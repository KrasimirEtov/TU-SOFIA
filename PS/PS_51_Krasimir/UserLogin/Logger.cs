using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
	public static class Logger
	{
		private static List<string> currentSessionActivities = new List<string>();

		public static void LogActivity(string activity)
		{
			string activityLine = $"{DateTime.Now}; {LoginValidation.CurrentUserName};  {LoginValidation.CurrentUserRole}; {activity}";

			File.AppendAllText("logFilePS.txt", activityLine);

			currentSessionActivities.Add(activityLine);
		}

		public static string GetCurrentSessionActivities(string filter)
		{
			StringBuilder sb = new StringBuilder();
			var filteredActivities = currentSessionActivities
				.Where(x => x.Contains(filter))
				.ToList();

			foreach (var item in filteredActivities)
			{
				sb.AppendLine(item);
			}
			return sb.ToString();
		}
	}
}
