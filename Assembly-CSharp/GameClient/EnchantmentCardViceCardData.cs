using System;

namespace GameClient
{
	// Token: 0x02004572 RID: 17778
	public class EnchantmentCardViceCardData : IComparable<EnchantmentCardViceCardData>
	{
		// Token: 0x06018CBD RID: 101565 RVA: 0x007BEFFC File Offset: 0x007BD3FC
		public int CompareTo(EnchantmentCardViceCardData other)
		{
			if (this.mAllSuccessRate != other.mAllSuccessRate)
			{
				return this.mAllSuccessRate - other.mAllSuccessRate;
			}
			if (this.mViceCardItemData.mPrecEnchantmentCard != null && other.mViceCardItemData.mPrecEnchantmentCard != null && this.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel != other.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel)
			{
				return this.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel - other.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel;
			}
			return this.mViceCardItemData.TableID - other.mViceCardItemData.TableID;
		}

		// Token: 0x04011DF0 RID: 73200
		public ItemData mViceCardItemData;

		// Token: 0x04011DF1 RID: 73201
		public int mAllSuccessRate;

		// Token: 0x04011DF2 RID: 73202
		public int mViceCardCount;

		// Token: 0x04011DF3 RID: 73203
		public int mConsumViceCardCount;
	}
}
