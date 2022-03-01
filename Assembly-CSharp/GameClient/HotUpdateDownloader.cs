using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LibZip;
using UnityEngine;
using UnityEngine.Events;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02000215 RID: 533
	public class HotUpdateDownloader : MonoSingleton<HotUpdateDownloader>
	{
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x0005E98D File Offset: 0x0005CD8D
		public VersionUpdateState updateState
		{
			get
			{
				return this.m_UpdateState;
			}
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0005E995 File Offset: 0x0005CD95
		private void Start()
		{
			this.m_Platform = HotUpdateDownloader.CustomPlatform.Android;
			this.PLATFORM_STRING = this.PLATFORM_STRING_TABLE[(int)this.m_Platform];
			if (!this._LoadHackServerList())
			{
				this._LoadServerList();
			}
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0005E9C2 File Offset: 0x0005CDC2
		public void DoHotUpdate(VersionUpdateFrame frame)
		{
			this.m_UI = frame;
			base.StartCoroutine(this._ProcessHotUpdate());
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0005E9D8 File Offset: 0x0005CDD8
		public void CheckHotUpdateVersion()
		{
			base.StartCoroutine(this._CheckHotUpdateVersion());
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0005E9E8 File Offset: 0x0005CDE8
		protected IEnumerator _CheckHotUpdateVersion()
		{
			Singleton<VersionManager>.instance.m_IsLastest = false;
			this.m_CheckRes = VersionCheckResult.None;
			yield return Yielders.EndOfFrame;
			yield return this._FetchVersion();
			Debug.Log("_CheckHotUpdateVersion CustomMajor");
			int majorIdx = 2;
			if (this.m_CurNativeVerDesc.m_VersionNumber[majorIdx] == this.m_CurRemoteVerDesc.m_VersionNumber[majorIdx])
			{
				int num = 3;
				if (this.m_CurNativeVerDesc.m_VersionNumber[num] < this.m_CurRemoteVerDesc.m_VersionNumber[num])
				{
					this.m_CheckRes = VersionCheckResult.NeedHotUpdate;
					yield break;
				}
			}
			else if (this.m_CurNativeVerDesc.m_VersionNumber[majorIdx] < this.m_CurRemoteVerDesc.m_VersionNumber[majorIdx])
			{
				this.m_CheckRes = VersionCheckResult.NeedHotUpdate;
				yield break;
			}
			this.m_CheckRes = VersionCheckResult.Lastest;
			Singleton<VersionManager>.instance.m_IsLastest = true;
			Debug.Log("_CheckHotUpdateVersion End");
			yield break;
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0005EA03 File Offset: 0x0005CE03
		public VersionCheckResult GetVersionCheckRes()
		{
			return this.m_CheckRes;
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0005EA0C File Offset: 0x0005CE0C
		public static void RestartApp()
		{
			Debug.Log("Restart application has been called!");
			Debug.Log("Restart application step 0");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			Debug.Log("Restart application step 1");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			Debug.Log("Restart application step 2");
			@static.Call("restartApplication", new object[0]);
			Debug.Log("Restart application step 3");
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0005EA74 File Offset: 0x0005CE74
		private IEnumerator _FetchVersion()
		{
			yield return this._GetNativeVersion();
			if (!this.m_CurNativeVerDesc.m_IsVersionOK)
			{
				string msgContent = "读取本地版本信息失败，安装包被破坏，请重新下载安装包！";
				SystemNotifyManager.BaseMsgBoxOK(msgContent, new UnityAction(this._OnConfirmQuit_OK), string.Empty);
				yield break;
			}
			yield return this._GetRemoteVersion();
			if (!this.m_CurRemoteVerDesc.m_IsVersionOK)
			{
				string msgContent2 = "获取服务器配置文件失败，是否重试？";
				SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent2, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
				yield break;
			}
			Debug.Log("_FetchVersion Version End");
			yield break;
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0005EA90 File Offset: 0x0005CE90
		public IEnumerator ForceFullUpdate()
		{
			yield return this._ForceFullUpdate();
			yield break;
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0005EAAC File Offset: 0x0005CEAC
		private IEnumerator _ForceFullUpdate()
		{
			this.m_UpdateState = VersionUpdateState.WaitFullUpdate;
			yield return this._GetForceUpdateUrl();
			string msgInfo = "亲爱的玩家，莉娅发布了最新的游戏版本，点击[下载]获取游戏的最新版本！";
			SystemNotifyManager.BaseMsgBoxOK(msgInfo, new UnityAction(this._ReopenUrl), "下载");
			yield break;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0005EAC7 File Offset: 0x0005CEC7
		private void _openAppStoreForceUpdateFrame()
		{
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0005EAC9 File Offset: 0x0005CEC9
		private void _ReopenUrl()
		{
			if (!string.IsNullOrEmpty(this.m_ForceUpdateUrl))
			{
				Application.OpenURL(this.m_ForceUpdateUrl);
			}
			else
			{
				Application.OpenURL("http://ald.xy.com");
			}
			base.StartCoroutine(this._ForceFullUpdate());
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0005EB04 File Offset: 0x0005CF04
		private IEnumerator _GetForceUpdateUrl()
		{
			string forceUpdateUrlFile = Path.Combine(this._GetHotfixAccessUrlProtocol(), this.FORCE_UPDATE_PACKAGE_NAME);
			WWW forceUpdateUrlFileWWW = new WWW(forceUpdateUrlFile);
			yield return forceUpdateUrlFileWWW;
			this.m_ForceUpdateUrl = string.Empty;
			if (forceUpdateUrlFileWWW.error == null)
			{
				try
				{
					ArrayList arrayList = MiniJSON.jsonDecode(forceUpdateUrlFileWWW.text) as ArrayList;
					if (arrayList != null && arrayList.Count > 0)
					{
						this.m_ForceUpdateUrl = (arrayList[0] as string);
					}
				}
				catch (Exception ex)
				{
				}
			}
			yield break;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0005EB20 File Offset: 0x0005CF20
		private IEnumerator _ProcessHotUpdate()
		{
			yield return Yielders.EndOfFrame;
			yield return this._FetchVersion();
			this.m_NativeVersion = this.m_CurNativeVerDesc.m_VersionString;
			this.m_VersionTbl = this.m_CurNativeVerDesc.m_VersionTbl;
			this.m_LocalNewer = this.m_CurNativeVerDesc.m_LocalNewer;
			this.m_RemoteVersion = this.m_CurRemoteVerDesc.m_VersionString;
			int majorIdx = 2;
			if (this.m_CurNativeVerDesc.m_VersionNumber[majorIdx] < this.m_CurRemoteVerDesc.m_VersionNumber[majorIdx])
			{
				string msgContent = "亲爱的玩家，莉娅发布了最新的游戏版本，请获取最新版本的游戏！";
				SystemNotifyManager.BaseMsgBoxOK(msgContent, new UnityAction(this._OnNeedDownloadFullVersion_OK), string.Empty);
				this._DisplayUpdateState("最新的游戏版本已经发布，请获取最新的游戏版本");
				this._DisplayUpdateInfo(100, "祝您生活愉快！");
				Singleton<VersionManager>.instance.m_IsLastest = true;
				this.m_UpdateState = VersionUpdateState.FinishUpdate;
				this.m_CheckRes = VersionCheckResult.NeedUpGrade;
				yield break;
			}
			if (this.m_CurNativeVerDesc.m_VersionNumber[majorIdx] > this.m_CurRemoteVerDesc.m_VersionNumber[majorIdx])
			{
				string msgContent2 = "本地版本高于服务器版本，请等待服务器维护完成！";
				SystemNotifyManager.BaseMsgBoxOK(msgContent2, new UnityAction(this._OnWaitServerUpdate_OK), string.Empty);
				this.m_CheckRes = VersionCheckResult.Lastest;
				yield break;
			}
			int patchIdx = 3;
			if (this.m_CurNativeVerDesc.m_VersionNumber[patchIdx] >= this.m_CurRemoteVerDesc.m_VersionNumber[patchIdx])
			{
				if (this.m_CurNativeVerDesc.m_VersionNumber[patchIdx] > this.m_CurRemoteVerDesc.m_VersionNumber[patchIdx])
				{
					if (!this.m_LocalNewer)
					{
						this._ClearHotUpdateCaches();
						base.StartCoroutine(this._ProcessHotUpdate());
						yield break;
					}
					string content = string.Format("当前远端版本号：{0}，玩家本地版本号：{1}", this.m_CurRemoteVerDesc.m_VersionNumber[patchIdx], this.m_CurNativeVerDesc.m_VersionNumber[patchIdx]);
					this._SendErrorEmail("检测到玩家版本高于热更版本", content);
					this.m_CheckRes = VersionCheckResult.Lastest;
				}
				Debug.LogWarning("##################################### 不对");
				this._DisplayUpdateState("当前版本为最新");
				this._DisplayUpdateInfo(100, "祝您游戏愉快！");
				Singleton<VersionManager>.instance.m_IsLastest = true;
				this.m_UpdateState = VersionUpdateState.FinishUpdate;
				yield break;
			}
			yield return base.StartCoroutine(this._GetExpireVersion());
			bool bIsExpireOK = false;
			string[] expireVerList = null;
			if (!string.IsNullOrEmpty(this.m_ExpireVersion))
			{
				expireVerList = this.m_ExpireVersion.Split(new char[]
				{
					'.'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (expireVerList.Length == 4)
				{
					bIsExpireOK = true;
				}
			}
			if (!bIsExpireOK)
			{
				string msgContent3 = "获取服务器配置文件失败，是否重试？";
				SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent3, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
				yield break;
			}
			int[] expireVers = new int[expireVerList.Length];
			for (int i = 0; i < expireVerList.Length; i++)
			{
				expireVers[i] = int.Parse(expireVerList[i]);
			}
			if (this.m_CurNativeVerDesc.m_VersionNumber[patchIdx] < expireVers[patchIdx])
			{
				string msgContent4 = "亲爱的玩家，莉娅发布了最新的游戏版本，请获取最新版本的游戏！";
				SystemNotifyManager.BaseMsgBoxOK(msgContent4, new UnityAction(this._OnNeedDownloadFullVersion_OK), string.Empty);
				this._DisplayUpdateState("最新的游戏版本已经发布，请获取最新的游戏版本");
				this._DisplayUpdateInfo(100, "祝您生活愉快！");
				Singleton<VersionManager>.instance.m_IsLastest = true;
				this.m_UpdateState = VersionUpdateState.FinishUpdate;
				this.m_CheckRes = VersionCheckResult.NeedUpGrade;
				yield break;
			}
			base.StartCoroutine(this._ProcessUpdatePatches());
			yield break;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0005EB3C File Offset: 0x0005CF3C
		private IEnumerator _ProcessUpdatePatches()
		{
			string msg = "正在获取更新文件列表...";
			this._DisplayUpdateState(msg);
			this._DisplayUpdateInfo(7, string.Empty);
			string packageFile = string.Concat(new string[]
			{
				"package-",
				this.m_NativeVersion,
				"-",
				this.m_RemoteVersion,
				".txt"
			});
			Debug.Log("Target patch:" + packageFile);
			this.m_UpdateState = VersionUpdateState.GetPatchDiffList;
			string diffListData = null;
			string diffFileUrl = null;
			string lastError = string.Empty;
			WWW diffListWWW = null;
			int retryCnt = 0;
			bool isConnectOK = false;
			do
			{
				diffFileUrl = this._GetDiffListFileUrl(packageFile).Replace('\\', '/');
				diffListWWW = new WWW(diffFileUrl);
				yield return diffListWWW;
				if (diffListWWW.error == null && !string.IsNullOrEmpty(diffListWWW.text))
				{
					diffListData = diffListWWW.text;
					isConnectOK = true;
				}
				else
				{
					lastError = diffListWWW.error;
				}
				diffListWWW.Dispose();
				if (isConnectOK)
				{
					break;
				}
				retryCnt++;
			}
			while (retryCnt < 3);
			if (isConnectOK && !string.IsNullOrEmpty(diffListData))
			{
				if (this._ParseDiffList(diffListData, ref this.m_TotalSize, ref this.m_DownloadedSize))
				{
					if (!this._IsWifiUsed())
					{
						float num = (float)this.m_TotalSize / 1048576f;
						float num2 = (float)this.m_DownloadedSize / 1048576f;
						string msgContent = string.Format("检测到当前设备未连接到无线局域网（WiFi），本次更新共{0}MB，已下载{1}MB，是否确认更新？", num.ToString("G3"), num2.ToString("G3"));
						SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent, new UnityAction(this._OnConfirmHotUpdate_OK), new UnityAction(this._OnConfirmHotUpdate_Cancel));
					}
					else
					{
						this._OnConfirmHotUpdate_OK();
					}
				}
			}
			else
			{
				string content = string.Format("问题流程：{0}，问题地址（URL）：{1}，请求列表{2}，错误详情：{3}", new object[]
				{
					this.m_UpdateState.ToString(),
					diffFileUrl,
					packageFile,
					lastError
				});
				this._SendErrorEmail("热更新获取差异列表失败", content);
				if (this._IsFileNotFound(lastError))
				{
					this._DisplayUpdateState("热更新检查完毕");
					this._DisplayUpdateInfo(100, "未发现需要更新的文件列表！");
					this.m_UpdateState = VersionUpdateState.FinishUpdate;
					this.m_CheckRes = VersionCheckResult.Lastest;
					yield break;
				}
				string msgContent2 = "获取服务器配置文件失败，是否重试？";
				SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent2, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
			}
			yield break;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0005EB58 File Offset: 0x0005CF58
		private IEnumerator _GetRemoteVersion()
		{
			this.m_CurRemoteVerDesc.Reset();
			if (!Global.Settings.loadFromPackage)
			{
				this.m_CurRemoteVerDesc.m_VersionString = this.m_CurNativeVerDesc.m_VersionString;
				yield break;
			}
			float startTime = Time.realtimeSinceStartup;
			string msg = "正在获取服务器配置文件...";
			this._DisplayUpdateState(msg);
			this._DisplayUpdateInfo(5, string.Empty);
			string configPath = null;
			int retryCnt = 0;
			string lastError = string.Empty;
			bool isRemoteOK = false;
			string usrAgreementString = string.Empty;
			Hashtable verTbl = null;
			do
			{
				configPath = Path.Combine(this._GetResourceServerRoot(), this.VERSION_INFO_FILE_NAME);
				configPath = configPath.Replace("\\", "/");
				BaseWaitHttpRequest configReq = new BaseWaitHttpRequest();
				if (configPath.Contains("?"))
				{
					configReq.url = configPath + string.Format("&tsp={0}", Utility.GetCurrentTimeUnix() / 300U);
				}
				else
				{
					configReq.url = configPath + string.Format("?tsp={0}", Utility.GetCurrentTimeUnix() / 300U);
				}
				configReq.reconnectCnt = 0;
				Debug.Log("URL:[" + configReq.url + "]!");
				this.m_UpdateState = VersionUpdateState.CheckNetwork;
				yield return configReq;
				if (configReq.GetResult() == BaseWaitHttpRequest.eState.Success)
				{
					verTbl = null;
					usrAgreementString = configReq.GetResultString();
					this.m_CurRemoteVerDesc.m_VersionString = this._GetVersionFromJson(usrAgreementString, ref verTbl);
					this.m_UpdateState = VersionUpdateState.CheckRemoteVersion;
					isRemoteOK = true;
				}
				if (isRemoteOK)
				{
					break;
				}
				retryCnt++;
			}
			while (retryCnt < 3);
			float fetchTime = (Time.realtimeSinceStartup - startTime) * 1000f;
			if (fetchTime >= 5000f)
			{
				Logger.LogErrorFormat("version fetchTime:{0}", new object[]
				{
					fetchTime
				});
			}
			if (!isRemoteOK)
			{
				this.m_CurRemoteVerDesc.m_VersionString = this.m_CurNativeVerDesc.m_VersionString;
				string content = string.Format("问题流程：{0}，问题地址（URL）：{1}，错误详情：{2}", this.m_UpdateState.ToString(), configPath, lastError);
				this._SendErrorEmail("热更新连接版本服务器失败", content);
			}
			Debug.Log("Remote Version:[" + this.m_CurRemoteVerDesc.m_VersionString + "]!");
			this.m_CurRemoteVerDesc.m_IsVersionOK = false;
			string[] remoteVerList = null;
			if (!string.IsNullOrEmpty(this.m_CurRemoteVerDesc.m_VersionString))
			{
				remoteVerList = this.m_CurRemoteVerDesc.m_VersionString.Split(new char[]
				{
					'.'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (remoteVerList.Length == 4)
				{
					this.m_CurRemoteVerDesc.m_IsVersionOK = true;
				}
			}
			if (this.m_CurRemoteVerDesc.m_IsVersionOK)
			{
				for (int i = 0; i < this.m_CurRemoteVerDesc.m_VersionNumber.Length; i++)
				{
					this.m_CurRemoteVerDesc.m_VersionNumber[i] = int.Parse(remoteVerList[i]);
				}
			}
			Debug.Log("_GetUserAgreementFromJson");
			bool needAgreement = this._GetCommonSwitchFromJson(verTbl, "agreement");
			ClientSystemLogin.mOpenUserAgreement = needAgreement;
			SDKChannel[] plt = this._GetCommonSDKChannelSwitch(verTbl, "vipauth");
			Global.VipAuthSDKChannel = plt;
			SDKChannel[] cls = this._GetCommonSDKChannelSwitch(verTbl, "realnameauth");
			Global.RealNamePopWindowsChannel = cls;
			SDKChannel[] cls2 = this._GetCommonSDKChannelSwitch(verTbl, "sdkpush");
			Global.SDKPushChannel = cls2;
			Global.BuglyEnable = this._GetCommonSwitchFromJson(verTbl, "bugly");
			yield break;
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0005EB74 File Offset: 0x0005CF74
		private IEnumerator _GetExpireVersion()
		{
			if (!Global.Settings.loadFromPackage)
			{
				this.m_ExpireVersion = this.DEFAULT_VERSION;
				yield break;
			}
			string msg = "正在获取服务器配置文件...";
			this._DisplayUpdateState(msg);
			string configPath = null;
			int retryCnt = 0;
			string lastError = string.Empty;
			bool isExpireOK = false;
			WWWForm form = new WWWForm();
			form.AddField("Cache-Control", "max-age=0");
			WWW serverWWW = null;
			do
			{
				configPath = Path.Combine(this._GetResourceServerRoot(), this.VERSION_EXPIRE_FILE_NAME);
				configPath = configPath.Replace("\\", "/");
				Debug.Log("URL:[" + configPath + "]!");
				serverWWW = new WWW(configPath);
				yield return serverWWW;
				if (serverWWW.error == null && !string.IsNullOrEmpty(serverWWW.text))
				{
					Hashtable hashtable = null;
					this.m_ExpireVersion = this._GetVersionFromJson(serverWWW.text, ref hashtable);
					this.m_UpdateState = VersionUpdateState.CheckExpireVersion;
					isExpireOK = true;
				}
				else
				{
					lastError = serverWWW.error;
				}
				serverWWW.Dispose();
				if (isExpireOK)
				{
					break;
				}
				retryCnt++;
			}
			while (retryCnt < 3);
			if (!isExpireOK)
			{
				this.m_ExpireVersion = this.DEFAULT_VERSION;
				string content = string.Format("问题流程：{0}，问题地址（URL）：{1}，错误详情：{2}", this.m_UpdateState.ToString(), configPath, lastError);
				this._SendErrorEmail("热更新连接版本服务器失败", content);
			}
			Debug.Log("Expire Version:[" + this.m_ExpireVersion + "]!");
			yield break;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0005EB90 File Offset: 0x0005CF90
		private IEnumerator _GetNativeVersion()
		{
			this.m_CurNativeVerDesc.Reset();
			this._DisplayUpdateState("读取本地版本信息... ");
			this.m_UpdateState = VersionUpdateState.CheckPathPermission;
			string localPersistentVerFile = Path.Combine(this._GetHotfixAccessUrlProtocol(), this.VERSION_INFO_FILE_NAME);
			WWW localPersistentVerFileWWW = new WWW(localPersistentVerFile);
			yield return localPersistentVerFileWWW;
			string verHotfixJson = null;
			Hashtable verTblHotfix = null;
			if (localPersistentVerFileWWW.error == null)
			{
				verHotfixJson = this._GetVersionFromJson(localPersistentVerFileWWW.text, ref verTblHotfix);
				Debug.LogWarning("### Native hot-fix version:" + verHotfixJson);
			}
			else
			{
				verHotfixJson = this.DEFAULT_VERSION;
			}
			localPersistentVerFileWWW.Dispose();
			string localStreamVerFile = Path.Combine(this._GetLocalAccessUrlProtocol(), this.VERSION_INFO_FILE_NAME);
			WWW localStreamVerFileWWW = new WWW(localStreamVerFile);
			yield return localStreamVerFileWWW;
			string verLocalJson = null;
			Hashtable verTblLocal = null;
			if (localStreamVerFileWWW.error == null)
			{
				verLocalJson = this._GetVersionFromJson(localStreamVerFileWWW.text, ref verTblLocal);
				Debug.LogWarning("### Native local version:" + verLocalJson);
			}
			else
			{
				verLocalJson = this.DEFAULT_VERSION;
				this._SendErrorEmail("热更新检查包内版本文件错误", localStreamVerFileWWW.error + "版本号文件路径：" + localStreamVerFile);
			}
			localStreamVerFileWWW.Dispose();
			string[] hotfixVerList = verHotfixJson.Split(new char[]
			{
				'.'
			});
			string[] localVerList = verLocalJson.Split(new char[]
			{
				'.'
			});
			int hotfixPatchVersion = 0;
			int localPatchVersion = 0;
			int hotfixClientVersion = 0;
			int localClientVersion = 0;
			if (hotfixVerList.Length == 4)
			{
				hotfixClientVersion = int.Parse(hotfixVerList[2]);
				hotfixPatchVersion = int.Parse(hotfixVerList[3]);
			}
			else
			{
				Debug.LogWarning("Hot-fix version string is invalid(while split version string to sub versions)!");
			}
			if (localVerList.Length == 4)
			{
				localClientVersion = int.Parse(localVerList[2]);
				localPatchVersion = int.Parse(localVerList[3]);
			}
			else
			{
				Debug.LogWarning("Local version string is invalid(while split version string to sub versions)!");
			}
			if (hotfixPatchVersion > localPatchVersion && hotfixClientVersion >= localClientVersion)
			{
				this.m_CurNativeVerDesc.m_VersionString = verHotfixJson;
				this.m_CurNativeVerDesc.m_VersionTbl = verTblHotfix;
				this.m_CurNativeVerDesc.m_LocalNewer = false;
			}
			else
			{
				this.m_CurNativeVerDesc.m_VersionString = verLocalJson;
				this.m_CurNativeVerDesc.m_VersionTbl = verTblLocal;
				this.m_CurNativeVerDesc.m_LocalNewer = true;
				this._ClearHotUpdateCaches();
			}
			this.m_UpdateState = VersionUpdateState.CheckNativeVerion;
			this.m_CurNativeVerDesc.m_IsVersionOK = false;
			string[] nativeVerList = null;
			if (!string.IsNullOrEmpty(this.m_CurNativeVerDesc.m_VersionString))
			{
				nativeVerList = this.m_CurNativeVerDesc.m_VersionString.Split(new char[]
				{
					'.'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (nativeVerList.Length == 4)
				{
					this.m_CurNativeVerDesc.m_IsVersionOK = true;
				}
			}
			if (this.m_CurNativeVerDesc.m_IsVersionOK)
			{
				for (int i = 0; i < this.m_CurNativeVerDesc.m_VersionNumber.Length; i++)
				{
					this.m_CurNativeVerDesc.m_VersionNumber[i] = int.Parse(nativeVerList[i]);
				}
			}
			yield break;
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0005EBAB File Offset: 0x0005CFAB
		protected void _OnConfirmHotUpdate_OK()
		{
			base.StartCoroutine(this._UpdatePatches());
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0005EBBA File Offset: 0x0005CFBA
		protected void _OnConfirmHotUpdate_Cancel()
		{
			Application.Quit();
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x0005EBC1 File Offset: 0x0005CFC1
		protected void _OnRetryHotUpdate_OK()
		{
			this._ClearHotUpdateCaches();
			base.StartCoroutine(this._ProcessHotUpdate());
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0005EBD6 File Offset: 0x0005CFD6
		protected void _OnRetryHotUpdate_Cancel()
		{
			Singleton<VersionManager>.instance.m_IsLastest = false;
			this.m_UpdateState = VersionUpdateState.FinishUpdate;
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x0005EBEB File Offset: 0x0005CFEB
		protected void _OnWaitServerUpdate_OK()
		{
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x0005EBED File Offset: 0x0005CFED
		protected void _OnNeedDownloadFullVersion_OK()
		{
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0005EBEF File Offset: 0x0005CFEF
		protected void _OnConfirmQuit_OK()
		{
			Application.Quit();
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0005EBF6 File Offset: 0x0005CFF6
		public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0005EBFC File Offset: 0x0005CFFC
		private IEnumerator _UpdatePatches()
		{
			string msg = "开始下载更新文件...";
			this._DisplayUpdateState(msg);
			this._DisplayUpdateInfo(9, string.Empty);
			ServicePointManager.DefaultConnectionLimit = 30;
			byte[] downloadCache = new byte[this.DOWNLOAD_CHUNK_SIZE];
			string assetFullUrl = string.Empty;
			string patchAssetName = string.Empty;
			this.m_UpdateState = VersionUpdateState.DownloadPatch;
			int nReadSize = 0;
			for (int i = 0; i < this.m_DiffAssetDescArray.Length; i++)
			{
				HotUpdateDownloader.DiffAssetDesc assetDesc = this.m_DiffAssetDescArray[i];
				assetFullUrl = this._GetDiffListFileUrl(assetDesc.assetUrl);
				patchAssetName = Path.GetFileName(assetFullUrl);
				GC.Collect();
				long responseCountLength = 0L;
				HttpWebRequest requestHttp = null;
				WebResponse webResponse = null;
				try
				{
					requestHttp = (WebRequest.Create(assetFullUrl) as HttpWebRequest);
					webResponse = requestHttp.GetResponse();
					responseCountLength = webResponse.ContentLength;
					requestHttp.KeepAlive = false;
					webResponse.Close();
					webResponse = null;
					requestHttp.Abort();
					requestHttp = null;
				}
				catch (Exception ex)
				{
					string msgContent = "网络连接遇到问题，是否重试？";
					SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
					Logger.LogError("### Get http download request count length has failed! Exception:" + ex.ToString());
					yield break;
				}
				string assetDownloadPath = Path.Combine(Application.persistentDataPath, patchAssetName);
				long fileOffset = FileUtil.GetFileBytes(assetDownloadPath);
				if (fileOffset < responseCountLength)
				{
					FileStream fs;
					if (fileOffset != -1L)
					{
						fs = File.OpenWrite(assetDownloadPath);
						fs.Seek(fileOffset, SeekOrigin.Current);
					}
					else
					{
						fs = new FileStream(assetDownloadPath, FileMode.Create);
					}
					requestHttp = null;
					try
					{
						requestHttp = (WebRequest.Create(assetFullUrl) as HttpWebRequest);
					}
					catch (Exception ex2)
					{
						string msgContent2 = "网络连接遇到问题，是否重试？";
						SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent2, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
						Logger.LogError("### [Download] Create http request for download offset has failed! Exception: " + ex2.ToString());
						yield break;
					}
					if (fileOffset > 0L)
					{
						requestHttp.AddRange((int)fileOffset);
					}
					webResponse = requestHttp.GetResponse();
					Stream ns = webResponse.GetResponseStream();
					ns.ReadTimeout = this.REQUEST_TIME_LIMIT;
					for (;;)
					{
						try
						{
							nReadSize = ns.Read(downloadCache, 0, this.DOWNLOAD_CHUNK_SIZE);
							if (nReadSize <= 0)
							{
								break;
							}
							fs.Write(downloadCache, 0, nReadSize);
							int num = (int)((double)((float)(fs.Length * 100L) / (float)this.m_TotalSize) * 0.69);
							msg = "正在下载文件：";
							this._DisplayUpdateState(msg);
							float num2 = 9.536743E-07f;
							string str = string.Format("  已下载{0}MB（共{1}MB）", ((float)fs.Length * num2).ToString("G3"), ((float)this.m_TotalSize * num2).ToString("G3"));
							this._DisplayUpdateInfo(num + 10, patchAssetName + str);
						}
						catch (Exception ex3)
						{
							yield break;
						}
						yield return nReadSize;
					}
					ns.Close();
					fs.Close();
					webResponse.Close();
					webResponse = null;
					requestHttp.Abort();
					requestHttp = null;
				}
				this.m_UpdateState = VersionUpdateState.CheckPatch;
				string downloadedAssetMD5 = FileUtil.GetFileMD5(assetDownloadPath);
				if (!downloadedAssetMD5.ToLower().Equals(assetDesc.assetMD5.ToLower()))
				{
					File.Delete(Path.Combine(Application.persistentDataPath, patchAssetName));
					string msgContent3 = "由于网络问题导致更新的压缩包损坏，是否重新下载？";
					SystemNotifyManager.HotUpdateMsgBoxOkCancel(msgContent3, new UnityAction(this._OnRetryHotUpdate_OK), new UnityAction(this._OnRetryHotUpdate_Cancel));
					yield break;
				}
				msg = "正在解压文件...";
				this._DisplayUpdateState(msg);
				this._DisplayUpdateInfo(80, string.Empty);
				this.m_UpdateState = VersionUpdateState.InstallPatch;
				if (!LibZipFileReader.UncompressAll(Path.Combine(Application.persistentDataPath, patchAssetName)))
				{
					SystemNotifyManager.BaseMsgBoxOK("解压更新文件失败，请清理设备存储空间后重试！", null, string.Empty);
					Singleton<VersionManager>.instance.m_IsLastest = false;
					this.m_UpdateState = VersionUpdateState.FinishUpdate;
					this._DisplayUpdateInfo(0, "解压更新文件失败，请清理设备存储空间后重试！");
					yield break;
				}
				File.Delete(Path.Combine(Application.persistentDataPath, patchAssetName));
			}
			string verPath = Path.Combine(Application.persistentDataPath, this.VERSION_INFO_FILE_NAME);
			FileStream streamW = new FileStream(verPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
			streamW.SetLength(0L);
			StreamWriter sw = new StreamWriter(streamW);
			this.m_NativeVersion = this.m_RemoteVersion;
			this.m_VersionTbl[this.PLATFORM_STRING] = this.m_NativeVersion;
			sw.Write(MiniJSON.jsonEncode(this.m_VersionTbl));
			streamW.Flush();
			sw.Close();
			streamW.Close();
			Singleton<VersionManager>.instance.Init();
			string info = "祝您游戏愉快！";
			string state = "更新完毕";
			this._DisplayUpdateState(state);
			this._DisplayUpdateInfo(100, info);
			this.m_UpdateState = VersionUpdateState.FinishUpdate;
			Singleton<VersionManager>.instance.m_IsLastest = true;
			this._DisplayUpdateInfo(100, "正在重新启动游戏...");
			this.m_UpdateState = VersionUpdateState.WaitForRestart;
			yield return Yielders.GetWaitForSeconds(1f);
			HotUpdateDownloader.RestartApp();
			Debug.Log("Hot fix completed!");
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0005EC18 File Offset: 0x0005D018
		public void DoDeleteExpirePackage()
		{
			string text = Path.Combine(this._GetHotfixAccessPath(), this.DELETE_PACKAGE_LIST_NAME);
			Debug.LogWarningFormat("Hot fix delete package list file[{0}]!", new object[]
			{
				text
			});
			string empty = string.Empty;
			if (FileArchiveAccessor.LoadFileInPersistentFileArchive(this.DELETE_PACKAGE_LIST_NAME, out empty))
			{
				ArrayList arrayList = MiniJSON.jsonDecode(empty) as ArrayList;
				if (arrayList != null)
				{
					int i = 0;
					int count = arrayList.Count;
					while (i < count)
					{
						string text2 = arrayList[i] as string;
						if (!string.IsNullOrEmpty(text2))
						{
							string text3 = Path.Combine(this._GetHotfixAccessPath(), Path.Combine("AssetBundles", text2));
							Debug.LogWarningFormat("Hot fix delete package file[{0}]!", new object[]
							{
								text3
							});
							if (File.Exists(text3))
							{
								File.Delete(text3);
							}
						}
						i++;
					}
				}
				if (File.Exists(text))
				{
					Debug.LogWarningFormat("Hot fix delete package list file is exist[{0}]!", new object[]
					{
						text
					});
					File.Delete(text);
				}
				else
				{
					Debug.LogWarningFormat("Hot fix delete package list file is not exist[{0}]!", new object[]
					{
						text
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("Hot fix can't open file [{0}]!", new object[]
				{
					text
				});
			}
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x0005ED42 File Offset: 0x0005D142
		protected string _GetDiffListFileUrl(string packageFile)
		{
			return string.Concat(new string[]
			{
				this._GetResourceServerRoot(),
				this.PLATFORM_STRING,
				"/zip/",
				this.m_RemoteVersion,
				"/",
				packageFile
			});
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x0005ED80 File Offset: 0x0005D180
		private bool _ParseDiffList(string diffData, ref long totalSize, ref long downloadedSize)
		{
			string text = diffData.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			}, StringSplitOptions.RemoveEmptyEntries);
			this.m_DiffAssetDescArray = new HotUpdateDownloader.DiffAssetDesc[array.Length];
			totalSize = 0L;
			downloadedSize = 0L;
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					','
				}, StringSplitOptions.RemoveEmptyEntries);
				HotUpdateDownloader.DiffAssetDesc diffAssetDesc = new HotUpdateDownloader.DiffAssetDesc();
				try
				{
					diffAssetDesc.assetUrl = array2[0].Replace("zip:", null);
					diffAssetDesc.assetMD5 = array2[1].Replace("md5:", null);
					diffAssetDesc.assetBytes = long.Parse(array2[2].Replace(" bytes", null));
					this.m_DiffAssetDescArray[i] = diffAssetDesc;
					totalSize += diffAssetDesc.assetBytes;
					string path = Path.Combine(Application.persistentDataPath, Path.GetFileName(diffAssetDesc.assetUrl));
					long fileBytes = FileUtil.GetFileBytes(path);
					if (fileBytes >= 0L)
					{
						downloadedSize += fileBytes;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x0005EE9C File Offset: 0x0005D29C
		protected string _GetResourceServerRoot()
		{
			if (this.m_LocalHost)
			{
				return "http://localhost/DNF/";
			}
			if (this.m_ServerList != null)
			{
				int index = Random.Range(0, this.m_ServerList.Count);
				return this.m_ServerList[index] as string;
			}
			return string.Empty;
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x0005EEEE File Offset: 0x0005D2EE
		protected void _DisplayUpdateState(string updateState)
		{
			if (this.m_UI != null && this.m_UI.IsOpen())
			{
				this.m_UI.UpdateProgressState(updateState);
			}
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x0005EF17 File Offset: 0x0005D317
		protected void _DisplayUpdateInfo(int progress, string info)
		{
			if (this.m_UI != null && this.m_UI.IsOpen())
			{
				this.m_UI.UpdateProgress(progress, info);
			}
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0005EF44 File Offset: 0x0005D344
		protected bool _LoadHackServerList()
		{
			string json = null;
			if (FileArchiveAccessor.LoadFileInPersistentFileArchive(this.UPDATA_SERVER_HACK_FILE_NAME, out json))
			{
				this.m_ServerList = (MiniJSON.jsonDecode(json) as ArrayList);
				if (this.m_ServerList != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x0005EF84 File Offset: 0x0005D384
		protected void _LoadServerList()
		{
			string text = Path.Combine(this._GetLocalAccessUrlProtocol(), this.UPDATA_SERVER_FILE_NAME);
			byte[] array = null;
			WWW www = new WWW(text);
			while (!www.isDone)
			{
			}
			if (www.error == null)
			{
				List<byte> list = new List<byte>();
				list.AddRange(www.bytes);
				array = list.ToArray();
			}
			else
			{
				Debug.LogWarning(www.error);
			}
			www.Dispose();
			if (array != null)
			{
				this.m_ServerList = this._GetUpdateServerFromJson(Encoding.Default.GetString(array));
			}
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x0005F018 File Offset: 0x0005D418
		protected string _GetLocalAccessUrlProtocol()
		{
			switch (this.m_Platform)
			{
			case HotUpdateDownloader.CustomPlatform.PC:
				return "file:///" + Application.streamingAssetsPath;
			case HotUpdateDownloader.CustomPlatform.iOS:
				return "file://" + Application.streamingAssetsPath;
			case HotUpdateDownloader.CustomPlatform.Android:
				return "jar:file://" + Application.dataPath + "!/assets/";
			default:
				return "file:///" + Application.streamingAssetsPath;
			}
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0005F088 File Offset: 0x0005D488
		protected string _GetHotfixAccessUrlProtocol()
		{
			switch (this.m_Platform)
			{
			case HotUpdateDownloader.CustomPlatform.PC:
				return "file:///" + Application.persistentDataPath;
			case HotUpdateDownloader.CustomPlatform.iOS:
				return "file://" + Application.persistentDataPath;
			case HotUpdateDownloader.CustomPlatform.Android:
				return "file://" + Application.persistentDataPath;
			default:
				return "file:///" + Application.persistentDataPath;
			}
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0005F0F2 File Offset: 0x0005D4F2
		protected string _GetHotfixAccessPath()
		{
			return Application.persistentDataPath;
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x0005F0FC File Offset: 0x0005D4FC
		protected string _GetVersionFromJson(string jsonData, ref Hashtable versionTable)
		{
			try
			{
				if (!string.IsNullOrEmpty(jsonData))
				{
					versionTable = (MiniJSON.jsonDecode(jsonData) as Hashtable);
					if (versionTable != null)
					{
						return versionTable[this.PLATFORM_STRING] as string;
					}
					Debug.Log("[_GetVersionFromJson] versionTable is null");
				}
				else
				{
					Debug.Log("[_GetVersionFromJson] jsonData is null");
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Get version form json has failed! Exception:" + ex.ToString(), new object[0]);
				versionTable = null;
			}
			return this.DEFAULT_VERSION;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x0005F19C File Offset: 0x0005D59C
		protected bool _GetCommonSwitchFromJson(string jsonData, string key)
		{
			try
			{
				if (!string.IsNullOrEmpty(jsonData))
				{
					Hashtable jsonTable = MiniJSON.jsonDecode(jsonData) as Hashtable;
					return this._GetCommonSwitchFromJson(jsonTable, key);
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[_GetCommonSwitchFromJson] Get version form json has failed! Exception: {0}", new object[]
				{
					ex.ToString()
				});
			}
			return false;
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x0005F208 File Offset: 0x0005D608
		protected bool _GetCommonSwitchFromJson(Hashtable jsonTable, string key)
		{
			try
			{
				if (jsonTable != null && jsonTable.ContainsKey(key))
				{
					string text = jsonTable[key] as string;
					if (!string.IsNullOrEmpty(text))
					{
						if (text.Equals("true", StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
						return false;
					}
					else
					{
						Debug.Log("[_GetCommonSwitchFromJson] agreement is null");
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[_GetCommonSwitchFromJson] Get version form json has failed! Exception: {0}", new object[]
				{
					ex.ToString()
				});
			}
			return false;
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0005F2A0 File Offset: 0x0005D6A0
		protected SDKChannel[] _GetCommonSDKChannelSwitch(string jsonData, string key)
		{
			SDKChannel[] result = new SDKChannel[0];
			try
			{
				if (!string.IsNullOrEmpty(jsonData))
				{
					Hashtable jsonTable = MiniJSON.jsonDecode(jsonData) as Hashtable;
					return this._GetCommonSDKChannelSwitch(jsonTable, key);
				}
				Debug.Log("[_GetCommonSDKChannelSwitch] jsonData is null");
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[_GetCommonSDKChannelSwitch] Get version form json has failed! Exception: {0}", new object[]
				{
					ex.ToString()
				});
			}
			return result;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x0005F31C File Offset: 0x0005D71C
		protected SDKChannel[] _GetCommonSDKChannelSwitch(Hashtable jsonTable, string key)
		{
			SDKChannel[] array = new SDKChannel[0];
			try
			{
				if (jsonTable != null && jsonTable.ContainsKey(key))
				{
					string text = jsonTable[key] as string;
					if (string.IsNullOrEmpty(text))
					{
						return array;
					}
					string[] array2 = text.Split(new char[]
					{
						','
					});
					if (array2 == null || array2.Length <= 0)
					{
						return array;
					}
					array = new SDKChannel[array2.Length];
					for (int i = 0; i < array2.Length; i++)
					{
						try
						{
							array[i] = (SDKChannel)Enum.Parse(typeof(SDKChannel), array2[i]);
						}
						catch (Exception ex)
						{
							Debug.LogErrorFormat("[_GetCommonSDKChannelSwitch] enum parse failed : {0}", new object[]
							{
								ex.ToString()
							});
							return new SDKChannel[0];
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.LogErrorFormat("[_GetCommonSDKChannelSwitch] Get version form json has failed! Exception: {0}", new object[]
				{
					ex2.ToString()
				});
			}
			return array;
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x0005F438 File Offset: 0x0005D838
		protected ArrayList _GetUpdateServerFromJson(string jsonData)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList result;
			try
			{
				Hashtable hashtable = MiniJSON.jsonDecode(jsonData) as Hashtable;
				if (hashtable != null)
				{
					if (Global.Settings.hotFixUrlDebug)
					{
						arrayList = (hashtable["debug"] as ArrayList);
					}
					else
					{
						arrayList = (hashtable["release"] as ArrayList);
					}
				}
				else
				{
					Debug.Log("[_GetUpdateServerFromJson] table is null");
				}
				result = arrayList;
			}
			catch (Exception ex)
			{
				arrayList.Clear();
				result = arrayList;
			}
			return result;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x0005F4C8 File Offset: 0x0005D8C8
		private bool _IsWifiUsed()
		{
			return Application.internetReachability == 2;
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x0005F4D2 File Offset: 0x0005D8D2
		private bool _IsFileNotFound(string error)
		{
			return error.Contains("404");
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x0005F4DF File Offset: 0x0005D8DF
		protected bool _SendErrorEmail(string title, string content)
		{
			return MailSender.SetEmail(title, content);
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x0005F4E8 File Offset: 0x0005D8E8
		protected void _ClearHotUpdateCaches()
		{
			Debug.LogWarning("Clean hot-fix bundles!");
			string path = Path.Combine(this._GetHotfixAccessPath(), "AssetBundles");
			if (Directory.Exists(path))
			{
				Directory.Delete(path, true);
			}
			string path2 = Path.Combine(this._GetHotfixAccessPath(), "version.config");
			if (File.Exists(path2))
			{
				File.Delete(path2);
			}
			string path3 = Path.Combine(this._GetHotfixAccessPath(), this.VERSION_INFO_FILE_NAME);
			if (File.Exists(path3))
			{
				File.Delete(path3);
			}
			string path4 = Path.Combine(this._GetHotfixAccessPath(), "Assembly-CSharp.dll");
			if (File.Exists(path4))
			{
				File.Delete(path4);
			}
			string path5 = Path.Combine(this._GetHotfixAccessPath(), "Assembly-CSharp-firstpass.dll");
			if (File.Exists(path5))
			{
				File.Delete(path5);
			}
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x0005F5AE File Offset: 0x0005D9AE
		protected void _ProcessQuitProcedural()
		{
			Application.Quit();
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x0005F5B8 File Offset: 0x0005D9B8
		public IEnumerator ProcessPackageDownload()
		{
			yield return this._GetLocalPackageVersion();
			string packageListFile = Path.Combine(this._GetHotfixAccessUrlProtocol(), this.m_PackageListFile);
			WWW packageListFileWWW = new WWW(packageListFile);
			yield return packageListFileWWW;
			Debug.LogWarningFormat("Local version:{0}", new object[]
			{
				this.m_LocalPatchVersion
			});
			bool needFetchPackage = true;
			if (packageListFileWWW.error == null)
			{
				ArrayList arrayList = MiniJSON.jsonDecode(packageListFileWWW.text) as ArrayList;
				if (arrayList != null && arrayList.Count > 0)
				{
					string s = arrayList[0] as string;
					int num = 0;
					int.TryParse(s, out num);
					int num2 = 1;
					int.TryParse(this.m_LocalPatchVersion, out num2);
					if (num >= num2)
					{
						needFetchPackage = false;
					}
				}
			}
			packageListFileWWW.Dispose();
			if (needFetchPackage)
			{
				yield return this._FetchAssetPackage();
			}
			yield break;
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x0005F5D4 File Offset: 0x0005D9D4
		private IEnumerator _GetLocalPackageVersion()
		{
			string localStreamVerFile = Path.Combine(this._GetLocalAccessUrlProtocol(), this.VERSION_INFO_FILE_NAME);
			WWW localStreamVerFileWWW = new WWW(localStreamVerFile);
			yield return localStreamVerFileWWW;
			string verLocalJson = null;
			Hashtable verTblLocal = null;
			if (localStreamVerFileWWW.error == null)
			{
				verLocalJson = this._GetVersionFromJson(localStreamVerFileWWW.text, ref verTblLocal);
				Debug.LogWarning("### Native local version:" + verLocalJson);
			}
			localStreamVerFileWWW.Dispose();
			if (!string.IsNullOrEmpty(verLocalJson) && !string.IsNullOrEmpty(verLocalJson))
			{
				string[] array = verLocalJson.Split(new char[]
				{
					'.'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4)
				{
					this.m_LocalPatchVersion = array[3];
					yield break;
				}
			}
			this.m_LocalPatchVersion = null;
			yield break;
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x0005F5EF File Offset: 0x0005D9EF
		protected string _GetPackageListFileUrl(string packageFile)
		{
			return string.Concat(new string[]
			{
				this._GetResourceServerRoot(),
				"package/",
				this.PLATFORM_STRING,
				"/",
				packageFile
			});
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x0005F624 File Offset: 0x0005DA24
		private bool _ParsePackageList(string diffData, ref long totalSize, ref long downloadedSize)
		{
			string text = diffData.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			}, StringSplitOptions.RemoveEmptyEntries);
			this.m_PackageDescArray = new HotUpdateDownloader.PackageDesc[array.Length];
			totalSize = 0L;
			downloadedSize = 0L;
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					','
				}, StringSplitOptions.RemoveEmptyEntries);
				HotUpdateDownloader.PackageDesc packageDesc = new HotUpdateDownloader.PackageDesc();
				try
				{
					packageDesc.assetUrl = array2[0].Replace("zip:", null);
					packageDesc.assetMD5 = array2[1].Replace("md5:", null);
					packageDesc.assetBytes = long.Parse(array2[2].Replace(" bytes", null));
					this.m_PackageDescArray[i] = packageDesc;
					totalSize += packageDesc.assetBytes;
					string path = Path.Combine(Application.persistentDataPath, Path.GetFileName(packageDesc.assetUrl));
					long fileBytes = FileUtil.GetFileBytes(path);
					if (fileBytes >= 0L)
					{
						downloadedSize += fileBytes;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x0005F740 File Offset: 0x0005DB40
		private IEnumerator _FetchAssetPackage()
		{
			string packageFile = "package-" + this.m_LocalPatchVersion + ".txt";
			Debug.Log("Target patch:" + packageFile);
			this.m_DownloadState = HotUpdateDownloader.PackageDownloadState.GetPackageList;
			string diffListData = null;
			string packageListFileUrl = null;
			string lastError = string.Empty;
			WWW packageListWWW = null;
			int retryCnt = 0;
			bool isConnectOK = false;
			do
			{
				packageListFileUrl = this._GetPackageListFileUrl(packageFile).Replace('\\', '/');
				packageListWWW = new WWW(packageListFileUrl);
				yield return packageListWWW;
				if (packageListWWW.error == null && !string.IsNullOrEmpty(packageListWWW.text))
				{
					diffListData = packageListWWW.text;
					isConnectOK = true;
				}
				else
				{
					lastError = packageListWWW.error;
				}
				packageListWWW.Dispose();
				if (isConnectOK)
				{
					break;
				}
				retryCnt++;
			}
			while (retryCnt < 3);
			if (isConnectOK && !string.IsNullOrEmpty(diffListData))
			{
				if (this._ParsePackageList(diffListData, ref this.m_TotalSize, ref this.m_DownloadedSize))
				{
					if (!this._IsWifiUsed())
					{
						yield break;
					}
					yield return this._DownloadPacakges();
				}
			}
			yield break;
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x0005F75C File Offset: 0x0005DB5C
		private IEnumerator _DownloadPacakges()
		{
			ServicePointManager.DefaultConnectionLimit = 30;
			byte[] downloadCache = new byte[this.DOWNLOAD_CHUNK_SIZE];
			string assetFullUrl = string.Empty;
			string patchAssetName = string.Empty;
			this.m_DownloadState = HotUpdateDownloader.PackageDownloadState.DownloadPackage;
			int nReadSize = 0;
			for (int i = 0; i < this.m_PackageDescArray.Length; i++)
			{
				HotUpdateDownloader.PackageDesc assetDesc = this.m_PackageDescArray[i];
				assetFullUrl = this._GetPackageListFileUrl(assetDesc.assetUrl);
				patchAssetName = Path.GetFileName(assetFullUrl);
				GC.Collect();
				long responseCountLength = 0L;
				HttpWebRequest requestHttp = null;
				WebResponse webResponse = null;
				try
				{
					requestHttp = (WebRequest.Create(assetFullUrl) as HttpWebRequest);
					webResponse = requestHttp.GetResponse();
					responseCountLength = webResponse.ContentLength;
					requestHttp.KeepAlive = false;
					webResponse.Close();
					webResponse = null;
					requestHttp.Abort();
					requestHttp = null;
				}
				catch (Exception ex)
				{
					Logger.LogError("Get http download request count length has failed! Exception:" + ex.ToString());
					yield break;
				}
				string assetDownloadPath = Path.Combine(Application.persistentDataPath, patchAssetName);
				long fileOffset = FileUtil.GetFileBytes(assetDownloadPath);
				if (fileOffset < responseCountLength)
				{
					FileStream fs;
					if (fileOffset != -1L)
					{
						fs = File.OpenWrite(assetDownloadPath);
						fs.Seek(fileOffset, SeekOrigin.Current);
					}
					else
					{
						fs = new FileStream(assetDownloadPath, FileMode.Create);
					}
					requestHttp = null;
					try
					{
						requestHttp = (WebRequest.Create(assetFullUrl) as HttpWebRequest);
					}
					catch (Exception ex2)
					{
						base.StartCoroutine(this._FetchAssetPackage());
						yield break;
					}
					if (fileOffset > 0L)
					{
						requestHttp.AddRange((int)fileOffset);
					}
					webResponse = requestHttp.GetResponse();
					Stream ns = webResponse.GetResponseStream();
					ns.ReadTimeout = this.REQUEST_TIME_LIMIT;
					for (;;)
					{
						try
						{
							nReadSize = ns.Read(downloadCache, 0, this.DOWNLOAD_CHUNK_SIZE);
							if (nReadSize <= 0)
							{
								break;
							}
							fs.Write(downloadCache, 0, nReadSize);
							int num = (int)((double)((float)(fs.Length * 100L) / (float)this.m_TotalSize) * 0.69);
							float num2 = 9.536743E-07f;
							string str = string.Format("  已下载{0}MB（共{1}MB）", ((float)fs.Length * num2).ToString("G3"), ((float)this.m_TotalSize * num2).ToString("G3"));
							Logger.LogError(str);
						}
						catch (Exception ex3)
						{
							yield break;
						}
						yield return nReadSize;
					}
					ns.Close();
					fs.Close();
					webResponse.Close();
					webResponse = null;
					requestHttp.Abort();
					requestHttp = null;
				}
				this.m_DownloadState = HotUpdateDownloader.PackageDownloadState.VerifyPackage;
				yield return FileUtil.GetFileMD5Async(assetDownloadPath);
				string downloadedAssetMD5 = FileUtil.md5;
				if (!downloadedAssetMD5.ToLower().Equals(assetDesc.assetMD5.ToLower()))
				{
					Debug.LogWarning("MD5效验失败，包体下载失败！");
					yield break;
				}
				this.m_DownloadState = HotUpdateDownloader.PackageDownloadState.UnzipPackage;
				yield return LibZipFileReader.UncompressAllAsync(Path.Combine(Application.persistentDataPath, patchAssetName), 64, null);
			}
			yield return Yielders.EndOfFrame;
			File.Delete(Path.Combine(Application.persistentDataPath, patchAssetName));
			this.m_DownloadState = HotUpdateDownloader.PackageDownloadState.Finish;
			Debug.Log("Asset package download completed!");
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x04000BBB RID: 3003
		private HotUpdateDownloader.HotUpdateConfig mHotUpdateConfig;

		// Token: 0x04000BBC RID: 3004
		protected readonly string[] PLATFORM_STRING_TABLE = new string[]
		{
			"pc",
			"ios",
			"android"
		};

		// Token: 0x04000BBD RID: 3005
		protected HotUpdateDownloader.DiffAssetDesc[] m_DiffAssetDescArray;

		// Token: 0x04000BBE RID: 3006
		protected long m_TotalSize;

		// Token: 0x04000BBF RID: 3007
		protected long m_DownloadedSize;

		// Token: 0x04000BC0 RID: 3008
		protected readonly int DOWNLOAD_CHUNK_SIZE = 1048576;

		// Token: 0x04000BC1 RID: 3009
		protected readonly int REQUEST_TIME_LIMIT = 16000;

		// Token: 0x04000BC2 RID: 3010
		protected readonly string VERSION_INFO_FILE_NAME = "version.json";

		// Token: 0x04000BC3 RID: 3011
		protected readonly string FULLPACKAGE_INFO_FILE_NAME = "full-package.json";

		// Token: 0x04000BC4 RID: 3012
		protected readonly string VERSION_EXPIRE_FILE_NAME = "version-expire.json";

		// Token: 0x04000BC5 RID: 3013
		protected readonly string UPDATA_SERVER_FILE_NAME = "updateserver.json";

		// Token: 0x04000BC6 RID: 3014
		protected readonly string UPDATA_SERVER_HACK_FILE_NAME = "updateserver-hack.json";

		// Token: 0x04000BC7 RID: 3015
		protected readonly string VERSION_INFO_FILE_LOCAL_PATH = string.Empty;

		// Token: 0x04000BC8 RID: 3016
		protected readonly string FORCE_UPDATE_PACKAGE_NAME = "fullupdateurl.json";

		// Token: 0x04000BC9 RID: 3017
		protected string m_ForceUpdateUrl = string.Empty;

		// Token: 0x04000BCA RID: 3018
		protected readonly string DELETE_PACKAGE_LIST_NAME = "delpackagelist.json";

		// Token: 0x04000BCB RID: 3019
		protected readonly string DEFAULT_VERSION = "1.0.1.0";

		// Token: 0x04000BCC RID: 3020
		protected HotUpdateDownloader.CustomPlatform m_Platform;

		// Token: 0x04000BCD RID: 3021
		protected string PLATFORM_STRING = string.Empty;

		// Token: 0x04000BCE RID: 3022
		protected bool m_LocalHost;

		// Token: 0x04000BCF RID: 3023
		protected bool m_LocalNewer;

		// Token: 0x04000BD0 RID: 3024
		protected string m_NativeVersion = string.Empty;

		// Token: 0x04000BD1 RID: 3025
		protected string m_RemoteVersion = string.Empty;

		// Token: 0x04000BD2 RID: 3026
		protected string m_ExpireVersion = string.Empty;

		// Token: 0x04000BD3 RID: 3027
		protected VersionCheckResult m_CheckRes = VersionCheckResult.Lastest;

		// Token: 0x04000BD4 RID: 3028
		protected HotUpdateDownloader.VersionDesc m_CurNativeVerDesc = new HotUpdateDownloader.VersionDesc();

		// Token: 0x04000BD5 RID: 3029
		protected HotUpdateDownloader.VersionDesc m_CurRemoteVerDesc = new HotUpdateDownloader.VersionDesc();

		// Token: 0x04000BD6 RID: 3030
		protected VersionUpdateFrame m_UI;

		// Token: 0x04000BD7 RID: 3031
		protected Hashtable m_VersionTbl;

		// Token: 0x04000BD8 RID: 3032
		protected ArrayList m_ServerList;

		// Token: 0x04000BD9 RID: 3033
		protected VersionUpdateState m_UpdateState;

		// Token: 0x04000BDA RID: 3034
		protected bool m_HasSendErrorMail;

		// Token: 0x04000BDB RID: 3035
		private WaitForEndOfFrame WAIT_FOR_ENDOFFRAME = new WaitForEndOfFrame();

		// Token: 0x04000BDC RID: 3036
		protected HotUpdateDownloader.PackageDesc[] m_PackageDescArray;

		// Token: 0x04000BDD RID: 3037
		protected HotUpdateDownloader.PackageDownloadState m_DownloadState;

		// Token: 0x04000BDE RID: 3038
		protected string m_LocalPatchVersion = string.Empty;

		// Token: 0x04000BDF RID: 3039
		protected string m_PackageListFile = "packagelist.json";

		// Token: 0x02000216 RID: 534
		// (Invoke) Token: 0x060011F6 RID: 4598
		private delegate void OnDownloadPatchFailed();

		// Token: 0x02000217 RID: 535
		protected class DiffAssetDesc
		{
			// Token: 0x04000BE0 RID: 3040
			public string assetUrl;

			// Token: 0x04000BE1 RID: 3041
			public string assetMD5;

			// Token: 0x04000BE2 RID: 3042
			public long assetBytes;
		}

		// Token: 0x02000218 RID: 536
		protected class HotUpdateConfig
		{
			// Token: 0x1700020B RID: 523
			// (get) Token: 0x060011FB RID: 4603 RVA: 0x0005F787 File Offset: 0x0005DB87
			// (set) Token: 0x060011FC RID: 4604 RVA: 0x0005F78F File Offset: 0x0005DB8F
			public string patchIndexFileFetchInfo { get; set; }

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x060011FD RID: 4605 RVA: 0x0005F798 File Offset: 0x0005DB98
			// (set) Token: 0x060011FE RID: 4606 RVA: 0x0005F7A0 File Offset: 0x0005DBA0
			public string packageNotValid { get; set; }

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x060011FF RID: 4607 RVA: 0x0005F7A9 File Offset: 0x0005DBA9
			// (set) Token: 0x06001200 RID: 4608 RVA: 0x0005F7B1 File Offset: 0x0005DBB1
			public string forceUpdate { get; set; }

			// Token: 0x1700020E RID: 526
			// (get) Token: 0x06001201 RID: 4609 RVA: 0x0005F7BA File Offset: 0x0005DBBA
			// (set) Token: 0x06001202 RID: 4610 RVA: 0x0005F7C2 File Offset: 0x0005DBC2
			public string packageVersionIsHigh { get; set; }

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x06001203 RID: 4611 RVA: 0x0005F7CB File Offset: 0x0005DBCB
			// (set) Token: 0x06001204 RID: 4612 RVA: 0x0005F7D3 File Offset: 0x0005DBD3
			public string patchZipFileFetchInfo { get; set; }

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x06001205 RID: 4613 RVA: 0x0005F7DC File Offset: 0x0005DBDC
			// (set) Token: 0x06001206 RID: 4614 RVA: 0x0005F7E4 File Offset: 0x0005DBE4
			public string versionFileFetchInfo { get; set; }

			// Token: 0x17000211 RID: 529
			// (get) Token: 0x06001207 RID: 4615 RVA: 0x0005F7ED File Offset: 0x0005DBED
			// (set) Token: 0x06001208 RID: 4616 RVA: 0x0005F7F5 File Offset: 0x0005DBF5
			public string networkErrorInfo { get; set; }

			// Token: 0x17000212 RID: 530
			// (get) Token: 0x06001209 RID: 4617 RVA: 0x0005F7FE File Offset: 0x0005DBFE
			// (set) Token: 0x0600120A RID: 4618 RVA: 0x0005F806 File Offset: 0x0005DC06
			public string pathZipFileDownloadError { get; set; }

			// Token: 0x17000213 RID: 531
			// (get) Token: 0x0600120B RID: 4619 RVA: 0x0005F80F File Offset: 0x0005DC0F
			// (set) Token: 0x0600120C RID: 4620 RVA: 0x0005F817 File Offset: 0x0005DC17
			public string fullPackageDownloadUrl { get; set; }
		}

		// Token: 0x02000219 RID: 537
		protected class VersionDesc
		{
			// Token: 0x0600120D RID: 4621 RVA: 0x0005F820 File Offset: 0x0005DC20
			public VersionDesc()
			{
				int[] array = new int[4];
				array[0] = 1;
				array[2] = 1;
				this.m_VersionNumber = array;
				base..ctor();
			}

			// Token: 0x0600120E RID: 4622 RVA: 0x0005F83C File Offset: 0x0005DC3C
			public void Reset()
			{
				this.m_VersionString = null;
				this.m_VersionTbl = null;
				this.m_LocalNewer = false;
				this.m_IsVersionOK = false;
				if (this.m_VersionNumber == null)
				{
					int[] array = new int[4];
					array[0] = 1;
					array[2] = 1;
					this.m_VersionNumber = array;
				}
				else
				{
					this.m_VersionNumber[0] = 1;
					this.m_VersionNumber[1] = 0;
					this.m_VersionNumber[2] = 1;
					this.m_VersionNumber[3] = 0;
				}
			}

			// Token: 0x04000BEC RID: 3052
			public Hashtable m_VersionTbl;

			// Token: 0x04000BED RID: 3053
			public bool m_LocalNewer;

			// Token: 0x04000BEE RID: 3054
			public bool m_IsVersionOK;

			// Token: 0x04000BEF RID: 3055
			public int[] m_VersionNumber;

			// Token: 0x04000BF0 RID: 3056
			public string m_VersionString;
		}

		// Token: 0x0200021A RID: 538
		public enum CustomPlatform
		{
			// Token: 0x04000BF2 RID: 3058
			PC,
			// Token: 0x04000BF3 RID: 3059
			iOS,
			// Token: 0x04000BF4 RID: 3060
			Android,
			// Token: 0x04000BF5 RID: 3061
			MaxPlatformNum
		}

		// Token: 0x0200021B RID: 539
		private enum VersionType
		{
			// Token: 0x04000BF7 RID: 3063
			ServerMajor,
			// Token: 0x04000BF8 RID: 3064
			ServerMinor,
			// Token: 0x04000BF9 RID: 3065
			CustomMajor,
			// Token: 0x04000BFA RID: 3066
			CustomPatch,
			// Token: 0x04000BFB RID: 3067
			VersionTypeNum
		}

		// Token: 0x0200021C RID: 540
		public enum PackageDownloadState
		{
			// Token: 0x04000BFD RID: 3069
			None,
			// Token: 0x04000BFE RID: 3070
			CheckLocalVerion,
			// Token: 0x04000BFF RID: 3071
			CheckNetwork,
			// Token: 0x04000C00 RID: 3072
			GetPackageList,
			// Token: 0x04000C01 RID: 3073
			DownloadPackage,
			// Token: 0x04000C02 RID: 3074
			VerifyPackage,
			// Token: 0x04000C03 RID: 3075
			UnzipPackage,
			// Token: 0x04000C04 RID: 3076
			Finish
		}

		// Token: 0x0200021D RID: 541
		protected class PackageDesc
		{
			// Token: 0x04000C05 RID: 3077
			public string assetUrl;

			// Token: 0x04000C06 RID: 3078
			public string assetMD5;

			// Token: 0x04000C07 RID: 3079
			public long assetBytes;
		}
	}
}
