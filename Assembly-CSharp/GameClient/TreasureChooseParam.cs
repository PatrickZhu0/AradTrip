using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001CBF RID: 7359
	public class TreasureChooseParam
	{
		// Token: 0x0400BC35 RID: 48181
		public List<ItemData> treasureChooseList;

		// Token: 0x0400BC36 RID: 48182
		public Action<ItemData> treasureChooseCallback;
	}
}
