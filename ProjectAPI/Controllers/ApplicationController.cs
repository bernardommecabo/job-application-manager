using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Services.Interfaces;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;

namespace ProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService applicationService;

        public ApplicationController(IApplicationService service)
        {
            applicationService = service;
        }

        [HttpPost]
        public IActionResult AddApplication([FromBody] ApplicationDTORequest request)
        {
            try
            {
                var response = applicationService.AddApplication(request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message, full = ex.ToString(), inner = ex.InnerException?.ToString() });
            }
        }

        // GET: api/<ApplicationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApplicationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        

        // PUT api/<ApplicationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
