using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaysOfWeek.Models;

namespace DaysOfWeek.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public string DaysWeek(int dayNum)
    {
        string[] days = {"Digite um valor válido", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        if ((dayNum >= 1) && (dayNum <= 7)) { return days[dayNum]; }
        else { return days[0]; }
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
