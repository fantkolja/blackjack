using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    public enum GameMode
    {
        WithAI = 1,
        MultiPlayer = 2
    }

    public enum GameAI
    {
        Careful = 1,
        Risky = 2,
        Random = 3
    }
}
