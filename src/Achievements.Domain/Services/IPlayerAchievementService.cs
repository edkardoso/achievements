using Achievements.Domain.Entities;

namespace Achievements.Domain.Services
{
    public interface IPlayerAchievementService
    {
        PlayerAchievement GetAchievement(int playerId);
    }
}