using System;

namespace GameClient
{
	// Token: 0x0200188D RID: 6285
	public sealed class FashionDiscountActivityView : FashionActivityView
	{
		// Token: 0x0600F5F5 RID: 62965 RVA: 0x00425B71 File Offset: 0x00423F71
		protected override void UpdateTime()
		{
			this.mTextTime.SafeSetText(string.Format(TR.Value("activity_discount_fashion_time"), Function.GetDateTime((int)this.mModel.StartTime, (int)this.mModel.EndTime)));
		}
	}
}
