using System;

namespace GameClient
{
	// Token: 0x02001451 RID: 5201
	public class AuctionSellItemData : IComparable<AuctionSellItemData>
	{
		// Token: 0x0600C97E RID: 51582 RVA: 0x0031093B File Offset: 0x0030ED3B
		public AuctionSellItemData(ulong uid, int quality, int level, bool isTreasure = false)
		{
			this.uId = uid;
			this.Quality = quality;
			this.Level = level;
			this.IsTreasure = ((!isTreasure) ? 0 : 1);
		}

		// Token: 0x17001BEC RID: 7148
		// (get) Token: 0x0600C97F RID: 51583 RVA: 0x0031096C File Offset: 0x0030ED6C
		// (set) Token: 0x0600C980 RID: 51584 RVA: 0x00310974 File Offset: 0x0030ED74
		public ulong uId { get; set; }

		// Token: 0x17001BED RID: 7149
		// (get) Token: 0x0600C981 RID: 51585 RVA: 0x0031097D File Offset: 0x0030ED7D
		// (set) Token: 0x0600C982 RID: 51586 RVA: 0x00310985 File Offset: 0x0030ED85
		public int Quality { get; set; }

		// Token: 0x17001BEE RID: 7150
		// (get) Token: 0x0600C983 RID: 51587 RVA: 0x0031098E File Offset: 0x0030ED8E
		// (set) Token: 0x0600C984 RID: 51588 RVA: 0x00310996 File Offset: 0x0030ED96
		public int Level { get; set; }

		// Token: 0x17001BEF RID: 7151
		// (get) Token: 0x0600C985 RID: 51589 RVA: 0x0031099F File Offset: 0x0030ED9F
		// (set) Token: 0x0600C986 RID: 51590 RVA: 0x003109A7 File Offset: 0x0030EDA7
		public int IsTreasure { get; set; }

		// Token: 0x0600C987 RID: 51591 RVA: 0x003109B0 File Offset: 0x0030EDB0
		public int CompareTo(AuctionSellItemData other)
		{
			if (this.Quality == other.Quality)
			{
				return other.Level - this.Level;
			}
			return other.Quality - this.Quality;
		}
	}
}
