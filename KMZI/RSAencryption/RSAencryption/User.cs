using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RSAencryption
{
	public class User
	{
		public string UserName { get; set; }

		public BigInteger PublicKey { get; set; }

		public BigInteger PrivateKey { get; set; }
	}
}
