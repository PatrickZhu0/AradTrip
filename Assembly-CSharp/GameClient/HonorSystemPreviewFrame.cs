using System;

namespace GameClient
{
	// Token: 0x02001674 RID: 5748
	public class HonorSystemPreviewFrame : ClientFrame
	{
		// Token: 0x0600E1FB RID: 57851 RVA: 0x003A1175 File Offset: 0x0039F575
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HonorSystem/HonorSystemPreviewFrame";
		}

		// Token: 0x0600E1FC RID: 57852 RVA: 0x003A117C File Offset: 0x0039F57C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mHonorSystemPreviewView != null)
			{
				this.mHonorSystemPreviewView.InitView();
			}
		}

		// Token: 0x0600E1FD RID: 57853 RVA: 0x003A11A0 File Offset: 0x0039F5A0
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E1FE RID: 57854 RVA: 0x003A11A2 File Offset: 0x0039F5A2
		protected override void _bindExUI()
		{
			this.mHonorSystemPreviewView = this.mBind.GetCom<HonorSystemPreviewView>("HonorSystemPreviewView");
		}

		// Token: 0x0600E1FF RID: 57855 RVA: 0x003A11BA File Offset: 0x0039F5BA
		protected override void _unbindExUI()
		{
			this.mHonorSystemPreviewView = null;
		}

		// Token: 0x04008741 RID: 34625
		private HonorSystemPreviewView mHonorSystemPreviewView;
	}
}
