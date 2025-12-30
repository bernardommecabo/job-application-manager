using Microsoft.EntityFrameworkCore;
using ProjectApplication.Repos.Interfaces;
using ProjectDomain.Entitites;
using ProjectInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApplication.Repos
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationEntity> createApplication(int applicantId, ApplicationEntity application)
        {
            application.ApplicantId = applicantId;
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<List<ApplicationEntity>> getAllApplicationsByApplicantId(int applicantId)
        {
            return await _context.Applications
                                 .AsNoTracking()
                                 .Where(a => a.ApplicantId == applicantId)
                                 .ToListAsync();
        }

        public async Task<ApplicationEntity?> getApplicationById(int applicantId, int applicationId)
        {
            return await _context.Applications
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(a => a.Id == applicationId && a.ApplicantId == applicantId);
        }

        public async Task<ApplicationEntity> updateApplication(int applicantId, ApplicationEntity application)
        {
            var existing = await _context.Applications
                                         .FirstOrDefaultAsync(a => a.Id == application.Id && a.ApplicantId == applicantId);
            if (existing == null) throw new KeyNotFoundException($"Application ID: {application.Id} for Applicant ID: {applicantId} was not found.");

            existing.JobTitle = application.JobTitle;
            existing.CompanyName = application.CompanyName;
            existing.Status = application.Status;
            existing.AppliedDate = application.AppliedDate;
            existing.PreviewAnswerDate = application.PreviewAnswerDate;

            _context.Applications.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<ApplicationEntity> deleteApplication(int applicantId, int applicationId)
        {
            var existing = await _context.Applications
                                         .FirstOrDefaultAsync(a => a.Id == applicationId && a.ApplicantId == applicantId);
            if (existing == null) throw new KeyNotFoundException($"Application ID: {applicationId} for Applicant ID: {applicantId} was not found.");

            _context.Applications.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
