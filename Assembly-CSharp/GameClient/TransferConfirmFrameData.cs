using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001B95 RID: 7061
	internal class TransferConfirmFrameData
	{
		// Token: 0x0400B357 RID: 45911
		public ItemData data;

		// Token: 0x0400B358 RID: 45912
		public ItemData item;

		// Token: 0x0400B359 RID: 45913
		public UnityAction<ItemData, ItemData> onOk;
	}
}
