using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200128A RID: 4746
	public class EItemTypeComparer : IEqualityComparer<ItemTable.eType>
	{
		// Token: 0x0600B674 RID: 46708 RVA: 0x00293BDF File Offset: 0x00291FDF
		public bool Equals(ItemTable.eType x, ItemTable.eType y)
		{
			return x == y;
		}

		// Token: 0x0600B675 RID: 46709 RVA: 0x00293BE5 File Offset: 0x00291FE5
		public int GetHashCode(ItemTable.eType x)
		{
			return (int)x;
		}
	}
}
