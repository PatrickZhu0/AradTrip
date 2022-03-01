using System;

namespace GameClient
{
	// Token: 0x020010F0 RID: 4336
	public class BaseClientFrameStackCmd
	{
		// Token: 0x0600A44C RID: 42060 RVA: 0x0021C887 File Offset: 0x0021AC87
		protected BaseClientFrameStackCmd(eClientFrameStackCmd type)
		{
			this.mType = type;
		}

		// Token: 0x0600A44D RID: 42061 RVA: 0x0021C896 File Offset: 0x0021AC96
		public eClientFrameStackCmd CmdType()
		{
			return this.mType;
		}

		// Token: 0x04005BDA RID: 23514
		protected eClientFrameStackCmd mType;
	}
}
