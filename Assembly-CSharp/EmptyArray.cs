using System;

// Token: 0x02004BE0 RID: 19424
internal static class EmptyArray<T>
{
	// Token: 0x0601C791 RID: 116625 RVA: 0x0089F8F8 File Offset: 0x0089DCF8
	public static T[] Empty()
	{
		return EmptyArray<T>.skIns;
	}

	// Token: 0x04013B0E RID: 80654
	private static T[] skIns = new T[0];
}
