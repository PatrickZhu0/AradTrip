using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E95 RID: 3733
	public interface IChapterProcess
	{
		// Token: 0x060093B5 RID: 37813
		GameObject GetProcessRoot();

		// Token: 0x060093B6 RID: 37814
		void SetProcess(int id, int[] presList);
	}
}
