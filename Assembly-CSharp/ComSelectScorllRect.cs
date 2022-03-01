using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02001942 RID: 6466
public class ComSelectScorllRect : ScrollRect, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x17001D0B RID: 7435
	// (get) Token: 0x0600FB5D RID: 64349 RVA: 0x0044DE8C File Offset: 0x0044C28C
	// (set) Token: 0x0600FB5E RID: 64350 RVA: 0x0044DE94 File Offset: 0x0044C294
	public GameObject SelectedGameObject { get; set; }

	// Token: 0x0600FB5F RID: 64351 RVA: 0x0044DE9D File Offset: 0x0044C29D
	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		if (this.SelectedGameObject)
		{
			this.SelectedGameObject.CustomActive(true);
		}
	}

	// Token: 0x0600FB60 RID: 64352 RVA: 0x0044DEC2 File Offset: 0x0044C2C2
	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		if (this.SelectedGameObject)
		{
			this.SelectedGameObject.CustomActive(false);
		}
	}

	// Token: 0x0600FB61 RID: 64353 RVA: 0x0044DEE7 File Offset: 0x0044C2E7
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.SelectedGameObject)
		{
			this.SelectedGameObject.CustomActive(false);
		}
	}

	// Token: 0x0600FB62 RID: 64354 RVA: 0x0044DF05 File Offset: 0x0044C305
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.SelectedGameObject)
		{
			this.SelectedGameObject.CustomActive(true);
		}
	}
}
