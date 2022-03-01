using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02001002 RID: 4098
public class DropGuideCom : MonoBehaviour, IDropHandler, IEventSystemHandler
{
	// Token: 0x06009BD3 RID: 39891 RVA: 0x001E670F File Offset: 0x001E4B0F
	public void OnDrop(PointerEventData eventData)
	{
		if (this.eventOnDrop != null)
		{
			this.eventOnDrop(eventData);
		}
	}

	// Token: 0x0400552F RID: 21807
	public Action<PointerEventData> eventOnDrop;
}
