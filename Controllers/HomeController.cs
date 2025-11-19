using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using provateste.Models;

namespace provateste.Controllers;

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
    public IActionResult LoginRedirect()
    {
        // Se não estiver autenticado → vai para o Login
        if (!User.Identity.IsAuthenticated)
            return Redirect("/Identity/Account/Login");

        // Se estiver autenticado → vai para o CRUD
        return RedirectToAction("Index", "Produtos");
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
