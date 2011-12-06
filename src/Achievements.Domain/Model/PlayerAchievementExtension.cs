using Achievements.Domain.Entities;
using Achievements.Domain.Helper;

namespace Achievements.Domain.Model
{
    public static class PlayerAchievementExtension
    {
        public static bool IsAchievementComplied(this PlayerAchievement playerAchievement)
        {
            return new ObjectFactory<IAchievementRule>()
                .CreateObject(playerAchievement.Type + "Rule")
                .IsAchievementComplied();
        }
    }
}