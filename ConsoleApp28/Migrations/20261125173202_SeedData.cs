using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp28.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "All programming courses", "Programming", null },
                    { 5, null, "Data Science", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinedAt" },
                values: new object[,]
                {
                    { 1, "Senior .NET developer and trainer.", "ahmed.hassan@learn.com", "Ahmed Hassan", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "sara.mohamed@learn.com", "Sara Mohamed", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.ali@mail.com", "Omar Ali" },
                    { 2, new DateTime(1999, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona.khaled@mail.com", "Mona Khaled" },
                    { 3, new DateTime(2002, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.adel@mail.com", "Youssef Adel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Server-side development", "Backend", 1 },
                    { 4, "Client-side development", "Frontend", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "IsPublished", "Level", "Price", "PublishedAt", "Title", "instructorId" },
                values: new object[] { 1, 1, "Learn C# from scratch", true, "Beginner", 49.99m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 3, null, "ASP.NET", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "IsPublished", "Level", "Price", "PublishedAt", "Title", "instructorId" },
                values: new object[] { 3, 4, null, true, "Advanced", 79.00m, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular in Depth", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Level", "Price", "PublishedAt", "Title", "instructorId" },
                values: new object[] { 4, 2, "Draft course", "Intermediate", 59.00m, null, "Docker for Developers", 2 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrolledAt", "FinalGrade", "ProgressPercentage", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.50m, 100, "Completed" },
                    { 1, 2, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "IsPublished", "Level", "Price", "PublishedAt", "Title", "instructorId" },
                values: new object[] { 2, 3, "Build REST APIs", true, "Intermediate", 99.99m, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API", 1 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrolledAt", "FinalGrade", "ProgressPercentage", "Status" },
                values: new object[] { 2, 1, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, "Active" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
