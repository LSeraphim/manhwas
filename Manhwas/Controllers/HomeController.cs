using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Manhwas.Models;
using System.Text.Json;

namespace Manhwas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Manhwa> manhwas = GetManhwas();
        List<Genero> generos = GetGeneros();
        ViewData["Generos"] = generos;
        return View(manhwas);
    }

    public IActionResult Details(int id) 
    {
        List<Manhwa> manhwas = GetManhwas();
        List<Genero> generos = GetGeneros();
        DetailsVM details = new() {
            Generos = generos,
            Atual = manhwas.FirstOrDefault(m => m.Numero == id),
            Anterior = manhwas.OrderByDescending(m => m.Numero).FirstOrDefault(m => m.Numero < id),
            Proximo = manhwas.OrderBy(m => m.Numero).FirstOrDefault(m => m.Numero > id),
        };
        return View(details);
    }

    private List<Manhwa> GetManhwas()
    {
        using (StreamReader leitor = new("Data\\manhwas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Manhwa>>(dados);
        }
    }

    
    private List<Genero> GetGeneros()
    {
        using (StreamReader leitor = new("Data\\generos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Genero>>(dados);
        }
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
