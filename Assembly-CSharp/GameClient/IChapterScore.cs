using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E9A RID: 3738
	public interface IChapterScore
	{
		// Token: 0x060093C2 RID: 37826
		GameObject GetScoreRoot();

		// Token: 0x060093C3 RID: 37827
		void SetHitCount(int cnt);

		// Token: 0x060093C4 RID: 37828
		void SetRebornCount(int cnt);

		// Token: 0x060093C5 RID: 37829
		void SetFightTime(int time);

		// Token: 0x060093C6 RID: 37830
		void SetPassed(bool isPass);

		// Token: 0x060093C7 RID: 37831
		void SetBestScore(DungeonScore score);
	}
}
