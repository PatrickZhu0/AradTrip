using System;
using System.Collections;
using System.Diagnostics;
using ActivityLimitTime;
using GameClient;
using ProtoTable;
using UnityEngine;

namespace MobileBind
{
	// Token: 0x020017D9 RID: 6105
	public class MobileBindManager : DataManager<MobileBindManager>
	{
		// Token: 0x17001CEB RID: 7403
		// (get) Token: 0x0600F08C RID: 61580 RVA: 0x0040C368 File Offset: 0x0040A768
		public ActivityLimitTimeData BindPhoneActData
		{
			get
			{
				if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
				{
					return DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.BindPhoneOtherData;
				}
				return null;
			}
		}

		// Token: 0x17001CEC RID: 7404
		// (get) Token: 0x0600F08D RID: 61581 RVA: 0x0040C38A File Offset: 0x0040A78A
		public bool SendPhoneNumSucc
		{
			get
			{
				return this.sendPhoneNumSucc;
			}
		}

		// Token: 0x17001CED RID: 7405
		// (get) Token: 0x0600F08E RID: 61582 RVA: 0x0040C392 File Offset: 0x0040A792
		public bool SendPhoneVerifySucc
		{
			get
			{
				return this.sendPhoneVerifySucc;
			}
		}

		// Token: 0x17001CEE RID: 7406
		// (get) Token: 0x0600F08F RID: 61583 RVA: 0x0040C39A File Offset: 0x0040A79A
		// (set) Token: 0x0600F090 RID: 61584 RVA: 0x0040C3A2 File Offset: 0x0040A7A2
		public bool HasSendVerify
		{
			get
			{
				return this.hasSendVerify;
			}
			set
			{
				this.hasSendVerify = value;
			}
		}

		// Token: 0x0600F091 RID: 61585 RVA: 0x0040C3AB File Offset: 0x0040A7AB
		public override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x0600F092 RID: 61586 RVA: 0x0040C3B3 File Offset: 0x0040A7B3
		public override void Initialize()
		{
			this.Clear();
		}

