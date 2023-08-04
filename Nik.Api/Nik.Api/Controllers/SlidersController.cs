using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Services.Interfaces;

namespace Nik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly NikDbContext _context;
        private readonly ISlidersRepository _sliderRepo;

        public SlidersController(NikDbContext context, ISlidersRepository slidersRepository)
        {
            _context = context;
            _sliderRepo = slidersRepository;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slider>>> GetSliders()
        {
            if (_context.Sliders == null)
            {
                return NotFound();
            }
            return await _sliderRepo.getAllSlider();
        }

        // GET: api/Sliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetSlider(int id)
        {
            if (_context.Sliders == null)
            {
                return NotFound();
            }
            var slider = await _sliderRepo.getSliderById(id);

            if (slider == null)
            {
                return NotFound();
            }

            return slider;
        }

        // PUT: api/Sliders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlider(int id, [FromForm] Slider slider)
        {
            if (id != slider.SliderId)
            {
                return BadRequest();
            }

            _context.Entry(slider).State = EntityState.Modified;

            try
            {
                await _sliderRepo.putSlider(id, slider);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sliders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Slider>> PostSlider([FromForm] Slider slider)
        {
            if (_context.Sliders == null)
            {
                return Problem("Entity set 'NikDbContext.Sliders'  is null.");
            }
            _sliderRepo.postSlider(slider);
            return CreatedAtAction("GetSlider", new { id = slider.SliderId }, slider);
        }

        // DELETE: api/Sliders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Sliders.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Sliders.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SliderExists(int id)
        {
            return (_context.Sliders?.Any(e => e.SliderId == id)).GetValueOrDefault();
        }
    }
}
