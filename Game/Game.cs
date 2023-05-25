using blackjack.Game;
using blackjack.Game.Observer;
using blackjack.Game.Strategy;

namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        public GameMode Mode { get; private set; }
        private GameState _state;
        private IObserver _statisticsObserver;

        public Game()
        {
            _state = new GameState();
            _statisticsObserver = new StatisticsObserver();
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
                    players.Add(new LocalPlayer(name));
                }
            }

            else if(Mode == GameMode.WithAI)
            {
                string defaultName = $"Player";
                string name = InputHandler.RequestAnswer($"Write your name", defaultName);
                players.Add(new LocalPlayer(name));

                string gameAI = InputHandler.RequestAnswer($"Select AI (input number from 1 to 3):\n\t1) Careful\n\t2) Risky\n\t3) Random", "1");

                Player ai = new CarefulAI();

                if (gameAI == "1")
                    ai = new CarefulAI();
                else if (gameAI == "2")
                    ai = new RiskyAI();
                else if (gameAI == "3")
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
            string mode = InputHandler.RequestAnswer($"Select AI (input number from 1 or 2):\n\t1) 2 Players\n\t2) With AI", "1");

            if (mode == "2")
                this.Mode = GameMode.WithAI;
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

            _statisticsObserver.Update($"Datetime: {DateTime.Now}, Average Score: {_state.GetAverageScore()}");
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