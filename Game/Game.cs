using BlackJack.Classes;
using BlackJack.Interfaces;
namespace BlackJack
{
    public class Game : GameObservable
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        private GameState _state = new GameState();

        public Game()
        {
            AddObserver(new EventLogger("log.txt"));
            AddObserver(new PointsStatistics("statistics.txt"));
        }

        private List<Player> _createPlayers()
        {
            var players = new List<Player>();
            for (int i = 1; i <= PLAYER_COUNT; i++)
            {
                string defaultName = $"Player {i}";
                string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                Player player = new Player(name, ChooseStrategy());
                players.Add(player);
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
        }

        public void HandlePlayer(Player player)
        {
            Logger.StartPlayersTurn(player.Name);
            for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
            {
                player.DrawCard(this._state.Deck);
            }
            player.Play(this._state);
            NotifyObservers(PointsCounter.CountSum(player.DrawnCards).ToString());
        }

        public IStrategy ChooseStrategy()
        {
            int strategyChoice = int.Parse(InputHandler.RequestAnswer("Choose a strategy: 1 - Cautious, 2 - Risky, 3 - Random, any - Random."));
            switch (strategyChoice)
            {
                case 1:
                    return new CautiousStrategy();
                case 2:
                    return new RiskyStrategy();
                case 3:
                    return new RandomStrategy();
                default:
                    return new RandomStrategy();
            }
        }
    }
}
