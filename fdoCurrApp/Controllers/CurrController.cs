using Microsoft.AspNetCore.Mvc;

namespace fdoCurrApp.Controllers
{
    public class CurrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
