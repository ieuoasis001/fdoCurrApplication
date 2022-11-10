using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

      
        public ActionResult Index()
        {
            List<Curr> curr = _context.curr.ToList();
            return View("Index", curr);
        }

       
    }
}

