using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal interface GameObserver
    {
        public void WriteExaggerate(Player player, int sum);

        public void WriteAnalytics(float sum);
    }
}
