using System;
using System.Diagnostics;
using UnityEngine;

namespace Spine.Unity.Playables
{
	// Token: 0x02004A1F RID: 18975
	public abstract class SpinePlayableHandleBase : MonoBehaviour
	{
		// Token: 0x17002453 RID: 9299
		// (get) Token: 0x0601B66A RID: 112234
		public abstract SkeletonData SkeletonData { get; }

		// Token: 0x17002454 RID: 9300
		// (get) Token: 0x0601B66B RID: 112235
		public abstract Skeleton Skeleton { get; }

		// Token: 0x14000086 RID: 134
		// (add) Token: 0x0601B66C RID: 112236 RVA: 0x008739E4 File Offset: 0x00871DE4
		// (remove) Token: 0x0601B66D RID: 112237 RVA: 0x00873A1C File Offset: 0x00871E1C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SpineEventDelegate AnimationEvents;

		// Token: 0x0601B66E RID: 112238 RVA: 0x00873A54 File Offset: 0x00871E54
		public virtual void HandleEvents(ExposedList<Event> eventBuffer)
		{
			if (eventBuffer == null || this.AnimationEvents == null)
			{
				return;
			}
			int i = 0;
			int count = eventBuffer.Count;
			while (i < count)
			{
				this.AnimationEvents(eventBuffer.Items[i]);
				i++;
			}
		}
	}
}
