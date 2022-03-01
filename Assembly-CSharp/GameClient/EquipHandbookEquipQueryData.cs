using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020015BF RID: 5567
	internal class EquipHandbookEquipQueryData
	{
		// Token: 0x17001C34 RID: 7220
		// (get) Token: 0x0600D9CB RID: 55755 RVA: 0x0036AD17 File Offset: 0x00369117
		// (set) Token: 0x0600D9CC RID: 55756 RVA: 0x0036AD1F File Offset: 0x0036911F
		public int code { get; set; }

		// Token: 0x04008017 RID: 32791
		public List<EquipHandbookCommentData> itemcomments = new List<EquipHandbookCommentData>();
	}
}
