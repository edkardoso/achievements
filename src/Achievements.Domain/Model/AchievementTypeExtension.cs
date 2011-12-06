namespace Achievements.Domain.Model
{
    public static class AchievementTypeExtension
    {
        public static AchievementType NextState(this AchievementType type)
        {
            return AchievementStateLocator.Instance(type).NextState();
        }
    }
}