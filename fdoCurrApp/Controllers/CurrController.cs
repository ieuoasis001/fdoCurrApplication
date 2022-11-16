using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System;
using System.Collections;
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
                return Json(new SuccessResponse() { status = 200, Response = curr });
            }

            return Json(new ErrorMessage() { status = 500, message = "Accsess Token Hatası" });




        }

        [HttpPost]
        public JsonResult Eleclist(ElecListRequest ecurr)
        {
            Lecturer lec = _context.lecturerInfo
       .Where(x => x.lec_id == ecurr.lec_id).FirstOrDefault();
            if (lec != null)
            {

                Fdo fdo_lang = _context.fdo.Where(x => x.id == lec.fdo_id).FirstOrDefault();

                List<ResponseCurrElecCourses> currElecCourses =
                     (from _course_elec in _context.currElecCourses
                      join _course in _context.course on _course_elec.courseId equals _course.courseId
                      select new ResponseCurrElecCourses
                      {
                          course = _course,
                          currElecCourses = _course_elec
                      })
                      .Where(k => k.currElecCourses.currCode == ecurr.currCode && k.currElecCourses.uniCode == ecurr.uniCode)
                      .ToList();


                var responseCurrElecStuCount =
                 (from _course in _context.course
                  select new
                  {
                      course = _course
                  })
                  .Where(k => k.course.ects>= ecurr.ects && ((fdo_lang.deptLangCode == 0 && k.course.deptLangCode != 0) || (fdo_lang.deptLangCode != 0 && k.course.deptLangCode == 0)))
                  .OrderBy(k=>k.course.uniCode)
                  .ToList();

              



                ResponseElecCurr responseElecCurr = new ResponseElecCurr()
                {
                    course = responseCurrElecStuCount.Where(x => currElecCourses.All(a => a.course.courseId != x.course.courseId)).Select(x => new Course
                    {
                        courseId = x.course.courseId,
                        f = x.course.f,
                        fdo = x.course.fdo,
                        faculty = x.course.faculty,
                        department = x.course.department,
                        uniCode = x.course.uniCode,
                        courseName = x.course.courseName,
                        ects = x.course.ects,
                        credit = x.course.credit
                    }).ToList(),
                    currElecCourses = currElecCourses
                };


                return Json(new SuccessResponse() { status = 200, Response = responseElecCurr });
            }

            return Json(new ErrorMessage() { status = 500, message = "Accsess Token Hatası" });
        }


        [HttpPost]
        public JsonResult AddElec(CurrElecCourses ecurr)
        {

            CurrElecCourses currElecCourses = _context.currElecCourses.Where(x => x.courseId == ecurr.courseId && x.currCode == ecurr.currCode && x.uniCode == ecurr.uniCode).FirstOrDefault();

            if (currElecCourses != null)
            {
                return Json(new SuccessResponse() { status = 500, Response = "Bu ders daha önceden bu müfredata eklenmiştir." });
            }

            ecurr.createdDate = DateTime.Now;
            _context.currElecCourses.Add(ecurr);
            _context.SaveChanges();

            return Json(new SuccessResponse() { status = 200, Response = "Ders Başarılı bir şekilde eklenmiştir." });


        }

        [HttpPost]
        public JsonResult DeleteElec(int id)
        {
            CurrElecCourses currElecCourses = _context.currElecCourses.Where(x => x.id == id).FirstOrDefault();

            if (currElecCourses != null)
            {
                _context.currElecCourses.Remove(currElecCourses);
                _context.SaveChanges();
                return Json(new SuccessResponse() { status = 200, Response = "Ders ilgili müfredat ve seçmeli grubundan kaldırılmıştır." });
            }


            return Json(new SuccessResponse() { status = 500, Response = "Ders bulunamadı" });


        }
    }
}

