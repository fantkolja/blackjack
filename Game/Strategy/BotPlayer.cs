using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class BotPlayer : Player, IBotPlayer
    {
        public IStrategy Strategy { get; set; }

        public BotPlayer(string name, IStrategy strategy) : base(name)
        {
            Strategy = strategy;
        }
    }
}
