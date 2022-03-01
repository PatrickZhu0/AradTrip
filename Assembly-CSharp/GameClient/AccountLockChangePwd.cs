using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A14 RID: 6676
	public class AccountLockChangePwd : ClientFrame
	{
		// Token: 0x06010648 RID: 67144 RVA: 0x0049BC39 File Offset: 0x0049A039
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SettingPanel/AccountLockChangePwd";
		}

		// Token: 0x06010649 RID: 67145 RVA: 0x0049BC40 File Offset: 0x0049A040
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
		}

		// Token: 0x0601064A RID: 67146 RVA: 0x0049BC48 File Offset: 0x0049A048
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0601064B RID: 67147 RVA: 0x0049BC50 File Offset: 0x0049A050
		protected override void _bindExUI()
		{
			this.edtPwd1 = this.mBind.GetCom<InputField>("Pwd1");
			this.edtPwd2 = this.mBind.GetCom<InputField>("Pwd2");
			this.edtPwd3 = this.mBind.GetCom<InputField>("Pwd3");
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<AccountLockChangePwd>(this, false);
				});
			}
			this.btnOK = this.mBind.GetCom<Button>("btOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					if (this.edtPwd1 != null && this.edtPwd2 != null && this.edtPwd3 != null)
					{
						if (this.edtPwd1.textComponent.text.Length < SecurityLockDataManager.nPwdMinLength || this.edtPwd1.textComponent.text.Length > SecurityLockDataManager.nPwdMaxLength)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("原密码长度错误(密码长度最小4位，最大8位)", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						if (this.edtPwd2.textComponent.text != this.edtPwd3.textComponent.text)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("两次密码输入不一致", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						if (this.edtPwd2.textComponent.text.Length < SecurityLockDataManager.nPwdMinLength || this.edtPwd2.textComponent.text.Length > SecurityLockDataManager.nPwdMaxLength)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("新密码长度错误(密码长度最小4位，最大8位)", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						if (this.edtPwd1.textComponent.text == this.edtPwd2.textComponent.text)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("新密码不可以与原密码相同，请重新输入", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						DataManager<SecurityLockDataManager>.GetInstance().SendWorldChangeSecurityPasswdReq(this.edtPwd1.textComponent.text, this.edtPwd2.textComponent.text);
					}
				});
			}
			this.imgGou = this.mBind.GetCom<Image>("imgGou");
		}

		// Token: 0x0601064C RID: 67148 RVA: 0x0049BD5B File Offset: 0x0049A15B
		protected override void _unbindExUI()
		{
			this.edtPwd1 = null;
			this.edtPwd2 = null;
			this.edtPwd3 = null;
			this.btnClose = null;
			this.btnOK = null;
			this.imgGou = null;
		}

		// Token: 0x0601064D RID: 67149 RVA: 0x0049BD87 File Offset: 0x0049A187
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0601064E RID: 67150 RVA: 0x0049BD8C File Offset: 0x0049A18C
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.imgGou != null && this.edtPwd2 != null && this.edtPwd3 != null)
			{
				this.imgGou.CustomActive(this.edtPwd2.textComponent.text == this.edtPwd3.textComponent.text && this.edtPwd2.textComponent.text != string.Empty);
			}
		}

		// Token: 0x0601064F RID: 67151 RVA: 0x0049BE1E File Offset: 0x0049A21E
		private void BindUIEvent()
		{
		}

		// Token: 0x06010650 RID: 67152 RVA: 0x0049BE20 File Offset: 0x0049A220
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0400A668 RID: 42600
		private InputField edtPwd1;

		// Token: 0x0400A669 RID: 42601
		private InputField edtPwd2;

		// Token: 0x0400A66A RID: 42602
		private InputField edtPwd3;

		// Token: 0x0400A66B RID: 42603
		private Button btnClose;

		// Token: 0x0400A66C RID: 42604
		private Button btnOK;

		// Token: 0x0400A66D RID: 42605
		private Image imgGou;
	}
}
