using FluentValidation;
using ProjectApplication.Repos.Interfaces;
using ProjectShared.DTOs.request;

namespace ProjectAPI.Validators
{
    public class ApplicantValidators : AbstractValidator<ApplicationDTORequest>
    {
        //private readonly List<string> allowedStatuses = new() { "Applied", "Interviewing", "Offered", "Rejected", "Accepted" }; 
        private readonly IApplicantRepository applicantRepository;

        public ApplicantValidators(IApplicantRepository applicantRepository)
        {
            this.applicantRepository = applicantRepository;

            RuleFor(a => a.JobTitle)
                .NotEmpty().WithMessage("Job title is required.")
                .MaximumLength(100).WithMessage("Job title cannot exceed 100 characters.")
                .MustAsync(async (name, cancellation) =>
                {
                    var existingApplicant = await applicantRepository.GetByJobTitleAsync(name);
                    return existingApplicant == null;
                });

            RuleFor(a => a.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");
            RuleFor(a => a.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status cannot exceed 50 characters.");
                //.Must(status => allowedStatuses.Contains(status))
                //.WithMessage($"Status must be one of the following: {string.Join(", ", allowedStatuses)}");
            RuleFor(a => a.AppliedDate)
                .NotEmpty().WithMessage("Applied date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Applied date cannot be in the future.");
            RuleFor(a => a.PreviewAnswerDate)
                .GreaterThan(a => a.AppliedDate).When(a => a.PreviewAnswerDate.HasValue)
                .WithMessage("Preview answer date must be after the applied date.");
        }
    }
}
