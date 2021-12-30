using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    /*
     * Created By : Sohaib Alvi
     * Created Date : 12/18/2021 3:34PM
     * Description : This class contains the data of Teacher.
     */
    public class Teacher
    {
        [Key]
        
        public int Id
        {
            get; set;
        }
        public string FName
        {
            get; set;
        }
        public string LName
        {
            get; set;
        }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOF
        {
            get; set;
        }
        public int Salary
        {
            get; set;
        }
        public List<CourseSubjectTeacher> CourseSubjectTeachers { get; set; }
    }
}
