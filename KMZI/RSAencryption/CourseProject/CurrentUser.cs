using Org.BouncyCastle.Math;

namespace CourseProject
{
	public static class CurrentUser
	{
		public static string UserName { get; set; }

		public static string Password { get; set; }

		public static BigInteger PublicKey { get; set; }

		public static BigInteger PrivateKey { get; set; }

		public static BigInteger N { get; set; }
	}
}
