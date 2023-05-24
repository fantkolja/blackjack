using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class WithPlayerMode : Mode
    {
        public List<Player> CreatePlayers()
        {
            var players = new List<Player>();
            for (int i = 1; i <= 2; i++)
            {
                string defaultName = $"Player {i}";
                string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                players.Add(new Player(name, false));
            }
            return players;
        }
    }
}
