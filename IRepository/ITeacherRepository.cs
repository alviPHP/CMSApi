using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int id);
        Task<Teacher> UpdateTeacher(int id, Teacher teacher);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(Teacher teacher);
    }
}
