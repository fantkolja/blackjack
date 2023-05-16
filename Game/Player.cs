using BlackJack.CardDeck;
using BlackJack.Interfaces;
namespace BlackJack
{
    public class Player
    {
        public string Name { get; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        public IStrategy Strategy { get; set; }
        public Player(string name, IStrategy strategy)
        {
            this.Name = name;
            Strategy = strategy;
        }
        public bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
            return card;
        }
        public void Play(GameState state)
        {
            this.Strategy.Play(this, state);
        }
    }
}
