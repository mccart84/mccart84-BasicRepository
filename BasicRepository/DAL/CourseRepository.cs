using BasicRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicRepository.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private List<Course> courses = null;

        public CourseRepository()
        {
            this.courses = (List<Course>)HttpContext.Current.Session["Courses"];
        }

        public CourseRepository(List<Course> courses)
        {
            this.courses = courses;
        }

        public void Delete(int id)
        {
            var index = this.courses.FindIndex(a => a.ID == id);

            if (index != -1)
                this.courses.RemoveAt(index);
            else
                throw new ArgumentException("CourseNotFound");
        }

        public int GetNextID()
        {
            return this.courses.Max(x => x.ID) + 1;
        }

        public void Insert(Course course)
        {
            this.courses.Add(course);
        }

        public void Save()
        {
            //Implement to save to SQL database
            throw new NotImplementedException();
        }

        public IEnumerable<Course> SelectAll()
        {
            return this.courses;
        }

        public Course SelectById(int id)
        {
            var index = courses.FindIndex(a => a.ID == id);

            if (index != -1)
                return this.courses[index];
            else
                throw new ArgumentException("CourseNotFound");
        }

        public void Update(Course course)
        {
            var index = this.courses.FindIndex(a => a.ID == course.ID);

            if (index != -1)
                this.courses[index] = course;
            else
                throw new ArgumentException("CourseNotFound");
        }
    }
}