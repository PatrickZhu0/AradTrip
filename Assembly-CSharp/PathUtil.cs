using System;

// Token: 0x020000F1 RID: 241
public class PathUtil
{
	// Token: 0x06000500 RID: 1280 RVA: 0x00021F80 File Offset: 0x00020380
	public static string EraseExtension(string fullName)
	{
		if (fullName == null)
		{
			return null;
		}
		int num = fullName.LastIndexOf('.');
		if (num > 0 && fullName.Substring(num, fullName.Length - num) != ".lua")
		{
			return fullName.Substring(0, num);
		}
		return fullName;
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00021FD0 File Offset: 0x000203D0
	public static string GetExtension(string fullName)
	{
		int num = fullName.LastIndexOf('.');
		if (num > 0 && num + 1 < fullName.Length)
		{
			return fullName.Substring(num);
		}
		return string.Empty;
	}
}
