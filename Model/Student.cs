using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    /*
    * Created By : Sohaib Alvi
    * Created Date : 12/18/2021 3:35PM
    * Description : This class contains the data of Student.
    */
    public class Student
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
        public DateTime DOF
        {
            get;set;
        }
        public string RegNo
        {
            get;set;
        }

        public List<Grade> Grades { get; set; }
        
        
    }
}
