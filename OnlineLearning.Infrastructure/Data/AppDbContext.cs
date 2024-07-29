using Microsoft.EntityFrameworkCore;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Student>()
        //.HasMany(e => e.Courses)
        //.WithMany(e => e.Students)
        //.UsingEntity<Enrollment>();

        modelBuilder.Entity<Enrollment>().HasKey(sc => new { sc.StudentId, sc.CourseId });

        modelBuilder.Entity<Enrollment>()
        .HasOne(bc => bc.Student)
        .WithMany(b => b.Enrollments)
        .HasForeignKey(bc => bc.StudentId);

            modelBuilder.Entity<Enrollment>()
            .HasOne(bc => bc.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(bc => bc.CourseId);


            modelBuilder.Entity<Course>()
                 .Property(f => f.CourseId)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                 .Property(f => f.StudentId)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                 .Property(f => f.UserId)
                 .ValueGeneratedOnAdd();

        }
    }
}
