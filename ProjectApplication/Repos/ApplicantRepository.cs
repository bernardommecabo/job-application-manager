using Microsoft.EntityFrameworkCore;
using ProjectApplication.Repos.Interfaces;
using ProjectDomain.Entitites;
using ProjectInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Repos
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly AppDbContext _context;

        public ApplicantRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicantEntity> SaveAsync(ApplicantEntity applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();
            return applicant;
        }

        public async Task<ApplicantEntity> GetByIdAsync(int id)
        {
            ApplicantEntity applicantEntity = await _context.Applicants.FindAsync(id);
            return applicantEntity;
        }

        public async Task<List<ApplicantEntity>> GetAllAsync()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<ApplicantEntity> UpdateAsync(ApplicantEntity applicant)
        {
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
            return applicant;
        }

        public async Task<ApplicantEntity> DeleteByIdAsync(int id)
        {
            ApplicantEntity applicantEntity = await _context.Applicants.FindAsync(id);
            if (applicantEntity == null) throw new KeyNotFoundException("ID: "+ id + " was not found.");

            _context.Applicants.Remove(applicantEntity);
            await _context.SaveChangesAsync();
            return applicantEntity;
        }
    }
}
