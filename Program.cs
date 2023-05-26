using blackjack.Game.Observer;
using BlackJack;

var game = new Game();
game.EventManager.Subscribe(GameEvent.EndGame, new EndGameObserver());
game.EventManager.Subscribe(GameEvent.Statistics, new StatisticsObserver());
game.Start();