namespace BlackJack
{
    abstract class Player : IStrategy
    {
        public string? Name { get; set; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        protected IObserver? _scoreLimitReach;

        public abstract bool ConfirmNextDraw();
        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);
            if (GetCurrentScore() > 21)
            {
                _scoreLimitReach?.Update($"Player <<{Name}>> reached a score limit.");
            }
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
            return card;
        }

        public int GetCurrentScore()
        {
            return PointsCounter.CountSum(this.DrawnCards!);
        }
    }
}