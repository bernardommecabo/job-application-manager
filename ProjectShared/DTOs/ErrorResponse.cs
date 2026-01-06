using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.DTOs
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(string message)
        {
            Message = message;
            Errors = new List<string>();
        }

        public ErrorResponse(string message, List<string> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}
