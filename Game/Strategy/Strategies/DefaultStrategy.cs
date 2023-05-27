using System;
using blackjack.Strategy.Interfaces;

namespace blackjack.Strategy.Strategies
{
    public class DefaultStrategy : IStrategy
    {
        public bool Play(int points)
        {
            return true;
        }
    }
}