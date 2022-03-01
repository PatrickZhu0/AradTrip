using System;

namespace GameClient
{
	// Token: 0x02000FC9 RID: 4041
	internal class UIEventSpecialRedPointNotify : UIEvent
	{
		// Token: 0x06009AEB RID: 39659 RVA: 0x001DF34C File Offset: 0x001DD74C
		public UIEventSpecialRedPointNotify(int iMainId, string prefabKey)
		{
			this.EventID = EUIEventID.ActivitySpecialRedPointNotify;
			this.iMainId = iMainId;
			this.prefabKey = prefabKey;
		}

		// Token: 0x0400507F RID: 20607
		public int iMainId;

		// Token: 0x04005080 RID: 20608
		public string prefabKey;
	}
}
