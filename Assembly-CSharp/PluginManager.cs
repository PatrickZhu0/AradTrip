using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GameClient;
using MobileBind;
using Protocol;
using ProtoTable;
using UnityEngine;
using VoiceSDK;
using XUPorterJSON;

// Token: 0x02004645 RID: 17989
public class PluginManager : Singleton<PluginManager>
{
	// Token: 0x06019468 RID: 103528 RVA: 0x00800677 File Offset: 0x007FEA77
	public override void Init()
	{
		base.Init();
		this.LeBianRequestUpdate();
	}

	// Token: 0x06019469 RID: 103529 RVA: 0x00800685 File Offset: 0x007FEA85
	public void InititalSDK()
	{
		if (!this.isSDKInited)
		{
			this.InitSDK();
			this.isSDKInited = true;
		}
	}

	// Token: 0x0601946A RID: 103530 RVA: 0x008006A0 File Offset: 0x007FEAA0
	public bool IsLargeMemoryDevice()
	{
		int systemMemorySize = SystemInfo.systemMemorySize;
		return systemMemorySize > 2000;
	}

	// Token: 0x0601946B RID: 103531 RVA: 0x008006BC File Offset: 0x007FEABC
	public static bool CheckDeviceMemory()
	{
		if (!SwitchFunctionUtility.IsOpen(6))
		{
			return false;
		}
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (systemMemorySize <= 512)
		{
			SystemNotifyManager.SysNotifyMsgBoxOK("设备内存不足!", delegate
			{
				SDKInterface.instance.Exit();
			}, string.Empty, false);
			return true;
		}
		return false;
	}

	// Token: 0x0601946C RID: 103532 RVA: 0x00800718 File Offset: 0x007FEB18
	public static bool IsTargetDevice()
	{
		int systemMemorySize = SystemInfo.systemMemorySize;
		return false;
	}

	// Token: 0x0601946D RID: 103533 RVA: 0x0080072C File Offset: 0x007FEB2C
	private void InitBreakpad()
	{
		SDKInterface.instance.InitBreakpad();
	}

	// Token: 0x0601946E RID: 103534 RVA: 0x00800738 File Offset: 0x007FEB38
	public static void InitBugly()
	{
		Debug.Log("### Ready Init Bugly!!!!");
		string text = PluginManager._GetBuglyAppId();
		if (!string.IsNullOrEmpty(text))
		{
			PluginManager._InitBuglyAgent(text);
		}
	}

