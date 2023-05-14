using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    internal class InitManager
    {
        private static string projectPath = Directory.GetParent("./").Parent.Parent.Parent.ToString() + "/Game";
        private static string dataPath = projectPath + "/data";

        public static Subject GetNewSubject()
        {
            System.IO.Directory.CreateDirectory(dataPath);
            IEventListener bustObserver = new BustObserver(dataPath + "/busts.txt", PointsCounter.MAX_POINTS_COUNT);
            IEventListener averageObserver = new AverageObserver(dataPath + "/averages.txt");
            Subject subject = new Subject();
            subject.Subscribe(bustObserver);
            subject.Subscribe(averageObserver);
            return subject;
        }
    }
}
