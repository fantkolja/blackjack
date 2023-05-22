using blackjack.Game;

namespace BlackJack
{
    class Player
    {
        public string Name { get; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        private List<IObserver> _observers = new List<IObserver>();
        public Player(string name)
        {
            this.Name = name;
        }
        public bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
        

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }

            return card;
        }
    }
}