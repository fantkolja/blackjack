using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class AnalyticsObserver : IPointsObserver
    {
        private readonly string _filePath;

        public AnalyticsObserver(string filePath)
        {
            _filePath = filePath;
        }

        public void Update(int points)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(points);
            }
        }

        public double GetAveragePoints()
        {
            List<int> pointsList = new List<int>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int points;
                    if (int.TryParse(line, out points))
                    {
                        pointsList.Add(points);
                    }
                }
            }

            if (pointsList.Count == 0)
            {
                return 0;
            }

            return pointsList.Average();
        }
    }
}
