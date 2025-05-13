using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula05Projeto.Models;
using Aula05;

namespace Aula05Projeto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    

    public IActionResult Index()
    {
        Custumer c1 = new Custumer();
        c1.Name = "Frodo";
        c1.ObjectCount++;
        Custumer.InstantCount++;

        var c2 = new Custumer();
        c2.Name = "Galadriel";
        c2.ObjectCount++;
        Custumer.InstantCount++;

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
