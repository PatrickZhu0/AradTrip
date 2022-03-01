using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000652 RID: 1618
	public class BaseSortList
	{
		// Token: 0x060055C1 RID: 21953 RVA: 0x00106CF2 File Offset: 0x001050F2
		public bool Init(SortListType type)
		{
			return true;
		}

		// Token: 0x040021C5 RID: 8645
		public SortListType type;

		// Token: 0x040021C6 RID: 8646
		public ushort start;

		// Token: 0x040021C7 RID: 8647
		public ushort totalNum;

		// Token: 0x040021C8 RID: 8648
		public ushort num;

		// Token: 0x040021C9 RID: 8649
		public List<BaseSortListEntry> entries = new List<BaseSortListEntry>();

		// Token: 0x040021CA RID: 8650
		public BaseSortListEntry selfEntry;
	}
}
