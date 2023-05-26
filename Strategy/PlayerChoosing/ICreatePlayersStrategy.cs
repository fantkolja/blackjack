namespace blackjack.Strategy.PlayerChoosing;

using Game;

internal interface ICreatePlayersStrategy
{
    public List<Player> Create();
}