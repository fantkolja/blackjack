using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class HumanStrategy : IPlayingStrategy
    {
        public bool ShouldDrawCard(Player player)
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
    }

}
