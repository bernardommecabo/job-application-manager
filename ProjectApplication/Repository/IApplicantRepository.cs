using ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Repository
{
    public interface IApplicantEntityRepository
    {
        Task<ApplicantEntity> GetApplicantByIdAsync(string id);
        Task CreateApplicantAsync(ApplicantEntity applicant);
        Task UpdateApplicantAsync(ApplicantEntity applicant);
        Task DeleteApplicantAsync(string id);
    }
}
