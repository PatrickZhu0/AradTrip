using System;
using System.Text;

namespace Xxtea
{
	// Token: 0x0200473E RID: 18238
	public sealed class XXTEA
	{
		// Token: 0x0601A332 RID: 107314 RVA: 0x0082339F File Offset: 0x0082179F
		private XXTEA()
		{
		}

		// Token: 0x0601A333 RID: 107315 RVA: 0x008233A7 File Offset: 0x008217A7
		private static uint MX(uint sum, uint y, uint z, int p, uint e, uint[] k)
		{
			return (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[(int)(checked((IntPtr)(unchecked((long)(p & 3) ^ (long)((ulong)e)))))] ^ z);
		}

		// Token: 0x0601A334 RID: 107316 RVA: 0x008233CB File Offset: 0x008217CB
		public static byte[] Encrypt(byte[] data, byte[] key)
		{
			if (data.Length == 0)
			{
				return data;
			}
			return XXTEA.ToByteArray(XXTEA.Encrypt(XXTEA.ToUInt32Array(data, true), XXTEA.ToUInt32Array(XXTEA.FixKey(key), false)), false);
		}

		// Token: 0x0601A335 RID: 107317 RVA: 0x008233F5 File Offset: 0x008217F5
		public static byte[] Encrypt(string data, byte[] key)
		{
			return XXTEA.Encrypt(XXTEA.utf8.GetBytes(data), key);
		}

		// Token: 0x0601A336 RID: 107318 RVA: 0x00823408 File Offset: 0x00821808
		public static byte[] Encrypt(byte[] data, string key)
		{
			return XXTEA.Encrypt(data, XXTEA.utf8.GetBytes(key));
		}

		// Token: 0x0601A337 RID: 107319 RVA: 0x0082341B File Offset: 0x0082181B
		public static byte[] Encrypt(string data, string key)
		{
			return XXTEA.Encrypt(XXTEA.utf8.GetBytes(data), XXTEA.utf8.GetBytes(key));
		}

		// Token: 0x0601A338 RID: 107320 RVA: 0x00823438 File Offset: 0x00821838
		public static string EncryptToBase64String(byte[] data, byte[] key)
		{
			return Convert.ToBase64String(XXTEA.Encrypt(data, key));
		}

		// Token: 0x0601A339 RID: 107321 RVA: 0x00823446 File Offset: 0x00821846
		public static string EncryptToBase64String(string data, byte[] key)
		{
			return Convert.ToBase64String(XXTEA.Encrypt(data, key));
		}

		// Token: 0x0601A33A RID: 107322 RVA: 0x00823454 File Offset: 0x00821854
		public static string EncryptToBase64String(byte[] data, string key)
		{
			return Convert.ToBase64String(XXTEA.Encrypt(data, key));
		}

		// Token: 0x0601A33B RID: 107323 RVA: 0x00823462 File Offset: 0x00821862
		public static string EncryptToBase64String(string data, string key)
		{
			return Convert.ToBase64String(XXTEA.Encrypt(data, key));
		}

		// Token: 0x0601A33C RID: 107324 RVA: 0x00823470 File Offset: 0x00821870
		public static byte[] Decrypt(byte[] data, byte[] key)
		{
			if (data.Length == 0)
			{
				return data;
			}
			return XXTEA.ToByteArray(XXTEA.Decrypt(XXTEA.ToUInt32Array(data, false), XXTEA.ToUInt32Array(XXTEA.FixKey(key), false)), true);
		}

		// Token: 0x0601A33D RID: 107325 RVA: 0x0082349A File Offset: 0x0082189A
		public static byte[] Decrypt(byte[] data, string key)
		{
			return XXTEA.Decrypt(data, XXTEA.utf8.GetBytes(key));
		}

		// Token: 0x0601A33E RID: 107326 RVA: 0x008234AD File Offset: 0x008218AD
		public static byte[] DecryptBase64String(string data, byte[] key)
		{
			return XXTEA.Decrypt(Convert.FromBase64String(data), key);
		}

		// Token: 0x0601A33F RID: 107327 RVA: 0x008234BB File Offset: 0x008218BB
		public static byte[] DecryptBase64String(string data, string key)
		{
			return XXTEA.Decrypt(Convert.FromBase64String(data), key);
		}

		// Token: 0x0601A340 RID: 107328 RVA: 0x008234C9 File Offset: 0x008218C9
		public static string DecryptToString(byte[] data, byte[] key)
		{
			return XXTEA.utf8.GetString(XXTEA.Decrypt(data, key));
		}

