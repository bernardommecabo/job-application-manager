using ProjectShared.DTOs.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.DTOs.response
{
    public class ApplicationDTOResponse
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime? PreviewAnswerDate { get; set; }

        public ApplicationDTOResponse() { }
        public ApplicationDTOResponse(ApplicationDTORequest applicationDTORequest)
        {
            this.JobTitle = applicationDTORequest.JobTitle;
            this.CompanyName = applicationDTORequest.CompanyName;
            this.Status = applicationDTORequest.Status;
            this.AppliedDate = applicationDTORequest.AppliedDate;
            this.PreviewAnswerDate = applicationDTORequest?.PreviewAnswerDate;
        }

    }
}
