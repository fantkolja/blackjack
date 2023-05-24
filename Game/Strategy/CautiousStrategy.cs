using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class CautiousStrategy : IStrategy
    {
        public bool RequestNextDraw(List<Card> cards)
        {
           return PointsCounter.CountSum(cards) < 13;
        }
    }
}
