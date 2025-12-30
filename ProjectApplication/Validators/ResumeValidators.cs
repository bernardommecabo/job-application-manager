using FluentValidation;
using ProjectShared.DTOs.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Validators
{
    public class ResumeValidators : AbstractValidator<ResumeDTORequest>
    {
        public ResumeValidators()
        {
            // rule for NAME
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Resume name must not exceed 100 characters");

            // rule for FILE PATH
            RuleFor(x => x.FilePath)
                .NotEmpty().WithMessage("Archive must not be null");

            // rule for FILE TYPE
            RuleFor(x => x.FilePath)
                .Must(path => path.EndsWith(".pdf") || path.EndsWith(".docx"))
                .When(x => !string.IsNullOrEmpty(x.FilePath))
                .WithMessage("Only .pdf /.docx are allowed");
        }
    }
}
