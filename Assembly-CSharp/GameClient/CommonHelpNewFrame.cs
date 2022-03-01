using System;

namespace GameClient
{
	// Token: 0x02000E01 RID: 3585
	public class CommonHelpNewFrame : ClientFrame
	{
		// Token: 0x06008FC0 RID: 36800 RVA: 0x001A9250 File Offset: 0x001A7650
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/CommonHelpNew/CommonHelpNewFrame";
		}

		// Token: 0x06008FC1 RID: 36801 RVA: 0x001A9258 File Offset: 0x001A7658
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCommonHelpNewView != null)
			{
				int helpId = 0;
				if (this.userData != null)
				{
					helpId = (int)this.userData;
				}
				this.mCommonHelpNewView.InitView(helpId);
			}
		}

		// Token: 0x06008FC2 RID: 36802 RVA: 0x001A92A1 File Offset: 0x001A76A1
		protected override void _bindExUI()
		{
			this.mCommonHelpNewView = this.mBind.GetCom<CommonHelpNewView>("CommonHelpNewView");
		}

		// Token: 0x06008FC3 RID: 36803 RVA: 0x001A92B9 File Offset: 0x001A76B9
		protected override void _unbindExUI()
		{
			this.mCommonHelpNewView = null;
		}

		// Token: 0x04004753 RID: 18259
		private CommonHelpNewView mCommonHelpNewView;
	}
}
