using blackjack.Game;
using blackjack.Game.Observer;
using System;

namespace BlackJack
{
    class LocalPlayer : Player
    {
        public LocalPlayer(string name)
        {
           Name = name;
           _scoreOverflowObserver = new ScoreOverflowObserver();
        }

        public override bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
    }
}