using Microsoft.AspNetCore.Mvc;
using Workshop3.EFCore.Data.EFCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetDataController : ControllerBase
{
    private readonly MusicWikiContext _context;

    public ResetDataController(MusicWikiContext context)
    {
        _context = context;
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public IActionResult Get()
    {
        foreach (var genre in GetGenres())
        {
            _context.Genres.Add(genre);
        }
        
        _context.SaveChanges();
        return Ok(_context.Artists.ToList());
    }

    private static IEnumerable<Genre> GetGenres()
    {
        return new[]
        {
            new Genre(){Name = "Trash Metal", Bands = new []
            {
                new Artist(){Name = "Metallica"},
                new Artist(){Name = "Megadeth"},
                new Artist(){Name = "Slayer"},
                new Artist(){Name = "Anthrax"},
            }},
            new Genre(){Name = "Heavy Metal", Bands = new[]
            {
                new Artist(){Name = "Iron Maiden"},
                new Artist(){Name = "Judas Priest"},
                new Artist(){Name = "Black Sabbath"},
                new Artist(){Name = "Accept"},
            }},
            new Genre(){Name = "Death Metal", Bands = new[]
            {
                new Artist(){Name = "Death"},
                new Artist(){Name = "Cannibal Corpse"},
                new Artist(){Name = "Morbid Angel"},
                new Artist(){Name = "Obituary"},
            }},
            new Genre(){Name = "Black Metal", Bands = new[]
            {
                new Artist(){Name = "Mayhem"},
                new Artist(){Name = "Darkthrone"},
                new Artist(){Name = "Emperor"},
                new Artist(){Name = "Burzum"},
            }},
            new Genre(){Name = "Power Metal", Bands = new[]
            {
                new Artist(){Name = "Helloween"},
                new Artist(){Name = "Blind Guardian"},
                new Artist(){Name = "Stratovarius"},
                new Artist(){Name = "Gamma Ray"},
            }},
            new Genre(){Name = "Progressive Metal", Bands = new[]
            {
                new Artist(){Name = "Dream Theater"},
                new Artist(){Name = "Symphony X"},
                new Artist(){Name = "Fates Warning"},
                new Artist(){Name = "Queensrÿche"},
            }},
        };
    }

    // private IEnumerable<Artist> GetArtists()
    // {
    //     // var thrash = _context.Genres.Single(x => x.Name == "Trash Metal");
    //     return new[]
    //     {
    //         new Artist()
    //         {
    //             Name = "Metallica"
    //         }
    //     };
    // }
}