using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class WithBotMode : Mode
    {
        private ChooserBotType choice = new ChooserBotType();
        public List<Player> CreatePlayers()
        {
            var players = new List<Player>();

            string defaultName = $"Player ";
            string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
            players.Add(new Player(name, false));
            Console.WriteLine("Choose type of bot:\n1.Careful\n2.Risky\n3.Random");
            switch (Console.ReadLine())
            {
                case "1": choice.setBotType(new CarefulBot()); 
                    break;
                case "2":choice.setBotType(new RiskyBot());
                    break;
                case "3":choice.setBotType(new RandomBot());
                    break;
            }
            players.Add(new Player("Bot", true, choice));

            return players;
        }
    }
}
