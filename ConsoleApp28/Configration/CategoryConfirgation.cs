using ConsoleApp28.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Configration
{
    public class CategoryConfirgation : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {


            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(300);

            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasMany(c=>c.courses)
                   .WithOne(co => co.Category)
                   .HasForeignKey(co => co.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
