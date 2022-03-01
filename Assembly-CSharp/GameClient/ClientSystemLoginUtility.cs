using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Client;
using MobileBind;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200115D RID: 4445
	public class ClientSystemLoginUtility
	{
		// Token: 0x0600A9BC RID: 43452 RVA: 0x002401A8 File Offset: 0x0023E5A8
		[Conditional("USE_NO_SDK_SERVER_LOGIN")]
		public static void SetLoginReqData_SkipSdk(string req_param, string req_hashvalue, string req_tablemd5, string req_skillmd5, string req_sv)
		{
			ClientSystemLoginUtility.req_param = req_param;
			ClientSystemLoginUtility.req_hashvalue = req_hashvalue;
			ClientSystemLoginUtility.req_tablemd5 = req_tablemd5;
			ClientSystemLoginUtility.req_skillmd5 = req_skillmd5;
			ClientSystemLoginUtility.req_sv = req_sv;
		}

		// Token: 0x0600A9BD RID: 43453 RVA: 0x002401CC File Offset: 0x0023E5CC
		[Conditional("USE_NO_SDK_SERVER_LOGIN")]
		private static void SetLoginReq(AdminLoginVerifyReq req)
		{
			req.param = ClientSystemLoginUtility.req_param;
			string[] array = ClientSystemLoginUtility.req_hashvalue.Split(new char[]
			{
				','
			});
			string text = ClientSystemLoginUtility.req_hashvalue;
			byte[] array2 = new byte[20];
			for (int i = 0; i < text.Length / 2; i++)
			{
				array2[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
			}
			uint num = 1U;
			num <<= 8;
			num += Convert.ToUInt32(ClientSystemLoginUtility.req_sv);
			num <<= 16;
			num += 1U;
			req.version = num;
			req.hashValue = array2;
			req.tableMd5 = DungeonUtility.GetMD5(ClientSystemLoginUtility.req_tablemd5.ToLower() + ClientSystemLoginUtility.req_skillmd5.ToLower() + req.param);
			ClientApplication.playerinfo.param = ClientSystemLoginUtility.req_param;
			ClientApplication.playerinfo.hashValue = array2;
		}

		// Token: 0x0600A9BE RID: 43454 RVA: 0x002402AD File Offset: 0x0023E6AD
		public static void StartLoginAfterVerify()
		{
			ClientSystemLoginUtility.StopLoginAfterVerify();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginStart, null, null, null, null);
			ClientSystemLoginUtility.mLoginProcess = MonoSingleton<GameFrameWork>.instance.StartCoroutine(ClientSystemLoginUtility._loginAfterVerify());
		}

		// Token: 0x0600A9BF RID: 43455 RVA: 0x002402DC File Offset: 0x0023E6DC
		public static void StopLoginAfterVerify()
		{
			if (ClientSystemLoginUtility.mLoginProcess != null && ClientSystemLoginUtility.IsLogining())
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(ClientSystemLoginUtility.mLoginProcess);
				ClientSystemLoginUtility.mLoginProcess = null;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
			}
		}

		// Token: 0x0600A9C0 RID: 43456 RVA: 0x0024032A File Offset: 0x0023E72A
		public static bool IsLogining()
		{
			return ClientSystemLoginUtility.mIsLogin;
		}

		// Token: 0x0600A9C1 RID: 43457 RVA: 0x00240334 File Offset: 0x0023E734
		private static IEnumerator _loginAfterVerify()
		{
			ClientSystemLoginUtility.mIsLogin = true;
			if (string.IsNullOrEmpty(ClientApplication.adminServer.ip) || ClientApplication.adminServer.port == 0)
			{
				Logger.LogErrorFormat("[登录] 登录地址非法", new object[0]);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			WaitServerConnected conAdminServer = new WaitServerConnected(ServerType.ADMIN_SERVER, ClientApplication.adminServer.ip, ClientApplication.adminServer.port, 0U, 4f, 3, 1f);
			yield return conAdminServer;
			if (conAdminServer.GetResult() != WaitServerConnected.eResult.Success)
			{
				Logger.LogErrorFormat("[登录] 登录服务器连接失败", new object[0]);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFailWithServerConnect, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			AdminLoginVerifyReq req = new AdminLoginVerifyReq();
			AdminLoginVerifyRet res = new AdminLoginVerifyRet();
			MessageEvents message = new MessageEvents();
			byte[] tableBytes = new byte[0];
			string dataPath = "AssetBundles/data_table.pck";
			dataPath = "AssetBundles/data_table_fb.pck";
			string persistentDataPath = Path.Combine(Application.persistentDataPath, dataPath);
			string path = string.Empty;
			path = "jar:file://" + Application.dataPath + "!/assets/" + dataPath;
			Debug.LogFormat("table-data-path {0}", new object[]
			{
				path
			});
			if (File.Exists(persistentDataPath))
			{
				tableBytes = File.ReadAllBytes(persistentDataPath);
			}
			else
			{
				WWW www = new WWW(path);
				yield return www;
				if (www.isDone)
				{
					tableBytes = www.bytes;
				}
			}
			Debug.LogFormat("table-data len:{0}", new object[]
			{
				tableBytes.Length
			});
			byte[] skillBytes = new byte[0];
			string dataPath2 = "AssetBundles/data_skilldata.pck";
			string persistentDataPath2 = Path.Combine(Application.persistentDataPath, dataPath2);
			string path2 = string.Empty;
			path2 = "jar:file://" + Application.dataPath + "!/assets/" + dataPath2;
			Debug.LogFormat("skill-data path {0}", new object[]
			{
				path2
			});
			if (File.Exists(persistentDataPath2))
			{
				skillBytes = File.ReadAllBytes(persistentDataPath2);
			}
			else
			{
				WWW www2 = new WWW(path2);
				yield return www2;
				if (www2.isDone)
				{
					skillBytes = www2.bytes;
				}
			}
			Debug.LogFormat("skill-data len:{0}", new object[]
			{
				skillBytes.Length
			});
			req.param = ClientApplication.playerinfo.param;
			req.hashValue = ClientApplication.playerinfo.hashValue;
			req.source1 = "a";
			req.source2 = "b";
			req.version = Singleton<VersionManager>.instance.ServerVersion();
			string fileMd5Str = DungeonUtility.GetMD5Str(tableBytes).ToLower() + DungeonUtility.GetMD5Str(skillBytes).ToLower() + req.param;
			Debug.LogFormat("[登录] param {0}", new object[]
			{
				req.param
			});
			req.tableMd5 = DungeonUtility.GetMD5(fileMd5Str);
			yield return MessageUtility.Wait<AdminLoginVerifyReq, AdminLoginVerifyRet>(ServerType.ADMIN_SERVER, message, req, res, true, 20f);
			if (!message.IsAllMessageReceived())
			{
				Logger.LogErrorFormat("[登录] 登录服务器消息超时", new object[0]);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFailWithServerConnect, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			if (res.result != 0U)
			{
				if (res.errMsg != null && res.errMsg.Length > 0)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(res.errMsg, null, string.Empty, false);
				}
				else if (res.result == 100007U)
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(ClientConfig.AppPackageMessageLoginFailed, ClientConfig.AppPackageButTextRetryLogin, ClientConfig.AppPackageButTextOpenURL, delegate()
					{
						Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemVersion>(null, null, false);
						AppPackageFetcher.SkipFetchAgain(true);
					}, delegate()
					{
						ClientSystemLoginUtility.mFetchAppPackageProcess = MonoSingleton<GameFrameWork>.instance.StartCoroutine(ClientSystemLoginUtility._OpenAppPackageUrl());
						AppPackageFetcher.SkipFetchAgain(true);
					}, FrameLayer.High);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
				}
				Logger.LogErrorFormat("[登录] 登录服务器消息结果出错 {0}", new object[]
				{
					res.result
				});
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			ClientApplication.playerinfo.accid = res.accid;
			ClientApplication.gateServer.ip = res.addr.ip;
			ClientApplication.gateServer.port = res.addr.port;
			ClientApplication.adminServer.dirSig = res.dirSig;
			DataManager<MobileBindManager>.GetInstance().BindMobileRoleId = res.phoneBindRoleId;
			bool isBind = Singleton<PluginManager>.instance.BindOtherNameForServicePush("android_" + res.accid);
			ClientApplication.isEncryptProtocol = (res.isEncryptProtocol != 0);
			ClientApplication.replayServer = res.replayAgentAddr;
			ClientApplication.channelRankListServer = res.activityYearSortListUrl;
			ClientApplication.operateAdsServer = res.webActivityUrl;
			ClientApplication.commentServerAddr = res.commentServerAddr;
			ClientApplication.redPackRankServerPath = res.redPacketRankUrl;
			ClientApplication.convertAccountInfoUrl = res.convertUrl;
			ClientApplication.reportPlayerUrl = res.reportUrl;
			ClientApplication.questionnaireUrl = res.writeQuestionnaireUrl;
			if (ClientApplication.playerinfo != null)
			{
				ClientApplication.playerinfo.serverID = res.serverId;
			}
			Singleton<PluginManager>.GetInstance().InitVoiceChatSDK(res.voiceFlag);
			WaitServerConnected conGateServer = new WaitServerConnected(ServerType.GATE_SERVER, ClientApplication.gateServer.ip, ClientApplication.gateServer.port, ClientApplication.playerinfo.accid, 4f, 3, 1f);
			yield return conGateServer;
			if (conGateServer.GetResult() != WaitServerConnected.eResult.Success)
			{
				Logger.LogErrorFormat("[登录] 连接Gate服务器消息结果出错 {0}", new object[]
				{
					conGateServer.GetResult()
				});
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			GateClientLoginReq req2 = new GateClientLoginReq();
			GateClientLoginRet res2 = new GateClientLoginRet();
			MessageEvents msg = new MessageEvents();
			req2.accid = ClientApplication.playerinfo.accid;
			req2.hashValue = ClientApplication.playerinfo.hashValue;
			req2.password = ClientApplication.playerinfo.password;
			req2.password2 = ClientApplication.playerinfo.password2;
			req2.cpsaccount = ClientApplication.playerinfo.cpsaccount;
			if (req2.cpsaccount.Length > 0)
			{
				Debugger.LogWarning("GATEREG:" + req2.cpsaccount);
			}
			yield return MessageUtility.Wait<GateClientLoginReq, GateClientLoginRet>(ServerType.GATE_SERVER, msg, req2, res2, true, 20f);
			if (!msg.IsAllMessageReceived())
			{
				Logger.LogErrorFormat("[登录] 连接Gate服务器消息超时", new object[0]);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			ClientApplication.serverStartTime = res2.serverStartTime;
			ClientApplication.veteranReturn = (uint)res2.notifyVeteranReturn;
			if (ClientApplication.veteranReturn == 1U && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SelectRoleFrame>(null) && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OldPlayerFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<OldPlayerFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (res2.result != 0U)
			{
				if (res2.result == 100010U)
				{
					if (res2.waitPlayerNum > 0U)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginQueueWait, res2.waitPlayerNum, null, null, null);
					}
					else
					{
						Logger.LogErrorFormat("[登录] WaitQueue服务 等待人数为0 ", new object[0]);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
					}
				}
				else
				{
					Logger.LogErrorFormat("[登录] Gate消息 错误返回{0}", new object[]
					{
						res2.result
					});
					if (res2.result == 9988001U)
					{
						SystemNotifyManager.SystemNotify(8001, "邀请码错误");
					}
					else if (res2.result == 100004U)
					{
						if (ClientApplication.m_bReg)
						{
							SystemNotifyManager.SystemNotify(8001, "账号已被注册");
						}
						else
						{
							SystemNotifyManager.SystemNotify(8001, "密码输入错误");
						}
					}
					else
					{
						SystemNotifyManager.SystemNotify((int)res2.result, string.Empty);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginFail, null, null, null, null);
				}
				ClientSystemLoginUtility.mIsLogin = false;
				yield break;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerLoginSuccess, null, null, null, null);
			ClientSystemLoginUtility.mIsLogin = false;
			DataManager<SecurityLockDataManager>.GetInstance().InitiallizeSystem();
			yield break;
		}

		// Token: 0x0600A9C2 RID: 43458 RVA: 0x00240348 File Offset: 0x0023E748
		private static IEnumerator _OpenAppPackageUrl()
		{
			yield return AppPackageFetcher.FetchFullAppPackage();
			AppPackageFetcher.OpenAppPackageURL();
			yield break;
		}

		// Token: 0x04005EF2 RID: 24306
		private static Coroutine mLoginProcess;

		// Token: 0x04005EF3 RID: 24307
		private static Coroutine mFetchAppPackageProcess;

		// Token: 0x04005EF4 RID: 24308
		private static string req_param;

		// Token: 0x04005EF5 RID: 24309
		private static string req_hashvalue;

		// Token: 0x04005EF6 RID: 24310
		private static string req_tablemd5;

		// Token: 0x04005EF7 RID: 24311
		private static string req_skillmd5;

		// Token: 0x04005EF8 RID: 24312
		private static string req_sv;

		// Token: 0x04005EF9 RID: 24313
		private static bool mIsLogin;
	}
}
