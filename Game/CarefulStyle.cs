using BlackJack;

namespace blackjack.Game
{
    public class CarefulStyle : IPlayingStyle
    {
        public bool ShouldDrawNextCard(List<Card> currentCards)
        {
            return PointsCounter.CountSum(currentCards) < 13;
        }
    }
}
