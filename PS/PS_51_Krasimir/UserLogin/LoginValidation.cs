using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
	public class LoginValidation
	{
		private readonly string userName;
		private readonly string password;
		private string errorMessage;
		private ActionOnError actionOnError;

		public delegate void ActionOnError(string errorMessage);

		public static UserRoles.Roles CurrentUserRole { get; set; }

		public static string CurrentUserName { get; set; }

		public LoginValidation(string userName, string password, ActionOnError actionOnError)
		{
			this.userName = userName;
			this.password = password;
			this.actionOnError = actionOnError;
		}

		public bool ValidateUserInput(out User user)
		{
			user = null;
			if (this.userName.Equals(string.Empty) || this.password.Equals(string.Empty))
			{
				errorMessage = "Username or password is empty";
				actionOnError(errorMessage);
				CurrentUserRole = UserRoles.Roles.Anonymous;
				return false;
			}

			if (this.userName.Length < 5 || this.password.Length < 5)
			{
				errorMessage = "Username or password shoud be at least 5 characters long";
				actionOnError(errorMessage);
				CurrentUserRole = UserRoles.Roles.Anonymous;
				return false;
			}

			user = UserData.IsUserPasswordCorrect(this.userName, this.password);	

			if (user == null)
			{
				errorMessage = "User with that username and password is not found";
				actionOnError(errorMessage);
				CurrentUserRole = UserRoles.Roles.Anonymous;
				return false;
			}
			CurrentUserRole = (UserRoles.Roles)user.UserRole;
			CurrentUserName = user.UserName;
			Logger.LogActivity("Successfull login");
			return true;
		}
	}
}
