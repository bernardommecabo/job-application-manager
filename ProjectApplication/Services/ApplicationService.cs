using ProjectApplication.Repos.Interfaces;
using ProjectApplication.Services.Interfaces;
using ProjectDomain.Entitites;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApplication.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicantRepository _applicantRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IApplicantRepository applicantRepository)
        {
            _applicationRepository = applicationRepository;
            _applicantRepository = applicantRepository;
        }

        public async Task<ApplicationDTOResponse> createApplication(int applicantId, ApplicationDTORequest applicationDTORequest)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var applicationEntity = new ApplicationEntity
            {
                JobTitle = applicationDTORequest.JobTitle,
                CompanyName = applicationDTORequest.CompanyName,
                Status = applicationDTORequest.Status,
                AppliedDate = applicationDTORequest.AppliedDate,
                PreviewAnswerDate = applicationDTORequest?.PreviewAnswerDate,
                ApplicantId = applicantId
            };

            var created = await _applicationRepository.createApplication(applicantId, applicationEntity);
            return new ApplicationDTOResponse(created);
        }

        public async Task<List<ApplicationDTOResponse>> getAllApplications(int applicantId)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var list = await _applicationRepository.getAllApplicationsByApplicantId(applicantId);
            return list.Select(e => new ApplicationDTOResponse(e)).ToList();
        }

        public async Task<ApplicationDTOResponse> getApplicationById(int applicantId, int applicationId)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var existing = await _applicationRepository.getApplicationById(applicantId, applicationId);
            if (existing == null) throw new KeyNotFoundException($"Application ID: {applicationId} for Applicant ID: {applicantId} was not found.");

            return new ApplicationDTOResponse(existing);
        }

        public async Task<ApplicationDTOResponse> updateApplication(int applicantId, int applicationId, ApplicationDTORequest applicationDTORequest)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var existing = await _applicationRepository.getApplicationById(applicantId, applicationId);
            if (existing == null) throw new KeyNotFoundException($"Application ID: {applicationId} for Applicant ID: {applicantId} was not found.");

            existing.JobTitle = applicationDTORequest.JobTitle;
            existing.CompanyName = applicationDTORequest.CompanyName;
            existing.Status = applicationDTORequest.Status;
            existing.AppliedDate = applicationDTORequest.AppliedDate;
            existing.PreviewAnswerDate = applicationDTORequest?.PreviewAnswerDate;

            var updated = await _applicationRepository.updateApplication(applicantId, existing);
            return new ApplicationDTOResponse(updated);
        }

        public async Task<ApplicationDTOResponse> deleteApplication(int applicantId, int applicationId)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null) throw new KeyNotFoundException($"Applicant ID: {applicantId} was not found.");

            var deleted = await _applicationRepository.deleteApplication(applicantId, applicationId);
            return new ApplicationDTOResponse(deleted);
        }
    }
}
