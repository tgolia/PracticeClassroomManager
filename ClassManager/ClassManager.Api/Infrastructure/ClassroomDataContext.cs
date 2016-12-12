﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClassManager.Api.Infrastructure
{
    public class ClassroomDataContext : DbContext
    {
        public ClassroomDataContext() : base("Classroom")
        {

        }
        public IDbSet<Class> Classes { get; set; }
        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1 teacher has many classes
            modelBuilder.Entity<Teacher>()
                        .HasMany(t => t.Classes)
                        .WithOptional(@class => @class.Teacher)
                        .HasForeignKey(@class => @class.TeacherId);

            // 1 student has many enrollments
            modelBuilder.Entity<Student>()
                        .HasMany(student => student.Enrollments)
                        .WithRequired(enrollment => enrollment.Student)
                        .HasForeignKey(enrollment => enrollment.StudentId);

            // 1 class has many enrollments
            modelBuilder.Entity<Class>()
                .HasMany(@class => @class.Enrollments)
                .WithRequired(enrollment => enrollment.Class)
                .HasForeignKey(enrollment => enrollment.ClassId);

            // Compound Key
            modelBuilder.Entity<Enrollment>
                        .HasKey(enrollment => new { enrollment.ClassId, enrollment.StudentId });
        }

    }
}