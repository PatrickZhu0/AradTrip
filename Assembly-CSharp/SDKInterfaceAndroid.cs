using System;
using System.IO;
using Assets.SimpleAndroidNotifications;
using GameClient;
using UnityEngine;

// Token: 0x02004653 RID: 18003
public class SDKInterfaceAndroid : SDKInterface
{
	// Token: 0x06019586 RID: 103814 RVA: 0x0080302C File Offset: 0x0080142C
	protected AndroidJavaObject GetActivity()
	{
		if (this.currentActivity == null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			this.currentActivity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
		return this.currentActivity;
	}

	// Token: 0x06019587 RID: 103815 RVA: 0x00803066 File Offset: 0x00801466
	protected AndroidJavaObject GetContext()
	{
		if (this.applicationContext == null)
		{
			this.applicationContext = this.GetActivity().Call<AndroidJavaObject>("getApplicationContext", new object[0]);
		}
		return this.applicationContext;
	}

	// Token: 0x06019588 RID: 103816 RVA: 0x00803098 File Offset: 0x00801498
	protected AndroidJavaObject GetLebianJavaObject()
	{
		if (this.lebianJavaObj == null)
		{
			this.lebianJavaObj = new AndroidJavaObject("com.excelliance.open.LeBianSDKImpl", new object[0]);
			this.lebianJavaObj.CallStatic("SetCommonContext", new object[]
			{
				this.GetActivity()
			});
		}
		return this.lebianJavaObj;
	}

	// Token: 0x06019589 RID: 103817 RVA: 0x008030EC File Offset: 0x008014EC
	protected AndroidJavaObject GetCommonJavaObject()
	{
		if (this.commonJavaObj == null)
		{
			this.commonJavaObj = new AndroidJavaObject("com.example.administrator.common.AndroidCommonImpl", new object[0]);
			this.commonJavaObj.CallStatic("SetCommonContext", new object[]
			{
				this.GetActivity()
			});
		}
		return this.commonJavaObj;
	}

	// Token: 0x0601958A RID: 103818 RVA: 0x00803140 File Offset: 0x00801540
	protected AndroidJavaObject BreakpadJavaObject()
	{
		AndroidJavaObject result;
		try
		{
			if (this.breakpadObj == null)
			{
				this.breakpadObj = new AndroidJavaObject("com.tm.breakpad.BreakpadJava", new object[0]);
			}
			result = this.breakpadObj;
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString());
			result = null;
		}
		return result;
	}

