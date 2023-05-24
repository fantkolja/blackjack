using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal interface Mode
    {
        public List<Player> CreatePlayers();
    }
}
