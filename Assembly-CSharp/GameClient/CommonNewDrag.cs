using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameClient
{
	// Token: 0x02000DF6 RID: 3574
	public class CommonNewDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
	{
		// Token: 0x06008F84 RID: 36740 RVA: 0x001A8E32 File Offset: 0x001A7232
		public void SetIsCanBeginDragAction(IsCanBeginDragAction isCanBeginDragAction)
		{
			this._isCanBeginDragAction = isCanBeginDragAction;
		}

		// Token: 0x06008F85 RID: 36741 RVA: 0x001A8E3B File Offset: 0x001A723B
		public void SetDragBeginAction(DragBeginAction dragBegin)
		{
			this._dragBeginAction = dragBegin;
		}

		// Token: 0x06008F86 RID: 36742 RVA: 0x001A8E44 File Offset: 0x001A7244
		public void SetDragEndAction(DragEndAction dragEnd)
		{
			this._dragEndAction = dragEnd;
		}

		// Token: 0x06008F87 RID: 36743 RVA: 0x001A8E4D File Offset: 0x001A724D
		public void ResetDragAction()
		{
			this._isCanBeginDragAction = null;
			this._dragBeginAction = null;
			this._dragEndAction = null;
		}

		// Token: 0x06008F88 RID: 36744 RVA: 0x001A8E64 File Offset: 0x001A7264
		public void OnBeginDrag(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (CommonNewDragUtility.IsAlreadyOwnerFirstDraggingPointerId())
			{
				return;
			}
			this._isDragging = false;
			if (this._isCanBeginDragAction != null && !this._isCanBeginDragAction(pointerEventData))
			{
				return;
			}
			if (this._dragBeginAction != null)
			{
				this._dragBeginAction(pointerEventData);
			}
			this.SetDraggedPosition(pointerEventData);
			this._isDragging = true;
			CommonNewDragUtility.SetFirstDraggingPointerId(pointerEventData.pointerId);
		}

		// Token: 0x06008F89 RID: 36745 RVA: 0x001A8ED9 File Offset: 0x001A72D9
		public void OnDrag(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (!CommonNewDragUtility.IsPointerIdIsFirstDraggingPointerId(pointerEventData.pointerId))
			{
				return;
			}
			if (!this._isDragging)
			{
				return;
			}
			this.SetDraggedPosition(pointerEventData);
		}

		// Token: 0x06008F8A RID: 36746 RVA: 0x001A8F06 File Offset: 0x001A7306
		public void OnEndDrag(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (!CommonNewDragUtility.IsPointerIdIsFirstDraggingPointerId(pointerEventData.pointerId))
			{
				return;
			}
			this._isDragging = false;
			CommonNewDragUtility.ResetFirstDragPointerId();
			if (this._dragEndAction != null)
			{
				this._dragEndAction(pointerEventData);
			}
		}

		// Token: 0x06008F8B RID: 36747 RVA: 0x001A8F43 File Offset: 0x001A7343
		public void OnForceEndDrag()
		{
			this._isDragging = false;
			CommonNewDragUtility.ResetFirstDragPointerId();
			if (this._dragEndAction != null)
			{
				this._dragEndAction(null);
			}
		}

		// Token: 0x06008F8C RID: 36748 RVA: 0x001A8F68 File Offset: 0x001A7368
		private void SetDraggedPosition(PointerEventData pointerEventData)
		{
			if (this._dragCanvasRoot == null)
			{
				return;
			}
			if (this._dragGameObject == null)
			{
				return;
			}
			RectTransform component = this._dragGameObject.GetComponent<RectTransform>();
			RectTransform rectTransform = this._dragCanvasRoot.transform as RectTransform;
			Vector2 anchoredPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pointerEventData.position, pointerEventData.pressEventCamera, ref anchoredPosition))
			{
				component.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x06008F8D RID: 36749 RVA: 0x001A8FD6 File Offset: 0x001A73D6
		public void SetDragGameObject(GameObject dragGameObject)
		{
			this._dragGameObject = dragGameObject;
		}

		// Token: 0x06008F8E RID: 36750 RVA: 0x001A8FDF File Offset: 0x001A73DF
		public GameObject GetDragGameObject()
		{
			return this._dragGameObject;
		}

		// Token: 0x06008F8F RID: 36751 RVA: 0x001A8FE7 File Offset: 0x001A73E7
		public void SetDragCanvasRoot(GameObject dragCanvasRoot)
		{
			this._dragCanvasRoot = dragCanvasRoot;
		}

		// Token: 0x06008F90 RID: 36752 RVA: 0x001A8FF0 File Offset: 0x001A73F0
		public bool GetDraggingState()
		{
			return this._isDragging;
		}

		// Token: 0x04004746 RID: 18246
		private bool _isDragging;

		// Token: 0x04004747 RID: 18247
		private GameObject _dragGameObject;

		// Token: 0x04004748 RID: 18248
		private GameObject _dragCanvasRoot;

		// Token: 0x04004749 RID: 18249
		private IsCanBeginDragAction _isCanBeginDragAction;

		// Token: 0x0400474A RID: 18250
		private DragBeginAction _dragBeginAction;

		// Token: 0x0400474B RID: 18251
		private DragEndAction _dragEndAction;
	}
}
