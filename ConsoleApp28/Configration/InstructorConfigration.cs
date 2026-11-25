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
    public class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
       .IsRequired()
       .HasMaxLength(100);

            builder.Property(i => i.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(i => i.Bio)
                   .HasMaxLength(500);

            builder.Property(i => i.JoinedAt)
                   .IsRequired();

            builder.HasMany(i => i.Courses)
                   .WithOne(c => c.instructor)
                   .HasForeignKey(c => c.instructorId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
