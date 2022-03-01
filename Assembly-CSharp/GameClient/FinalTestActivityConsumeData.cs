using System;

namespace GameClient
{
	// Token: 0x02000F56 RID: 3926
	public class FinalTestActivityConsumeData : BaseActivityConsumeData, IActivityConsumeData
	{
		// Token: 0x06009895 RID: 39061 RVA: 0x001D585B File Offset: 0x001D3C5B
		public FinalTestActivityConsumeData(int id) : base(id)
		{
		}

		// Token: 0x06009896 RID: 39062 RVA: 0x001D5864 File Offset: 0x001D3C64
		public long GetLeftCount()
		{
			return (long)DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftCount();
		}

		// Token: 0x06009897 RID: 39063 RVA: 0x001D5871 File Offset: 0x001D3C71
		public long GetSumCount()
		{
			return (long)DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMaxCount();
		}

		// Token: 0x06009898 RID: 39064 RVA: 0x001D587E File Offset: 0x001D3C7E
		public bool IsCanBuyCount()
		{
			return false;
		}

		// Token: 0x06009899 RID: 39065 RVA: 0x001D5881 File Offset: 0x001D3C81
		public long GetLeftBuyCount()
		{
			return 0L;
		}

		// Token: 0x0600989A RID: 39066 RVA: 0x001D5885 File Offset: 0x001D3C85
		public long GetHasUsedCount()
		{
			return 0L;
		}

		// Token: 0x0600989B RID: 39067 RVA: 0x001D5889 File Offset: 0x001D3C89
		public long GetHasBuyCount()
		{
			return 0L;
		}

		// Token: 0x0600989C RID: 39068 RVA: 0x001D588D File Offset: 0x001D3C8D
		public int GetCostItemID()
		{
			return 0;
		}

		// Token: 0x0600989D RID: 39069 RVA: 0x001D5890 File Offset: 0x001D3C90
		public int GetCostItemCount()
		{
			return 0;
		}

		// Token: 0x0600989E RID: 39070 RVA: 0x001D5893 File Offset: 0x001D3C93
		public byte GetCostItemType()
		{
			return 0;
		}
	}
}
