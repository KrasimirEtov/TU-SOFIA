using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace RSAencryption
{
	public class Program
	{
		private static string menu = "1.Add User\n2.Log in\n3.Add msg\n4.Read msg\n0.Exit";
		private static List<User> users;
		private static List<string> msgs = new List<string>();
		private static User currUser = null;

		public static void Main(string[] args)
		{
			var operations = new Operations();
			var users = new List<User>();
			LoadData();
			while (true)
			{
				Console.WriteLine(menu);
				switch (Console.ReadLine())
				{
					case "1":
						operations.AddUser();
						break;
					case "2":
						var user = operations.Login();
						break;
					case "3":
						break;
					case "4":
						break;
					case "0":
						return;
				}
			}


			//const string plaintextstring = "Hello, Rosetta!";
			//byte[] plaintext = Encoding.ASCII.GetBytes(plaintextstring);
			//BigInteger pt = new BigInteger(plaintext);
			//if (pt > N)
			//	throw new Exception();

			//BigInteger ct = BigInteger.ModPow(pt, publicKey, N);
			//Console.WriteLine("Encoded:  " + ct);

			//BigInteger dc = BigInteger.ModPow(ct, privateKey, N);
			//Console.WriteLine("Decoded:  " + dc);

			//string decoded = ASCIIEncoding.ASCII.GetString(dc.ToByteArray());
			//Console.WriteLine("As ASCII: " + decoded);
		}

		private static void LoadData()
		{
			users = new List<User>();

			StreamReader usersFile = new StreamReader(Environment.CurrentDirectory + "\\users.txt");
			StreamReader publicKeysFile = new StreamReader(Environment.CurrentDirectory + "\\publicKeys.txt");
			StreamReader privateKeysFile = new StreamReader(Environment.CurrentDirectory + "\\privateKeys.txt");

			String user;
			String privateKey;
			String publicKey;
			while ((user = usersReader.readLine()) != null)
			{
				privateKey = privateKeyReader.readLine();
				publicKey = publicKeyReader.readLine();
				String[] userSplit = user.split(" ");
				String[] privateKeySplit = privateKey.split(" ");
				String[] publicKeySplit = publicKey.split(" ");

				users.add(new User(userSplit[0], userSplit[1], new BigInteger(userSplit[2]), new BigInteger(privateKeySplit[1]), new BigInteger(publicKeySplit[1])));
			}
		}
	}
}
