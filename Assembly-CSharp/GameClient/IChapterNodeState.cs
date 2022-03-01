using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02000E9D RID: 3741
	public interface IChapterNodeState
	{
		// Token: 0x060093D5 RID: 37845
		void SetChapterState(eChapterNodeState[] state, int[] limitLevel);

		// Token: 0x060093D6 RID: 37846
		void SetChapterScore(DungeonScore[] score);
	}
}
