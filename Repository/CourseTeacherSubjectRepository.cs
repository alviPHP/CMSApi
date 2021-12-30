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
    public class CourseTeacherSubjectRepository : ICourseTeacherSubjectRepository
    {
        private readonly AppDbContext _context;

        public CourseTeacherSubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CourseSubjectTeacher> AddCourseSubjectTeacher(CourseSubjectTeacher courseSubjectTeacher)
        {
            _context.CoursesSubjectsTeachers.Add(courseSubjectTeacher);
            await _context.SaveChangesAsync();
            return courseSubjectTeacher;

        }

        public async Task<CourseSubjectTeacher> DeleteCourseSubjectTeacher(CourseSubjectTeacher courseSubjectTeacher)
        {
            _context.CoursesSubjectsTeachers.Remove(courseSubjectTeacher);
            await _context.SaveChangesAsync();
            return courseSubjectTeacher;
        }

        public int GetCompositeKeyId(int courseId, int subjectId)
        {
            return _context.CoursesSubjectsTeachers.Where(e => e.CourseId == courseId && e.SubjectId == subjectId).Select(e => e.Id).FirstOrDefault();
        }

        public async Task<IEnumerable<CourseDesignInfo>> GetCourseDesignInfo()
        {
            var courseDesignInfo = await (from cst in _context.CoursesSubjectsTeachers
                                          join c in _context.Courses on cst.CourseId equals c.Id
                                          join s in _context.Subjects on cst.SubjectId equals s.Id
                                          join t in _context.Teachers on cst.TeacherId equals t.Id
                                          select new CourseDesignInfo()
                                          {
                                              Id = cst.Id,
                                              CourseId = cst.CourseId,
                                              CourseName = cst.Course.Name,
                                              SubjectId = cst.SubjectId,
                                              SubjectName = cst.Subject.Name,
                                              TeacherId = cst.TeacherId,
                                              TeacherName = cst.Teacher.FName + ' ' + cst.Teacher.LName
                                          }).ToListAsync();

            return courseDesignInfo;
        }

        public async Task<IEnumerable<CourseSubjectTeacher>> GetCoursesSubjectsTeachers()
        {
            return await _context.CoursesSubjectsTeachers.ToListAsync();
        }

        public async Task<CourseSubjectTeacher> GetCourseSubjectTeacher(int id)
        {
            return await _context.CoursesSubjectsTeachers.FindAsync(id);
        }

        public async Task<IEnumerable<CourseDesignInfo>> GetTeachersDataByCourseId(int id)
        {
            var teacher = await (from cst in _context.CoursesSubjectsTeachers
                                 join s in _context.Subjects on cst.SubjectId equals s.Id
                                 join t in _context.Teachers on cst.TeacherId equals t.Id
                                 where cst.CourseId == id
                                 select new CourseDesignInfo()
                                 {
                                     SubjectName = cst.Subject.Name,
                                     TeacherName = cst.Teacher.FName + ' ' + cst.Teacher.LName
                                 }).ToListAsync();

            return teacher;
        }

        public async Task<IEnumerable<CourseDesignInfo>> GetTeachersDataBySubjectId(int id)
        {
            var teacher = await (from cst in _context.CoursesSubjectsTeachers
                                 join c in _context.Courses on cst.CourseId equals c.Id
                                 join s in _context.Subjects on cst.SubjectId equals s.Id
                                 join t in _context.Teachers on cst.TeacherId equals t.Id
                                 where cst.SubjectId == id
                                 select new CourseDesignInfo()
                                 {
                                     CourseName = cst.Course.Name,
                                     TeacherName = cst.Teacher.FName + ' ' + cst.Teacher.LName
                                 }).ToListAsync();

            return teacher;
        }

        public async Task<CourseSubjectTeacher> UpdateCourseSubjectTeacher(int id, CourseSubjectTeacher courseSubjectTeacher)
        {
            _context.Entry(courseSubjectTeacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return courseSubjectTeacher;
        }
    }
}
