using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
	public class CarefulStrategy : IStrategy
	{
		public bool Play(int points)
		{
			return !(points>=13);
		}
	}
}