namespace Achievements.Domain.Model
{
    public class AdmitWorker : AchievementStateBase
    {
        public override AchievementType NextState()
        {
            return AchievementType.StartResearch;
        }
    }
}