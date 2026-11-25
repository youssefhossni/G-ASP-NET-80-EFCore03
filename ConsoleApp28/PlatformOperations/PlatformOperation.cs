using ConsoleApp28.Context;
using ConsoleApp28.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.PlatformOperations
{
    public  class PlatformOperation
    {
         public static void AddInstructor(AppDbContext context, string fullName, string email, string? bio)
        {
            if (context.Instructors.Any(i => i.Email == email))
            {
                Console.WriteLine($"Error: Instructor with email '{email}' already exists.");
                return;
            }
            var instructor = new Instructor
            {
                FullName = fullName,
                Email = email,
                Bio = bio,
                JoinedAt = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine($"Instructor added successfully with Id: {instructor.Id}");
        }
      public  static void AddCourse(AppDbContext context, string title, string? description, decimal price, CourseLevel level, int instructorId, int categoryId)
        {
            bool instructorExists = context.Instructors.Any(i => i.Id == instructorId);
            if (!instructorExists)
            {
                Console.WriteLine($"Error: Instructor with Id {instructorId} not found.");
                return;
            }

            bool categoryExists = context.Categories.Any(c => c.Id == categoryId);
            if (!categoryExists)
            {
                Console.WriteLine($"Error: Category with Id {categoryId} not found.");
                return;
            }

            var course = new Course
            {
                Title = title,
                Description = description,
                Price = price,
                Level = level,
                IsPublished = false,
                PublishedAt = null,
                instructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine($"Course '{course.Title}' added successfully with Id: {course.Id}");
        }
       public static void AddStudents(AppDbContext context)
        {
            var students = new List<Student>
    {
        new Student { FullName = "Ali Mahmoud", Email = "ali.m@mail.com", DateOfBirth = new DateTime(2001, 4, 15) },
        new Student { FullName = "Nourhan Tarek", Email = "nourhan.t@mail.com", DateOfBirth = new DateTime(2002, 8, 20) },
        new Student { FullName = "Karim Hany", Email = "karim.h@mail.com", DateOfBirth = new DateTime(2000, 12, 5) }
    };
            var newStudents = students
    .Where(s => !context.Students.Any(db => db.Email == s.Email))
    .ToList();

            if (newStudents.Count == 0)
            {
                Console.WriteLine("All these students already exist.");
                return;
            }

            context.Students.AddRange(newStudents);
            context.SaveChanges();
            context.Students.AddRange(students);
            context.SaveChanges();

            Console.WriteLine("Students added successfully with Ids:");
            foreach (var s in students)
            {
                Console.WriteLine($"- {s.FullName}: Id = {s.Id}");
            }
        }
       public static void EnrollStudent(AppDbContext context, int studentId, int courseId)
        {
            var student = context.Students.Find(studentId);
            if (student == null)
            {
                Console.WriteLine($"Refused: Student with Id {studentId} does not exist.");
                return;
            }

            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine($"Refused: Course with Id {courseId} does not exist.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine($"Refused: Course '{course.Title}' is not published yet.");
                return;
            }

            bool alreadyEnrolled = context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
            if (alreadyEnrolled)
            {
                Console.WriteLine($"Refused: Student {studentId} is already enrolled in course {courseId}.");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now,
                ProgressPercentage = 0,
                Status = EnrollmentStatus.Active,
                FinalGrade = null
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine($"Student {studentId} enrolled in Course {courseId} successfully.");
        }
        public static void FindCourse(AppDbContext context, int id, string title)
        {
            var courseById = context.Courses.Find(id);
            if (courseById == null)
                Console.WriteLine($"Course with Id {id}: not found.");
            else
                Console.WriteLine($"Found by Id: {courseById.Title} (${courseById.Price})");

            var courseByTitle = context.Courses.FirstOrDefault(c => c.Title == title);
            if (courseByTitle == null)
                Console.WriteLine($"Course '{title}': not found.");
            else
                Console.WriteLine($"Found by Title: {courseByTitle.Title} (Id: {courseByTitle.Id})");
        }
        public static void FilterCourses(AppDbContext context, decimal minPrice, decimal maxPrice)
        {
            var courses = context.Courses
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new { c.Title, c.Level, c.Price })
                .ToList();

            Console.WriteLine($"Courses priced between {minPrice} and {maxPrice}:");
            foreach (var c in courses)
            {
                Console.WriteLine($"- {c.Title} | Level: {c.Level} | Price: {c.Price}");
            }
        }
        public static void GetCategoriesHierarchy(AppDbContext context, int parentCategoryId)
        {
            var subCategories = context.Categories
                .Where(c => c.ParentCategoryId == parentCategoryId)
                .ToList();

            Console.WriteLine($"Direct sub-categories of Category {parentCategoryId}:");
            foreach (var sub in subCategories)
            {
                Console.WriteLine($"- {sub.Name}");
            }

            var topLevelCategories = context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top-level categories:");
            foreach (var top in topLevelCategories)
            {
                Console.WriteLine($"- {top.Name}");
            }
        }
        public static void GetCourseRoster(AppDbContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine($"Course with Id {courseId} not found.");
                return;
            }

            var studentIds = context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            Console.WriteLine($"Course '{course.Title}' has {studentIds.Count} enrolled student(s):");

            var studentNames = context.Students
                .Where(s => studentIds.Contains(s.Id))
                .Select(s => s.FullName)
                .ToList();

            foreach (var name in studentNames)
            {
                Console.WriteLine($"- {name}");
            }
        }
        public static void ChangeCoursePrice(AppDbContext context, int courseId, decimal newPrice)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine($"Error: Course with Id {courseId} not found.");
                return;
            }

            decimal oldPrice = course.Price;
            course.Price = newPrice;
            context.SaveChanges();

            Console.WriteLine($"Course '{course.Title}' price updated from {oldPrice} to {newPrice}.");
        }
        public static void UpdateProgress(AppDbContext context, int courseId, int studentId, int newProgress)
        {
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine($"Error: Progress ({newProgress}) must be between 0 and 100.");
                return;
            }

            var enrollment = context.Enrollments.Find(courseId, studentId);
            if (enrollment == null)
            {
                Console.WriteLine($"Error: Enrollment for Student {studentId} in Course {courseId} not found.");
                return;
            }

            enrollment.ProgressPercentage = newProgress;
            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }

            context.SaveChanges();
            Console.WriteLine($"Progress updated to {enrollment.ProgressPercentage}% | Status: {enrollment.Status}");
        }

        public static void PublishCourse(AppDbContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine($"Error: Course with Id {courseId} not found.");
                return;
            }

            if (course.IsPublished)
            {
                Console.WriteLine($"Course '{course.Title}' is already published.");
                return;
            }

            course.IsPublished = true;
            course.PublishedAt = DateTime.Now;
            context.SaveChanges();

            Console.WriteLine($"Course '{course.Title}' published successfully at {course.PublishedAt}.");
        }
        public static void UnenrollStudent(AppDbContext context, int courseId, int studentId)
        {
            var enrollment = context.Enrollments.Find(courseId, studentId);
            if (enrollment == null)
            {
                Console.WriteLine($"Error: Enrollment for Student {studentId} in Course {courseId} not found.");
                return;
            }

            context.Enrollments.Remove(enrollment);
            context.SaveChanges();

            Console.WriteLine($"Student {studentId} unenrolled from Course {courseId} successfully.");
        }
        public static void DeleteCategoryUnsafe(AppDbContext context, int categoryId)
        {
            context.ChangeTracker.Clear();
            var category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine($"Error: Category with Id {categoryId} not found.");
                return;
            }

            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                Console.WriteLine($"Category '{category.Name}' deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                context.Entry(category).State = EntityState.Unchanged;
                Console.WriteLine($"DbUpdateException caught: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public static void DeleteCategorySafe(AppDbContext context, int categoryId)
        {
            var category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine($"Error: Category with Id {categoryId} not found.");
                return;
            }

            bool hasSubCategories = context.Categories.Any(c => c.ParentCategoryId == categoryId);
            if (hasSubCategories)
            {
                Console.WriteLine($"Refused: Cannot delete Category '{category.Name}' because it still has sub-categories.");
                return;
            }

            bool hasCourses = context.Courses.Any(c => c.CategoryId == categoryId);
            if (hasCourses)
            {
                Console.WriteLine($"Refused: Cannot delete Category '{category.Name}' because it still has courses.");
                return;
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            Console.WriteLine($"Category '{category.Name}' deleted safely.");
        }
        public static void DeleteCourse(AppDbContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine($"Error: Course with Id {courseId} not found.");
                return;
            }

            int enrollmentsBefore = context.Enrollments.Count(e => e.CourseId == courseId);
            Console.WriteLine($"Enrollments for '{course.Title}' BEFORE delete: {enrollmentsBefore}");

            context.Courses.Remove(course);
            context.SaveChanges();

            // The enrollments were automatically removed because the relationship between
            // Course and Enrollment is configured with DeleteBehavior.Cascade in CourseConfiguration.
            int enrollmentsAfter = context.Enrollments.Count(e => e.CourseId == courseId);
            Console.WriteLine($"Course '{course.Title}' deleted.");
            Console.WriteLine($"Enrollments for '{course.Title}' AFTER delete: {enrollmentsAfter}");
        }

    }
}
