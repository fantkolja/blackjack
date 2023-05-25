using blackjack.Game.Observer;
using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class CarefulAI : AI
    {
        public CarefulAI() : base()
        {
            Name = $"AI#{_Id}";
            _scoreOverflowObserver = new ScoreOverflowObserver();
        }

        public override bool ConfirmNextDraw()
        {
            return GetCurrentScore() < 13;
        }
    }
}
