using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class GameObserver : Observer
    {
        public readonly string pathToLoseNotifications = "C:\\Users\\HP\\SoftwareDesign\\lab6\\task3\\blackjack\\Game\\ObserverResults\\LoseNotifications.txt";
        public readonly string pathToAvarageSum = "C:\\Users\\HP\\SoftwareDesign\\lab6\\task3\\blackjack\\Game\\ObserverResults\\AvarageSumOfPoints.txt";
        private List<float> playersSum = new List<float>();

        public void AddPlayersSum(float sum)
        {
            playersSum.Add(sum);
        }

        public List<float> GetPlayersSum() { 
            return playersSum;
        }
        public void CleanFiles()
        {
            File.WriteAllText(pathToLoseNotifications, string.Empty);
            File.WriteAllText(pathToAvarageSum, string.Empty);
        }
        public float CountAvarageSum(List<float> playersSum)
        {
            float sum = 0;
            foreach (float _sum in playersSum)
            {
                sum += _sum;
            }
            return sum / 2;
        }

        public void WriteExaggerate(Player player, int sum)
        {
            using (StreamWriter writer = new StreamWriter(pathToLoseNotifications, true))
            {
                writer.WriteLine($"Player {player.Name} has {sum} points");
            }
        }

        public void WriteAnalytics()
        {
            using (StreamWriter writer = new StreamWriter(pathToAvarageSum, true))
            {
                writer.WriteLine($"Avarage sum of players is {this.CountAvarageSum(playersSum)}");
            }
        }
    }
}
