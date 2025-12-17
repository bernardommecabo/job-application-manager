using ProjectDomain.Entitites;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Services
{
    public interface IApplicantService
    {
        Task<ApplicantDTOResponse> createApplicant(ApplicantDTORequest request);
        Task<ApplicantEntity> getApplicantById(int id);
        Task<List<ApplicantEntity>> getAllApplicants();
        Task<ApplicantDTOResponse> updateApplicant(int id, ApplicantDTORequest request);
        Task<ApplicantDTOResponse> deleteApplicantById(int id);
    }
}