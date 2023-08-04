using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface IAchievementRepository
    {
        Task<List<Achievement>> GetAllAchievements();
        Task<Achievement> GetAchievement(int id);
        void PutAchievement(int id, Achievement achievement);

        Task<Achievement> PostAchievement(Achievement achievement);
        Task<Achievement> DeleteAchievement(int id);
    }
}
