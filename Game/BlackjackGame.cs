using System.Collections.Generic;
using BlackJack;
//using lab_6.blackjack.CardsDeck;

namespace lab_6.blackjack.Game
{
    public class BlackjackGame : IBlackjackGame
    {
        private List<IBlackjackGameObserver> observers;
        private List<IPlayer> players;

        public BlackjackGame()
        {
            observers = new List<IBlackjackGameObserver>();
            players = new List<IPlayer>();
        }

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }
        public void AddObserver(IBlackjackGameObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IBlackjackGameObserver observer)
        {
            observers.Remove(observer);
        }

        public void Hit()
        {
            foreach (var observer in observers)
            {
                observer.Update("Player received a card.");
            }
        }

        public void Stand()
        {
            foreach (var observer in observers)
            {
                observer.Update("Player stood.");
            }
        }

        public void EndGame()
        {
            foreach (var observer in observers)
            {
                observer.Update("Game ended.");
            }
        }

        public int GetTotalPoints()
        {
            int totalPoints = 0;

            foreach (var player in players)
            {
                int playerPoints = CalculatePlayerPoints(player);
                totalPoints += playerPoints;
            }

            return totalPoints;
        }

        private int CalculatePlayerPoints(IPlayer player)
        {
            int points = 0;
            int numberOfAces = 0;

            // Retrieve the player's hand using the appropriate method or logic
            List<Card> hand = GetPlayerHand(player);

            foreach (var card in hand)
            {
                points += GetCardValue(card);

                if (card.Name == CardName.Ace)
                {
                    numberOfAces++;
                }
            }

            while (numberOfAces > 0 && points > 21)
            {
                points -= 10;
                numberOfAces--;
            }

            return points;
        }

        private int GetCardValue(Card card)
        {
            switch (card.Name)
            {
                case CardName.Two:
                    return 2;
                case CardName.Three:
                    return 3;
                case CardName.Four:
                    return 4;
                case CardName.Five:
                    return 5;
                case CardName.Six:
                    return 6;
                case CardName.Seven:
                    return 7;
                case CardName.Eight:
                    return 8;
                case CardName.Nine:
                    return 9;
                case CardName.Ten:
                case CardName.Jack:
                case CardName.Queen:
                case CardName.King:
                    return 10;
                case CardName.Ace:
                    return 11;
                default:
                    return 0; // Handle unknown card names or error cases
            }
        }

        private List<Card> GetPlayerHand(IPlayer player)
        {
            var playerInstance = player as Player;
            return playerInstance != null ? playerInstance.Hand : new List<Card>();
        }

    }
}
