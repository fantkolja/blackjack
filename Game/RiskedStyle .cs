using BlackJack;

namespace blackjack.Game
{
    public class RiskedStyle : IPlayingStyle
    {
        public bool ShouldDrawNextCard(List<Card> currentCards)
        {
            return PointsCounter.CountSum(currentCards) < 19;
        }
    }
}