	// Token: 0x0601946F RID: 103535 RVA: 0x00800768 File Offset: 0x007FEB68
	private static void _LoadBuglyAppIdConfig()
	{
		if (PluginManager.isLoadBuglyConfig)
		{
			return;
		}
		PluginManager.isLoadBuglyConfig = true;
		try
		{
			byte[] array = null;
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive(PluginManager.BUGLY_APPID_CHANNEL_CONFIG_FILE, out array) && !FileArchiveAccessor.LoadFileInLocalFileArchive(PluginManager.BUGLY_APPID_CHANNEL_CONFIG_FILE, out array))
			{
				Debug.LogErrorFormat("[_LoadBuglyAppIdConfig] - can not load config {0} anywhere", new object[]
				{
					PluginManager.BUGLY_APPID_CHANNEL_CONFIG_FILE
				});
			}
			if (array != null)
			{
				string @string = Encoding.Default.GetString(array);
				if (string.IsNullOrEmpty(@string))
				{
					Debug.LogErrorFormat("[_LoadBuglyAppIdConfig] - load config content is null", new object[0]);
				}
				else
				{
					PluginManager.buglyConfigTable = (MiniJSON.jsonDecode(@string) as Hashtable);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("[_LoadBuglyAppIdConfig] - load failed : {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x06019470 RID: 103536 RVA: 0x00800838 File Offset: 0x007FEC38
	private static string _GetBuglyAppId()
	{
		PluginManager._LoadBuglyAppIdConfig();
		string empty = string.Empty;
		if (PluginManager.buglyConfigTable == null)
		{
			return empty;
		}
		string key = SDKInterface.instance.GetCurrentSDKChannel().ToString();
		if (!PluginManager.buglyConfigTable.ContainsKey(key))
		{
			return empty;
		}
		Hashtable hashtable = PluginManager.buglyConfigTable[key] as Hashtable;
		if (hashtable == null || !hashtable.ContainsKey("appid"))
		{
			return empty;
		}
		return hashtable["appid"] as string;
	}

	// Token: 0x06019471 RID: 103537 RVA: 0x008008C2 File Offset: 0x007FECC2
	private static void _InitBuglyAgent(string appid)
	{
		if (PluginManager.isBuglyInited)
		{
			return;
		}
		PluginManager.isBuglyInited = true;
		PluginManager.SetBuglyFileVerInfo();
		if (string.IsNullOrEmpty(appid))
		{
			return;
		}
		BuglyAgent.InitWithAppId(appid);
		BuglyAgent.EnableExceptionHandler();
	}

	// Token: 0x06019472 RID: 103538 RVA: 0x008008F4 File Offset: 0x007FECF4
	public static void SetBuglyFileVerInfo()
	{
		string buglyFileVerInfo = PluginManager.GetBuglyFileVerInfo();
		if (buglyFileVerInfo != "none")
		{
			BuglyAgent.ConfigDefault(string.Empty, string.Empty, buglyFileVerInfo, 0L);
		}
	}

	// Token: 0x06019473 RID: 103539 RVA: 0x0080092C File Offset: 0x007FED2C
	public static string GetBuglyFileVerInfo()
	{
		string text = "none";
		if (FileArchiveAccessor.LoadFileInPersistentFileArchive(PluginManager.BuglySetUseIdInfoFileName, out text))
		{
			try
			{
				Logger.LogErrorFormat("[SDKConfig] 读取 {0} : {1}", new object[]
				{
					PluginManager.BuglySetUseIdInfoFileName,
					text
				});
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[SDKConfig] 解析 {0} 失败, {1}", new object[]
				{
					PluginManager.BuglySetUseIdInfoFileName,
					ex.ToString()
				});
			}
		}
		else
		{
			Logger.LogErrorFormat("[SDKConfig] 加载 {0} 失败", new object[]
			{
				PluginManager.BuglySetUseIdInfoFileName
			});
		}
		return text;
	}

	// Token: 0x06019474 RID: 103540 RVA: 0x008009C8 File Offset: 0x007FEDC8
	public void SetBuglyVerIdInfo(string sceneinfo = "")
	{
	}

	// Token: 0x06019475 RID: 103541 RVA: 0x008009CA File Offset: 0x007FEDCA
	public static void KeepScreenOn()
	{
		SDKInterfaceAndroid.KeepScreenOn(true);
	}

	// Token: 0x06019476 RID: 103542 RVA: 0x008009D4 File Offset: 0x007FEDD4
	private void InitSDK()
	{
		bool isDebug = Global.Settings.isDebug;
		this._buglyInfoDebug = isDebug;
		SDKInterface.instance.Init(isDebug);
		SDKInterface.instance.loginCallbackGame = delegate(string token, string openuid, string ext)
		{
			if (ClientApplication.playerinfo.state == PlayerState.LOGIN)
			{
				if (SDKInterface.instance.logoutCallbackGame != null)
				{
					SDKInterface.instance.logoutCallbackGame();
				}
				return;
			}
			ClientApplication.playerinfo.state = PlayerState.LOGIN;
			ClientApplication.playerinfo.token = token;
			ClientApplication.playerinfo.openuid = openuid;
			ClientApplication.playerinfo.sdkLoginExt = ext;
			if (Global.Settings.isUsingSDK)
			{
				string text = Global.channelName + openuid;
				if (Global.Settings.sdkChannel == SDKChannel.SN79)
				{
					text = openuid;
				}
				object value = PlayerLocalSetting.GetValue("AccountDefault");
				string b = (value != null) ? value.ToString() : string.Empty;
				if (text != b)
				{
					PlayerLocalSetting.SetValue("ServerID", null);
					ClientApplication.adminServer.id = 0U;
				}
				PlayerLocalSetting.SetValue("AccountDefault", text);
				PlayerLocalSetting.SaveConfig();
			}
			SDKInterface.instance.GetRealNameInfo();
			CameraAspectAdjust.MarkDirty();
		};
		SDKInterface.instance.logoutCallbackGame = delegate()
		{
			ClientApplication.playerinfo.state = PlayerState.LOGOUT;
			ClientSystemManager instance = Singleton<ClientSystemManager>.GetInstance();
			instance._QuitToLoginImpl();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.onSDKLogoutSuccess, null, null, null, null);
			IClientSystem currentSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem;
			if (currentSystem != null && currentSystem is ClientSystemLogin)
			{
				SDKInterface.instance.Login();
			}
		};
		SDKInterface.instance.adultCheakcallback = delegate(int flag, int realNameFlag, int age)
		{
			if (flag == 0)
			{
				ClientApplication.playerinfo.age = age;
				ClientApplication.playerinfo.authType = (AuthIDType)realNameFlag;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.onSDKLoginSuccess, null, null, null, null);
		};
		SDKInterface.instance.payResultCallbackGame = delegate(string result)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, result, null, null, null);
		};
		SDKInterface.instance.bindPhoneCallbackGame = delegate(string bindPhoneNum)
		{
			DataManager<MobileBindManager>.GetInstance().SDKBindPhoneSucc(bindPhoneNum);
		};
		SDKInterface.instance.smallGameLoadCallbackGame = delegate(string sceneName)
		{
			GameObject gameObject = GameObject.Find("UIRoot");
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
			gameObject = GameObject.Find("Environment");
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
			Application.LoadLevel(sceneName);
		};
	}

