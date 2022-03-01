using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using behaviac;

// Token: 0x02004583 RID: 17795
public class LogicApplication : Singleton<LogicApplication>
{
	// Token: 0x06018D3F RID: 101695 RVA: 0x007C2A7C File Offset: 0x007C0E7C
	private static void GuardThread()
	{
		for (;;)
		{
			Thread.Sleep(2000);
			string text = string.Empty;
			string text2 = Path.Combine(Directory.GetCurrentDirectory(), "guard.cfg");
			if (File.Exists(text2))
			{
				text = File.ReadAllText(text2);
			}
			else
			{
				Logger.LogErrorFormat("filePath not found {0}", new object[]
				{
					text2
				});
			}
			int num = 0;
			int.TryParse(text, out num);
			if (num == LogicApplication.WRITE_TAG)
			{
				try
				{
					if (File.Exists(text2))
					{
						File.WriteAllText(text2, LogicApplication.zeroStr);
					}
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("WRITE_TAG Save Guard Log {0} is failed reason {1}", new object[]
					{
						text2,
						ex.ToString()
					});
				}
				if (LogicApplication.m_Logics.ContainsKey(LogicApplication.curSessionID))
				{
					LogicServer logicServer = LogicApplication.m_Logics[LogicApplication.curSessionID];
					if (logicServer != null)
					{
						if (logicServer.isEnd())
						{
							Logger.LogErrorFormat("curSessionID is End {0}", new object[]
							{
								LogicApplication.curSessionID
							});
						}
						else if (logicServer.recordServer != null)
						{
							try
							{
								logicServer.recordServer.SaveProcessInBattle();
								logicServer.recordServer.SaveRecordReplayInBattle();
								Logger.LogErrorFormat("curSessionID {0} is Success", new object[]
								{
									LogicApplication.curSessionID
								});
							}
							catch (Exception ex2)
							{
								Logger.LogErrorFormat("curSessionID {0} is Exception :{1}", new object[]
								{
									LogicApplication.curSessionID,
									ex2.ToString()
								});
							}
						}
					}
				}
			}
			else if (num == LogicApplication.CHECK_TAG)
			{
				try
				{
					if (File.Exists(text2))
					{
						File.WriteAllText(text2, LogicApplication.zeroStr);
					}
					Logger.LogErrorFormat("curSessionID is {0}", new object[]
					{
						LogicApplication.curSessionID
					});
				}
				catch (Exception ex3)
				{
					Logger.LogErrorFormat("CHECK_TAG Save Guard Log {0} is failed reason {1}", new object[]
					{
						text2,
						ex3.ToString()
					});
				}
			}
		}
	}

