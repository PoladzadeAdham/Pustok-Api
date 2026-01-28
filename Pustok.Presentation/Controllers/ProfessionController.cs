using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Buisness.Dtos.ProfessionDtos;
using Pustok.Buisness.Services.Abstractions;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController(IProfessionService _professionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professions = await _professionService.GetAllAsync();

            return Ok(professions);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var profession = await _professionService.GetById(id);

            if (profession is null)
                return NotFound();

            return Ok(profession);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProfessionCreateDto dto)
        {
            await _professionService.CreateAsync(dto);

            return Created();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProfessionUpdateDto dto)
        {
            await _professionService.UpdateAsync(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _professionService.DeleteAsync(id);

            return Ok();
        }

    }
}
