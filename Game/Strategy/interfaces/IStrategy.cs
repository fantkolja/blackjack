using BlackJack;

namespace BlackJack.Interfaces
{
    public interface IStrategy
    {
        void Play(Player player, GameState state);
    }
}