	// Token: 0x06018D40 RID: 101696 RVA: 0x007C2C90 File Offset: 0x007C1090
	public static bool Init()
	{
		bool result;
		try
		{
			LogicServer.LogicServerInit();
			result = true;
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D41 RID: 101697 RVA: 0x007C2CD0 File Offset: 0x007C10D0
	public static void ShowConsumeTime()
	{
	}

	// Token: 0x17002078 RID: 8312
	// (get) Token: 0x06018D42 RID: 101698 RVA: 0x007C2CD2 File Offset: 0x007C10D2
	public static int LogicCount
	{
		get
		{
			return LogicApplication.m_Logics.Count;
		}
	}

	// Token: 0x06018D43 RID: 101699 RVA: 0x007C2CDE File Offset: 0x007C10DE
	public static void DeInit()
	{
		LogicApplication.m_Logics.Clear();
	}

	// Token: 0x06018D44 RID: 101700 RVA: 0x007C2CEA File Offset: 0x007C10EA
	public static void ExceptionCallBack()
	{
		LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("[ExceptionCallBack] : curSessionID {0} occur Error.", LogicApplication.curSessionID));
	}

	// Token: 0x06018D45 RID: 101701 RVA: 0x007C2D08 File Offset: 0x007C1108
	public static void Update(int delta)
	{
		try
		{
			List<ulong> list = new List<ulong>();
			foreach (KeyValuePair<ulong, LogicServer> keyValuePair in LogicApplication.m_Logics)
			{
				LogicServer value = keyValuePair.Value;
				LogicApplication.curSessionID = keyValuePair.Key;
				value.Update(delta);
				if (value.isEnd())
				{
					Logger.LogErrorFormat("race:{0} is end...", new object[]
					{
						value.GetSession()
					});
					list.Add(value.GetSession());
				}
			}
			foreach (ulong id in list)
			{
				LogicApplication.DelLogicInstance(id);
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
		}
	}

	// Token: 0x06018D46 RID: 101702 RVA: 0x007C2E20 File Offset: 0x007C1220
	public static bool StartPVE(ulong s, IntPtr buff, int bufflen)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer != null)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("race({0}) start pve failed, already has this race.", s));
				result = false;
			}
			else
			{
				logicServer = LogicServer.NewGameLogic();
				logicServer.StartPVE(s, buff, bufflen);
				LogicApplication.m_Logics[s] = logicServer;
				result = true;
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D47 RID: 101703 RVA: 0x007C2EA0 File Offset: 0x007C12A0
	public static bool StartPVP(ulong s, IntPtr buff, int bufflen)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer != null)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("race({0}) start pvp failed, already has this race.", s));
				result = false;
			}
			else
			{
				logicServer = LogicServer.NewGameLogic();
				logicServer.StartPVP(s, buff, bufflen);
				LogicApplication.m_Logics[s] = logicServer;
				result = true;
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D48 RID: 101704 RVA: 0x007C2F20 File Offset: 0x007C1320
	public static bool PushFrameCommand(ulong s, IntPtr buff, int bufflen)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("can't find race({0})", s));
				result = false;
			}
			else
			{
				logicServer.PushFrameCommand(buff, bufflen);
				result = true;
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D49 RID: 101705 RVA: 0x007C2F8C File Offset: 0x007C138C
	public static void DumpMemory()
	{
		string text = string.Format("dump-{0}", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
	}

	// Token: 0x06018D4A RID: 101706 RVA: 0x007C2FB8 File Offset: 0x007C13B8
	public static void StartPVPRecord(IntPtr buff, int bufflen)
	{
		LogicServer logicServer = LogicServer.NewGameLogic();
		logicServer.StartPVPRecord(buff, bufflen);
		LogicApplication.m_Logics[logicServer.GetSession()] = logicServer;
	}

	// Token: 0x06018D4B RID: 101707 RVA: 0x007C2FE4 File Offset: 0x007C13E4
	public static void StartPVPRecord(byte[] buff)
	{
		LogicServer logicServer = LogicServer.NewGameLogic();
		logicServer.StartPVPRecord(buff);
		LogicApplication.m_Logics[LogicApplication.s += 1UL] = logicServer;
	}

	// Token: 0x06018D4C RID: 101708 RVA: 0x007C3018 File Offset: 0x007C1418
	public static bool StartPVERecord(byte[] buff)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(LogicApplication.s);
			if (logicServer != null)
			{
				Logger.LogErrorFormat("race({0}) start pve failed, already has this race.", new object[]
				{
					LogicApplication.s
				});
				result = false;
			}
			else
			{
				logicServer = LogicServer.NewGameLogic();
				LogicApplication.m_Logics[LogicApplication.s += 1UL] = logicServer;
				logicServer.StartPVE(LogicApplication.s, buff);
				result = true;
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat(ex.ToString(), new object[0]);
			result = false;
		}
		return result;
	}

	// Token: 0x06018D4D RID: 101709 RVA: 0x007C30B8 File Offset: 0x007C14B8
	public static void GiveUpVerify(ulong s)
	{
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("can't find race({0})", s));
			}
			else
			{
				logicServer.GiveUpVerify();
				LogicApplication.DelLogicInstance(s);
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
		}
	}

	// Token: 0x06018D4E RID: 101710 RVA: 0x007C3120 File Offset: 0x007C1520
	public static uint GetRaceNum()
	{
		return (uint)LogicApplication.m_Logics.Count;
	}

	// Token: 0x06018D4F RID: 101711 RVA: 0x007C312C File Offset: 0x007C152C
	public static bool IsRaceFinish(ulong s)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				result = true;
			}
			else
			{
				result = logicServer.isEnd();
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D50 RID: 101712 RVA: 0x007C3180 File Offset: 0x007C1580
	public static bool IsRunToLastFrame(ulong s)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				result = true;
			}
			else
			{
				result = !logicServer.HaveFrameInQueue();
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x06018D51 RID: 101713 RVA: 0x007C31D8 File Offset: 0x007C15D8
	public static void SaveRecord(ulong s)
	{
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("can't find race({0})", s));
			}
			else
			{
				logicServer.SaveRecord();
			}
		}
		catch (Exception ex)
		{
			LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, ex.ToString());
		}
	}

	// Token: 0x06018D52 RID: 101714 RVA: 0x007C323C File Offset: 0x007C163C
	public static bool HaveFrameInQueue(ulong s)
	{
		bool result;
		try
		{
			LogicServer logicServer = LogicApplication.FindLogicInstance(s);
			if (logicServer == null)
			{
				Logger.LogErrorFormat("can't find race({0})", new object[]
				{
					s
				});
				result = false;
			}
			else
			{
				result = logicServer.HaveFrameInQueue();
			}
		}
		catch (Exception ex)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06018D53 RID: 101715 RVA: 0x007C329C File Offset: 0x007C169C
	protected static LogicServer FindLogicInstance(ulong id)
	{
		LogicServer result;
		LogicApplication.m_Logics.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x06018D54 RID: 101716 RVA: 0x007C32B8 File Offset: 0x007C16B8
	public static void CleanUpWorkSpace()
	{
		if (Workspace.Instance != null)
		{
			Workspace.Instance.Cleanup();
		}
	}

	// Token: 0x06018D55 RID: 101717 RVA: 0x007C32CE File Offset: 0x007C16CE
	protected static void DelLogicInstance(ulong id)
	{
		if (LogicApplication.m_Logics.ContainsKey(id))
		{
			LogicApplication.m_Logics[id] = null;
		}
		LogicApplication.m_Logics.Remove(id);
	}

	// Token: 0x04011E2A RID: 73258
	private static Dictionary<ulong, LogicServer> m_Logics = new Dictionary<ulong, LogicServer>();

	// Token: 0x04011E2B RID: 73259
	private static int WRITE_TAG = 1;

	// Token: 0x04011E2C RID: 73260
	private static int CHECK_TAG = 2;

	// Token: 0x04011E2D RID: 73261
	private static ulong curSessionID = 0UL;

	// Token: 0x04011E2E RID: 73262
	private static string zeroStr = 0.ToString();

	// Token: 0x04011E2F RID: 73263
	private static int curSessionId = -1;

	// Token: 0x04011E30 RID: 73264
	private static ulong s = 0UL;
}
