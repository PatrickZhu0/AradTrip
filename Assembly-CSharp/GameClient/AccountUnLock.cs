using System;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A17 RID: 6679
	public class AccountUnLock : ClientFrame
	{
		// Token: 0x06010667 RID: 67175 RVA: 0x0049C63D File Offset: 0x0049AA3D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SettingPanel/AccountUnLock";
		}

		// Token: 0x06010668 RID: 67176 RVA: 0x0049C644 File Offset: 0x0049AA44
		protected override void _OnOpenFrame()
		{
			this.iCount = 0;
			this.BindUIEvent();
			this._OnRefreshVerifyPwdErrorCount(null);
		}

		// Token: 0x06010669 RID: 67177 RVA: 0x0049C65A File Offset: 0x0049AA5A
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
			this.UnBindUIEvent();
		}

		// Token: 0x0601066A RID: 67178 RVA: 0x0049C668 File Offset: 0x0049AA68
		protected override void _bindExUI()
		{
			this.edtPwd1 = this.mBind.GetCom<InputField>("Pwd1");
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			this.btnCD = this.mBind.GetCom<SetComButtonCD>("btOKCD");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<AccountUnLock>(this, false);
				});
			}
			this.txtOk = this.mBind.GetCom<Text>("txtOk");
			if (this.txtOk != null)
			{
				this.strOk = this.txtOk.text;
			}
			this.txtErrorCount = this.mBind.GetCom<Text>("txtErrorCount");
			this.btnOK = this.mBind.GetCom<Button>("btOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					if (this.edtPwd1 != null)
					{
						if (this.edtPwd1.textComponent.text.Length < SecurityLockDataManager.nPwdMinLength || this.edtPwd1.textComponent.text.Length > SecurityLockDataManager.nPwdMaxLength)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("密码长度错误(密码长度最小4位，最大8位)", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						ClientSystemLogin clientSystemLogin = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemLogin;
						if (clientSystemLogin != null)
						{
							DataManager<SecurityLockDataManager>.GetInstance().SendGateSecurityLockRemoveReq(this.edtPwd1.textComponent.text);
						}
						else
						{
							DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockOpReq(LockOpType.LT_UNLOCK, this.edtPwd1.textComponent.text);
						}
						InvokeMethod.InvokeInterval(this, 0f, 1f, 3f, delegate
						{
							if (this.btnOK != null)
							{
								UIGray uigray = this.btnOK.gameObject.SafeAddComponent(true);
								if (uigray != null)
								{
									uigray.SetEnable(true);
								}
								this.btnOK.interactable = false;
								this.btnOK.image.raycastTarget = false;
							}
							if (this.txtOk != null)
							{
								this.txtOk.text = string.Format("{0}({1}s)", this.strOk, 3 - this.iCount);
								this.iCount++;
							}
						}, delegate
						{
							if (this.txtOk != null)
							{
								this.txtOk.text = string.Format("{0}({1}s)", this.strOk, 3 - this.iCount);
								this.iCount++;
							}
						}, delegate
						{
							if (this.btnOK != null)
							{
								UIGray component = this.btnOK.gameObject.GetComponent<UIGray>();
								if (component != null)
								{
									component.SetEnable(false);
								}
								this.btnOK.interactable = true;
								this.btnOK.image.raycastTarget = true;
							}
							if (this.txtOk != null)
							{
								this.txtOk.text = string.Format("{0}", this.strOk);
								this.iCount = 0;
							}
						});
					}
				});
			}
		}

		// Token: 0x0601066B RID: 67179 RVA: 0x0049C795 File Offset: 0x0049AB95
		protected override void _unbindExUI()
		{
			this.edtPwd1 = null;
			this.btnClose = null;
			this.btnOK = null;
			this.btnCD = null;
			this.txtOk = null;
			this.txtErrorCount = null;
		}

		// Token: 0x0601066C RID: 67180 RVA: 0x0049C7C1 File Offset: 0x0049ABC1
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshVerifyPwdErrorCount, new ClientEventSystem.UIEventHandler(this._OnRefreshVerifyPwdErrorCount));
		}

		// Token: 0x0601066D RID: 67181 RVA: 0x0049C7DE File Offset: 0x0049ABDE
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshVerifyPwdErrorCount, new ClientEventSystem.UIEventHandler(this._OnRefreshVerifyPwdErrorCount));
		}

		// Token: 0x0601066E RID: 67182 RVA: 0x0049C7FC File Offset: 0x0049ABFC
		private void _OnRefreshVerifyPwdErrorCount(UIEvent uiEvent)
		{
			SecurityLockData securityLockData = DataManager<SecurityLockDataManager>.GetInstance().GetSecurityLockData();
			if (this.txtErrorCount != null)
			{
				this.txtErrorCount.text = TR.Value("verifyPwdFailedCount", 5, securityLockData.verifyPwdFailedCount);
			}
			if (securityLockData.verifyPwdFailedCount >= 5U)
			{
				InvokeMethod.RmoveInvokeIntervalCall(this);
				if (this.btnOK != null)
				{
					UIGray uigray = this.btnOK.gameObject.SafeAddComponent(true);
					if (uigray != null)
					{
						uigray.SetEnable(true);
					}
					this.btnOK.interactable = false;
					this.btnOK.image.raycastTarget = false;
				}
				if (this.txtOk != null)
				{
					this.txtOk.text = string.Format("{0}", this.strOk);
					this.iCount = 0;
				}
			}
		}

		// Token: 0x0400A687 RID: 42631
		private string strOk = string.Empty;

		// Token: 0x0400A688 RID: 42632
		private int iCount;

		// Token: 0x0400A689 RID: 42633
		private const int maxCount = 3;

		// Token: 0x0400A68A RID: 42634
		private const int maxErrorCount = 5;

		// Token: 0x0400A68B RID: 42635
		private InputField edtPwd1;

		// Token: 0x0400A68C RID: 42636
		private Button btnClose;

		// Token: 0x0400A68D RID: 42637
		private Button btnOK;

		// Token: 0x0400A68E RID: 42638
		private SetComButtonCD btnCD;

		// Token: 0x0400A68F RID: 42639
		private Text txtOk;

		// Token: 0x0400A690 RID: 42640
		private Text txtErrorCount;
	}
}
