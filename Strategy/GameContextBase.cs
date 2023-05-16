using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy
{
	internal class GameContextBase
	{
		protected IGameStrategy _strategy;
		
		public GameContextBase()
		{
			_strategy = new MultiplePlayersStrategy();
		}
		public void SetStrategy(IGameStrategy strategy)
		{
			_strategy = strategy;
		}
	}
}
