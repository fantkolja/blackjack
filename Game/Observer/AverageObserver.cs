using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    internal class AverageObserver : IEventListener
    {
        private string filePath;
        private List<int> numbers = new List<int>();

        public AverageObserver(string filePath)
        {
            this.filePath = filePath;
            File.WriteAllText(filePath, string.Empty);
        }

        public void Update(int number)
        {
            numbers.Add(number);
            string content = $"Average: {GetAverage(numbers)} at {DateTime.Now}\n";
            File.AppendAllText(filePath, content);
        }

        private static double GetAverage(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum / numbers.Count;
        }
    }
}
