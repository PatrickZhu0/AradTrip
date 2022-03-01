using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001725 RID: 5925
	public class FashionOutComeData
	{
		// Token: 0x0600E8B2 RID: 59570 RVA: 0x003D8C63 File Offset: 0x003D7063
		public FashionOutComeData()
		{
			this.mallItemInfos = new List<MallItemInfo>();
			this.fashionTypeIndex = FashionMallMainIndex.None;
		}

		// Token: 0x04008D14 RID: 36116
		public List<MallItemInfo> mallItemInfos;

		// Token: 0x04008D15 RID: 36117
		public FashionMallMainIndex fashionTypeIndex;
	}
}
