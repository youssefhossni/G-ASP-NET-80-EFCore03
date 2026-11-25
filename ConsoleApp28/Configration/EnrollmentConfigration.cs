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
    public class EnrollmentConfigration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {

            builder.HasKey(e => new { e.CourseId, e.Student });
            

            builder.Property(e => e.EnrolledAt)
                   .IsRequired();

            builder.Property(e => e.ProgressPercentage)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(e => e.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(e => e.FinalGrade)
                   .HasPrecision(5, 2);

            
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Enrollment_Progress",
                "[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100"));
        }
    }
}
