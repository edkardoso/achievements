using Achievements.Domain.Entities;
using Achievements.Domain.Model;
using Achievements.Domain.Repositories;

namespace Achievements.Domain.Services
{
	public class PlayerAchievementService : IPlayerAchievementService
	{
		private readonly IPlayerAchievementRepository _playerAchievementRepository;

		public PlayerAchievementService(IPlayerAchievementRepository playerAchievementRepository)
		{
			_playerAchievementRepository = playerAchievementRepository;
		}
		
		public PlayerAchievement GetAchievement(int playerId)
		{
			var playerAchievement = _playerAchievementRepository.First(p => p.Player.Id.Equals(playerId) && p.IsComplied == false);
			if (playerAchievement == null)
				return null;

			if (playerAchievement.IsAchievementComplied())
			{
				SaveAchievementComplied(playerAchievement);
				return AddNextAchievement(playerAchievement.Player, playerAchievement.Type.NextState());
			}
			return playerAchievement;

		}

		private PlayerAchievement AddNextAchievement(Player player, AchievementType achievementType)
		{
			var newAchievement = new PlayerAchievement(player, achievementType);
			_playerAchievementRepository.Add(newAchievement);
			_playerAchievementRepository.SaveChanges();
			return newAchievement;
		}

		private void SaveAchievementComplied(PlayerAchievement playerAchievement)
		{
			playerAchievement.IsComplied = true;
			_playerAchievementRepository.Edit(playerAchievement);
			_playerAchievementRepository.SaveChanges();
		}

	}
}