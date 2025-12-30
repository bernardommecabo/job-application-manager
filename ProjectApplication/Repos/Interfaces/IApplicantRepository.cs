using ProjectDomain.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectApplication.Repos.Interfaces
{
    public interface IApplicantRepository
    {
        Task<ApplicantEntity?> GetByIdAsync(int id);
        Task<List<ApplicantEntity>> GetAllAsync();
        Task<ApplicantEntity> SaveAsync(ApplicantEntity applicant);
        Task<ApplicantEntity> UpdateAsync(ApplicantEntity applicant);
        Task<ApplicantEntity> DeleteByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByPhoneAsync(string phone);
        Task<bool> ExistsByWebsiteAsync(string website);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
