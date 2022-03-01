using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000045 RID: 69
	public class ComMonoBehaviorCallBack : MonoBehaviour
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000F311 File Offset: 0x0000D711
		private void OnEnable()
		{
			if (this.onMonoBehaviorEnable != null)
			{
				this.onMonoBehaviorEnable.Invoke();
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000F329 File Offset: 0x0000D729
		private void OnDisable()
		{
			if (this.onMonoBehaviorDisable != null)
			{
				this.onMonoBehaviorDisable.Invoke();
			}
		}

		// Token: 0x04000197 RID: 407
		public UnityEvent onMonoBehaviorEnable;

		// Token: 0x04000198 RID: 408
		public UnityEvent onMonoBehaviorDisable;
	}
}
