using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
	public static class UserData
	{
		public static List<User> TestUsers { get; private set; }

		static UserData()
		{
			ResetTestUserData();
		}

		private static void ResetTestUserData()
		{
			TestUsers = new List<User>()
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
			foreach (User user in TestUsers)
			{
				if (user.UserName == userName && user.Password == password)
				{
					return user;
				}
			}
			return null;
		}

		public static void ChangeActivityDate(string userName, DateTime activeUntilDate)
		{
			User user = TestUsers.FirstOrDefault(x => x.UserName == userName);

			if (user != null)
			{
				user.ActiveUntil = activeUntilDate;
				Logger.LogActivity($"Changed {user.UserName} activity date");
			}
		}

		public static void AssignUserRole(string userName, UserRoles.Roles userRole)
		{
			User user = TestUsers.FirstOrDefault(x => x.UserName == userName);

			if (user != null)
			{
				user.UserRole = (int)userRole;
				LoginValidation.CurrentUserRole = userRole;
				Logger.LogActivity($"Changed {user.UserName} role");
			}
		}
	}
}
