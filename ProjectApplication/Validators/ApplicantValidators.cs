using FluentValidation;
using ProjectApplication.Repos.Interfaces;
using ProjectShared.DTOs.request;

namespace ProjectAPI.Validators
{
    public class ApplicantValidators : AbstractValidator<ApplicantDTORequest>
    {
        private readonly IApplicantRepository applicantRepository;

        public ApplicantValidators(IApplicantRepository applicantRepository)
        {
            this.applicantRepository = applicantRepository;

            // rule for NAME
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Username is mandatory*")
                .MustAsync(async (name, cancellation) =>
                {
                    var existing = await applicantRepository.ExistsByNameAsync(name);
                    return !existing;
                }).WithMessage("A user with that name already exists");

            // rule for EMAIL
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is mandatory*")
                .EmailAddress().WithMessage("Invalid Email")
                .MustAsync(async (email, cancellation) =>
                {
                    var existing = await applicantRepository.ExistsByEmailAsync(email);
                    return !existing;
                }).WithMessage("A user with that email already exists");

            // rule for PHONE
            RuleFor(x => x.Phone)
                .NotEmpty()
                .MustAsync(async (phone, cancellation) =>
                {
                    var existing = await applicantRepository.ExistsByPhoneAsync(phone);
                    return !existing;
                }).WithMessage("The phone number is already registered");

            // rule for WEBSITE
            RuleFor(x => x.Website)
                .NotEmpty()
                .MustAsync(async (site, cancellation) =>
                {
                    var existing = await applicantRepository.ExistsByWebsiteAsync(site);
                    return !existing;
                }).WithMessage("The website is already registered");
        }
    }
}
