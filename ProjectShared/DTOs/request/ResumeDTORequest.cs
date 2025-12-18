using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.DTOs.request
{
    public class ResumeDTORequest
    {
        public string FilePath { get; set; } = string.Empty;
        public int? ApplicantId { get; set; }
    }
}
