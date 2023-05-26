namespace BlackJack
{
    class OverDrawEventListener : IEventListener
    {

        public void Update(List<Card> cards, int totalPointsCount, Player player)
        {

            if (totalPointsCount <= PointsCounter.MAX_POINTS_COUNT)
            {
                return;
            }

            string pathName = @"c:\temp\MyTest.txt";

                
            // Create a file to write to.
            using (StreamWriter sw = File.AppendText(pathName))
            {
                // Generates list of strings like this:
                // 1) Three of Spades
                // 2) King of Hearts
                IEnumerable<String> cardNames = cards.Select(card => card.Name + " of " + card.Suit.Name);

                // Converts list of string into a string separated with coma
                // Three of Spades, King of Hearts
                string cardString = String.Join(", ", cardNames);

                sw.WriteLine($"{player.Name} gets {totalPointsCount} points with cards {cardString}");
            }

        }

        
    }
}