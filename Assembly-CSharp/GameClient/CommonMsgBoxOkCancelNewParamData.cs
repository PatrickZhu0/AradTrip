using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E1F RID: 3615
	public class CommonMsgBoxOkCancelNewParamData
	{
		// Token: 0x04004810 RID: 18448
		public string ContentLabel;

		// Token: 0x04004811 RID: 18449
		public TextAnchor ContentTextAnchor = 4;

		// Token: 0x04004812 RID: 18450
		public bool IsShowNotify;

		// Token: 0x04004813 RID: 18451
		public bool IsDefaultCheck;

		// Token: 0x04004814 RID: 18452
		public OnCommonMsgBoxToggleClick OnCommonMsgBoxToggleClick;

		// Token: 0x04004815 RID: 18453
		public string LeftButtonText;

		// Token: 0x04004816 RID: 18454
		public Action OnLeftButtonClickCallBack;

		// Token: 0x04004817 RID: 18455
		public string RightButtonText;

		// Token: 0x04004818 RID: 18456
		public Action OnRightButtonClickCallBack;

		// Token: 0x04004819 RID: 18457
		public string MiddleButtonText;

		// Token: 0x0400481A RID: 18458
		public Action OnMiddleButtonClickCallBack;

		// Token: 0x0400481B RID: 18459
		public bool IsMiddleButton;

		// Token: 0x0400481C RID: 18460
		public bool IsSetContentFontSize;

		// Token: 0x0400481D RID: 18461
		public int ContentFontSize;
	}
}
