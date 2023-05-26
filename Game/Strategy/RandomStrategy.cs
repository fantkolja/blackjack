using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class RandomStrategy : IStrategy
    {
        public bool Deside(List<Card> cards)
        {
            if (PointsCounter.CountSum(cards) < 17) return true;

            Random random = new Random();
            return random.Next(0, 2) == 0;
        }
    }
}
