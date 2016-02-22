using BasicRepository.Models;
using BasicRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicRepository.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseRepository cr = null;

        public CoursesController()
        {
            this.cr = new CourseRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            return View(cr.SelectAll());
        }

        public ActionResult ShowDetail(int id)
        {
            return View(cr.SelectById(id));
        }

        public ActionResult DeleteCourse(int id)
        {
            return View(cr.SelectById(id));
        }

        [HttpPost]
        public ActionResult DeleteCourse(FormCollection form)
        {
            if (form["operation"] == "Delete")
                cr.Delete(Convert.ToInt32(form["ID"]));

            return RedirectToAction("ShowTable");
        }

        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                Course newCourse = new Course()
                {
                    ID = cr.GetNextID(),
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = (StateEnum.StateAbrv)Enum.Parse(typeof(StateEnum.StateAbrv), form["state"]),
                    Zip = form["zip"],
                    Open = Convert.ToBoolean(form["open"]),
                    TimeStamp = DateTime.Today
                };

                cr.Insert(newCourse);
            }

            return RedirectToAction("ShowTable");
        }

        public ActionResult UpdateCourse(int id)
        {
            return View(cr.SelectById(id));
        }

        [HttpPost]
        public ActionResult UpdateCourse(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                Course updatedCourse = new Course()
                {
                    ID = Convert.ToInt32(form["ID"]),
                    Name = form["Name"],
                    Address = form["Address"],
                    City = form["City"],
                    State = (StateEnum.StateAbrv)Enum.Parse(typeof(StateEnum.StateAbrv), form["State"]),
                    Zip = form["Zip"],
                    Open = Convert.ToBoolean(form["Open"]),
                    TimeStamp = Convert.ToDateTime(DateTime.Today)
                };

                cr.Update(updatedCourse);
            }

            return RedirectToAction("ShowTable");
        }
    }
}