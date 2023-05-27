using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class RandomStrategy : IStrategy
    {
        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            // Random strategy: makes a decision randomly
            Random random = new Random();
            return random.Next(2) == 0; // 50% chance to continue the game
        }
    }
}
