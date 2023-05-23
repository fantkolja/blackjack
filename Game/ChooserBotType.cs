using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class ChooserBotType
    {
        private BotType botType;

        public void setBotType(BotType _botType)
        {
            botType = _botType;
        }

        public int getResultBotType() { 
            return botType.GetMaxRiskPoints();
        }
    }
}
