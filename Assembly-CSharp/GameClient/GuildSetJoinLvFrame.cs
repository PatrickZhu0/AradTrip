using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001652 RID: 5714
	public class GuildSetJoinLvFrame : ClientFrame
	{
		// Token: 0x0600E0CF RID: 57551 RVA: 0x0039895B File Offset: 0x00396D5B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildSetJoinLv";
		}

		// Token: 0x0600E0D0 RID: 57552 RVA: 0x00398964 File Offset: 0x00396D64
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			if (this.txtVirtualInput != null)
			{
				this.txtVirtualInput.SetInputMode(NumberVirtualInput.InputMode.NUMBER);
				this.txtVirtualInput.SetNumberLimit(0U, (uint)GuildDataManager.GetJoinGuildMaxLevel());
			}
			if (this.edtNumber != null && DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.edtNumber.textComponent.text = DataManager<GuildDataManager>.GetInstance().myGuild.nJoinLevel.ToString();
			}
		}

		// Token: 0x0600E0D1 RID: 57553 RVA: 0x003989EF File Offset: 0x00396DEF
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600E0D2 RID: 57554 RVA: 0x003989F8 File Offset: 0x00396DF8
		protected override void _bindExUI()
		{
			this.edtNumber = this.mBind.GetCom<InputField>("edtNumber");
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<GuildSetJoinLvFrame>(this, false);
				});
			}
			this.btnOK = this.mBind.GetCom<Button>("btOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					if (this.edtNumber != null)
					{
						DataManager<GuildDataManager>.GetInstance().SendWorldGuildSetJoinLevelReq(Utility.ToUInt(this.edtNumber.textComponent.text));
					}
					this.frameMgr.CloseFrame<GuildSetJoinLvFrame>(this, false);
				});
			}
			this.txtVirtualInput = this.mBind.GetCom<NumberVirtualInput>("txtVirtualInput");
		}

		// Token: 0x0600E0D3 RID: 57555 RVA: 0x00398AD7 File Offset: 0x00396ED7
		protected override void _unbindExUI()
		{
			this.edtNumber = null;
			this.btnClose = null;
			this.btnOK = null;
			this.txtVirtualInput = null;
		}

		// Token: 0x0600E0D4 RID: 57556 RVA: 0x00398AF5 File Offset: 0x00396EF5
		private void BindUIEvent()
		{
		}

		// Token: 0x0600E0D5 RID: 57557 RVA: 0x00398AF7 File Offset: 0x00396EF7
		private void UnBindUIEvent()
		{
		}

		// Token: 0x040085BD RID: 34237
		private InputField edtNumber;

		// Token: 0x040085BE RID: 34238
		private Button btnClose;

		// Token: 0x040085BF RID: 34239
		private Button btnOK;

		// Token: 0x040085C0 RID: 34240
		private NumberVirtualInput txtVirtualInput;
	}
}
