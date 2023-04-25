using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
	public class HazardStrategy : IStrategy
	{
		public bool Play(int points)
		{
			if(points>=19)
			{
				return false;
			}
			
			return true;
		}
	}
}
