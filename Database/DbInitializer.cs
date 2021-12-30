using CMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Database
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            if (context.Courses.Any()
                || context.Subjects.Any()
                || context.Teachers.Any()
                || context.Students.Any()
                ) return;

            #region Add Courses

            var courses = new List<Course>
            {
                new Course
                {
                    Name = "BSSE"
                },
                new Course
                {
                    Name = "BSCS"
                },
                new Course
                {
                    Name = "BSIT"
                },
            };

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            context.SaveChanges();

            #endregion

            #region Add Subjects

            var subjects = new List<Subject>
            {
                new Subject
                {
                    Name = "Data Structures"
                },
                new Subject
                {
                    Name = "Relational Database Management System"
                },
                new Subject
                {
                    Name = "Introduction to Computer Science"
                },
                new Subject
                {
                    Name = "Introduction to C Programming"
                },
                new Subject
                {
                    Name = "Data Communication and Networking"
                },
                new Subject
                {
                    Name = "Information Technology"
                },
                new Subject
                {
                    Name = "Business Communication"
                },
                new Subject
                {
                    Name = "Economics"
                }
            };

            foreach (var subject in subjects)
            {
                context.Subjects.Add(subject);
            }

            context.SaveChanges();

            #endregion

            #region Add Teachers

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FName ="Tim",
                    LName = "Core",
                    DOF = Convert.ToDateTime("1980-02-15"),
                    Salary = 5000
                },
                new Teacher
                {
                    FName ="Uncle",
                    LName = "Bob",
                    DOF = Convert.ToDateTime("1950-07-11"),
                    Salary = 100000
                },
                new Teacher
                {
                    FName ="Isaac",
                    LName = "Newton",
                    DOF = Convert.ToDateTime("1945-04-18"),
                    Salary = 165000
                },
                new Teacher
                {
                    FName ="Pragim",
                    LName = "Tech",
                    DOF = Convert.ToDateTime("1984-07-24"),
                    Salary = 7000
                },
                new Teacher
                {
                    FName ="Noman",
                    LName = "Sultan" ,
                    DOF = Convert.ToDateTime("1983-01-05"),
                    Salary = 7500
                },
                new Teacher
                {
                    FName ="Jhon",
                    LName = "Albert" ,
                    DOF = Convert.ToDateTime("1977-07-08"),
                    Salary = 4000
                },

            };

            foreach (var teacher in teachers)
            {
                context.Teachers.Add(teacher);
            }

            context.SaveChanges();

            #endregion

            #region Add Students

            var students = new List<Student>
            {
                new Student
                {
                    FName ="Sohaib",
                    LName = "Alvi",
                    DOF = Convert.ToDateTime("1986-07-13"),
                    RegNo = "EP067267"
                },
                new Student
                {
                    FName ="Hyder",
                    LName = "Abidi",
                    DOF = Convert.ToDateTime("1988-06-02"),
                    RegNo = "EP067268"
                },
                new Student
                {
                    FName ="Muhammad",
                    LName = "Rizwan",
                    DOF = Convert.ToDateTime("1988-11-26"),
                    RegNo = "EP067261"
                },
                new Student
                {
                    FName ="Babar",
                    LName = "Azam",
                    DOF = Convert.ToDateTime("1997-09-05"),
                    RegNo = "EP067262"
                },
                new Student
                {
                    FName ="Nasir",
                    LName = "Ashfaq",
                    DOF = Convert.ToDateTime("1979-02-06"),
                    RegNo = "EP067265"
                },
                new Student
                {
                    FName ="Rizwan",
                    LName = "Metla",
                    DOF = Convert.ToDateTime("1987-10-26"),
                    RegNo = "EP067266"
                }
            };

            foreach (var student in students)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();

            #endregion


        }
    }
}
