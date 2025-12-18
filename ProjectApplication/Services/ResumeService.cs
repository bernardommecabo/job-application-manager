using ProjectApplication.Repos;
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
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository resumeRepository;

        public ResumeService(IResumeRepository repository)
        {
            resumeRepository = repository;
        }
        public async Task<ResumeDTOResponse> createResume(int applicantId,ResumeDTORequest request)
        {
            ResumeEntity resumeEntity = new ResumeEntity();
            resumeEntity.FilePath = request.FilePath;
            resumeEntity.ApplicantId = applicantId;
            await resumeRepository.CreateResumeAsync(resumeEntity);
            return new ResumeDTOResponse(resumeEntity);
        }
        public async Task<ResumeEntity> getResumeById(int resumeId)
        {
            return await resumeRepository.GetResumeByIdAsync(resumeId);
        }
        public async Task<ResumeEntity> getResumeByApplicantId(int applicantId)
        {
            return await resumeRepository.GetResumeByApplicantIdAsync(applicantId);
        }
        public async Task<ResumeDTOResponse> updateResume(int resumeId, ResumeDTORequest request)
        {
            ResumeEntity resumeEntity = await resumeRepository.GetResumeByIdAsync(resumeId);
            if (resumeEntity == null) throw new KeyNotFoundException("ID: " + resumeId + " was not found.");
            resumeEntity.FilePath = request.FilePath;
            resumeEntity.ApplicantId = request.ApplicantId;
            await resumeRepository.UpdateResumeAsync(resumeEntity);
            return new ResumeDTOResponse(resumeEntity);
        }
        public async Task<ResumeDTOResponse> deleteResume(int resumeId)
        {
            ResumeEntity resumeEntity = await resumeRepository.DeleteResumeAsync(resumeId);
            return new ResumeDTOResponse(resumeEntity);
        }
    }
}
