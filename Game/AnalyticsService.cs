using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack

class AnalyticsService
{
    private int _totalRounds;
    private int _totalPoints;

    public void UpdateStatistics(int points)
    {
        _totalRounds++;
        _totalPoints += points;
    }

    public double GetAveragePoints()
    {
        if (_totalRounds == 0)
            return 0;

        return (double)_totalPoints / _totalRounds;
    }

    public void SaveAnalyticsToFile(string filePath)
    {
        string analyticsData = $"Total Rounds: {_totalRounds}\nAverage Points: {GetAveragePoints()}";
        File.WriteAllText(filePath, analyticsData);
    }
}
