using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy
{
	internal class BaseOfGame
	{
		protected IGameStrategy _strategy;

		public BaseOfGame()
		{
			_strategy = new CooperativeStrategy();
		}
		public void SetStrategy(IGameStrategy strategy)
		{
			_strategy = strategy;
		}
	}
}