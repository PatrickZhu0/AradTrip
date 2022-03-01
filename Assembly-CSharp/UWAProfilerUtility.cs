using System;
using System.Diagnostics;
using System.Reflection;

// Token: 0x0200473C RID: 18236
public static class UWAProfilerUtility
{
	// Token: 0x17002252 RID: 8786
	// (get) Token: 0x0601A323 RID: 107299 RVA: 0x008231CC File Offset: 0x008215CC
	private static object MonoDumpHelper
	{
		get
		{
			if (UWAProfilerUtility.skDumpHelper == null)
			{
				Type uwaCoreType = UWAProfilerUtility.GetUwaCoreType("UWALocal.MonoTrackManager");
				FieldInfo field = uwaCoreType.GetField("DumpHelper");
				UWAProfilerUtility.skDumpHelper = field.GetValue(null);
			}
			return UWAProfilerUtility.skDumpHelper;
		}
	}

	// Token: 0x17002253 RID: 8787
	// (set) Token: 0x0601A324 RID: 107300 RVA: 0x0082320C File Offset: 0x0082160C
	public static bool MonoDumpHelperIsAuto
	{
		set
		{
			if (UWAProfilerUtility.skDumpHelperIsAuto == null)
			{
				Type type = UWAProfilerUtility.MonoDumpHelper.GetType();
				UWAProfilerUtility.skDumpHelperIsAuto = type.GetField("AutoDump");
			}
			UWAProfilerUtility.skDumpHelperIsAuto.SetValue(UWAProfilerUtility.MonoDumpHelper, (!value) ? UWAProfilerUtility.skFalse : UWAProfilerUtility.skTrue);
		}
	}

	// Token: 0x17002254 RID: 8788
	// (set) Token: 0x0601A325 RID: 107301 RVA: 0x00823264 File Offset: 0x00821664
	private static bool MonoDumpHelperIsWait2Dump
	{
		set
		{
			if (UWAProfilerUtility.skDumpHelperIsWait2Dump == null)
			{
				Type type = UWAProfilerUtility.MonoDumpHelper.GetType();
				UWAProfilerUtility.skDumpHelperIsWait2Dump = type.GetField("WaitToDump");
			}
			UWAProfilerUtility.skDumpHelperIsWait2Dump.SetValue(UWAProfilerUtility.MonoDumpHelper, (!value) ? UWAProfilerUtility.skFalse : UWAProfilerUtility.skTrue);
		}
	}

	// Token: 0x17002255 RID: 8789
	// (get) Token: 0x0601A326 RID: 107302 RVA: 0x008232BA File Offset: 0x008216BA
	private static Assembly UwaCoreAssembly
	{
		get
		{
			if (UWAProfilerUtility.skUwaCoreAssembly == null)
			{
				UWAProfilerUtility.skUwaCoreAssembly = UWAProfilerUtility._FindAssembly("UWALocalCore", "UWALocal.UwaProfiler");
			}
			return UWAProfilerUtility.skUwaCoreAssembly;
		}
	}

	// Token: 0x0601A327 RID: 107303 RVA: 0x008232E0 File Offset: 0x008216E0
	private static Assembly _FindAssembly(string assetname, string typename)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly[] array = assemblies;
		foreach (Assembly assembly in array)
		{
			if (assembly.GetType(typename) != null && assembly.FullName.ToLower().Contains(assetname.ToLower()))
			{
				return assembly;
			}
		}
		return null;
	}

	// Token: 0x0601A328 RID: 107304 RVA: 0x00823343 File Offset: 0x00821743
	private static Type GetUwaCoreType(string typename)
	{
		return UWAProfilerUtility._GetAssType(UWAProfilerUtility.UwaCoreAssembly, typename);
	}

	// Token: 0x0601A329 RID: 107305 RVA: 0x00823350 File Offset: 0x00821750
	private static Type _GetAssType(Assembly ass, string typename)
	{
		if (ass == null)
		{
			return null;
		}
		return ass.GetType(typename);
	}

	// Token: 0x0601A32A RID: 107306 RVA: 0x00823361 File Offset: 0x00821761
	[Conditional("ENABLE_PROFILER")]
	public static void DoDump()
	{
	}

	// Token: 0x0601A32B RID: 107307 RVA: 0x00823363 File Offset: 0x00821763
	[Conditional("ENABLE_PROFILER")]
	public static void Mark(string tag)
	{
	}

	// Token: 0x0601A32C RID: 107308 RVA: 0x00823365 File Offset: 0x00821765
	[Conditional("ENABLE_PROFILER")]
	public static void LogValue(string tag, int v)
	{
	}

	// Token: 0x0601A32D RID: 107309 RVA: 0x00823367 File Offset: 0x00821767
	[Conditional("ENABLE_PROFILER")]
	public static void LogValue(string tag, bool v)
	{
	}

	// Token: 0x0601A32E RID: 107310 RVA: 0x00823369 File Offset: 0x00821769
	[Conditional("ENABLE_PROFILER")]
	public static void LogValue(string tag, float v)
	{
	}

	// Token: 0x0401266A RID: 75370
	private const string skUwaProfilerProfiler = "UWALocal.UwaProfiler";

	// Token: 0x0401266B RID: 75371
	private static Assembly skUwaCoreAssembly = null;

	// Token: 0x0401266C RID: 75372
	private static object skDumpHelper = null;

	// Token: 0x0401266D RID: 75373
	private static FieldInfo skDumpHelperIsAuto = null;

	// Token: 0x0401266E RID: 75374
	private static object skTrue = true;

	// Token: 0x0401266F RID: 75375
	private static object skFalse = false;

	// Token: 0x04012670 RID: 75376
	private static FieldInfo skDumpHelperIsWait2Dump = null;
}
