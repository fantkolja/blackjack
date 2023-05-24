using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class RandomStrategy : IStrategy
    {
        public bool RequestNextDraw(List<Card> drawnCards)
        {
            int points = PointsCounter.CountSum(drawnCards);
            if (points > 13) 
            {
                var random = new Random();
                if(random.Next(0, 2) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
