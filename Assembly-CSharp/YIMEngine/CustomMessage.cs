using System;

namespace YIMEngine
{
	// Token: 0x02004A51 RID: 19025
	public class CustomMessage : MessageInfoBase
	{
		// Token: 0x17002494 RID: 9364
		// (get) Token: 0x0601B8E5 RID: 112869 RVA: 0x0087B3A2 File Offset: 0x008797A2
		// (set) Token: 0x0601B8E6 RID: 112870 RVA: 0x0087B3AA File Offset: 0x008797AA
		public byte[] Content
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

		// Token: 0x0401320E RID: 78350
		private byte[] strContent;
	}
}
