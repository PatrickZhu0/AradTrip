using System;

namespace PathFinder
{
	// Token: 0x020001DE RID: 478
	public static class MathExtra
	{
		// Token: 0x06000F34 RID: 3892 RVA: 0x0004DD64 File Offset: 0x0004C164
		public static float FastSqrt(float x)
		{
			float num = x * 0.5f;
			float num2 = x;
			int num3 = (int)num2;
			num3 = 1597463174 - (num3 >> 1);
			num2 = (float)num3;
			num2 *= 1.5f - num * num2 * num2;
			return x * num2;
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0004DDA0 File Offset: 0x0004C1A0
		public static float InverseSqrtFast(float x)
		{
			float num = 0.5f * x;
			int num2 = (int)x;
			num2 = 1597463174 - (num2 >> 1);
			x = (float)num2;
			x *= 1.5f - num * x * x;
			return x;
		}
	}
}
