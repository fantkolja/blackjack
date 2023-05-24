using blackjack.Game.Observer;
using System;

namespace BlackJack
{
    class Player
    {
        public string Name { get; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        private IObserver _scoreOverflowObserver;

        public Player(string name)
        {
            this.Name = name;
            this._scoreOverflowObserver = new ScoreOverflowObserver();
        }

        public bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }

        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);

            int countSum = GetCurrentScore();

            if(countSum > 21)
            {
                _scoreOverflowObserver.Update($"Player '{Name}' had a scoreoverflow on {DateTime.Now}");
            }

            Logger.ShowDrawnCard(card, countSum);


            return card;
        }

        public int GetCurrentScore()
        {
            return PointsCounter.CountSum(this.DrawnCards);
        }
    }
}