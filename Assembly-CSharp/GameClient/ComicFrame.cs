using System;

namespace GameClient
{
	// Token: 0x020045AE RID: 17838
	internal sealed class ComicFrame : ClientFrame
	{
		// Token: 0x06018F6C RID: 102252 RVA: 0x007DAD3F File Offset: 0x007D913F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/ComicFrame";
		}

		// Token: 0x06018F6D RID: 102253 RVA: 0x007DAD46 File Offset: 0x007D9146
		public override bool NeedMutex()
		{
			return false;
		}

		// Token: 0x06018F6E RID: 102254 RVA: 0x007DAD49 File Offset: 0x007D9149
		private void ShowMainFrameAndInput(bool bShow)
		{
			InputManager.instance.SetVisible(bShow);
		}

		// Token: 0x06018F6F RID: 102255 RVA: 0x007DAD56 File Offset: 0x007D9156
		protected override void _OnOpenFrame()
		{
			this.ShowMainFrameAndInput(false);
		}

		// Token: 0x06018F70 RID: 102256 RVA: 0x007DAD5F File Offset: 0x007D915F
		protected override void _OnCloseFrame()
		{
		}
	}
}
