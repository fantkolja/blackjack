using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.blackjack.Game
{
    public class CautiousStrategy : IStrategy
    {
        private readonly IBlackjackGame blackjackGame;

        public CautiousStrategy(IBlackjackGame game)
        {
            blackjackGame = game;
        }

        public void MakeMove()
        {
            // Логіка ходу з обережною стратегією
            // Комп'ютерний гравець буде зупинятися після набору 13 або більше очок
            if (blackjackGame.GetTotalPoints() >= 13)
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
