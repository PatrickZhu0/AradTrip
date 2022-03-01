using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000041 RID: 65
	[Serializable]
	public class MergeStep
	{
		// Token: 0x04000189 RID: 393
		public UnityEvent onEvent;

		// Token: 0x0400018A RID: 394
		public float time;

		// Token: 0x0400018B RID: 395
		public int stepId;
	}
}
