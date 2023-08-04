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
    public class CategoryImagesController : ControllerBase
    {
        private readonly NikDbContext _context;
        private readonly ICategoryImageRepository _categoryImageRepository;
        public CategoryImagesController(NikDbContext context, ICategoryImageRepository categoryImageRepository)
        {
            _context = context;
            _categoryImageRepository = categoryImageRepository;
        }

        // GET: api/CategoryImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryImage>>> GetCategoryImages()
        {
            if (_context.CategoryImages == null)
            {
                return NotFound();
            }

            return await _categoryImageRepository.getAllCategoryImages();
        }

        // GET: api/CategoryImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryImage>> GetCategoryImage(int id)
        {
            if (_context.CategoryImages == null)
            {
                return NotFound();
            }
            var categoryImage = await _categoryImageRepository.getByCategoryImage(id);

            if (categoryImage == null)
            {
                return NotFound();
            }

            return categoryImage;
        }

        // PUT: api/CategoryImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryImage(int id, [FromForm] CategoryImage categoryImage)
        {
            if (id != categoryImage.CategoryImageId)
            {
                return BadRequest();
            }

            _context.Entry(categoryImage).State = EntityState.Modified;

            try
            {
                await _categoryImageRepository.putCategoryImage(id, categoryImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryImageExists(id))
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

        // POST: api/CategoryImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryImage>> PostCategoryImage([FromForm] CategoryImage categoryImage)
        {
            if (_context.CategoryImages == null)
            {
                return Problem("Entity set 'NikDbContext.CategoryImages'  is null.");
            }
            await _categoryImageRepository.postCategoryImage(categoryImage);


            return CreatedAtAction("GetCategoryImage", new { id = categoryImage.CategoryImageId }, categoryImage);
        }

        // DELETE: api/CategoryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryImage(int id)
        {
            if (_context.CategoryImages == null)
            {
                return NotFound();
            }
            var category = await _context.CategoryImages.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.CategoryImages.Remove(category);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool CategoryImageExists(int id)
        {
            return (_context.CategoryImages?.Any(e => e.CategoryImageId == id)).GetValueOrDefault();
        }
    }
}
