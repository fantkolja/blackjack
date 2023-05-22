using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    interface IPlayer
    {
        public string Name { get; }
        public bool ConfirmNextDraw();
        public Card DrawCard(CardsDeck cardsDeck);
    }
}
