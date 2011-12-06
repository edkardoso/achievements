using Achievements.Domain.Infra;
using Achievements.Domain.Repositories;
using NUnit.Framework;

namespace Achievements.Domain.Tests
{
    [TestFixture]
    public class PlayerAchievementRepositoryTests
    {

        private IPlayerAchievementRepository _playerAchievementRepository;
        
        [SetUp]
        public void Initializer()
        {
            _playerAchievementRepository = new PlayerAchievementRepository(new GameModelContext());
        }


        //[Test]
        //public void Inserindo_PlayerAchievement()
        //{
        //    var playerAchievement = new PlayerAchievement() {PlayerId = 1};
        //    _playerAchievementRepository.Add(playerAchievement);
        //    _playerAchievementRepository.SaveChanges();
        //    playerAchievement.Id.Should().BeGreaterOrEqualTo(1);
        //}


        //[Test]
        //public void Recuperando_PlayerAchievement()
        //{

        //    var playeraChievement = _playerAchievementRepository.Find(p => p.PlayerId == 1).FirstOrDefault();
        //    playeraChievement.Should().NotBeNull();
        //}
    }
}