	// Token: 0x06019477 RID: 103543 RVA: 0x00800AE8 File Offset: 0x007FEEE8
	public void OpenXYLogin()
	{
		SDKInterface.instance.Login();
	}

	// Token: 0x06019478 RID: 103544 RVA: 0x00800AF4 File Offset: 0x007FEEF4
	public void AddNotification(int nID, bool isWeeklyOpen = false)
	{
		NotificationTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NotificationTable>(nID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			if (isWeeklyOpen)
			{
				string[] array = tableItem.weekday.Split(new char[]
				{
					','
				});
				List<int> list = new List<int>();
				if (array == null)
				{
					Logger.LogErrorFormat("周推送数据有误！！", new object[0]);
					return;
				}
				for (int i = 0; i < array.Length; i++)
				{
					int num;
					if (int.TryParse(array[i], out num))
					{
						num++;
						if (num > 7)
						{
							num %= 7;
						}
						list.Add(num);
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					SDKInterface.instance.SetNotificationWeekly(nID, tableItem.Content, string.Empty, list[j], tableItem.hour, tableItem.minute);
				}
			}
			else
			{
				SDKInterface.instance.SetNotification(nID, tableItem.Content, string.Empty, tableItem.hour);
			}
		}
	}

	// Token: 0x06019479 RID: 103545 RVA: 0x00800C01 File Offset: 0x007FF001
	public void RemoveNotification(int nID)
	{
		SDKInterface.instance.RemoveNotification(nID);
	}

	// Token: 0x0601947A RID: 103546 RVA: 0x00800C0E File Offset: 0x007FF00E
	public void RemoveAllNotification()
	{
		SDKInterface.instance.RemoveAllNotification();
	}

	// Token: 0x0601947B RID: 103547 RVA: 0x00800C1A File Offset: 0x007FF01A
	public bool GetAudioAuthorization()
	{
		return SDKInterface.instance.RequestAudioAuthorization();
	}

	// Token: 0x0601947C RID: 103548 RVA: 0x00800C28 File Offset: 0x007FF028
	public void InitNotifications()
	{
		bool isWeeklyOpen = false;
		SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(60, string.Empty, string.Empty);
		if (tableItem != null)
		{
			isWeeklyOpen = tableItem.Open;
		}
		this.RemoveAllNotification();
		SDKInterface.instance.ResetBadge();
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<NotificationTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			NotificationTable notificationTable = (NotificationTable)keyValuePair.Value;
			if (notificationTable.NeedClose > 0)
			{
				this.RemoveNotification(notificationTable.ID);
			}
			else
			{
				this.AddNotification(notificationTable.ID, isWeeklyOpen);
			}
		}
	}

