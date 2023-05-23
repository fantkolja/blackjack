using blackjack.Game;

namespace BlackJack
{
  class Player
  {
    public string Name { get; }

    public bool IsBot { get; }

    private ChooserBotType? chooserBot = null;
    public List<Card> DrawnCards { get; } = new List<Card>();
    public Player(string name, bool isBot, ChooserBotType? _chooserBot = null)
    {
            this.Name = name;
            IsBot = isBot;
            if (IsBot) { 
                chooserBot = _chooserBot;
            }
    }
    public bool ConfirmNextDraw(int currentSumPoints)
    {
    if (IsBot)
    {
        return chooserBot.getResultBotType() <= currentSumPoints ? false : true;       
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