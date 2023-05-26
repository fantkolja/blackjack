namespace blackjack.Strategy.DrowConfirmation;

using BlackJack;
using System.Collections.Generic;

internal class RandomDrawConfirmationStrategy : IDrawConfirmationStrategy
{
    public bool ConfirmNextDraw(List<Card> drawnCards)
    {
        return PointsCounter.CountSum(drawnCards) < RandomNumberGenerator.GenerateRandomNumber();
    }
}
