using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class ChooserCurrentMode
    {
        private Mode _mode = null;

        public void setCurrentMode(Mode mode)
        {
            _mode = mode;
        }

        public List<Player> CreatePlayers()
        {
            return _mode.CreatePlayers();
        }
    }
}
