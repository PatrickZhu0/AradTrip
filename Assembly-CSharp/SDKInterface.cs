using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using GameClient;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x02004649 RID: 17993
public class SDKInterface
{
	// Token: 0x060194ED RID: 103661 RVA: 0x00801D78 File Offset: 0x00800178
	private static SDKInterface _createInstanceByClassName(string name)
	{
		SDKInterface result;
		try
		{
			Assembly assembly = Assembly.GetAssembly(typeof(SDKInterface));
			result = (assembly.CreateInstance(name) as SDKInterface);
		}
		catch (Exception ex)
		{
			result = new SDKInterfaceDefault();
		}
		return result;
	}

	// Token: 0x060194EE RID: 103662 RVA: 0x00801DC4 File Offset: 0x008001C4
	private static SDKInterface _getSDKInstance()
	{
		switch (Global.Settings.sdkChannel)
		{
		case SDKChannel.NONE:
		case SDKChannel.COUNT:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid");
		case SDKChannel.XY:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_XY");
		case SDKChannel.MG:
		case SDKChannel.TestMG:
		case SDKChannel.MGYingYB:
		case SDKChannel.MGOther:
		case SDKChannel.MGOtherHC:
		case SDKChannel.TestInMG:
		case SDKChannel.MGOther915:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_MG");
		case SDKChannel.SN79:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_SN79");
		case SDKChannel.HuaWei:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_HuaWei");
		case SDKChannel.OPPO:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_OPPO");
		case SDKChannel.VIVO:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_VIVO");
		case SDKChannel.Lenovo:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_Lenovo");
		case SDKChannel.KuPai:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_KuPai");
		case SDKChannel.JinLi:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_JinLi");
		case SDKChannel.MeiZu:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_MeiZu");
		case SDKChannel.BaiDu:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_BAIDU");
		case SDKChannel.XiaoMi:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_XIAOMI");
		case SDKChannel.SanXing:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_SAMSUNG");
		case SDKChannel.M4399:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_4399");
		case SDKChannel.M360:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_360");
		case SDKChannel.M915:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_915");
		case SDKChannel.JUNHAI:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_JunHai");
		case SDKChannel.JoyLand:
			return SDKInterface._createInstanceByClassName("SDKInterfaceAndroid_JoyLand");
		}
		return new SDKInterfaceDefault();
	}

	// Token: 0x170020D0 RID: 8400
	// (get) Token: 0x060194EF RID: 103663 RVA: 0x00801F75 File Offset: 0x00800375
	public static SDKInterface instance
	{
		get
		{
			if (SDKInterface._instance == null)
			{
				SDKInterface._instance = SDKInterface._getSDKInstance();
			}
			return SDKInterface._instance;
		}
	}

	// Token: 0x060194F0 RID: 103664 RVA: 0x00801F90 File Offset: 0x00800390
	public static bool IsNewSDKChannelPay()
	{
		return Global.Settings.sdkChannel != SDKChannel.NONE && Global.Settings.sdkChannel != SDKChannel.COUNT && Global.Settings.sdkChannel != SDKChannel.MG && Global.Settings.sdkChannel != SDKChannel.SN79 && Global.Settings.sdkChannel != SDKChannel.TB && Global.Settings.sdkChannel != SDKChannel.AISI && Global.Settings.sdkChannel != SDKChannel.XY && Global.Settings.sdkChannel != SDKChannel.TestMG && Global.Settings.sdkChannel != SDKChannel.MGYingYB && Global.Settings.sdkChannel != SDKChannel.ZY && Global.Settings.sdkChannel != SDKChannel.ZYOL && Global.Settings.sdkChannel != SDKChannel.ZYYH && Global.Settings.sdkChannel != SDKChannel.ZYHD && Global.Settings.sdkChannel != SDKChannel.ZYWZ && Global.Settings.sdkChannel != SDKChannel.MGOther && Global.Settings.sdkChannel != SDKChannel.ZYYZ && Global.Settings.sdkChannel != SDKChannel.ZYYS && Global.Settings.sdkChannel != SDKChannel.ZYLK && Global.Settings.sdkChannel != SDKChannel.ZYGB && Global.Settings.sdkChannel != SDKChannel.ZYMG && Global.Settings.sdkChannel != SDKChannel.ZYYY && Global.Settings.sdkChannel != SDKChannel.ZYNL && Global.Settings.sdkChannel != SDKChannel.ZYSY && Global.Settings.sdkChannel != SDKChannel.MGOtherHC && Global.Settings.sdkChannel != SDKChannel.TestInMG && Global.Settings.sdkChannel != SDKChannel.DYCC && Global.Settings.sdkChannel != SDKChannel.MGDY && Global.Settings.sdkChannel != SDKChannel.DYAY && Global.Settings.sdkChannel != SDKChannel.MGOther915 && Global.Settings.sdkChannel != SDKChannel.ZYOther;
	}

