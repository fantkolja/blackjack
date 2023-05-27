using System.Numerics;

namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;

        private static List<Player> _players = new List<Player>();
        private GameState _state = new GameState();
        private GameLogger _logger;
        private AnalyticsService _analyticsService;


        public Game(string logFilePath, string bustLogFilePath)
        {
            _logger = new GameLogger(logFilePath, bustLogFilePath);
            _analyticsService = new AnalyticsService();

        }
        public void createComputerPlayer(IStrategy strategy)
        {

            _players.Add(new ComputerPlayer("BOT", strategy));
        }
        private void createPlayer()
        {
            string defaultName = $"Player";
            string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
            _players.Add(new Player(name));
        }
        private void _greet()
        {
            Logger.Greet();
        }
        private void _initiateState()
        {
            createPlayer();
            this._state.SetPlayers(_players);
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
            while (this._state.SwitchPlayer());
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
            _logger.LogEvent("PlayerTurn", $"Player {player.Name}'s turn has started.");
            for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
            {
                player.DrawCard(this._state.Deck);
            }

            if (player is ComputerPlayer computerPlayer)
            {
                while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && computerPlayer.ConfirmNextDraw(player.DrawnCards))
                {
                    player.DrawCard(this._state.Deck);
                    _logger.LogEvent("CardDrawn", $"Player {player.Name} has drawn a card.");
                }
            }
            else
            {
                while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw())
                {
                    player.DrawCard(this._state.Deck);
                    _logger.LogEvent("CardDrawn", $"Player {player.Name} has drawn a card.");
                }
            }

            _analyticsService.UpdateStatistics(PointsCounter.CountSum(player.DrawnCards));

            SaveAnalytics();


            if (PointsCounter.CountSum(player.DrawnCards) > PointsCounter.MAX_POINTS_COUNT)
            {
                _logger.CheckBust(player.Name);
            }
            
        }

        public void SaveAnalytics()
        {
            _analyticsService.SaveAnalyticsToFile("analytics.txt");
        }
    }
}