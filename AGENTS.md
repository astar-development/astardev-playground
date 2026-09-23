# AGENTS

.NET 10 playground + library workspace. Prefer existing project patterns over ad hoc conventions.

## Primary commands

Run from repo root:

- Restore/build: `dotnet restore AStarDev.Playground.slnx`
- Build: `dotnet build AStarDev.Playground.slnx --no-restore`
- Test all projects: `dotnet test AStarDev.Playground.slnx --no-restore`
- Run a single test project: `dotnet test AStarDev.Playing.TestsUnit/AStarDev.Playing.TestsUnit.csproj --no-restore`

Solution uses Microsoft.Testing.Platform. Tests run via `dotnet test`, no custom wrappers.

## Repo layout

- `AStarDev.Playground.slnx` — root solution
- `AStarDev.Playing/` — Avalonia desktop app
- `AStarDev.Playing.TestsUnit/` — app tests
- `nuget-packages/` — reusable libs + source generator packages
- `artifacts/` — build output, redirected by repo-wide MSBuild props

## Hard repo conventions

- Default target `net10.0` via root `Directory.Build.props`.
- `TreatWarningsAsErrors=true` repo-wide; leave no compiler warnings.
- `Nullable`, `ImplicitUsings`, analyzers enabled globally.
- NuGet versions centrally managed in `Directory.Packages.props`; no ad hoc package versions in project files unless explicitly required.
- Test project suffixes: `.TestsUnit`, `.TestsIntegration`; intentionally not packable.
- TDD expected: add/update focused failing test before implementing fix.

## Test style and naming

- xUnit v3 + `Shouldly` + `NSubstitute`.
- Test names follow repo pattern: `when_[action]_then_[outcome]`.
- Validate real behavior; avoid mock-only assertions when real contract or integration boundary available.

## Contribution guidance

- Small, focused PRs; `.github/CONTRIBUTING.md` is source of truth for workflow.
- Conventional commit prefixes: `feat:`, `fix:`, `test:`, `refactor:`, `docs:`.
- Follow existing layered architecture + constructor-based DI.

## Documentation and references

- [README.md](README.md)
- [.github/CONTRIBUTING.md](.github/CONTRIBUTING.md)
- [Directory.Build.props](Directory.Build.props)
- [Directory.Packages.props](Directory.Packages.props)
- [AStarDev.Playground.slnx](AStarDev.Playground.slnx)

These files are authoritative. Check them before adding new patterns, dependencies, or repo-wide conventions.
