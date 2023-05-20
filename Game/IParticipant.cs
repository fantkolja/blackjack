using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
  internal interface IParticipant
  {
    public string Name { get; }
    public List<Card> DrawnCards { get; }

    public bool ConfirmNextDraw(int currentSum);
    public Card DrawCard(CardsDeck cardsDeck);
  }
}
