using BlackJack;

namespace blackjack.Game
{
    public interface IPlayingStyle
    {
        bool ShouldDrawNextCard(List<Card> currentCards);
    }
}
