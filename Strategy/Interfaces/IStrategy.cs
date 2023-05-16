using System;

namespace blackjack.Strategy.Interfaces
{
    public interface IStrategy
    {
        public bool Play(int points);
    }
}
