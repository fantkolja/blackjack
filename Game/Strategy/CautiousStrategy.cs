using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CautiousStrategy : IStrategy
    {
        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            // Cautious strategy: stops after reaching a sum of 13 points
            return PointsCounter.CountSum(drawnCards) < 13;
        }
    }
}
