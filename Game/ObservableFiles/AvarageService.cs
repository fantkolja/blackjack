namespace blackjack.Game.ObservableFiles;
public static class AverageService
{
    public static double GetAveragePoints()
    {
        List<int> pointsList = new List<int>();

        var lines = File.ReadAllLines(ObservableConsts.StatFile);

        foreach (var line in lines)
        {
            if (int.TryParse(line, out int points))
            {
                pointsList.Add(points);
            }
        }

        if (pointsList.Count == 0)
        {
            return 0;
        }

        return pointsList.Average();
    }
}
