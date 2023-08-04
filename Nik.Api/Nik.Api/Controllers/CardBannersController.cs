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
    public class CardBannersController : ControllerBase
    {
        private readonly NikDbContext _context;

        public CardBannersController(NikDbContext context)
        {
            _context = context;
        }

        // GET: api/CardBanners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardBanner>>> GetCardBanners()
        {
          if (_context.CardBanners == null)
          {
              return NotFound();
          }
            return await _context.CardBanners.ToListAsync();
        }

        // GET: api/CardBanners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardBanner>> GetCardBanner(int id)
        {
          if (_context.CardBanners == null)
          {
              return NotFound();
          }
            var cardBanner = await _context.CardBanners.FindAsync(id);

            if (cardBanner == null)
            {
                return NotFound();
            }

            return cardBanner;
        }

        // PUT: api/CardBanners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardBanner(int id, CardBanner cardBanner)
        {
            if (id != cardBanner.CardBannerId)
            {
                return BadRequest();
            }

            _context.Entry(cardBanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardBannerExists(id))
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

        // POST: api/CardBanners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardBanner>> PostCardBanner(CardBanner cardBanner)
        {
          if (_context.CardBanners == null)
          {
              return Problem("Entity set 'NikDbContext.CardBanners'  is null.");
          }
            _context.CardBanners.Add(cardBanner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardBanner", new { id = cardBanner.CardBannerId }, cardBanner);
        }

        // DELETE: api/CardBanners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardBanner(int id)
        {
            if (_context.CardBanners == null)
            {
                return NotFound();
            }
            var cardBanner = await _context.CardBanners.FindAsync(id);
            if (cardBanner == null)
            {
                return NotFound();
            }

            _context.CardBanners.Remove(cardBanner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardBannerExists(int id)
        {
            return (_context.CardBanners?.Any(e => e.CardBannerId == id)).GetValueOrDefault();
        }
    }
}
