using System;
using ProtoTable;

namespace DataModel
{
	// Token: 0x02001CD1 RID: 7377
	public abstract class ActivityTreasureLotteryModelBase : IActivityTreasureLotteryModelBase
	{
		// Token: 0x0601215E RID: 74078 RVA: 0x0054B978 File Offset: 0x00549D78
		public ActivityTreasureLotteryModelBase(int itemId, uint itemNum, uint lotteryId, int sortId)
		{
			this.ItemId = itemId;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			this.IconPath = string.Empty;
			this.Name = string.Empty;
			if (tableItem != null)
			{
				this.IconPath = tableItem.Icon;
				this.Name = tableItem.Name;
			}
			this.ItemNum = itemNum;
			this.LotteryId = lotteryId;
			this.SortId = sortId;
		}

		// Token: 0x17001DCD RID: 7629
		// (get) Token: 0x0601215F RID: 74079 RVA: 0x0054B9F2 File Offset: 0x00549DF2
		// (set) Token: 0x06012160 RID: 74080 RVA: 0x0054B9FA File Offset: 0x00549DFA
		public string IconPath { get; private set; }

		// Token: 0x17001DCE RID: 7630
		// (get) Token: 0x06012161 RID: 74081 RVA: 0x0054BA03 File Offset: 0x00549E03
		// (set) Token: 0x06012162 RID: 74082 RVA: 0x0054BA0B File Offset: 0x00549E0B
		public int ItemId { get; private set; }

		// Token: 0x17001DCF RID: 7631
		// (get) Token: 0x06012163 RID: 74083 RVA: 0x0054BA14 File Offset: 0x00549E14
		// (set) Token: 0x06012164 RID: 74084 RVA: 0x0054BA1C File Offset: 0x00549E1C
		public uint ItemNum { get; private set; }

		// Token: 0x17001DD0 RID: 7632
		// (get) Token: 0x06012165 RID: 74085 RVA: 0x0054BA25 File Offset: 0x00549E25
		// (set) Token: 0x06012166 RID: 74086 RVA: 0x0054BA2D File Offset: 0x00549E2D
		public uint LotteryId { get; private set; }

		// Token: 0x17001DD1 RID: 7633
		// (get) Token: 0x06012167 RID: 74087 RVA: 0x0054BA36 File Offset: 0x00549E36
		// (set) Token: 0x06012168 RID: 74088 RVA: 0x0054BA3E File Offset: 0x00549E3E
		public string Name { get; private set; }

		// Token: 0x17001DD2 RID: 7634
		// (get) Token: 0x06012169 RID: 74089 RVA: 0x0054BA47 File Offset: 0x00549E47
		// (set) Token: 0x0601216A RID: 74090 RVA: 0x0054BA4F File Offset: 0x00549E4F
		public int SortId { get; private set; }
	}
}
