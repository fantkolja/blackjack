using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
	public class RandomStrategy : IStrategy
	{
		public bool Play(int points)
		{
			if(points<=21 && points>=17)
			{
				return false;
			}
			if(points>12)
			{
				return true;
			}

			return true;
		}
	}
}