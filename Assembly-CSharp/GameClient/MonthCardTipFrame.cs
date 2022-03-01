using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001946 RID: 6470
	public sealed class MonthCardTipFrame : ClientFrame
	{
		// Token: 0x0600FBB2 RID: 64434 RVA: 0x0044FF0B File Offset: 0x0044E30B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/MonthCardTipFrame";
		}

		// Token: 0x0600FBB3 RID: 64435 RVA: 0x0044FF14 File Offset: 0x0044E314
		protected override void _bindExUI()
		{
			this.closeBtn = this.mBind.GetCom<Button>("BtnClose");
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.CloseBtnClick));
				this.closeBtn.onClick.AddListener(new UnityAction(this.CloseBtnClick));
			}
			this.openVipBtn = this.mBind.GetCom<Button>("BtnVip");
			if (this.openVipBtn)
			{
				this.openVipBtn.onClick.RemoveListener(new UnityAction(this.OpenVipBtnClick));
				this.openVipBtn.onClick.AddListener(new UnityAction(this.OpenVipBtnClick));
			}
		}

		// Token: 0x0600FBB4 RID: 64436 RVA: 0x0044FFE0 File Offset: 0x0044E3E0
		protected override void _unbindExUI()
		{
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.CloseBtnClick));
			}
			this.closeBtn = null;
			if (this.openVipBtn)
			{
				this.openVipBtn.onClick.RemoveListener(new UnityAction(this.OpenVipBtnClick));
			}
			this.openVipBtn = null;
		}

		// Token: 0x0600FBB5 RID: 64437 RVA: 0x00450053 File Offset: 0x0044E453
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600FBB6 RID: 64438 RVA: 0x00450055 File Offset: 0x0044E455
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600FBB7 RID: 64439 RVA: 0x00450057 File Offset: 0x0044E457
		private void CloseBtnClick()
		{
			this.frameMgr.CloseFrame<MonthCardTipFrame>(this, false);
		}

		// Token: 0x0600FBB8 RID: 64440 RVA: 0x00450066 File Offset: 0x0044E466
		private void OpenVipBtnClick()
		{
			base.Close(false);
			if (!this.frameMgr.IsFrameOpen<VipFrame>(null))
			{
				this.frameMgr.OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
			}
		}

		// Token: 0x04009D42 RID: 40258
		private Button closeBtn;

		// Token: 0x04009D43 RID: 40259
		private Button openVipBtn;
	}
}
