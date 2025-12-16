using Microsoft.EntityFrameworkCore;
using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInfrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<ApplicantEntity> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Name)
                    .IsRequired()             
                    .HasMaxLength(100)      
                    .HasColumnName("name");   

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
