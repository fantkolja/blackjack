namespace BlackJack
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(string name) : base(name)
        {
        }
        public interface IOpponentStrategy
        {
            Player ChooseOpponent(List<Player> opponents);
        }

        public class RandomOpponentStrategy : IOpponentStrategy
        {
            private Random random = new Random();

            public Player ChooseOpponent(List<Player> opponents)
            {
                // Вибрати випадкового опонента зі списку
                int index = random.Next(opponents.Count);
                return opponents[index];
            }
        }

        public class HighestScoreOpponentStrategy : IOpponentStrategy
        {
            public Player ChooseOpponent(List<Player> opponents)
            {
                // Вибрати опонента з найвищою кількістю очок
                Player highestScorePlayer = opponents[0];
                int highestScore = PointsCounter.CountSum(highestScorePlayer.DrawnCards);
                foreach (Player opponent in opponents)
                {
                    int score = PointsCounter.CountSum(opponent.DrawnCards);
                    if (score > highestScore)
                    {
                        highestScorePlayer = opponent;
                        highestScore = score;
                    }
                }
                return highestScorePlayer;
            }
        }

        public interface IComputerPlayerStrategy
        {
            bool ShouldDrawNextCard(List<Card> drawnCards);
        }

        public class CautiousComputerPlayerStrategy : IComputerPlayerStrategy
        {
            public bool ShouldDrawNextCard(List<Card> drawnCards)
            {
                // Обережний алгоритм: зупинятися після 13 набраних очок
                return PointsCounter.CountSum(drawnCards) < 13;
            }
        }

        public class RiskyComputerPlayerStrategy : IComputerPlayerStrategy
        {
            public bool ShouldDrawNextCard(List<Card> drawnCards)
            {
                // Ризиковий алгоритм: зупинятися після 19 набраних очок
                return PointsCounter.CountSum(drawnCards) < 19;
            }
        }

        public class RandomComputerPlayerStrategy : IComputerPlayerStrategy
        {
            private Random random = new Random();

            public bool ShouldDrawNextCard(List<Card> drawnCards)
            {
                // Рандомний алгоритм: випадкове прийняття рішення
                return random.Next(2) == 0;
            }
        }
    }
}
