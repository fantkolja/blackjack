namespace BlackJack
{
    public class AnalyticsService
    {
        private static int totalPoints = 0;
        private static int roundsPlayed = 0;
        private static int busts = 0;

        public static void AddRoundPoints(int points)
        {
            totalPoints += points;
            roundsPlayed++;
            if (points > 21)
            {
                busts++;
            }
        }

        public static void AddRoundPointsBusts(int points)
        {
            if (points > 21)
            {
                busts++;
            }
        }

        public static void WriteToFile(string filePath)
        {
            double averagePoints = (double)totalPoints / roundsPlayed;
            File.WriteAllText(filePath, $"Average points per round: {averagePoints}\nNumber of busts: {busts}");
        }
    }
}
