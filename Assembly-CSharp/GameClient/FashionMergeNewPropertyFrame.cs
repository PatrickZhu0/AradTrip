using System;

namespace GameClient
{
	// Token: 0x02001B34 RID: 6964
	public class FashionMergeNewPropertyFrame : ClientFrame
	{
		// Token: 0x0601119C RID: 70044 RVA: 0x004E816B File Offset: 0x004E656B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionMergeNewPropertyFrame";
		}

		// Token: 0x0601119D RID: 70045 RVA: 0x004E8172 File Offset: 0x004E6572
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mFashionMergeNewPropertyView != null)
			{
				this.mFashionMergeNewPropertyView.InitData();
			}
		}

		// Token: 0x0601119E RID: 70046 RVA: 0x004E8196 File Offset: 0x004E6596
		protected override void _bindExUI()
		{
			this.mFashionMergeNewPropertyView = this.mBind.GetCom<FashionMergeNewPropertyView>("FashionMergeNewPropertyView");
		}

		// Token: 0x0601119F RID: 70047 RVA: 0x004E81AE File Offset: 0x004E65AE
		protected override void _unbindExUI()
		{
			this.mFashionMergeNewPropertyView = null;
		}

		// Token: 0x0400B042 RID: 45122
		private FashionMergeNewPropertyView mFashionMergeNewPropertyView;
	}
}
