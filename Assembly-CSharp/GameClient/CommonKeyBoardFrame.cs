using System;

namespace GameClient
{
	// Token: 0x02000E07 RID: 3591
	public class CommonKeyBoardFrame : ClientFrame
	{
		// Token: 0x06008FE9 RID: 36841 RVA: 0x001A9A6B File Offset: 0x001A7E6B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/CommonKeyBoard/CommonKeyBoardFrame";
		}

		// Token: 0x06008FEA RID: 36842 RVA: 0x001A9A74 File Offset: 0x001A7E74
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCommonKeyBoardView != null)
			{
				CommonKeyBoardDataModel dataModel = null;
				if (this.userData != null)
				{
					dataModel = (this.userData as CommonKeyBoardDataModel);
				}
				this.mCommonKeyBoardView.InitView(dataModel);
			}
		}

		// Token: 0x06008FEB RID: 36843 RVA: 0x001A9ABD File Offset: 0x001A7EBD
		protected override void _bindExUI()
		{
			this.mCommonKeyBoardView = this.mBind.GetCom<CommonKeyBoardView>("CommonKeyBoardView");
		}

		// Token: 0x06008FEC RID: 36844 RVA: 0x001A9AD5 File Offset: 0x001A7ED5
		protected override void _unbindExUI()
		{
			this.mCommonKeyBoardView = null;
		}

		// Token: 0x0400476C RID: 18284
		private CommonKeyBoardView mCommonKeyBoardView;
	}
}
