using Microsoft.AspNetCore.Mvc;
using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Controllers;

public class FooController : Controller
{
    private readonly ISomeBusinessLogicService _businessLogicService;
    
    // GET
    public FooController(ISomeBusinessLogicService businessLogicService)
    {
        _businessLogicService = businessLogicService;
    }

    public async Task<IActionResult> Index()
    {
        await _businessLogicService.DoStuffAsync();
        return View();
    }
}