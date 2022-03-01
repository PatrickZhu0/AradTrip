using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AD8 RID: 6872
	[Serializable]
	public class EffectProcessConfig
	{
		// Token: 0x0400AD35 RID: 44341
		public int index;

		// Token: 0x0400AD36 RID: 44342
		public float start;

		// Token: 0x0400AD37 RID: 44343
		public float len = 1f;

		// Token: 0x0400AD38 RID: 44344
		public UnityEvent onActionStart;

		// Token: 0x0400AD39 RID: 44345
		public UnityEvent onActionEnd;
	}
}
