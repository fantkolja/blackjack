using BlackJack;


namespace blackjack.Strategy.DrowConfirmation;
internal class CarefulDrawConfirmationStrategy : IDrawConfirmationStrategy
{
    public bool ConfirmNextDraw(List<Card> drawnCards)
    {
        return PointsCounter.CountSum(drawnCards) < 13;
    }
}
