using System;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A12 RID: 6674
	public class AccountLock : ClientFrame
	{
		// Token: 0x06010630 RID: 67120 RVA: 0x0049B806 File Offset: 0x00499C06
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SettingPanel/AccountLock";
		}

		// Token: 0x06010631 RID: 67121 RVA: 0x0049B80D File Offset: 0x00499C0D
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
		}

		// Token: 0x06010632 RID: 67122 RVA: 0x0049B815 File Offset: 0x00499C15
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x06010633 RID: 67123 RVA: 0x0049B820 File Offset: 0x00499C20
		protected override void _bindExUI()
		{
			this.edtPwd1 = this.mBind.GetCom<InputField>("Pwd1");
			this.edtPwd2 = this.mBind.GetCom<InputField>("Pwd2");
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<AccountLock>(this, false);
				});
			}
			this.btnOK = this.mBind.GetCom<Button>("btOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					if (this.edtPwd1 != null && this.edtPwd2 != null)
					{
						if (this.edtPwd1.textComponent.text != this.edtPwd2.textComponent.text)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("两次输入的密码不一致", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						if (this.edtPwd1.textComponent.text.Length < SecurityLockDataManager.nPwdMinLength || this.edtPwd1.textComponent.text.Length > SecurityLockDataManager.nPwdMaxLength)
						{
							SystemNotifyManager.SysNotifyFloatingEffect("密码长度错误(密码长度最小4位，最大8位)", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockOpReq(LockOpType.LT_LOCK, this.edtPwd1.textComponent.text);
					}
				});
			}
			this.imgGou = this.mBind.GetCom<Image>("imgGou");
		}

		// Token: 0x06010634 RID: 67124 RVA: 0x0049B915 File Offset: 0x00499D15
		protected override void _unbindExUI()
		{
			this.edtPwd1 = null;
			this.edtPwd2 = null;
			this.btnClose = null;
			this.btnOK = null;
			this.imgGou = null;
		}

		// Token: 0x06010635 RID: 67125 RVA: 0x0049B93A File Offset: 0x00499D3A
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x06010636 RID: 67126 RVA: 0x0049B940 File Offset: 0x00499D40
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.imgGou != null && this.edtPwd1 != null && this.edtPwd2 != null)
			{
				this.imgGou.CustomActive(this.edtPwd1.textComponent.text == this.edtPwd2.textComponent.text && this.edtPwd1.textComponent.text != string.Empty);
			}
		}

		// Token: 0x06010637 RID: 67127 RVA: 0x0049B9D2 File Offset: 0x00499DD2
		private void BindUIEvent()
		{
		}

		// Token: 0x06010638 RID: 67128 RVA: 0x0049B9D4 File Offset: 0x00499DD4
		private void UnBindUIEvent()
		{
		}

		// Token: 0x06010639 RID: 67129 RVA: 0x0049B9D6 File Offset: 0x00499DD6
		private void OnChangeNum(UIEvent iEvent)
		{
		}

		// Token: 0x0400A65F RID: 42591
		private InputField edtPwd1;

		// Token: 0x0400A660 RID: 42592
		private InputField edtPwd2;

		// Token: 0x0400A661 RID: 42593
		private Button btnClose;

		// Token: 0x0400A662 RID: 42594
		private Button btnOK;

		// Token: 0x0400A663 RID: 42595
		private Image imgGou;
	}
}
