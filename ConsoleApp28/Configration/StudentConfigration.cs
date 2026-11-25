using ConsoleApp28.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Configration
{
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(s => s.Email).IsUnique();

            builder.Property(s => s.DateOfBirth)
                   .IsRequired()
                   .HasColumnType("date");

            builder.HasMany(s => s.Enrollments)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
