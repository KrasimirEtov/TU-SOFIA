using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
	public class Student
	{
		public string FirstName { get; set; }
		public string SurName { get; set; }
		public string LastName { get; set; }
		public string Faculty { get; set; }
		public string Specialty { get; set; }
		public string Degree { get; set; }
		public string Status { get; set; }
		public string FacultyNumber { get; set; }
		public int Course { get; set; }
		public int Stream { get; set; }
		public int Group { get; set; }
		public DateTime LastCertification { get; set; }
		public DateTime LastPayment { get; set; }
	}
}
