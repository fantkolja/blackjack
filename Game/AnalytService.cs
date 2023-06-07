namespace BlackJack
{
  static class AnalytService
  {
        private static int TotalPoints { get; set; } = 0;
        private static int RoundsPlayed { get; set; } = 0;
        private static int Busts { get; set; } = 0;

        public static void AddRoundPoints(int points)
        {
            TotalPoints += points;
            RoundsPlayed++;
        }

        public static void AddRoundPointsBusts(int points)
        {
            if (points > 21)
            {
                Busts++;
            }
        }

        public static void WriteFile(string filePath)
        {
            double averagePoints = (double)TotalPoints / RoundsPlayed;
            File.WriteAllText(filePath, $"Average number of points: {averagePoints}\nCount of busts: {Busts}");
        }
  }
}