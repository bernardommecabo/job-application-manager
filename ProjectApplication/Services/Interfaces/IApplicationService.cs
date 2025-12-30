using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectApplication.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationDTOResponse> createApplication(int applicantId, ApplicationDTORequest applicationDTORequest);
        Task<List<ApplicationDTOResponse>> getAllApplications(int applicantId);
        Task<ApplicationDTOResponse> getApplicationById(int applicantId, int applicationId);
        Task<ApplicationDTOResponse> updateApplication(int applicantId, int applicationId, ApplicationDTORequest applicationDTORequest);
        Task<ApplicationDTOResponse> deleteApplication(int applicantId, int applicationId);
    }
}