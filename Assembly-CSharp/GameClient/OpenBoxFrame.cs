using System;

namespace GameClient
{
	// Token: 0x02001A8D RID: 6797
	public class OpenBoxFrame : ClientFrame
	{
		// Token: 0x06010AEE RID: 68334 RVA: 0x004BAC92 File Offset: 0x004B9092
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Box/OpenBoxFrame";
		}

		// Token: 0x06010AEF RID: 68335 RVA: 0x004BAC9C File Offset: 0x004B909C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mOpenBoxView != null)
			{
				BoxDataModel boxDataModel = (BoxDataModel)this.userData;
				this.mOpenBoxView.InitView(boxDataModel);
			}
		}

		// Token: 0x06010AF0 RID: 68336 RVA: 0x004BACD8 File Offset: 0x004B90D8
		protected override void _bindExUI()
		{
			this.mOpenBoxView = this.mBind.GetCom<OpenBoxView>("OpenBoxView");
		}

		// Token: 0x06010AF1 RID: 68337 RVA: 0x004BACF0 File Offset: 0x004B90F0
		protected override void _unbindExUI()
		{
			this.mOpenBoxView = null;
		}

		// Token: 0x0400AA95 RID: 43669
		private OpenBoxView mOpenBoxView;
	}
}
