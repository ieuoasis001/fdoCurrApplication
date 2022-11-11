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


                List<ResponseCurrElecStuCount> responseCurrElecStuCount = (from _course in _context.course
                                  join _currElecStuCount in _context.currElecStuCount on
                                  new { fdo =_course.fdo, uni_code =_course.uniCode }
                                     equals new { fdo = _currElecStuCount.fdo, uni_code=_currElecStuCount.uniCode }
                                     orderby _currElecStuCount.stuCount descending
                                  select new ResponseCurrElecStuCount
                                  (){
                                      courseId= _course.courseId,
                                      f = _course.f,
                                      fdo = _course.fdo,
                                      faculty = _course.faculty,
                                      department = _course.department,
                                      uniCode = _course.uniCode,
                                      courseName = _course.courseName,
                                      ects = _course.ects,
                                      credit= _course.credit,
                                      stuCount= _currElecStuCount.stuCount,
                                      overallCount= _context.currElecStuCount.Where(x=>x.uniCode==_course.uniCode).Select(x=>x.overallCount).FirstOrDefault()
                                  }).Where(k=>k.fdo== lec.fdo_id).ToList();

                ResponseCurr list = new ResponseCurr()
                {
                    currList = curr,
                    currElecStuCountList= responseCurrElecStuCount
                };

                return Json(new SuccessResponse() { status = 200, Response = list });
            }

            return Json(new ErrorMessage() { status = 500, message = "Accsess Token Hatası" });

        
            

        }

       
    }
}

