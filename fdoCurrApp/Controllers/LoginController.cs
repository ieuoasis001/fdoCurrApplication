using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace fdoCurrApp.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Login login)
        {
            //Lecturer lec = _context.lecturerInfo.SingleOrDefault(x => x.lec_id == login.lec_id && x.lec_id == login.lec_id);

            Lecturer lec = _context.lecturerInfo
         .Where(x => x.lec_id == login.lec_id && x.lec_pass==login.lec_pass).FirstOrDefault();

            return Json(lec);
        }

    }
}
