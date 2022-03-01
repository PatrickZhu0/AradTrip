using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001A8C RID: 6796
	public class BoxDataModel
	{
		// Token: 0x0400AA91 RID: 43665
		public string BoxModelPath;

		// Token: 0x0400AA92 RID: 43666
		public List<CommonNewItemDataModel> CommonNewItemDataModelList = new List<CommonNewItemDataModel>();

		// Token: 0x0400AA93 RID: 43667
		public CommonNewItemDataModel AwardItemData;

		// Token: 0x0400AA94 RID: 43668
		public bool IsSpecialAward;
	}
}
