using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BF1 RID: 7153
	internal class TAPTabData
	{
		// Token: 0x0400B673 RID: 46707
		public TAPSystemTabType eTAPSystemTabType = TAPSystemTabType.TSTT_COUNT;

		// Token: 0x0400B674 RID: 46708
		public string name;

		// Token: 0x0400B675 RID: 46709
		public TAPTabData.OpenCheck isOpen;

		// Token: 0x0400B676 RID: 46710
		public TAPTabData.OnTabChanged onTabChanged;

		// Token: 0x0400B677 RID: 46711
		public GameObject root;

		// Token: 0x02001BF2 RID: 7154
		// (Invoke) Token: 0x06011899 RID: 71833
		public delegate bool OpenCheck();

		// Token: 0x02001BF3 RID: 7155
		// (Invoke) Token: 0x0601189D RID: 71837
		public delegate ClientFrame OnTabChanged(TAPSystemTabType eTAPSystemTabType, object data);
	}
}
