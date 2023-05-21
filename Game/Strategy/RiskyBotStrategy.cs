using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class RiskyBotStrategy : IBotStrategy
    {
        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            return PointsCounter.CountSum(drawnCards) < 19;
        }
    }
}
