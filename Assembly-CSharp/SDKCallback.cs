using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004647 RID: 17991
public class SDKCallback : MonoSingleton<SDKCallback>
{
	// Token: 0x170020CE RID: 8398
	// (get) Token: 0x060194C6 RID: 103622 RVA: 0x0080153D File Offset: 0x007FF93D
	// (set) Token: 0x060194C5 RID: 103621 RVA: 0x00801534 File Offset: 0x007FF934
	public bool CanRead
	{
		get
		{
			return this.canRead;
		}
		set
		{
			this.canRead = value;
		}
	}

	// Token: 0x060194C7 RID: 103623 RVA: 0x00801545 File Offset: 0x007FF945
	public void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060194C8 RID: 103624 RVA: 0x00801552 File Offset: 0x007FF952
	public override void Init()
	{
	}

	// Token: 0x060194C9 RID: 103625 RVA: 0x00801554 File Offset: 0x007FF954
	public void StartScreenSave()
	{
		if (SwitchFunctionUtility.IsOpen(5))
		{
			this.InitScreenBrightnessProtect();
		}
		else
		{
			this.screenSaverInited = false;
			this.timer = null;
		}
	}

	// Token: 0x060194CA RID: 103626 RVA: 0x0080157C File Offset: 0x007FF97C
	public void OnLogin(string param)
	{
		string[] array = param.Split(new char[]
		{
			','
		});
		if (array.Length == 2)
		{
			SDKInterface.instance.loginCallbackGame(array[1], array[0], string.Empty);
		}
		else if (array.Length == 3)
		{
			SDKInterface.instance.loginCallbackGame(array[1], array[0], array[2]);
		}
		else
		{
			Logger.LogErrorFormat("login param is wrong:{0}", new object[]
			{
				param
			});
		}
	}

	// Token: 0x060194CB RID: 103627 RVA: 0x008015FD File Offset: 0x007FF9FD
	public void OnLogout()
	{
		SDKInterface.instance.logoutCallbackGame();
	}

	// Token: 0x060194CC RID: 103628 RVA: 0x0080160E File Offset: 0x007FFA0E
	public void OnPayResult(string param)
	{
		SDKInterface.instance.payResultCallbackGame(param);
	}

	// Token: 0x060194CD RID: 103629 RVA: 0x00801620 File Offset: 0x007FFA20
	public void OnBindPhoneSucc(string bindPhoneNum)
	{
		SDKInterface.instance.bindPhoneCallbackGame(bindPhoneNum);
	}

	// Token: 0x060194CE RID: 103630 RVA: 0x00801632 File Offset: 0x007FFA32
	public void OnKeyBoardShowOn(string param)
	{
		if (SDKInterface.instance.keyboardShowCallbackGame != null)
		{
			SDKInterface.instance.keyboardShowCallbackGame(param);
		}
	}

	// Token: 0x060194CF RID: 103631 RVA: 0x00801653 File Offset: 0x007FFA53
	public void OnLogRet(string res)
	{
		Logger.LogError("[android res] - " + res);
	}

	// Token: 0x060194D0 RID: 103632 RVA: 0x00801668 File Offset: 0x007FFA68
	public void OnLoadSmallGame()
	{
		string iosappstoreSmallGameLoadSceneName = SDKInterface.instance.GetIOSAppstoreSmallGameLoadSceneName();
		if (SDKInterface.instance.smallGameLoadCallbackGame != null && !string.IsNullOrEmpty(iosappstoreSmallGameLoadSceneName))
		{
			SDKInterface.instance.smallGameLoadCallbackGame(iosappstoreSmallGameLoadSceneName);
		}
	}

