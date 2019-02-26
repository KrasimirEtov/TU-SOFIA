using System;

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

			int choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 0:
					break;
				case 1:
					Console.WriteLine("Enter user name and role");
					UserData.AssignUserRole(Console.ReadLine(), (UserRoles.Roles)int.Parse(Console.ReadLine()));
					break;
				case 2:
					Console.WriteLine("Enter user name and date");
					UserData.ChangeActivityDate(Console.ReadLine(), DateTime.Parse(Console.ReadLine()));
					break;
			}
		}

		public static void ErrorLogger(string errorMessage)
		{
			Console.WriteLine("!!! " + errorMessage + " !!!");
		}
	}
}
