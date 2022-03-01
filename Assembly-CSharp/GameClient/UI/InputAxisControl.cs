using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient.UI
{
	// Token: 0x02000F8D RID: 3981
	[AddComponentMenu("UI/InputAxisControl", 40)]
	[RequireComponent(typeof(RectTransform))]
	public class InputAxisControl : Selectable, IBeginDragHandler, IDragHandler, IInitializePotentialDragHandler, IEventSystemHandler
	{
		// Token: 0x06009A01 RID: 39425 RVA: 0x001D9F02 File Offset: 0x001D8302
		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		// Token: 0x06009A02 RID: 39426 RVA: 0x001D9F0B File Offset: 0x001D830B
		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		// Token: 0x06009A03 RID: 39427 RVA: 0x001D9F0D File Offset: 0x001D830D
		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
