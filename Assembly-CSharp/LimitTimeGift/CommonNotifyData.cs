using System;
using GameClient;
using UnityEngine.Events;

namespace LimitTimeGift
{
	// Token: 0x02001723 RID: 5923
	public class CommonNotifyData
	{
		// Token: 0x04008D0A RID: 36106
		public string contentStr;

		// Token: 0x04008D0B RID: 36107
		public UnityAction onClickOkCallback;

		// Token: 0x04008D0C RID: 36108
		public UnityAction onClickCancelCallback;

		// Token: 0x04008D0D RID: 36109
		public ClientFrame ownerFrame;
	}
}
