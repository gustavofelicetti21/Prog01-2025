using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NumToWords.Models;

namespace NumToWords.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new Numbers();
        return View(model);
    }

    [HttpPost]
    public IActionResult Numbers(Numbers model)
    {
        model.numInText = model.NumberConvert(model.userInput);
        return View("Index", model);
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
