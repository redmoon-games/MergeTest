using System;

namespace Utils
{
	public class TimeUtils
	{
		public static string SecondsToMS(long seconds)
		{
			var timeSpan = TimeSpan.FromSeconds(seconds);
			if (timeSpan.TotalMinutes >= 1)
				return timeSpan.ToString("mm\\:ss");
			return timeSpan.ToString("ss");
		}

		public static string SecondsToHMS(long seconds)
		{
			var timeSpan = TimeSpan.FromSeconds(seconds);
			if (timeSpan.TotalHours >= 1)
				return timeSpan.ToString("hh\\:mm\\:ss");
			if (timeSpan.TotalMinutes >= 1)
				return timeSpan.ToString("mm\\:ss");
			return timeSpan.ToString("ss");
		}
	}
}