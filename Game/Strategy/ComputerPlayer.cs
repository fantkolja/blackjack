using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class ComputerPlayer : Player
    {
        private IStrategy _strategy;

        public ComputerPlayer(string name, IStrategy strategy) : base(name)
        {
            _strategy = strategy;
        }

        public bool ConfirmNextDraw(List<Card> drawnCards)
        {
            return _strategy.ConfirmNextDraw(drawnCards);
        }
    }
}
