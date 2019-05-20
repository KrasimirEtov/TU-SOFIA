using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RSAencryption
{
	public class Operations
	{
		public void AddUser()
		{
			var generator = new Generator();
			Console.WriteLine("Enter user name");
			var userName = Console.ReadLine();
			Console.WriteLine("Enter password");
			var password = Console.ReadLine();

			var p = generator.GetBigRandomNumber();
			var q = generator.GetBigRandomNumber();
			var N = generator.GenerateN(p, q);
			var fN = generator.GenerateFn(p, q);

			var publicKey = generator.GetPublicKey();
			var privateKey = generator.GetPrivateKey(publicKey, fN);

			string usersInfo = userName + " " + password + " " + N + "\n";
			string privateKeysInfo = userName + " " + privateKey.ToString() + "\n";
			string publicKeysInfo = userName + " " + publicKey.ToString() + "\n";
			File.AppendAllText(Environment.CurrentDirectory + "\\users.txt", usersInfo);
			File.AppendAllText(Environment.CurrentDirectory + "\\privateKeys.txt", privateKeysInfo);
			File.AppendAllText(Environment.CurrentDirectory + "\\publicKeys.txt", privateKeysInfo);
		}

		public User Login()
		{
			var generator = new Generator();
			User user = null;
			Console.WriteLine("Enter user name");
			var userName = Console.ReadLine();
			Console.WriteLine("Enter password");
			var password = Console.ReadLine();

			string usersLine;
			string publicLine;
			string privateLine;
			// Read the file and display it line by line.  
			StreamReader usersFile =new StreamReader(Environment.CurrentDirectory + "\\users.txt");
			StreamReader publicKeysFile =new StreamReader(Environment.CurrentDirectory + "\\publicKeys.txt");
			StreamReader privateKeysFile =new StreamReader(Environment.CurrentDirectory + "\\privateKeys.txt");
			while ((usersLine = usersFile.ReadLine()) != null)
			{
				var userData = usersLine.Split();

			}

			usersFile.Close();
			return user;
		}
	}
}
