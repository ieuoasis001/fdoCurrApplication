using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace fdoCurrApp.Controllers
{
    public class CurrController : Controller
    {
        private ApplicationDbContext _context;

        public CurrController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            List<Curr> curr = _context.curr.ToList();
            return View("Index", curr);
        }

       
    }
}

