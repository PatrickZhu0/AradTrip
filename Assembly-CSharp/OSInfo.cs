using System;
using UnityEngine;

// Token: 0x020001D9 RID: 473
public class OSInfo
{
	// Token: 0x06000F14 RID: 3860 RVA: 0x0004CF80 File Offset: 0x0004B380
	public static AndroidAPILevel GetAndroidOSAPILevel()
	{
		string operatingSystem = SystemInfo.operatingSystem;
		Debug.Log("### Operating System:" + operatingSystem);
		if (!operatingSystem.Contains("Android OS", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.None;
		}
		if (operatingSystem.Contains("API-16", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_16;
		}
		if (operatingSystem.Contains("API-17", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_17;
		}
		if (operatingSystem.Contains("API-18", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_18;
		}
		if (operatingSystem.Contains("API-19", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_19;
		}
		if (operatingSystem.Contains("API-21", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_21;
		}
		if (operatingSystem.Contains("API-22", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_22;
		}
		if (operatingSystem.Contains("API-23", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_23;
		}
		if (operatingSystem.Contains("API-24", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_24;
		}
		if (operatingSystem.Contains("API-25", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_25;
		}
		if (operatingSystem.Contains("API-26", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_26;
		}
		if (operatingSystem.Contains("API-27", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_27;
		}
		if (operatingSystem.Contains("API-28", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_28;
		}
		if (operatingSystem.Contains("API-29", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_29;
		}
		if (operatingSystem.Contains("API-30", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_30;
		}
		if (operatingSystem.Contains("API-31", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_31;
		}
		if (operatingSystem.Contains("API-32", StringComparison.OrdinalIgnoreCase))
		{
			return AndroidAPILevel.Level_32;
		}
		return AndroidAPILevel.None;
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x0004D0F8 File Offset: 0x0004B4F8
	public static int GetSysMemorySize()
	{
		int systemMemorySize = SystemInfo.systemMemorySize;
		Debug.Log("### System Memory Size:" + systemMemorySize);
		return systemMemorySize;
	}
}
