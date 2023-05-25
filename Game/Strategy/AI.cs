using blackjack.Game.Observer;
using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public abstract class AI : Player
    {
        protected static int _Id = 0;
        public AI()
        {
            _Id += 1;
        }
    }
}
