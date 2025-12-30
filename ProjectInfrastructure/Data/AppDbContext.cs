using Microsoft.EntityFrameworkCore;
using ProjectDomain.Entitites;

namespace ProjectInfrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<ApplicantEntity> Applicants { get; set; }
        public DbSet<ResumeEntity> Resume { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }

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

            modelBuilder.Entity<ResumeEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnName("file_path");

                entity.HasOne(r => r.Applicant)
                    .WithOne()
                    .HasForeignKey<ResumeEntity>(r => r.ApplicantId)
                    .IsRequired(false);
            });

            modelBuilder.Entity<ApplicationEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("job_title");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("company_name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status");

                entity.Property(e => e.AppliedDate)
                    .IsRequired()
                    .HasColumnName("applied_date");

                entity.Property(e => e.PreviewAnswerDate)
                    .HasColumnName("preview_answer_date");

                entity.HasOne(a => a.Applicant)
                      .WithMany()
                      .HasForeignKey(a => a.ApplicantId)
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
