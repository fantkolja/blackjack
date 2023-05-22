using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class GamePoints
    {
        public int TotalPoints { get; set; }
        public float AvgPoints => TotalPoints / GamesCount;
        public int GamesCount { get; set; }

        public void AddPoints(int points)
        {
            GamesCount++;
            TotalPoints += points;
        }
    }
}
