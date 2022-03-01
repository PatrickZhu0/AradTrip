using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameClient
{
	// Token: 0x02000EB2 RID: 3762
	public class ComDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
	{
		// Token: 0x06009469 RID: 37993 RVA: 0x001BD25C File Offset: 0x001BB65C
		public void OnBeginDrag(PointerEventData eventData)
		{
			this.OnBeginDragEvent.Invoke(this);
			if (this.DragObject == null)
			{
				Logger.LogError("ComDrag DragObject is null!");
				return;
			}
			if (string.IsNullOrEmpty(this.Name))
			{
				Logger.LogError("ComDrag Name is null!");
				return;
			}
			Canvas canvas = ComDrag.FindInParents<Canvas>(base.gameObject);
			if (canvas == null)
			{
				Logger.LogError("ComDrag canvas is null!");
				return;
			}
			this.DragObject.transform.SetParent(canvas.transform, false);
			CanvasGroup canvasGroup = this.DragObject.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = this.DragObject.AddComponent<CanvasGroup>();
			}
			canvasGroup.blocksRaycasts = false;
			this.m_sourceRect = (canvas.transform as RectTransform);
			this.m_dragRect = (this.DragObject.transform as RectTransform);
			this._UpdateDragObjectPos(eventData);
		}

		// Token: 0x0600946A RID: 37994 RVA: 0x001BD33F File Offset: 0x001BB73F
		public void OnDrag(PointerEventData eventData)
		{
			if (this.m_sourceRect != null && this.m_dragRect != null)
			{
				this._UpdateDragObjectPos(eventData);
			}
		}

		// Token: 0x0600946B RID: 37995 RVA: 0x001BD36A File Offset: 0x001BB76A
		public void OnEndDrag(PointerEventData eventData)
		{
			this.OnEndDragEvent.Invoke(this);
			this.m_dragRect = null;
			this.m_sourceRect = null;
		}

		// Token: 0x0600946C RID: 37996 RVA: 0x001BD388 File Offset: 0x001BB788
		public static T FindInParents<T>(GameObject go) where T : Component
		{
			if (go == null)
			{
				return (T)((object)null);
			}
			T component = go.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			Transform parent = go.transform.parent;
			while (parent != null && component == null)
			{
				component = parent.gameObject.GetComponent<T>();
				parent = parent.parent;
			}
			return component;
		}

		// Token: 0x0600946D RID: 37997 RVA: 0x001BD404 File Offset: 0x001BB804
		private void _UpdateDragObjectPos(PointerEventData eventData)
		{
			Vector3 position;
			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_sourceRect, eventData.position, eventData.pressEventCamera, ref position))
			{
				this.m_dragRect.position = position;
			}
		}

		// Token: 0x04004B2D RID: 19245
		public GameObject DragObject;

		// Token: 0x04004B2E RID: 19246
		public string Name = "Default";

		// Token: 0x04004B2F RID: 19247
		public OnBeginDragEvent OnBeginDragEvent = new OnBeginDragEvent();

		// Token: 0x04004B30 RID: 19248
		public OnEndDragEvent OnEndDragEvent = new OnEndDragEvent();

		// Token: 0x04004B31 RID: 19249
		private RectTransform m_dragRect;

		// Token: 0x04004B32 RID: 19250
		private RectTransform m_sourceRect;
	}
}
