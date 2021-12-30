using CMSApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.IRepository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubject(int id);
        Task<Subject> UpdateSubject(int id, Subject subject);
        Task<Subject> AddSubject(Subject subject);
        Task<Subject> DeleteSubject(Subject subject);
        Task<IEnumerable<Subject>> GetSubjectsByCourseId(int id);
    }
}
