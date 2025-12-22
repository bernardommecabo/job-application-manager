using ProjectDomain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Repos.Interfaces
{
    public interface IResumeRepository
    {
        Task<ResumeEntity> CreateResumeAsync(ResumeEntity resume);
        Task<ResumeEntity> GetResumeByIdAsync(int id);
        Task<ResumeEntity> GetResumeByApplicantIdAsync(int applicantId);
        Task<ResumeEntity> UpdateResumeAsync(ResumeEntity resume);
        Task<ResumeEntity> DeleteResumeAsync(int id);
    }
}
