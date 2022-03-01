using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001B6A RID: 7018
	public class MagicCardPreViewFrame : ClientFrame
	{
		// Token: 0x06011334 RID: 70452 RVA: 0x004F2E4F File Offset: 0x004F124F
		protected sealed override void _bindExUI()
		{
			this.mMagicCardPreView = this.mBind.GetCom<MagicCardPreViewView>("MagicCardPreView");
		}

		// Token: 0x06011335 RID: 70453 RVA: 0x004F2E67 File Offset: 0x004F1267
		protected sealed override void _unbindExUI()
		{
			this.mMagicCardPreView = null;
		}

		// Token: 0x06011336 RID: 70454 RVA: 0x004F2E70 File Offset: 0x004F1270
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FunctionPrefab/MagicCardPreViewFrame";
		}

		// Token: 0x06011337 RID: 70455 RVA: 0x004F2E78 File Offset: 0x004F1278
		protected sealed override void _OnOpenFrame()
		{
			this.mData = (this.userData as List<ItemData>);
			if (this.mData != null)
			{
				this.mData.Sort((ItemData x, ItemData y) => (x.Quality - y.Quality <= 0) ? 1 : -1);
				if (this.mMagicCardPreView != null)
				{
					this.mMagicCardPreView.InitView(this.mData);
				}
			}
		}

		// Token: 0x06011338 RID: 70456 RVA: 0x004F2EEB File Offset: 0x004F12EB
		protected sealed override void _OnCloseFrame()
		{
			if (this.mMagicCardPreView != null)
			{
				this.mMagicCardPreView.UnInitView();
			}
			this.mData = null;
		}

		// Token: 0x0400B18B RID: 45451
		private MagicCardPreViewView mMagicCardPreView;

		// Token: 0x0400B18C RID: 45452
		private List<ItemData> mData;
	}
}
