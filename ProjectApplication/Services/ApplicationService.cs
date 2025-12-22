using ProjectApplication.Services.Interfaces;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Services
{
    public class ApplicationService : IApplicationService
    {
        public ApplicationDTOResponse AddApplication(ApplicationDTORequest applicationDTORequest)
        {
            ApplicationDTOResponse applicationDTOResponse = new ApplicationDTOResponse();
            applicationDTOResponse.JobTitle = applicationDTORequest.JobTitle;
            applicationDTOResponse.CompanyName = applicationDTORequest.CompanyName;
            applicationDTOResponse.Status = applicationDTORequest.Status;
            applicationDTOResponse.AppliedDate = applicationDTORequest.AppliedDate;
            applicationDTOResponse.PreviewAnswerDate = applicationDTORequest?.PreviewAnswerDate;
            return applicationDTOResponse;
        }

        public List<ApplicationDTOResponse> GetAllApplications()
        {
            throw new NotImplementedException();
        }
    }
}
