using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Entitites
{
    public class ResumeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int? ApplicantId { get; set; }
        public ApplicantEntity? Applicant { get; set; }

        public ResumeEntity(int id, string name, string filePath, int applicantId)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
            this.Id = id;
            this.Name = name;
            this.FilePath = filePath;
            this.ApplicantId = applicantId;
        }

        public ResumeEntity()
        {
        }
    }
}
