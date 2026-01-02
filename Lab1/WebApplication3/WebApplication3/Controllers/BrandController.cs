using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.DTOs;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        // GET: api/brands
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        // GET: api/brands/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            return brand == null ? NotFound() : Ok(brand);
        }

        // POST: api/brands
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandDto dto)
        {
            var brand = new Brand
            {
                Name = dto.Name
            };

            await _service.AddAsync(brand);

            return CreatedAtAction(nameof(Get), new { id = brand.Id }, brand);
        }

        // PUT: api/brands/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BrandDto dto)
        {
            var brand = await _service.GetByIdAsync(id);
            if (brand == null) return NotFound();

            brand.Name = dto.Name;
            await _service.UpdateAsync(brand);

            return NoContent();
        }

        // DELETE: api/brands/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
