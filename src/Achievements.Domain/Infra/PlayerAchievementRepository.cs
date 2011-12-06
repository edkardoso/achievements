using Achievements.Domain.Entities;
using Achievements.Domain.Repositories;

namespace Achievements.Domain.Infra
{

    public class PlayerAchievementRepository : EFGenericRepository<PlayerAchievement>, IPlayerAchievementRepository
    {
        public PlayerAchievementRepository(GameModelContext gameModelContext)
            : base(gameModelContext)
        {
        }

    }
}
