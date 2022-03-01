using System;

namespace GameClient
{
	// Token: 0x02001678 RID: 5752
	public class HonorSystemProtectCardFrame : ClientFrame
	{
		// Token: 0x0600E21F RID: 57887 RVA: 0x003A18FC File Offset: 0x0039FCFC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HonorSystem/HonorSystemProtectCardFrame";
		}

		// Token: 0x0600E220 RID: 57888 RVA: 0x003A1903 File Offset: 0x0039FD03
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mHonorSystemProtectCardView != null)
			{
				this.mHonorSystemProtectCardView.InitView();
			}
		}

		// Token: 0x0600E221 RID: 57889 RVA: 0x003A1927 File Offset: 0x0039FD27
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E222 RID: 57890 RVA: 0x003A1929 File Offset: 0x0039FD29
		protected override void _bindExUI()
		{
			this.mHonorSystemProtectCardView = this.mBind.GetCom<HonorSystemProtectCardView>("HonorSystemProtectCardView");
		}

		// Token: 0x0600E223 RID: 57891 RVA: 0x003A1941 File Offset: 0x0039FD41
		protected override void _unbindExUI()
		{
			this.mHonorSystemProtectCardView = null;
		}

		// Token: 0x04008752 RID: 34642
		private HonorSystemProtectCardView mHonorSystemProtectCardView;
	}
}
