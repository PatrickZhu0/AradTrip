using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AF0 RID: 6896
	public class MsgBoxNewdata
	{
		// Token: 0x0400ADF4 RID: 44532
		public int iID;

		// Token: 0x0400ADF5 RID: 44533
		public string prefab;

		// Token: 0x0400ADF6 RID: 44534
		public string title;

		// Token: 0x0400ADF7 RID: 44535
		public string content;

		// Token: 0x0400ADF8 RID: 44536
		public string ok;

		// Token: 0x0400ADF9 RID: 44537
		public string cancel;

		// Token: 0x0400ADFA RID: 44538
		public MsgBoxDataType flags;

		// Token: 0x0400ADFB RID: 44539
		public UnityAction OnOK;

		// Token: 0x0400ADFC RID: 44540
		public UnityAction OnCancel;

		// Token: 0x0400ADFD RID: 44541
		public List<ToggleEvent> ToggleListEvent;

		// Token: 0x0400ADFE RID: 44542
		public FrameLayer eLayer = FrameLayer.Middle;
	}
}
