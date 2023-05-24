using BlackJack;

namespace blackjack.Game
{
    public class UnpredictableStyle : IPlayingStyle
    {
        private Random _random = new Random();

        public bool ShouldDrawNextCard(List<Card> currentCards)
        {
            return _random.Next(0, 2) == 0;
        }
    }
}