		// Token: 0x0600F093 RID: 61587 RVA: 0x0040C3BC File Offset: 0x0040A7BC
		public override void Clear()
		{
			if (this.sendPhoneNumCor != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.sendPhoneNumCor);
				this.sendPhoneNumCor = null;
			}
			if (this.sendPhoneVerifyCor != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.sendPhoneVerifyCor);
				this.sendPhoneVerifyCor = null;
			}
			this.ResetSendParams();
		}

		// Token: 0x0600F094 RID: 61588 RVA: 0x0040C413 File Offset: 0x0040A813
		private void ResetSendParams()
		{
			this.sendPhoneNumRetCode = 0;
			this.sendPhoneVerifyRetCode = 0;
			this.sendPhoneNumSucc = false;
			this.sendPhoneVerifySucc = false;
		}

		// Token: 0x0600F095 RID: 61589 RVA: 0x0040C434 File Offset: 0x0040A834
		public void SendPhoneNumber(string phoneNum)
		{
			this.sendPhoneNumRetCode = 0;
			if (this.sendPhoneNumCor != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.sendPhoneNumCor);
				this.sendPhoneNumCor = null;
			}
			this.sendPhoneNumCor = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._SendPhoneNum(phoneNum));
		}

		// Token: 0x0600F096 RID: 61590 RVA: 0x0040C484 File Offset: 0x0040A884
		public void SendNumberVerify(string phoneNum, string verifyNum = "")
		{
			this.sendPhoneVerifyRetCode = 0;
			if (this.sendPhoneVerifyCor != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.sendPhoneVerifyCor);
				this.sendPhoneVerifyCor = null;
			}
			this.sendPhoneVerifyCor = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._SendPhoneVerify(phoneNum, verifyNum));
		}

		// Token: 0x0600F097 RID: 61591 RVA: 0x0040C4D4 File Offset: 0x0040A8D4
		private IEnumerator _SendPhoneNum(string phoneNum)
		{
			string url = string.Format("http://{0}/bind?platform={1}&openid={2}&accid={3}&phonenumber={4}", new object[]
			{
				Global.VERIFY_BIND_PHONE_ADDRESS,
				Global.channelName,
				ClientApplication.playerinfo.openuid,
				ClientApplication.playerinfo.accid,
				phoneNum
			});
			if (string.IsNullOrEmpty(url))
			{
				yield break;
			}
			BaseWaitHttpRequest bwhr = new BaseWaitHttpRequest();
			bwhr.url = url;
			yield return bwhr;
			if (bwhr.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				string resultString = bwhr.GetResultString();
				if (string.IsNullOrEmpty(resultString))
				{
					this.sendPhoneNumRetCode = -1;
				}
				else
				{
					this.sendPhoneNumRetCode = int.Parse(resultString);
				}
			}
			if (this.sendPhoneNumRetCode != 0)
			{
				this.sendPhoneNumSucc = false;
				yield break;
			}
			this.sendPhoneNumSucc = true;
			yield break;
		}

		// Token: 0x0600F098 RID: 61592 RVA: 0x0040C4F8 File Offset: 0x0040A8F8
		private IEnumerator _SendPhoneVerify(string mobilePhone, string verifyCode = "")
		{
			this.hasSendVerify = true;
			string url = string.Format("http://{0}/verify?platform={1}&openid={2}&accid={3}&roleid={4}&code={5}&sid={6}&phonenumber={7}", new object[]
			{
				Global.VERIFY_BIND_PHONE_ADDRESS,
				Global.channelName,
				ClientApplication.playerinfo.openuid,
				ClientApplication.playerinfo.accid,
				DataManager<PlayerBaseData>.GetInstance().RoleID,
				verifyCode,
				ClientApplication.playerinfo.serverID + string.Empty,
				mobilePhone
			});
			if (string.IsNullOrEmpty(url))
			{
				yield break;
			}
			BaseWaitHttpRequest bwhr = new BaseWaitHttpRequest();
			bwhr.url = url;
			yield return bwhr;
			if (bwhr.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				string resultString = bwhr.GetResultString();
				if (string.IsNullOrEmpty(resultString))
				{
					this.sendPhoneVerifyRetCode = -1;
				}
				else
				{
					this.sendPhoneVerifyRetCode = int.Parse(resultString);
				}
			}
			if (this.sendPhoneVerifyRetCode != 0)
			{
				this.sendPhoneVerifySucc = false;
				this.SystemNotifyText((MobileBindReturnCode)this.sendPhoneVerifyRetCode);
				yield break;
			}
			this.sendPhoneVerifySucc = true;
			yield break;
		}

		// Token: 0x0600F099 RID: 61593 RVA: 0x0040C524 File Offset: 0x0040A924
		private void SystemNotifyText(MobileBindReturnCode code)
		{
			switch (code)
			{
			case MobileBindReturnCode.DBError:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，数据库错误", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.CD:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证中", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.InvalidAccount:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，帐号无效", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.RepeatBind:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，重复绑定", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.InvalidVerifyCode:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，验证码无效", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.InvalidServerId:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，服务器ID错误", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.NoVerifyCode:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，无验证码", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.ServerError:
				SystemNotifyManager.SysNotifyTextAnimation("手机号验证，服务器错误", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.PlayerOffine:
				SystemNotifyManager.SysNotifyTextAnimation("角色离线了", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case MobileBindReturnCode.InvalidPhoneNum:
				SystemNotifyManager.SysNotifyTextAnimation("手机号错误，请检查", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600F09A RID: 61594 RVA: 0x0040C608 File Offset: 0x0040AA08
		// (remove) Token: 0x0600F09B RID: 61595 RVA: 0x0040C640 File Offset: 0x0040AA40
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action VerifySuccListener;

		// Token: 0x0600F09C RID: 61596 RVA: 0x0040C676 File Offset: 0x0040AA76
		public void AddVerifySuccHandler(Action handler)
		{
			this.RemoveAllVerifySuccHandler();
			if (this.VerifySuccListener == null)
			{
				this.VerifySuccListener += handler;
			}
		}

		// Token: 0x0600F09D RID: 61597 RVA: 0x0040C690 File Offset: 0x0040AA90
		public void RemoveAllVerifySuccHandler()
		{
			if (this.VerifySuccListener != null)
			{
				Delegate[] invocationList = this.VerifySuccListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.VerifySuccListener -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600F09E RID: 61598 RVA: 0x0040C6E0 File Offset: 0x0040AAE0
		// (remove) Token: 0x0600F09F RID: 61599 RVA: 0x0040C718 File Offset: 0x0040AB18
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action SendPhoneNumSuccListener;

		// Token: 0x0600F0A0 RID: 61600 RVA: 0x0040C74E File Offset: 0x0040AB4E
		public void AddSendPhoneNumSuccHandler(Action handler)
		{
			this.RemoveAllSendPhoneNumSuccHandler();
			if (this.SendPhoneNumSuccListener == null)
			{
				this.SendPhoneNumSuccListener += handler;
			}
		}

		// Token: 0x0600F0A1 RID: 61601 RVA: 0x0040C768 File Offset: 0x0040AB68
		public void RemoveAllSendPhoneNumSuccHandler()
		{
			if (this.SendPhoneNumSuccListener != null)
			{
				Delegate[] invocationList = this.SendPhoneNumSuccListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.SendPhoneNumSuccListener -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600F0A2 RID: 61602 RVA: 0x0040C7B8 File Offset: 0x0040ABB8
		// (remove) Token: 0x0600F0A3 RID: 61603 RVA: 0x0040C7F0 File Offset: 0x0040ABF0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<string> SDKBindPhoneNumSuccListener;

		// Token: 0x0600F0A4 RID: 61604 RVA: 0x0040C826 File Offset: 0x0040AC26
		public void AddSDKBindPhoneNumSuccHandler(Action<string> handler)
		{
			this.RemoveAllSDKBindPhoneNumSuccHandler();
			if (this.SDKBindPhoneNumSuccListener == null)
			{
				this.SDKBindPhoneNumSuccListener += handler;
			}
		}

		// Token: 0x0600F0A5 RID: 61605 RVA: 0x0040C840 File Offset: 0x0040AC40
		public void RemoveAllSDKBindPhoneNumSuccHandler()
		{
			if (this.SDKBindPhoneNumSuccListener != null)
			{
				Delegate[] invocationList = this.SDKBindPhoneNumSuccListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.SDKBindPhoneNumSuccListener -= (invocationList[i] as Action<string>);
					}
				}
			}
		}

		// Token: 0x17001CEF RID: 7407
		// (get) Token: 0x0600F0A6 RID: 61606 RVA: 0x0040C88E File Offset: 0x0040AC8E
		// (set) Token: 0x0600F0A7 RID: 61607 RVA: 0x0040C896 File Offset: 0x0040AC96
		public ulong BindMobileRoleId
		{
			get
			{
				return this.bindMobileRoleId;
			}
			set
			{
				this.bindMobileRoleId = value;
				this.hasRoleBindPhoneAwardActive = false;
			}
		}

		// Token: 0x17001CF0 RID: 7408
		// (get) Token: 0x0600F0A8 RID: 61608 RVA: 0x0040C8A6 File Offset: 0x0040ACA6
		// (set) Token: 0x0600F0A9 RID: 61609 RVA: 0x0040C8AE File Offset: 0x0040ACAE
		public bool hasRoleBindPhoneAwardActive { get; set; }

		// Token: 0x0600F0AA RID: 61610 RVA: 0x0040C8B7 File Offset: 0x0040ACB7
		public void ToOpenMobileBind(bool open)
		{
			this.toOpenMobileBind = open;
		}

		// Token: 0x0600F0AB RID: 61611 RVA: 0x0040C8C0 File Offset: 0x0040ACC0
		public bool IsMobileBindFuncEnable()
		{
			return this.toOpenMobileBind && this.IsRoleLevelEnable() && SDKInterface.instance.NeedSDKBindPhoneOpen() && !this.IsBindMobileDataEmpty() && !this.IsBindPhoneActivityEnd() && (!this.HasBindPhone() || this.HasBindMobileAwardToReceive()) && (!this.hasRoleBindPhoneAwardActive || this.HasBindMobileAwardToReceive());
		}

		// Token: 0x0600F0AC RID: 61612 RVA: 0x0040C944 File Offset: 0x0040AD44
		public bool IsRoleLevelEnable()
		{
			int id = 16;
			int num = 8;
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.ValueA;
			}
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= num;
		}

		// Token: 0x0600F0AD RID: 61613 RVA: 0x0040C98C File Offset: 0x0040AD8C
		public bool HasBindPhone()
		{
			if (this.BindMobileRoleId > 0UL)
			{
				this.hasRoleBindPhoneAwardActive = true;
				return true;
			}
			return false;
		}

		// Token: 0x0600F0AE RID: 61614 RVA: 0x0040C9A8 File Offset: 0x0040ADA8
		public bool HasBindMobileAwardToReceive()
		{
			return this.BindPhoneActData != null && this.BindPhoneActData.activityDetailDataList != null && this.BindPhoneActData.activityDetailDataList.Count > 0 && this.BindPhoneActData.activityDetailDataList[0].ActivityDetailState == ActivityTaskState.Finished;
		}

		// Token: 0x0600F0AF RID: 61615 RVA: 0x0040CA10 File Offset: 0x0040AE10
		public bool IsBindPhoneActivityEnd()
		{
			return this.BindPhoneActData == null || this.BindPhoneActData.ActivityState == ActivityState.End;
		}

		// Token: 0x0600F0B0 RID: 61616 RVA: 0x0040CA34 File Offset: 0x0040AE34
		public bool IsBindMobileDataEmpty()
		{
			return this.BindPhoneActData == null || this.BindPhoneActData.activityDetailDataList == null || (this.BindPhoneActData.activityDetailDataList.Count > 0 && this.BindPhoneActData.activityDetailDataList[0].ActivityDetailState == ActivityTaskState.Over);
		}

		// Token: 0x0600F0B1 RID: 61617 RVA: 0x0040CA95 File Offset: 0x0040AE95
		public void SDKBindPhoneSucc(string bindPhoneNum)
		{
			if (this.SDKBindPhoneNumSuccListener != null)
			{
				this.SDKBindPhoneNumSuccListener(bindPhoneNum);
			}
		}

		// Token: 0x040093A6 RID: 37798
		private Coroutine sendPhoneNumCor;

		// Token: 0x040093A7 RID: 37799
		private Coroutine sendPhoneVerifyCor;

		// Token: 0x040093A8 RID: 37800
		private int sendPhoneNumRetCode = -1;

		// Token: 0x040093A9 RID: 37801
		private bool sendPhoneNumSucc;

		// Token: 0x040093AA RID: 37802
		private int sendPhoneVerifyRetCode = -1;

		// Token: 0x040093AB RID: 37803
		private bool sendPhoneVerifySucc;

		// Token: 0x040093AC RID: 37804
		private bool hasSendVerify;

		// Token: 0x040093B0 RID: 37808
		private bool toOpenMobileBind = true;

		// Token: 0x040093B1 RID: 37809
		private ulong bindMobileRoleId;
	}
}
