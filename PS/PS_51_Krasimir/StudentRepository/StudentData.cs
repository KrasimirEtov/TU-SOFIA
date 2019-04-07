using System.Collections.Generic;
using System.Linq;

namespace StudentRepository
{
    public class StudentData
    {
        private List<Student> students = new List<Student>();
        public List<Student> Students
        {
            get
            {
                AddStudents();
                return students;
            }
            private set
            {
                students = value;
            }
        }

        private void AddStudents()
        {
            students.AddRange(new List<Student>()
            {
                new Student()
                {
                    FirstName = "Митьо",
                    LastName = "Теслата",
                    FacultyNumber = "123456789",
                    Course = 3,
                    Degree = "Бакалавър",
                    Faculty = "ФКСТ",
                    Group = 51,
                    Specialty = "КСИ",
                    Status = "Редовен",
                    Stream = 2,
                    SurName = "Пищовов"
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
            return Students
                .Where(x => x.FacultyNumber == facultyNumber)
                .FirstOrDefault();
        }
    }
}
