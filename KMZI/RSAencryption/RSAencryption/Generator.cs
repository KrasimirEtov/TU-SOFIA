using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace RSAencryption
{
	public class Generator
	{
		public BigInteger GetBigRandomNumber()
		{
			while (true)
			{
				var number = new BigInteger(GenerateBigRandomNumberByteArray());
				if (number.IsProbablePrimeMillerRabin(10))
				{
					return number;
				}
			}
		}

		private byte[] GenerateBigRandomNumberByteArray()
		{
			using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
			{
				byte[] bytes = new byte[64];
				rng.GetBytes(bytes);

				return bytes;
			}
		}

		public BigInteger GetPrivateKey(BigInteger publicKey, BigInteger fN)
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
		public BigInteger GenerateN(BigInteger p, BigInteger q)
		{
			return BigInteger.Multiply(p, q);
		}

		public BigInteger GenerateFn(BigInteger p, BigInteger q)
		{
			return BigInteger.Multiply(BigInteger.Subtract(p, 1), BigInteger.Subtract(q, 1));
		}

		public BigInteger GetPublicKey()
		{
			return new BigInteger(65537);
		}
	}
}