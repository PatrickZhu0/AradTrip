using System;

namespace LimitTimeGift
{
	// Token: 0x02001732 RID: 5938
	public class LimitTimeGiftAwardData
	{
		// Token: 0x0600E985 RID: 59781 RVA: 0x003DCEBC File Offset: 0x003DB2BC
		public LimitTimeGiftAwardData()
		{
			this.Reset();
		}

		// Token: 0x17001CDB RID: 7387
		// (get) Token: 0x0600E986 RID: 59782 RVA: 0x003DCECA File Offset: 0x003DB2CA
		// (set) Token: 0x0600E987 RID: 59783 RVA: 0x003DCED2 File Offset: 0x003DB2D2
		public uint AwardId
		{
			get
			{
				return this.awardId;
			}
			set
			{
				this.awardId = value;
			}
		}

		// Token: 0x17001CDC RID: 7388
		// (get) Token: 0x0600E988 RID: 59784 RVA: 0x003DCEDB File Offset: 0x003DB2DB
		// (set) Token: 0x0600E989 RID: 59785 RVA: 0x003DCEE3 File Offset: 0x003DB2E3
		public uint AwardCount
		{
			get
			{
				return this.awardCount;
			}
			set
			{
				this.awardCount = value;
			}
		}

		// Token: 0x17001CDD RID: 7389
		// (get) Token: 0x0600E98A RID: 59786 RVA: 0x003DCEEC File Offset: 0x003DB2EC
		// (set) Token: 0x0600E98B RID: 59787 RVA: 0x003DCEF4 File Offset: 0x003DB2F4
		public int StrengthLevel
		{
			get
			{
				return this.strengthLevel;
			}
			set
			{
				this.strengthLevel = value;
			}
		}

		// Token: 0x0600E98C RID: 59788 RVA: 0x003DCEFD File Offset: 0x003DB2FD
		public void Reset()
		{
			this.awardId = 0U;
			this.awardCount = 0U;
			this.strengthLevel = 0;
		}

		// Token: 0x04008D87 RID: 36231
		private uint awardId;

		// Token: 0x04008D88 RID: 36232
		private uint awardCount;

		// Token: 0x04008D89 RID: 36233
		private int strengthLevel;
	}
}
