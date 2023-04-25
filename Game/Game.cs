using blackjack;
using blackjack.Game.Strategy;
using blackjack.Game.Observer;

namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        private GameState _state = new GameState();
        private IStrategy _strategy;
        public bool IsMultiplayer { get; private set; }
        public Game(bool isMultiplayer = true)
        {
            IsMultiplayer = isMultiplayer;
            if (!IsMultiplayer)
            {
                _strategy = new WeakStrategy();
            }
        }
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }
        private List<Player> _createPlayers()
        {
            var players = new List<Player>();
            if (IsMultiplayer)
            {
                for (int i = 1; i <= PLAYER_COUNT; i++)
                {
                    string defaultName = $"Player {i}";
                    string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                    players.Add(new Player(name));
                }
            }
            else
            {
                string defaultName = $"Player {1}";
                string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                players.Add(new Player(name));
                for (int i = 2; i <= PLAYER_COUNT; i++)
                {
                    var num = 0;
                    foreach (var player in players)
                    {
                        if (player.IsAi)
                        {
                            num++;
                        }
                    }
                    players.Add(new Player($"AI_{num}", true));
                }
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
            var analyticsObserver = new AnalyticsObserver("analytics.txt");
            Console.WriteLine();
            Console.WriteLine($"Average score for all rounds in all played games on this computer: {analyticsObserver.GetAveragePoints()}");
        }

        public void HandlePlayer(Player player)
        {
            Logger.StartPlayersTurn(player.Name);
            for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
            {
                player.DrawCard(this._state.Deck);
            }

            if (!player.IsAi)
            {
                while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw())
                {
                    player.DrawCard(this._state.Deck);
                }
            }
            else
            {
                while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && _strategy.DecideMove(PointsCounter.CountSum(player.DrawnCards)))
                {
                    player.DrawCard(this._state.Deck);
                }
            }

            int points = PointsCounter.CountSum(player.DrawnCards);

            // Notify observers
            var subject = new PointsSubject();
            var overdrawObserver = new OverdrawObserver("overdraw.txt");
            var analyticsObserver = new AnalyticsObserver("analytics.txt");

            subject.RegisterObserver(overdrawObserver);
            subject.RegisterObserver(analyticsObserver);
            subject.NotifyObservers(points);

            // Write in console about overdraw
            if (points > PointsCounter.MAX_POINTS_COUNT)
            {
                Console.WriteLine($"{player.Name} have got overdraw ({points} points)");
                Console.WriteLine();
            }
        }
    }
}