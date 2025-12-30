using ProjectDomain.Entitites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectApplication.Repos.Interfaces
{
    public interface IApplicationRepository
    {
        Task<ApplicationEntity> createApplication(int applicantId, ApplicationEntity application);
        Task<List<ApplicationEntity>> getAllApplicationsByApplicantId(int applicantId);
        Task<ApplicationEntity?> getApplicationById(int applicantId, int applicationId);
        Task<ApplicationEntity> updateApplication(int applicantId, ApplicationEntity application);
        Task<ApplicationEntity> deleteApplication(int applicantId, int applicationId);
    }
}
