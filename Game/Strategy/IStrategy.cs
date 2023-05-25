using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public interface IStrategy
    {
        public bool StopTakingCards();
    }
}
