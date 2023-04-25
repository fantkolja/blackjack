using System;
using blackjack.Strategy.Interfaces;
using blackjack.Strategy.Strategies;
using BlackJack;

namespace blackjack.Strategy
{
    internal class Bot : IPlayer
    {
        private IStrategy _strategy;

        public string Name => "Smart(stupid) bot";

        public List<Card> DrawnCards {get;} = new List<Card>();

        public Bot()
        {
            _strategy = new CarefulStrategy();
        }
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }


        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
			DrawnCards.Add(card);
			Logger.ShowDrawnCard(card, PointsCounter.CountSum(DrawnCards));
			return card;
        }

        public bool ConfirmNextDraw()
        {
            return _strategy.Play(PointsCounter.CountSum(DrawnCards));
        }
    }
}
