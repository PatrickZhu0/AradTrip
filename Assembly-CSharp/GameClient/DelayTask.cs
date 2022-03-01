using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02004588 RID: 17800
	public class DelayTask
	{
		// Token: 0x06018D8A RID: 101770 RVA: 0x007C59BA File Offset: 0x007C3DBA
		public DelayTask(float fStartTime, float fDelayTime, UnityAction callback)
		{
			this.fStartTime = fStartTime;
			this.fDelayTime = fDelayTime;
			this.callback = callback;
		}

		// Token: 0x06018D8B RID: 101771 RVA: 0x007C59D7 File Offset: 0x007C3DD7
		public void DoSomething()
		{
			if (this.callback != null)
			{
				this.callback.Invoke();
			}
		}

		// Token: 0x06018D8C RID: 101772 RVA: 0x007C59EF File Offset: 0x007C3DEF
		public bool CanExecuted()
		{
			return Time.time >= this.fStartTime + this.fDelayTime;
		}

		// Token: 0x04011E56 RID: 73302
		private float fStartTime;

		// Token: 0x04011E57 RID: 73303
		private float fDelayTime;

		// Token: 0x04011E58 RID: 73304
		private UnityAction callback;
	}
}
