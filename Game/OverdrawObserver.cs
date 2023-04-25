using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class OverdrawObserver : IPointsObserver
    {
        private readonly string _filePath;

        public OverdrawObserver(string filePath)
        {
            _filePath = filePath;
        }

        public void Update(int points)
        {
            if (points > PointsCounter.MAX_POINTS_COUNT)
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: Points exhausted ({points} points)");
                }
            }
        }
    }
}
