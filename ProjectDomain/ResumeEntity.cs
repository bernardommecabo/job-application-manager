using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public class ResumeEntity
    {
        private int id { get; set; }
        private string filePath { get; set; }
        private string? applicantId { get; set; }
        private ApplicantEntity? applicant { get; set; }

        public ResumeEntity(int id, string filePath, string applicantId)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
            if (string.IsNullOrEmpty(applicantId)) throw new ArgumentException("Applicant ID cannot be null or empty", nameof(applicantId));
            this.id = id;
            this.filePath = filePath;
            this.applicantId = applicantId;
        }

        public interface IResumeEntityRepository
        {
            Task<ResumeEntity> GetResumeByIdAsync(int id);
            Task CreateResumeAsync(ResumeEntity resume);
            Task UpdateResumeAsync(ResumeEntity resume);
            Task DeleteResumeAsync(int id);
        }
    }
}
