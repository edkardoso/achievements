
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Achievements.Tests
{
	[TestFixture]
	public class AchievementTests
	{
				
		[Test]
		public void Testando()
		{
			Assert.AreEqual(1,1);
		}
		
		/*
		 * 1 - Quando abrir popup, buscar missao pendente do jogador (IsCompleted == false)
		 * 2 - Se encontrar, verificar se ele concluiu 
		 * 3 - Caso tenha concluido, incluir nova missao
		 * 4 - Exibir missao pendente
		 * 
		 * A partir da 10a. missao, o jogador poderá escolher a missao que desejar
		 */

		
		
	}

	/// <summary>
	/// State pattern
	/// </summary>
	public class Achievement
	{
		private MissionState _missionState;
		
		public void Show()
		{
			_missionState.VerificarMissaoConcluida(this);
		}

		public MissionState CurrentMission { get; set; }
	}


	public abstract class MissionState
	{
		public abstract bool VerificarMissaoConcluida(Achievement achievement);
	}


	public class Missao1 : MissionState
	{
		public override bool VerificarMissaoConcluida(Achievement achievement)
		{
			if (true) //Se concluida
			{
				achievement.CurrentMission = new Missao2();
			}
			return true;
		}
	}

	public class Missao2 : MissionState
	{
		public override bool VerificarMissaoConcluida(Achievement achievement)
		{
			return true;
		}
	}





	//POCOs

	class XAchievement
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}


	class XPlayer
	{
		public int Id { get; set; }
		public ICollection<PlayerAchievement> Achievements { get; set; }
	}

	class PlayerAchievement
	{

		public PlayerAchievement()
		{

		}

		public PlayerAchievement(XPlayer player)
		{

		}

		public int Id { get; set; }
		public XPlayer Player { get; set; }
		public XAchievement Achievement { get; set; }
		public bool IsCompleted { get; set; }
	}

	
}

