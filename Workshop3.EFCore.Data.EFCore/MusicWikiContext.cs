using Microsoft.EntityFrameworkCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.Data.EFCore;

public class MusicWikiContext : DbContext
{
    private readonly string _connectionString;

    public MusicWikiContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Artist> Artists { get; set; }
    // public DbSet<Genre> Genres { get; set; }
    public DbSet<Album> Albums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Artist>().HasData(new[]
        {
            new Artist() { Id=1,Name = "Metallica" },
            new Artist() { Id=2,Name = "Megadeth" },
            new Artist() { Id=3,Name = "Slayer" },
            new Artist() { Id=4,Name = "Anthrax" }
        });
    }
}