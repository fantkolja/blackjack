using System.IO;

namespace lab_6.blackjack.Game
{
    public class BustMonitorService : IBlackjackGameObserver
    {
        private string logFilePath;

        public BustMonitorService(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Update(string eventInfo)
        {
            if (eventInfo.StartsWith("Player busted"))
            {
                // Запис відповідного випадку перебору в файл
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(eventInfo);
                }
            }
        }
    }

}