	// Token: 0x060194D1 RID: 103633 RVA: 0x008016AC File Offset: 0x007FFAAC
	public void Update()
	{
		float deltaTime = Time.deltaTime;
		if (this.screenSaverInited)
		{
			if (this.timer != null)
			{
				this.timer.UpdateTimer((int)(deltaTime * 1000f));
			}
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == 3)
			{
				this.RestoreScreenBrightness();
				if (this.timer != null)
				{
					this.timer.StartTimer();
				}
			}
		}
		SDKInterface.instance.QuitApplicationOnEsc();
		if (SDKInterface.instance.CanSetCreateRoleInfoInFiveMin())
		{
			this.durationTimeTemp += deltaTime;
			if (this.durationTimeTemp >= 300f)
			{
				SDKInterface.instance.SetCreateRoleInFiveInfo(ClientApplication.playerinfo.openuid, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString());
				this.durationTimeTemp = 0f;
			}
		}
		this.durationTimeTemp2 += deltaTime;
		if (this.durationTimeTemp2 > 300f)
		{
			if (this.roleLevel < DataManager<PlayerBaseData>.GetInstance().Level)
			{
				this.roleLevel = DataManager<PlayerBaseData>.GetInstance().Level;
				SDKInterface.instance.SetRoleUpLevelInfo(ClientApplication.playerinfo.openuid, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(), this.roleLevel.ToString());
				SDKInterface.instance.SetCreateRoleInfo(ClientApplication.playerinfo.openuid, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(), DataManager<PlayerBaseData>.GetInstance().Name.ToString(), DataManager<PlayerBaseData>.GetInstance().Level.ToString(), ClientApplication.adminServer.name, "角色段位", DataManager<PlayerBaseData>.GetInstance().guildName);
			}
			this.durationTimeTemp2 = 0f;
		}
		this.UpdateCanReadFlag(deltaTime);
		this.UpdateCheckTempure(deltaTime);
	}

	// Token: 0x060194D2 RID: 103634 RVA: 0x00801898 File Offset: 0x007FFC98
	private void UpdateCanReadFlag(float timeElapsed)
	{
		if (!this.canRead)
		{
			this.checkAcc += timeElapsed;
			if (this.checkAcc >= 1f)
			{
				this.checkAcc = 0f;
				this.canRead = true;
			}
		}
	}

	// Token: 0x060194D3 RID: 103635 RVA: 0x008018D5 File Offset: 0x007FFCD5
	private void _UpdateSetBuglyInfo(float timeElapsed)
	{
		this.tempBuglyInfoTimer += timeElapsed;
		if (this.tempBuglyInfoTimer >= 15f)
		{
			Singleton<PluginManager>.GetInstance().SetBuglyVerIdInfo(string.Empty);
			this.tempBuglyInfoTimer = 0f;
		}
	}

	// Token: 0x060194D4 RID: 103636 RVA: 0x0080190F File Offset: 0x007FFD0F
	private void OnApplicationFocus(bool focusStatus)
	{
		if (!focusStatus)
		{
			this.RestoreScreenBrightness();
		}
		else
		{
			this.RestartBGAudio();
		}
	}

	// Token: 0x060194D5 RID: 103637 RVA: 0x00801928 File Offset: 0x007FFD28
	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			this.RestoreScreenBrightness();
		}
		else
		{
			this.RestartBGAudio();
		}
	}

	// Token: 0x060194D6 RID: 103638 RVA: 0x00801944 File Offset: 0x007FFD44
	public void InitScreenBrightnessProtect()
	{
		if (this.screenSaverInited)
		{
			return;
		}
		this.timer = new SimpleTimer2();
		this.SaveBrightness();
		this.timer.timeupCallBack = delegate()
		{
			this.SetLowScreenBrightness();
		};
		int countdown = 120;
		SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(5, string.Empty, string.Empty);
		if (tableItem != null)
		{
			countdown = tableItem.ValueA;
		}
		this.timer.SetCountdown(countdown);
		this.timer.StartTimer();
		this.screenSaverInited = true;
	}

	// Token: 0x060194D7 RID: 103639 RVA: 0x008019C9 File Offset: 0x007FFDC9
	public void SetLowScreenBrightness()
	{
		if (this.screenSaverInited)
		{
			if (SDKInterface.instance.GetScreenBrightness() != this.deviceScreenBrightness)
			{
				this.SaveBrightness();
			}
			SDKInterface.instance.SetScreenBrightness(0.01f);
		}
	}

	// Token: 0x060194D8 RID: 103640 RVA: 0x00801A00 File Offset: 0x007FFE00
	public void RestoreScreenBrightness()
	{
		if (this.screenSaverInited && SDKInterface.instance.GetScreenBrightness() != this.deviceScreenBrightness)
		{
			this.SaveBrightness();
			SDKInterface.instance.SetScreenBrightness(this.deviceScreenBrightness);
		}
	}

	// Token: 0x060194D9 RID: 103641 RVA: 0x00801A38 File Offset: 0x007FFE38
	private void SaveBrightness()
	{
		if (SDKInterface.instance.GetScreenBrightness() > 0.01f)
		{
			this.deviceScreenBrightness = SDKInterface.instance.GetScreenBrightness();
		}
	}

	// Token: 0x060194DA RID: 103642 RVA: 0x00801A60 File Offset: 0x007FFE60
	private void RestartBGAudio()
	{
		AudioSource[] array = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		if (array != null)
		{
			foreach (AudioSource audioSource in array)
			{
				bool loop = audioSource.loop;
				if (loop && audioSource.clip != null)
				{
					audioSource.Play();
				}
			}
		}
	}

	// Token: 0x060194DB RID: 103643 RVA: 0x00801AC4 File Offset: 0x007FFEC4
	public void ReportValues()
	{
	}

	// Token: 0x060194DC RID: 103644 RVA: 0x00801AC6 File Offset: 0x007FFEC6
	public void SetNeedCheckTempure(bool flag)
	{
	}

	// Token: 0x060194DD RID: 103645 RVA: 0x00801AC8 File Offset: 0x007FFEC8
	private void UpdateCheckTempure(float delta)
	{
	}

	// Token: 0x060194DE RID: 103646 RVA: 0x00801ACA File Offset: 0x007FFECA
	private void InitRecordValues()
	{
	}

	// Token: 0x060194DF RID: 103647 RVA: 0x00801ACC File Offset: 0x007FFECC
	private void RecordValues()
	{
	}

	// Token: 0x060194E0 RID: 103648 RVA: 0x00801ACE File Offset: 0x007FFECE
	private void _recordValue(int value, ref int var)
	{
	}

	// Token: 0x060194E1 RID: 103649 RVA: 0x00801AD0 File Offset: 0x007FFED0
	public void OnAdultCheakRet(string params_JAVA)
	{
		string[] array = this.ParseCallBackParams(params_JAVA);
		if (SDKInterface.instance.adultCheakcallback != null)
		{
			if (array != null)
			{
				if (array.Length == 3)
				{
					SDKInterface.instance.adultCheakcallback(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
				}
				else
				{
					SDKInterface.instance.adultCheakcallback(0, 2, 0);
				}
			}
			else
			{
				SDKInterface.instance.adultCheakcallback(0, 2, 0);
			}
		}
		else
		{
			SDKInterface.instance.adultCheakcallback(0, 2, 0);
		}
	}

	// Token: 0x060194E2 RID: 103650 RVA: 0x00801B6F File Offset: 0x007FFF6F
	private string[] ParseCallBackParams(string params_JAVA)
	{
		return params_JAVA.Split(new char[]
		{
			','
		});
	}

	// Token: 0x0401228F RID: 74383
	private const int TOTAL_COUNTDOWN = 120;

	// Token: 0x04012290 RID: 74384
	private const float LOW_SCREEN_BRIGHTNESS = 0.01f;

	// Token: 0x04012291 RID: 74385
	private float deviceScreenBrightness = 0.5f;

	// Token: 0x04012292 RID: 74386
	private SimpleTimer2 timer;

	// Token: 0x04012293 RID: 74387
	private bool screenSaverInited;

	// Token: 0x04012294 RID: 74388
	private float durationTimeTemp;

	// Token: 0x04012295 RID: 74389
	private float durationTimeTemp2;

	// Token: 0x04012296 RID: 74390
	private ushort roleLevel;

	// Token: 0x04012297 RID: 74391
	private float checkAcc;

	// Token: 0x04012298 RID: 74392
	private bool canRead;

	// Token: 0x04012299 RID: 74393
	private float tempAcc;

	// Token: 0x0401229A RID: 74394
	private const float STAT_DURATION = 120f;

	// Token: 0x0401229B RID: 74395
	private bool needCheckTempure;

	// Token: 0x0401229C RID: 74396
	public int cpuTempture;

	// Token: 0x0401229D RID: 74397
	public int batteryTempture;

	// Token: 0x0401229E RID: 74398
	public int frameRate;

	// Token: 0x0401229F RID: 74399
	public int batteryLevel;

	// Token: 0x040122A0 RID: 74400
	public int batteryConsume;

	// Token: 0x040122A1 RID: 74401
	private bool valueUpated;

	// Token: 0x040122A2 RID: 74402
	private float tempBuglyInfoTimer;

	// Token: 0x040122A3 RID: 74403
	private const float BUGLY_INFO_DURATION = 15f;
}
