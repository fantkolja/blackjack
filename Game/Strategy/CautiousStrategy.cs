using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    class CautiousStrategy : IPlayingStrategy
    {
        public bool ShouldDrawCard(Player? player)
        {
            return PointsCounter.CountSum(player.DrawnCards) < 13;
        }
    }
}
