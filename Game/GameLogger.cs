using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameLogger
    {
        private readonly string _logFilePath;
        private readonly string _bustLogFilePath;


        public GameLogger(string logFilePath, string bustLogFilePath)
        {
            _logFilePath = logFilePath;
            _bustLogFilePath = bustLogFilePath;
        }

        public void LogEvent(string eventName, string description)
        {
            string logMessage = $"[{DateTime.Now}] {eventName}: {description}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }


        public void CheckBust(string name)
        {
            string bustMessage = $"[{DateTime.Now}] {name} has busted!";
            File.AppendAllText(_bustLogFilePath, bustMessage + Environment.NewLine);
        }
    }
}
