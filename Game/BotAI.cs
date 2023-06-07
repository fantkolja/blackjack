namespace BlackJack
{
    interface IComputerPlayerStrategy
    {
        string Name { get; }
        bool ShouldDrawNextCard(List<Card> cards);
    }   
    class CautiousStrategy : IComputerPlayerStrategy
    {
        public string Name => "Cautious";
        public bool ShouldDrawNextCard(List<Card> cards)
        {
            return PointsCounter.CountSum(cards) < 13;
        }
    }   
    class RiskyStrategy : IComputerPlayerStrategy
    {
        public string Name => "Risky";
        public bool ShouldDrawNextCard(List<Card> cards)
        {
            return PointsCounter.CountSum(cards) < 19;
        }
    }   
    class RandomStrategy : IComputerPlayerStrategy
    {
        public string Name => "Random";
        private Random _random = new Random();  
        public bool ShouldDrawNextCard(List<Card> cards)
        {
            return _random.Next(0, 2) == 0;
        }
    }   
    class ComputerPlayer : Player
    {
        private IComputerPlayerStrategy _strategy;  
        public ComputerPlayer(string name, IComputerPlayerStrategy strategy) : base(name)
        {
            _strategy = strategy;
        }   
        public override bool ConfirmNextDraw()
        {
            return _strategy.ShouldDrawNextCard(this.DrawnCards);
        }
    }
}