using blackjack.Observer;
using blackjack.Strategy;
using blackjack.Strategy.Interfaces;

namespace BlackJack
{
	class Game : GameContextBase
	{
		public static readonly int PLAYER_COUNT = 2;
		public static readonly int CARDS_WITHOUT_CONFIRMATION_COUNT = 2;
		public GameState State { get; private set; }

		public Game()
		{
			State = new GameState();
		}
		private List<IPlayer> _createPlayers()
		{
			return _strategy.GeneratePlayers();
		}
		private void _greet()
		{
			Logger.Greet();
		}
		private void _initiateState()
		{
			State.SetPlayers(this._createPlayers());
		}
		public void Start()
		{
			SetStrategy(InputHandler.ChooseGameMode()??_strategy);
			this._greet();
			this._initiateState();
			do
			{
				if (this.State.ActivePlayer == null)
				{
					throw new Exception("No active player detected!");
				}
				this.HandlePlayer(this.State.ActivePlayer);
			}
			while (this.State.SwitchPlayer());
			this.End();
		}

		public void End()
		{
			List<IPlayer> winners = this.State.GetWinners();
			Logger.EndGame(winners);
		}

		public void HandlePlayer(IPlayer player)
		{
			Logger.StartPlayersTurn(player.Name);
			for (int i = 0; i < CARDS_WITHOUT_CONFIRMATION_COUNT; i++)
			{
				player.DrawCard(this.State.Deck);
			}
			while (PointsCounter.CountSum(player.DrawnCards) < PointsCounter.MAX_POINTS_COUNT && player.ConfirmNextDraw())
			{
				player.DrawCard(this.State.Deck);
			}
		}
	}
}