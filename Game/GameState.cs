using blackjack.Game;

namespace BlackJack
{
  class GameState
  {
    private List<IParticipant> _players = new List<IParticipant>();
    public CardsDeck Deck { get; } = new CardsDeck();
    public IParticipant? ActivePlayer { get; private set; }

    public List<IParticipant> GetWinners()
    {
      return this._players.Aggregate(new List<IParticipant>(), (List<IParticipant> winners, IParticipant next) => {
        int? nextPlayerPointsCount = PointsCounter.CountWinningPoints(next.DrawnCards);
        int? currentWinningPoints = winners.Count > 0 ? PointsCounter.CountWinningPoints(winners[0].DrawnCards) : null;
        if (nextPlayerPointsCount is int)
        {
          // if there is no winner yet
          if (currentWinningPoints == null)
          {
            winners.Add(next);
          }
          // if the points count is the same
          if (nextPlayerPointsCount == currentWinningPoints)
          {
            winners.Add(next);
          }
          // if next player has more points
          if (nextPlayerPointsCount > currentWinningPoints)
          {
            winners.Clear();
            winners.Add(next);
          }
        }
        return winners;
      });
    }

    public List<IParticipant> GetParticipants()
    {
      return this._players;
    }

    public void SetPlayers(List<IParticipant> players)
    {
      this._players.AddRange(players);
      this.ActivePlayer = this._players[0];
    }

    public bool SwitchPlayer()
    {
      bool hasSwitchedToNewPlayer = false;
      int activePlayerIndex = this.ActivePlayer == null ? -1 : this._players.IndexOf(this.ActivePlayer);
      if (activePlayerIndex > -1 && activePlayerIndex < this._players.Count - 1)
      {
        this.ActivePlayer = this._players[++activePlayerIndex];
        Logger.ShowPlayerSwitchMessage(this.ActivePlayer.Name);
        hasSwitchedToNewPlayer = true;
      }
      return hasSwitchedToNewPlayer;
    }
  }
}