using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    internal class PointsObserver : IObserver
    {
        public string FilePath { get; set; }
        public PointsObserver(string filePath)
        {
            FilePath = filePath;
        }
        public void Update(object data)
        {
            Player player = (Player)data;
            int points = PointsCounter.CountSum(player.DrawnCards);
            if (points > 21)
            {
                File.AppendAllText(FilePath, $"{DateTime.Now} | {player.Name} - {points} points" + Environment.NewLine);
            }
        }
    }
}
