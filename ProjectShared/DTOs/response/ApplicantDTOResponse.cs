using ProjectDomain.Entitites;
using System;

namespace ProjectShared.DTOs.response
{
    public class ApplicantDTOResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Website { get; private set; }
        public int? resumeId { get; private set; }
        public DateTime? DateOfBirth { get; private set; }

        public ApplicantDTOResponse(ApplicantEntity applicantEntity)
        {
            if (applicantEntity == null) throw new ArgumentNullException(nameof(applicantEntity));

            this.Id = applicantEntity.Id;
            this.Name = applicantEntity.Name;
            this.Email = applicantEntity.Email;
            this.Phone = applicantEntity.Phone;
            this.Website = applicantEntity.Website;
            this.resumeId = applicantEntity.Resume?.Id;
            this.DateOfBirth = applicantEntity.DateOfBirth;
        }
    }
}
