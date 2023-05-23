using blackjack.Game.Observer;

namespace BlackJack
{
  class Player
  {
    public string Name { get; }
    public List<Card> DrawnCards { get; } = new List<Card>();
    public Player(string name)
    {
      this.Name = name;
    }
    public bool ConfirmNextDraw()
    {
      return InputHandler.Confirm("Do you want to draw next card?");
    }
    public GameSubject DrawCardSubject { get; } = new GameSubject();
    public Card DrawCard(CardsDeck cardsDeck)
    {
        Card card = cardsDeck.Draw();
        this.DrawnCards.Add(card);
        DrawCardSubject.Notify(this);  // Notify the observers
        Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
        return card;
    }
  }
}