using System;

namespace YIMEngine
{
	// Token: 0x02004A54 RID: 19028
	public class VoiceMessage : MessageInfoBase
	{
		// Token: 0x1700249E RID: 9374
		// (get) Token: 0x0601B8FC RID: 112892 RVA: 0x0087B464 File Offset: 0x00879864
		// (set) Token: 0x0601B8FD RID: 112893 RVA: 0x0087B46C File Offset: 0x0087986C
		public int Duration
		{
			get
			{
				return this.iDuration;
			}
			set
			{
				this.iDuration = value;
			}
		}

		// Token: 0x1700249F RID: 9375
		// (get) Token: 0x0601B8FE RID: 112894 RVA: 0x0087B475 File Offset: 0x00879875
		// (set) Token: 0x0601B8FF RID: 112895 RVA: 0x0087B47D File Offset: 0x0087987D
		public string Text
		{
			get
			{
				return this.strText;
			}
			set
			{
				this.strText = value;
			}
		}

		// Token: 0x170024A0 RID: 9376
		// (get) Token: 0x0601B900 RID: 112896 RVA: 0x0087B486 File Offset: 0x00879886
		// (set) Token: 0x0601B901 RID: 112897 RVA: 0x0087B48E File Offset: 0x0087988E
		public string Param
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

		// Token: 0x04013218 RID: 78360
		private string strText;

		// Token: 0x04013219 RID: 78361
		private string strParam;

		// Token: 0x0401321A RID: 78362
		private int iDuration;
	}
}
