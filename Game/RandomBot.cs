using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    internal class RandomBot : BotType
    {
        private int MaxRiskPoints;

        public RandomBot()
        {
            Random random = new Random(); 
            MaxRiskPoints = random.Next(13, 20);
            WriteRandom();
        }
        public int GetMaxRiskPoints()
        {
            return MaxRiskPoints;
        }

        public void WriteRandom()
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\HP\\SoftwareDesign\\lab6\\task3\\blackjack1\\Game\\Random\\RandomNumber.txt"))
            {
                writer.WriteLine($"Random number is {this.MaxRiskPoints}");
            }
        }
    }
}
