using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
   public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<Course> UpdateCourse(int id, Course course);
        Task<Course> AddCourse(Course course);
        Task<Course> DeleteCourse(Course course);
    }
}
