using System;

namespace GameClient
{
	// Token: 0x02000F54 RID: 3924
	public class NormalActivityConsumeData : BaseActivityConsumeData, IActivityConsumeData
	{
		// Token: 0x06009876 RID: 39030 RVA: 0x001D5541 File Offset: 0x001D3941
		public NormalActivityConsumeData(int id) : base(id)
		{
		}

		// Token: 0x06009877 RID: 39031 RVA: 0x001D554C File Offset: 0x001D394C
		protected long _getCommonSumCount()
		{
			long result = 0L;
			if (this.mDungeonTimesTable != null)
			{
				result = (long)this.mDungeonTimesTable.BaseTimes;
			}
			return result;
		}

		// Token: 0x06009878 RID: 39032 RVA: 0x001D5578 File Offset: 0x001D3978
		protected long _getCommonBuySumCount()
		{
			long result = 0L;
			if (this.mDungeonTimesTable != null)
			{
				result = (long)this.mDungeonTimesTable.BaseBuyTimes;
			}
			return result;
		}

		// Token: 0x06009879 RID: 39033 RVA: 0x001D55A4 File Offset: 0x001D39A4
		protected long _getVIPBuySumCount()
		{
			long result = 0L;
			if (this.mVipTable != null)
			{
				float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(this.mVipTable.Type);
				if (curVipLevelPrivilegeData <= 0f)
				{
					result = 0L;
				}
				else
				{
					result = (long)curVipLevelPrivilegeData;
				}
			}
			return result;
		}

		// Token: 0x0600987A RID: 39034 RVA: 0x001D55E8 File Offset: 0x001D39E8
		protected long _getUsedCounter()
		{
			long result = 0L;
			if (this.mDungeonTimesTable != null)
			{
				result = (long)DataManager<CountDataManager>.GetInstance().GetCount(this.mDungeonTimesTable.UsedTimesCounter);
			}
			return result;
		}

		// Token: 0x0600987B RID: 39035 RVA: 0x001D561C File Offset: 0x001D3A1C
		protected long _getBuyCounter()
		{
			long result = 0L;
			if (this.mDungeonTimesTable != null)
			{
				result = (long)DataManager<CountDataManager>.GetInstance().GetCount(this.mDungeonTimesTable.BuyTimesCounter);
			}
			return result;
		}

		// Token: 0x0600987C RID: 39036 RVA: 0x001D564F File Offset: 0x001D3A4F
		protected long _getBuySum()
		{
			return this._getVIPBuySumCount() + this._getCommonBuySumCount();
		}

		// Token: 0x0600987D RID: 39037 RVA: 0x001D565E File Offset: 0x001D3A5E
		protected long _getLeftBuyCount()
		{
			return this._getBuySum() - this._getBuyCounter();
		}

		// Token: 0x0600987E RID: 39038 RVA: 0x001D5670 File Offset: 0x001D3A70
		protected long _getLeftCount()
		{
			long num = this._getSumCount() - this._getUsedCounter();
			if (num < 0L)
			{
				num = 0L;
			}
			return num;
		}

		// Token: 0x0600987F RID: 39039 RVA: 0x001D569C File Offset: 0x001D3A9C
		protected long _getSumCount()
		{
			long num = this._getCommonSumCount() + this._getBuyCounter();
			if (num < 0L)
			{
				Logger.LogErrorFormat("[次数消耗] 总次数数值非法 {0}", new object[]
				{
					num
				});
				num = 0L;
			}
			return num;
		}

		// Token: 0x06009880 RID: 39040 RVA: 0x001D56DF File Offset: 0x001D3ADF
		public long GetLeftCount()
		{
			return this._getLeftCount();
		}

		// Token: 0x06009881 RID: 39041 RVA: 0x001D56E7 File Offset: 0x001D3AE7
		public long GetSumCount()
		{
			return this._getSumCount();
		}

		// Token: 0x06009882 RID: 39042 RVA: 0x001D56EF File Offset: 0x001D3AEF
		public bool IsCanBuyCount()
		{
			return this._getLeftBuyCount() > 0L;
		}

		// Token: 0x06009883 RID: 39043 RVA: 0x001D56FB File Offset: 0x001D3AFB
		public long GetLeftBuyCount()
		{
			return this._getBuySum() - this._getBuyCounter();
		}

		// Token: 0x06009884 RID: 39044 RVA: 0x001D570A File Offset: 0x001D3B0A
		public long GetHasUsedCount()
		{
			return this._getLeftBuyCount();
		}

		// Token: 0x06009885 RID: 39045 RVA: 0x001D5712 File Offset: 0x001D3B12
		public long GetHasBuyCount()
		{
			return this._getBuyCounter();
		}

		// Token: 0x06009886 RID: 39046 RVA: 0x001D571A File Offset: 0x001D3B1A
		public int GetCostItemID()
		{
			if (this.mDungeonTimesTable != null)
			{
				return this.mDungeonTimesTable.BuyTimesCostItemID;
			}
			return 0;
		}

		// Token: 0x06009887 RID: 39047 RVA: 0x001D5734 File Offset: 0x001D3B34
		public int GetCostItemCount()
		{
			int result = 0;
			int num = (int)this._getLeftBuyCount();
			if (this.mDungeonTimesTable != null)
			{
				if (this.mDungeonTimesTable.BuyTimesCost.Count > 0)
				{
					result = this.mDungeonTimesTable.BuyTimesCost[this.mDungeonTimesTable.BuyTimesCost.Count - 1];
				}
				if (num >= 0 && num < this.mDungeonTimesTable.BuyTimesCost.Count)
				{
					result = this.mDungeonTimesTable.BuyTimesCost[num];
				}
			}
			return result;
		}

		// Token: 0x06009888 RID: 39048 RVA: 0x001D57BF File Offset: 0x001D3BBF
		public byte GetCostItemType()
		{
			if (this.mDungeonTable != null)
			{
				return (byte)this.mDungeonTable.SubType;
			}
			return 0;
		}
	}
}
