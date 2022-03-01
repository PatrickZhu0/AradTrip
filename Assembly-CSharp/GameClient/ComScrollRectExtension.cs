using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F42 RID: 3906
	public class ComScrollRectExtension : ScrollRect
	{
		// Token: 0x060097FE RID: 38910 RVA: 0x001D26C9 File Offset: 0x001D0AC9
		public override void OnEndDrag(PointerEventData eventData)
		{
			if (this.onDragEnd != null)
			{
				this.onDragEnd.Invoke();
			}
			base.OnEndDrag(eventData);
		}

		// Token: 0x04004E70 RID: 20080
		public ComScrollRectExtension.ScrollRectDragEndEvent onDragEnd = new ComScrollRectExtension.ScrollRectDragEndEvent();

		// Token: 0x02000F43 RID: 3907
		[Serializable]
		public class ScrollRectDragEndEvent : UnityEvent
		{
		}
	}
}
