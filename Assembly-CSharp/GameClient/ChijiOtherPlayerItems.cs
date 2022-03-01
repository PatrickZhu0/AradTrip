using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001135 RID: 4405
	public class ChijiOtherPlayerItems
	{
		// Token: 0x0600A761 RID: 42849 RVA: 0x0022E8C3 File Offset: 0x0022CCC3
		public void ClearData()
		{
			this.battleID = 0U;
			this.playerID = 0UL;
			this.detailItems.Clear();
		}

		// Token: 0x04005DAD RID: 23981
		public uint battleID;

		// Token: 0x04005DAE RID: 23982
		public ulong playerID;

		// Token: 0x04005DAF RID: 23983
		public List<OtherPlayerDetailItem> detailItems = new List<OtherPlayerDetailItem>();
	}
}
