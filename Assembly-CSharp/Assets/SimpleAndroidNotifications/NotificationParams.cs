using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
	// Token: 0x02004985 RID: 18821
	public class NotificationParams
	{
		// Token: 0x04012D9A RID: 77210
		public int Id;

		// Token: 0x04012D9B RID: 77211
		public TimeSpan Delay;

		// Token: 0x04012D9C RID: 77212
		public string Title;

		// Token: 0x04012D9D RID: 77213
		public string Message;

		// Token: 0x04012D9E RID: 77214
		public string Ticker;

		// Token: 0x04012D9F RID: 77215
		public bool Sound = true;

		// Token: 0x04012DA0 RID: 77216
		public bool Vibrate = true;

		// Token: 0x04012DA1 RID: 77217
		public bool Light = true;

		// Token: 0x04012DA2 RID: 77218
		public NotificationIcon SmallIcon;

		// Token: 0x04012DA3 RID: 77219
		public Color SmallIconColor;

		// Token: 0x04012DA4 RID: 77220
		public string LargeIcon;
	}
}
