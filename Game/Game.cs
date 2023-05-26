using blackjack.Game.Observer;
using blackjack.Game.Strategy;

namespace BlackJack
{
    class Game
    {
        public static readonly int PLAYER_COUNT = 2;
        public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
        public EventManager EventManager = new EventManager();
        private GameState _state = new GameState();
        private bool _playWithBot = false;
        private List<Player> _createPlayers()
        {
            var players = new List<Player>();
            if (this._playWithBot)
            {
                for (int i = 1; i < PLAYER_COUNT; i++)
                {
                    string botName = $"Bot {i}";
                    bool riskyStrategy = InputHandler.Confirm($"Do you want {botName} to play with risky strategy?");
                    if (riskyStrategy)
                    {
                        players.Add(new Bot(botName, new RiskyStrategy()));
                        continue;
                    }
                    bool randomStrategy = InputHandler.Confirm($"Do you want {botName} to play with random strategy?");
                    if (randomStrategy)
                    {
                        players.Add(new Bot(botName, new RandomStrategy()));
                        continue;
                    }
                    players.Add(new Bot(botName, new CarefulStrategy()));
                }
                string defaultName = $"Player 1";
                string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                players.Add(new Player(name));
            }
            else
            {
                for (int i = 1; i <= PLAYER_COUNT; i++)
                {
                    string defaultName = $"Player {i}";
                    string name = InputHandler.RequestAnswer($"Write a name for [{defaultName}]", defaultName);
                    players.Add(new Player(name));
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
            this._playWithBot = InputHandler.Confirm("Do you want to play with bot?");
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
            List<Player> winners = this._state.GetWinners(EventManager);
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
    }
}