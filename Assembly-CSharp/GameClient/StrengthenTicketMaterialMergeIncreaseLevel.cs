using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012FA RID: 4858
	public class StrengthenTicketMaterialMergeIncreaseLevel
	{
		// Token: 0x0600BC54 RID: 48212 RVA: 0x002BE9EB File Offset: 0x002BCDEB
		public StrengthenTicketMaterialMergeIncreaseLevel()
		{
			this.Clear();
		}

		// Token: 0x0600BC55 RID: 48213 RVA: 0x002BEA0F File Offset: 0x002BCE0F
		public void Clear()
		{
			if (this.mergeTableIds != null)
			{
				this.mergeTableIds.Clear();
			}
			if (this.increaseLevels != null)
			{
				this.increaseLevels.Clear();
			}
		}

		// Token: 0x040069F6 RID: 27126
		public int displayItemTableId;

		// Token: 0x040069F7 RID: 27127
		public string name;

		// Token: 0x040069F8 RID: 27128
		public int strengthenLevel;

		// Token: 0x040069F9 RID: 27129
		public bool isBind;

		// Token: 0x040069FA RID: 27130
		public List<int> mergeTableIds = new List<int>();

		// Token: 0x040069FB RID: 27131
		public List<int> increaseLevels = new List<int>();
	}
}
