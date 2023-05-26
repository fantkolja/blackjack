using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class Bot : Player
    {
        public Bot(string name, IStrategy strategy) : base(name)
        {
            Strategy = strategy;
        }

        public IStrategy Strategy { get; }

        public override bool ConfirmNextDraw()
        {
            return Strategy.Deside(this.DrawnCards);
        }
    }
}
