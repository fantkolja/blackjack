using System.Text.Json;
using blackjack.Observer.Utils;
using BlackJack;

namespace blackjack.Observer
{
	public class AveragePointCountObserver : IObserver
	{

		private string _path = Directory.GetCurrentDirectory() + "/AveragePointsInfo.json";

		private int _points = 0;
		
		public void Update(ISubject subject)
		{
			var players = ((GameState)subject).Players;

			string jsonStr = File.ReadAllText(_path);
			
			AveragePointInfo? info = JsonSerializer.Deserialize<AveragePointInfo>(jsonStr);

			foreach (var player in players)
			{
				_points += PointsCounter.CountSum(player.DrawnCards);
			}
			if (info != null)
			{
				info.Update(_points);
				var result = JsonSerializer.Serialize<AveragePointInfo>(info, new JsonSerializerOptions()
				{
					WriteIndented = true
				});
				File.WriteAllText(_path, result);
			}
		}
	}
}
