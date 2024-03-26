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
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        ViewData["Tipos"] = tipos;
        return View(bandas);
    }

    public IActionResult Details(int id)
    {
        List<Banda> bandas = [];
        using (StreamReader leitor = new("Data\\bandas.json"))
        {
            string dados = leitor.ReadToEnd();
            bandas = JsonSerializer.Deserialize<List<Banda>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = bandas.FirstOrDefault(p => p.Numero == id),
            Anterior = bandas.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = bandas.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
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
