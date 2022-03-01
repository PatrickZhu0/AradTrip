using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020045E4 RID: 17892
public class ClipScrollrect : ScrollRect
{
	// Token: 0x060192A8 RID: 103080 RVA: 0x007F4C5B File Offset: 0x007F305B
	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		if (this.onEndDrag != null)
		{
			this.onEndDrag.Invoke(eventData);
		}
	}

	// Token: 0x04012066 RID: 73830
	public ClipScrollrect.ClipScrollrectEvent onEndDrag = new ClipScrollrect.ClipScrollrectEvent();

	// Token: 0x020045E5 RID: 17893
	public class ClipScrollrectEvent : UnityEvent<PointerEventData>
	{
	}
}
