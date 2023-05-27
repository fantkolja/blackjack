using System;
using blackjack.Strategy.Interfaces;
using blackjack.Strategy.Strategies;
using BlackJack;

namespace blackjack.Strategy
{
	internal class SoloStrategy : IGameStrategy
	{
		private List<IPlayer> _players;

		public SoloStrategy()
		{
			_players = new List<IPlayer>();
		}
		public List<IPlayer> GeneratePlayers()
		{
			string defaultName = "Player 1";
			string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
			_players.Add(new Player(name));
			_players.Add(new Bot());
			return _players;
		}
	}
}