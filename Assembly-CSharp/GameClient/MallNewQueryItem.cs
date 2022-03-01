using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020012AB RID: 4779
	public class MallNewQueryItem
	{
		// Token: 0x040067C2 RID: 26562
		public int MallType;

		// Token: 0x040067C3 RID: 26563
		public int SubType;

		// Token: 0x040067C4 RID: 26564
		public int JobId;

		// Token: 0x040067C5 RID: 26565
		public List<MallItemInfo> Items;
	}
}
