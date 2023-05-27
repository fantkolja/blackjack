using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class RiskyStrategy : IStrategy
    {
        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            // Risky strategy: stops after reaching a sum of 19 points
            return PointsCounter.CountSum(drawnCards) < 19;
        }
    }
}
