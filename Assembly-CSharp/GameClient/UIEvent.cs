using System;

namespace GameClient
{
	// Token: 0x02000FBE RID: 4030
	public class UIEvent
	{
		// Token: 0x06009AE0 RID: 39648 RVA: 0x001DF1A9 File Offset: 0x001DD5A9
		public void Initialize()
		{
			this.EventID = EUIEventID.Invalid;
			this.Param1 = null;
			this.Param2 = null;
			this.Param3 = null;
			this.Param4 = null;
			this.IsUsing = false;
		}

		// Token: 0x0400506A RID: 20586
		public EUIEventID EventID;

		// Token: 0x0400506B RID: 20587
		public UIEventParams EventParams;

		// Token: 0x0400506C RID: 20588
		public object Param1;

		// Token: 0x0400506D RID: 20589
		public object Param2;

		// Token: 0x0400506E RID: 20590
		public object Param3;

		// Token: 0x0400506F RID: 20591
		public object Param4;

		// Token: 0x04005070 RID: 20592
		public bool IsUsing;
	}
}
