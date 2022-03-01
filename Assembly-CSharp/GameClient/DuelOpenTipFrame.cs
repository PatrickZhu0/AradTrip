using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015DD RID: 5597
	internal class DuelOpenTipFrame : ClientFrame
	{
		// Token: 0x0600DB40 RID: 56128 RVA: 0x003742B1 File Offset: 0x003726B1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionUnlock/NextOpenShow_1";
		}

		// Token: 0x0600DB41 RID: 56129 RVA: 0x003742B8 File Offset: 0x003726B8
		protected override void _OnOpenFrame()
		{
			this.openType = (OpenType)this.userData;
			this.jobType = DataManager<PlayerBaseData>.GetInstance().JobTableID / 10 * 10;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.jobType, string.Empty, string.Empty);
			if (this.openType == OpenType.changejobbefore)
			{
				if (tableItem != null)
				{
					this.mBorder.CustomActive(false);
					ETCImageLoader.LoadSprite(ref this.mImgBeijing, tableItem.ChangJobTaskPrompt, true);
				}
			}
			else if (this.openType == OpenType.changejobbeafter)
			{
				this.mBorder.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.mImgBeijing, this.changejobbeforePath, true);
			}
		}

		// Token: 0x0600DB42 RID: 56130 RVA: 0x00374368 File Offset: 0x00372768
		protected override void _OnCloseFrame()
		{
			this.openType = OpenType.none;
			this.jobType = 0;
		}

		// Token: 0x0600DB43 RID: 56131 RVA: 0x00374378 File Offset: 0x00372778
		protected override void _bindExUI()
		{
			this.mImgBeijing = this.mBind.GetCom<Image>("ImgBeijing");
			this.mBorder = this.mBind.GetGameObject("Border");
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
		}

		// Token: 0x0600DB44 RID: 56132 RVA: 0x003743E3 File Offset: 0x003727E3
		protected override void _unbindExUI()
		{
			this.mImgBeijing = null;
			this.mBorder = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
		}

		// Token: 0x0600DB45 RID: 56133 RVA: 0x00374416 File Offset: 0x00372816
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<DuelOpenTipFrame>(this, false);
		}

		// Token: 0x0400812B RID: 33067
		private OpenType openType;

		// Token: 0x0400812C RID: 33068
		private int jobType;

		// Token: 0x0400812D RID: 33069
		private string changejobbeforePath = "UIFlatten/Image/Background/UI_Beijing_Wanfa.png:UI_Beijing_Wanfa";

		// Token: 0x0400812E RID: 33070
		private Image mImgBeijing;

		// Token: 0x0400812F RID: 33071
		private GameObject mBorder;

		// Token: 0x04008130 RID: 33072
		private Button mBtClose;
	}
}
