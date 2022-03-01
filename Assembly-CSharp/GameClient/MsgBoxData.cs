using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AEE RID: 6894
	public class MsgBoxData
	{
		// Token: 0x0400ADE3 RID: 44515
		public int iID;

		// Token: 0x0400ADE4 RID: 44516
		public string prefab;

		// Token: 0x0400ADE5 RID: 44517
		public string title;

		// Token: 0x0400ADE6 RID: 44518
		public string content;

		// Token: 0x0400ADE7 RID: 44519
		public string ok;

		// Token: 0x0400ADE8 RID: 44520
		public string cancel;

		// Token: 0x0400ADE9 RID: 44521
		public MsgBoxDataType flags;

		// Token: 0x0400ADEA RID: 44522
		public UnityAction OnOK;

		// Token: 0x0400ADEB RID: 44523
		public UnityAction OnCancel;
	}
}
