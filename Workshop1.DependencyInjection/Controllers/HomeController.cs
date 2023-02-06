using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workshop1.DependencyInjection.Interfaces;
using Workshop1.DependencyInjection.Models;

namespace Workshop1.DependencyInjection.Controllers;

public class HomeController : Controller
{
    private readonly ITransientOperation _transientOperation;
    private readonly ITransientOperation _otherTransientOperation;
    private readonly IScopedOperation _scopedOperation;
    private readonly IScopedOperation _otherScopedOperation;
    private readonly ISingletonOperation _singletonOperation;
    private readonly ISingletonOperation _otherSingletonOperation;

    public HomeController( 
        ITransientOperation transientOperation, 
        IScopedOperation scopedOperation,
        ISingletonOperation singletonOperation,
        ITransientOperation otherTransientOperation, 
        IScopedOperation otherScopedOperation, 
        ISingletonOperation otherSingletonOperation)
    {
        _scopedOperation = scopedOperation;
        _transientOperation = transientOperation;
        _singletonOperation = singletonOperation;
        _otherTransientOperation = otherTransientOperation;
        _otherScopedOperation = otherScopedOperation;
        _otherSingletonOperation = otherSingletonOperation;
    }

    public IActionResult Index()
    {
        ViewBag.TransientGuid = _transientOperation.OperationId;
        ViewBag.TransientGuid2 = _otherTransientOperation.OperationId;
        ViewBag.ScopedGuid = _scopedOperation.OperationId;
        ViewBag.ScopedGuid2 = _otherScopedOperation.OperationId;
        ViewBag.SingletonGuid = _singletonOperation.OperationId;
        ViewBag.SingletonGuid2 = _otherSingletonOperation.OperationId;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}