using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

namespace blackjack.Game.Strategy
{
    internal class Context
    {
      public Bot? bot { get; private set; }

      public void SetBot(Bot bot)
      {
        this.bot = bot;
      }

      public void Unset()
      {
        this.bot = null;
      }

       public void BotAssessment(bool botWin)
       {
          if (bot != null) Logger.BotLog(bot.Assessment(botWin));
       }
    }
}
