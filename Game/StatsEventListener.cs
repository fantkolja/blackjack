namespace BlackJack
{
    class StatsEventListener : IEventListener
    {
        private int players;
        
        private int points;

        public void Update(List<Card> cards, int totalPointsCount, Player player)
        {

            players++;

            points += totalPointsCount;

            string pathName = @"c:\temp\stats.txt";

            double averagePoints = points / (double)players;

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(pathName))
            {
                sw.WriteLine($"Players: {players}. Average points: {averagePoints}");
            }

        }


    }
}