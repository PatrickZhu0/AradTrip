using System;
using UnityEngine;

// Token: 0x02000E47 RID: 3655
public class HGProfiler
{
	// Token: 0x06009192 RID: 37266 RVA: 0x001AF2F4 File Offset: 0x001AD6F4
	public static void BeginProfiler(string name)
	{
		Singleton<ExceptionManager>.instance.RecordLog(string.Format("BeginProfiler [{0}]", name));
		HGProfiler.stop++;
		if (HGProfiler.stop < 0)
		{
			HGProfiler.stop = 0;
		}
		if (HGProfiler.stop >= 100)
		{
			HGProfiler.stop = 99;
		}
		HGProfiler.profilerData profilerData = HGProfiler.sdata[HGProfiler.stop];
		profilerData.time = Time.realtimeSinceStartup;
		profilerData.name = name;
		HGProfiler.sdata[HGProfiler.stop] = profilerData;
	}

	// Token: 0x06009193 RID: 37267 RVA: 0x001AF384 File Offset: 0x001AD784
	public static void EndProfiler()
	{
		if (HGProfiler.stop <= -1)
		{
			return;
		}
		HGProfiler.profilerData profilerData = HGProfiler.sdata[HGProfiler.stop];
		profilerData.time = Time.realtimeSinceStartup - profilerData.time;
		Singleton<ExceptionManager>.instance.RecordLog(string.Format("[{0}] use time: [{1}]s", profilerData.name, profilerData.time));
		HGProfiler.stop--;
	}

	// Token: 0x040048C6 RID: 18630
	private static float time;

	// Token: 0x040048C7 RID: 18631
	private static string current;

	// Token: 0x040048C8 RID: 18632
	private static HGProfiler.profilerData[] sdata = new HGProfiler.profilerData[100];

	// Token: 0x040048C9 RID: 18633
	private static int stop = -1;

	// Token: 0x02000E48 RID: 3656
	private struct profilerData
	{
		// Token: 0x040048CA RID: 18634
		public float time;

		// Token: 0x040048CB RID: 18635
		public string name;
	}
}
