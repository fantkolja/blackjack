using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    static class BetHandler
    {
        public static int RequestBet(Player player)
        {
            return InputHandler.RequestNumber("Place your bet: ", 1, player.Money);
        }
    }
}
