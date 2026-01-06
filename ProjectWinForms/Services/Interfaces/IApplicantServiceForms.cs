using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWinForms.Services.Interfaces
{
    public interface IApplicantServiceForms
    {
        Task<LoginDTOResponse> LoginAsync(string request);
        Task CreateAsync(ApplicantDTORequest request);
    }
}
