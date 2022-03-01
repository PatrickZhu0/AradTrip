using System;
using System.Collections;
using System.Text;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020017F7 RID: 6135
public class OnlineServiceManager : DataManager<OnlineServiceManager>
{
	// Token: 0x17001CF7 RID: 7415
	// (get) Token: 0x0600F1D8 RID: 61912 RVA: 0x004136DB File Offset: 0x00411ADB
	// (set) Token: 0x0600F1D9 RID: 61913 RVA: 0x004136E3 File Offset: 0x00411AE3
	public bool IsOnlineServiceOpen { get; private set; }

	// Token: 0x0600F1DA RID: 61914 RVA: 0x004136EC File Offset: 0x00411AEC
	public void TryCloseOnlineServiceFrame()
	{
		if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OnlineServiceFrame>(null))
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<OnlineServiceFrame>(null, false);
		}
	}

	// Token: 0x0600F1DB RID: 61915 RVA: 0x0041370C File Offset: 0x00411B0C
	public void UpdateReqOfflineInfos(float timeElapsed)
	{
		if (this.isUpdateReqInfo)
		{
			this.elapsedTime += timeElapsed;
			if (this.elapsedTime > (float)this.reqOfflineInfoDuration)
			{
				this.elapsedTime = 0f;
				this.ReqOfflineInfoSign();
				this.isUpdateReqInfo = false;
			}
		}
	}

	// Token: 0x0600F1DC RID: 61916 RVA: 0x0041375C File Offset: 0x00411B5C
	public void StartReqOfflineInfos(bool beUpdate)
	{
		this.isUpdateReqInfo = beUpdate;
		this.elapsedTime = 0f;
		this.reqOfflineInfoDuration = 5;
		this.unReadMsgNum = 0;
		if (this.tempCoroutine != null)
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.tempCoroutine);
			this.tempCoroutine = null;
		}
	}

	// Token: 0x0600F1DD RID: 61917 RVA: 0x004137AB File Offset: 0x00411BAB
	public void RequireOfflineInfos()
	{
		if (this.tempCoroutine != null)
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.tempCoroutine);
			this.tempCoroutine = null;
		}
		this.tempCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.WaitForOfflineUrlRet(this.reqSignWithHttpTimeOut));
	}

	// Token: 0x0600F1DE RID: 61918 RVA: 0x004137EB File Offset: 0x00411BEB
	public bool HasUnReadMessage()
	{
		return this.unReadMsgNum > 0;
	}

	// Token: 0x0600F1DF RID: 61919 RVA: 0x004137FC File Offset: 0x00411BFC
	public bool IsSatisfiedVipLevel()
	{
		bool result = false;
		int num = 10;
		string s = TR.Value("vip_online_service_entrance_openlevel");
		if (int.TryParse(s, out num))
		{
			result = (DataManager<PlayerBaseData>.GetInstance().VipLevel >= num);
		}
		return result;
	}

	// Token: 0x0600F1E0 RID: 61920 RVA: 0x00413840 File Offset: 0x00411C40
	public void TryReqOnlineServiceSign()
	{
		bool flag = DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_VIP_AUTH);
		bool flag2 = this.IsSatisfiedVipLevel();
		bool flag3 = Singleton<PluginManager>.GetInstance().HasVIPAuth();
		if (flag2 && !flag && flag3)
		{
			this.ReqOnlineServiceUrlSign(true);
		}
		else
		{
			this.ReqOnlineServiceUrlSign(false);
		}
	}

	// Token: 0x0600F1E1 RID: 61921 RVA: 0x00413891 File Offset: 0x00411C91
	public bool TryReqOnlineServiceOpen()
	{
		this.IsOnlineServiceOpen = !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_ONLINE_SERVICE);
		return this.IsOnlineServiceOpen;
	}

	// Token: 0x0600F1E2 RID: 61922 RVA: 0x004138AE File Offset: 0x00411CAE
	public override void Initialize()
	{
		this.ResetUrlParams();
		NetProcess.AddMsgHandler(600817U, new Action<MsgDATA>(this.OnSyncOnlineServiceSign));
	}

	// Token: 0x0600F1E3 RID: 61923 RVA: 0x004138CC File Offset: 0x00411CCC
	public override void Clear()
	{
		this.IsOnlineServiceOpen = false;
		this.openServiceSignStr = string.Empty;
		this.offlineInfoSignStr = string.Empty;
		this.vipAuthSignStr = string.Empty;
		this.reqOfflineInfoDuration = 5;
		this.isUpdateReqInfo = false;
		this.unReadMsgNum = 0;
		if (this.tempCoroutine != null)
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.tempCoroutine);
		}
		this.tempCoroutine = null;
		this.elapsedTime = 0f;
		NetProcess.RemoveMsgHandler(600817U, new Action<MsgDATA>(this.OnSyncOnlineServiceSign));
		OnlineServiceManager.userId = string.Empty;
		this.isReqOpenServiceUrl = false;
		this.isReqVipAuthUrl = false;
	}

	// Token: 0x0600F1E4 RID: 61924 RVA: 0x00413974 File Offset: 0x00411D74
	public void ReqOnlineServiceUrlSign(bool bVipAuth = false)
	{
		this.isReqOpenServiceUrl = true;
		this.isReqVipAuthUrl = bVipAuth;
		this.TrySetUrlParams();
		string text = string.Empty;
		if (bVipAuth)
		{
			text = this.TryGetVipAuthReqInfo();
		}
		else
		{
			text = this.TryGetOnlineServiceReqInfo();
		}
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		WorldCustomServiceSignReq worldCustomServiceSignReq = new WorldCustomServiceSignReq();
		worldCustomServiceSignReq.info = text;
		NetManager.Instance().SendCommand<WorldCustomServiceSignReq>(ServerType.GATE_SERVER, worldCustomServiceSignReq);
	}

	// Token: 0x0600F1E5 RID: 61925 RVA: 0x004139DC File Offset: 0x00411DDC
	public void ReqOfflineInfoSign()
	{
		this.isReqOpenServiceUrl = false;
		this.TrySetUrlParams();
		string text = this.TryGetOfflineInfoReqInfo();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		WorldCustomServiceSignReq worldCustomServiceSignReq = new WorldCustomServiceSignReq();
		worldCustomServiceSignReq.info = text;
		NetManager.Instance().SendCommand<WorldCustomServiceSignReq>(ServerType.GATE_SERVER, worldCustomServiceSignReq);
	}

	// Token: 0x0600F1E6 RID: 61926 RVA: 0x00413A24 File Offset: 0x00411E24
	private void OnSyncOnlineServiceSign(MsgDATA msg)
	{
		WorldCustomServiceSignRes worldCustomServiceSignRes = new WorldCustomServiceSignRes();
		worldCustomServiceSignRes.decode(msg.bytes);
		if (worldCustomServiceSignRes.result == 0U)
		{
			this.IsOnlineServiceOpen = true;
			if (this.isReqOpenServiceUrl)
			{
				string text = string.Empty;
				if (this.isReqVipAuthUrl)
				{
					this.vipAuthSignStr = worldCustomServiceSignRes.sign;
					text = this.GetReqVipCheckUrl();
				}
				else
				{
					this.openServiceSignStr = worldCustomServiceSignRes.sign;
					text = this.GetReqOnlineServiceUrl();
				}
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OnlineServiceFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<OnlineServiceFrame>(FrameLayer.TopMoreMost, text, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRecVipOnlineService, text, this.isReqVipAuthUrl, null, null);
				}
			}
			else
			{
				this.offlineInfoSignStr = worldCustomServiceSignRes.sign;
				if (!SDKInterface.IsNewSDKChannelPay())
				{
					this.RequireOfflineInfos();
				}
			}
		}
		if (worldCustomServiceSignRes.result == 3100003U)
		{
			this.IsOnlineServiceOpen = false;
			if (this.isReqOpenServiceUrl)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("客服系统正在维护中...", null, string.Empty, false);
			}
		}
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MakeShowOnlineService, null, null, null, null);
	}

	// Token: 0x0600F1E7 RID: 61927 RVA: 0x00413B48 File Offset: 0x00411F48
	private IEnumerator WaitForCheckVipUrlRet(int timeout)
	{
		string url = this.GetReqVipCheckUrl();
		if (string.IsNullOrEmpty(url))
		{
			yield break;
		}
		BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
		wt.timeout = timeout;
		wt.gaptime = 0;
		wt.reconnectCnt = 0;
		wt.url = url;
		yield return wt;
		if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
		{
		}
		yield break;
	}

	// Token: 0x0600F1E8 RID: 61928 RVA: 0x00413B6C File Offset: 0x00411F6C
	private IEnumerator WaitForOfflineUrlRet(int timeout)
	{
		string url = this.GetReqOfflineServiceUrl();
		if (string.IsNullOrEmpty(url))
		{
			yield break;
		}
		BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
		wt.timeout = timeout;
		wt.gaptime = 0;
		wt.reconnectCnt = 0;
		wt.url = url;
		yield return wt;
		if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
		{
			string resultString = wt.GetResultString();
			if (!string.IsNullOrEmpty(resultString))
			{
				Hashtable hashtable = (Hashtable)MiniJSON.jsonDecode(resultString);
				string text = hashtable["code"] + string.Empty;
				if (text != null && text.Equals("0"))
				{
					object json = hashtable["data"];
					string json2 = MiniJSON.jsonEncode(json);
					Hashtable hashtable2 = (Hashtable)MiniJSON.jsonDecode(json2);
					object obj = hashtable2["interval"];
					if (obj != null)
					{
						string s = obj.ToString();
						if (int.TryParse(s, out this.reqOfflineInfoDuration))
						{
						}
					}
					string text2 = hashtable2["number"] + string.Empty;
					if (text2 != null && int.TryParse(text2, out this.unReadMsgNum))
					{
						bool flag = this.unReadMsgNum > 0;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRecOnlineServiceNewNote, flag, null, null, null);
					}
					string text3 = hashtable2["flag"] + string.Empty;
					if (text3 != null)
					{
						this.isUpdateReqInfo = text3.Equals("1");
					}
				}
				else
				{
					this.isUpdateReqInfo = false;
				}
			}
			else
			{
				this.isUpdateReqInfo = false;
			}
		}
		yield break;
	}

	// Token: 0x0600F1E9 RID: 61929 RVA: 0x00413B90 File Offset: 0x00411F90
	private IEnumerator WaitForOfflineUrlRet()
	{
		string url = this.GetReqOfflineServiceUrl();
		if (string.IsNullOrEmpty(url))
		{
			yield break;
		}
		WaitHttpRespensedService wh = new WaitHttpRespensedService(url);
		yield return wh;
		string resText = wh.GetResultString();
		if (!string.IsNullOrEmpty(resText))
		{
			Hashtable hashtable = (Hashtable)MiniJSON.jsonDecode(resText);
			string text = hashtable["code"] + string.Empty;
			if (text != null && text.Equals("0"))
			{
				object json = hashtable["data"];
				string json2 = MiniJSON.jsonEncode(json);
				Hashtable hashtable2 = (Hashtable)MiniJSON.jsonDecode(json2);
				object obj = hashtable2["interval"];
				if (obj != null)
				{
					string s = obj.ToString();
					if (int.TryParse(s, out this.reqOfflineInfoDuration))
					{
					}
				}
				string text2 = hashtable2["number"] + string.Empty;
				if (text2 != null && int.TryParse(text2, out this.unReadMsgNum))
				{
					bool flag = this.unReadMsgNum > 0;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRecOnlineServiceNewNote, flag, null, null, null);
				}
				string text3 = hashtable2["flag"] + string.Empty;
				if (text3 != null)
				{
					this.isUpdateReqInfo = text3.Equals("1");
				}
			}
			else
			{
				this.isUpdateReqInfo = false;
			}
		}
		else
		{
			this.isUpdateReqInfo = false;
		}
		yield break;
	}

	// Token: 0x0600F1EA RID: 61930 RVA: 0x00413BAB File Offset: 0x00411FAB
	private void ResetUrlParams()
	{
	}

	// Token: 0x0600F1EB RID: 61931 RVA: 0x00413BAD File Offset: 0x00411FAD
	private string TryGetOnlineServiceReqInfo()
	{
		return this.FormatReqSignUrl();
	}

	// Token: 0x0600F1EC RID: 61932 RVA: 0x00413BB5 File Offset: 0x00411FB5
	private string TryGetOfflineInfoReqInfo()
	{
		return this.FomatReqOfflineSignUrl();
	}

	// Token: 0x0600F1ED RID: 61933 RVA: 0x00413BBD File Offset: 0x00411FBD
	private string TryGetVipAuthReqInfo()
	{
		return this.FormatReqVipCheckSignUrl();
	}

	// Token: 0x0600F1EE RID: 61934 RVA: 0x00413BC8 File Offset: 0x00411FC8
	private string FormatReqSignUrl()
	{
		return string.Format("user_id={0}&user_name={1}&server_id={2}&server_name={3}&plat_id={4}&plat_name={5}&level={6}&timestamp={7}&jobs_id={8}&is_special={9}&ouid={10}&app_id={11}&channel_name={12}", new object[]
		{
			OnlineServiceManager.userId,
			this.userName,
			this.serverId,
			this.serverName,
			this.platId,
			this.platName,
			this.level,
			this.timeStap,
			this.jobId,
			this.vipFlag,
			this.accId,
			OnlineServiceManager.appid,
			this.channelName
		});
	}

	// Token: 0x0600F1EF RID: 61935 RVA: 0x00413C60 File Offset: 0x00412060
	private string FomatReqOfflineSignUrl()
	{
		return string.Format("user_id={0}&timestamp={1}&app_id={2}&is_special={3}", new object[]
		{
			OnlineServiceManager.userId,
			this.timeStap,
			OnlineServiceManager.appid,
			this.vipFlag
		});
	}

	// Token: 0x0600F1F0 RID: 61936 RVA: 0x00413CA4 File Offset: 0x004120A4
	private string FormatReqVipCheckSignUrl()
	{
		return string.Format("uid={0}&server={1}&server_id={2}&role={3}&role_id={4}&plat_id={5}&job={6}&job_id={7}&vip={8}&vip_sign={9}&channel_name={10}", new object[]
		{
			this.accId,
			this.serverName,
			this.serverId,
			this.userName,
			this.roleId,
			this.vipPlatId,
			this.jobName,
			this.jobId,
			this.vipLevel,
			this.vipLevel,
			this.channelName
		});
	}

	// Token: 0x0600F1F1 RID: 61937 RVA: 0x00413D2C File Offset: 0x0041212C
	private string GetReqOnlineServiceUrl()
	{
		if (string.IsNullOrEmpty(this.openServiceSignStr))
		{
			return string.Empty;
		}
		return string.Format("https://{0}/?{1}", Global.ONLINE_SERVICE_ADDRESS, this.openServiceSignStr);
	}

	// Token: 0x0600F1F2 RID: 61938 RVA: 0x00413D68 File Offset: 0x00412168
	private string GetReqOfflineServiceUrl()
	{
		if (string.IsNullOrEmpty(this.offlineInfoSignStr))
		{
			return string.Empty;
		}
		return string.Format("https://{0}/user/unread?{1}", Global.ONLINE_SERVICE_REQ_ADDRESS, this.offlineInfoSignStr);
	}

	// Token: 0x0600F1F3 RID: 61939 RVA: 0x00413DA4 File Offset: 0x004121A4
	private string GetReqVipCheckUrl()
	{
		if (string.IsNullOrEmpty(this.vipAuthSignStr))
		{
			return string.Empty;
		}
		return string.Format("http://{0}?{1}", Global.ONLINE_SERVICE_VIP_CHECK_ADDRESS, this.vipAuthSignStr);
	}

	// Token: 0x0600F1F4 RID: 61940 RVA: 0x00413DE0 File Offset: 0x004121E0
	private void SetCurrBaseJobId()
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			if (tableItem.JobType == 0)
			{
				this.jobId = tableItem.ID.ToString();
			}
			else
			{
				this.jobId = tableItem.prejob.ToString();
			}
			this.jobName = tableItem.Name;
		}
	}

	// Token: 0x0600F1F5 RID: 61941 RVA: 0x00413E64 File Offset: 0x00412264
	private void TrySetUrlParams()
	{
		this.SetCurrBaseJobId();
		this.userName = DataManager<PlayerBaseData>.GetInstance().Name;
		this.serverId = ClientApplication.adminServer.id.ToString();
		this.serverName = ClientApplication.adminServer.name;
		this.platId = Singleton<PluginManager>.GetInstance().GetOnlineServiceBuildPlatformId();
		this.platName = Singleton<PluginManager>.GetInstance().GetOnlineServicePlatformName();
		this.level = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
		this.timeStap = DataManager<TimeManager>.GetInstance().GetServerTime().ToString();
		this.channelName = Singleton<PluginManager>.GetInstance().GetChannelName();
		this.accId = ClientApplication.playerinfo.openuid;
		this.roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		this.vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
		this.vipPlatId = Singleton<PluginManager>.GetInstance().GetBuildPlatformId();
		this.vipFlag = "0";
		OnlineServiceManager.appid = TR.Value("zymg_onlineservice_app_id");
		OnlineServiceManager.userId = string.Format("{0}_{1}_{2}", this.serverId, this.vipFlag, this.roleId);
	}

	// Token: 0x0600F1F6 RID: 61942 RVA: 0x00413FB0 File Offset: 0x004123B0
	private void UrlEncodeOnRecSign(params string[] urlParams)
	{
		if (urlParams != null)
		{
			if (urlParams.Length != 10)
			{
				return;
			}
			for (int i = 0; i < 10; i++)
			{
				string input = urlParams[i];
				urlParams[i] = this.UrlEncode(input);
			}
		}
	}

	// Token: 0x0600F1F7 RID: 61943 RVA: 0x00413FF0 File Offset: 0x004123F0
	public string UrlEncode(string input)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (byte b in Encoding.UTF8.GetBytes(input))
		{
			if (this.IsReverseChar((char)b))
			{
				stringBuilder.Append('%');
				stringBuilder.Append(this.ByteToHex(b));
			}
			else
			{
				stringBuilder.Append((char)b);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600F1F8 RID: 61944 RVA: 0x00414060 File Offset: 0x00412460
	private bool IsReverseChar(char c)
	{
		return (c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && (c < '0' || c > '9') && c != '-' && c != '_' && c != '.' && c != '~';
	}

	// Token: 0x0600F1F9 RID: 61945 RVA: 0x004140C0 File Offset: 0x004124C0
	private string ByteToHex(byte b)
	{
		return b.ToString("x2");
	}

	// Token: 0x04009499 RID: 38041
	private const string RequestSignNotify = "客服系统正在维护中...";

	// Token: 0x0400949A RID: 38042
	private static string appid = "138";

	// Token: 0x0400949B RID: 38043
	private static string userId = string.Empty;

	// Token: 0x0400949C RID: 38044
	private string userName = string.Empty;

	// Token: 0x0400949D RID: 38045
	private string serverId = string.Empty;

	// Token: 0x0400949E RID: 38046
	private string serverName = string.Empty;

	// Token: 0x0400949F RID: 38047
	private string platId = string.Empty;

	// Token: 0x040094A0 RID: 38048
	private string platName = string.Empty;

	// Token: 0x040094A1 RID: 38049
	private string level = string.Empty;

	// Token: 0x040094A2 RID: 38050
	private string jobId = string.Empty;

	// Token: 0x040094A3 RID: 38051
	private string timeStap = string.Empty;

	// Token: 0x040094A4 RID: 38052
	private string vipFlag = string.Empty;

	// Token: 0x040094A5 RID: 38053
	private string channelName = string.Empty;

	// Token: 0x040094A6 RID: 38054
	private string accId = string.Empty;

	// Token: 0x040094A7 RID: 38055
	private string roleId = string.Empty;

	// Token: 0x040094A8 RID: 38056
	private string vipPlatId = string.Empty;

	// Token: 0x040094A9 RID: 38057
	private string jobName = string.Empty;

	// Token: 0x040094AA RID: 38058
	private string vipLevel = string.Empty;

	// Token: 0x040094AB RID: 38059
	private const int urlParamCount = 10;

	// Token: 0x040094AD RID: 38061
	private string openServiceSignStr = string.Empty;

	// Token: 0x040094AE RID: 38062
	private string offlineInfoSignStr = string.Empty;

	// Token: 0x040094AF RID: 38063
	private string vipAuthSignStr = string.Empty;

	// Token: 0x040094B0 RID: 38064
	private int reqOfflineInfoDuration = 5;

	// Token: 0x040094B1 RID: 38065
	private bool isUpdateReqInfo;

	// Token: 0x040094B2 RID: 38066
	private int unReadMsgNum;

	// Token: 0x040094B3 RID: 38067
	private Coroutine tempCoroutine;

	// Token: 0x040094B4 RID: 38068
	private float elapsedTime;

	// Token: 0x040094B5 RID: 38069
	private bool isReqOpenServiceUrl;

	// Token: 0x040094B6 RID: 38070
	private bool isReqVipAuthUrl;

	// Token: 0x040094B7 RID: 38071
	private int reqSignWithHttpTimeOut = 3000;
}
