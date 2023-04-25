using blackjack.Game.Strategy;
using BlackJack;

var strategy = new RandomStrategy();

var game = new Game(false);
game.SetStrategy(strategy);
game.Start();