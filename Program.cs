using BlackJack;
using lab_6.blackjack.Game;
using System;



//var game = new Game();
//game.Start();
// Створюємо об'єкт гри
IBlackjackGame game = new BlackjackGame();

// Додаємо гравців
IPlayer player1 = new Player("Player 1") as IPlayer;
IPlayer player2 = new Player("Player 2") as IPlayer;
game.AddPlayer(player1);
game.AddPlayer(player2);

// Викликаємо деякі методи гри
game.Hit();
game.Stand();
game.EndGame();

// Отримуємо загальну кількість очок
int totalPoints = game.GetTotalPoints();
Console.WriteLine("Total points: " + totalPoints);