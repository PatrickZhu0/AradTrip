using System;
using System.Text;

// Token: 0x020001EC RID: 492
public class StringHelper
{
	// Token: 0x06000F89 RID: 3977 RVA: 0x0004F57F File Offset: 0x0004D97F
	public static string BytesToString(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes).TrimEnd(StringHelper.default_trim);
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x0004F596 File Offset: 0x0004D996
	public static string BytesToString(string str)
	{
		return str;
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x0004F599 File Offset: 0x0004D999
	public static void ClearFormater()
	{
		StringHelper.Formater.Remove(0, StringHelper.Formater.Length);
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x0004F5B4 File Offset: 0x0004D9B4
	public static bool IsAvailableString(string str)
	{
		int num = 0;
		int i = 0;
		bool flag = false;
		int length = str.Length;
		while (i < length)
		{
			char c = str[i];
			if (flag)
			{
				if (c < '\udc00' || c > '\udfff')
				{
					return false;
				}
				num += 4;
				flag = false;
			}
			else
			{
				if (c < '\u0080')
				{
					while (i < length)
					{
						if (str[i] >= '\u0080')
						{
							break;
						}
						num++;
						i++;
					}
					continue;
				}
				if (c < 'ࠀ')
				{
					num += 2;
				}
				else if (c >= '\ud800' && c <= '\udbff')
				{
					flag = true;
				}
				else
				{
					if (c >= '\udc00' && c <= '\udfff')
					{
						return false;
					}
					num += 3;
				}
			}
			i++;
		}
		return true;
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x0004F6A4 File Offset: 0x0004DAA4
	public static void StringToUTF8Bytes(string str, ref byte[] buffer)
	{
		if (str != null && buffer != null)
		{
			if (!str.EndsWith("\0"))
			{
				str += "\0";
			}
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			int count = (bytes.Length > buffer.Length) ? buffer.Length : bytes.Length;
			Buffer.BlockCopy(bytes, 0, buffer, 0, count);
			buffer[buffer.Length - 1] = 0;
		}
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x0004F718 File Offset: 0x0004DB18
	public static byte[] StringToUTF8Bytes(string str)
	{
		if (str != null)
		{
			if (!str.EndsWith("\0"))
			{
				str += "\0";
			}
			return Encoding.UTF8.GetBytes(str);
		}
		return null;
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x0004F758 File Offset: 0x0004DB58
	public static void StringToUTF8Bytes(string str, ref sbyte[] buffer)
	{
		if (str != null && buffer != null)
		{
			if (!str.EndsWith("\0"))
			{
				str += "\0";
			}
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			int count = (bytes.Length > buffer.Length) ? buffer.Length : bytes.Length;
			Buffer.BlockCopy(bytes, 0, buffer, 0, count);
			buffer[buffer.Length - 1] = 0;
		}
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x0004F7CC File Offset: 0x0004DBCC
	public static string UTF8BytesToString(ref byte[] str)
	{
		string result;
		try
		{
			result = ((str != null) ? Encoding.UTF8.GetString(str).TrimEnd(new char[1]) : null);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000F91 RID: 3985 RVA: 0x0004F81C File Offset: 0x0004DC1C
	public static string UTF8BytesToString(ref string str)
	{
		return str;
	}

	// Token: 0x04000AC2 RID: 2754
	public static StringBuilder Formater = new StringBuilder(1024);

	// Token: 0x04000AC3 RID: 2755
	protected static readonly char[] default_trim = new char[1];
}