	// Token: 0x060194F1 RID: 103665 RVA: 0x00802194 File Offset: 0x00800594
	public bool IsMGChannel()
	{
		return Global.Settings.sdkChannel == SDKChannel.MG || Global.Settings.sdkChannel == SDKChannel.ZY || Global.Settings.sdkChannel == SDKChannel.ZYHD || Global.Settings.sdkChannel == SDKChannel.ZYOL || Global.Settings.sdkChannel == SDKChannel.ZYWZ || Global.Settings.sdkChannel == SDKChannel.ZYYH || Global.Settings.sdkChannel == SDKChannel.ZYYZ || Global.Settings.sdkChannel == SDKChannel.ZYYS || Global.Settings.sdkChannel == SDKChannel.ZYLK || Global.Settings.sdkChannel == SDKChannel.ZYGB || Global.Settings.sdkChannel == SDKChannel.ZYMG || Global.Settings.sdkChannel == SDKChannel.ZYYY || Global.Settings.sdkChannel == SDKChannel.ZYNL || Global.Settings.sdkChannel == SDKChannel.ZYSY || Global.Settings.sdkChannel == SDKChannel.DYCC || Global.Settings.sdkChannel == SDKChannel.MGDY || Global.Settings.sdkChannel == SDKChannel.DYAY || Global.Settings.sdkChannel == SDKChannel.ZYOther;
	}

	// Token: 0x060194F2 RID: 103666 RVA: 0x008022D5 File Offset: 0x008006D5
	public bool IsIOSOtherChannel()
	{
		return Global.Settings.sdkChannel == SDKChannel.XY || Global.Settings.sdkChannel == SDKChannel.AISI;
	}

	// Token: 0x060194F3 RID: 103667 RVA: 0x008022FC File Offset: 0x008006FC
	public bool HasVIPAuth()
	{
		bool flag = false;
		if (Global.VipAuthSDKChannel != null && Global.VipAuthSDKChannel.Length > 0)
		{
			foreach (SDKChannel sdkchannel in Global.VipAuthSDKChannel)
			{
				if (sdkchannel == Global.Settings.sdkChannel)
				{
					flag = true;
					break;
				}
			}
		}
		return this.IsMGChannel() || flag;
	}

	// Token: 0x060194F4 RID: 103668 RVA: 0x0080236C File Offset: 0x0080076C
	public bool IsRealNameAuth()
	{
		if (Global.RealNamePopWindowsChannel != null && Global.RealNamePopWindowsChannel.Length > 0)
		{
			foreach (SDKChannel sdkchannel in Global.RealNamePopWindowsChannel)
			{
				if (sdkchannel == Global.Settings.sdkChannel)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060194F5 RID: 103669 RVA: 0x008023C4 File Offset: 0x008007C4
	public bool IsVersionOpen(SDKChannel[] channelist)
	{
		if (channelist != null && channelist.Length > 0)
		{
			foreach (SDKChannel sdkchannel in channelist)
			{
				if (sdkchannel == Global.Settings.sdkChannel)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060194F6 RID: 103670 RVA: 0x00802410 File Offset: 0x00800810
	public virtual void Init(bool debug)
	{
		SDKCallback instance = MonoSingleton<SDKCallback>.instance;
	}

	// Token: 0x060194F7 RID: 103671 RVA: 0x00802423 File Offset: 0x00800823
	public virtual void Login()
	{
	}

	// Token: 0x060194F8 RID: 103672 RVA: 0x00802425 File Offset: 0x00800825
	public virtual void Logout()
	{
	}

	// Token: 0x060194F9 RID: 103673 RVA: 0x00802427 File Offset: 0x00800827
	public virtual void Pay(string price, string extra = "", int serverID = 0, string openuid = "")
	{
	}

	// Token: 0x060194FA RID: 103674 RVA: 0x00802429 File Offset: 0x00800829
	public virtual void Pay(string price, string extra = "", int serverID = 0, string openuid = "", string productName = "", string productDesc = "")
	{
	}

	// Token: 0x060194FB RID: 103675 RVA: 0x0080242B File Offset: 0x0080082B
	public virtual void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
	}

	// Token: 0x060194FC RID: 103676 RVA: 0x0080242D File Offset: 0x0080082D
	public virtual string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}", new object[]
		{
			serverUrl,
			serverId,
			openuid,
			token,
			deviceId,
			sdkChannel
		});
	}

	// Token: 0x060194FD RID: 103677 RVA: 0x0080245A File Offset: 0x0080085A
	public virtual void ResetBadge()
	{
	}

	// Token: 0x060194FE RID: 103678 RVA: 0x0080245C File Offset: 0x0080085C
	public virtual void SetNotification(int nid, string content, string title, int hour)
	{
	}

	// Token: 0x060194FF RID: 103679 RVA: 0x0080245E File Offset: 0x0080085E
	public virtual void SetNotificationWeekly(int nid, string content, string title, int weekday, int hour, int minute)
	{
	}

	// Token: 0x06019500 RID: 103680 RVA: 0x00802460 File Offset: 0x00800860
	public virtual void RemoveNotification(int nid)
	{
	}

	// Token: 0x06019501 RID: 103681 RVA: 0x00802462 File Offset: 0x00800862
	public virtual void RemoveAllNotification()
	{
	}

	// Token: 0x06019502 RID: 103682 RVA: 0x00802464 File Offset: 0x00800864
	public virtual void SetScreenBrightness(float value)
	{
	}

	// Token: 0x06019503 RID: 103683 RVA: 0x00802466 File Offset: 0x00800866
	public virtual float GetScreenBrightness()
	{
		return 0.5f;
	}

	// Token: 0x06019504 RID: 103684 RVA: 0x0080246D File Offset: 0x0080086D
	public virtual void KeepScreenOn(bool isOn)
	{
	}

	// Token: 0x06019505 RID: 103685 RVA: 0x0080246F File Offset: 0x0080086F
	public virtual void Exit()
	{
	}

	// Token: 0x06019506 RID: 103686 RVA: 0x00802471 File Offset: 0x00800871
	public virtual float GetBatteryLevel()
	{
		return 1f;
	}

	// Token: 0x06019507 RID: 103687 RVA: 0x00802478 File Offset: 0x00800878
	public virtual bool IsBatteryCharging()
	{
		return true;
	}

	// Token: 0x06019508 RID: 103688 RVA: 0x0080247C File Offset: 0x0080087C
	public virtual string GetSystemTimeHHMM()
	{
		DateTime now = DateTime.Now;
		return string.Format("{0:HH:mm}", now);
	}

	// Token: 0x06019509 RID: 103689 RVA: 0x0080249F File Offset: 0x0080089F
	public virtual bool RequestAudioAuthorization()
	{
		return false;
	}

	// Token: 0x0601950A RID: 103690 RVA: 0x008024A2 File Offset: 0x008008A2
	public virtual void SetAudioSessionActive()
	{
	}

	// Token: 0x0601950B RID: 103691 RVA: 0x008024A4 File Offset: 0x008008A4
	public virtual string GetSystemTimeStamp()
	{
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return ((uint)(DateTime.Now - d).TotalSeconds).ToString();
	}

	// Token: 0x0601950C RID: 103692 RVA: 0x008024EC File Offset: 0x008008EC
	public virtual string GetProductId(int id)
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChargeGearTable>();
		if (table != null)
		{
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChargeGearTable chargeGearTable = keyValuePair.Value as ChargeGearTable;
				if (Global.Settings.sdkChannel.ToString().Equals(chargeGearTable.Channel) && id > 0 && chargeGearTable.ProductIds.Count >= id)
				{
					return chargeGearTable.ProductIds[id - 1];
				}
			}
		}
		return string.Empty;
	}

