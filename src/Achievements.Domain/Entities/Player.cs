using System.Collections.Generic;

namespace Achievements.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public IList<PlayerAchievement> PlayerAchievements { get; set; }
    }
}