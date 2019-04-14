using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
	public static class UserData
	{
		public static List<User> Users { get; private set; }

		static UserData()
		{
			ResetTestUserData();
		}

		private static void ResetTestUserData()
		{
			Users = new List<User>()
			{
				new User()
				{
					UserName = "Administrator",
					Password = "12345",
					FacultyNumber = "123456789",
					UserRole = (int)UserRoles.Roles.Admin,
					CreatedOn = DateTime.Now,
					ActiveUntil = DateTime.MaxValue
				},
				new User()
				{
					UserName = "rumencho",
					Password = "12345",
					FacultyNumber = "121216999",
					UserRole = (int)UserRoles.Roles.Student,
					CreatedOn = DateTime.Now,
					ActiveUntil = DateTime.MaxValue
				},
				new User()
				{
					UserName = "traiko",
					Password = "12345",
					FacultyNumber = "121216100",
					UserRole = (int)UserRoles.Roles.Student,
					CreatedOn = DateTime.Now,
					ActiveUntil = DateTime.MaxValue
				}
			};
		}

		public static User IsUserPasswordCorrect(string userName, string password)
		{
			return Users
				.Where(x => x.UserName == userName && x.Password == password)
				.FirstOrDefault();
		}

		public static void ChangeActivityDate(int userIndex, DateTime activeUntilDate)
		{
			User user = Users[userIndex];

			if (user != null)
			{
				user.ActiveUntil = activeUntilDate;
				Logger.LogActivity($"Changed {user.UserName} activity date");
			}
		}

		public static void AssignUserRole(int userIndex, UserRoles.Roles userRole)
		{
			User user = Users[userIndex];

			if (user != null)
			{
				user.UserRole = (int)userRole;
				LoginValidation.CurrentUserRole = userRole;
				Logger.LogActivity($"Changed {user.UserName} role");
			}
		}

		public static Dictionary<string, int> GetAllUsersUsernames()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();

			for (int i = 0; i < Users.Count; i++)
			{
				result.Add(Users[i].UserName, i);
			}

			return result;
		}
	}
}
