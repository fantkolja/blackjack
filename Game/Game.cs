namespace BlackJack
{
  class Game
  {
    public static readonly int PLAYER_COUNT = 3;
    public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
    private GameState _state = new GameState();

    private List<IEventListener> eventListeners = new List<IEventListener>();

    private List<IStrategy> strategies = new List<IStrategy>();       

    private List<Player> _createPlayers()
    {
      var players = new List<Player>();

      for (int i = 1; i <= PLAYER_COUNT; i++)
      {
        string defaultName = $"Player {i}";
        string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);

        IStrategy strategy;

        //обирається стратегія для кожного ігрока
        int? numOfStrategy = this._chooseStrategy(name);

        if(numOfStrategy == 1)
        {
            strategy = new PersonStrategy();
        } 
        else if(numOfStrategy == 2)
        {
            strategy = new CarefulStrategy();
        } 
        else if(numOfStrategy == 3)
        {
            strategy = new RiskStrategy();
        } 
        else
        {
          strategy = new RandomStrategy();
        }

        players.Add(new Player(name, strategy));
      
      }
      return players;
    }

    private void _greet()
    {
      Logger.Greet();
    }

    private void _initiateState()
    {
      this._state.SetPlayers(this._createPlayers());
      this.eventListeners.Add(new OverDrawEventListener());
      this.eventListeners.Add(new StatsEventListener());
    }
    private int? _chooseStrategy(string name)
    {
      Logger.Log($"Choose a strategy for {name}:");
      Logger.Log("Enter 1 - player is a person");
      Logger.Log("Enter 2 - careful computer");
      Logger.Log("Enter 3 - risky computer");
      return InputHandler.IntAnswer("Enter 4 - random  computer");
    }

    public void Start()
    {
      
      this._greet();
      this._initiateState();
      
      
     
      do
      {
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
        player.DrawCard(this._state.Deck); //показує карту, що була витягнута
      }

  
      int totalPoints = PointsCounter.CountSum(player.DrawnCards);

                                                                  //контекст = кількість балів
      while (totalPoints < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw(totalPoints))
      {
        player.DrawCard(this._state.Deck);
        totalPoints = PointsCounter.CountSum(player.DrawnCards);
      }

      //
      foreach(IEventListener eventListener in eventListeners)
      {
        eventListener.Update(player.DrawnCards, totalPoints, player);
      }
      
    }
  }
}