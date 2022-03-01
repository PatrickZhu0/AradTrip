using System;

namespace GameClient
{
	// Token: 0x02001521 RID: 5409
	public class ChapterBattlePotionSetFrameData : IComparable<ChapterBattlePotionSetFrameData>
	{
		// Token: 0x0600D276 RID: 53878 RVA: 0x00341125 File Offset: 0x0033F525
		public ChapterBattlePotionSetFrameData(ComCommonBind bind, ulong id)
		{
			this.id = id;
			this.bind = bind;
		}

		// Token: 0x17001BF1 RID: 7153
		// (get) Token: 0x0600D277 RID: 53879 RVA: 0x0034113B File Offset: 0x0033F53B
		// (set) Token: 0x0600D278 RID: 53880 RVA: 0x00341143 File Offset: 0x0033F543
		public ComCommonBind bind { get; set; }

		// Token: 0x17001BF2 RID: 7154
		// (get) Token: 0x0600D279 RID: 53881 RVA: 0x0034114C File Offset: 0x0033F54C
		// (set) Token: 0x0600D27A RID: 53882 RVA: 0x00341154 File Offset: 0x0033F554
		public ulong id
		{
			get
			{
				return this.mID;
			}
			set
			{
				this.mID = value;
				this._updateTypeAndTableID();
			}
		}

		// Token: 0x17001BF3 RID: 7155
		// (get) Token: 0x0600D27B RID: 53883 RVA: 0x00341163 File Offset: 0x0033F563
		// (set) Token: 0x0600D27C RID: 53884 RVA: 0x0034116B File Offset: 0x0033F56B
		private int tableID { get; set; }

		// Token: 0x17001BF4 RID: 7156
		// (get) Token: 0x0600D27D RID: 53885 RVA: 0x00341174 File Offset: 0x0033F574
		// (set) Token: 0x0600D27E RID: 53886 RVA: 0x0034117C File Offset: 0x0033F57C
		private int type { get; set; }

		// Token: 0x0600D27F RID: 53887 RVA: 0x00341188 File Offset: 0x0033F588
		private void _updateTypeAndTableID()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.id);
			if (item != null)
			{
				this.tableID = item.TableID;
				this.type = item.SubType;
			}
			else
			{
				this.type = int.MaxValue;
				this.tableID = int.MaxValue;
			}
		}

		// Token: 0x0600D280 RID: 53888 RVA: 0x003411E0 File Offset: 0x0033F5E0
		public int CompareTo(ChapterBattlePotionSetFrameData other)
		{
			if (this.type != other.type)
			{
				return this.type - other.type;
			}
			if (this.tableID != other.tableID)
			{
				return other.tableID - this.tableID;
			}
			if (this.id > other.id)
			{
				return -1;
			}
			if (this.id == other.id)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x04007B3D RID: 31549
		private ulong mID;
	}
}
