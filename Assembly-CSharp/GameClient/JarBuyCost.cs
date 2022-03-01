using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200129F RID: 4767
	public class JarBuyCost
	{
		// Token: 0x17001AF6 RID: 6902
		// (get) Token: 0x0600B784 RID: 46980 RVA: 0x0029EA54 File Offset: 0x0029CE54
		// (set) Token: 0x0600B785 RID: 46981 RVA: 0x0029EA5C File Offset: 0x0029CE5C
		public virtual int nRemainDiscountTime { get; set; }

		// Token: 0x0600B786 RID: 46982 RVA: 0x0029EA68 File Offset: 0x0029CE68
		public int GetRealCostCount(int a_nBuyCount)
		{
			float num = 1f;
			int num2;
			int num3;
			if (this.nRemainDiscountTime < 0)
			{
				num2 = a_nBuyCount;
				num3 = 0;
			}
			else if (this.nRemainDiscountTime > 0)
			{
				if (this.nRemainDiscountTime >= a_nBuyCount)
				{
					if (a_nBuyCount == 1)
					{
						num2 = a_nBuyCount;
						num3 = 0;
						num = 1f;
					}
					else
					{
						num2 = a_nBuyCount;
						num3 = 0;
						num = 0.9f;
					}
				}
				else
				{
					num2 = this.nRemainDiscountTime;
					num3 = a_nBuyCount - this.nRemainDiscountTime;
					num = 0.9f;
				}
			}
			else if (a_nBuyCount == 1)
			{
				num2 = 0;
				num3 = a_nBuyCount;
				num = 1f;
			}
			else
			{
				num2 = 0;
				num3 = a_nBuyCount;
				num = 0.9f;
			}
			return Mathf.FloorToInt(((float)(num2 * this.item.Count) * this.fDiscount + (float)(num3 * this.item.Count)) * num);
		}

		// Token: 0x04006778 RID: 26488
		public float fDiscount;

		// Token: 0x0400677A RID: 26490
		public bool bDisTimeReset;

		// Token: 0x0400677B RID: 26491
		public ItemData item;
	}
}
