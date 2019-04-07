using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
	class Program
	{
		static void Main(string[] args)
		{
            StudentData data = new StudentData();
            Console.WriteLine("Enter faculty number:");
            string facNumber = Console.ReadLine();
            var result = data.IsThereStudent(facNumber);
            if (result != null)
            {
                Console.WriteLine(result.FirstName);
                Console.WriteLine(result.LastName);
                Console.WriteLine(result.Course);
            }
            else
            {
                Console.WriteLine("No such user");
            }

        }
	}
}
