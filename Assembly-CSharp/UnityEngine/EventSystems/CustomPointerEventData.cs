using System;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000FAF RID: 4015
	public class CustomPointerEventData : PointerEventData
	{
		// Token: 0x06009AB5 RID: 39605 RVA: 0x001DE9DF File Offset: 0x001DCDDF
		public CustomPointerEventData(EventSystem ev) : base(ev)
		{
		}

		// Token: 0x06009AB6 RID: 39606 RVA: 0x001DE9E8 File Offset: 0x001DCDE8
		public void CopyFrom(PointerEventData src)
		{
			base.eligibleForClick = src.eligibleForClick;
			base.pointerId = src.pointerId;
			base.position = src.position;
			base.delta = src.delta;
			base.pressPosition = src.pressPosition;
			base.clickTime = src.clickTime;
			base.clickCount = src.clickCount;
			base.scrollDelta = src.scrollDelta;
			base.useDragThreshold = src.useDragThreshold;
			base.dragging = src.dragging;
			base.button = src.button;
		}

		// Token: 0x04005045 RID: 20549
		public int customData;
	}
}
