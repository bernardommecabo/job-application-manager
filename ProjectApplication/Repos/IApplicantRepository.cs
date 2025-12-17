using ProjectDomain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Repos
{
    public interface IApplicantRepository
    {
        Task<ApplicantEntity> SaveAsync(ApplicantEntity applicant);
        Task<ApplicantEntity> GetByIdAsync(int id);
        Task<List<ApplicantEntity>> GetAllAsync();
        Task<ApplicantEntity> UpdateAsync(ApplicantEntity applicant);
        Task<ApplicantEntity> DeleteByIdAsync(int id);
    }
}
