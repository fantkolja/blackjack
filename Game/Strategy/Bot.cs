using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//I use this class instead of IStrategy (the Assessment method is method from the pattern).
//I implemented IParticipant at first, but then i realised that i didn't need a Context to introduce the required functionality.
//So then i added the method above to show how the Context works,
//but it is still redundand as we don't need to change the bot's behaviour during the game
//and we create a new Game instance every time we play again.
namespace blackjack.Game.Strategy
{
    internal class Bot : IParticipant
    {
        public string Name { get; protected set; } = "Bot";
        public List<Card> DrawnCards { get; } = new List<Card>();

        public virtual bool ConfirmNextDraw(int currentSum)
        {
          throw new NotImplementedException();
        }

        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
            return card;
        }

    public virtual string Assessment(bool botWin)
    {
      throw new NotImplementedException();
    }

    public readonly string[] botNames = new string[]
    {
            "CarefulBot",
            "RiskyBot",
            "RandomBot"
    };
  }
}
