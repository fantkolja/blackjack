using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(int points);
    }

    public interface IObserver
    {
        void Update(int points);
    }

    public class Game : ISubject
    {
        private List<IObserver> observers;

        public Game()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(int points)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(points);
            }
        }
    }

    public class Analytic : IObserver
    {
        private int games = 0;
        private int totalPoints = 0;

        public void Update(int points)
        {
            if (points > 21)
            {
                using (StreamWriter sw = File.AppendText("number21.txt"))
                {
                    sw.WriteLine(points);
                }
            }
            games += 1;
            totalPoints += points;
        }

        public void SaveAverage()
        {
            double average = (double)totalPoints / games;
            using (StreamWriter sw = File.AppendText("score.txt"))
            {
                sw.WriteLine($"Average points : {average}");
            }
        }
    }
}
