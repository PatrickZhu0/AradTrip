using System;

namespace YIMEngine
{
	// Token: 0x02004A53 RID: 19027
	public class GiftMessage : MessageInfoBase
	{
		// Token: 0x1700249A RID: 9370
		// (get) Token: 0x0601B8F3 RID: 112883 RVA: 0x0087B418 File Offset: 0x00879818
		// (set) Token: 0x0601B8F4 RID: 112884 RVA: 0x0087B420 File Offset: 0x00879820
		public string Anchor
		{
			get
			{
				return this.strAnchor;
			}
			set
			{
				this.strAnchor = value;
			}
		}

		// Token: 0x1700249B RID: 9371
		// (get) Token: 0x0601B8F5 RID: 112885 RVA: 0x0087B429 File Offset: 0x00879829
		// (set) Token: 0x0601B8F6 RID: 112886 RVA: 0x0087B431 File Offset: 0x00879831
		public int GiftID
		{
			get
			{
				return this.iGiftID;
			}
			set
			{
				this.iGiftID = value;
			}
		}

		// Token: 0x1700249C RID: 9372
		// (get) Token: 0x0601B8F7 RID: 112887 RVA: 0x0087B43A File Offset: 0x0087983A
		// (set) Token: 0x0601B8F8 RID: 112888 RVA: 0x0087B442 File Offset: 0x00879842
		public ExtraGifParam ExtParam
		{
			get
			{
				return this.strParam;
			}
			set
			{
				this.strParam = value;
			}
		}

		// Token: 0x1700249D RID: 9373
		// (get) Token: 0x0601B8F9 RID: 112889 RVA: 0x0087B44B File Offset: 0x0087984B
		// (set) Token: 0x0601B8FA RID: 112890 RVA: 0x0087B453 File Offset: 0x00879853
		public int GiftCount
		{
			get
			{
				return this.iGiftCount;
			}
			set
			{
				this.iGiftCount = value;
			}
		}

		// Token: 0x04013214 RID: 78356
		private int iGiftCount;

		// Token: 0x04013215 RID: 78357
		private int iGiftID;

		// Token: 0x04013216 RID: 78358
		private ExtraGifParam strParam;

		// Token: 0x04013217 RID: 78359
		private string strAnchor;
	}
}
