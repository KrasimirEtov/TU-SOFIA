using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace CourseProject
{
	public class Program
	{
		public static Dictionary<string, List<BigInteger>> Messages { get; set; } = new Dictionary<string, List<BigInteger>>();

		static void Main(string[] args)
		{
			while (true)
			{
				PrintMenu();
				switch (Console.ReadLine())
				{
					case "1":
						AddUser();
						Console.WriteLine("\nPress Any key to clear the console.\n");
						Console.ReadKey();
						Console.Clear();
						break;
					case "2":
						Login();
						Console.WriteLine("\nPress Any key to clear the console.\n");
						Console.ReadKey();
						Console.Clear();
						break;
					case "3":
						AddMessage();
						Console.WriteLine("\nPress Any key to clear the console.\n");
						Console.ReadKey();
						Console.Clear();
						break;
					case "4":
						ReadMessage();
						Console.WriteLine("\nPress Any key to clear the console.\n");
						Console.ReadKey();
						Console.Clear();
						break;
					case "5":
						return;
				}
			}
		}

		public static void PrintMenu()
		{
			Console.WriteLine("1. Add user");
			Console.WriteLine("2. Login");
			Console.WriteLine("3. Add message");
			Console.WriteLine("4. Read message");
			Console.WriteLine("5. Exit");
		}

		public static void AddUser()
		{
			Console.WriteLine();
			Console.WriteLine("Enter user name");
			var userName = Console.ReadLine();
			Console.WriteLine("Enter password");
			var password = Console.ReadLine();

			var p = GetRandomNumber();
			var q = GetRandomNumber();
			var N = GenerateN(p, q);
			var fN = GenerateFn(p, q);

			var publicKey = GetPublicKey();
			var privateKey = GetPrivateKey(publicKey, fN);

			string usersInfo = userName + " " + password + " " + N + "\n";
			string privateKeysInfo = userName + " " + privateKey.ToString() + "\n";
			string publicKeysInfo = userName + " " + publicKey.ToString() + "\n";
			File.AppendAllText(Environment.CurrentDirectory + "\\users.txt", usersInfo);
			File.AppendAllText(Environment.CurrentDirectory + "\\privateKeys.txt", privateKeysInfo);
			File.AppendAllText(Environment.CurrentDirectory + "\\publicKeys.txt", publicKeysInfo);
		}

		public static void Login()
		{
			Console.WriteLine();
			Console.WriteLine("Enter user name");
			var userName = Console.ReadLine();
			Console.WriteLine("Enter password");
			var password = Console.ReadLine();
			GetCurrentUser(userName, password);
		}

		public static void AddMessage()
		{
			Console.WriteLine();
			Console.WriteLine("Enter receiver user name");
			var userName = Console.ReadLine();
			Console.WriteLine("Enter message to encrypt");
			var messageInput = Console.ReadLine();
			GetCurrentUser(userName);
			var message = EncodeMessage(messageInput, CurrentUser.PublicKey, CurrentUser.N);

			if (Messages.ContainsKey(userName))
			{
				Messages[userName].Add(message);
			}
			else
			{
				var messages = new List<BigInteger>() { message };
				Messages.Add(userName, messages);
			}
		}

		public static void ReadMessage()
		{
			Console.WriteLine();
			StringBuilder decodedMessages = new StringBuilder();
			Console.WriteLine("Enter receiver user name");
			var userName = Console.ReadLine();
			if (!Messages.ContainsKey(userName))
			{
				Console.WriteLine("No messages for user {0}", userName);
				return;
			}
			var userMessages = Messages[userName];
			foreach (var msg in userMessages)
			{
				decodedMessages.AppendLine(DecodeMessage(msg, CurrentUser.PrivateKey, CurrentUser.N));
			}
			Console.WriteLine();
			Console.WriteLine("Messages for user {0}:", userName);
			Console.WriteLine(decodedMessages);
		}

		private static void GetCurrentUser(string userName, string password = null)
		{
			string[] userFile = File.ReadAllLines(Environment.CurrentDirectory + "\\users.txt");

			foreach (var userLine in userFile)
			{
				if (userLine.Contains(userName))
				{
					var userInfo = userLine.Split();
					CurrentUser.UserName = userInfo[0];
					if (!string.IsNullOrEmpty(password))
					{
						CurrentUser.Password = userInfo[1];
					}
					CurrentUser.N = BigInteger.Parse(userInfo[2]);
				}
			}

			string[] privateKeysFile = File.ReadAllLines(Environment.CurrentDirectory + "\\privateKeys.txt");

			foreach (var privateKeyLine in privateKeysFile)
			{
				if (privateKeyLine.Contains(userName))
				{
					var userInfo = privateKeyLine.Split();
					CurrentUser.PrivateKey = BigInteger.Parse(userInfo[1]);
				}
			}

			string[] publicKeysFile = File.ReadAllLines(Environment.CurrentDirectory + "\\publicKeys.txt");

			foreach (var publicKeysLine in publicKeysFile)
			{
				if (publicKeysLine.Contains(userName))
				{
					var userInfo = publicKeysLine.Split();
					CurrentUser.PublicKey = BigInteger.Parse(userInfo[1]);
				}
			}
		}

		private static BigInteger EncodeMessage(string message, BigInteger publicKey, BigInteger N)
		{
			byte[] messageToByteArray = Encoding.ASCII.GetBytes(message);
			BigInteger encoded = new BigInteger(messageToByteArray);

			return BigInteger.ModPow(encoded, publicKey, N);
		}

		private static string DecodeMessage(BigInteger encodedMessage, BigInteger privateKey, BigInteger N)
		{
			var decodedMessage = BigInteger.ModPow(encodedMessage, privateKey, N);

			return Encoding.ASCII.GetString(decodedMessage.ToByteArray());
		}

		private static BigInteger GetRandomNumber()
		{
			while (true)
			{
				var number = new BigInteger(GenerateRandomNumberByteArray());
				if (IsPrimeByMillerRabin(number, 10))
				{
					return number;
				}
			}
		}

		private static byte[] GenerateRandomNumberByteArray()
		{
			using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
			{
				byte[] bytes = new byte[64];
				rng.GetBytes(bytes);

				return bytes;
			}
		}

		private static BigInteger GenerateN(BigInteger p, BigInteger q)
		{
			return BigInteger.Multiply(p, q);
		}

		private static BigInteger GenerateFn(BigInteger p, BigInteger q)
		{
			return BigInteger.Multiply(BigInteger.Subtract(p, 1), BigInteger.Subtract(q, 1));
		}

		private static BigInteger GetPublicKey()
		{
			return new BigInteger(65537);
		}

		public static bool IsPrimeByMillerRabin(BigInteger source, int certainty)
		{
			if (source == 2 || source == 3)
				return true;
			if (source < 2 || source % 2 == 0)
				return false;

			BigInteger d = source - 1;
			int s = 0;

			while (d % 2 == 0)
			{
				d /= 2;
				s += 1;
			}

			// There is no built-in method for generating random BigInteger values.
			// Instead, random BigIntegers are constructed from randomly generated
			// byte arrays of the same length as the source.
			RandomNumberGenerator rng = RandomNumberGenerator.Create();
			byte[] bytes = new byte[source.ToByteArray().LongLength];
			BigInteger a;

			for (int i = 0; i < certainty; i++)
			{
				do
				{
					// This may raise an exception in Mono 2.10.8 and earlier.
					// http://bugzilla.xamarin.com/show_bug.cgi?id=2761
					rng.GetBytes(bytes);
					a = new BigInteger(bytes);
				}
				while (a < 2 || a >= source - 2);

				BigInteger x = BigInteger.ModPow(a, d, source);
				if (x == 1 || x == source - 1)
					continue;

				for (int r = 1; r < s; r++)
				{
					x = BigInteger.ModPow(x, 2, source);
					if (x == 1)
						return false;
					if (x == source - 1)
						break;
				}

				if (x != source - 1)
					return false;
			}
			return true;
		}

		private static BigInteger GetPrivateKey(BigInteger publicKey, BigInteger fN)
		{
			BigInteger inv, u1, u3, v1, v3, t1, t3, q;
			BigInteger iter;
			/* Step X1. Initialise */
			u1 = 1;
			u3 = publicKey;
			v1 = 0;
			v3 = fN;
			/* Remember odd/even iterations */
			iter = 1;
			/* Step X2. Loop while v3 != 0 */
			while (v3 != 0)
			{
				/* Step X3. Divide and "Subtract" */
				q = u3 / v3;
				t3 = u3 % v3;
				t1 = u1 + q * v1;
				/* Swap */
				u1 = v1;
				v1 = t1;
				u3 = v3;
				v3 = t3;
				iter = -iter;
			}
			/* Make sure u3 = gcd(u,v) == 1 */
			if (u3 != 1)
				return 0;   /* Error: No inverse exists */
							/* Ensure a positive result */
			if (iter < 0)
				inv = fN - u1;
			else
				inv = u1;
			return inv;
		}
	}
}
