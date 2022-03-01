using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F55 RID: 3925
	public class DeadTowerActivityConsumeData : BaseActivityConsumeData, IActivityConsumeData
	{
		// Token: 0x06009889 RID: 39049 RVA: 0x001D57DA File Offset: 0x001D3BDA
		public DeadTowerActivityConsumeData(int id) : base(id)
		{
		}

		// Token: 0x0600988A RID: 39050 RVA: 0x001D57E3 File Offset: 0x001D3BE3
		private int _getDeadTowerNormalLeftCount()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_RESET_REMAIN_TIMES);
		}

		// Token: 0x0600988B RID: 39051 RVA: 0x001D57F4 File Offset: 0x001D3BF4
		private int _getDeadTowerVipCount()
		{
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.WARRIOR_TOWER_REBEGIN_NUM);
			if (curVipLevelPrivilegeData <= 0f)
			{
				return 0;
			}
			return (int)curVipLevelPrivilegeData - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_VIP_TOWER_PAY_TIMES);
		}

		// Token: 0x0600988C RID: 39052 RVA: 0x001D5827 File Offset: 0x001D3C27
		public long GetLeftCount()
		{
			return (long)(this._getDeadTowerNormalLeftCount() + this._getDeadTowerVipCount());
		}

		// Token: 0x0600988D RID: 39053 RVA: 0x001D5837 File Offset: 0x001D3C37
		public long GetSumCount()
		{
			return 0L;
		}

		// Token: 0x0600988E RID: 39054 RVA: 0x001D583B File Offset: 0x001D3C3B
		public bool IsCanBuyCount()
		{
			return this._getDeadTowerVipCount() > 0;
		}

		// Token: 0x0600988F RID: 39055 RVA: 0x001D5846 File Offset: 0x001D3C46
		public long GetLeftBuyCount()
		{
			return 0L;
		}

		// Token: 0x06009890 RID: 39056 RVA: 0x001D584A File Offset: 0x001D3C4A
		public long GetHasUsedCount()
		{
			return 0L;
		}

		// Token: 0x06009891 RID: 39057 RVA: 0x001D584E File Offset: 0x001D3C4E
		public long GetHasBuyCount()
		{
			return 0L;
		}

		// Token: 0x06009892 RID: 39058 RVA: 0x001D5852 File Offset: 0x001D3C52
		public int GetCostItemID()
		{
			return 0;
		}

		// Token: 0x06009893 RID: 39059 RVA: 0x001D5855 File Offset: 0x001D3C55
		public int GetCostItemCount()
		{
			return 0;
		}

		// Token: 0x06009894 RID: 39060 RVA: 0x001D5858 File Offset: 0x001D3C58
		public byte GetCostItemType()
		{
			return 0;
		}
	}
}
