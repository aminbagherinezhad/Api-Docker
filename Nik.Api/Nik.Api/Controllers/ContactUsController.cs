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
    public class ContactUsController : ControllerBase
    {
        private readonly NikDbContext _context;

        public ContactUsController(NikDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactUs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactU>>> GetContactUs()
        {
          if (_context.ContactUs == null)
          {
              return NotFound();
          }
            return await _context.ContactUs.ToListAsync();
        }

        // GET: api/ContactUs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactU>> GetContactU(int id)
        {
          if (_context.ContactUs == null)
          {
              return NotFound();
          }
            var contactU = await _context.ContactUs.FindAsync(id);

            if (contactU == null)
            {
                return NotFound();
            }

            return contactU;
        }

        // PUT: api/ContactUs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactU(int id, ContactU contactU)
        {
            if (id != contactU.ContactUsId)
            {
                return BadRequest();
            }

            _context.Entry(contactU).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactUExists(id))
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

        // POST: api/ContactUs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactU>> PostContactU(ContactU contactU)
        {
          if (_context.ContactUs == null)
          {
              return Problem("Entity set 'NikDbContext.ContactUs'  is null.");
          }
            _context.ContactUs.Add(contactU);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactU", new { id = contactU.ContactUsId }, contactU);
        }

        // DELETE: api/ContactUs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactU(int id)
        {
            if (_context.ContactUs == null)
            {
                return NotFound();
            }
            var contactU = await _context.ContactUs.FindAsync(id);
            if (contactU == null)
            {
                return NotFound();
            }

            _context.ContactUs.Remove(contactU);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactUExists(int id)
        {
            return (_context.ContactUs?.Any(e => e.ContactUsId == id)).GetValueOrDefault();
        }
    }
}
