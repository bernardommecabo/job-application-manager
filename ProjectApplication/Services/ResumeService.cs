using ProjectApplication.Repos;
using ProjectApplication.Repos.Interfaces;
using ProjectApplication.Services.Interfaces;
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
        private readonly IApplicantRepository applicantRepository;

        public ResumeService(IResumeRepository repository, IApplicantRepository applicantRepository)
        {
            resumeRepository = repository;
            this.applicantRepository = applicantRepository;
        }
        public async Task<ResumeDTOResponse> createResume(int applicantId,ResumeDTORequest request)
        {
            ApplicantEntity applicantEntity = await applicantRepository.GetByIdAsync(applicantId);
            if (applicantEntity == null) throw new KeyNotFoundException("ID: " + applicantId + " was not found.");

            ResumeEntity resumeEntity = new ResumeEntity();
            resumeEntity.Name = request.Name;
            resumeEntity.FilePath = request.FilePath;
            resumeEntity.ApplicantId = applicantId;
            await resumeRepository.CreateResumeAsync(resumeEntity);
            return new ResumeDTOResponse(resumeEntity);
        }
        public async Task<ResumeEntity> getResumeByApplicantId(int applicantId)
        {
            ApplicantEntity applicantEntity = await applicantRepository.GetByIdAsync(applicantId);
            if (applicantEntity == null) throw new KeyNotFoundException("ID: " + applicantId + " was not found.");

            var resumeEntity = await resumeRepository.GetResumeByApplicantIdAsync(applicantId);
            if (resumeEntity == null) throw new KeyNotFoundException("Applicant ID: " + applicantId + " does not have a resume.");

            return resumeEntity;
        }
        public async Task<ResumeDTOResponse> updateResume(int applicantId, ResumeDTORequest request)
        {
            var applicantEntity = await applicantRepository.GetByIdAsync(applicantId);
            if (applicantEntity == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var resumeEntity = await resumeRepository.GetResumeByApplicantIdAsync(applicantId);
            if (resumeEntity == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} does not have a resume.");

            resumeEntity.Name = request.Name;
            resumeEntity.FilePath = request.FilePath;
            await resumeRepository.UpdateResumeAsync(resumeEntity);
            return new ResumeDTOResponse(resumeEntity);
        }
        public async Task<ResumeDTOResponse> deleteResume(int applicantId)
        {
            var applicantEntity = await applicantRepository.GetByIdAsync(applicantId);
            if (applicantEntity == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var resumeExists = await resumeRepository.GetResumeByApplicantIdAsync(applicantId);
            if (resumeExists == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} does not have a resume.");

            ResumeEntity resumeEntity = await resumeRepository.DeleteResumeAsync(resumeExists.Id);
            return new ResumeDTOResponse(resumeEntity);
        }
    }
}
