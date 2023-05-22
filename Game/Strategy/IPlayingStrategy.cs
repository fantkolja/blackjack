using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    interface IPlayingStrategy
    {
        bool ShouldDrawCard(Player player);
    }
}
