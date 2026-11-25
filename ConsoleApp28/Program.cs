using ConsoleApp28.Context;
using ConsoleApp28.Models;
using ConsoleApp28.PlatformOperations;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using var context = new AppDbContext();

            Console.WriteLine("--- CREATE OPERATIONS ---");
            PlatformOperation.AddInstructor(context, "Khaled Mansour", "khaled.m@learn.com", "Cloud Architect");
            PlatformOperation.AddCourse(context, "EF Core Mastery", "Deep dive into EF Core", 85.00m, CourseLevel.Intermediate, 1, 2);
            PlatformOperation.AddStudents(context);
            PlatformOperation.EnrollStudent(context, 3, 1);
            PlatformOperation.EnrollStudent(context, 3, 4);
            PlatformOperation.EnrollStudent(context, 1, 1);
            Console.WriteLine("\n--- READ OPERATIONS ---");
            PlatformOperation.FindCourse(context, 1, "Angular in Depth");
            PlatformOperation.FindCourse(context, 999, "Non Existent Course");
            PlatformOperation.FilterCourses(context, 50m, 100m);
            PlatformOperation.GetCategoriesHierarchy(context, 1);
            PlatformOperation.GetCourseRoster(context, 1);
            Console.WriteLine("\n--- UPDATE OPERATIONS ---");
            PlatformOperation.ChangeCoursePrice(context, 1, 59.99m);
            PlatformOperation.UpdateProgress(context, 1, 2, 150); 
            PlatformOperation.UpdateProgress(context, 1, 2, 100); 
            PlatformOperation.PublishCourse(context, 4);

            Console.WriteLine("\n--- DELETE OPERATIONS ---");
            PlatformOperation.UnenrollStudent(context, 1, 2);
            PlatformOperation.DeleteCategoryUnsafe(context, 1); 
            PlatformOperation.DeleteCategorySafe(context, 1);   
            PlatformOperation.DeleteCategorySafe(context, 5);   
            PlatformOperation.DeleteCourse(context, 1);         
        }
    }
}
