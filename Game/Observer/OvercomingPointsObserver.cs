using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class OvercomingPointsObserver : IObserver
    {
        public string FilePath { get; set; }

        public OvercomingPointsObserver(string filePath)
        {
            this.FilePath = filePath;
        }

        public void Update(object data)
        {
            List<Player> players = (List<Player>)data;
            List<Player> playersWithOvercomingPoints = players.Where(player => PointsCounter.CountSum(player.DrawnCards) > PointsCounter.MAX_POINTS_COUNT).ToList();

            if (playersWithOvercomingPoints.Count > 0)
            {
                List<string> lines = playersWithOvercomingPoints.Select(player => $"{player.Name} has overcome 21 points.").ToList();
                File.AppendAllLines(this.FilePath, lines);
            }
        }
    }

}
