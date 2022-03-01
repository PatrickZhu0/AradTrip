using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000E97 RID: 3735
	public interface IChapterInfoDrops
	{
		// Token: 0x060093BD RID: 37821
		void SetDropList(IList<int> drops, int dungonID);

		// Token: 0x060093BE RID: 37822
		void UpdateDropCount(List<ComItemList.Items> drops);
	}
}
