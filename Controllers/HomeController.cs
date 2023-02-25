using Microsoft.AspNetCore.Mvc;

namespace ministers_of_sweden.web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
