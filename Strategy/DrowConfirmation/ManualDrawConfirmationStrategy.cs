using BlackJack;

namespace blackjack.Strategy.DrowConfirmation;
internal class ManualDrawConfirmationStrategy : IDrawConfirmationStrategy
{
    public bool ConfirmNextDraw(List<Card> drawnCards)
    {
        return InputHandler.Confirm("Do you want to draw next card?");
    }
}
