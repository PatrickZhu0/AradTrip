using System;

namespace GameClient
{
	// Token: 0x0200167B RID: 5755
	public class HonorSystemFrame : ClientFrame
	{
		// Token: 0x0600E244 RID: 57924 RVA: 0x003A2179 File Offset: 0x003A0579
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HonorSystem/HonorSystemFrame";
		}

		// Token: 0x0600E245 RID: 57925 RVA: 0x003A2180 File Offset: 0x003A0580
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mHonorSystemView != null)
			{
				this.mHonorSystemView.InitView();
			}
		}

		// Token: 0x0600E246 RID: 57926 RVA: 0x003A21A4 File Offset: 0x003A05A4
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E247 RID: 57927 RVA: 0x003A21A6 File Offset: 0x003A05A6
		protected override void _bindExUI()
		{
			this.mHonorSystemView = this.mBind.GetCom<HonorSystemView>("HonorSystemView");
		}

		// Token: 0x0600E248 RID: 57928 RVA: 0x003A21BE File Offset: 0x003A05BE
		protected override void _unbindExUI()
		{
			this.mHonorSystemView = null;
		}

		// Token: 0x04008767 RID: 34663
		private HonorSystemView mHonorSystemView;
	}
}
