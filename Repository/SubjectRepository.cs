using CMSApi.Database;
using CMSApi.IRepository;
using CMSApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> DeleteSubject(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> GetSubject(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByCourseId(int id)
        {
            var subjects = await  (from cst in _context.CoursesSubjectsTeachers
                                 join s in _context.Subjects on cst.SubjectId equals s.Id
                                 where cst.CourseId == id
                                 select new Subject()
                                 {
                                     Id = cst.SubjectId,
                                     Name = cst.Subject.Name

                                 }).ToListAsync();

            return subjects;
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
             await _context.SaveChangesAsync();
            return subject;
        }
    }
}
