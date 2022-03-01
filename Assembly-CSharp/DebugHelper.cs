using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

// Token: 0x0200011A RID: 282
public class DebugHelper : MonoBehaviour
{
	// Token: 0x06000635 RID: 1589 RVA: 0x00025A8D File Offset: 0x00023E8D
	public static void Assert(bool InCondition)
	{
		DebugHelper.Assert(InCondition, null, null);
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x00025A97 File Offset: 0x00023E97
	public static void Assert(bool InCondition, string InFormat)
	{
		DebugHelper.Assert(InCondition, InFormat, null);
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x00025AA4 File Offset: 0x00023EA4
	public static void Assert(bool InCondition, string InFormat, params object[] InParameters)
	{
		if (!InCondition)
		{
			try
			{
				string text = null;
				if (!string.IsNullOrEmpty(InFormat))
				{
					try
					{
						if (InParameters != null)
						{
							text = string.Format(InFormat, InParameters);
						}
						else
						{
							text = InFormat;
						}
					}
					catch (Exception)
					{
					}
				}
				else
				{
					text = string.Format(" no detail, but stacktrace is :{0}", Environment.StackTrace);
				}
				if (text != null)
				{
					string str = "Assert failed! " + text;
					DebugHelper.CrashAttchLog(str);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x00025B40 File Offset: 0x00023F40
	private void Awake()
	{
		DebugHelper.Assert(DebugHelper.instance == null);
		DebugHelper.instance = this;
		DebugHelper.logMode = this.cfgMode;
		int num = 4;
		for (int i = 0; i < num; i++)
		{
			DebugHelper.s_logers[i] = new SLogObj();
		}
		DebugHelper.OpenLoger(SLogCategory.Normal, string.Format("{0}/sgame_log.txt", Application.persistentDataPath));
		DebugHelper.OpenLoger(SLogCategory.Skill, string.Format("{0}/sgame_skill.txt", Application.persistentDataPath));
		DebugHelper.OpenLoger(SLogCategory.Misc, string.Format("{0}/sgame_misc.txt", Application.persistentDataPath));
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x00025BCD File Offset: 0x00023FCD
	[Conditional("UNITY_EDITOR")]
	public static void ClearConsole()
	{
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x00025BD0 File Offset: 0x00023FD0
	public static void CloseLoger(SLogCategory logType)
	{
		DebugHelper.s_logers[(int)logType].Flush();
		DebugHelper.s_logers[(int)logType].Close();
		DebugHelper.s_logers[(int)logType].TargetPath = null;
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x00025C04 File Offset: 0x00024004
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_LOG")]
	public static void ConsoleLog(string logmsg)
	{
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x00025C06 File Offset: 0x00024006
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_LOG")]
	public static void ConsoleLogError(string logmsg)
	{
		Logger.LogError(logmsg);
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x00025C0E File Offset: 0x0002400E
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_EDITOR")]
	public static void ConsoleLogWarning(string logmsg)
	{
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x00025C10 File Offset: 0x00024010
	[Conditional("UNITY_ANDROID")]
	public static void CrashAttchLog(string str)
	{
		string text = "com.tencent.tmgp.sgame.SGameUtility";
		AndroidJavaClass androidJavaClass = new AndroidJavaClass(text);
		object[] array = new object[]
		{
			str
		};
		androidJavaClass.CallStatic("dtLog", array);
		androidJavaClass.Dispose();
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x00025C47 File Offset: 0x00024047
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_EDITOR")]
	public static void EditorAssert(bool InCondition, string InFormat = null, params object[] InParameters)
	{
		DebugHelper.Assert(InCondition, InFormat, InParameters);
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x00025C51 File Offset: 0x00024051
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_LOG")]
	public static void Log(string logmsg)
	{
		if (DebugHelper.logMode == SLogTypeDef.LogType_Custom && string.IsNullOrEmpty(DebugHelper.s_logers[0].TargetPath))
		{
			DebugHelper.OpenLoger(SLogCategory.Normal, string.Format("{0}/sgame_log.txt", Application.persistentDataPath));
		}
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x00025C89 File Offset: 0x00024089
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("UNITY_EDITOR")]
	public static void LogError(string errmsg)
	{
		Logger.LogError(errmsg);
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x00025C91 File Offset: 0x00024091
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("UNITY_STANDALONE_WIN")]
	public static void LogInternal(SLogCategory logType, string logmsg)
	{
		DebugHelper.s_logers[(int)logType].Log(logmsg);
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x00025CA0 File Offset: 0x000240A0
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_STANDALONE_WIN")]
	public static void LogMisc(string logmsg)
	{
		if (DebugHelper.logMode != SLogTypeDef.LogType_System && DebugHelper.logMode == SLogTypeDef.LogType_Custom && string.IsNullOrEmpty(DebugHelper.s_logers[3].TargetPath))
		{
			DebugHelper.OpenLoger(SLogCategory.Misc, string.Format("{0}/sgame_misc.txt", Application.persistentDataPath));
		}
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x00025CF0 File Offset: 0x000240F0
	[Conditional("UNITY_STANDALONE_WIN")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_LOG")]
	public static void LogSkill(string logmsg)
	{
		if (DebugHelper.logMode != SLogTypeDef.LogType_System && DebugHelper.logMode == SLogTypeDef.LogType_Custom && string.IsNullOrEmpty(DebugHelper.s_logers[1].TargetPath))
		{
			DebugHelper.OpenLoger(SLogCategory.Skill, string.Format("{0}/sgame_skill.txt", Application.persistentDataPath));
		}
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x00025D3E File Offset: 0x0002413E
	[Conditional("FORCE_LOG")]
	[Conditional("UNITY_EDITOR")]
	[Conditional("UNITY_STANDALONE_WIN")]
	public static void LogWarning(string warmsg)
	{
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x00025D40 File Offset: 0x00024140
	protected void OnDestroy()
	{
		int num = 4;
		for (int i = 0; i < num; i++)
		{
			DebugHelper.s_logers[i].Flush();
			DebugHelper.s_logers[i].Close();
		}
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x00025D7C File Offset: 0x0002417C
	public static void OpenLoger(SLogCategory logType, string logFile)
	{
		DebugHelper.s_logers[(int)logType].Flush();
		DebugHelper.s_logers[(int)logType].Close();
		DebugHelper.s_logers[(int)logType].TargetPath = logFile;
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000648 RID: 1608 RVA: 0x00025DB0 File Offset: 0x000241B0
	public static string logRootPath
	{
		get
		{
			if (DebugHelper.CachedLogRootPath == null)
			{
				string text = string.Format("{0}/Replay/", Application.persistentDataPath);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				DebugHelper.CachedLogRootPath = text;
			}
			return DebugHelper.CachedLogRootPath;
		}
	}

	// Token: 0x04000515 RID: 1301
	private static string CachedLogRootPath;

	// Token: 0x04000516 RID: 1302
	public SLogTypeDef cfgMode = SLogTypeDef.LogType_System;

	// Token: 0x04000517 RID: 1303
	private static DebugHelper instance = null;

	// Token: 0x04000518 RID: 1304
	private static SLogTypeDef logMode = SLogTypeDef.LogType_Custom;

	// Token: 0x04000519 RID: 1305
	private static SLogObj[] s_logers = new SLogObj[4];

	// Token: 0x0400051A RID: 1306
	public static string timeTag;
}
