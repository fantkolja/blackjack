using blackjack.Game;
using System.IO;
using System.Numerics;

namespace BlackJack
{
  class Game : GameObserver
  {
    public static readonly int PLAYER_COUNT = 2;
    public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
    public static readonly string pathToLoseNotifications = "C:\\Users\\HP\\SoftwareDesign\\lab6\\task3\\blackjack\\Game\\ObserverResults\\LoseNotifications.txt";
    public static readonly string pathToAvarageSum = "C:\\Users\\HP\\SoftwareDesign\\lab6\\task3\\blackjack\\Game\\ObserverResults\\AvarageSumOfPoints.txt";
    List<float> playersSum = new List<float>();
    private GameState _state = new GameState();
    private List<Player> _createPlayers()
    {
      var players = new List<Player>();
      for (int i = 1; i <= PLAYER_COUNT; i++)
      {
        string defaultName = $"Player {i}";
        string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
        players.Add(new Player(name));
      }
      return players;
    }
    private void _greet()
    {
      Logger.Greet();
    }
    private void _initiateState()
    {
      File.WriteAllText(pathToLoseNotifications, string.Empty);
      File.WriteAllText(pathToAvarageSum, string.Empty);
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
      WriteAnalytics(CountAvarageSum(playersSum));
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
      if (PointsCounter.CountSum(player.DrawnCards) > PointsCounter.MAX_POINTS_COUNT)
      {
         WriteExaggerate(player, PointsCounter.CountSum(player.DrawnCards));
      }
      playersSum.Add(PointsCounter.CountSum(player.DrawnCards));

    }

        public float CountAvarageSum(List<float> playersSum)
        {
            float sum = 0;
            foreach(float _sum in playersSum)
            {
                sum += _sum;
            }
            return sum/2;
        }

        public void WriteExaggerate(Player player, int sum)
        {
            using (StreamWriter writer = new StreamWriter(pathToLoseNotifications, true))
            {
                writer.WriteLine($"Player {player.Name} has {sum} points");
            }
        }

        public void WriteAnalytics(float sum)
        {
            using (StreamWriter writer = new StreamWriter(pathToAvarageSum, true))
            {
                writer.WriteLine($"Avarage sum of players is {sum}");
            }
        }
    }
}