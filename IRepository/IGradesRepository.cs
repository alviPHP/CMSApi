using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
    public interface IGradesRepository
    {
        Task<IEnumerable<Grade>> GetGrades();

        Task<Grade> GetGrade(int id);

        Task<Grade> UppdateGrade(int id, Grade grade);

        Task<Grade> AddGrade(Grade grade);

        Task<Grade> DeleteGrade(Grade grade);

        Task<IEnumerable<GradesInfo>> GetGradesInfo();

        Task<IEnumerable<GradesInfo>> GetStudentsDataByCourseId(int id);

        Task<IEnumerable<GradesInfo>> GetStudentsDataBySubjectId(int id);

        Task<IEnumerable<GradesInfo>> GetMarkSheetByStudentId(int id);

    }
}
