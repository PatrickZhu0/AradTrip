using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001B72 RID: 7026
	public class RandomPropertiesFrame : ClientFrame
	{
		// Token: 0x06011379 RID: 70521 RVA: 0x004F446C File Offset: 0x004F286C
		protected sealed override void _bindExUI()
		{
			this.mRandomPropertiesView = this.mBind.GetCom<RandomPropertiesView>("RandomPropertiesView");
		}

		// Token: 0x0601137A RID: 70522 RVA: 0x004F4484 File Offset: 0x004F2884
		protected sealed override void _unbindExUI()
		{
			this.mRandomPropertiesView = null;
		}

		// Token: 0x0601137B RID: 70523 RVA: 0x004F448D File Offset: 0x004F288D
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/RandomPropertiesFrame/RandomPropertiesFrame";
		}

		// Token: 0x0601137C RID: 70524 RVA: 0x004F4494 File Offset: 0x004F2894
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mDatas = (this.userData as List<int>);
			if (this.mDatas != null)
			{
				this.mRandomPropertiesView.Initialize(this, this.mDatas);
			}
		}

		// Token: 0x0601137D RID: 70525 RVA: 0x004F44CA File Offset: 0x004F28CA
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mRandomPropertiesView.UnInitialize();
		}

		// Token: 0x0400B1CA RID: 45514
		private List<int> mDatas;

		// Token: 0x0400B1CB RID: 45515
		private RandomPropertiesView mRandomPropertiesView;
	}
}
