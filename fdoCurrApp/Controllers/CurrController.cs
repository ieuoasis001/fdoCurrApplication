using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
;

namespace fdoCurrApp.Controllers
{
    public class CurrController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "aaaaMüfredat kontrol sayfası";
            ViewBag.Message = "Sadece Seçmeli Ders İçerikleri Girilecektir";

            Curr curriculum = new Curr();
            curriculum.uniCode = "ACC 100";
            curriculum.courseName = "Matematik";

          return View(curriculum);
        }

        private readonly ILogger<CurrController> _logger;

        public CurrController(ILogger<CurrController> logger)
        {
            _logger = logger;
        }
    }
}

