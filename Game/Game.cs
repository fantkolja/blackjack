namespace BlackJack
{
    using blackjack.Game.ObservableFiles;
    using System;

    class Game : IObservable<int>
    {
        public Game()
        {
            var per = new PereborService();
            per.Subscribe(this);
            var stat = new StatService();
            stat.Subscribe(this);
            _observers.Add(stat);
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void Unsubscribe(IObserver<int> observer)
        {
            var ob = (IObserverService)_observers.FirstOrDefault(observer);
            if (ob != null)
            {
                ob.Unsubscribe();
            }
        }

        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        private GameState _state = new GameState();
        private List<IObserver<int>> _observers = new List<IObserver<int>>();
        
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
            Console.WriteLine(AverageService.GetAveragePoints());
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
            
            foreach (var observer in _observers)
            {
                observer.OnNext(PointsCounter.CountSum(player.DrawnCards));
            }
            
        }
    }
}