using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class RandomBotStrategy : IBotStrategy
    {
        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            if (PointsCounter.CountSum(drawnCards) > 13)
            {
                var random = new Random();
                if (random.Next(2) == 0)
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
