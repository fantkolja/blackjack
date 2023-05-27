using System;
using BlackJack;

namespace blackjack.Observer
{
    internal class AveragePointInfo
    {
        public int gameCount { get; set; } = 0;

        public int CurrentPoints { get; set; }

        public DateTime LastUpdated { get; set; }

        public double Average { get; set; }


        private void CalculateAverage()
        {
            Average = CurrentPoints / gameCount;
        }
        public void Update(int points)
        {
            gameCount++;
            CurrentPoints += points;
            LastUpdated = DateTime.Now;
            CalculateAverage();
        }
    }
}