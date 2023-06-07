namespace BlackJack
{
  class Game
  {
    public static readonly int PLAYER_COUNT = 2;
    public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
    private GameState _state = new GameState();
    private List<Player> _createPlayers()
    {
        var players = new List<Player>();

        if(InputHandler.Confirm("Do you want to play with bot?"))
        {
          // Create human player
          string defaultName = "Player 1";
          string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
          players.Add(new Player(name));

          // Create computer player
          IComputerPlayerStrategy strategy = ChooseRandomStrategy();
          players.Add(new ComputerPlayer("Computer Character", strategy));
          Logger.Log($"Computer player strategy: {strategy.Name}");
        }
        else{
          // Create human players
          for (int i = 1; i <= PLAYER_COUNT; i++)
          {
            string defaultName = $"Player {i}";
            string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
            players.Add(new Player(name));
          }
        }
        return players;
    }

    private IComputerPlayerStrategy ChooseRandomStrategy()
    {
      var strategies = new List<IComputerPlayerStrategy> { new RiskyStrategy(), new CautiousStrategy(), new RandomStrategy() };
      var random = new Random();
      int index = random.Next(strategies.Count);
      return strategies[index];
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
      }
    }
  }
}