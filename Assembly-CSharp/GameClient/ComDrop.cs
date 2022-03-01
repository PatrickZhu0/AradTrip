using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameClient
{
	// Token: 0x02000EB6 RID: 3766
	public class ComDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x06009472 RID: 38002 RVA: 0x001BD488 File Offset: 0x001BB888
		public void OnDrop(PointerEventData data)
		{
			GameObject pointerDrag = data.pointerDrag;
			if (pointerDrag == null)
			{
				return;
			}
			ComDrag component = pointerDrag.GetComponent<ComDrag>();
			if (component == null)
			{
				return;
			}
			if (this.AcceptDragName != component.Name)
			{
				return;
			}
			this.OnDropEvent.Invoke(this, component);
		}

		// Token: 0x06009473 RID: 38003 RVA: 0x001BD4E4 File Offset: 0x001BB8E4
		public void OnPointerEnter(PointerEventData data)
		{
			GameObject pointerDrag = data.pointerDrag;
			if (pointerDrag == null)
			{
				return;
			}
			ComDrag component = pointerDrag.GetComponent<ComDrag>();
			if (component == null)
			{
				return;
			}
			if (this.AcceptDragName != component.Name)
			{
				return;
			}
			this.OnEnterEvent.Invoke(this, component);
		}

		// Token: 0x06009474 RID: 38004 RVA: 0x001BD540 File Offset: 0x001BB940
		public void OnPointerExit(PointerEventData data)
		{
			GameObject pointerDrag = data.pointerDrag;
			if (pointerDrag == null)
			{
				return;
			}
			ComDrag component = pointerDrag.GetComponent<ComDrag>();
			if (component == null)
			{
				return;
			}
			if (this.AcceptDragName != component.Name)
			{
				return;
			}
			this.OnExitEvent.Invoke(this, component);
		}

		// Token: 0x04004B33 RID: 19251
		public string AcceptDragName = "Default";

		// Token: 0x04004B34 RID: 19252
		public OnDropEvent OnDropEvent = new OnDropEvent();

		// Token: 0x04004B35 RID: 19253
		public OnEnterEvent OnEnterEvent = new OnEnterEvent();

		// Token: 0x04004B36 RID: 19254
		public OnExitEvent OnExitEvent = new OnExitEvent();
	}
}
