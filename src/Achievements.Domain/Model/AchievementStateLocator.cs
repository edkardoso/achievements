using System;
using System.Collections.Generic;
using System.Linq;

namespace Achievements.Domain.Model
{
    public static class AchievementStateLocator
    {
        private static readonly IDictionary<AchievementType, AchievementStateBase> Services;
        static AchievementStateLocator()
        {
            Services = new Dictionary<AchievementType, AchievementStateBase>
                           {
                               {AchievementType.AdmitWorker, new AdmitWorker()},
                               {AchievementType.StartResearch, new StartResearch()}
                           };
        }

        public static AchievementStateBase Instance(AchievementType type)
        {
            var instance = Services.First(c => c.Key.Equals(type)).Value;
            if (instance == null)
                throw new NotImplementedException("AchievementState was not implemented");

            return instance;
        }
    }
}