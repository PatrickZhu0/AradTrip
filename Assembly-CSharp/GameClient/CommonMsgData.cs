using System;

namespace GameClient
{
	// Token: 0x02000E23 RID: 3619
	internal class CommonMsgData
	{
		// Token: 0x04004830 RID: 18480
		public string ok;

		// Token: 0x04004831 RID: 18481
		public string cancel;

		// Token: 0x04004832 RID: 18482
		public string msg;

		// Token: 0x04004833 RID: 18483
		public CommonMsgData.OnOk onClickOk;

		// Token: 0x04004834 RID: 18484
		public CommonMsgData.OnCancel onClickCancel;

		// Token: 0x02000E24 RID: 3620
		// (Invoke) Token: 0x060090E4 RID: 37092
		public delegate void OnOk();

		// Token: 0x02000E25 RID: 3621
		// (Invoke) Token: 0x060090E8 RID: 37096
		public delegate void OnCancel();
	}
}
