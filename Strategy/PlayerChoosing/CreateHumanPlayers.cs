using blackjack.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Strategy.PlayerChoosing;
internal class CreateHumanPlayers : ICreatePlayersStrategy
{
    public List<Player> Create()
    {
        var players = new List<Player>
        {
            ChoosePlayerHelper.CreateHumanPlayer(1),
            ChoosePlayerHelper.CreateHumanPlayer(2),
        };
        return players;
    }
}
