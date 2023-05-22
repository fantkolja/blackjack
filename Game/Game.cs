namespace BlackJack
{
  class Game
  {
    public int PLAYER_COUNT = 2;
    public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
    private GameState _state = new GameState();
    private ComputerPlayer.IOpponentStrategy _opponentStrategy;
    private ComputerPlayer.IComputerPlayerStrategy _computerPlayerStrategy;

    public Game(ComputerPlayer.IOpponentStrategy opponentStrategy, ComputerPlayer.IComputerPlayerStrategy computerPlayerStrategy)
    {
      _opponentStrategy = opponentStrategy;
      _computerPlayerStrategy = computerPlayerStrategy;
    }
    private List<Player> _createPlayers()
    {
      var players = new List<Player>();
      Console.WriteLine($"Do you want to play with bot?");
      char tempp = Console.ReadKey().KeyChar;
      if (tempp == 'y')
      {
        PLAYER_COUNT = 1;
      }
      for (int i = 1; i < PLAYER_COUNT; i++)
      {
        string defaultName = $"Player {i}";
        string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
        players.Add(new Player(name));
      }
      return players;
    }
        public void ChooseOpponent(Player player)
        {
            Player opponent = _opponentStrategy.ChooseOpponent(this._state._players);
            // ...
        }
    private void _greet()
    {
      Logger.Greet();
    }
    private void _initiateState()
    {
      this._state.SetPlayers(this._createPlayers());
    }
    public void Start()
    {
      this._greet();
      this._initiateState();
      do
      {
        if (this._state.ActivePlayer == null)
        {
          throw new Exception("No active player detected!");          
        }
        this.HandlePlayer(this._state.ActivePlayer);
      }
      while(this._state.SwitchPlayer());
      this.End();
    }

    public void End()
    {
      List<Player> winners = this._state.GetWinners();
      Logger.EndGame(winners);
    }

    public void HandlePlayer(Player player)
    {
      Logger.StartPlayersTurn(player.Name);
      for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
      {
        player.DrawCard(this._state.Deck);
      }
      while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw())
      {
        player.DrawCard(this._state.Deck);
        _computerPlayerStrategy.ShouldDrawNextCard(player.DrawnCards);
        player.DrawCard(this._state.Deck);
      }
    }
  }
}