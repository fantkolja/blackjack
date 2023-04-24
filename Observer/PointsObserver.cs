using System;
using BlackJack;

namespace blackjack.Observer
{
    public class PointsObserver : IObserver
    {
        private string _path = Directory.GetCurrentDirectory() + "/PointsState.txt";
        public void Update(ISubject subject)
        {
            var player = ((Player)subject);
			int points = PointsCounter.CountSum(player.DrawnCards);
            if (points > 21)
            {
                string msg = $"Overcounting[{DateTime.Now}]! Player: {player.Name}, Points: {points}\n";
                File.AppendAllText(_path, msg);
            }

        }
    }
}
