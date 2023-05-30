using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.blackjack.Game
{
    public class RiskyStrategy : IStrategy
    {
        private readonly IBlackjackGame blackjackGame;

        public RiskyStrategy(IBlackjackGame game)
        {
            blackjackGame = game;
        }

        public void MakeMove()
        {
            if (blackjackGame.GetTotalPoints() >= 19)
            {
                blackjackGame.Stand();
            }
            else
            {
                blackjackGame.Hit();
            }
        }
    }
}
