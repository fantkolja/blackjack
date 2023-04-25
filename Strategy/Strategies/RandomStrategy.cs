using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
	public class RandomStrategy : IStrategy
	{
		public bool Play(int points)
		{
			if(points<=21&&points>=19)
			{
				return false;
			}
			if(points>10)
			{
				return true;
			}
			
			return true;
		}
	}
}
