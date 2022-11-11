using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
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

        [HttpGet]
        public JsonResult List(string id)
        {
            int page = Int32.Parse(HttpContext.Request.Query["id"]);

            Lecturer lec = _context.lecturerInfo
         .Where(x => x.lec_id == page).FirstOrDefault();

            if (lec != null)
            {
                List<Curr> curr = _context.curr.Where(x => x.fdo == lec.fdo_id).ToList();
                List<CurrElecStuCount> course= _context.currElecStuCount.ToList();

                ResponseCurr list = new ResponseCurr()
                {
                    currElecStuCountList = course,
                    currList = curr
                };

                return Json(new SuccessResponse() { status = 200, Response = list });
            }

            return Json(new ErrorMessage() { status = 500, message = "Accsess Token Hatası" });

        
            

        }

       
    }
}

