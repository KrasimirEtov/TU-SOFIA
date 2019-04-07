using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        private readonly StudentData studentData = new StudentData();

        public Student GetStudentDataByUser(User student)
        {
            if (string.IsNullOrEmpty(student.FacultyNumber) || student == null)
            {
                throw new Exception("User is not found");
            }

            var studentRecord = studentData.IsThereStudent(student.FacultyNumber);

            if (studentRecord == null)
            {
                throw new Exception("User is not found");
            }

            return studentRecord;
        }
    }
}
