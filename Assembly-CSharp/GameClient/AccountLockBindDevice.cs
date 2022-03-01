using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A13 RID: 6675
	public class AccountLockBindDevice : ClientFrame
	{
		// Token: 0x0601063D RID: 67133 RVA: 0x0049BABC File Offset: 0x00499EBC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SettingPanel/AccountLockBindDevice";
		}

		// Token: 0x0601063E RID: 67134 RVA: 0x0049BAC3 File Offset: 0x00499EC3
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
		}

		// Token: 0x0601063F RID: 67135 RVA: 0x0049BACB File Offset: 0x00499ECB
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x06010640 RID: 67136 RVA: 0x0049BAD4 File Offset: 0x00499ED4
		protected override void _bindExUI()
		{
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<AccountLockBindDevice>(this, false);
				});
			}
			this.btnOK = this.mBind.GetCom<Button>("btOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					DataManager<SecurityLockDataManager>.GetInstance().SendWorldBindDeviceReq(true);
				});
			}
			this.btnCancel = this.mBind.GetCom<Button>("btCancel");
			if (this.btnCancel != null)
			{
				this.btnCancel.onClick.RemoveAllListeners();
				this.btnCancel.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<AccountLockBindDevice>(this, false);
				});
			}
		}

		// Token: 0x06010641 RID: 67137 RVA: 0x0049BBEB File Offset: 0x00499FEB
		protected override void _unbindExUI()
		{
			this.btnOK = null;
			this.btnCancel = null;
			this.btnClose = null;
		}

		// Token: 0x06010642 RID: 67138 RVA: 0x0049BC02 File Offset: 0x0049A002
		private void BindUIEvent()
		{
		}

		// Token: 0x06010643 RID: 67139 RVA: 0x0049BC04 File Offset: 0x0049A004
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0400A664 RID: 42596
		private Button btnClose;

		// Token: 0x0400A665 RID: 42597
		private Button btnOK;

		// Token: 0x0400A666 RID: 42598
		private Button btnCancel;
	}
}
