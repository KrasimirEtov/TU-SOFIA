using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
	public class StudentData
	{
		private List<Student> testStudents;
		public List<Student> TestStudents
		{
			get
			{
				AddStudents();
				return testStudents;
			}
			private set
			{
				testStudents = value;
			}
		}

		private void AddStudents()
		{
			testStudents.AddRange(new List<Student>()
			{
				new Student()
				{
					FirstName = "Mitio",
					LastName = "Teslata",
					FacultyNumber = "123456789"
				},
				new Student()
				{
					FirstName = "Bace",
					LastName = "Pepi",
					FacultyNumber = "123456987"
				}
			});
		}

		public Student IsThereStudent(string facultyNumber)
		{
			return TestStudents
				.Where(x => x.FacultyNumber == facultyNumber)
				.FirstOrDefault();
		}
	}
}
