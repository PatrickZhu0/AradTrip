using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000F0B RID: 3851
	internal class ComObjectClicked : MonoBehaviour
	{
		// Token: 0x0600965D RID: 38493 RVA: 0x001C75D8 File Offset: 0x001C59D8
		private void OnMouseDown()
		{
			this.OnClicked.Invoke();
		}

		// Token: 0x04004D32 RID: 19762
		public ComObjectClicked.ClickEvent OnClicked = new ComObjectClicked.ClickEvent();

		// Token: 0x02000F0C RID: 3852
		public class ClickEvent : UnityEvent
		{
		}
	}
}
