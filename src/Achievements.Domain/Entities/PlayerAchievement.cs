using Achievements.Domain.Model;

namespace Achievements.Domain.Entities
{
    public class PlayerAchievement
    {
        public PlayerAchievement(Player player) 
            : this(player, AchievementType.AdmitWorker)
        {
        }

        public PlayerAchievement(Player player, AchievementType achievementType)
        {
            Player = player;
            Type = achievementType;
        }

        public int Id { get; set; }
        public Player Player { get; set; }
        public AchievementType Type { get; set; }
        public bool IsComplied { get; set; }
    }
}