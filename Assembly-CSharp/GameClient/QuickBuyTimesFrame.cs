using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019C5 RID: 6597
	public class QuickBuyTimesFrame : ClientFrame
	{
		// Token: 0x17001D2B RID: 7467
		// (get) Token: 0x06010273 RID: 66163 RVA: 0x004803D4 File Offset: 0x0047E7D4
		// (set) Token: 0x06010272 RID: 66162 RVA: 0x004803CB File Offset: 0x0047E7CB
		public QuickBuyTimesFrame.eState state { get; private set; }

		// Token: 0x06010274 RID: 66164 RVA: 0x004803DC File Offset: 0x0047E7DC
		protected override void _bindExUI()
		{
			this.mLeftcount = this.mBind.GetCom<Text>("leftcount");
			this.mCoincount = this.mBind.GetCom<Text>("coincount");
			this.mCointype = this.mBind.GetCom<Text>("cointype");
			this.mCancel = this.mBind.GetCom<Button>("cancel");
			this.mCancel.onClick.AddListener(new UnityAction(this._onCancelButtonClick));
			this.mOk = this.mBind.GetCom<Button>("ok");
			this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
			this.mIcon = this.mBind.GetCom<Image>("icon");
		}

		// Token: 0x06010275 RID: 66165 RVA: 0x004804A8 File Offset: 0x0047E8A8
		protected override void _unbindExUI()
		{
			this.mLeftcount = null;
			this.mCoincount = null;
			this.mCointype = null;
			this.mCancel.onClick.RemoveListener(new UnityAction(this._onCancelButtonClick));
			this.mCancel = null;
			this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
			this.mOk = null;
			this.mIcon = null;
		}

		// Token: 0x06010276 RID: 66166 RVA: 0x00480517 File Offset: 0x0047E917
		private void _onCancelButtonClick()
		{
			this._onCancel();
		}

		// Token: 0x06010277 RID: 66167 RVA: 0x0048051F File Offset: 0x0047E91F
		private void _onOkButtonClick()
		{
			this._onOK();
		}

		// Token: 0x06010278 RID: 66168 RVA: 0x00480527 File Offset: 0x0047E927
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/CommonTimesQuickBuy";
		}

		// Token: 0x06010279 RID: 66169 RVA: 0x0048052E File Offset: 0x0047E92E
		protected override void _OnOpenFrame()
		{
			this.state = QuickBuyTimesFrame.eState.None;
		}

		// Token: 0x0601027A RID: 66170 RVA: 0x00480537 File Offset: 0x0047E937
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0601027B RID: 66171 RVA: 0x00480539 File Offset: 0x0047E939
		public void SetLeftCount(int leftCount)
		{
			this.mLeftcount.text = leftCount.ToString();
		}

		// Token: 0x0601027C RID: 66172 RVA: 0x00480554 File Offset: 0x0047E954
		public void SetCostItem(int id, int count)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.Icon, true);
			}
			this.mCoincount.text = count.ToString();
		}

		// Token: 0x0601027D RID: 66173 RVA: 0x004805A8 File Offset: 0x0047E9A8
		private void _onOK()
		{
			this.state = QuickBuyTimesFrame.eState.Success;
			this.frameMgr.CloseFrame<QuickBuyTimesFrame>(this, false);
		}

		// Token: 0x0601027E RID: 66174 RVA: 0x004805BE File Offset: 0x0047E9BE
		private void _onCancel()
		{
			this.state = QuickBuyTimesFrame.eState.Cancel;
			this.frameMgr.CloseFrame<QuickBuyTimesFrame>(this, false);
		}

		// Token: 0x0400A325 RID: 41765
		private Text mLeftcount;

		// Token: 0x0400A326 RID: 41766
		private Text mCoincount;

		// Token: 0x0400A327 RID: 41767
		private Text mCointype;

		// Token: 0x0400A328 RID: 41768
		private Button mCancel;

		// Token: 0x0400A329 RID: 41769
		private Button mOk;

		// Token: 0x0400A32A RID: 41770
		private Image mIcon;

		// Token: 0x020019C6 RID: 6598
		public enum eState
		{
			// Token: 0x0400A32C RID: 41772
			None,
			// Token: 0x0400A32D RID: 41773
			Success,
			// Token: 0x0400A32E RID: 41774
			Cancel
		}
	}
}
