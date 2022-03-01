using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012A3 RID: 4771
	public class JarData
	{
		// Token: 0x04006786 RID: 26502
		public int nID;

		// Token: 0x04006787 RID: 26503
		public JarBonus.eType eType;

		// Token: 0x04006788 RID: 26504
		public string strName;

		// Token: 0x04006789 RID: 26505
		public string strJarImagePath;

		// Token: 0x0400678A RID: 26506
		public string strJarModelPath;

		// Token: 0x0400678B RID: 26507
		public IList<int> arrFilters;

		// Token: 0x0400678C RID: 26508
		public List<ItemSimpleData> arrBonusItems;

		// Token: 0x0400678D RID: 26509
		public List<ItemSimpleData> arrRealBonusItems;

		// Token: 0x0400678E RID: 26510
		public List<ItemData> arrBuyItems;

		// Token: 0x0400678F RID: 26511
		public List<JarBuyInfo> arrBuyInfos;
	}
}
