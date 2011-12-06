using System.Data.Entity;
using Achievements.Domain.Entities;

namespace Achievements.Domain.Infra
{
    public class GameModelContext : DbContext
    {
        public GameModelContext() : base("GameModelContext")
        {
        }

        public IDbSet<PlayerAchievement> PlayerAchievements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlayerAchievementConfiguration());
     
            base.OnModelCreating(modelBuilder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }


    }

    public class GameModelContextInitializer : DropCreateDatabaseIfModelChanges<GameModelContext>
    {
        protected override void Seed(GameModelContext context)
        {
        }
    }
}

