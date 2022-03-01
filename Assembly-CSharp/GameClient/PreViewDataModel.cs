using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001597 RID: 5527
	public class PreViewDataModel
	{
		// Token: 0x0600D841 RID: 55361 RVA: 0x00361069 File Offset: 0x0035F469
		public PreViewDataModel()
		{
			this.isCreatItem = false;
			this.preViewItemList = new List<PreViewItemData>();
		}

		// Token: 0x04007EF7 RID: 32503
		public bool isCreatItem;

		// Token: 0x04007EF8 RID: 32504
		public List<PreViewItemData> preViewItemList;
	}
}
