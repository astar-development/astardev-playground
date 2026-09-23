# CLAUDE.md

Guidance for Claude Code (claude.ai/code) in this repo.

Core commands, conventions, test style in AGENTS.md (imported below); this file adds architecture + gotchas spanning multiple files.

@AGENTS.md

## Commands (additions to AGENTS.md)

- Single test: `dotnet test --project <path/to/X.TestsUnit.csproj> --no-restore -- --filter-method "*when_some_name*"` (Microsoft.Testing.Platform + xUnit v3 via `global.json`; test projects `OutputType=Exe`).
- Coverage: `./code-coverage.sh` (MTP `--coverage` → `TestResults/`, then `reportgenerator` → `CoverageReport/`, excludes `*.g.cs`).
- CI (`.github/workflows/dotnet.yml`) runs only `*.TestsUnit.dll`; `.TestsIntegration` local-only.
- ControlDb EF migrations: `dotnet ef migrations add <Name> --project nuget-packages/AStarDev.ControlDb.Persistence`. `ControlDbContext` parameterless ctor falls back to in-memory SQLite → design-time tooling works without startup project.

## Architecture

- `nuget-packages/` = packable libs. Tests sit beside target as `<Project>.TestsUnit` / `<Project>.TestsIntegration`; `Directory.Build.props` auto-marks them non-packable (+ suppresses CA1707 etc.) by name.
- `Directory.Build.targets` fails pack if packable project lacks `Description`, `PackageTags` or license; adds `Microsoft.SourceLink.GitHub` to packable projects.
- All `bin/`/`obj/` output → `artifacts/bin/<ProjectName>/` and `artifacts/obj/<ProjectName>/`, not project folders.

### Source generators (`nuget-packages/source-generators/`)

- `AStarDev.SourceGeneratorAttributes`: marker attrs (`[StrongId]`, `[AutoRegisterService]` with `Layer`/`ServiceLifetime`, `[AutoRegisterOptions]`, `[AutoRegisterEndpoint]`).
- `AStarDev.SourceGenerators` (netstandard2.0, Roslyn component): generators in `StrongIdCodeGeneration/`, `ServiceRegistrationGeneration/`, `OptionsBindingGeneration/`. Custom MSBuild targets copy Attributes + SourceAnalyzers DLLs into output, pack all under `analyzers/dotnet/cs` → one package ships attrs, generators, diagnostics. Release notes in `<PackageReleaseNotes>` in csproj.
- `AStarDev.SourceAnalyzers`: diagnostics for correct attr usage (e.g. `[StrongId]` types must be `partial`). Track new diagnostic IDs in `AnalyzerReleases.Shipped.md`.
- Generator tests build in-memory compilations; `TestsUnit/Utilities/CompilationHelpers.cs` inlines attr source → update when attr shapes change.
- Consuming generators in-repo via project reference (not NuGet) needs `AddGeneratorAnalyzerRefs` target pattern from `AStarDev.ControlDb.Persistence.csproj`.

### ControlDb (in progress on the current branch)

- `AStarDev.ControlDb.Persistence`: EF Core + SQLite `ControlDbContext`. Entity configs in `Configurations/` picked up by `ApplyConfigurationsFromAssembly`. IDs = `[StrongId] partial record struct` types, extended via C# 14 `extension(...)` blocks (see `ScrapeConfigIdHelpers.cs`: adds `Empty`, `Create` (v7 GUID)).
- Immutable domain records live in `AStarDev.ControlDb`; mutable EF entities (same type names, own StrongId types) in `.Persistence`. Convert via `ScrapeConfigurationMappings`: `ToEntity()` (insert), `UpdateFrom(domain)` (copy onto tracked entity so EF saves changes, keeps `Id`), `ToDomain()`. Alias domain namespace (`using Domain = AStarDev.ControlDb;`) to disambiguate.
- Two C# 14 `extension(...)` blocks in one class whose receiver types share a name (domain vs entity) trigger CA1708 → use classic `this` extension methods.
- Integration tests: shared in-memory `SqliteConnection` per test class, call `EnsureCreated()`, build entities via `TestFactories/`.

## Testing notes

- Snapshot tests use Shouldly `ShouldMatchApproved()`: mismatch writes `*.received.txt` beside test; approve by renaming to `*.approved.txt`. Commit `.approved.txt`; never commit `.received.txt`.
- TDD commit history expected: commit failing test (`test:` or `[RED]`) before implementation.
