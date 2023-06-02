using Microsoft.EntityFrameworkCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.Data.EFCore;

public class MusicWikiContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
}