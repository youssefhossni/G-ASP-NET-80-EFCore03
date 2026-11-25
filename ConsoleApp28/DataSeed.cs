using ConsoleApp28.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed.hassan@learn.com", Bio = "Senior .NET developer and trainer.", JoinedAt = new DateTime(2023, 1, 10) },
                new Instructor { Id = 2, FullName = "Sara Mohamed", Email = "sara.mohamed@learn.com", Bio = null, JoinedAt = new DateTime(2023, 6, 1) });

            // Tree: Programming -> Backend -> ASP.NET ; Programming -> Frontend ; Data Science (top-level, unused)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming", Description = "All programming courses", ParentCategoryId = null },
                new Category { Id = 2, Name = "Backend", Description = "Server-side development", ParentCategoryId = 1 },
                new Category { Id = 3, Name = "ASP.NET", Description = null, ParentCategoryId = 2 },
                new Category { Id = 4, Name = "Frontend", Description = "Client-side development", ParentCategoryId = 1 },
                new Category { Id = 5, Name = "Data Science", Description = null, ParentCategoryId = null });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Fundamentals", Description = "Learn C# from scratch", Price = 49.99m, Level = CourseLevel.Beginner, IsPublished = true, PublishedAt = new DateTime(2023, 2, 1), instructorId = 1, CategoryId = 1 },
                new Course { Id = 2, Title = "ASP.NET Core Web API", Description = "Build REST APIs", Price = 99.99m, Level = CourseLevel.Intermediate, IsPublished = true, PublishedAt = new DateTime(2023, 4, 15), instructorId = 1, CategoryId = 3 },
                new Course { Id = 3, Title = "Angular in Depth", Description = null, Price = 79.00m, Level = CourseLevel.Advanced, IsPublished = true, PublishedAt = new DateTime(2023, 8, 20), instructorId = 2, CategoryId = 4 },
                new Course { Id = 4, Title = "Docker for Developers", Description = "Draft course", Price = 59.00m, Level = CourseLevel.Intermediate, IsPublished = false, PublishedAt = null, instructorId = 2, CategoryId = 2 });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Omar Ali", Email = "omar.ali@mail.com", DateOfBirth = new DateTime(2000, 5, 12) },
                new Student { Id = 2, FullName = "Mona Khaled", Email = "mona.khaled@mail.com", DateOfBirth = new DateTime(1999, 11, 3) },
                new Student { Id = 3, FullName = "Youssef Adel", Email = "youssef.adel@mail.com", DateOfBirth = new DateTime(2002, 2, 25) });

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1, EnrolledAt = new DateTime(2023, 3, 1), ProgressPercentage = 100, Status = EnrollmentStatus.Completed, FinalGrade = 90.50m },
                new Enrollment { StudentId = 2, CourseId = 1, EnrolledAt = new DateTime(2023, 3, 5), ProgressPercentage = 40, Status = EnrollmentStatus.Active, FinalGrade = null },
                new Enrollment { StudentId = 1, CourseId = 2, EnrolledAt = new DateTime(2023, 5, 1), ProgressPercentage = 20, Status = EnrollmentStatus.Active, FinalGrade = null });
        }
    }

}
