using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Strategy.PlayerChoosing;

using Game;

internal class BotType
{
    public string Name { get; set; }
    public Func<Player> GetPLayer { get; set; }
}
