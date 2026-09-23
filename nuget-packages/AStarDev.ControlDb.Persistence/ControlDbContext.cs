using Microsoft.EntityFrameworkCore;

namespace AStarDev.ControlDb.Persistence;

public class ControlDbContext : DbContext
{
    public ControlDbContext(DbContextOptions<ControlDbContext> options) : base(options)
    {

    }

    public ControlDbContext() : this(new DbContextOptions<ControlDbContext>())
    {

    }

    public DbSet<ScrapeConfiguration> ScrapeConfigurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=:memory:");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlDbContext).Assembly);
    }
}
