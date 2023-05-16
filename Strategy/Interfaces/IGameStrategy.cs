using System;
using BlackJack;

namespace blackjack.Strategy.Interfaces
{
    internal interface IGameStrategy
    {
        public List<IPlayer> GeneratePlayers();
    }
}
