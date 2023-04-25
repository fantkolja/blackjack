using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class RandomStrategy : IStrategy
    {
        public bool DecideMove(int currentPoints)
        {
            Random random = new Random();
            if (random.Next(100) % 2 == 0)
            {
                return currentPoints < 19;
            }
            else
            {
                return currentPoints < 13;
            }
        }
    }
}
