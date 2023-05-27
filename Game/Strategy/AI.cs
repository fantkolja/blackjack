namespace BlackJack
{
    abstract class AI : Player
    {
        public AI()
        {
            Name = $"Computer";
            _scoreLimitReach = new ScoreLimitReachObserver();
        }
    }
}
