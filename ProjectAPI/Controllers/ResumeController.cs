using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Services.Interfaces;
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
                return BadRequest(new { message = ex.Message});
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
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpPut("/applicant/{applicantId}/resume")]
        public async Task<IActionResult> updateResume([FromRoute]int applicantId, [FromBody] ResumeDTORequest request)
        {
            try
            {
                var response = await resumeService.updateResume(applicantId, request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpDelete("/applicant/{applicantId}/resume")]
        public async Task<IActionResult> deleteResume([FromRoute] int applicantId)
        {
            try
            {
                var response = await resumeService.deleteResume(applicantId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
