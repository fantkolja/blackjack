using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class BotPlayer : Player
    {
        public IBotStrategy Strategy { get; set; }

        public BotPlayer(string name, IBotStrategy strategy) : base(name)
        {
            Strategy = strategy;
        }

        public override bool ConfirmNextDraw()
        {
            return Strategy.ConfirmNextDraw(DrawnCards);
        }
    }
}
