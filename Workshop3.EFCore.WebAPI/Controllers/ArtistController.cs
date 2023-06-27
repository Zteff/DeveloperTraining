using Microsoft.AspNetCore.Mvc;
using Workshop3.EFCore.Data.EFCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly MusicWikiContext _context;

    public ArtistController(MusicWikiContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public IActionResult Get()
    {
        // UpdateDemo();

        return Ok(_context.Artists.ToList());
    }

    private void UpdateDemo()
    {
        var master = _context.Albums.Single(x => x.Id == 3);
        master.Title = "Master of Puppies";
        // master.ReleaseDate = new DateTime(1986, 3, 3);
        // var album = new Album() { Id = 3, Title = "Master!", ArtistId = 1};
        // _context.Albums.Update(album);
        _context.SaveChanges();
    }
}