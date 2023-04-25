using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public interface IPointsObserver
    {
        void Update(int points);
    }
}
