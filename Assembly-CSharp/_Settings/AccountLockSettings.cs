using System;
using System.Globalization;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A15 RID: 6677
	public class AccountLockSettings : SettingsBindUI
	{
		// Token: 0x06010653 RID: 67155 RVA: 0x0049BFA2 File Offset: 0x0049A3A2
		public AccountLockSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x06010654 RID: 67156 RVA: 0x0049BFB3 File Offset: 0x0049A3B3
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/accountLock";
		}

		// Token: 0x06010655 RID: 67157 RVA: 0x0049BFBC File Offset: 0x0049A3BC
		protected override void InitBind()
		{
			this.InitButtonBind(ref this.btnLock, "btnLock", delegate
			{
				SecurityLockData securityLockData = DataManager<SecurityLockDataManager>.GetInstance().GetSecurityLockData();
				if (Input.GetKeyDown(306))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountLock>(FrameLayer.Middle, null, string.Empty);
				}
				else if (securityLockData.isUseLock)
				{
					DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockOpReq(LockOpType.LT_LOCK, string.Empty);
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountLock>(FrameLayer.Middle, null, string.Empty);
				}
			});
			this.InitButtonBind(ref this.btnUnLock, "btnUnLock", delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountUnLock>(FrameLayer.Middle, null, string.Empty);
			});
			this.InitButtonBind(ref this.btnBind, "btnBind", delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountLockBindDevice>(FrameLayer.Middle, null, string.Empty);
			});
			this.InitButtonBind(ref this.btnUnBind, "btnUnBind", delegate
			{
				DataManager<SecurityLockDataManager>.GetInstance().SendWorldBindDeviceReq(false);
			});
			this.InitButtonBind(ref this.btnForceUnLock, "btnForceUnLock", delegate
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel("确认强制解锁后，账号会进入7*24小时的冻结期，冻结期结束后，安全锁密码将被删除并变为“未开启”状态。是否确认强制解锁？", delegate()
				{
					DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockOpReq(LockOpType.LT_FORCE_UNLOCK, string.Empty);
				}, null, 0f, false);
			});
			this.InitButtonBind(ref this.btnChangePwd, "btnChangePwd", delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountLockChangePwd>(FrameLayer.Middle, null, string.Empty);
			});
			this.InitButtonBind(ref this.btnCancelForceUnLock, "btnCancelForceUnLock", delegate
			{
				DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockOpReq(LockOpType.LT_CANCAL_APPLY, string.Empty);
			});
			this.goNotOpen = this.mBind.GetGameObject("NotOpen");
			this.goOpened = this.mBind.GetGameObject("Opened");
			this.goForceLock = this.mBind.GetGameObject("ForceUnLock");
			this.txtApply = this.mBind.GetCom<Text>("apply");
			this.txtApplyEnd = this.mBind.GetCom<Text>("applyEnd");
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshSecurityLockDataUI, new ClientEventSystem.UIEventHandler(this._OnRefeshUI));
		}

		// Token: 0x06010656 RID: 67158 RVA: 0x0049C194 File Offset: 0x0049A594
		protected override void UnInitBind()
		{
			this.UnInitButtonBind(ref this.btnLock, null);
			this.UnInitButtonBind(ref this.btnUnLock, null);
			this.UnInitButtonBind(ref this.btnBind, null);
			this.UnInitButtonBind(ref this.btnUnBind, null);
			this.UnInitButtonBind(ref this.btnForceUnLock, null);
			this.UnInitButtonBind(ref this.btnCancelForceUnLock, null);
			this.UnInitButtonBind(ref this.btnChangePwd, null);
			this.goNotOpen = null;
			this.goOpened = null;
			this.goForceLock = null;
			this.txtApply = null;
			this.txtApplyEnd = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshSecurityLockDataUI, new ClientEventSystem.UIEventHandler(this._OnRefeshUI));
		}

		// Token: 0x06010657 RID: 67159 RVA: 0x0049C23A File Offset: 0x0049A63A
		protected override void OnShowOut()
		{
			this.RefeshUI();
		}

		// Token: 0x06010658 RID: 67160 RVA: 0x0049C242 File Offset: 0x0049A642
		protected override void OnHideIn()
		{
		}

		// Token: 0x06010659 RID: 67161 RVA: 0x0049C244 File Offset: 0x0049A644
		private void InitButtonBind(ref Button btn, string name, UnityAction callback)
		{
			btn = this.mBind.GetCom<Button>(name);
			if (btn != null)
			{
				btn.onClick.RemoveAllListeners();
				btn.onClick.AddListener(callback);
			}
		}

		// Token: 0x0601065A RID: 67162 RVA: 0x0049C27A File Offset: 0x0049A67A
		private void UnInitButtonBind(ref Button btn, UnityAction callback = null)
		{
			if (btn != null)
			{
				btn.onClick.RemoveAllListeners();
				btn = null;
			}
		}

		// Token: 0x0601065B RID: 67163 RVA: 0x0049C298 File Offset: 0x0049A698
		private void SetShowType(AccountLockSettings.ShowType eType)
		{
			this.eShowType = eType;
		}

		// Token: 0x0601065C RID: 67164 RVA: 0x0049C2A4 File Offset: 0x0049A6A4
		private void RefeshUI()
		{
			SecurityLockData securityLockData = DataManager<SecurityLockDataManager>.GetInstance().GetSecurityLockData();
			if (securityLockData.lockState == SecurityLockState.SECURITY_STATE_UNLOCK)
			{
				this.SetShowType(AccountLockSettings.ShowType.NotOpen);
			}
			else if (securityLockData.lockState == SecurityLockState.SECURITY_STATE_LOCK)
			{
				this.SetShowType(AccountLockSettings.ShowType.Opened);
			}
			else if (securityLockData.lockState == SecurityLockState.SECURITY_STATE_APPLY)
			{
				this.SetShowType(AccountLockSettings.ShowType.ForceUnLock);
			}
			if (this.goNotOpen != null)
			{
				this.goNotOpen.CustomActive(false);
			}
			if (this.goOpened != null)
			{
				this.goOpened.CustomActive(false);
			}
			if (this.goForceLock != null)
			{
				this.goForceLock.CustomActive(false);
			}
			if (this.eShowType == AccountLockSettings.ShowType.NotOpen)
			{
				if (this.goNotOpen != null)
				{
					this.goNotOpen.CustomActive(true);
				}
				if (!securityLockData.isUseLock)
				{
					this.btnBind.CustomActive(false);
					this.btnUnBind.CustomActive(false);
				}
				else if (securityLockData.isUseLock && !securityLockData.isCommonDev)
				{
					this.btnBind.CustomActive(true);
					this.btnUnBind.CustomActive(false);
				}
				else if (securityLockData.isUseLock && securityLockData.isCommonDev)
				{
					this.btnBind.CustomActive(false);
					this.btnUnBind.CustomActive(true);
				}
			}
			else if (this.eShowType == AccountLockSettings.ShowType.Opened)
			{
				if (this.goOpened != null)
				{
					this.goOpened.CustomActive(true);
				}
			}
			else if (this.eShowType == AccountLockSettings.ShowType.ForceUnLock)
			{
				if (this.goForceLock != null)
				{
					this.goForceLock.CustomActive(true);
				}
				if (this.txtApply != null)
				{
					DateTime dateTime = Function.ConvertIntDateTime((double)securityLockData.freezeTime);
					this.txtApply.text = dateTime.ToString(TR.Value("tip_timestrmp2"), DateTimeFormatInfo.InvariantInfo);
				}
				if (this.txtApplyEnd != null)
				{
					DateTime dateTime2 = Function.ConvertIntDateTime((double)securityLockData.unFreezeTime);
					this.txtApplyEnd.text = dateTime2.ToString(TR.Value("tip_timestrmp2"), DateTimeFormatInfo.InvariantInfo);
				}
			}
			else
			{
				Logger.LogErrorFormat("show type error!!!,type = {0}", new object[]
				{
					this.eShowType
				});
			}
		}

		// Token: 0x0601065D RID: 67165 RVA: 0x0049C511 File Offset: 0x0049A911
		private void _OnRefeshUI(UIEvent a_event)
		{
			this.RefeshUI();
		}

		// Token: 0x0400A66E RID: 42606
		private Button btnLock;

		// Token: 0x0400A66F RID: 42607
		private Button btnBind;

		// Token: 0x0400A670 RID: 42608
		private Button btnUnBind;

		// Token: 0x0400A671 RID: 42609
		private Button btnUnLock;

		// Token: 0x0400A672 RID: 42610
		private Button btnForceUnLock;

		// Token: 0x0400A673 RID: 42611
		private Button btnChangePwd;

		// Token: 0x0400A674 RID: 42612
		private Button btnCancelForceUnLock;

		// Token: 0x0400A675 RID: 42613
		private Text txtApply;

		// Token: 0x0400A676 RID: 42614
		private Text txtApplyEnd;

		// Token: 0x0400A677 RID: 42615
		private GameObject goNotOpen;

		// Token: 0x0400A678 RID: 42616
		private GameObject goOpened;

		// Token: 0x0400A679 RID: 42617
		private GameObject goForceLock;

		// Token: 0x0400A67A RID: 42618
		private AccountLockSettings.ShowType eShowType = AccountLockSettings.ShowType.NotOpen;

		// Token: 0x02001A16 RID: 6678
		public enum ShowType
		{
			// Token: 0x0400A684 RID: 42628
			Opened,
			// Token: 0x0400A685 RID: 42629
			NotOpen,
			// Token: 0x0400A686 RID: 42630
			ForceUnLock
		}
	}
}
