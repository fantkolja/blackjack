using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class GameplayStatistics
    {
        public int TotalScore;
        public int GamesCount;
        public int AvarageScore;

        public GameplayStatistics()
        {
            TotalScore = 0;
            GamesCount = 0;
            AvarageScore = 0;
        }

        public void UpdateStatistics(int score)
        {
            TotalScore += score;
            GamesCount++;
            AvarageScore = TotalScore / GamesCount;
        }
    }
}
