using System;
using System.IO;
using System.Text;

namespace UserLogin
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter userName");
			string userName = Console.ReadLine();
			Console.WriteLine("Enter password");
			string password = Console.ReadLine();

			LoginValidation loginValidation = new LoginValidation(userName, password, ErrorLogger);

			if (loginValidation.ValidateUserInput(out User user))
			{
				AdminPanel();

				Console.WriteLine($"\nUser name: {user.UserName}\nUser password: {user.Password}\nFaculty number: {user.FacultyNumber}\nCreated on: {user.CreatedOn}\nActive until: {user.ActiveUntil}");

				switch ((int)LoginValidation.CurrentUserRole)
				{
					case 1:
						Console.WriteLine("Current user role: Anonymous");
						break;
					case 2:
						Console.WriteLine("Current user role: Admin");
						break;
					case 3:
						Console.WriteLine("Current user role: Inspector");
						break;
					case 4:
						Console.WriteLine("Current user role: Professor");
						break;
					case 5:
						Console.WriteLine("Current user role: Student");
						break;
				}
			}
		}

		public static void AdminPanel()
		{
			Console.WriteLine("Choose option:");
			Console.WriteLine("0: Exit");
			Console.WriteLine("1: Change user role");
			Console.WriteLine("2: Change user activity date");
			Console.WriteLine("3: See all users");
			Console.WriteLine("4: View log file");
			Console.WriteLine("5: View current session activity");

			int choice = int.Parse(Console.ReadLine());
			var allUserNames = UserData.GetAllUsersUsernames();
			string userNameToEdit;
			switch (choice)
			{
				case 0:
					return;
				case 1:
					Console.WriteLine("Enter user name and role");
					userNameToEdit = Console.ReadLine();
					UserData.AssignUserRole(allUserNames[userNameToEdit], (UserRoles.Roles)int.Parse(Console.ReadLine()));
					break;
				case 2:
					Console.WriteLine("Enter user name and date");
					userNameToEdit = Console.ReadLine();
					UserData.ChangeActivityDate(allUserNames[userNameToEdit], DateTime.Parse(Console.ReadLine()));
					break;
				case 3:
					foreach (var user in allUserNames)
					{
						Console.WriteLine(user.Key);
					}		
					break;
				case 4:
					StreamReader sr = new StreamReader("logFilePS.txt");
					string logResult = sr.ReadToEnd();
					Console.WriteLine(logResult);
					sr.Close();
					break;
				case 5:
					string result = Logger.GetCurrentSessionActivities("login");
					Console.WriteLine(result);
					break;
			}
		}

		public static void ErrorLogger(string errorMessage)
		{
			Console.WriteLine("!!! " + errorMessage + " !!!");
		}
	}
}
