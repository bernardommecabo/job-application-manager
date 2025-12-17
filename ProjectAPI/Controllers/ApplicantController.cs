using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Services;
using ProjectShared.DTOs.request;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;

        public ApplicantController(IApplicantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> createApplicant([FromBody] ApplicantDTORequest request)
        {
            try
            {
                var response = await _service.createApplicant(request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getApplicantById(int id)
        {
            try
            {
                var response = await _service.getApplicantById(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllApplicants()
        {
            try
            {
                var response = await _service.getAllApplicants();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateApplicant(int id, [FromBody] ApplicantDTORequest request)
        {
            try
            {
                var response = await _service.updateApplicant(id, request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteApplicant(int id)
        {
            try
            {
                _service.deleteApplicantById(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }
    }
}
