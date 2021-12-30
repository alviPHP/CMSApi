using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    /*
     * Created By : Sohaib Alvi
     * Created Date : 12/18/2021 3:30PM
     * Description : This class contains the Ids of Course,Subject,Teacher tables.
     */

    public class CourseSubjectTeacher
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public int CourseId
        {
            get; set;
        }
        public int SubjectId
        {
            get; set;
        }
        public int TeacherId
        {
            get; set;
        }       
        public Course Course { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public List<Grade> Grades { get; set; }

    }
}
