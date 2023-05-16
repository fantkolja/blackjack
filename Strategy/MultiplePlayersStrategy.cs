using System;
using blackjack.Strategy.Interfaces;
using BlackJack;

namespace blackjack.Strategy
{
	internal class MultiplePlayersStrategy : IGameStrategy
	{
		private List<IPlayer> _players;
		
		public MultiplePlayersStrategy()
		{
			_players = new List<IPlayer>();
		}
		public List<IPlayer> GeneratePlayers()
		{
			for (int i = 1; i <= Game.PLAYER_COUNT; i++)
			{
				string defaultName = $"Player {i}";
				string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
				_players.Add(new Player(name));
			}
			return _players;
		}
	}
}
