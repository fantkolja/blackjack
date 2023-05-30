using System.IO;

namespace lab_6.blackjack.Game
{
    public class AnalyticsService : IBlackjackGameObserver
    {
        private string logFilePath;
        private int totalScore;
        private int gameCount;

        public AnalyticsService(string logFilePath)
        {
            this.logFilePath = logFilePath;
            totalScore = 0;
            gameCount = 0;
        }

        public void Update(string eventInfo)
        {
            // Підрахунок очків гравця після кожного ходу
            if (eventInfo.StartsWith("Player score:"))
            {
                int score = int.Parse(eventInfo.Split(':')[1].Trim());
                totalScore += score;
                gameCount++;
            }
        }

        public void GenerateAnalyticsReport()
        {
            int averageScore = totalScore / gameCount;

            // Запис середньої кількості очків в файл
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Average score: {averageScore}");
            }
        }
    }

}
