using System.Collections.Generic;

namespace BlackJack
{
    class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; private set; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        public Player(string name)
        {
            this.Name = name;
            Hand = new List<Card>();
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
    }
}