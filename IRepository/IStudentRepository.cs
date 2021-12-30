using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> AddStudent(Student student);
        Task<Student> DeleteStudent(Student student);
    }
}
