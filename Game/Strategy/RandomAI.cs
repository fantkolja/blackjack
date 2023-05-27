
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class RandomAI : AI
    {
        public override bool ConfirmNextDraw()
        {
            Random random = new Random();
            return random.Next(0, 100) < 80;
        }
    }
}
