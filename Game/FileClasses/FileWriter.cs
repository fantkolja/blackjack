using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.FileClasses
{
    public class FileWriter
    {
        private string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteToFile(string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing to file: {ex.Message}");
            }
        }
    }
}
