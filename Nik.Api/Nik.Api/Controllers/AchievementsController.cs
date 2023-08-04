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
    public class AchievementsController : ControllerBase
    {
        private readonly NikDbContext _context;
        private readonly IAchievementRepository _achiev;

        public AchievementsController(NikDbContext context, IAchievementRepository achiev)
        {
            _context = context;
            _achiev = achiev;
        }

        // GET: api/Achievements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achievement>>> GetAchievements()
        {
            if (_context.Achievements == null)
            {
                return NotFound();
            }
            var result = await _achiev.GetAllAchievements();
            return result;
        }

        // GET: api/Achievements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achievement>> GetAchievement(int id)
        {
            if (_context.Achievements == null)
            {
                return NotFound();
            }
            var achievement = await _achiev.GetAchievement(id);

            if (achievement == null)
            {
                return NotFound();
            }

            return achievement;
        }

        // PUT: api/Achievements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchievement(int id, Achievement achievement)
        {
            if (id != achievement.AchievementId)
            {
                return BadRequest();
            }

            _context.Entry(achievement).State = EntityState.Modified;

            try
            {
                _achiev.PutAchievement(id, achievement);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
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

        // POST: api/Achievements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achievement>> PostAchievement(Achievement achievement)
        {
            if (_context.Achievements == null)
            {
                return Problem("Entity set 'NikDbContext.Achievements'  is null.");
            }
            await _achiev.PostAchievement(achievement);

            return CreatedAtAction("GetAchievement", new { id = achievement.AchievementId }, achievement);
        }

        // DELETE: api/Achievements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(int id)
        {
            if (_context.Achievements == null)
            {
                return NotFound();
            }
            var achievement = await _achiev.DeleteAchievement(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool AchievementExists(int id)
        {
            return (_context.Achievements?.Any(e => e.AchievementId == id)).GetValueOrDefault();
        }
    }
}
