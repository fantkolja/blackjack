using BlackJack;
using System.Collections.Generic;

namespace lab_6.blackjack.Game
{
    public class ComputerPlayer : IPlayer
    {
        private IStrategy strategy;
        private IBlackjackGame blackjackGame;

        public ComputerPlayer(IBlackjackGame game)
        {
            blackjackGame = game;
            strategy = new CautiousStrategy(blackjackGame);
        }

        public void SetStrategy(IStrategy newStrategy)
        {
            strategy = newStrategy;
        }

        public void MakeMove()
        {
            strategy.MakeMove();
        }
    }
}
