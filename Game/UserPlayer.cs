using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class UserPlayer : Player
    {
        public UserPlayer(string name)
        {
            Name = name;
            _scoreLimitReach = new ScoreLimitReachObserver();
        }

        public override bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
    }
}
