namespace Achievements.Domain.Model
{
    public class AdmitWorkerRule: IAchievementRule
    {
        public bool IsAchievementComplied()
        {
            return true;
        }
    }
}