	// Token: 0x0601947D RID: 103549 RVA: 0x00800CD2 File Offset: 0x007FF0D2
	public float GetBatteryPower()
	{
		return SDKInterface.instance.GetBatteryLevel();
	}

	// Token: 0x0601947E RID: 103550 RVA: 0x00800CDE File Offset: 0x007FF0DE
	public bool IsBatteryCharging()
	{
		return SDKInterface.instance.IsBatteryCharging();
	}

	// Token: 0x0601947F RID: 103551 RVA: 0x00800CEA File Offset: 0x007FF0EA
	public string GetSystemTime_HHMM()
	{
		return SDKInterface.instance.GetSystemTimeHHMM();
	}

	// Token: 0x06019480 RID: 103552 RVA: 0x00800CF6 File Offset: 0x007FF0F6
	public string GetSystemTimeStamp()
	{
		return SDKInterface.instance.GetSystemTimeStamp();
	}

	// Token: 0x06019481 RID: 103553 RVA: 0x00800D02 File Offset: 0x007FF102
	public void SetAudioSessionActive()
	{
		SDKInterface.instance.SetAudioSessionActive();
	}

	// Token: 0x06019482 RID: 103554 RVA: 0x00800D10 File Offset: 0x007FF110
	public string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		string str = SDKInterface.instance.ExtendLoginVerifyUrl();
		ext = ext.Replace(" ", string.Empty);
		return SDKInterface.instance.LoginVerifyUrl(serverUrl, serverId, openuid, token, deviceId, sdkChannel, ext) + str;
	}

	// Token: 0x06019483 RID: 103555 RVA: 0x00800D58 File Offset: 0x007FF158
	public bool IsYueYuPag()
	{
		return SDKInterface.instance.IsYueYuPag();
	}

	// Token: 0x06019484 RID: 103556 RVA: 0x00800D64 File Offset: 0x007FF164
	public virtual string FullPackageFetchURL(string serverName, string sdkChannel, string version)
	{
		return string.Format("http://{0}?channel={1}&version={2}", serverName, sdkChannel, version);
	}

	// Token: 0x06019485 RID: 103557 RVA: 0x00800D73 File Offset: 0x007FF173
	public string GetClipboardText()
	{
		return SDKInterface.instance.GetClipboardText();
	}

	// Token: 0x06019486 RID: 103558 RVA: 0x00800D7F File Offset: 0x007FF17F
	public void AddKeyboardShowListener(SDKInterface.KeyboardShowOut OnKeyboardres)
	{
		if (OnKeyboardres != null)
		{
			SDKInterface.instance.keyboardShowCallbackGame = OnKeyboardres;
		}
	}

	// Token: 0x06019487 RID: 103559 RVA: 0x00800D92 File Offset: 0x007FF192
	public void RemoveKeyboardShowListener()
	{
		SDKInterface.instance.keyboardShowCallbackGame = null;
	}

	// Token: 0x06019488 RID: 103560 RVA: 0x00800D9F File Offset: 0x007FF19F
	public int GetCurrVersionApi()
	{
		return SDKInterface.instance.TryGetCurrVersionAPI();
	}

	// Token: 0x06019489 RID: 103561 RVA: 0x00800DAC File Offset: 0x007FF1AC
	public bool IsSDKEnableSystemVersion(SDKInterface.FuncSDKType funcSdkType)
	{
		int currVersionApi = this.GetCurrVersionApi();
		return funcSdkType != SDKInterface.FuncSDKType.FSDK_UniWebView || currVersionApi > 19;
	}

	// Token: 0x0601948A RID: 103562 RVA: 0x00800DD8 File Offset: 0x007FF1D8
	public bool IsMGSDKChannel()
	{
		return SDKInterface.instance.IsMGChannel();
	}

	// Token: 0x0601948B RID: 103563 RVA: 0x00800DE4 File Offset: 0x007FF1E4
	public static bool NeedChannelHideVersionUpdateProgress()
	{
		return SDKInterface.NeedChannelHideVersionUpdateProgress();
	}

	// Token: 0x0601948C RID: 103564 RVA: 0x00800DEB File Offset: 0x007FF1EB
	public void LeBianRequestUpdate()
	{
		SDKInterface.instance.LBRequestUpdate();
	}

	// Token: 0x0601948D RID: 103565 RVA: 0x00800DF8 File Offset: 0x007FF1F8
	public void LeBianJudgeLevelAndDownload(int level)
	{
		SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(100, string.Empty, string.Empty);
		if (tableItem != null && tableItem.Open && level >= tableItem.ValueA)
		{
			this.LeBianDownloadFullRes();
		}
	}

	// Token: 0x0601948E RID: 103566 RVA: 0x00800E3F File Offset: 0x007FF23F
	public void LeBianDownloadFullRes()
	{
		SDKInterface.instance.LBDownloadFullRes();
	}

	// Token: 0x0601948F RID: 103567 RVA: 0x00800E4B File Offset: 0x007FF24B
	public bool LeBianIsAfterUpdate()
	{
		return SDKInterface.instance.LBIsAfterUpdate();
	}

	// Token: 0x06019490 RID: 103568 RVA: 0x00800E57 File Offset: 0x007FF257
	public string LeBianGetFullResPath()
	{
		return SDKInterface.instance.LBGetFullResPath();
	}

	// Token: 0x06019491 RID: 103569 RVA: 0x00800E63 File Offset: 0x007FF263
	public void ReportDeviceId()
	{
		if (Global.Settings.sdkChannel == SDKChannel.MG || Global.Settings.sdkChannel == SDKChannel.TestMG)
		{
			SDKInterface.instance.SendGameServerSystemIMEI();
		}
	}

	// Token: 0x06019492 RID: 103570 RVA: 0x00800E8F File Offset: 0x007FF28F
	public string GetBuildPlatformId()
	{
		return SDKInterface.instance.GetBuildPlatformId();
	}

	// Token: 0x06019493 RID: 103571 RVA: 0x00800E9B File Offset: 0x007FF29B
	public bool HasVIPAuth()
	{
		return SDKInterface.instance.HasVIPAuth();
	}

	// Token: 0x06019494 RID: 103572 RVA: 0x00800EA7 File Offset: 0x007FF2A7
	public bool IsRealNameAuth()
	{
		return SDKInterface.instance.IsRealNameAuth();
	}

	// Token: 0x06019495 RID: 103573 RVA: 0x00800EB3 File Offset: 0x007FF2B3
	public string GetOnlineServiceBuildPlatformId()
	{
		return SDKInterface.instance.GetOnlineServicePlatformId();
	}

	// Token: 0x06019496 RID: 103574 RVA: 0x00800EBF File Offset: 0x007FF2BF
	public string GetOnlineServicePlatformName()
	{
		return SDKInterface.instance.GetOnlineServicePlatformName();
	}

	// Token: 0x06019497 RID: 103575 RVA: 0x00800ECB File Offset: 0x007FF2CB
	public string GetChannelName()
	{
		return SDKInterface.instance.GetPlatformNameBySelect();
	}

	// Token: 0x06019498 RID: 103576 RVA: 0x00800ED7 File Offset: 0x007FF2D7
	public void TriggerMobileVibrate()
	{
		SDKInterface.instance.MobileVibrate();
	}

	// Token: 0x06019499 RID: 103577 RVA: 0x00800EE3 File Offset: 0x007FF2E3
	public void ScanFile(string path)
	{
		SDKInterface.instance.ScanFile(path);
	}

	// Token: 0x0601949A RID: 103578 RVA: 0x00800EF0 File Offset: 0x007FF2F0
	public void SaveDoc(string content, string parentPathName, string fileName, bool isAppend = true)
	{
		SDKInterface.instance.SaveDoc(content, parentPathName, fileName, isAppend);
	}

	// Token: 0x0601949B RID: 103579 RVA: 0x00800F01 File Offset: 0x007FF301
	public string ReadDoc(string parentPathName, string fileName)
	{
		return SDKInterface.instance.ReadDoc(parentPathName, fileName);
	}

	// Token: 0x0601949C RID: 103580 RVA: 0x00800F0F File Offset: 0x007FF30F
	public float GetCpuTemperature()
	{
		return SDKInterface.instance.GetCpuTemperature();
	}

	// Token: 0x0601949D RID: 103581 RVA: 0x00800F1B File Offset: 0x007FF31B
	public float GetBatteryTemperature()
	{
		return SDKInterface.instance.GetBatteryTemperature();
	}

	// Token: 0x0601949E RID: 103582 RVA: 0x00800F27 File Offset: 0x007FF327
	public void TryGetIOSAppstoreProductIds()
	{
		SDKInterface.instance.TryGetIOSAppstoreProductIds();
	}

	// Token: 0x0601949F RID: 103583 RVA: 0x00800F33 File Offset: 0x007FF333
	public string GetAvailMemory()
	{
		return SDKInterface.instance.GetAvailMemory();
	}

	// Token: 0x060194A0 RID: 103584 RVA: 0x00800F3F File Offset: 0x007FF33F
	public string GetCurrentProcessMemory()
	{
		return SDKInterface.instance.GetCurrentProcessMemory();
	}

	// Token: 0x060194A1 RID: 103585 RVA: 0x00800F4B File Offset: 0x007FF34B
	public string GetMonoMemory()
	{
		return SDKInterface.instance.GetMonoMemory();
	}

	// Token: 0x060194A2 RID: 103586 RVA: 0x00800F57 File Offset: 0x007FF357
	public bool IsSimulator()
	{
		return SDKInterface.instance.IsSimulator();
	}

	// Token: 0x060194A3 RID: 103587 RVA: 0x00800F63 File Offset: 0x007FF363
	public string GetSimulatorName()
	{
		return SDKInterface.instance.GetSimulatorName();
	}

	// Token: 0x060194A4 RID: 103588 RVA: 0x00800F6F File Offset: 0x007FF36F
	public int GetMemLogTotalpss()
	{
		return SDKInterface.instance.GetMemLogTotalpss();
	}

	// Token: 0x060194A5 RID: 103589 RVA: 0x00800F7B File Offset: 0x007FF37B
	public string GetMemLogAll()
	{
		return SDKInterface.instance.GetMemLogAll();
	}

	// Token: 0x060194A6 RID: 103590 RVA: 0x00800F87 File Offset: 0x007FF387
	public bool HasSDKAdultCheakAuth()
	{
		return SDKInterface.instance.HasSDKAdultCheakAuth();
	}

	// Token: 0x060194A7 RID: 103591 RVA: 0x00800F93 File Offset: 0x007FF393
	public bool CanOpenAdultCheakWindow()
	{
		return SDKInterface.instance.CanOpenAdultCheakWindow();
	}

	// Token: 0x060194A8 RID: 103592 RVA: 0x00800F9F File Offset: 0x007FF39F
	public void OpenAdultCheakWindow()
	{
		SDKInterface.instance.OpenAdultCheakWindow();
	}

	// Token: 0x060194A9 RID: 103593 RVA: 0x00800FAC File Offset: 0x007FF3AC
	public static string GetSDKLogoPath(SDKInterface.SDKLogoType sdkLogoType)
	{
		string text = string.Empty;
		if (SDKInterface.BeOtherChannel())
		{
			string text2 = Global.Settings.sdkChannel.ToString();
			string str = string.Format("Base/Version/VersionFrame/SDK_Logos/{0}/", text2);
			string str2 = string.Format("UI/Image/Background/SDK_Logos/{0}/", text2);
			string str3 = string.Format("version_update_frame_background_{0}", text2);
			string str4 = string.Format("version_update_frame_background_{0}.jpg:version_update_frame_background_{1}", text2, text2);
			string str5 = string.Format("UI_Beijing_Dixiacheng_{0}.png:UI_Beijing_Dixiacheng_{1}", text2, text2);
			string str6 = string.Format("Loading-logo_{0}.png:Loading-logo_{1}", text2, text2);
			switch (sdkLogoType)
			{
			case SDKInterface.SDKLogoType.VersionUpdate:
				text = str + str3;
				break;
			case SDKInterface.SDKLogoType.SelectRole:
				text = str2 + str4;
				break;
			case SDKInterface.SDKLogoType.LoginLogo:
				text = str2 + str5;
				break;
			case SDKInterface.SDKLogoType.LoadingLogo:
				text = str2 + str6;
				break;
			}
			if (string.IsNullOrEmpty(text))
			{
				Logger.LogError("GetSDKLogoPath - iconPath is null");
			}
			return text;
		}
		return text;
	}

	// Token: 0x060194AA RID: 103594 RVA: 0x00801099 File Offset: 0x007FF499
	public void InitServiceAdsPush(string gameObjectName)
	{
		SDKInterface.instance.InitServicePush(gameObjectName);
	}

	// Token: 0x060194AB RID: 103595 RVA: 0x008010A6 File Offset: 0x007FF4A6
	public void TurnOnServiceAdsPush(bool on)
	{
		if (on)
		{
			SDKInterface.instance.TurnOnServicePush();
		}
		else
		{
			SDKInterface.instance.TurnOffServicePush();
		}
	}

	// Token: 0x060194AC RID: 103596 RVA: 0x008010C7 File Offset: 0x007FF4C7
	public bool BindOtherNameForServicePush(string alias)
	{
		return SDKInterface.instance.BindOtherName(alias);
	}

	// Token: 0x060194AD RID: 103597 RVA: 0x008010D4 File Offset: 0x007FF4D4
	public bool UnBindOtherNameForServicePush(string alias)
	{
		return SDKInterface.instance.UnBindOtherName(alias);
	}

	// Token: 0x170020C8 RID: 8392
	// (get) Token: 0x060194AE RID: 103598 RVA: 0x008010E1 File Offset: 0x007FF4E1
	// (set) Token: 0x060194AF RID: 103599 RVA: 0x008010E9 File Offset: 0x007FF4E9
	public bool OpenChatVoice { get; private set; }

	// Token: 0x170020C9 RID: 8393
	// (get) Token: 0x060194B0 RID: 103600 RVA: 0x008010F2 File Offset: 0x007FF4F2
	// (set) Token: 0x060194B1 RID: 103601 RVA: 0x008010FA File Offset: 0x007FF4FA
	public bool OpenChatVoiceInGloabl { get; private set; }

	// Token: 0x170020CA RID: 8394
	// (get) Token: 0x060194B2 RID: 103602 RVA: 0x00801103 File Offset: 0x007FF503
	// (set) Token: 0x060194B3 RID: 103603 RVA: 0x0080110B File Offset: 0x007FF50B
	public bool OpenTalkRealVocie { get; private set; }

	// Token: 0x170020CB RID: 8395
	// (get) Token: 0x060194B4 RID: 103604 RVA: 0x00801114 File Offset: 0x007FF514
	// (set) Token: 0x060194B5 RID: 103605 RVA: 0x0080111C File Offset: 0x007FF51C
	public bool OpenTalkRealIn3v3Pvp { get; private set; }

	// Token: 0x170020CC RID: 8396
	// (get) Token: 0x060194B6 RID: 103606 RVA: 0x00801125 File Offset: 0x007FF525
	// (set) Token: 0x060194B7 RID: 103607 RVA: 0x0080112D File Offset: 0x007FF52D
	public bool OpenTalkRealIn3v3Room { get; private set; }

	// Token: 0x170020CD RID: 8397
	// (get) Token: 0x060194B8 RID: 103608 RVA: 0x00801136 File Offset: 0x007FF536
	// (set) Token: 0x060194B9 RID: 103609 RVA: 0x0080113E File Offset: 0x007FF53E
	public bool OpenTalkRealInTeam { get; private set; }

	// Token: 0x060194BA RID: 103610 RVA: 0x00801147 File Offset: 0x007FF547
	public bool GetVoiceSDKSwitch(PluginManager.VoiceSDKSwitch switchType)
	{
		return this.mVoiceSDKSwitches[(int)switchType];
	}

	// Token: 0x060194BB RID: 103611 RVA: 0x00801154 File Offset: 0x007FF554
	public void InitVoiceChatSDK(uint voiceSwitchFlag)
	{
		bool isDebug = Global.Settings.isDebug;
		this.OpenChatVoice = ((voiceSwitchFlag & 1U) == 0U);
		this.OpenChatVoiceInGloabl = (this.OpenChatVoice && (voiceSwitchFlag & 2U) == 0U);
		this.OpenTalkRealVocie = ((voiceSwitchFlag & 4U) == 0U);
		this.OpenTalkRealIn3v3Pvp = (this.OpenTalkRealVocie && (voiceSwitchFlag & 8U) == 0U);
		this.OpenTalkRealIn3v3Room = (this.OpenTalkRealVocie && (voiceSwitchFlag & 16U) == 0U);
		this.OpenTalkRealInTeam = (this.OpenTalkRealVocie && (voiceSwitchFlag & 32U) == 0U);
		if (this.mVoiceSDKSwitches != null)
		{
			int num = 0;
			int num2 = 2;
			for (int i = 0; i < this.mVoiceSDKSwitches.Length; i++)
			{
				bool flag = (voiceSwitchFlag & 1U << i) == 0U;
				if (i >= num && i < num2)
				{
					bool[] array = this.mVoiceSDKSwitches;
					int num3 = i;
					bool flag3;
					if (i == num)
					{
						bool flag2 = flag;
						this.OpenChatVoice = flag2;
						flag3 = flag2;
					}
					else
					{
						flag3 = (this.OpenChatVoice && flag);
					}
					array[num3] = flag3;
				}
				else if (i >= num2)
				{
					bool[] array2 = this.mVoiceSDKSwitches;
					int num4 = i;
					bool flag4;
					if (i == num2)
					{
						bool flag2 = flag;
						this.OpenTalkRealVocie = flag2;
						flag4 = flag2;
					}
					else
					{
						flag4 = (this.OpenTalkRealVocie && flag);
					}
					array2[num4] = flag4;
				}
			}
		}
		Singleton<SDKVoiceManager>.GetInstance().InitVoiceEnabled(this.OpenChatVoice, this.OpenTalkRealVocie);
		Singleton<SDKVoiceManager>.GetInstance().SetVoiceDebugLevel(SDKVoiceLogLevel.None);
		Singleton<SDKVoiceManager>.GetInstance().SetVoiceSavePath(VoiceDataHelper.saveLocalPath);
		Singleton<SDKVoiceManager>.GetInstance().InitChatVoice();
		Singleton<SDKVoiceManager>.GetInstance().InitTalkVoice();
	}

	// Token: 0x0401226B RID: 74347
	private static readonly string BUGLY_APPID_CHANNEL_CONFIG_FILE = "bugly_appid_channel.conf";

	// Token: 0x0401226C RID: 74348
	private static string BUGLY_IOS_APPID = "9ea011527a";

	// Token: 0x0401226D RID: 74349
	private static string BUGLY_ANDROID_APPID = "900058233";

	// Token: 0x0401226E RID: 74350
	private static string BUGLY_ANDROID_MG_TEST = "fc1ccbfe45";

	// Token: 0x0401226F RID: 74351
	private static bool isBuglyInited;

	// Token: 0x04012270 RID: 74352
	private static bool isLoadBuglyConfig;

	// Token: 0x04012271 RID: 74353
	private static Hashtable buglyConfigTable;

	// Token: 0x04012272 RID: 74354
	private bool isSDKInited;

	// Token: 0x04012273 RID: 74355
	public static bool isFirstStartGame = true;

	// Token: 0x04012274 RID: 74356
	private static readonly string BuglySetUseIdInfoFileName = "bugly_userid_info.conf";

	// Token: 0x04012275 RID: 74357
	public string BuglySceneInfo = string.Empty;

	// Token: 0x04012276 RID: 74358
	private bool _buglyInfoDebug;

	// Token: 0x04012277 RID: 74359
	private readonly object buglyinfoLock = new object();

	// Token: 0x0401227E RID: 74366
	private bool[] mVoiceSDKSwitches = new bool[7];

	// Token: 0x02004646 RID: 17990
	public enum VoiceSDKSwitch
	{
		// Token: 0x04012287 RID: 74375
		ChatVoice,
		// Token: 0x04012288 RID: 74376
		ChatVoiceInGloabl,
		// Token: 0x04012289 RID: 74377
		TalkVoice,
		// Token: 0x0401228A RID: 74378
		TalkVoiceIn3v3Pvp,
		// Token: 0x0401228B RID: 74379
		TalkVoiceIn3v3Room,
		// Token: 0x0401228C RID: 74380
		TalkVoiceInTeam,
		// Token: 0x0401228D RID: 74381
		TalkVoiceInTeamDuplication,
		// Token: 0x0401228E RID: 74382
		All
	}
}
