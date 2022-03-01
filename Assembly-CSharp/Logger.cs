using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200014B RID: 331
public class Logger
{
	// Token: 0x06000984 RID: 2436 RVA: 0x0003217F File Offset: 0x0003057F
	internal static void Log(string v1, float v2)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x00032186 File Offset: 0x00030586
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_ERROR")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void Init()
	{
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x00032188 File Offset: 0x00030588
	[Conditional("LOG_DIALOG")]
	[Conditional("UNITY_ANDROID")]
	[Conditional("UNITY_IOS")]
	[Conditional("LOG_ERROR")]
	public static void DisplayLog(string info, UnityAction onOKCallBack = null)
	{
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0003218C File Offset: 0x0003058C
	[Conditional("UNITY_EDITOR")]
	public static void EditorLogWarning(string str, params object[] args)
	{
		string empty = string.Empty;
		Debug.LogWarningFormat(Logger._formatString(3, str, args), new object[0]);
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x000321B4 File Offset: 0x000305B4
	[Conditional("LOG_DIALOG")]
	public static void MessageBox(string info, UnityAction onOKCallBack = null)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		GameObject gameObject = Utility.FindGameObject("AlertBoxCanvas", false);
		if (gameObject == null)
		{
			gameObject = new GameObject("AlertBoxCanvas", new Type[]
			{
				typeof(RectTransform),
				typeof(Canvas),
				typeof(CanvasScaler),
				typeof(GraphicRaycaster)
			});
			gameObject.GetComponent<Canvas>().renderMode = 0;
			gameObject.GetComponent<CanvasScaler>().uiScaleMode = 1;
			gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920f, 1080f);
			gameObject.transform.SetAsLastSibling();
		}
		GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Base/UI/Prefabs/BaseMsgBoxOK", true, 0U);
		Utility.AttachTo(gameObject2, gameObject, false);
		if (onOKCallBack != null)
		{
			Button button = Utility.FindComponent<Button>(gameObject2, "loading/Panel/button", false);
			button.onClick.AddListener(onOKCallBack);
		}
		gameObject2.GetComponent<AlertBox>().SetMessage(info);
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x000322B0 File Offset: 0x000306B0
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_DIALOG")]
	[Conditional("LOG_ERROR")]
	public static void ShowDailog(string str, params object[] args)
	{
		string empty = string.Empty;
		string arg = string.Format(str, args).TrimEnd(new char[0]);
		Logger.DisplayLog(string.Format("{0}\n{1}", arg, empty), null);
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x000322E8 File Offset: 0x000306E8
	private static string _formatString(LogType type, string str, params object[] args)
	{
		string str2 = string.Format(str, args);
		return str2 + "\n";
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x00032308 File Offset: 0x00030708
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_NORMAL")]
	public static void Log(string str)
	{
		string empty = string.Empty;
		Debug.LogFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(3, str, new object[0])
		});
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x00032340 File Offset: 0x00030740
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_NORMAL")]
	public static void LogFormat(string str, params object[] args)
	{
		string empty = string.Empty;
		Debug.LogFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(3, str, args)
		});
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x00032374 File Offset: 0x00030774
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void LogWarning(string str)
	{
		string empty = string.Empty;
		Debug.LogWarningFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(2, str, new object[0])
		});
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x000323AC File Offset: 0x000307AC
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void LogWarningFormat(string str, params object[] args)
	{
		string empty = string.Empty;
		Debug.LogWarningFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(2, str, args)
		});
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x000323E0 File Offset: 0x000307E0
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_PROCESS")]
	public static void LogProcessFormat(string str, params object[] args)
	{
		string empty = string.Empty;
		Debug.LogWarningFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(2, str, args)
		});
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x00032414 File Offset: 0x00030814
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_ERROR")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void LogErrorCode(uint error)
	{
		string empty = string.Empty;
		string str = Utility.ProtocolErrorString(error);
		Debug.LogErrorFormat("{0} {1}", new object[]
		{
			empty,
			Logger._formatString(0, str, new object[0])
		});
		Logger.ShowDailog(str, new object[0]);
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x00032460 File Offset: 0x00030860
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_ERROR")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void LogError(string str)
	{
		string text = string.Empty;
		text = string.Format("[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"), str);
		Debug.LogError(text);
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x00032498 File Offset: 0x00030898
	[Conditional("WORK_DEBUG")]
	[Conditional("LOG_ERROR")]
	[Conditional("LOG_WARNNING")]
	[Conditional("LOG_NORMAL")]
	public static void LogErrorFormat(string str, params object[] args)
	{
		string text = string.Empty;
		text = string.Format("[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"), str);
		Debug.LogErrorFormat(text, args);
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x000324D0 File Offset: 0x000308D0
	[Conditional("LOG_ASSET")]
	public static void LogAsset(string str)
	{
		string empty = string.Empty;
		LogType logType = 2;
		if (logType != 3)
		{
			if (logType != 2)
			{
				if (logType == null)
				{
					Debug.LogErrorFormat("{0} {1}", new object[]
					{
						empty,
						Logger._formatString(logType, str, new object[0])
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("{0} {1}", new object[]
				{
					empty,
					Logger._formatString(logType, str, new object[0])
				});
			}
		}
		else
		{
			Debug.LogFormat("{0} {1}", new object[]
			{
				empty,
				Logger._formatString(logType, str, new object[0])
			});
		}
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0003257C File Offset: 0x0003097C
	[Conditional("LOG_ASSET")]
	public static void LogAssetFormat(string str, params object[] args)
	{
		string empty = string.Empty;
		LogType logType = 2;
		if (logType != 3)
		{
			if (logType != 2)
			{
				if (logType == null)
				{
					Debug.LogErrorFormat("{0} {1}", new object[]
					{
						empty,
						Logger._formatString(logType, str, args)
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("{0} {1}", new object[]
				{
					empty,
					Logger._formatString(logType, str, args)
				});
			}
		}
		else
		{
			Debug.LogFormat("{0} {1}", new object[]
			{
				empty,
				Logger._formatString(logType, str, args)
			});
		}
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x00032618 File Offset: 0x00030A18
	[Conditional("LOG_PROFILE")]
	public static void LogProfile(string str)
	{
		string empty = string.Empty;
		LogType logType = 2;
		if (logType != 3)
		{
			if (logType != 2)
			{
				if (logType == null)
				{
					Debug.LogErrorFormat("{0} {1}", new object[]
					{
						empty,
						Logger._formatString(logType, str, new object[0])
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("{0} {1}", new object[]
				{
					empty,
					Logger._formatString(logType, str, new object[0])
				});
			}
		}
		else
		{
			Debug.LogFormat("{0} {1}", new object[]
			{
				empty,
				Logger._formatString(logType, str, new object[0])
			});
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x000326C4 File Offset: 0x00030AC4
	[Conditional("LOG_PROFILE")]
	public static void LogProfileFormat(string str, params object[] args)
	{
		string empty = string.Empty;
		LogType logType = 2;
		if (logType != 3)
		{
			if (logType != 2)
			{
				if (logType == null)
				{
					Debug.LogErrorFormat("{0} {1}", new object[]
					{
						empty,
						Logger._formatString(logType, str, args)
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("{0} {1}", new object[]
				{
					empty,
					Logger._formatString(logType, str, args)
				});
			}
		}
		else
		{
			Debug.LogFormat("{0} {1}", new object[]
			{
				empty,
				Logger._formatString(logType, str, args)
			});
		}
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0003275E File Offset: 0x00030B5E
	[Conditional("WORK_DEBUG")]
	public static void Break()
	{
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x00032760 File Offset: 0x00030B60
	[Conditional("WORK_DEBUG")]
	public static void LogForNet(string str, params object[] args)
	{
		Debug.LogWarningFormat(str, args);
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x00032769 File Offset: 0x00030B69
	[Conditional("WORK_DEBUG")]
	public static void LogForAI(string str, params object[] args)
	{
		if (!BeAIManager.logerror)
		{
			return;
		}
		Debug.LogErrorFormat(str, args);
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x0003277D File Offset: 0x00030B7D
	public static void LogForReplay(string str, params object[] args)
	{
		if (!Global.Settings.isLogRecord)
		{
			return;
		}
		Debug.LogErrorFormat(str, args);
	}

	// Token: 0x04000737 RID: 1847
	public static bool enable = false;

	// Token: 0x04000738 RID: 1848
	private static string[] sColorList = new string[]
	{
		"#C7301CFF",
		"#EAB101FF",
		"#EAB101FF",
		"#B0B0B0FF",
		"#EAB101FF"
	};

	// Token: 0x0200014C RID: 332
	private class LoggerUnit
	{
		// Token: 0x0600099D RID: 2461 RVA: 0x000327D9 File Offset: 0x00030BD9
		public static void _loadRegex()
		{
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000327DC File Offset: 0x00030BDC
		private static void _loadAttribute()
		{
			Logger.LoggerUnit.mTypeModeDict.Clear();
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type type in assembly.GetTypes())
				{
					string key = type.ToString();
					LoggerModelAttribute[] array = type.GetCustomAttributes(typeof(LoggerModelAttribute), true) as LoggerModelAttribute[];
					if (array.Length > 0)
					{
						foreach (LoggerModelAttribute loggerModelAttribute in array)
						{
							if (!Logger.LoggerUnit.mTypeModeDict.ContainsKey(key))
							{
								Logger.LoggerUnit.mTypeModeDict.Add(key, loggerModelAttribute.mName);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000328B4 File Offset: 0x00030CB4
		public static void Init()
		{
			Logger.LoggerUnit._loadAttribute();
			Logger.LoggerUnit._loadRegex();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000328C0 File Offset: 0x00030CC0
		private static bool _regexMatch()
		{
			return true;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000328C4 File Offset: 0x00030CC4
		private static string _formatTag()
		{
			return string.Format("[{0}] [{1} {2}({3})]", new object[]
			{
				DateTime.Now.ToString("yy/MM/dd hh:mm:ss"),
				Logger.LoggerUnit.sMethmodName,
				Logger.LoggerUnit.sFileName,
				Logger.LoggerUnit.sLineNumber
			});
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00032913 File Offset: 0x00030D13
		private static string _formatModel()
		{
			return string.Format("[{0} {1}]", Logger.LoggerUnit.sClassName, Logger.LoggerUnit.sModelName);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0003292C File Offset: 0x00030D2C
		public static bool GetTag(ref string output, bool withAllStack = false, int offset = 2)
		{
			StackTrace stackTrace = new StackTrace(true);
			if (stackTrace.FrameCount < offset + 1)
			{
				return false;
			}
			bool flag = true;
			int i = offset;
			while (i < stackTrace.FrameCount)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				Logger.LoggerUnit.sFileName = Path.GetFileName(frame.GetFileName());
				if (Logger.LoggerUnit.sFileName == null)
				{
					Logger.LoggerUnit.sFileName = frame.GetFileName();
				}
				Logger.LoggerUnit.sMethmodName = frame.GetMethod().Name;
				Logger.LoggerUnit.sLineNumber = frame.GetFileLineNumber();
				if (!withAllStack)
				{
					Logger.LoggerUnit.sClassName = frame.GetMethod().DeclaringType.ToString();
					Logger.LoggerUnit.sModelName = Logger.LoggerUnit.sClassName;
					if (Logger.LoggerUnit.mTypeModeDict.ContainsKey(Logger.LoggerUnit.sClassName))
					{
						Logger.LoggerUnit.sModelName = Logger.LoggerUnit.mTypeModeDict[Logger.LoggerUnit.sClassName];
					}
					else
					{
						Logger.LoggerUnit.sModelName = "_other";
					}
					if (!Logger.LoggerUnit._regexMatch())
					{
						return false;
					}
					output = string.Format("{0} {1}", Logger.LoggerUnit._formatTag(), Logger.LoggerUnit._formatModel());
					break;
				}
				else
				{
					if (flag)
					{
						output = Logger.LoggerUnit._formatTag();
						flag = false;
					}
					else
					{
						output = string.Format("{0}\n{1}", output, Logger.LoggerUnit._formatTag());
					}
					i++;
				}
			}
			return true;
		}

		// Token: 0x04000739 RID: 1849
		private static string sMethmodName;

		// Token: 0x0400073A RID: 1850
		private static string sFileName;

		// Token: 0x0400073B RID: 1851
		private static string sClassName;

		// Token: 0x0400073C RID: 1852
		private static string sModelName;

		// Token: 0x0400073D RID: 1853
		private static int sLineNumber;

		// Token: 0x0400073E RID: 1854
		private static bool sInited = false;

		// Token: 0x0400073F RID: 1855
		private static Dictionary<string, string> mTypeModeDict = new Dictionary<string, string>();

		// Token: 0x04000740 RID: 1856
		private const int kMaxRegexCount = 4;

		// Token: 0x04000741 RID: 1857
		private static string[] sFilterStr = Global.Settings.loggerFilter;
	}
}
