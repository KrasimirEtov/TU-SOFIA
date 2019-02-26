using System;
using System.Collections.Generic;
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

			currentSessionActivities.Add(activityLine);
		}
	}
}
