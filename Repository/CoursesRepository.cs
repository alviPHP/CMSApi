using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSApi.Database;
using CMSApi.IRepository;
using CMSApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CMSApi.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly AppDbContext _context;
        public CoursesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Course> AddCourse(Course course)
        {
           _context.Courses.Add(course);
           await _context.SaveChangesAsync();
           return course;
        }
        public async Task<Course> DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return  await _context.Courses.ToListAsync();
        }
        public async Task<Course> GetCourse(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task<Course> UpdateCourse(int id, Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
