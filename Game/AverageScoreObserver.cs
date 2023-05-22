using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    class AverageScoreObserver : IObserver
    {
        private int _totalScore = 0;
        private int _playersCount = 0;

        public void Update(Player player)
        {
            _totalScore += PointsCounter.CountSum(player.DrawnCards);
            _playersCount++;

            double averageScore = (double)_totalScore / _playersCount;

            using (StreamWriter sw = new StreamWriter("averageScoreLog.txt", true))
            {
                sw.WriteLine($"{DateTime.Now}: Середня кількість очок наразі складає {averageScore}");
            }
        }
    }
}
