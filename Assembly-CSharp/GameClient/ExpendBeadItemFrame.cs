using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001B14 RID: 6932
	public class ExpendBeadItemFrame : ClientFrame
	{
		// Token: 0x0601105E RID: 69726 RVA: 0x004DF9D1 File Offset: 0x004DDDD1
		protected sealed override void _bindExUI()
		{
			this.mExpendBeadItemView = this.mBind.GetCom<ExpendBeadItemView>("ExpendBeadItemView");
		}

		// Token: 0x0601105F RID: 69727 RVA: 0x004DF9E9 File Offset: 0x004DDDE9
		protected sealed override void _unbindExUI()
		{
			this.mExpendBeadItemView = null;
		}

		// Token: 0x06011060 RID: 69728 RVA: 0x004DF9F2 File Offset: 0x004DDDF2
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/ExpendBeadItemFrame/ExpendBeadItemFrame";
		}

		// Token: 0x06011061 RID: 69729 RVA: 0x004DF9FC File Offset: 0x004DDDFC
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mDatas = (this.userData as List<ExpendBeadItemData>);
			if (this.mDatas != null)
			{
				this.mExpendBeadItemView.Initialize(this, this.mDatas, new ExpendBeadItemView.OnItemSelected(this.OnSelectItem));
			}
		}

		// Token: 0x06011062 RID: 69730 RVA: 0x004DFA49 File Offset: 0x004DDE49
		private void OnSelectItem(ExpendBeadItemData data)
		{
			if (data != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectExpendBeadItem, data, null, null, null);
			}
			this.frameMgr.CloseFrame<ExpendBeadItemFrame>(this, false);
		}

		// Token: 0x06011063 RID: 69731 RVA: 0x004DFA71 File Offset: 0x004DDE71
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mExpendBeadItemView.UnInitialize();
		}

		// Token: 0x0400AF42 RID: 44866
		private List<ExpendBeadItemData> mDatas;

		// Token: 0x0400AF43 RID: 44867
		private ExpendBeadItemView mExpendBeadItemView;
	}
}
