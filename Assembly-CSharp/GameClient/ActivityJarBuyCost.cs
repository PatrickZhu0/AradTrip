using System;

namespace GameClient
{
	// Token: 0x020012A0 RID: 4768
	public class ActivityJarBuyCost : JarBuyCost
	{
		// Token: 0x17001AF7 RID: 6903
		// (get) Token: 0x0600B788 RID: 46984 RVA: 0x0029EB48 File Offset: 0x0029CF48
		// (set) Token: 0x0600B789 RID: 46985 RVA: 0x0029EB50 File Offset: 0x0029CF50
		public int nJarID
		{
			get
			{
				return this.m_nJarID;
			}
			set
			{
				this.m_nJarID = value;
				this.m_strRemainTimeKey = string.Format("jar_buy_dis_remain_{0}", this.m_nJarID);
			}
		}

		// Token: 0x17001AF8 RID: 6904
		// (get) Token: 0x0600B78A RID: 46986 RVA: 0x0029EB74 File Offset: 0x0029CF74
		// (set) Token: 0x0600B78B RID: 46987 RVA: 0x0029EB99 File Offset: 0x0029CF99
		public override int nRemainDiscountTime
		{
			get
			{
				if (this.m_nRemainDiscountTime < 0)
				{
					return this.m_nRemainDiscountTime;
				}
				return DataManager<CountDataManager>.GetInstance().GetCount(this.m_strRemainTimeKey);
			}
			set
			{
				this.m_nRemainDiscountTime = value;
			}
		}

		// Token: 0x0400677C RID: 26492
		protected int m_nJarID;

		// Token: 0x0400677D RID: 26493
		protected int m_nRemainDiscountTime = -1;

		// Token: 0x0400677E RID: 26494
		protected string m_strRemainTimeKey;
	}
}
