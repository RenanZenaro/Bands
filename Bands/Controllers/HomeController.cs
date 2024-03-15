using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Bands.Models;

namespace Bands.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Banda> bandas = [];
        using (StreamReader leitor = new("Data\\bandas.json"))
        {
            string dados = leitor.ReadToEnd();
            bandas = JsonSerializer.Deserialize<List<Banda>>(dados);
        }
        return View(bandas);
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
