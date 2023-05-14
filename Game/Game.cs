using blackjack.Game;
using blackjack.Game.Strategy;
using System.Xml.Linq;

namespace BlackJack
{
  class Game
  {
    public static readonly int PLAYER_COUNT = 2;
    public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
    private GameState _state = new GameState();
    private Context botContext = new Context();
    private List<IParticipant> _createParticipants()
    {
      botContext.Unset();
      var participants = new List<IParticipant>();
      Bot? bot = null;
      if (InputHandler.Confirm($"Do you want to play with bot?"))
      {
        int botId = int.TryParse(InputHandler.RequestAnswer($"Careful - 1, Risky - 2, Random - 3"), out botId) ? botId : 2;
        switch (botId)
        {
          case 1: bot = new CarefulBot(); break;
          case 2: bot = new RiskyBot(); break;
          default: bot = new RandomBot(); break;
        }
        botContext.SetBot(bot);
        participants.Add(new Player("YOU"));
        participants.Add(bot);
      }
      else
      {
        for (int i = 1; i <= PLAYER_COUNT; i++)
        {
          string defaultName = $"Player {i}";
          string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
          while (name.ToLower().Contains("bot"))
          {
            Console.WriteLine("Try another name.");
            name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
          }
          participants.Add(new Player(name));
        }
      }
      return participants;
    }

    private void _greet()
    {
      Console.Clear();
      Logger.Greet();
    }
    private void _initiateState()
    {
      this._state.SetPlayers(this._createParticipants());
    }
    public bool Start()
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
      return this.End();
    }

    public bool End()
    {
      List<IParticipant> winners = this._state.GetWinners();
      Logger.EndGame(winners);
      _botsAssessments(winners);
      return InputHandler.Confirm("Do you want to play again?");
    }

    public void HandlePlayer(IParticipant player)
    {
      Logger.StartPlayersTurn(player.Name);
      for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
      {
        player.DrawCard(this._state.Deck);
      }
      while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw(PointsCounter.CountSum(player.DrawnCards)))
      {
        player.DrawCard(this._state.Deck);
      }
    }

    private void _botsAssessments(List<IParticipant> winners)
    {
      foreach(IParticipant i in this._state.GetParticipants())
      {
        if (i.Name.ToLower().Contains("bot"))
        {
          botContext.SetBot((Bot)i);
          if(winners.Contains(i)) botContext.BotAssessment(true);
          else botContext.BotAssessment(false);
        }
      }
    }
  }
}