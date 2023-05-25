using blackjack.Game.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class RandomAI : AI
    {
        public RandomAI() : base()
        {
            Name = $"AI#{_Id}";
            _scoreOverflowObserver = new ScoreOverflowObserver();
        }

        public override bool ConfirmNextDraw()
        {
            Random random = new Random();
            return random.Next(0, 100) < 80;
        }
    }
}
