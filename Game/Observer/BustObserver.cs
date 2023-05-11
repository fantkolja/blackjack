using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace blackjack.Game.Observer
{
    internal class BustObserver : IEventListener
    {
        private string filePath;
        private int comparator;
        private int summa = 0;

        public BustObserver(string filePath, int comparator)
        {
            this.filePath = filePath;
            this.comparator = comparator;
            if(!File.Exists(filePath)) File.WriteAllText(filePath, string.Empty);
        }
        
        public void Update(int number)
        {
            summa += number;
            if (summa <= comparator) return;

            string content = $"Bust ({summa}) at {DateTime.Now}\n";
            File.AppendAllText(filePath, content);
            summa = 0;
        }
    }
}
