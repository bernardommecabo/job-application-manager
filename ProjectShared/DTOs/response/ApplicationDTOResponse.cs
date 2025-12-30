using ProjectDomain.Entitites;
using ProjectShared.DTOs.request;
using System;

namespace ProjectShared.DTOs.response
{
    public class ApplicationDTOResponse
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedDate { get; set; }
        public DateTime? PreviewAnswerDate { get; set; }

        public ApplicationDTOResponse() { }

        public ApplicationDTOResponse(ApplicationEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            this.Id = entity.Id;
            this.JobTitle = entity.JobTitle ?? string.Empty;
            this.CompanyName = entity.CompanyName ?? string.Empty;
            this.Status = entity.Status ?? string.Empty;
            this.AppliedDate = entity.AppliedDate;
            this.PreviewAnswerDate = entity.PreviewAnswerDate;
        }
    }
}
