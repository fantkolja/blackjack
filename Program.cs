using blackjack.Game.Observer;
using BlackJack;

var game = new Game();
game.Events.Subscribe(GameEvent.PointsChanged, new PointsObserver("points.txt"));
game.Events.Subscribe(GameEvent.GameEnd, new AveragePointsObserver("avgPoints.json"));
game.Start();