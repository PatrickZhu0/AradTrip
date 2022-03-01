using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001603 RID: 5635
	internal class GuildCommonModifyData
	{
		// Token: 0x04008244 RID: 33348
		public string strTitle;

		// Token: 0x04008245 RID: 33349
		public string strEmptyDesc;

		// Token: 0x04008246 RID: 33350
		public string strDefultContent;

		// Token: 0x04008247 RID: 33351
		public int nMaxWords;

		// Token: 0x04008248 RID: 33352
		public bool bHasCost;

		// Token: 0x04008249 RID: 33353
		public int nCostID;

		// Token: 0x0400824A RID: 33354
		public int nCostCount;

		// Token: 0x0400824B RID: 33355
		public EGuildCommonModifyMode eMode;

		// Token: 0x0400824C RID: 33356
		public UnityAction<string> onOkClicked;

		// Token: 0x0400824D RID: 33357
		public UnityAction onCancelClicked;
	}
}
