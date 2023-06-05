namespace Workshop3.EFCore.Domain;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    // public virtual Genre Genre { get; set; }
    public List<Album> Albums { get; set; }
}