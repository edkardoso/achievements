using System.Data.Entity.ModelConfiguration;
using Achievements.Domain.Entities;

namespace Achievements.Domain.Infra
{
    public class PlayerAchievementConfiguration : EntityTypeConfiguration<PlayerAchievement>
    {
        public PlayerAchievementConfiguration()
        {
            HasKey(o => o.Id);

            ToTable("PlayerAchievement");
        }
    }
}
