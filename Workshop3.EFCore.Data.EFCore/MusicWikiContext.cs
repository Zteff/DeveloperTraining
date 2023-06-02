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
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}