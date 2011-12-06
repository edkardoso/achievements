namespace Achievements.Domain.Model
{
    public class StartResearchRule : IAchievementRule
    {
        public bool IsAchievementComplied()
        {
            return false;
        }
    }
}