using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;

namespace Nik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : ControllerBase
    {
        private readonly NikDbContext _context;

        public SocialsController(NikDbContext context)
        {
            _context = context;
        }

        // GET: api/Socials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Social>>> GetSocials()
        {
          if (_context.Socials == null)
          {
              return NotFound();
          }
            return await _context.Socials.ToListAsync();
        }

        // GET: api/Socials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Social>> GetSocial(int id)
        {
          if (_context.Socials == null)
          {
              return NotFound();
          }
            var social = await _context.Socials.FindAsync(id);

            if (social == null)
            {
                return NotFound();
            }

            return social;
        }

        // PUT: api/Socials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocial(int id, Social social)
        {
            if (id != social.SocialId)
            {
                return BadRequest();
            }

            _context.Entry(social).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialExists(id))
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

        // POST: api/Socials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Social>> PostSocial(Social social)
        {
          if (_context.Socials == null)
          {
              return Problem("Entity set 'NikDbContext.Socials'  is null.");
          }
            _context.Socials.Add(social);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocial", new { id = social.SocialId }, social);
        }

        // DELETE: api/Socials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            if (_context.Socials == null)
            {
                return NotFound();
            }
            var social = await _context.Socials.FindAsync(id);
            if (social == null)
            {
                return NotFound();
            }

            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocialExists(int id)
        {
            return (_context.Socials?.Any(e => e.SocialId == id)).GetValueOrDefault();
        }
    }
}
