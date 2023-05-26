
namespace BlackJack
{
    interface IEventListener
    {
        public void Update(List<Card> cards, int totalPointsCount, Player player);
    }
}
