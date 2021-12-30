using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    /*
    * Created By : Sohaib Alvi
    * Created Date : 12/18/2021 3:41 PM
    * Description : This class contains the data of Subject.
    */
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseSubjectTeacher> CourseSubjectTeachers { get; set; }

    }
}
