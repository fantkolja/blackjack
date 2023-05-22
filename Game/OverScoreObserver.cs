using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    class OverScoreObserver : IObserver
    {
        public void Update(Player player)
        {
            if (PointsCounter.CountSum(player.DrawnCards) > 21)
            {
                using (StreamWriter sw = new StreamWriter("overScoreLog.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now}: Гравець {player.Name} перебрав 21 очко");
                }
            }
        }
    }
}
