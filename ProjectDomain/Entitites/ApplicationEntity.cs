using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Entitites
{
    public class ApplicationEntity
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedDate { get; set; } = DateTime.Now;
        public DateTime? PreviewAnswerDate { get; set; }
        public int ApplicantId { get; set; }

        public ApplicantEntity? Applicant { get; set; }

        public ApplicationEntity() { }

        public ApplicationEntity(int id, string jobTitle, string companyName, string status, DateTime appliedDate, DateTime? previewAnswerDate, int applicantId, ApplicantEntity? applicant)
        {
            Id = id;
            JobTitle = jobTitle;
            CompanyName = companyName;
            Status = status;
            AppliedDate = appliedDate;
            PreviewAnswerDate = previewAnswerDate;
            ApplicantId = applicantId;
            Applicant = applicant;
        }
    }
}