	// Token: 0x0601958B RID: 103819 RVA: 0x008031A0 File Offset: 0x008015A0
	public override void InitBreakpad()
	{
		base.InitBreakpad();
		try
		{
			string text = Application.persistentDataPath;
			if (string.IsNullOrEmpty(text))
			{
				text = "/storage/emulated/0/Android/data/" + Application.identifier + "/files";
			}
			if (Directory.Exists(text))
			{
				string text2 = Path.Combine(text, "Crash");
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				AndroidJavaObject androidJavaObject = this.BreakpadJavaObject();
				if (androidJavaObject != null)
				{
					androidJavaObject.CallStatic("Init", new object[]
					{
						this.GetActivity(),
						text2
					});
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString());
		}
	}

	// Token: 0x0601958C RID: 103820 RVA: 0x00803260 File Offset: 0x00801660
	public static void KeepScreenOn(bool isOn)
	{
		try
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			if (currentActivity != null)
			{
				currentActivity.Call("runOnUiThread", new object[]
				{
					new AndroidJavaRunnable(delegate()
					{
						AndroidJavaObject androidJavaObject = currentActivity.Call<AndroidJavaObject>("getWindow", new object[0]);
						if (androidJavaObject == null)
						{
							return;
						}
						if (isOn)
						{
							androidJavaObject.Call("addFlags", new object[]
							{
								128
							});
						}
						else
						{
							androidJavaObject.Call("clearFlags", new object[]
							{
								128
							});
						}
					})
				});
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0601958D RID: 103821 RVA: 0x008032F0 File Offset: 0x008016F0
	public override int GetKeyboardSize()
	{
		int result;
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			AndroidJavaObject androidJavaObject = null;
			try
			{
				if (androidJavaClass == null)
				{
					return 0;
				}
				AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
				if (@static == null)
				{
					return 0;
				}
				AndroidJavaObject androidJavaObject2 = @static.Get<AndroidJavaObject>("mUnityPlayer");
				if (androidJavaObject2 == null)
				{
					return 0;
				}
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("getView", new object[0]);
			}
			catch (Exception ex)
			{
				return 0;
			}
			if (androidJavaObject == null)
			{
				result = 0;
			}
			else
			{
				using (AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("android.graphics.Rect", new object[0]))
				{
					if (androidJavaObject3 == null)
					{
						result = 0;
					}
					else
					{
						try
						{
							androidJavaObject.Call("getWindowVisibleDisplayFrame", new object[]
							{
								androidJavaObject3
							});
						}
						catch (Exception ex2)
						{
							return 0;
						}
						result = Screen.height - androidJavaObject3.Call<int>("height", new object[0]);
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0601958E RID: 103822 RVA: 0x0080342C File Offset: 0x0080182C
	public override int TryGetCurrVersionAPI()
	{
		string operatingSystem = SystemInfo.operatingSystem;
		int num = 0;
		int result;
		try
		{
			string value = "Android OS";
			string text = "API-";
			int length = text.Length;
			int length2 = 2;
			if (operatingSystem.Contains(value))
			{
				if (!operatingSystem.Contains(text))
				{
					return num;
				}
				int num2 = operatingSystem.IndexOf(text);
				string s = operatingSystem.Substring(num2 + length, length2);
				if (int.TryParse(s, out num))
				{
					return num;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			result = num;
		}
		return result;
	}

	// Token: 0x0601958F RID: 103823 RVA: 0x008034CC File Offset: 0x008018CC
	public override float GetBatteryLevel()
	{
		return this.GetCommonJavaObject().CallStatic<float>("GetBatteryLevel", new object[0]);
	}

	// Token: 0x06019590 RID: 103824 RVA: 0x008034E4 File Offset: 0x008018E4
	public override bool IsBatteryCharging()
	{
		return this.GetCommonJavaObject().CallStatic<bool>("IsBatteryCharging", new object[0]);
	}

	// Token: 0x06019591 RID: 103825 RVA: 0x008034FC File Offset: 0x008018FC
	public override string GetSystemTimeHHMM()
	{
		return base.GetSystemTimeHHMM();
	}

	// Token: 0x06019592 RID: 103826 RVA: 0x00803504 File Offset: 0x00801904
	public override bool RequestAudioAuthorization()
	{
		return true;
	}

	// Token: 0x06019593 RID: 103827 RVA: 0x00803507 File Offset: 0x00801907
	public override string GetClipboardText()
	{
		return this.GetCommonJavaObject().CallStatic<string>("GetClipboardText", new object[0]);
	}

	// Token: 0x06019594 RID: 103828 RVA: 0x00803520 File Offset: 0x00801920
	public override string GetSystemIMEI()
	{
		string result = string.Empty;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("GetSystemIMEI", new object[0]);
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x06019595 RID: 103829 RVA: 0x00803568 File Offset: 0x00801968
	public override void QuitApplicationOnEsc()
	{
		if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem == null)
		{
			return;
		}
		if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemLogin && Input.GetKeyDown(27))
		{
			SystemNotifyManager.SystemNotifyOkCancel(8519, delegate
			{
				Application.Quit();
			}, delegate
			{
			}, FrameLayer.High, false);
		}
	}

	// Token: 0x06019596 RID: 103830 RVA: 0x008035EB File Offset: 0x008019EB
	public override void InitServicePush(string gameObjectName)
	{
	}

	// Token: 0x06019597 RID: 103831 RVA: 0x008035ED File Offset: 0x008019ED
	public override void TurnOnServicePush()
	{
	}

	// Token: 0x06019598 RID: 103832 RVA: 0x008035EF File Offset: 0x008019EF
	public override void TurnOffServicePush()
	{
	}

	// Token: 0x06019599 RID: 103833 RVA: 0x008035F1 File Offset: 0x008019F1
	public override bool BindOtherName(string alias)
	{
		return true;
	}

	// Token: 0x0601959A RID: 103834 RVA: 0x008035F4 File Offset: 0x008019F4
	public override bool UnBindOtherName(string alias)
	{
		return true;
	}

	// Token: 0x0601959B RID: 103835 RVA: 0x008035F8 File Offset: 0x008019F8
	public override void SetNotification(int nid, string content, string title, int hour)
	{
		string text = string.Empty;
		NotificationParams notificationParams = new NotificationParams
		{
			Id = nid,
			Delay = TimeSpan.FromSeconds(1.0),
			Title = title,
			Message = content,
			Ticker = "通知",
			Sound = true,
			Vibrate = true,
			Light = true,
			SmallIcon = NotificationIcon.Bell,
			SmallIconColor = new Color(0f, 0.5f, 0f),
			LargeIcon = "app_icon"
		};
		if (!SDKInterface.IsNewSDKChannelPay())
		{
			if (this.CheckPlatformBySDKChannel(SDKChannel.NONE))
			{
				text = "com.example.administrator.myapplication.BaseActivity";
			}
			else
			{
				text = "com.hegu.dnl.MainActivity";
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		NotificationManager.SetCustomHour(hour);
		NotificationManager.SetIntentActivityForSDK(text);
		NotificationManager.SendCustom3(notificationParams);
	}

	// Token: 0x0601959C RID: 103836 RVA: 0x008036D4 File Offset: 0x00801AD4
	public override void SetNotificationWeekly(int nid, string content, string title, int weekday, int hour, int minute)
	{
		string text = string.Empty;
		NotificationParams notificationParams = new NotificationParams
		{
			Id = this.ResetNidWeekly(nid, weekday),
			Delay = default(TimeSpan),
			Title = title,
			Message = content,
			Ticker = "通知",
			Sound = true,
			Vibrate = true,
			Light = true,
			SmallIcon = NotificationIcon.Bell,
			SmallIconColor = new Color(0f, 0.5f, 0f),
			LargeIcon = "app_icon"
		};
		if (!SDKInterface.IsNewSDKChannelPay())
		{
			if (this.CheckPlatformBySDKChannel(SDKChannel.NONE))
			{
				text = "com.example.administrator.myapplication.BaseActivity";
			}
			else
			{
				text = "com.hegu.dnl.MainActivity";
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		NotificationManager.SetCustomWeekly(weekday, hour, minute);
		NotificationManager.SetIntentActivityForSDK(text);
		NotificationManager.SendCustomWeekly(notificationParams);
	}

	// Token: 0x0601959D RID: 103837 RVA: 0x008037B7 File Offset: 0x00801BB7
	private int ResetNidWeekly(int nid, int weekly)
	{
		return nid * 10 + 100000 + weekly;
	}

	// Token: 0x0601959E RID: 103838 RVA: 0x008037C8 File Offset: 0x00801BC8
	public override void RemoveNotification(int nid)
	{
		NotificationManager.Cancel(nid);
		for (int i = 1; i <= 7; i++)
		{
			NotificationManager.Cancel(this.ResetNidWeekly(nid, i));
		}
	}

	// Token: 0x0601959F RID: 103839 RVA: 0x008037FA File Offset: 0x00801BFA
	public override void RemoveAllNotification()
	{
		NotificationManager.CancelAll();
	}

	// Token: 0x060195A0 RID: 103840 RVA: 0x00803801 File Offset: 0x00801C01
	public override string GetBuildPlatformId()
	{
		return TR.Value("zymg_plat_id_android");
	}

	// Token: 0x060195A1 RID: 103841 RVA: 0x0080380D File Offset: 0x00801C0D
	public override string GetOnlineServicePlatformId()
	{
		return TR.Value("zymg_onlineservice_plat_id_android");
	}

	// Token: 0x060195A2 RID: 103842 RVA: 0x00803819 File Offset: 0x00801C19
	public override string GetOnlineServicePlatformName()
	{
		return TR.Value("zymg_onlineservice_plat_name_android");
	}

	// Token: 0x060195A3 RID: 103843 RVA: 0x00803825 File Offset: 0x00801C25
	public override void MobileVibrate()
	{
		Handheld.Vibrate();
	}

	// Token: 0x060195A4 RID: 103844 RVA: 0x0080382C File Offset: 0x00801C2C
	public bool RequestPermission(string permission)
	{
		bool result;
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.support.v4.content.ContextCompat"))
		{
			if (androidJavaClass.CallStatic<int>("checkSelfPermission", new object[]
			{
				this.GetContext(),
				permission
			}) != 0)
			{
				using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.support.v4.app.ActivityCompat"))
				{
					androidJavaClass2.CallStatic("requestPermissions", new object[]
					{
						this.GetActivity(),
						new string[]
						{
							permission
						},
						100
					});
					return false;
				}
			}
			result = true;
		}
		return result;
	}

	// Token: 0x060195A5 RID: 103845 RVA: 0x008038E8 File Offset: 0x00801CE8
	public override void ScanFile(string path)
	{
		string text = "android.media.MediaScannerConnection";
		object[] array = new object[2];
		array[0] = this.GetContext();
		using (AndroidJavaObject androidJavaObject = new AndroidJavaObject(text, array))
		{
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string text2 = "scanFile";
			object[] array2 = new object[4];
			array2[0] = this.GetContext();
			array2[1] = new string[]
			{
				path
			};
			androidJavaObject2.CallStatic(text2, array2);
		}
	}

	// Token: 0x060195A6 RID: 103846 RVA: 0x00803958 File Offset: 0x00801D58
	public override void SaveDoc(string content, string parentPathName, string fileName, bool isAppend = true)
	{
		if (string.IsNullOrEmpty(content))
		{
			Logger.LogError("SaveDoc failed, content is null !");
			return;
		}
		if (string.IsNullOrEmpty(parentPathName))
		{
			Logger.LogError("SaveDoc failed, parentPathName is null !");
			return;
		}
		if (string.IsNullOrEmpty(fileName))
		{
			Logger.LogError("SaveDoc failed, fileName is null !");
			return;
		}
		try
		{
			this.GetCommonJavaObject().CallStatic("SaveDoc", new object[]
			{
				content,
				parentPathName,
				fileName,
				isAppend
			});
		}
		catch (Exception ex)
		{
			Logger.LogError("SaveDoc failed" + ex.ToString());
		}
	}

	// Token: 0x060195A7 RID: 103847 RVA: 0x00803A04 File Offset: 0x00801E04
	public override string ReadDoc(string parentPathName, string fileName)
	{
		if (string.IsNullOrEmpty(parentPathName))
		{
			Logger.LogError("ReadDoc failed, parentPathName is null !");
			return base.ReadDoc(parentPathName, fileName);
		}
		if (string.IsNullOrEmpty(fileName))
		{
			Logger.LogError("ReadDoc failed, fileName is null !");
			return base.ReadDoc(parentPathName, fileName);
		}
		string result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("ReadFile", new object[]
			{
				parentPathName,
				fileName
			});
		}
		catch (Exception ex)
		{
			Logger.LogError("SaveDoc failed" + ex.ToString());
			result = base.ReadDoc(parentPathName, fileName);
		}
		return result;
	}

	// Token: 0x060195A8 RID: 103848 RVA: 0x00803AA8 File Offset: 0x00801EA8
	public override float GetCpuTemperature()
	{
		float result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<float>("GetCpuTemperature", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("GetCpuTemperature falied!" + ex.ToString());
			result = base.GetCpuTemperature();
		}
		return result;
	}

	// Token: 0x060195A9 RID: 103849 RVA: 0x00803B04 File Offset: 0x00801F04
	public override float GetBatteryTemperature()
	{
		float result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<float>("GetBatteryTemp", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("GetBatteryTemperature falied!" + ex.ToString());
			result = base.GetBatteryTemperature();
		}
		return result;
	}

	// Token: 0x060195AA RID: 103850 RVA: 0x00803B60 File Offset: 0x00801F60
	public override string GetAvailMemory()
	{
		string result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("GetAvailMemory", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - GetAvailMemory falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.GetAvailMemory();
		}
		return result;
	}

	// Token: 0x060195AB RID: 103851 RVA: 0x00803BC0 File Offset: 0x00801FC0
	public override string GetCurrentProcessMemory()
	{
		string result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("GetCurrentProcessMemory", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - GetCurrentProcessMemory falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.GetCurrentProcessMemory();
		}
		return result;
	}

	// Token: 0x060195AC RID: 103852 RVA: 0x00803C20 File Offset: 0x00802020
	public override bool IsSimulator()
	{
		bool result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<bool>("isSimulator", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - check IsSimulator falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.IsSimulator();
		}
		return result;
	}

	// Token: 0x060195AD RID: 103853 RVA: 0x00803C80 File Offset: 0x00802080
	public override string GetSimulatorName()
	{
		string result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("getSimulatorName", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - GetSimulatorName falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.GetSimulatorName();
		}
		return result;
	}

	// Token: 0x060195AE RID: 103854 RVA: 0x00803CE0 File Offset: 0x008020E0
	public override int GetMemLogTotalpss()
	{
		int result;
		try
		{
			int num = 0;
			int.TryParse(this.GetCommonJavaObject().CallStatic<string>("GetMemoryInfoLog", new object[]
			{
				true
			}), out num);
			result = num;
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - GetMemLogTotalpss falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.GetMemLogTotalpss();
		}
		return result;
	}

	// Token: 0x060195AF RID: 103855 RVA: 0x00803D54 File Offset: 0x00802154
	public override string GetMemLogAll()
	{
		string result;
		try
		{
			result = this.GetCommonJavaObject().CallStatic<string>("GetMemoryInfoLog", new object[]
			{
				false
			});
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[SDKInterfaceAndroid] - GetMemLogTotalall falied!, {0}", new object[]
			{
				ex.ToString()
			});
			result = base.GetMemLogAll();
		}
		return result;
	}

	// Token: 0x060195B0 RID: 103856 RVA: 0x00803DC0 File Offset: 0x008021C0
	public override bool HasSDKAdultCheakAuth()
	{
		bool result;
		try
		{
			result = this.GetActivity().Call<bool>("HasAdultCheakAuth", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("HasSDKAdultCheakAuth falied!" + ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x060195B1 RID: 103857 RVA: 0x00803E18 File Offset: 0x00802218
	public override void GetRealNameInfo()
	{
		try
		{
			if (!base.IsRealNameAuth())
			{
				MonoSingleton<SDKCallback>.instance.OnAdultCheakRet("0," + 2.ToString() + ",0");
			}
			else if (!this.HasSDKAdultCheakAuth())
			{
				if (Global.Settings.sdkChannel == SDKChannel.HuaWei)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("download_huawei_service"), null, string.Empty, false);
					MonoSingleton<SDKCallback>.instance.OnAdultCheakRet("0," + 0.ToString() + ",0");
				}
				else
				{
					MonoSingleton<SDKCallback>.instance.OnAdultCheakRet("0," + 2.ToString() + ",0");
				}
			}
			else
			{
				this.GetActivity().Call("GetRealNameInfo", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("GetRealNameInfo falied!" + ex.ToString());
		}
	}

	// Token: 0x060195B2 RID: 103858 RVA: 0x00803F30 File Offset: 0x00802330
	public override bool CanOpenAdultCheakWindow()
	{
		bool result;
		try
		{
			result = this.GetActivity().Call<bool>("CanOpenAdultCheakWindow", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("CanOpenAdultCheakWindow falied!" + ex.ToString());
			result = false;
		}
		return result;
	}

	// Token: 0x060195B3 RID: 103859 RVA: 0x00803F88 File Offset: 0x00802388
	public override void OpenAdultCheakWindow()
	{
		try
		{
			if (this.CanOpenAdultCheakWindow())
			{
				this.GetActivity().Call("OpenAdultCheakWindow", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("OpenAdultCheakWindow falied!" + ex.ToString());
		}
	}

	// Token: 0x060195B4 RID: 103860 RVA: 0x00803FEC File Offset: 0x008023EC
	public override void LBRequestUpdate()
	{
		try
		{
			this.GetLebianJavaObject().CallStatic("RequestUpdate", new object[0]);
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("[SDKInterfaceAndroid] - LBRequestUpdate invoke failed : {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x060195B5 RID: 103861 RVA: 0x00804044 File Offset: 0x00802444
	public override void LBDownloadFullRes()
	{
	}

	// Token: 0x060195B6 RID: 103862 RVA: 0x00804048 File Offset: 0x00802448
	public override bool LBIsAfterUpdate()
	{
		return false;
	}

	// Token: 0x060195B7 RID: 103863 RVA: 0x00804058 File Offset: 0x00802458
	public override string LBGetFullResPath()
	{
		return string.Empty;
	}

	// Token: 0x060195B8 RID: 103864 RVA: 0x0080406C File Offset: 0x0080246C
	protected AndroidJavaObject GetLebianSMObject()
	{
		return this.lebianSMApi;
	}

	// Token: 0x060195B9 RID: 103865 RVA: 0x00804074 File Offset: 0x00802474
	public override bool IsResourceDownloadFinished()
	{
		return false;
	}

	// Token: 0x060195BA RID: 103866 RVA: 0x00804084 File Offset: 0x00802484
	public override bool IsSmallPackage()
	{
		return false;
	}

	// Token: 0x060195BB RID: 103867 RVA: 0x00804094 File Offset: 0x00802494
	public override long GetResourceDownloadedSize()
	{
		return 0L;
	}

	// Token: 0x060195BC RID: 103868 RVA: 0x008040A8 File Offset: 0x008024A8
	public override long GetTotalResourceDownloadSize()
	{
		return 0L;
	}

	// Token: 0x060195BD RID: 103869 RVA: 0x008040B9 File Offset: 0x008024B9
	public override void OpenDownload()
	{
	}

	// Token: 0x060195BE RID: 103870 RVA: 0x008040BB File Offset: 0x008024BB
	public override void CloseDownload()
	{
	}

	// Token: 0x060195BF RID: 103871 RVA: 0x008040BD File Offset: 0x008024BD
	public override bool IsDownload()
	{
		return this.isDownload;
	}

	// Token: 0x040122C1 RID: 74433
	private const string PERMISSION_WRITE = "android.permission.WRITE_EXTERNAL_STORAGE";

	// Token: 0x040122C2 RID: 74434
	protected AndroidJavaObject currentActivity;

	// Token: 0x040122C3 RID: 74435
	protected AndroidJavaObject applicationContext;

	// Token: 0x040122C4 RID: 74436
	protected AndroidJavaObject lebianJavaObj;

	// Token: 0x040122C5 RID: 74437
	protected AndroidJavaObject commonJavaObj;

	// Token: 0x040122C6 RID: 74438
	protected AndroidJavaObject breakpadObj;

	// Token: 0x040122C7 RID: 74439
	protected AndroidJavaObject lebianSMApi;

	// Token: 0x040122C8 RID: 74440
	private bool isResourceDownloaded;

	// Token: 0x040122C9 RID: 74441
	private bool firstCheckIsSmallPackage = true;

	// Token: 0x040122CA RID: 74442
	private bool isSmallPackage;

	// Token: 0x040122CB RID: 74443
	private bool isDownload;
}
