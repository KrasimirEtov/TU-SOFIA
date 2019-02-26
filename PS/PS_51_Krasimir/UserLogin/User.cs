using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
	public class User
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public string FacultyNumber { get; set; }

		public int UserRole { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime ActiveUntil { get; set; }
	}
}
