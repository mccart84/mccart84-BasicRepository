using BasicRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicRepository.DAL
{
    public class Data
    {
        public static void InitializeCourses()
        {
            List<Course> courses = new List<Course>();

            courses.Add(new Course
            {
                ID = 1,
                Name = "Log Lake",
                Address = "2475 Log Lake Rd NE",
                City = "Kalkaska",
                State = StateEnum.StateAbrv.MI,
                Zip = "49646",
                Open = true,
                TimeStamp = Convert.ToDateTime("2015-10-23")
            });

            courses.Add(new Course
            {
                ID = 2,
                Name = "Hickory Hills",
                Address = "Hickory Hills Road",
                City = "Traverse City",
                State = StateEnum.StateAbrv.MI,
                Zip = "49684",
                Open = false,
                TimeStamp = Convert.ToDateTime("2015-12-25")
            });

            HttpContext.Current.Session["Courses"] = courses;
        }
    }
}