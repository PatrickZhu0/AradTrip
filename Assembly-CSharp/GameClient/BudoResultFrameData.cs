using System;

namespace GameClient
{
	// Token: 0x020014AB RID: 5291
	internal class BudoResultFrameData
	{
		// Token: 0x04007782 RID: 30594
		public bool bNeedOpenBudoInfo;

		// Token: 0x04007783 RID: 30595
		public bool bOver;

		// Token: 0x04007784 RID: 30596
		public PKResult eResult = PKResult.DRAW;

		// Token: 0x04007785 RID: 30597
		public BudoResultFrameData.OnClose onClose;

		// Token: 0x04007786 RID: 30598
		public bool bDebug;

		// Token: 0x020014AC RID: 5292
		// (Invoke) Token: 0x0600CD1F RID: 52511
		public delegate void OnClose();
	}
}
