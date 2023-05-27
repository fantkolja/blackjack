
namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        private GameState _state;
        private IObserver _averageScore;
        public GameMode Mode { get; private set; }

        public Game()
        {
            _state = new GameState();
            _averageScore = new AverageScoreObserver();
        }
        private List<Player> _createPlayers()
        {
            var players = new List<Player>();

            if (Mode == GameMode.MultiPlayer)
            {
                for (int i = 1; i <= PLAYER_COUNT; i++)
                {
                    string defaultName = $"Player {i}";
                    string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                    players.Add(new UserPlayer(name));
                }
                return players;
            }

            else if (Mode == GameMode.SinglePlayer)
            {
                string defaultName = $"Player";
                string name = InputHandler.RequestAnswer($"Write your name", defaultName);
                players.Add(new UserPlayer(name));

                string gameAI = InputHandler.RequestAnswer($"Choose difficulty:\n1 - Careful\n2 - Risky\n3 - Random", "1");


                Player ai;

                if (gameAI == "1")
                    ai = new CarefulAI();
                else if (gameAI == "2")
                    ai = new RiskyAI();
                else
                    ai = new RandomAI();

                players.Add(ai);
            }

            return players;
        }
        private void _greet()
        {
            Logger.Greet();
        }
        private void _initiateState()
        {
            string mode = InputHandler.RequestAnswer($"Choose game mode:\n1 - Single player\n2 - Multiplayer", "1");

            if (mode == "1")
                this.Mode = GameMode.SinglePlayer;
            else
                this.Mode = GameMode.MultiPlayer;

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
            while (this._state.SwitchPlayer());
            this.End();
        }

        public void End()
        {
            List<Player> winners = this._state.GetWinners();
            Logger.EndGame(winners);
            _averageScore.Update($"Game Mode: {Mode}, Average Score: {_state.GetAverageScore()}");
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