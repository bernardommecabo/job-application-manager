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
        public ApplicantEntity applicantEntity { get; set; }

        public ApplicationEntity() 
        {
        }

        public ApplicationEntity(int id, string jobTitle, string companyName, string status, DateTime appliedDate, DateTime? previewAnswerDate, int applicantId, ApplicantEntity applicantEntity)
        {
            this.Id = id;
            this.JobTitle = jobTitle;
            this.CompanyName = companyName;
            this.Status = status;
            this.AppliedDate = appliedDate;
            this.PreviewAnswerDate = previewAnswerDate;
            this.ApplicantId = applicantId;
            this.applicantEntity = applicantEntity;
        }
    }
}
