using CMSApi.Database;
using CMSApi.IRepository;
using CMSApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeacher(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
