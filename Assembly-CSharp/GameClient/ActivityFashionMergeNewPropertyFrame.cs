using System;

namespace GameClient
{
	// Token: 0x02001B18 RID: 6936
	public class ActivityFashionMergeNewPropertyFrame : ClientFrame
	{
		// Token: 0x06011079 RID: 69753 RVA: 0x004E0071 File Offset: 0x004DE471
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/ActivityFashionMergeNewPropertyFrame";
		}

		// Token: 0x0601107A RID: 69754 RVA: 0x004E0078 File Offset: 0x004DE478
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mFashionMergeNewPropertyView != null)
			{
				this.mFashionMergeNewPropertyView.InitData();
			}
		}

		// Token: 0x0601107B RID: 69755 RVA: 0x004E009C File Offset: 0x004DE49C
		protected override void _bindExUI()
		{
			this.mFashionMergeNewPropertyView = this.mBind.GetCom<FashionMergeNewPropertyView>("FashionMergeNewPropertyView");
		}

		// Token: 0x0601107C RID: 69756 RVA: 0x004E00B4 File Offset: 0x004DE4B4
		protected override void _unbindExUI()
		{
			this.mFashionMergeNewPropertyView = null;
		}

		// Token: 0x0400AF4D RID: 44877
		private FashionMergeNewPropertyView mFashionMergeNewPropertyView;
	}
}
