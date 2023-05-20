using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
  internal class RandomBot : Bot
  {
    public RandomBot()
    {
      this.Name = botNames[2];
    }
        public override bool ConfirmNextDraw(int currentSum)
        {
            if (currentSum > 13)
            {
                if (new Random().Next(2) == 0) return true;
                return false;
            }
            return true;
        }

    public override string Assessment(bool botWin)
    {
      if (botWin) return $"[{this.Name}] : The luck is on my side.";
      return $"[{this.Name}] : This time I was unlucky...";
    }
  }
}
