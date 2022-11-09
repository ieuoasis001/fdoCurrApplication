using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace fdoCurrApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login login)
        {


            return View();
        }

    }
}
