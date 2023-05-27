namespace BlackJack
{
    public class FileWriter
    {
        private string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void FileWriteLine(string content)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(filePath, true))
                {
                    wr.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while writing to file: {ex.Message}");
            }
        }
    }
}
