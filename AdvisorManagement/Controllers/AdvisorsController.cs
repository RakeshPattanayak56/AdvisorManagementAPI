using Advisor.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Advisor.Domain.Entities;

namespace AdvisorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorsController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;

        public AdvisorsController(IAdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvisor(AdvisorsDto advisorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var advisor = new Advisors
            {
                Name = advisorDto.Name,
                SIN = advisorDto.SIN,
                Address = advisorDto.Address,
                Phone = advisorDto.Phone                
            };
            var createdAdvisor = await _advisorService.CreateAdvisorAsync(advisor);
            return CreatedAtAction(nameof(GetAdvisorById), new { id = createdAdvisor.Id }, createdAdvisor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvisorById(int id)
        {
            var advisor = await _advisorService.GetAdvisorByIdAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }
            return Ok(advisor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvisors()
        {
            var advisors = await _advisorService.GetAllAdvisorsAsync();
            return Ok(advisors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdvisor(int id, Advisors advisor)
        {
            if (id != advisor.Id)
            {
                return BadRequest();
            }

            var updatedAdvisor = await _advisorService.UpdateAdvisorAsync(advisor);
            return Ok(updatedAdvisor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(int id)
        {
            await _advisorService.DeleteAdvisorAsync(id);
            return NoContent();
        }
    }
}
