using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02001001 RID: 4097
public class DragGuideCom : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
{
	// Token: 0x06009BCF RID: 39887 RVA: 0x001E66BC File Offset: 0x001E4ABC
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.eventOnBeginDrag != null)
		{
			this.eventOnBeginDrag(eventData);
		}
	}

	// Token: 0x06009BD0 RID: 39888 RVA: 0x001E66D5 File Offset: 0x001E4AD5
	public void OnDrag(PointerEventData eventData)
	{
		if (this.eventOnDrag != null)
		{
			this.eventOnDrag(eventData);
		}
	}

	// Token: 0x06009BD1 RID: 39889 RVA: 0x001E66EE File Offset: 0x001E4AEE
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.eventOnEndDrag != null)
		{
			this.eventOnEndDrag(eventData);
		}
	}

	// Token: 0x0400552C RID: 21804
	public Action<PointerEventData> eventOnBeginDrag;

	// Token: 0x0400552D RID: 21805
	public Action<PointerEventData> eventOnDrag;

	// Token: 0x0400552E RID: 21806
	public Action<PointerEventData> eventOnEndDrag;
}
