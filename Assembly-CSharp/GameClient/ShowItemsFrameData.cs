using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020016FF RID: 5887
	internal class ShowItemsFrameData
	{
		// Token: 0x04008C27 RID: 35879
		public JarData data;

		// Token: 0x04008C28 RID: 35880
		public JarBuyInfo buyInfo;

		// Token: 0x04008C29 RID: 35881
		public List<JarBonus> items = new List<JarBonus>();

		// Token: 0x04008C2A RID: 35882
		public ItemData scoreItemData;

		// Token: 0x04008C2B RID: 35883
		public int scoreRate = 1;
	}
}
