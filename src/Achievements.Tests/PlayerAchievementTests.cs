/* 
   1 - Quando abrir popup, buscar missao pendente do jogador (IsComplied == false)
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
using Achievements.Domain.Entities;
using Achievements.Domain.Model;
using NUnit.Framework;
using FluentAssertions;

namespace Achievements.Domain.Tests
{
	[TestFixture]
	public class PlayerAchievementTests
	{
		
		[Test]
		public void Se_Jogador_Nao_Tiver_Missao_Definir_Missao_AdmitWorker()
		{
			new PlayerAchievement(new Player()).Type.Should().Be(AchievementType.AdmitWorker);
		}

		[Test]
		public void Deve_Retornar_Missao_StartResearch()
		{
			var playerAchievement = new PlayerAchievement(new Player());
			playerAchievement.Type.NextState().Should().Be(AchievementType.StartResearch);
		}
		
		[Test]
		public void Validando_Retorno_De_Regra_Para_AdmitWorker()
		{
			var playerAchievement = new PlayerAchievement(new Player()) {Type = AchievementType.AdmitWorker};
			playerAchievement.IsAchievementComplied().Should().BeTrue();
		}

		[Test]
		public void Validando_Retorno_De_Regra_Para_StartResearch()
		{
			var playerAchievement = new PlayerAchievement(new Player()) { Type = AchievementType.StartResearch };
			playerAchievement.IsAchievementComplied().Should().BeFalse();
		}

	}
}

