﻿    using BlackJack;

var game = new Game("log.txt", "bustLog.txt");
game.createComputerPlayer(new CautiousStrategy());
game.Start();