using blackjack.Game;
using blackjack.Game.Strategy;

namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        private OverScoreObserver overScoreObserver = new OverScoreObserver();
        private AverageScoreObserver averageScoreObserver = new AverageScoreObserver();
        private GameState _state = new GameState();

        private List<Player> _createPlayers()
        {
            var players = new List<Player>();
            for (int i = 1; i < PLAYER_COUNT; i++)
            {
                string defaultName = $"Player {i}";
                string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                var newPlayer = new Player(name) { Strategy = new HumanStrategy() };

                newPlayer.Subscribe(overScoreObserver);
                newPlayer.Subscribe(averageScoreObserver);

                players.Add(newPlayer);
            }

            var strategy = _selectStrategy();
            var computer = new Player("Computer") { Strategy = strategy };
            computer.Subscribe(overScoreObserver);
            computer.Subscribe(averageScoreObserver);

            players.Add(computer);

            return players;
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
            for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
            {
                player.DrawCard(this._state.Deck);
            }
            while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw())
            {
                player.DrawCard(this._state.Deck);
            }
        }

        private IPlayingStrategy _selectStrategy()
        {
            Console.WriteLine("Choose a strategy for the computer player: ");
            Console.WriteLine("1. Cautious (stops after 13 points)");
            Console.WriteLine("2. Risky (stops after 19 points)");
            Console.WriteLine("3. Random (stops at a random point count)");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    return new CautiousStrategy();
                case 2:
                    return new RiskyStrategy();
                case 3:
                    return new RandomStrategy();
                default:
                    throw new Exception("Invalid strategy choice");
            }
        }
    }
}