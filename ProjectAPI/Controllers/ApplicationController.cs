using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Services;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectApplication.Services.Interfaces;

namespace ProjectAPI.Controllers
{
    [Route("applicants/{applicantId}/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddApplication([FromRoute] int applicantId, [FromBody] ApplicationDTORequest request)
        {
            try
            {
                var response = await _applicationService.createApplication(applicantId, request);
                return CreatedAtAction(nameof(GetById), new { applicantId = applicantId, applicationId = response.Id }, response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int applicantId)
        {
            try
            {
                var list = await _applicationService.getAllApplications(applicantId);
                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetById([FromRoute] int applicantId, [FromRoute] int applicationId)
        {
            try
            {
                var response = await _applicationService.getApplicationById(applicantId, applicationId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{applicationId}")]
        public async Task<IActionResult> Update([FromRoute] int applicantId, [FromRoute] int applicationId, [FromBody] ApplicationDTORequest request)
        {
            try
            {
                var response = await _applicationService.updateApplication(applicantId, applicationId, request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{applicationId}")]
        public async Task<IActionResult> Delete([FromRoute] int applicantId, [FromRoute] int applicationId)
        {
            try
            {
                var response = await _applicationService.deleteApplication(applicantId, applicationId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
