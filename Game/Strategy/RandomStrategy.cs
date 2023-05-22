using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class RandomStrategy : IPlayingStrategy
    {
        private Random _random = new Random();

        public bool ShouldDrawCard(Player? player)
        {
            return _random.NextDouble() > 0.5;
        }
    }
}
