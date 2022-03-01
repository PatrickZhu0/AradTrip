using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000042 RID: 66
	internal class ComMagicCardMergeAnimation : MonoBehaviour
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000EFB8 File Offset: 0x0000D3B8
		public float eventsLength
		{
			get
			{
				float num = 0f;
				if (this.events != null)
				{
					for (int i = 0; i < this.events.Count; i++)
					{
						if (this.events[i] != null)
						{
							num += this.events[i].time;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000F018 File Offset: 0x0000D418
		public void AppendEvent(MergeStep mergeStep)
		{
			MergeStep mergeStep2 = this.events.Find((MergeStep x) => mergeStep.stepId == x.stepId);
			if (mergeStep2 == null)
			{
				this.events.Add(mergeStep);
			}
			else
			{
				this.events.Remove(mergeStep2);
				this.events.Add(mergeStep);
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000F084 File Offset: 0x0000D484
		private void Start()
		{
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000F088 File Offset: 0x0000D488
		public void TriggerEvents()
		{
			InvokeMethod.RemoveInvokeCall(this);
			float num = 0f;
			for (int i = 0; i < this.events.Count; i++)
			{
				MergeStep curEvent = this.events[i];
				if (curEvent != null && curEvent.onEvent != null)
				{
					InvokeMethod.Invoke(this, num, delegate()
					{
						curEvent.onEvent.Invoke();
					});
					num += curEvent.time;
				}
			}
		}

		// Token: 0x0400018C RID: 396
		public List<MergeStep> events = new List<MergeStep>();
	}
}
