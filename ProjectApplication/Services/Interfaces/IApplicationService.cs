using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Services.Interfaces
{
    public interface IApplicationService
    {
        ApplicationDTOResponse AddApplication(ApplicationDTORequest applicationDTORequest);
        List<ApplicationDTOResponse> GetAllApplications();
    }
}
