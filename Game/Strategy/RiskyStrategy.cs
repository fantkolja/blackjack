using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class RiskyStrategy : IStrategy
    {
        public bool Deside(List<Card> cards)
        {
            return PointsCounter.CountSum(cards) < 19;
        }
    }
}
