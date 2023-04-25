using System;
using BlackJack;

namespace blackjack.Observer.Utils
{
    internal class AveragePointInfo
    {
        public int OveralGameCount { get; set; } = 0;

        public int CurrentPoints { get; set; }

        public DateTime LastUpdate { get; set; }

        public double Average { get; private set; }


        private void CalculateAverage()
        {
            Average = CurrentPoints / OveralGameCount;
        }
        public void Update(int points)
        {
            CurrentPoints += points;
            OveralGameCount++;
            LastUpdate = DateTime.Now;
            CalculateAverage();
        }
    }
}
