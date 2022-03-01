using System;

namespace GameClient
{
	// Token: 0x0200460C RID: 17932
	public class NpcInteractionData
	{
		// Token: 0x040120FB RID: 73979
		public string name;

		// Token: 0x040120FC RID: 73980
		public string icon;

		// Token: 0x040120FD RID: 73981
		public NpcInteractionData.OnClickFunction onClickFunction;

		// Token: 0x040120FE RID: 73982
		public NpcInteractionType eNpcInteractionType;

		// Token: 0x040120FF RID: 73983
		public int iParam0;

		// Token: 0x0200460D RID: 17933
		// (Invoke) Token: 0x06019345 RID: 103237
		public delegate void OnClickFunction();
	}
}
