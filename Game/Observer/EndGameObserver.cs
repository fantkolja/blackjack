using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class EndGameObserver : IObserver
    {
        private readonly string FILE_NAME = "EndGames.txt";
        public void Update(object data)
        {
            List<Player>? list = data as List<Player>;
            if (list == null) return;
            foreach (var player in list)
            {
                if (player == null) continue;
                int score = PointsCounter.CountSum(player.DrawnCards);
                if (score <= 21) continue;
                File.AppendAllText(FILE_NAME, $"[{DateTime.Now}] Player {player.Name} - {score}\n");
            }
        }
    }
}
