namespace lab_6.blackjack.Game
{
    public interface IBlackjackGame
    {
        void AddPlayer(IPlayer player);
        void RemovePlayer(IPlayer player);
        void AddObserver(IBlackjackGameObserver observer);
        void RemoveObserver(IBlackjackGameObserver observer);
        void Hit();
        void Stand();
        void EndGame();
        int GetTotalPoints();
    }

}
