using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
public class FrameRandom2
{
	// Token: 0x06001287 RID: 4743 RVA: 0x00063DAA File Offset: 0x000621AA
	public static float fRandom()
	{
		return (float)FrameRandom2.Random(65536U) / 65536f;
	}

	// Token: 0x06001288 RID: 4744 RVA: 0x00063DBD File Offset: 0x000621BD
	public static float InRange(float low, float high)
	{
		return FrameRandom2.fRandom() * (high - low) + low;
	}

	// Token: 0x06001289 RID: 4745 RVA: 0x00063DCA File Offset: 0x000621CA
	public static ushort Random(uint nMax)
	{
		FrameRandom2.callNum += 1U;
		FrameRandom2.nSeed = FrameRandom2.nSeed * 1194211693U + 12345U;
		return (ushort)((FrameRandom2.nSeed >> 16) % nMax);
	}

	// Token: 0x0600128A RID: 4746 RVA: 0x00063DF9 File Offset: 0x000621F9
	public static ushort Range100()
	{
		return FrameRandom2.Random(100U) + 1;
	}

	// Token: 0x0600128B RID: 4747 RVA: 0x00063E05 File Offset: 0x00062205
	public static ushort Range1000()
	{
		return FrameRandom2.Random(1000U) + 1;
	}

	// Token: 0x0600128C RID: 4748 RVA: 0x00063E14 File Offset: 0x00062214
	public static int InRange(int low, int high)
	{
		return (int)FrameRandom2.Random((uint)(high - low)) + low;
	}

	// Token: 0x0600128D RID: 4749 RVA: 0x00063E20 File Offset: 0x00062220
	public static int GetSeed()
	{
		return (int)FrameRandom2.nSeed;
	}

	// Token: 0x0600128E RID: 4750 RVA: 0x00063E27 File Offset: 0x00062227
	public static void ChangeSeed()
	{
		FrameRandom2.nSeed = FrameRandom2.nSeed * 1194211693U + 12345U;
	}

	// Token: 0x0600128F RID: 4751 RVA: 0x00063E3F File Offset: 0x0006223F
	public static void ResetSeed(uint seed)
	{
		FrameRandom2.nSeed = seed;
		FrameRandom2.callNum = 0U;
	}

	// Token: 0x04000C41 RID: 3137
	private const uint addValue = 50568701U;

	// Token: 0x04000C42 RID: 3138
	public static uint callNum = 0U;

	// Token: 0x04000C43 RID: 3139
	private const uint maxShort = 16777776U;

	// Token: 0x04000C44 RID: 3140
	private static uint multiper = (uint)UnityEngine.Random.Range(32768, 2147483646);

	// Token: 0x04000C45 RID: 3141
	private static uint nSeed = (uint)UnityEngine.Random.Range(32768, 2147483646);

	// Token: 0x04000C46 RID: 3142
	private static uint maxv1 = (uint)UnityEngine.Random.Range(32768, 2147483646);

	// Token: 0x04000C47 RID: 3143
	private static uint maxv2 = (uint)UnityEngine.Random.Range(32768, 2147483646);
}
