using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LitJson;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011F1 RID: 4593
	public class BaseWebViewManager : DataManager<BaseWebViewManager>
	{
		// Token: 0x0600B11C RID: 45340 RVA: 0x00271C34 File Offset: 0x00270034
		public override void Initialize()
		{
			this._InitReportLocalData();
		}

		// Token: 0x0600B11D RID: 45341 RVA: 0x00271C3C File Offset: 0x0027003C
		public override void Clear()
		{
			if (this.waitToShowScreenShotTips != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToShowScreenShotTips);
				this.waitToShowScreenShotTips = null;
			}
		}

		// Token: 0x0600B11E RID: 45342 RVA: 0x00271C60 File Offset: 0x00270060
		private void _OpenBaseWebViewFrame(BaseWebViewParams param)
		{
			if (param == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BaseWebViewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BaseWebViewFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BaseWebViewFrame>(FrameLayer.TopMoreMost, param, string.Empty);
		}

		// Token: 0x0600B11F RID: 45343 RVA: 0x00271C97 File Offset: 0x00270097
		private void _CloseBaseWebViewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BaseWebViewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BaseWebViewFrame>(null, false);
			}
		}

		// Token: 0x0600B120 RID: 45344 RVA: 0x00271CB5 File Offset: 0x002700B5
		public bool CanUnlockQuestionnaire()
		{
			return false;
		}

		// Token: 0x0600B121 RID: 45345 RVA: 0x00271CB8 File Offset: 0x002700B8
		public bool CanOpenQuestionnaire()
		{
			return false;
		}

		// Token: 0x0600B122 RID: 45346 RVA: 0x00271CBB File Offset: 0x002700BB
		public string GetQuestionnaireUrl()
		{
			return ClientApplication.questionnaireUrl;
		}

		// Token: 0x0600B123 RID: 45347 RVA: 0x00271CC4 File Offset: 0x002700C4
		public bool IsReportFuncOpen()
		{
			return !string.IsNullOrEmpty(ClientApplication.reportPlayerUrl) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.ReportingFunction) && Singleton<PluginManager>.instance.IsSDKEnableSystemVersion(SDKInterface.FuncSDKType.FSDK_UniWebView);
		}

		// Token: 0x0600B124 RID: 45348 RVA: 0x00271D08 File Offset: 0x00270108
		public void TryOpenReportFrame(RelationData rData)
		{
			if (!this._CheckEnableToReport())
			{
				return;
			}
			if (rData == null)
			{
				return;
			}
			InformantInfo informantInfoByReleationData = this.GetInformantInfoByReleationData(rData);
			if (informantInfoByReleationData != null)
			{
				this.TryOpenReportFrame(informantInfoByReleationData);
			}
		}

		// Token: 0x0600B125 RID: 45349 RVA: 0x00271D40 File Offset: 0x00270140
		public void TryOpenReportFrame(InformantInfo info)
		{
			if (!this._CheckEnableToReport())
			{
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(82, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			string text = this._GetReportFullUrl(info);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			this._OpenBaseWebViewFrame(new BaseWebViewParams
			{
				type = BaseWebViewType.OnlineReport,
				fullUrl = text,
				uniWebViewMsgs = new List<BaseWebViewMsg>(),
				uniWebViewMsgs = 
				{
					new BaseWebViewMsg
					{
						scheme = "uniwebview",
						path = "close",
						onReceiveWebViewMsg = new Action<Dictionary<string, string>, UniWebViewUtility>(this._OnWebViewMsgCloseFrame)
					},
					new BaseWebViewMsg
					{
						scheme = "uniwebview",
						path = "reportsuccess",
						onReceiveWebViewMsg = new Action<Dictionary<string, string>, UniWebViewUtility>(this._OnWebViewMsgReportSucc)
					}
				}
			});
		}

		// Token: 0x0600B126 RID: 45350 RVA: 0x00271E60 File Offset: 0x00270260
		public string GetJobNameByJobId(int jobId)
		{
			string result = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Name;
			}
			return result;
		}

		// Token: 0x0600B127 RID: 45351 RVA: 0x00271E98 File Offset: 0x00270298
		public InformantInfo GetInformantInfoByReleationData(RelationData rData)
		{
			if (rData == null)
			{
				return new InformantInfo();
			}
			return new InformantInfo
			{
				roleId = rData.uid.ToString(),
				roleName = rData.name,
				roleLevel = rData.level.ToString(),
				vipLevel = rData.vipLv.ToString(),
				jobId = rData.occu.ToString(),
				jobName = this.GetJobNameByJobId((int)rData.occu)
			};
		}

		// Token: 0x0600B128 RID: 45352 RVA: 0x00271F34 File Offset: 0x00270334
		private ReporterInfo _GetReportPlayerInfo()
		{
			ReporterInfo reporterInfo = new ReporterInfo();
			reporterInfo.roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
			reporterInfo.roleName = DataManager<PlayerBaseData>.GetInstance().Name;
			reporterInfo.roleLevel = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			reporterInfo.vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			reporterInfo.jobId = jobTableID.ToString();
			reporterInfo.jobName = this.GetJobNameByJobId(jobTableID);
			if (ClientApplication.playerinfo != null)
			{
				reporterInfo.accId = ClientApplication.playerinfo.accid.ToString();
				reporterInfo.serverId = ClientApplication.playerinfo.serverID.ToString();
			}
			reporterInfo.serverName = ClientApplication.adminServer.name;
			reporterInfo.platformName = SDKInterface.instance.GetPlatformNameBySelect();
			return reporterInfo;
		}

		// Token: 0x0600B129 RID: 45353 RVA: 0x0027203C File Offset: 0x0027043C
		private string _GetReportFullUrl(InformantInfo info)
		{
			string text = this._FormatReportUrl(info);
			if (string.IsNullOrEmpty(ClientApplication.reportPlayerUrl) || string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			return string.Format("{0}?{1}", ClientApplication.reportPlayerUrl, text);
		}

		// Token: 0x0600B12A RID: 45354 RVA: 0x00272084 File Offset: 0x00270484
		private string _FormatReportUrl(InformantInfo info)
		{
			if (info == null)
			{
				return string.Empty;
			}
			ReporterInfo reporterInfo = this._GetReportPlayerInfo();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("platform={0}&zoneid={1}&server={2}&", reporterInfo.platformName, reporterInfo.serverId, reporterInfo.serverName);
			stringBuilder.AppendFormat("target_role_id={0}&target_role_name={1}&target_vip={2}&target_occu={3}&target_accid={4}&target_occu_name={5}&target_role_level={6}&", new object[]
			{
				info.roleId,
				info.roleName,
				info.vipLevel,
				info.jobId,
				"0",
				info.jobName,
				info.roleLevel
			});
			stringBuilder.AppendFormat("reporter_accid={0}&reporter_role_id={1}&reporter_role_name={2}&reporter_occu={3}&reporter_vip={4}", new object[]
			{
				reporterInfo.accId,
				reporterInfo.roleId,
				reporterInfo.roleName,
				reporterInfo.jobId,
				reporterInfo.vipLevel
			});
			return stringBuilder.ToString();
		}

		// Token: 0x0600B12B RID: 45355 RVA: 0x00272160 File Offset: 0x00270560
		private void _NotifyReportSucc()
		{
			SceneReportNotify cmd = new SceneReportNotify();
			NetManager.Instance().SendCommand<SceneReportNotify>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B12C RID: 45356 RVA: 0x00272180 File Offset: 0x00270580
		private void _OnWebViewMsgReportSucc(Dictionary<string, string> msgArgs, UniWebViewUtility uniWebViewUti)
		{
			this._NotifyReportSucc();
		}

		// Token: 0x0600B12D RID: 45357 RVA: 0x00272188 File Offset: 0x00270588
		private void _InitReportLocalData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(628, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mReportConsumeActivityValue = (float)tableItem.Value;
			}
		}

		// Token: 0x0600B12E RID: 45358 RVA: 0x002721C2 File Offset: 0x002705C2
		private bool _CheckEnableToReport()
		{
			if ((float)DataManager<PlayerBaseData>.GetInstance().ActivityValue < this.mReportConsumeActivityValue)
			{
				SystemNotifyManager.SystemNotify(100016, new object[]
				{
					this.mReportConsumeActivityValue
				});
				return false;
			}
			return true;
		}

		// Token: 0x0600B12F RID: 45359 RVA: 0x002721FC File Offset: 0x002705FC
		public bool IsConvertAccountFuncOpen()
		{
			return !string.IsNullOrEmpty(ClientApplication.convertAccountInfoUrl) && Singleton<PluginManager>.instance.IsSDKEnableSystemVersion(SDKInterface.FuncSDKType.FSDK_UniWebView);
		}

		// Token: 0x0600B130 RID: 45360 RVA: 0x00272230 File Offset: 0x00270630
		public void ShowConvertAccountTips()
		{
			if (!this.IsConvertAccountFuncOpen())
			{
				return;
			}
			SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("zymg_convert_account_tips"), TR.Value("zymg_convert_account_tips_cancel_desc"), string.Empty, null, delegate()
			{
				this.ReqGateConvertAccount();
			}, 5f, false, new CommonMsgBoxCancelOKParams
			{
				closeFrameOnCancelBtnCDEnd = false,
				showCancelBtnGrayOnCDEnd = true
			});
		}

		// Token: 0x0600B131 RID: 45361 RVA: 0x00272290 File Offset: 0x00270690
		public void ReqGateConvertAccount()
		{
			if (!this.IsConvertAccountFuncOpen())
			{
				return;
			}
			GateConvertAccountReq cmd = new GateConvertAccountReq();
			NetManager.Instance().SendCommand<GateConvertAccountReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<GateConvertAccountRes>(new Action<GateConvertAccountRes>(this._WaitGateConvetAccountRes), true, 15f, null);
		}

		// Token: 0x0600B132 RID: 45362 RVA: 0x002722DC File Offset: 0x002706DC
		private void _WaitGateConvetAccountRes(GateConvertAccountRes msgRet)
		{
			if (msgRet == null)
			{
				return;
			}
			ConvertAccountInfo convertAccountInfo = new ConvertAccountInfo();
			convertAccountInfo.account = msgRet.account;
			convertAccountInfo.password = msgRet.passwd;
			convertAccountInfo.channelName = SDKInterface.instance.GetPlatformNameBySelect();
			if (ClientApplication.playerinfo != null)
			{
				if (string.IsNullOrEmpty(ClientApplication.playerinfo.openuid))
				{
					convertAccountInfo.originalOpenUid = ClientApplication.playerinfo.accid.ToString();
				}
				else
				{
					convertAccountInfo.originalOpenUid = ClientApplication.playerinfo.openuid;
				}
			}
			convertAccountInfo.needScreenShot = ((msgRet.screenShot != 1) ? "1" : "0");
			if (msgRet.saveFile == 1)
			{
				this._SaveConvertAccInfoToLocal(convertAccountInfo);
			}
			string text = this._GetConvertAccountFullUrl(convertAccountInfo);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			this._OpenBaseWebViewFrame(new BaseWebViewParams
			{
				type = BaseWebViewType.ConvertAccountInfo,
				fullUrl = text,
				uniWebViewMsgs = new List<BaseWebViewMsg>(),
				uniWebViewMsgs = 
				{
					new BaseWebViewMsg
					{
						scheme = "uniwebview",
						path = "screenshot",
						onReceiveWebViewMsg = new Action<Dictionary<string, string>, UniWebViewUtility>(this._OnWebViewMsgScreenShot)
					},
					new BaseWebViewMsg
					{
						scheme = "uniwebview",
						path = "close",
						onReceiveWebViewMsg = new Action<Dictionary<string, string>, UniWebViewUtility>(this._OnWebViewMsgCloseFrame)
					}
				}
			});
		}

		// Token: 0x0600B133 RID: 45363 RVA: 0x0027245C File Offset: 0x0027085C
		private void _SaveConvertAccInfoToLocal(ConvertAccountInfo info)
		{
			if (info == null)
			{
				return;
			}
			string fileName = this._GetConvertLocalFileName(info.channelName);
			string text = string.Empty;
			try
			{
				text = Singleton<PluginManager>.GetInstance().ReadDoc(TR.Value("zymg_convert_account_filerootpath"), fileName);
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[BaseWebViewManager] -_SaveConvertAccInfoToLocal, ReadDoc failed : {0}", new object[]
				{
					ex.ToString()
				});
			}
			LocalConvertAccInfos localConvertAccInfos = null;
			bool flag = false;
			try
			{
				if (!string.IsNullOrEmpty(text))
				{
					localConvertAccInfos = JsonMapper.ToObject<LocalConvertAccInfos>(text);
				}
			}
			catch (Exception ex2)
			{
				Debug.LogErrorFormat("[BaseWebViewManager] -_SaveConvertAccInfoToLocal, LitJson toObject failed : {0}", new object[]
				{
					ex2.ToString()
				});
			}
			if (localConvertAccInfos != null && localConvertAccInfos.convertAccountInfos != null)
			{
				for (int i = 0; i < localConvertAccInfos.convertAccountInfos.Count; i++)
				{
					ConvertAccountInfo convertAccountInfo = localConvertAccInfos.convertAccountInfos[i];
					if (convertAccountInfo != null)
					{
						if (convertAccountInfo.originalOpenUid == info.originalOpenUid && convertAccountInfo.channelName == info.channelName)
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				return;
			}
			if (localConvertAccInfos == null)
			{
				localConvertAccInfos = new LocalConvertAccInfos();
			}
			localConvertAccInfos.convertAccountInfos.Add(info);
			string text2 = string.Empty;
			try
			{
				text2 = JsonMapper.ToJson(localConvertAccInfos);
			}
			catch (Exception ex3)
			{
				Debug.LogErrorFormat("[BaseWebViewManager] -_SaveConvertAccInfoToLocal, LitJson toJson failed : {0}", new object[]
				{
					ex3.ToString()
				});
			}
			if (!string.IsNullOrEmpty(text2))
			{
				try
				{
					Singleton<PluginManager>.GetInstance().SaveDoc(text2, TR.Value("zymg_convert_account_filerootpath"), fileName, false);
				}
				catch (Exception ex4)
				{
					Debug.LogErrorFormat("[BaseWebViewManager] -_SaveConvertAccInfoToLocal, SaveDoc failed : {0}", new object[]
					{
						ex4.ToString()
					});
				}
			}
		}

		// Token: 0x0600B134 RID: 45364 RVA: 0x00272650 File Offset: 0x00270A50
		private string _GetConvertLocalFileName(string channelName)
		{
			return string.Format("{0}_{1}.{2}", "convertInfo", channelName, "conf");
		}

		// Token: 0x0600B135 RID: 45365 RVA: 0x00272668 File Offset: 0x00270A68
		private void _OnWebViewMsgScreenShot(Dictionary<string, string> msgArgs, UniWebViewUtility uniWebViewUti)
		{
			TakePhotoModeFrame.MobileScreenShoot(null, 0f, 0f, 1f, 1f);
			if (this.waitToShowScreenShotTips != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToShowScreenShotTips);
			}
			this.waitToShowScreenShotTips = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToShowScreenShotTips(uniWebViewUti));
		}

		// Token: 0x0600B136 RID: 45366 RVA: 0x002726C1 File Offset: 0x00270AC1
		private void _OnWebViewMsgCloseFrame(Dictionary<string, string> msgArgs, UniWebViewUtility uniWebViewUti)
		{
			this._CloseBaseWebViewFrame();
		}

		// Token: 0x0600B137 RID: 45367 RVA: 0x002726CC File Offset: 0x00270ACC
		private IEnumerator _WaitToShowScreenShotTips(UniWebViewUtility webViewUti)
		{
			yield return Yielders.GetWaitForSeconds(1f);
			if (webViewUti != null)
			{
				webViewUti.ExcuteJS("screen();", null);
			}
			yield break;
		}

		// Token: 0x0600B138 RID: 45368 RVA: 0x002726E8 File Offset: 0x00270AE8
		private string _GetConvertAccountFullUrl(ConvertAccountInfo info)
		{
			string text = this._FormatConvertAccountUrl(info);
			if (string.IsNullOrEmpty(ClientApplication.convertAccountInfoUrl) || string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			return string.Format("{0}?{1}", ClientApplication.convertAccountInfoUrl, text);
		}

		// Token: 0x0600B139 RID: 45369 RVA: 0x00272730 File Offset: 0x00270B30
		private string _FormatConvertAccountUrl(ConvertAccountInfo info)
		{
			if (info == null)
			{
				return string.Empty;
			}
			return string.Format("account={0}&password={1}&screen={2}&channel={3}", new object[]
			{
				info.account,
				info.password,
				info.needScreenShot,
				info.channelName
			});
		}

		// Token: 0x040062EE RID: 25326
		private Coroutine waitToShowScreenShotTips;

		// Token: 0x040062EF RID: 25327
		private float mReportConsumeActivityValue;

		// Token: 0x040062F0 RID: 25328
		public const string convertAccInfoFilePrefix = "convertInfo";

		// Token: 0x040062F1 RID: 25329
		public const string convertAccInfoFileExtension = "conf";
	}
}
