using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AF1 RID: 6897
	public class ToggleEvent
	{
		// Token: 0x06010ED6 RID: 69334 RVA: 0x004D5979 File Offset: 0x004D3D79
		public ToggleEvent(string tempText, UnityAction tempEvent)
		{
			this.toggleText = tempText;
			this.toggleEvent = tempEvent;
		}

		// Token: 0x0400ADFF RID: 44543
		public string toggleText;

		// Token: 0x0400AE00 RID: 44544
		public UnityAction toggleEvent;
	}
}
