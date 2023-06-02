namespace Workshop3.EFCore.Domain;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Artist> Bands { get; set; }
}