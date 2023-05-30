using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.blackjack.Game
{
    public class RandomStrategy : IStrategy
    {
        private readonly IBlackjackGame blackjackGame;

        public RandomStrategy(IBlackjackGame game)
        {
            blackjackGame = game;
        }

        public void MakeMove()
        {
            Random random = new Random();
            int decision = random.Next(2); 

            if (decision == 0)
            {
                blackjackGame.Hit();
            }
            else
            {
                blackjackGame.Stand();
            }
        }
    }
}
