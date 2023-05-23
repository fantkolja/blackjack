using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    class AveragePointsObserver : IObserver
    {
        public string FilePath { get; set; }

        public AveragePointsObserver(string filePath)
        {
            FilePath = filePath;
        }

        public void Update(object data)
        {
            List<Player> players = (List<Player>)data;
            int sum = 0;

            try
            {
                foreach (Player player in players)
                {
                    sum += PointsCounter.CountSum(player.DrawnCards);
                }
                File.AppendAllLines(this.FilePath, new string[] { $"Average points: {sum / players.Count}" + Environment.NewLine });
            }
            catch (DivideByZeroException)
            {
                File.AppendAllLines(this.FilePath, new string[] { $"Average points: 0" + Environment.NewLine });
            }
        }
    }
}
