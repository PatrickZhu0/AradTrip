using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200001B RID: 27
public class CloseMedicinebar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06000094 RID: 148 RVA: 0x00007EC7 File Offset: 0x000062C7
	public void Update()
	{
		if (this.isOpen)
		{
			ComDrugTipsBar.instance.SetDrugColumnStat();
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00007EDE File Offset: 0x000062DE
	public void OnPointerDown(PointerEventData eventData)
	{
		this.isOpen = true;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00007EE7 File Offset: 0x000062E7
	public void OnPointerUp(PointerEventData eventData)
	{
		this.isOpen = false;
	}

	// Token: 0x0400006D RID: 109
	private bool isOpen;
}
