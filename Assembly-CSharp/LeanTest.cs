using System;
using UnityEngine;

// Token: 0x020001A0 RID: 416
public class LeanTest
{
	// Token: 0x06000D0A RID: 3338 RVA: 0x000410CC File Offset: 0x0003F4CC
	public static void debug(string name, bool didPass, string failExplaination = null)
	{
		float num = LeanTest.printOutLength(name);
		int totalWidth = 40 - (int)(num * 1.05f);
		string text = string.Empty.PadRight(totalWidth, "_"[0]);
		string[] values = new string[]
		{
			LeanTest.formatB(name),
			" ",
			text,
			" [ ",
			didPass ? LeanTest.formatC("pass", "green") : LeanTest.formatC("fail", "red"),
			" ]"
		};
		string text2 = string.Concat(values);
		if (!didPass && failExplaination != null)
		{
			text2 = text2 + " - " + failExplaination;
		}
		Debug.Log(text2);
		if (didPass)
		{
			LeanTest.passes++;
		}
		LeanTest.tests++;
		if (LeanTest.tests == LeanTest.expected)
		{
			Debug.Log(string.Concat(new string[]
			{
				LeanTest.formatB("Final Report:"),
				" _____________________ PASSED: ",
				LeanTest.formatBC(string.Empty + LeanTest.passes, "green"),
				" FAILED: ",
				LeanTest.formatBC(string.Empty + (LeanTest.tests - LeanTest.passes), "red"),
				" "
			}));
		}
		else if (LeanTest.tests > LeanTest.expected)
		{
			Debug.Log(LeanTest.formatB("Too many tests for a final report!") + " set LeanTest.expected = " + LeanTest.tests);
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00041266 File Offset: 0x0003F666
	public static string formatB(string str)
	{
		return "<b>" + str + "</b>";
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x00041278 File Offset: 0x0003F678
	public static string formatBC(string str, string color)
	{
		return LeanTest.formatC(LeanTest.formatB(str), color);
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00041288 File Offset: 0x0003F688
	public static string formatC(string str, string color)
	{
		string[] values = new string[]
		{
			"<color=",
			color,
			">",
			str,
			"</color>"
		};
		return string.Concat(values);
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x000412C2 File Offset: 0x0003F6C2
	public static void overview()
	{
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x000412C4 File Offset: 0x0003F6C4
	public static string padRight(int len)
	{
		string text = string.Empty;
		for (int i = 0; i < len; i++)
		{
			text += "_";
		}
		return text;
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x000412F8 File Offset: 0x0003F6F8
	public static float printOutLength(string str)
	{
		float num = 0f;
		for (int i = 0; i < str.Length; i++)
		{
			if (str[i] == "I"[0])
			{
				num += 0.5f;
			}
			else if (str[i] == "J"[0])
			{
				num += 0.85f;
			}
			else
			{
				num += 1f;
			}
		}
		return num;
	}

	// Token: 0x04000908 RID: 2312
	public static int expected;

	// Token: 0x04000909 RID: 2313
	private static int passes;

	// Token: 0x0400090A RID: 2314
	private static int tests;
}
