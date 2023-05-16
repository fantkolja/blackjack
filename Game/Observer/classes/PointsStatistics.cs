using BlackJack.Interfaces;

namespace BlackJack.Classes
{
    public class PointsStatistics : IObserver
    {
        private readonly string _filePath;
        private int _totalPointsCount;
        private int _gamesPlayedCount;

        public PointsStatistics(string filePath)
        {
            _filePath = filePath;
            _totalPointsCount = 0;
            _gamesPlayedCount = 0;
        }

        public void Update(string message)
        {
            _totalPointsCount += int.Parse(message);
            _gamesPlayedCount++;
            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine($"Average points: {_totalPointsCount / (double)_gamesPlayedCount}");
            }
        }
    }
}
