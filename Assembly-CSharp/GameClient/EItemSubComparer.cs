using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200128B RID: 4747
	public class EItemSubComparer : IEqualityComparer<ItemTable.eSubType>
	{
		// Token: 0x0600B677 RID: 46711 RVA: 0x00293BF0 File Offset: 0x00291FF0
		public bool Equals(ItemTable.eSubType x, ItemTable.eSubType y)
		{
			return x == y;
		}

		// Token: 0x0600B678 RID: 46712 RVA: 0x00293BF6 File Offset: 0x00291FF6
		public int GetHashCode(ItemTable.eSubType x)
		{
			return (int)x;
		}
	}
}
