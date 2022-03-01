using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001B1A RID: 6938
	public class ComDelayInvoke : MonoBehaviour
	{
		// Token: 0x0601107F RID: 69759 RVA: 0x004E00D9 File Offset: 0x004DE4D9
		public void ClearAllInvokes()
		{
			InvokeMethod.RemoveInvokeCall(this);
			this.mDirty = false;
		}

		// Token: 0x06011080 RID: 69760 RVA: 0x004E00E8 File Offset: 0x004DE4E8
		public void AddAllInvokes()
		{
			this.mDirty = true;
		}

		// Token: 0x06011081 RID: 69761 RVA: 0x004E00F1 File Offset: 0x004DE4F1
		private void OnDestroy()
		{
			this.ClearAllInvokes();
		}

		// Token: 0x06011082 RID: 69762 RVA: 0x004E00FC File Offset: 0x004DE4FC
		private void Update()
		{
			if (!this.mDirty)
			{
				return;
			}
			InvokeMethod.RemoveInvokeCall(this);
			for (int i = 0; i < this.actions.Length; i++)
			{
				if (this.actions[i] != null)
				{
					UnityEvent action = this.actions[i].action;
					InvokeMethod.Invoke(this, this.actions[i].time, delegate()
					{
						if (action != null)
						{
							action.Invoke();
						}
					});
				}
			}
			this.mDirty = false;
		}

		// Token: 0x0400AF50 RID: 44880
		public DelayAction[] actions = new DelayAction[0];

		// Token: 0x0400AF51 RID: 44881
		private bool mDirty;
	}
}
