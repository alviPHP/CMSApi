
using CMSApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Database
{
    /*
     * Created By : Sohaib Alvi
     * Created Date : 12/18/2021 3:51PM
     * Description : This class contains the context of Database connections
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubjectTeacher> CoursesSubjectsTeachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Grade and Student Relation ship
            modelBuilder.Entity<Grade>()
            .HasOne<Student>(s => s.Student)
            .WithMany(g => g.Grades)
            .HasForeignKey(s => s.StudentId);

           // Grade and Subject Relation ship
            modelBuilder.Entity<Grade>()
            .HasOne<CourseSubjectTeacher>(s => s.CourseSubjectTeachers)
            .WithMany(g => g.Grades)
            .HasForeignKey(s => s.CourseSubjectTeacherId);


            modelBuilder.Entity<CourseSubjectTeacher>()
                .HasKey(cst => new { cst.Id});            
           
            modelBuilder.Entity<CourseSubjectTeacher>()
                .HasOne<Course>(cst => cst.Course)
                .WithMany(cst => cst.CourseSubjectTeachers)
                .HasForeignKey(cst => cst.CourseId);

            modelBuilder.Entity<CourseSubjectTeacher>()
                .HasOne<Subject>(cst => cst.Subject)
                .WithMany(cst => cst.CourseSubjectTeachers)
                .HasForeignKey(cst => cst.SubjectId);

            modelBuilder.Entity<CourseSubjectTeacher>()
                .HasOne<Teacher>(cst => cst.Teacher)
                .WithMany(cst => cst.CourseSubjectTeachers)
                .HasForeignKey(cst => cst.TeacherId);
         
            
        }

    }
}
