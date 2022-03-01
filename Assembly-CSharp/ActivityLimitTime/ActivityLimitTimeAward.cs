using System;

namespace ActivityLimitTime
{
	// Token: 0x020011BB RID: 4539
	public class ActivityLimitTimeAward
	{
		// Token: 0x0600AE3E RID: 44606 RVA: 0x0025FB6D File Offset: 0x0025DF6D
		public ActivityLimitTimeAward()
		{
			this.Reset();
		}

		// Token: 0x17001A8F RID: 6799
		// (get) Token: 0x0600AE3F RID: 44607 RVA: 0x0025FB7B File Offset: 0x0025DF7B
		// (set) Token: 0x0600AE40 RID: 44608 RVA: 0x0025FB83 File Offset: 0x0025DF83
		public uint Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		// Token: 0x17001A90 RID: 6800
		// (get) Token: 0x0600AE41 RID: 44609 RVA: 0x0025FB8C File Offset: 0x0025DF8C
		// (set) Token: 0x0600AE42 RID: 44610 RVA: 0x0025FB94 File Offset: 0x0025DF94
		public int Num
		{
			get
			{
				return this.num;
			}
			set
			{
				this.num = value;
			}
		}

		// Token: 0x17001A91 RID: 6801
		// (get) Token: 0x0600AE43 RID: 44611 RVA: 0x0025FB9D File Offset: 0x0025DF9D
		// (set) Token: 0x0600AE44 RID: 44612 RVA: 0x0025FBA5 File Offset: 0x0025DFA5
		public byte Strenth
		{
			get
			{
				return this.strenth;
			}
			set
			{
				this.strenth = value;
			}
		}

		// Token: 0x0600AE45 RID: 44613 RVA: 0x0025FBAE File Offset: 0x0025DFAE
		public void Reset()
		{
			this.id = 0U;
			this.num = 0;
			this.strenth = 0;
		}

		// Token: 0x04006184 RID: 24964
		private uint id;

		// Token: 0x04006185 RID: 24965
		private int num;

		// Token: 0x04006186 RID: 24966
		private byte strenth;
	}
}
