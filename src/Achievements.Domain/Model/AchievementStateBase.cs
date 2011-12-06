namespace Achievements.Domain.Model
{
    public abstract class AchievementStateBase
    {
        public virtual AchievementType NextState()
        {
            return AchievementType.None;
        }
    }
}