	// Token: 0x0601950D RID: 103693 RVA: 0x00802588 File Offset: 0x00800988
	public virtual string GetClipboardText()
	{
		return string.Empty;
	}

	// Token: 0x0601950E RID: 103694 RVA: 0x0080258F File Offset: 0x0080098F
	public virtual void QuitApplicationOnEsc()
	{
	}

	// Token: 0x0601950F RID: 103695 RVA: 0x00802591 File Offset: 0x00800991
	public virtual bool NeedSDKBindPhoneOpen()
	{
		return false;
	}

	// Token: 0x06019510 RID: 103696 RVA: 0x00802594 File Offset: 0x00800994
	public virtual void OpenBindPhone()
	{
	}

	// Token: 0x06019511 RID: 103697 RVA: 0x00802596 File Offset: 0x00800996
	public virtual void CheckIsPhoneBind()
	{
	}

	// Token: 0x06019512 RID: 103698 RVA: 0x00802598 File Offset: 0x00800998
	public virtual bool CanSetCreateRoleInfoInFiveMin()
	{
		return false;
	}

	// Token: 0x06019513 RID: 103699 RVA: 0x0080259B File Offset: 0x0080099B
	public virtual void SetCreateRoleInfo(string accid, string roleid)
	{
	}

	// Token: 0x06019514 RID: 103700 RVA: 0x0080259D File Offset: 0x0080099D
	public virtual void SetCreateRoleInFiveInfo(string accid, string roleid)
	{
	}

	// Token: 0x06019515 RID: 103701 RVA: 0x0080259F File Offset: 0x0080099F
	public virtual void SetRoleUpLevelInfo(string accid, string roleid, string roleLevel)
	{
	}

	// Token: 0x06019516 RID: 103702 RVA: 0x008025A1 File Offset: 0x008009A1
	public virtual void SetCreateRoleInfo(string accid, string roleid, string roleName, string roleLevel, string serverName, string roleRank, string beSociaty)
	{
	}

	// Token: 0x06019517 RID: 103703 RVA: 0x008025A3 File Offset: 0x008009A3
	public virtual void SetCreateRoleInfo(string roleName, int serverId)
	{
	}

