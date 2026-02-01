using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.Buisness.Dtos;
using Pustok.Buisness.Services.Abstractions;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Member")]
    public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _employeeService.GetByIdAsync(id);

            if (result.Data is null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
            var result = await _employeeService.CreateAsync(dto);

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeUpdateDto dto)
        {
            var result = await _employeeService.UpdateAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
