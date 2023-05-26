using BlackJack;

namespace blackjack.Strategy.DrowConfirmation;
internal interface IDrawConfirmationStrategy
{
    public bool ConfirmNextDraw(List<Card> drawnCards);
}
