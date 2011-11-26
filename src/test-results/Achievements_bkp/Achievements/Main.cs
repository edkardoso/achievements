using System;
using System.Collections.Generic;

namespace Achievements
{
	class MainClass
	{
		private static List<Achievement> _achievementsList;
		
		public static void Main (string[] args)
		{
			Console.WriteLine ("Starting Achievements...");
			
			_achievementsList = new List<Achievement>() 
			{
				new Achievement(){ Id = 1, Name = "Contratar trabalhadores até um mínimo de 15", Description = "Você precisa de trabalhadores para produzir recursos blablabla"},
				new Achievement(){ Id = 2, Name = "Iniciar pesquisa de qualquer classe nivel 1", Description = "Você precisa de trabalhadores para produzir recursos blablabla"},
				new Achievement(){ Id = 3, Name = "Contratar trabalhadores até um mínimo de 15", Description = "Você precisa de trabalhadores para produzir recursos blablabla"},
				new Achievement(){ Id = 4, Name = "Contratar trabalhadores até um mínimo de 15", Description = "Você precisa de trabalhadores para produzir recursos blablabla"},
				new Achievement(){ Id = 5, Name = "Contratar trabalhadores até um mínimo de 15", Description = "Você precisa de trabalhadores para produzir recursos blablabla"}
			};
			
			var player = new Player { Id = 1 };
			
			var playerAchievement =  new PlayerAchievement(player);
			
			
			
		}
		
		
		
	}
	
	
	
	
	public class AudioPlayer
	{
	    private AudioPlayerState _state;
	
	    public AudioPlayer(AudioPlayerState state)
	    {
	        _state = state;
	    }
	
	    public void PressPlay()
	    {
	        _state.PressPlay(this);
	    }
	
	    public void PressAudioSource()
	    {
	        _state.PressAudioSource(this);
	    }
	
	    public AudioPlayerState CurrentState
	    {
	        get { return _state; }
	        set { _state = value; }
	    }
	}
	
	
	public abstract class AudioPlayerState
	{
	    public abstract void PressPlay(AudioPlayer player);
	
	    public abstract void PressAudioSource(AudioPlayer player);
	}
	
	
	public class StandbyState : AudioPlayerState
	{
	    public StandbyState()
	    {
	        Console.WriteLine("STANDBY");
	    }
	
	    public override void PressPlay(AudioPlayer player)
	    {
	        Console.WriteLine("Play pressed: No effect");
	    }
	
	    public override void PressAudioSource(AudioPlayer player)
	    {
	        player.CurrentState = new MP3PlayingState();
	    }
	}
	
	
	public class MP3PlayingState : AudioPlayerState
	{
	    public MP3PlayingState()
	    {
	        Console.WriteLine("MP3 PLAYING");
	    }
	
	    public override void PressPlay(AudioPlayer player)
	    {
	        player.CurrentState = new MP3PausedState();
	    }
	
	    public override void PressAudioSource(AudioPlayer player)
	    {
	        player.CurrentState = new RadioState();
	    }
	}
	
	
	public class MP3PausedState : AudioPlayerState
	{
	    public MP3PausedState()
	    {
	        Console.WriteLine("MP3 PAUSED");
	    }
	
	    public override void PressPlay(AudioPlayer player)
	    {
	        player.CurrentState = new MP3PlayingState();
	    }
	
	    public override void PressAudioSource(AudioPlayer player)
	    {
	        player.CurrentState = new RadioState();
	    }
	}
	
	
	public class RadioState : AudioPlayerState
	{
	    public RadioState()
	    {
	        Console.WriteLine("RADIO");
	    }
	
	    public override void PressPlay(AudioPlayer player)
	    {
	        Console.WriteLine("Play pressed: New station selected");
	    }
	
	    public override void PressAudioSource(AudioPlayer player)
	    {
	        player.CurrentState = new StandbyState();
	    }
	}
		
		
	
	//POCO's
	
	class Achievement 
	{
		public int Id {get;set;}
		public string Name {get;set;}
		public string Description {get;set;}
	}

	
	class Player
	{
		public int Id {get;set;}
		public ICollection<PlayerAchievement> Achievements {get;set;}
	}
	
	class PlayerAchievement
	{
		
		public PlayerAchievement(){
			
		}
		
		public PlayerAchievement(Player player){
		
		}
	
		public int Id {get;set;}
		public Player Player {get;set;}
		public Achievement Achievement {get;set;}
		public bool IsCompleted {get;set;} 
	}

	


}

