using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012A1 RID: 4769
	public class JarBuyInfo
	{
		// Token: 0x17001AF9 RID: 6905
		// (get) Token: 0x0600B78D RID: 46989 RVA: 0x0029EBAA File Offset: 0x0029CFAA
		// (set) Token: 0x0600B78E RID: 46990 RVA: 0x0029EBB2 File Offset: 0x0029CFB2
		public virtual int nFreeTimestamp { get; set; }

		// Token: 0x17001AFA RID: 6906
		// (get) Token: 0x0600B78F RID: 46991 RVA: 0x0029EBBB File Offset: 0x0029CFBB
		// (set) Token: 0x0600B790 RID: 46992 RVA: 0x0029EBC3 File Offset: 0x0029CFC3
		public virtual int nFreeCount { get; set; }

		// Token: 0x0400677F RID: 26495
		public int nBuyCount;

		// Token: 0x04006780 RID: 26496
		public int nMaxFreeCount;

		// Token: 0x04006781 RID: 26497
		public int nFreeCD;

		// Token: 0x04006784 RID: 26500
		public List<JarBuyCost> arrCosts;
	}
}
