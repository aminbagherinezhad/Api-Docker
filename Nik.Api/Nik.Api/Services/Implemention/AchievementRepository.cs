using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Services.Interfaces;

namespace Nik.Api.Services.Implemention
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly NikDbContext _context;
        public AchievementRepository(NikDbContext context)
        {
            _context = context;
        }
        public async Task<Achievement> DeleteAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return null;
            }
            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();
            return achievement;
        }

        public async Task<Achievement> GetAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return null;
            }
            return achievement;
        }

        public async Task<List<Achievement>> GetAllAchievements()
        {
            var AllAchievements =await _context.Achievements.ToListAsync();
            return AllAchievements;

        }

        public async Task<Achievement> PostAchievement(Achievement achievement)
        {
            Achievement achev = new Achievement()
            {
                Icon = achievement.Icon,
                Number = achievement.Number,
                Title = achievement.Title,
            };
            _context.Achievements.Add(achev);
            await _context.SaveChangesAsync();
            return achev;
        }

        public async void PutAchievement(int id, Achievement achievement)
        {
            var put = _context.Achievements.Where(g => g.AchievementId == id).Select(p => new Achievement
            {
                Icon = p.Icon,
                Number = p.Number,
                Title = p.Title,
            });
            await _context.SaveChangesAsync();
        }
    }
}