	// Token: 0x06019518 RID: 103704 RVA: 0x008025A5 File Offset: 0x008009A5
	public virtual void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
	}

	// Token: 0x06019519 RID: 103705 RVA: 0x008025A7 File Offset: 0x008009A7
	public virtual void InitServicePush(string gameObjectName)
	{
	}

	// Token: 0x0601951A RID: 103706 RVA: 0x008025A9 File Offset: 0x008009A9
	public virtual void TurnOnServicePush()
	{
	}

	// Token: 0x0601951B RID: 103707 RVA: 0x008025AB File Offset: 0x008009AB
	public virtual void TurnOffServicePush()
	{
	}

	// Token: 0x0601951C RID: 103708 RVA: 0x008025AD File Offset: 0x008009AD
	public virtual bool BindOtherName(string alias)
	{
		return false;
	}

	// Token: 0x0601951D RID: 103709 RVA: 0x008025B0 File Offset: 0x008009B0
	public virtual bool UnBindOtherName(string alias)
	{
		return false;
	}

	// Token: 0x0601951E RID: 103710 RVA: 0x008025B3 File Offset: 0x008009B3
	public virtual int GetKeyboardSize()
	{
		return 0;
	}

	// Token: 0x0601951F RID: 103711 RVA: 0x008025B6 File Offset: 0x008009B6
	public virtual int TryGetCurrVersionAPI()
	{
		return 0;
	}

	// Token: 0x06019520 RID: 103712 RVA: 0x008025B9 File Offset: 0x008009B9
	public virtual void LBRequestUpdate()
	{
	}

	// Token: 0x06019521 RID: 103713 RVA: 0x008025BB File Offset: 0x008009BB
	public virtual void LBDownloadFullRes()
	{
	}

	// Token: 0x06019522 RID: 103714 RVA: 0x008025BD File Offset: 0x008009BD
	public virtual bool LBIsAfterUpdate()
	{
		return false;
	}

	// Token: 0x06019523 RID: 103715 RVA: 0x008025C0 File Offset: 0x008009C0
	public virtual string LBGetFullResPath()
	{
		return string.Empty;
	}

	// Token: 0x06019524 RID: 103716 RVA: 0x008025C7 File Offset: 0x008009C7
	public virtual void SaveDoc(string content, string parentPathName, string fileName, bool isAppend = true)
	{
	}

	// Token: 0x06019525 RID: 103717 RVA: 0x008025C9 File Offset: 0x008009C9
	public virtual string ReadDoc(string parentPathName, string fileName)
	{
		return string.Empty;
	}

	// Token: 0x06019526 RID: 103718 RVA: 0x008025D0 File Offset: 0x008009D0
	public virtual float GetCpuTemperature()
	{
		return 0f;
	}

	// Token: 0x06019527 RID: 103719 RVA: 0x008025D7 File Offset: 0x008009D7
	public virtual float GetBatteryTemperature()
	{
		return 0f;
	}

	// Token: 0x06019528 RID: 103720 RVA: 0x008025DE File Offset: 0x008009DE
	public virtual string GetAvailMemory()
	{
		return string.Empty;
	}

	// Token: 0x06019529 RID: 103721 RVA: 0x008025E5 File Offset: 0x008009E5
	public virtual string GetCurrentProcessMemory()
	{
		return string.Empty;
	}

	// Token: 0x0601952A RID: 103722 RVA: 0x008025EC File Offset: 0x008009EC
	public virtual string GetMonoMemory()
	{
		return null;
	}

	// Token: 0x0601952B RID: 103723 RVA: 0x008025EF File Offset: 0x008009EF
	public virtual int GetMemLogTotalpss()
	{
		return 0;
	}

	// Token: 0x0601952C RID: 103724 RVA: 0x008025F2 File Offset: 0x008009F2
	public virtual string GetMemLogAll()
	{
		return string.Empty;
	}

	// Token: 0x0601952D RID: 103725 RVA: 0x008025F9 File Offset: 0x008009F9
	public virtual bool IsSimulator()
	{
		return false;
	}

	// Token: 0x0601952E RID: 103726 RVA: 0x008025FC File Offset: 0x008009FC
	public virtual string GetSimulatorName()
	{
		return string.Empty;
	}

	// Token: 0x0601952F RID: 103727 RVA: 0x00802603 File Offset: 0x00800A03
	public virtual bool HasSDKAdultCheakAuth()
	{
		return false;
	}

	// Token: 0x06019530 RID: 103728 RVA: 0x00802608 File Offset: 0x00800A08
	public virtual void GetRealNameInfo()
	{
		MonoSingleton<SDKCallback>.instance.OnAdultCheakRet("0," + 2.ToString() + ",0");
	}

	// Token: 0x06019531 RID: 103729 RVA: 0x0080263D File Offset: 0x00800A3D
	public virtual void GetRealNameInfo_NotLogin()
	{
	}

	// Token: 0x06019532 RID: 103730 RVA: 0x0080263F File Offset: 0x00800A3F
	public virtual bool CanOpenAdultCheakWindow()
	{
		return false;
	}

	// Token: 0x06019533 RID: 103731 RVA: 0x00802642 File Offset: 0x00800A42
	public virtual void OpenAdultCheakWindow()
	{
	}

	// Token: 0x06019534 RID: 103732 RVA: 0x00802644 File Offset: 0x00800A44
	public virtual string ExtendLoginVerifyUrl()
	{
		string text = string.Empty;
		text = string.Format("&model={0}&device_version={1}&age={2}&is_id_auth={3}", new object[]
		{
			this.GetDeviceModelType(),
			this.GetOperationSystemInfo(),
			ClientApplication.playerinfo.age,
			(int)ClientApplication.playerinfo.authType
		});
		if (this.IsYueYuPag())
		{
			text = string.Format("{0}&platform2={1}", text, Global.Settings.sdkChannel.ToString().ToLower());
		}
		return text;
	}

	// Token: 0x06019535 RID: 103733 RVA: 0x008026D0 File Offset: 0x00800AD0
	public string GetOperationSystemInfo()
	{
		return this.UrlFormatFilter(SystemInfo.operatingSystem);
	}

	// Token: 0x06019536 RID: 103734 RVA: 0x008026DD File Offset: 0x00800ADD
	public string GetDeviceModelType()
	{
		return this.UrlFormatFilter(SystemInfo.deviceModel);
	}

	// Token: 0x06019537 RID: 103735 RVA: 0x008026EA File Offset: 0x00800AEA
	private string UrlFormatFilter(string originStr)
	{
		return originStr.Replace(" ", "_").Replace("&", "_").Replace("|", "_").Replace(";", "_");
	}

	// Token: 0x06019538 RID: 103736 RVA: 0x00802729 File Offset: 0x00800B29
	public virtual string GetBuildPlatformId()
	{
		return "0";
	}

	// Token: 0x06019539 RID: 103737 RVA: 0x00802730 File Offset: 0x00800B30
	public virtual string GetOnlineServicePlatformId()
	{
		return "3";
	}

	// Token: 0x0601953A RID: 103738 RVA: 0x00802737 File Offset: 0x00800B37
	public virtual string GetOnlineServicePlatformName()
	{
		return "other";
	}

	// Token: 0x0601953B RID: 103739 RVA: 0x0080273E File Offset: 0x00800B3E
	public virtual void MobileVibrate()
	{
		Handheld.Vibrate();
	}

	// Token: 0x0601953C RID: 103740 RVA: 0x00802745 File Offset: 0x00800B45
	public virtual void ScanFile(string path)
	{
	}

	// Token: 0x0601953D RID: 103741 RVA: 0x00802747 File Offset: 0x00800B47
	public virtual void InitAlartText(string title, string message, string btnText)
	{
	}

	// Token: 0x0601953E RID: 103742 RVA: 0x0080274C File Offset: 0x00800B4C
	public virtual bool NeedShowBanQuanMsg()
	{
		return Global.Settings.sdkChannel == SDKChannel.DYCC || Global.Settings.sdkChannel == SDKChannel.MGDY || Global.Settings.sdkChannel == SDKChannel.DYAY || Global.Settings.sdkChannel == SDKChannel.ZYNL;
	}

	// Token: 0x0601953F RID: 103743 RVA: 0x008027A0 File Offset: 0x00800BA0
	public virtual bool NeedHideLoginFrameLogoImg()
	{
		return Global.Settings.sdkChannel == SDKChannel.DYCC || Global.Settings.sdkChannel == SDKChannel.MGDY || Global.Settings.sdkChannel == SDKChannel.DYAY || Global.Settings.sdkChannel == SDKChannel.ZYNL;
	}

	// Token: 0x06019540 RID: 103744 RVA: 0x008027F4 File Offset: 0x00800BF4
	public virtual bool IsYueYuPag()
	{
		return Global.Settings.sdkChannel == SDKChannel.ZYOther;
	}

	// Token: 0x06019541 RID: 103745 RVA: 0x0080280A File Offset: 0x00800C0A
	public virtual void InitBreakpad()
	{
	}

	// Token: 0x06019542 RID: 103746 RVA: 0x0080280C File Offset: 0x00800C0C
	public virtual void CRASH()
	{
	}

	// Token: 0x06019543 RID: 103747 RVA: 0x00802810 File Offset: 0x00800C10
	public virtual string GenerateRequestPayID(string roleId, string timeStamp = "", string ext = "", int limitLenght = -1)
	{
		string text = string.Empty;
		if (timeStamp == string.Empty)
		{
			timeStamp = this.TransLocalNowDateToStamp() + string.Empty;
		}
		text = roleId + timeStamp + ext;
		if (limitLenght > 0 && string.IsNullOrEmpty(text))
		{
			text = text.Substring(0, limitLenght);
		}
		return text;
	}

	// Token: 0x06019544 RID: 103748 RVA: 0x00802874 File Offset: 0x00800C74
	public virtual uint TransLocalNowDateToStamp()
	{
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return (uint)(DateTime.Now - d).TotalSeconds;
	}

	// Token: 0x06019545 RID: 103749 RVA: 0x008028B0 File Offset: 0x00800CB0
	public virtual string MD5CreateNormal(string STR)
	{
		string text = string.Empty;
		if (string.IsNullOrEmpty(STR))
		{
			return text;
		}
		MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
		text = BitConverter.ToString(md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(STR)));
		text = text.Replace("-", string.Empty);
		return text.ToLowerInvariant();
	}

	// Token: 0x06019546 RID: 103750 RVA: 0x00802904 File Offset: 0x00800D04
	public virtual void SetAccInfo(string openid, string accesstoken)
	{
	}

	// Token: 0x06019547 RID: 103751 RVA: 0x00802908 File Offset: 0x00800D08
	public virtual string[] GetSplashResourcePath()
	{
		string text = "Base/UI/Image/aladezhinu";
		return new string[]
		{
			text
		};
	}

	// Token: 0x06019548 RID: 103752 RVA: 0x00802928 File Offset: 0x00800D28
	public virtual string GetServerListName(bool isChangePack = false)
	{
		if (isChangePack && !string.IsNullOrEmpty(SDKInterface.STR_SERVERLIST_CHANGE_PACKAGE))
		{
			return SDKInterface.STR_SERVERLIST_CHANGE_PACKAGE;
		}
		if (Global.Settings.sdkChannel == SDKChannel.MGOther)
		{
			return SDKInterface.STR_SERVERLIST_CORE2;
		}
		if (Global.Settings.sdkChannel == SDKChannel.MGOtherHC)
		{
			return SDKInterface.STR_SERVERLIST_CORE;
		}
		if (Global.Settings.sdkChannel == SDKChannel.M915 || Global.Settings.sdkChannel == SDKChannel.MGOther915)
		{
			return SDKInterface.STR_SERVERLIST_CORE_915;
		}
		if (!SDKInterface.IsNewSDKChannelPay())
		{
			return SDKInterface.STR_SERVERLIST;
		}
		if (Global.Settings.sdkChannel == SDKChannel.BaiDu || Global.Settings.sdkChannel == SDKChannel.XiaoMi || Global.Settings.sdkChannel == SDKChannel.SanXing || Global.Settings.sdkChannel == SDKChannel.M4399 || Global.Settings.sdkChannel == SDKChannel.M360 || Global.Settings.sdkChannel == SDKChannel.MGOther || Global.Settings.sdkChannel == SDKChannel.JoyLand || Global.Settings.sdkChannel == SDKChannel.MGOtherHC)
		{
			return SDKInterface.STR_SERVERLIST_CORE2;
		}
		if (Global.Settings.sdkChannel == SDKChannel.JUNHAI)
		{
			return SDKInterface.STR_SERVERLIST_CORE_JUNHAI;
		}
		return SDKInterface.STR_SERVERLIST_CORE;
	}

	// Token: 0x06019549 RID: 103753 RVA: 0x00802A60 File Offset: 0x00800E60
	public virtual bool IsPayResultNotify()
	{
		return Global.Settings.sdkChannel == SDKChannel.M915 || Global.Settings.sdkChannel == SDKChannel.JUNHAI || Global.Settings.sdkChannel == SDKChannel.MGOther || Global.Settings.sdkChannel == SDKChannel.MG || Global.Settings.sdkChannel == SDKChannel.MGYingYB || Global.Settings.sdkChannel == SDKChannel.JoyLand || Global.Settings.sdkChannel == SDKChannel.MGOtherHC || Global.Settings.sdkChannel == SDKChannel.MGOther915;
	}

	// Token: 0x0601954A RID: 103754 RVA: 0x00802AF5 File Offset: 0x00800EF5
	public virtual string GetSystemIMEI()
	{
		return string.Empty;
	}

	// Token: 0x0601954B RID: 103755 RVA: 0x00802AFC File Offset: 0x00800EFC
	public virtual bool IsStartFromGameCenter()
	{
		return false;
	}

	// Token: 0x0601954C RID: 103756 RVA: 0x00802AFF File Offset: 0x00800EFF
	public virtual bool IsOppoPlatform()
	{
		return Global.Settings.sdkChannel == SDKChannel.OPPO;
	}

	// Token: 0x0601954D RID: 103757 RVA: 0x00802B15 File Offset: 0x00800F15
	public virtual void GotoSDKChannelCommunity()
	{
	}

	// Token: 0x0601954E RID: 103758 RVA: 0x00802B17 File Offset: 0x00800F17
	public virtual bool IsVivoPlatForm()
	{
		return Global.Settings.sdkChannel == SDKChannel.VIVO;
	}

	// Token: 0x0601954F RID: 103759 RVA: 0x00802B2D File Offset: 0x00800F2D
	public virtual void OpenGameCenter()
	{
	}

	// Token: 0x06019550 RID: 103760 RVA: 0x00802B30 File Offset: 0x00800F30
	public virtual string GetPlatformNameByChannel()
	{
		string result = "none";
		string[] sdkchannelName = Global.SDKChannelName;
		if (sdkchannelName != null && sdkchannelName.Length == 45)
		{
			result = sdkchannelName[(int)Global.Settings.sdkChannel];
		}
		return result;
	}

	// Token: 0x06019551 RID: 103761 RVA: 0x00802B67 File Offset: 0x00800F67
	public virtual string GetPlatformNameBySelect()
	{
		return Global.channelName;
	}

	// Token: 0x06019552 RID: 103762 RVA: 0x00802B6E File Offset: 0x00800F6E
	public virtual bool NeedPayToken()
	{
		return Global.Settings.sdkChannel == SDKChannel.KuPai || Global.Settings.sdkChannel == SDKChannel.JUNHAI;
	}

	// Token: 0x06019553 RID: 103763 RVA: 0x00802B95 File Offset: 0x00800F95
	public static bool BeOtherChannel()
	{
		return Global.Settings.sdkChannel == SDKChannel.M915 || Global.Settings.sdkChannel == SDKChannel.JUNHAI;
	}

	// Token: 0x06019554 RID: 103764 RVA: 0x00802BBC File Offset: 0x00800FBC
	public static bool NeedChannelHideVersionUpdateProgress()
	{
		return Global.Settings.sdkChannel == SDKChannel.DYCC || Global.Settings.sdkChannel == SDKChannel.MGDY || Global.Settings.sdkChannel == SDKChannel.DYAY || Global.Settings.sdkChannel == SDKChannel.ZYNL;
	}

	// Token: 0x06019555 RID: 103765 RVA: 0x00802C10 File Offset: 0x00801010
	public virtual void NeedLogoutSDK()
	{
		if (Global.Settings.sdkChannel == SDKChannel.JoyLand || Global.Settings.sdkChannel == SDKChannel.DYCC || Global.Settings.sdkChannel == SDKChannel.MGDY || Global.Settings.sdkChannel == SDKChannel.DYAY)
		{
			this.Logout();
		}
	}

	// Token: 0x06019556 RID: 103766 RVA: 0x00802C67 File Offset: 0x00801067
	public virtual bool NeedChangeUpdateBtnPos()
	{
		return Global.Settings.sdkChannel == SDKChannel.ZYOther;
	}

	// Token: 0x06019557 RID: 103767 RVA: 0x00802C7D File Offset: 0x0080107D
	public virtual string NeedUriEncodeOpenid(string openid)
	{
		if (string.IsNullOrEmpty(openid))
		{
			return string.Empty;
		}
		if (Global.Settings.sdkChannel == SDKChannel.JoyLand)
		{
			openid = Uri.EscapeDataString(openid);
		}
		return openid;
	}

	// Token: 0x06019558 RID: 103768 RVA: 0x00802CAA File Offset: 0x008010AA
	public virtual bool CheckPlatformBySDKChannel(SDKChannel sdkChannel)
	{
		return Global.Settings.sdkChannel == sdkChannel;
	}

	// Token: 0x06019559 RID: 103769 RVA: 0x00802CBF File Offset: 0x008010BF
	public virtual SDKChannel GetCurrentSDKChannel()
	{
		return Global.Settings.sdkChannel;
	}

	// Token: 0x0601955A RID: 103770 RVA: 0x00802CCB File Offset: 0x008010CB
	public virtual void GetNewVersionInAppstore()
	{
	}

	// Token: 0x0601955B RID: 103771 RVA: 0x00802CCD File Offset: 0x008010CD
	public virtual string GetIOSAppstoreSmallGameLoadSceneName()
	{
		return "select";
	}

	// Token: 0x0601955C RID: 103772 RVA: 0x00802CD4 File Offset: 0x008010D4
	public virtual bool IsIOSAppstoreLoadSmallGame()
	{
		return false;
	}

	// Token: 0x0601955D RID: 103773 RVA: 0x00802CD7 File Offset: 0x008010D7
	public virtual void TryGetIOSAppstoreProductIds()
	{
	}

	// Token: 0x0601955E RID: 103774 RVA: 0x00802CD9 File Offset: 0x008010D9
	public virtual void SendGameServerSystemIMEI()
	{
		if (this.imeiCoroutine != null)
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.imeiCoroutine);
		}
		this.imeiCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.WaitToReportIMEI(5000));
	}

	// Token: 0x0601955F RID: 103775 RVA: 0x00802D14 File Offset: 0x00801114
	private IEnumerator WaitToReportIMEI(int timeout)
	{
		string serverAdd = string.Empty;
		serverAdd = Global.ANDROID_MG_CHARGE;
		if (string.IsNullOrEmpty(serverAdd))
		{
			yield break;
		}
		BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
		string sendUrl = string.Format("http://{0}/report?openid={1}&imei={2}&platform={3}", new object[]
		{
			serverAdd,
			ClientApplication.playerinfo.openuid,
			this.GetSystemIMEI(),
			Global.channelName
		});
		wt.url = sendUrl;
		wt.timeout = timeout;
		wt.gaptime = 0;
		wt.reconnectCnt = 0;
		yield return wt;
		if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
		{
			string resText = wt.GetResultString();
			int retCode = -1;
			if (string.IsNullOrEmpty(resText))
			{
				yield return null;
			}
			Hashtable ret = (Hashtable)MiniJSON.jsonDecode(resText);
			try
			{
				if (int.TryParse(ret["error"].ToString(), out retCode) && retCode != 0)
				{
					string text = ret["msg"].ToString();
				}
			}
			catch (Exception ex)
			{
			}
		}
		yield break;
	}

	// Token: 0x06019560 RID: 103776 RVA: 0x00802D38 File Offset: 0x00801138
	public Hashtable JsontoHashtable(string jsonData)
	{
		Hashtable result = null;
		try
		{
			if (string.IsNullOrEmpty(jsonData))
			{
				return result;
			}
			result = (MiniJSON.jsonDecode(jsonData) as Hashtable);
		}
		catch (Exception ex)
		{
			Debug.LogError("JsontoHashtablehas failed! Exception:" + ex.ToString());
		}
		return result;
	}

	// Token: 0x06019561 RID: 103777 RVA: 0x00802D98 File Offset: 0x00801198
	public virtual bool IsResourceDownloadFinished()
	{
		return true;
	}

	// Token: 0x06019562 RID: 103778 RVA: 0x00802D9B File Offset: 0x0080119B
	public virtual bool IsSmallPackage()
	{
		return false;
	}

	// Token: 0x06019563 RID: 103779 RVA: 0x00802D9E File Offset: 0x0080119E
	public virtual long GetResourceDownloadedSize()
	{
		return 0L;
	}

	// Token: 0x06019564 RID: 103780 RVA: 0x00802DA2 File Offset: 0x008011A2
	public virtual long GetTotalResourceDownloadSize()
	{
		return 0L;
	}

	// Token: 0x06019565 RID: 103781 RVA: 0x00802DA6 File Offset: 0x008011A6
	public virtual void OpenDownload()
	{
	}

	// Token: 0x06019566 RID: 103782 RVA: 0x00802DA8 File Offset: 0x008011A8
	public virtual void CloseDownload()
	{
	}

	// Token: 0x06019567 RID: 103783 RVA: 0x00802DAA File Offset: 0x008011AA
	public virtual bool IsDownload()
	{
		return false;
	}

	// Token: 0x040122A9 RID: 74409
	public static string STR_SERVERLIST = "serverList.xml";

	// Token: 0x040122AA RID: 74410
	public static string STR_SERVERLIST_CORE = "serverList_core.xml";

	// Token: 0x040122AB RID: 74411
	public static string STR_SERVERLIST_CORE2 = "serverList_core2.xml";

	// Token: 0x040122AC RID: 74412
	public static string STR_SERVERLIST_CORE_915 = "serverList_core3.xml";

	// Token: 0x040122AD RID: 74413
	public static string STR_SERVERLIST_CORE_JUNHAI = "serverList_core4.xml";

	// Token: 0x040122AE RID: 74414
	public static string STR_SERVERLIST_IOS_APPSTORE = "serverList_ios_appstore.xml";

	// Token: 0x040122AF RID: 74415
	public static string STR_SERVERLIST_IOS_APPSTORE_CORE_CC = "serverList_ios_appstore_core_cc.xml";

	// Token: 0x040122B0 RID: 74416
	public static string STR_SERVERLIST_CHANGE_PACKAGE = string.Empty;

	// Token: 0x040122B1 RID: 74417
	public SDKInterface.LoginCallback loginCallbackGame;

	// Token: 0x040122B2 RID: 74418
	public SDKInterface.LogoutCallback logoutCallbackGame;

	// Token: 0x040122B3 RID: 74419
	public SDKInterface.PayResultCallback payResultCallbackGame;

	// Token: 0x040122B4 RID: 74420
	public SDKInterface.BindPhoneCallBack bindPhoneCallbackGame;

	// Token: 0x040122B5 RID: 74421
	public SDKInterface.KeyboardShowOut keyboardShowCallbackGame;

	// Token: 0x040122B6 RID: 74422
	public SDKInterface.SmallGameLoad smallGameLoadCallbackGame;

	// Token: 0x040122B7 RID: 74423
	public SDKInterface.AdultCheakcallback adultCheakcallback;

	// Token: 0x040122B8 RID: 74424
	private static SDKInterface _instance;

	// Token: 0x040122B9 RID: 74425
	private Coroutine imeiCoroutine;

	// Token: 0x0200464A RID: 17994
	public enum SDKLogoType
	{
		// Token: 0x040122BB RID: 74427
		VersionUpdate,
		// Token: 0x040122BC RID: 74428
		SelectRole,
		// Token: 0x040122BD RID: 74429
		LoginLogo,
		// Token: 0x040122BE RID: 74430
		LoadingLogo
	}

	// Token: 0x0200464B RID: 17995
	public enum FuncSDKType
	{
		// Token: 0x040122C0 RID: 74432
		FSDK_UniWebView
	}

	// Token: 0x0200464C RID: 17996
	// (Invoke) Token: 0x0601956A RID: 103786
	public delegate void LoginCallback(string token, string openuid, string ext);

	// Token: 0x0200464D RID: 17997
	// (Invoke) Token: 0x0601956E RID: 103790
	public delegate void LogoutCallback();

	// Token: 0x0200464E RID: 17998
	// (Invoke) Token: 0x06019572 RID: 103794
	public delegate void PayResultCallback(string result);

	// Token: 0x0200464F RID: 17999
	// (Invoke) Token: 0x06019576 RID: 103798
	public delegate void BindPhoneCallBack(string bindedPhoneNum);

	// Token: 0x02004650 RID: 18000
	// (Invoke) Token: 0x0601957A RID: 103802
	public delegate void KeyboardShowOut(string result);

	// Token: 0x02004651 RID: 18001
	// (Invoke) Token: 0x0601957E RID: 103806
	public delegate void SmallGameLoad(string startSceneName);

	// Token: 0x02004652 RID: 18002
	// (Invoke) Token: 0x06019582 RID: 103810
	public delegate void AdultCheakcallback(int flag, int realNameFlag, int age);
}
