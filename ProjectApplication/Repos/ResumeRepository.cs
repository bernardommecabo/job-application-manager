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
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _context;

        public ResumeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResumeEntity> CreateResumeAsync(ResumeEntity resume)
        {
            await _context.Resume.AddAsync(resume);
            await _context.SaveChangesAsync();
            return resume;
        }
        public Task<ResumeEntity> GetResumeByIdAsync(int id)
        {
            return _context.Resume.FindAsync(id).AsTask();
        }
        public Task<ResumeEntity> GetResumeByApplicantIdAsync(int applicantId)
        {
            return _context.Resume.FirstOrDefaultAsync(r => r.ApplicantId == applicantId);
        }
        public async Task<ResumeEntity> UpdateResumeAsync(ResumeEntity resume)
        {
            _context.Resume.Update(resume);
            await _context.SaveChangesAsync();
            return resume;
        }
        public async Task<ResumeEntity> DeleteResumeAsync(int id)
        {
            ResumeEntity resumeEntity = await _context.Resume.FindAsync(id);
            if (resumeEntity == null) throw new KeyNotFoundException("ID: " + id + " was not found.");

            _context.Resume.Remove(resumeEntity);
            await _context.SaveChangesAsync();
            return resumeEntity;
        }
    }
}
