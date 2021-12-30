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
    public class GradesRepository : IGradesRepository
    {
        private readonly AppDbContext _context = null;

        public GradesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Grade> AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> DeleteGrade(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return grade;

        }

        public async Task<Grade> GetGrade(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task<IEnumerable<Grade>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<IEnumerable<GradesInfo>> GetGradesInfo()
        {
            var gradesInfo = await(from grds in _context.Grades
                                   join cst in _context.CoursesSubjectsTeachers on grds.CourseSubjectTeacherId equals cst.Id
                                   join cs in _context.Courses on cst.CourseId equals cs.Id
                                   join sb in _context.Subjects on cst.SubjectId equals sb.Id
                                   join s in _context.Students on grds.StudentId equals s.Id
                                   select new GradesInfo()
                                   {
                                       Id = grds.Id,
                                       CourseId = cs.Id,
                                       CourseName = cs.Name,
                                       SubjectId = sb.Id,
                                       SubjectName = sb.Name,
                                       StudentId = s.Id,
                                       StudentName = s.FName + ' ' + s.LName,
                                       Marks = grds.Marks,
                                       Grade_Code = grds.Grade_Code,
                                       RegistrationNo = s.RegNo

                                   }).ToListAsync();

            return gradesInfo;
        }

        public async Task<IEnumerable<GradesInfo>> GetStudentsDataByCourseId(int id)
        {//GetStudentsDataByCourseId
            var studentData = await(from grds in _context.Grades
                                    join cst in _context.CoursesSubjectsTeachers on grds.CourseSubjectTeacherId equals cst.Id
                                    join s in _context.Students on grds.StudentId equals s.Id
                                    where cst.CourseId == id
                                    select new GradesInfo()
                                    {
                                        StudentName = s.FName + ' ' + s.LName,
                                        Marks = grds.Marks,
                                        RegistrationNo = s.RegNo

                                    }).ToListAsync();


            var studentDataGroup = (from std in studentData
                                    group std by
                                    new
                                    {
                                        std.RegistrationNo,
                                        std.StudentName
                                    }
                                    into g
                                    select new GradesInfo
                                    {
                                        StudentName = g.Key.StudentName,
                                        RegistrationNo = g.Key.RegistrationNo,
                                        AverageMarks = Math.Round(g.Average(p => p.Marks))

                                    }).ToList();

            return studentDataGroup;
        }

        public async Task<IEnumerable<GradesInfo>> GetStudentsDataBySubjectId (int id)
        {//
            var studentData = await (from grds in _context.Grades
                                     join cst in _context.CoursesSubjectsTeachers on grds.CourseSubjectTeacherId equals cst.Id
                                     join c in _context.Courses on cst.CourseId equals c.Id
                                     join s in _context.Students on grds.StudentId equals s.Id
                                     where cst.SubjectId == id
                                     select new GradesInfo()
                                     {
                                         CourseName = c.Name,
                                         StudentName = s.FName + ' ' + s.LName,
                                         Marks = grds.Marks,
                                         RegistrationNo = s.RegNo,
                                         Grade_Code = grds.Grade_Code


                                     }).ToListAsync();

            return studentData;
        }

        public async Task<IEnumerable<GradesInfo>> GetMarkSheetByStudentId(int id)
        {
            
               var studentData = await (from grds in _context.Grades
                                     join cst in _context.CoursesSubjectsTeachers on grds.CourseSubjectTeacherId equals cst.Id
                                     join sb in _context.Subjects on cst.SubjectId equals sb.Id
                                     where grds.StudentId == id
                                     select new GradesInfo()
                                     {
                                         SubjectName = sb.Name,
                                         Marks = grds.Marks,
                                         Grade_Code = grds.Grade_Code
                                     }).ToListAsync();

            return studentData;
        }

        public async Task<Grade> UppdateGrade(int id, Grade grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return grade;
        }
    }
}
