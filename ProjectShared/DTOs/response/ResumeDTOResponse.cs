using ProjectDomain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.DTOs.response
{
    public class ResumeDTOResponse
    {
        public int Id { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public int? ApplicantId { get; set; }

        public ResumeDTOResponse(ResumeEntity resumeEntity)
        {
            if (resumeEntity == null) throw new ArgumentNullException(nameof(resumeEntity));

            this.Id = resumeEntity.Id;
            this.FilePath = resumeEntity.FilePath;
            this.ApplicantId = resumeEntity.ApplicantId;
        }
    }
}
