using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Repos.Interfaces;
using ProjectApplication.Services;
using ProjectApplication.Services.Interfaces;
using ProjectShared.DTOs.request;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;
        private readonly IApplicantRepository _repository;

        public ApplicantController(IApplicantService service, IApplicantRepository repository)
        {
            _service = service;
            _repository = repository;
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
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getApplicantById([FromRoute] int id)
        {
            try
            {
                var response = await _service.getApplicantById(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
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
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateApplicant([FromRoute] int id, [FromBody] ApplicantDTORequest request)
        {
            try
            {
                var response = await _service.updateApplicant(id, request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteApplicant([FromRoute] int id)
        {
            try
            {
                var response = await _service.deleteApplicantById(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> loginApplicant([FromBody] LoginDTORequest loginRequest)
        {
            try
            {
                var response = await _service.Login(loginRequest);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
