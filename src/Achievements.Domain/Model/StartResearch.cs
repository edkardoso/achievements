namespace Achievements.Domain.Model
{
    public class StartResearch : AchievementStateBase
    {
        public override AchievementType NextState()
        {
            return AchievementType.None;
        }
    }
}