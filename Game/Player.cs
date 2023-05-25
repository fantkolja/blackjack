using blackjack.Game.Observer;
using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    public abstract class Player
    {
        public string? Name { get; set; }
        public List<Card> DrawnCards { get; set; } = new List<Card>();
        protected IObserver? _scoreOverflowObserver;

        public abstract bool ConfirmNextDraw();

        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);

            int countSum = GetCurrentScore();

            if (countSum > 21)
            {
                _scoreOverflowObserver?.Update($"Player '{Name}' had a scoreoverflow on {DateTime.Now}");
            }

            Logger.ShowDrawnCard(card, countSum);


            return card;
        }

        public int GetCurrentScore()
        {
            return PointsCounter.CountSum(this.DrawnCards!);
        }
    }
}
