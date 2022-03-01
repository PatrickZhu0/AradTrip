using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016E4 RID: 5860
	internal class ItemTipData
	{
		// Token: 0x04008ACC RID: 35532
		public TextAnchor textAnchor;

		// Token: 0x04008ACD RID: 35533
		public ItemData item;

		// Token: 0x04008ACE RID: 35534
		public EquipSuitObj itemSuitObj;

		// Token: 0x04008ACF RID: 35535
		public ItemData compareItem;

		// Token: 0x04008AD0 RID: 35536
		public EquipSuitObj compareItemSuitObj;

		// Token: 0x04008AD1 RID: 35537
		public List<TipFuncButon> funcs;

		// Token: 0x04008AD2 RID: 35538
		public int nTipIndex;

		// Token: 0x04008AD3 RID: 35539
		public bool IsForceCloseModelAvatar;

		// Token: 0x04008AD4 RID: 35540
		public bool giftItemIsRequestServer = true;
	}
}
