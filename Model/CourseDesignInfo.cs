using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    public class CourseDesignInfo
    {
        public int Id
        {
            get; set;
        }
        public int CourseId
        {
            get; set;
        }
        public string CourseName
        {
            get; set;
        }
        public int SubjectId
        {
            get; set;
        }
        public string SubjectName
        {
            get; set;
        }
        public int TeacherId
        {
            get; set;
        }
        public string TeacherName
        {
            get; set;
        }
    }
}
