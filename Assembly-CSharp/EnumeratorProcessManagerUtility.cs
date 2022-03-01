using System;
using System.Reflection;
using UnityEngine;

// Token: 0x02000E3A RID: 3642
public class EnumeratorProcessManagerUtility
{
	// Token: 0x0600915B RID: 37211 RVA: 0x001AE7E4 File Offset: 0x001ACBE4
	public static int GetWaitForMS(WaitForSeconds t)
	{
		float num = 0f;
		try
		{
			num = (float)EnumeratorProcessManagerUtility.info.GetValue(t);
		}
		catch
		{
			num = 0f;
		}
		return (int)(num * 1000f);
	}

	// Token: 0x0400488E RID: 18574
	private static Type type = typeof(WaitForSeconds);

	// Token: 0x0400488F RID: 18575
	private static FieldInfo info = EnumeratorProcessManagerUtility.type.GetField("m_Seconds", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
}
