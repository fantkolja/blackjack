namespace blackjack.Strategy.PlayerChoosing;
using blackjack.Game;
using BlackJack;

internal class CreateHumanBotPlayers : ICreatePlayersStrategy
{
    public List<Player> Create()
    {
        var botPlayer = InputHandler.ChooseBootPlayer();
        var players = new List<Player>
            {
                ChoosePlayerHelper.CreateHumanPlayer(1),
                ChoosePlayerHelper.CreateBotPlayer(botPlayer),
            };
        return players;
    }
}
