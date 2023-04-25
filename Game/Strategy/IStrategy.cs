namespace blackjack.Game.Strategy
{
    public interface IStrategy
    {
        bool DecideMove(int currentPoints);
    }
}