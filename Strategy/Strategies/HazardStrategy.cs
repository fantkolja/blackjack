using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
	public class HazardStrategy : IStrategy
	{
		public bool Play(int points)
		{
			return !(points>=19);
		}
	}
}