		// Token: 0x0601A341 RID: 107329 RVA: 0x008234DC File Offset: 0x008218DC
		public static string DecryptToString(byte[] data, string key)
		{
			return XXTEA.utf8.GetString(XXTEA.Decrypt(data, key));
		}

		// Token: 0x0601A342 RID: 107330 RVA: 0x008234EF File Offset: 0x008218EF
		public static string DecryptBase64StringToString(string data, byte[] key)
		{
			return XXTEA.utf8.GetString(XXTEA.DecryptBase64String(data, key));
		}

		// Token: 0x0601A343 RID: 107331 RVA: 0x00823502 File Offset: 0x00821902
		public static string DecryptBase64StringToString(string data, string key)
		{
			return XXTEA.utf8.GetString(XXTEA.DecryptBase64String(data, key));
		}

		// Token: 0x0601A344 RID: 107332 RVA: 0x00823518 File Offset: 0x00821918
		private static uint[] Encrypt(uint[] v, uint[] k)
		{
			int num = v.Length - 1;
			if (num < 1)
			{
				return v;
			}
			uint z = v[num];
			uint num2 = 0U;
			int num3 = 6 + 52 / (num + 1);
			while (0 < num3--)
			{
				num2 += 2654435769U;
				uint e = num2 >> 2 & 3U;
				int i;
				uint y;
				for (i = 0; i < num; i++)
				{
					y = v[i + 1];
					z = (v[i] += XXTEA.MX(num2, y, z, i, e, k));
				}
				y = v[0];
				z = (v[num] += XXTEA.MX(num2, y, z, i, e, k));
			}
			return v;
		}

		// Token: 0x0601A345 RID: 107333 RVA: 0x008235C4 File Offset: 0x008219C4
		public static uint[] Decrypt(uint[] v, uint[] k)
		{
			int num = v.Length - 1;
			if (num < 1)
			{
				return v;
			}
			uint y = v[0];
			int num2 = 6 + 52 / (num + 1);
			for (uint num3 = (uint)((long)num2 * (long)((ulong)-1640531527)); num3 != 0U; num3 -= 2654435769U)
			{
				uint e = num3 >> 2 & 3U;
				int i;
				uint z;
				for (i = num; i > 0; i--)
				{
					z = v[i - 1];
					y = (v[i] -= XXTEA.MX(num3, y, z, i, e, k));
				}
				z = v[num];
				y = (v[0] -= XXTEA.MX(num3, y, z, i, e, k));
			}
			return v;
		}

		// Token: 0x0601A346 RID: 107334 RVA: 0x00823674 File Offset: 0x00821A74
		private static byte[] FixKey(byte[] key)
		{
			if (key.Length == 16)
			{
				return key;
			}
			byte[] array = new byte[16];
			if (key.Length < 16)
			{
				key.CopyTo(array, 0);
			}
			else
			{
				Array.Copy(key, 0, array, 0, 16);
			}
			return array;
		}

		// Token: 0x0601A347 RID: 107335 RVA: 0x008236B8 File Offset: 0x00821AB8
		private static uint[] ToUInt32Array(byte[] data, bool includeLength)
		{
			int num = data.Length;
			int num2 = ((num & 3) != 0) ? ((num >> 2) + 1) : (num >> 2);
			uint[] array;
			if (includeLength)
			{
				array = new uint[num2 + 1];
				array[num2] = (uint)num;
			}
			else
			{
				array = new uint[num2];
			}
			for (int i = 0; i < num; i++)
			{
				array[i >> 2] |= (uint)((uint)data[i] << ((i & 3) << 3));
			}
			return array;
		}

		// Token: 0x0601A348 RID: 107336 RVA: 0x0082372C File Offset: 0x00821B2C
		private static byte[] ToByteArray(uint[] data, bool includeLength)
		{
			int num = data.Length << 2;
			if (includeLength)
			{
				int num2 = (int)data[data.Length - 1];
				num -= 4;
				if (num2 < num - 3 || num2 > num)
				{
					return null;
				}
				num = num2;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (byte)(data[i >> 2] >> ((i & 3) << 3));
			}
			return array;
		}

		// Token: 0x04012671 RID: 75377
		private static readonly UTF8Encoding utf8 = new UTF8Encoding();

		// Token: 0x04012672 RID: 75378
		private const uint delta = 2654435769U;
	}
}
