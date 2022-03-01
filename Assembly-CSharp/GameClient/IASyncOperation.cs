using System;

namespace GameClient
{
	// Token: 0x02000DD2 RID: 3538
	public interface IASyncOperation
	{
		// Token: 0x06008EF7 RID: 36599
		void SetProgress(float progress);

		// Token: 0x06008EF8 RID: 36600
		float GetProgress();

		// Token: 0x06008EF9 RID: 36601
		void SetError(string ErrorMsg);

		// Token: 0x06008EFA RID: 36602
		string GetErrorMessage();

		// Token: 0x06008EFB RID: 36603
		bool IsError();

		// Token: 0x06008EFC RID: 36604
		void SetProgressInfo(string info);
	}
}
