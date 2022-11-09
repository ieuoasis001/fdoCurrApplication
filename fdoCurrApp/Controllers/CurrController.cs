using Microsoft.AspNetCore.Mvc;

namespace fdoCurrApp.Controllers
{
    public class CurrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD

        private readonly ILogger<CurrController> _logger;

        public CurrController(ILogger<CurrController> logger)
        {
            _logger = logger;
        }
    }
}

=======
    }
}
>>>>>>> origin/main
