using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.DTOs.request
{
    public class ApplicationDTORequest
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime? PreviewAnswerDate { get; set; }
    }
}
