using BlackJack;


namespace blackjack.Strategy.DrowConfirmation;
internal class RiskyDrawConfirmationStrategy : IDrawConfirmationStrategy
{
    public bool ConfirmNextDraw(List<Card> drawnCards)
    {
        return PointsCounter.CountSum(drawnCards) < 19;
    }
}
