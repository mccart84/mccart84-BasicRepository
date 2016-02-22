using BasicRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRepository.DAL
{
    interface ICourseRepository
    {
        IEnumerable<Course> SelectAll();
        Course SelectById(int id);
        void Insert(Course course);
        void Update(Course course);
        void Delete(int id);
        void Save();
        int GetNextID();
    }
}
