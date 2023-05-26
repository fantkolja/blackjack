namespace blackjack.Strategy.PlayerChoosing;

using System.Runtime.CompilerServices;
using BlackJack;
using DrowConfirmation;
using Game;

static class ChoosePlayerHelper
{
    public static List<BotType> Bots = new List<BotType>
    {
        new BotType
        {
            Name = "Careful",
            GetPLayer = () => new Player("Bot", new CarefulDrawConfirmationStrategy())
        },
        new BotType
        {
            Name = "Risky",
            GetPLayer = () => new Player("Bot", new RiskyDrawConfirmationStrategy())
        },
        new BotType
        {
            Name = "Random",
            GetPLayer = () => new Player("Bot", new RandomDrawConfirmationStrategy())
        },
    };

    public static Player CreateHumanPlayer(int i)
    {
        string defaultName = $"Player {i}";
        string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
        return new Player(name, new ManualDrawConfirmationStrategy());
    }

    public static Player CreateBotPlayer(int i)
    {
        return Bots[i].GetPLayer.Invoke();
    }
}
