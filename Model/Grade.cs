using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    /*
     * Created By : Sohaib Alvi
     * Created Date : 12/18/2021 3:31PM
     * Description : This class contains the Student table as well as the CourseSubjectTeacher tables and data related to student's marks and grades.
     */
    public class Grade
    {
        [Key]
        public int Id
        {
            get; set;
        }

        private int _marks;
        public int Marks
        {
            get { return _marks; }
            set
            {
                _marks = value;
                if (_marks >= 50 && _marks < 60)
                    Grade_Code = "C";
                else if(_marks >= 60 && _marks < 70 )
                    Grade_Code = "B";
                else if (_marks >= 70 && _marks < 80)
                    Grade_Code = "A";
                else if (_marks >= 80 && _marks < 100)
                    Grade_Code = "A1";
                else
                    Grade_Code = "FAILED";
            }
        }
        public string Grade_Code
        {
            set;get;
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseSubjectTeacherId { get; set; }
        public CourseSubjectTeacher CourseSubjectTeachers { get; set; }     
    }
}
