using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000E27 RID: 3623
	public class CommonSetContentDataModel
	{
		// Token: 0x0400483B RID: 18491
		public string TitleStr;

		// Token: 0x0400483C RID: 18492
		public string DefaultEmptyStr;

		// Token: 0x0400483D RID: 18493
		public string DefaultContentStr;

		// Token: 0x0400483E RID: 18494
		public int MaxWordNumber;

		// Token: 0x0400483F RID: 18495
		public UnityAction<string> OnOkClicked;
	}
}
