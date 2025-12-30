using FluentValidation;
using ProjectAPI.Validators;
using ProjectApplication.Repos.Interfaces;
using ProjectApplication.Services.Interfaces;
using ProjectDomain.Entitites;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using ProjectShared.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository applicantRepository;

        public ApplicantService(IApplicantRepository repository)
        {
            applicantRepository = repository;
        }
        public async Task<ApplicantDTOResponse> createApplicant(ApplicantDTORequest request)
        {
            var validator = new ApplicantValidators(applicantRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            ApplicantEntity applicantEntity = new ApplicantEntity();
            applicantEntity.Name = request.Name;
            applicantEntity.Email = request.Email;
            applicantEntity.Phone = request.Phone;
            applicantEntity.Website = request.Website;
            applicantEntity.DateOfBirth = request.DateOfBirth;
            await applicantRepository.SaveAsync(applicantEntity);
            return new ApplicantDTOResponse(applicantEntity);
        }

        public async Task<ApplicantEntity> getApplicantById(int id)
        {
            ApplicantEntity? applicantEntity = await applicantRepository.GetByIdAsync(id);
            if (applicantEntity == null) throw new KeyNotFoundException("ID: " + id + " was not found.");

            return applicantEntity;
        }

        public async Task<List<ApplicantEntity>> getAllApplicants()
        {
            return await applicantRepository.GetAllAsync();
        }

        public async Task<ApplicantDTOResponse> updateApplicant(int id, ApplicantDTORequest request)
        {
            ApplicantEntity applicantEntity = await applicantRepository.GetByIdAsync(id);
            if (applicantEntity == null) throw new KeyNotFoundException("ID: " + id + " was not found.");

            applicantEntity.Name = request.Name;
            applicantEntity.Email = request.Email;
            applicantEntity.Phone = request.Phone;
            applicantEntity.Website = request.Website;
            applicantEntity.DateOfBirth = request.DateOfBirth;
            await applicantRepository.UpdateAsync(applicantEntity);
            return new ApplicantDTOResponse(applicantEntity);
        }

        public async Task<ApplicantDTOResponse> deleteApplicantById(int id)
        {
            ApplicantEntity applicantEntity = await applicantRepository.DeleteByIdAsync(id);
            return new ApplicantDTOResponse(applicantEntity);
        }
    }
}
