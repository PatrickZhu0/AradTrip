using System;

namespace GameClient
{
	// Token: 0x0200175E RID: 5982
	internal class CommonClientFrame : ClientFrame
	{
		// Token: 0x0600EC08 RID: 60424 RVA: 0x003EEB3C File Offset: 0x003ECF3C
		[UIEventHandle("C/Close")]
		protected void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600EC09 RID: 60425 RVA: 0x003EEB45 File Offset: 0x003ECF45
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600EC0A RID: 60426 RVA: 0x003EEB47 File Offset: 0x003ECF47
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600EC0B RID: 60427 RVA: 0x003EEB49 File Offset: 0x003ECF49
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/Publish/UplevelShow";
		}
	}
}
