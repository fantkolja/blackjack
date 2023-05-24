using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class CarefulBot : BotType
    {
        private int MaxRiskPoints = 13;
        public int GetMaxRiskPoints()
        {
            return MaxRiskPoints;
        }
    }
}
