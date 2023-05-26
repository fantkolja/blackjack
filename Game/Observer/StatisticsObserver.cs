using BlackJack;

namespace blackjack.Game.Observer
{
    public class StatisticsObserver : IObserver
    {
        private readonly string FILE_NAME = "GameplayStatistics.txt";
        public void Update(object data)
        {
            List<Player>? players = data as List<Player>;
            if (players == null) return;

            GameplayStatistics gameplayStatistics = new GameplayStatistics();
            try
            {
                string text = File.ReadAllText(FILE_NAME);
                if (text == null || text == "") throw new Exception();
                string[] lines = text.Split("\n");
                if (lines.Length != 3) throw new Exception();
                gameplayStatistics.TotalScore = int.Parse(lines[0].Split(": ")[1]);
                gameplayStatistics.GamesCount = int.Parse(lines[1].Split(": ")[1]);
                gameplayStatistics.AvarageScore = int.Parse(lines[2].Split(": ")[1]);
            }
            catch
            {
                gameplayStatistics = new GameplayStatistics();
            }

            int score = players.Sum(player => PointsCounter.CountSum(player.DrawnCards));
            gameplayStatistics.UpdateStatistics(score);

            var result = $"Total score: {gameplayStatistics.TotalScore}\nGames count: {gameplayStatistics.GamesCount}\nAverage score: {gameplayStatistics.AvarageScore}";
            File.WriteAllText(FILE_NAME, result);
        }
    }
}
