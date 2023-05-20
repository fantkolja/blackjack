using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
  internal class CarefulBot : Bot
  {
    public CarefulBot()
    {
      this.Name = botNames[0];
    }

    public override bool ConfirmNextDraw(int currentSum)
    {
      if (currentSum > 13) return false;
      return true;
    }

    public override string Assessment(bool botWin)
    {
      if (botWin) return $"[{this.Name}] : My tactics bears fruit as well.";
      return $"[{this.Name}] : I am no match for you.";
    }
  }
}
