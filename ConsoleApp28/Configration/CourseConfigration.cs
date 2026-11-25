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
    public class CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {


            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(c => c.Level)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(c => c.IsPublished)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(c => c.PublishedAt);

            builder.HasMany(c => c.Enrollments)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
