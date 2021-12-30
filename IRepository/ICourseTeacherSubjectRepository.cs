using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
    public interface ICourseTeacherSubjectRepository
    {
        Task<IEnumerable<CourseSubjectTeacher>> GetCoursesSubjectsTeachers();

        Task<CourseSubjectTeacher> GetCourseSubjectTeacher(int id);

        Task<CourseSubjectTeacher> UpdateCourseSubjectTeacher(int id, CourseSubjectTeacher courseSubjectTeacher);

        Task<CourseSubjectTeacher> AddCourseSubjectTeacher(CourseSubjectTeacher courseSubjectTeacher);

        Task<CourseSubjectTeacher> DeleteCourseSubjectTeacher(CourseSubjectTeacher courseSubjectTeacher);

        Task<IEnumerable<CourseDesignInfo>> GetCourseDesignInfo();

        Task<IEnumerable<CourseDesignInfo>> GetTeachersDataByCourseId(int id);

        Task<IEnumerable<CourseDesignInfo>> GetTeachersDataBySubjectId(int id);

        int GetCompositeKeyId(int courseId, int subjectId);

    }
}
