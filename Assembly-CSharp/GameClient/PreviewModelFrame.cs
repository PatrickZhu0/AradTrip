using System;

namespace GameClient
{
	// Token: 0x02001599 RID: 5529
	public class PreviewModelFrame : ClientFrame
	{
		// Token: 0x0600D844 RID: 55364 RVA: 0x00361093 File Offset: 0x0035F493
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/PreviewModelFrame";
		}

		// Token: 0x0600D845 RID: 55365 RVA: 0x0036109C File Offset: 0x0035F49C
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null && this.preViewDataModel == null)
			{
				this.preViewDataModel = (this.userData as PreViewDataModel);
			}
			if (this.mPreviewModelView != null)
			{
				this.mPreviewModelView.InitView(this.preViewDataModel);
			}
		}

		// Token: 0x0600D846 RID: 55366 RVA: 0x003610F2 File Offset: 0x0035F4F2
		protected sealed override void _OnCloseFrame()
		{
			this.preViewDataModel = null;
		}

		// Token: 0x0600D847 RID: 55367 RVA: 0x003610FB File Offset: 0x0035F4FB
		protected sealed override void _bindExUI()
		{
			this.mPreviewModelView = this.mBind.GetCom<PreviewModelView>("PreviewModelView");
		}

		// Token: 0x0600D848 RID: 55368 RVA: 0x00361113 File Offset: 0x0035F513
		protected sealed override void _unbindExUI()
		{
			this.mPreviewModelView = null;
		}

		// Token: 0x04007EFB RID: 32507
		private PreViewDataModel preViewDataModel;

		// Token: 0x04007EFC RID: 32508
		private PreviewModelView mPreviewModelView;
	}
}
