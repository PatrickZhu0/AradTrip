using System;

namespace GameClient
{
	// Token: 0x020012FC RID: 4860
	public class StrengthenTicketFuseItemData
	{
		// Token: 0x0600BC58 RID: 48216 RVA: 0x002BEA63 File Offset: 0x002BCE63
		public StrengthenTicketFuseItemData()
		{
			this.Clear();
		}

		// Token: 0x0600BC59 RID: 48217 RVA: 0x002BEA71 File Offset: 0x002BCE71
		public void Clear()
		{
			this.ticketItemData = null;
		}

		// Token: 0x040069FF RID: 27135
		public ItemData ticketItemData;

		// Token: 0x04006A00 RID: 27136
		public int fuseValue;

		// Token: 0x04006A01 RID: 27137
		public bool canFuse;

		// Token: 0x04006A02 RID: 27138
		public float sProbabilityConvert;

		// Token: 0x04006A03 RID: 27139
		public int sLevel;

		// Token: 0x04006A04 RID: 27140
		public int bNotBindInt;
	}
}
