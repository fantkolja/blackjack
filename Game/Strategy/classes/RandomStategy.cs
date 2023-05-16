using BlackJack;
using BlackJack.Interfaces;

namespace BlackJack.Classes
{
    public class RandomStrategy : IStrategy
    {
        public void Play(Player player, GameState state)
        {
            Random random = new Random();
            int playerPoints = PointsCounter.CountSum(player.DrawnCards);
            while (playerPoints < 21 && player.ConfirmNextDraw())
            {
                if (playerPoints > 17 && random.NextDouble() < 0.5)
                    break;
                
                player.DrawCard(state.Deck);
                playerPoints = PointsCounter.CountSum(player.DrawnCards);
            }
        }
    }
}
