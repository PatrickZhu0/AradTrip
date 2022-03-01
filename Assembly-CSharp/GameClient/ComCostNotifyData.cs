using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001BB7 RID: 7095
	public class ComCostNotifyData
	{
		// Token: 0x0400B42C RID: 46124
		public string strContent;

		// Token: 0x0400B42D RID: 46125
		public Action<bool> delSetNotify;

		// Token: 0x0400B42E RID: 46126
		public Func<bool> delGetNotify;

		// Token: 0x0400B42F RID: 46127
		public UnityAction delOnOkCallback;

		// Token: 0x0400B430 RID: 46128
		public UnityAction delOnCancelCallback;
	}
}
