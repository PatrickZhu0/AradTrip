using System;

namespace GameClient
{
	// Token: 0x02000EA7 RID: 3751
	public class ComControlFrame : ClientFrame
	{
		// Token: 0x0600941E RID: 37918 RVA: 0x001BC0C8 File Offset: 0x001BA4C8
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ComControl/ComControlFrame";
		}

		// Token: 0x0600941F RID: 37919 RVA: 0x001BC0CF File Offset: 0x001BA4CF
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mComControlView != null)
			{
				this.mComControlView.InitView();
			}
		}

		// Token: 0x06009420 RID: 37920 RVA: 0x001BC0F3 File Offset: 0x001BA4F3
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06009421 RID: 37921 RVA: 0x001BC0F5 File Offset: 0x001BA4F5
		protected override void _bindExUI()
		{
			this.mComControlView = this.mBind.GetCom<ComControlView>("ComControlView");
		}

		// Token: 0x06009422 RID: 37922 RVA: 0x001BC10D File Offset: 0x001BA50D
		protected override void _unbindExUI()
		{
			this.mComControlView = null;
		}

		// Token: 0x04004AFD RID: 19197
		private ComControlView mComControlView;
	}
}
