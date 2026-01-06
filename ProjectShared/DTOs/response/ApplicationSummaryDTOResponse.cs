using System;

namespace ProjectShared.DTOs.response
{
    public class ApplicationSummaryDTOResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime? PreviewAnswerDate { get; set; }
        public string Status { get; set; }
    }
}