using blackjack.Game.Strategy;

namespace BlackJack
{
  class Player
  {
    public string Name { get; }
    public IStrategy Strategy { get; set; }
    public List<Card> DrawnCards { get; } = new List<Card>();
    public Player(string name)
    {
      this.Name = name;
    }
    public bool ConfirmNextDraw()
    {
        if (this is IBotPlayer botPlayer)
        {
            return botPlayer.Strategy.RequestNextDraw(this.DrawnCards);
        }
        else
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }
    }
    public Card DrawCard(CardsDeck cardsDeck)
    {
      Card card = cardsDeck.Draw();
      this.DrawnCards.Add(card);
      Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
      return card;
    }
  }
}