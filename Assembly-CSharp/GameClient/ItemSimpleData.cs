using System;

namespace GameClient
{
	// Token: 0x02001288 RID: 4744
	public class ItemSimpleData
	{
		// Token: 0x0600B66E RID: 46702 RVA: 0x00293BA8 File Offset: 0x00291FA8
		public ItemSimpleData()
		{
		}

		// Token: 0x0600B66F RID: 46703 RVA: 0x00293BB0 File Offset: 0x00291FB0
		public ItemSimpleData(int id, int count)
		{
			this.ItemID = id;
			this.Count = count;
		}

		// Token: 0x04006722 RID: 26402
		public int ItemID;

		// Token: 0x04006723 RID: 26403
		public int Count;

		// Token: 0x04006724 RID: 26404
		public string Name;

		// Token: 0x04006725 RID: 26405
		public int level;
	}
}
