using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    internal class AveragePointsObserver : IObserver
    {
        public string FilePath { get; set; }
        public AveragePointsObserver(string filePath)
        {
            FilePath = filePath;
        }
        public void Update(object data)
        {
            List<Player> players = (List<Player>)data;
            GamePoints gamePoints;
            try
            {
                var saved = File.ReadAllText(FilePath);
                gamePoints = JsonSerializer.Deserialize<GamePoints>(saved) ?? new GamePoints();

            }
            catch (Exception)
            {
                gamePoints = new GamePoints();
            }
            int points = players.Sum(player => PointsCounter.CountSum(player.DrawnCards));
            gamePoints.AddPoints(points);
            var fileContent = JsonSerializer.Serialize(gamePoints, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(FilePath, fileContent);
        }
    }
}
