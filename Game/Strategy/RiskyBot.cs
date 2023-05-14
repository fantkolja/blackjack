using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
  internal class RiskyBot : Bot
  {
    public RiskyBot()
    {
      this.Name = botNames[1];
    }

        public override bool ConfirmNextDraw(int currentSum)
        {
            if (currentSum > 19) return false;
            return true;
        }

    public override string Assessment(bool botWin)
    {
      if (botWin) return $"[{this.Name}] : I like this game!";
      return $"[{this.Name}] : Oh... Next time i will play more cautiously.";
    }
  }
}
