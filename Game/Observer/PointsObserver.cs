using System;
using BlackJack;

namespace blackjack.Observer
{
    public class PointsObserver : IObserver
    {
        private string _path = Directory.GetCurrentDirectory() + "/PointsState.txt";
        public async void Update(ISubject subject)
        {
            var players = ((GameState)subject).Players;

            foreach (var player in players)
            {
                int points = PointsCounter.CountSum(player.DrawnCards);
                if (points > 21)
                {
                    string msg = $"Overcounting [ {DateTime.Now} ]! Player: {player.Name}, Points: {points}\n";
                    await File.AppendAllTextAsync(_path, msg);
                }
            }

        }
    }
}