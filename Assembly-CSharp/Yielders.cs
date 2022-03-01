using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

// Token: 0x02000224 RID: 548
public static class Yielders
{
	// Token: 0x17000216 RID: 534
	// (get) Token: 0x0600123D RID: 4669 RVA: 0x0006343E File Offset: 0x0006183E
	public static WaitForEndOfFrame EndOfFrame
	{
		get
		{
			Yielders._internalCounter++;
			return (!Yielders.Enabled) ? new WaitForEndOfFrame() : Yielders._endOfFrame;
		}
	}

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x0600123E RID: 4670 RVA: 0x00063465 File Offset: 0x00061865
	public static WaitForFixedUpdate FixedUpdate
	{
		get
		{
			Yielders._internalCounter++;
			return (!Yielders.Enabled) ? new WaitForFixedUpdate() : Yielders._fixedUpdate;
		}
	}

	// Token: 0x0600123F RID: 4671 RVA: 0x0006348C File Offset: 0x0006188C
	public static WaitForSeconds GetWaitForSeconds(float seconds)
	{
		Yielders._internalCounter++;
		if (!Yielders.Enabled)
		{
			return new WaitForSeconds(seconds);
		}
		if (Yielders._waitForSecondsYielders == null)
		{
			Yielders._waitForSecondsYielders = new Dictionary<float, WaitForSeconds>();
		}
		WaitForSeconds result;
		if (!Yielders._waitForSecondsYielders.TryGetValue(seconds, out result))
		{
			Yielders._waitForSecondsYielders.Add(seconds, result = new WaitForSeconds(seconds));
		}
		return result;
	}

	// Token: 0x06001240 RID: 4672 RVA: 0x000634F0 File Offset: 0x000618F0
	public static WaitForSecondsRealtime GetWaitForSecondsRealtime(float seconds)
	{
		Yielders._internalCounter++;
		if (!Yielders.Enabled)
		{
			return new WaitForSecondsRealtime(seconds);
		}
		WaitForSecondsRealtime result;
		if (!Yielders._waitForSecondsRealtimeYielders.TryGetValue(seconds, out result))
		{
			Yielders._waitForSecondsRealtimeYielders.Add(seconds, result = new WaitForSecondsRealtime(seconds));
		}
		return result;
	}

	// Token: 0x06001241 RID: 4673 RVA: 0x00063540 File Offset: 0x00061940
	public static void ClearWaitForSeconds()
	{
		Yielders._waitForSecondsYielders.Clear();
	}

	// Token: 0x04000C2D RID: 3117
	public static bool Enabled = true;

	// Token: 0x04000C2E RID: 3118
	public static int _internalCounter = 0;

	// Token: 0x04000C2F RID: 3119
	private static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();

	// Token: 0x04000C30 RID: 3120
	private static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

	// Token: 0x04000C31 RID: 3121
	private static Dictionary<float, WaitForSeconds> _waitForSecondsYielders = new Dictionary<float, WaitForSeconds>(100, new FloatComparer());

	// Token: 0x04000C32 RID: 3122
	private static Dictionary<float, WaitForSecondsRealtime> _waitForSecondsRealtimeYielders = new Dictionary<float, WaitForSecondsRealtime>(100, new FloatComparer());
}
