using blackjack.Game.Observer;

namespace BlackJack
{
  class Player
  {
    private Subject subject = InitManager.GetNewSubject();
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
    public Card DrawCard(CardsDeck cardsDeck)
    {
      Card card = cardsDeck.Draw();
      this.DrawnCards.Add(card);
      subject.Notify(PointsCounter._cardValueMap[card.Name]);
      Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
      return card;
    }
  }
}