using Microsoft.AspNetCore.Mvc;
using Workshop3.EFCore.Data.EFCore;

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
        return Ok(_context.Artists.ToList());
    }
}