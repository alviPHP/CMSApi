using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Model
{
    public class GradesInfo
    {
        public int Id
        {
            get; set;
        }
        public int Marks
        {
            set; get;
        }

        private double _averagemarks;
        public double AverageMarks
        {
            get { return _averagemarks; }
            set
            {
                _averagemarks = value;
                if (_averagemarks >= 50 && _averagemarks < 60)
                    Grade_Code = "C";
                else if (_averagemarks >= 60 && _averagemarks < 70)
                    Grade_Code = "B";
                else if (_averagemarks >= 70 && _averagemarks < 80)
                    Grade_Code = "A";
                else if (_averagemarks >= 80 && _averagemarks < 100)
                    Grade_Code = "A1";
                else
                    Grade_Code = "Unknown";
            }
        }
        public string Grade_Code
        {
            set;
            get;
        }
        public int StudentId 
        { 
            get;
            set; 
        }
        public string StudentName 
        { 
            get; 
            set; 
        }
        public int CourseId 
        {
            get; 
            set; 
        }
        public string CourseName 
        { 
            get;
            set; 
        }
        public int SubjectId
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public string RegistrationNo
        { set; get; }

    }
}
