using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E9C RID: 3740
	public interface IChapterInfoDiffculte
	{
		// Token: 0x060093CC RID: 37836
		GameObject GetDiffculteRoot();

		// Token: 0x060093CD RID: 37837
		void SetActiveDiffculteByIdx(int idx, bool enable);

		// Token: 0x060093CE RID: 37838
		void SetLevelLimite(int[] limit);

		// Token: 0x060093CF RID: 37839
		void SetLevelDescription(string[] descs);

		// Token: 0x060093D0 RID: 37840
		void SetTopDiffculte(int top);

		// Token: 0x060093D1 RID: 37841
		int GetDiffculte();

		// Token: 0x060093D2 RID: 37842
		void SetDiffculte(int diff, int dungeonId);

		// Token: 0x060093D3 RID: 37843
		void SetDiffculteCallback(ChapterDiffCallback cb);

		// Token: 0x060093D4 RID: 37844
		void SetLock(bool isLock);
	}
}
