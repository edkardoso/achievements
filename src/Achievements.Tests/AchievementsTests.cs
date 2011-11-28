
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using FluentAssertions;
namespace Achievements.Tests
{
	[TestFixture]
	public class AchievementTests
	{



		/* //TODO
		   1 - Quando abrir popup, buscar missao pendente do jogador (IsCompleted == false)
		   2 - Se encontrar, verificar se ele concluiu 
		   3 - Caso tenha concluido, incluir nova missao
		   4 - Exibir missao pendente
		   
		   A partir da 10a. missao, o jogador poderá escolher a missao que desejar
		   
		   1- Contratar trabalhadores até um mínimo de 15 [200 / 200 / 200]
		   2- Iniciar pesquisa de qualquer classe 'nivel 1' [250 / 250 / 250]
		   3- Ensinar a se comunicar pelo fórum do territorio [3 azuritas]
		   4- Treinar 5 unidades de combate [500 / 500 / 500]
		   5- Contratar mais trabalhadores até um total de 20 ativos [3 azuritas]
		   6- Melhorar produção de todos os recursos para ter bonus de produção no 'nivel 1' [250 / 250 / 250]
		   7- Doar 100 de cada recurso para o fundo do territorio [3 Azuritas]
		   8- Pesquisa de qualquer unidade de classe 'nivel 2' [3 Azuritas] +  [500 / 500 / 500]
		   
			Tipo Achievement:
			- Defender um aliado
			- Capturar no minimo 1 trabalhador
			- Fazer com que heroi ganhe experiencia e chegue ao nivel 2
			
			- Ser o primeiro a atingir o nível 2, 3, 4, 5, 6...		   
		  
		   Tipos de Achievements:
		  
		  1 - DefinedBySystem
		  2 - DefinedByUser
		  
		  
		 */

		[Test]
		public void Se_Jogador_Nao_Tiver_Missao_Definir_Missao_AdmitWorker()
		{
			new PlayerAchievement().CurrentState.Should().BeOfType<AdmitWorker>();
		}

		[Test]
		public void Recupera_Missao_Jogador_Para_Ser_Exibida()
		{
			var mission = new PlayerAchievement().CurrentState;
			mission.Should().NotBeNull();
		}

		[Test]
		public void Validando_Retorno_De_Regra_Para_AdmitWorker()
		{
			IAchievementService achievementService = new AchievementService();
			var isCompleted = achievementService.IsCompleted<AdmitWorker>();
			isCompleted.Should().BeTrue();
		}

		[Test]
		public void Validando_Retorno_De_Regra_Para_StartResearch()
		{
			IAchievementService achievementService = new AchievementService();
			var isCompleted = achievementService.IsCompleted<StartResearch>();
			isCompleted.Should().BeFalse();
		}

		public void Se_Missao_Foi_Concluida_Deve_Retornar_Proxima_Missao()
		{
		}

		public void Se_Missao_NAO_Foi_Concluida_Deve_Retornar_Ela_Mesma()
		{
		}

		public void Se_Recebeu_Missao_Do_Tipo_DefinedByUser_Nao_Deve_Retornar_A_Mesma_Missao()
		{
		}


	}

	public class PlayerAchievement
	{
		private AchievementState _missionState;
		public PlayerAchievement()
		{
			CurrentState = CurrentState ?? new AdmitWorker();
		}

		public AchievementState GetMission(IAchievementService achievementService)
		{
			if (achievementService == null)
				throw new AccessViolationException("achievementService");

			if (_missionState.IsCompleted(this, achievementService))
				_missionState.NextState(this);

			return CurrentState;
		}

		public Player Player { get; set; }
		public AchievementState CurrentState { get; set; }
	}

	public class Player
	{
		public int Id { get; set; }
	}

	public abstract class AchievementState
	{
		public int AchievementId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		
		public abstract bool IsCompleted(PlayerAchievement achievement, IAchievementService achievementService);
		public abstract void NextState(PlayerAchievement achievement);
	}

	public class AdmitWorker : AchievementState
	{

		public override bool IsCompleted(PlayerAchievement achievement, IAchievementService achievementService)
		{
			return achievementService.IsCompleted<AdmitWorker>();
		}

		public override void NextState(PlayerAchievement achievement)
		{
			achievement.CurrentState = new StartResearch();
		}
	}

	public class StartResearch : AchievementState
	{
		public override bool IsCompleted(PlayerAchievement achievement, IAchievementService achievementService)
		{
			return achievementService.IsCompleted<StartResearch>();
		}

		public override void NextState(PlayerAchievement achievement)
		{
			achievement.CurrentState = new StartResearch();
		}
	}

	public interface IAchievementService
	{
		bool IsCompleted<T>();
	}

	public class AchievementService : IAchievementService
	{
		public bool IsCompleted<T>()
		{
			return AchievementRuleLocator.IsSatisfiedBy<T>();
		}
	}

	public static class AchievementRuleLocator
	{
		public static bool IsSatisfiedBy<T>()
		{
            return new ObjectFactory<IAchievementRule>().CreateObject(typeof (T).Name + "Rule").IsCompleted();
		}
	}

	public interface IAchievementRule
	{
		bool IsCompleted();
	}

	public class AdmitWorkerRule: IAchievementRule
	{
		public bool IsCompleted()
		{
			return true;
		}
	}

	public class StartResearchRule : IAchievementRule
	{
		public bool IsCompleted()
		{
			return false;
		}
	}

    public class ObjectFactory<T>
	{
		private readonly Dictionary<string, Type> _reportMap = new Dictionary<string, Type>();

		public ObjectFactory()
		{
			var types = Assembly.GetAssembly(typeof(T)).GetTypes();
			foreach (var type in types.Where(type => typeof(T).IsAssignableFrom(type) && type != typeof(T)))
				_reportMap.Add(type.Name, type);
		}

		public T CreateObject(string name, params object[] args)
		{
			return (T)Activator.CreateInstance(_reportMap[name], args);
		}
	}
}

