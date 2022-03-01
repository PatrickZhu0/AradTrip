using System;

namespace GameClient
{
	// Token: 0x02000E1A RID: 3610
	public class CommonMsgBoxCancelOKParams
	{
		// Token: 0x06009080 RID: 36992 RVA: 0x001AB4B0 File Offset: 0x001A98B0
		public CommonMsgBoxCancelOKParams()
		{
			this.ResetData();
		}

		// Token: 0x06009081 RID: 36993 RVA: 0x001AB4BE File Offset: 0x001A98BE
		public void ResetData()
		{
			this.closeFrameOnCancelBtnCDEnd = true;
			this.showCancelBtnGrayOnCDEnd = false;
		}

		// Token: 0x040047D0 RID: 18384
		public bool closeFrameOnCancelBtnCDEnd;

		// Token: 0x040047D1 RID: 18385
		public bool showCancelBtnGrayOnCDEnd;
	}
}
