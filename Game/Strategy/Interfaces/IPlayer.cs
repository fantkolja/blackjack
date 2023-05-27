using System;
using BlackJack;

namespace blackjack.Strategy.Interfaces
{
	internal interface IPlayer
	{
		public string Name { get; }
		public List<Card> DrawnCards { get; }
		public Card DrawCard(CardsDeck cardsDeck);

		public bool ConfirmNextDraw();
	}
}