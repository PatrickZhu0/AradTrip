using System;

namespace YIMEngine
{
	// Token: 0x02004A50 RID: 19024
	public class TextMessage : MessageInfoBase
	{
		// Token: 0x17002492 RID: 9362
		// (get) Token: 0x0601B8E0 RID: 112864 RVA: 0x0087B378 File Offset: 0x00879778
		// (set) Token: 0x0601B8E1 RID: 112865 RVA: 0x0087B380 File Offset: 0x00879780
		public string Content
		{
			get
			{
				return this.strContent;
			}
			set
			{
				this.strContent = value;
			}
		}

		// Token: 0x17002493 RID: 9363
		// (get) Token: 0x0601B8E2 RID: 112866 RVA: 0x0087B389 File Offset: 0x00879789
		// (set) Token: 0x0601B8E3 RID: 112867 RVA: 0x0087B391 File Offset: 0x00879791
		public string AttachParam
		{
			get
			{
				return this.strAttachParam;
			}
			set
			{
				this.strAttachParam = value;
			}
		}

		// Token: 0x0401320C RID: 78348
		private string strContent;

		// Token: 0x0401320D RID: 78349
		private string strAttachParam;
	}
}
