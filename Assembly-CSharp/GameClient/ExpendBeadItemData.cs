using System;

namespace GameClient
{
	// Token: 0x02001B13 RID: 6931
	public class ExpendBeadItemData : IComparable<ExpendBeadItemData>
	{
		// Token: 0x0601105B RID: 69723 RVA: 0x004DF99D File Offset: 0x004DDD9D
		public ExpendBeadItemData(int itemID, int tatleCount, int count)
		{
			this.ItemID = itemID;
			this.TatleCount = tatleCount;
			this.Count = count;
		}

		// Token: 0x0601105C RID: 69724 RVA: 0x004DF9BA File Offset: 0x004DDDBA
		public int CompareTo(ExpendBeadItemData other)
		{
			return other.TatleCount - this.TatleCount;
		}

		// Token: 0x0400AF3F RID: 44863
		public int ItemID;

		// Token: 0x0400AF40 RID: 44864
		public int TatleCount;

		// Token: 0x0400AF41 RID: 44865
		public int Count;
	}
}
