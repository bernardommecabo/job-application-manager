using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Services;
using ProjectShared.DTOs.request;

namespace ProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService resumeService;

        public ResumeController(IResumeService service)
        {
            resumeService = service;
        }

        [HttpPost]
        [Route("/applicant/{applicantId}/resume")]
        public async Task<IActionResult> createResume([FromRoute] int applicantId,[FromBody] ResumeDTORequest request)
        {
            try
            {
                var response = await resumeService.createResume(applicantId,request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpGet("{resumeId}")]
        public async Task<IActionResult> getResumeById([FromRoute] int resumeId)
        {
            try
            {
                var response = await resumeService.getResumeById(resumeId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpGet]
        [Route("/applicant/{applicantId}/resume")]
        public async Task<IActionResult> getResumeByApplicantId([FromRoute] int applicantId)
        {
            try
            {
                var response = await resumeService.getResumeByApplicantId(applicantId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpPut("{resumeId}")]
        public async Task<IActionResult> updateResume([FromRoute]int resumeId, [FromBody] ResumeDTORequest request)
        {
            try
            {
                var response = await resumeService.updateResume(resumeId, request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpDelete("{resumeId}")]
        public async Task<IActionResult> deleteResume([FromRoute] int resumeId)
        {
            try
            {
                var response = await resumeService.deleteResume(resumeId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }
    }
}
