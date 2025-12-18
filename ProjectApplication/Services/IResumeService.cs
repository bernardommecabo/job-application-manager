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
    public interface IResumeService
    {
        Task<ResumeDTOResponse> createResume(int applicantId,ResumeDTORequest request);
        Task<ResumeEntity> getResumeById(int resumeId);
        Task<ResumeEntity> getResumeByApplicantId(int applicantId);
        Task<ResumeDTOResponse> updateResume(int resumeId, ResumeDTORequest request);
        Task<ResumeDTOResponse> deleteResume(int resumeId);
    }
}
