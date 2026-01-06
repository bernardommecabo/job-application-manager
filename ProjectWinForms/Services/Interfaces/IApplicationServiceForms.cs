using ProjectShared.DTOs.response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWinForms.Services.Interfaces
{
    public interface IApplicationServiceForms
    {
        Task<List<ApplicationSummaryDTOResponse>> GetApplicationsAsync(int applicantId);
        Task AddApplicationAsync(int applicantId, ApplicationSummaryDTOResponse app);
        Task UpdateApplicationAsync(int applicantId, ApplicationSummaryDTOResponse app);
        Task DeleteApplicationAsync(int applicantId, int applicationId);
    }
}