using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameClient
{
	// Token: 0x02000DFF RID: 3583
	public class CommonNewDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x06008FB3 RID: 36787 RVA: 0x001A9055 File Offset: 0x001A7455
		public void SetIsPointerItemCanDropDownAction(IsPointerItemCanDropDownAction isPointerItemCanDropDownAction)
		{
			this._isPointerItemCanDropDownAction = isPointerItemCanDropDownAction;
		}

		// Token: 0x06008FB4 RID: 36788 RVA: 0x001A905E File Offset: 0x001A745E
		public void SetOnDropDownAction(OnDropDownAction onDropDownAction)
		{
			this._onDropDownAction = onDropDownAction;
		}

		// Token: 0x06008FB5 RID: 36789 RVA: 0x001A9067 File Offset: 0x001A7467
		public void SetOnPointerEnterAction(OnPointerEnterAction onPointerEnterAction)
		{
			this._onPointerEnterAction = onPointerEnterAction;
		}

		// Token: 0x06008FB6 RID: 36790 RVA: 0x001A9070 File Offset: 0x001A7470
		public void SetOnPointerExitAction(OnPointerExitAction onPointerExitAction)
		{
			this._onPointerExitAction = onPointerExitAction;
		}

		// Token: 0x06008FB7 RID: 36791 RVA: 0x001A9079 File Offset: 0x001A7479
		public void ResetDropAction()
		{
			this._isPointerItemCanDropDownAction = null;
			this._onDropDownAction = null;
			this._onPointerExitAction = null;
			this._onPointerEnterAction = null;
		}

		// Token: 0x06008FB8 RID: 36792 RVA: 0x001A9098 File Offset: 0x001A7498
		public void OnDrop(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (!CommonNewDragUtility.IsPointerIdIsFirstDraggingPointerId(pointerEventData.pointerId))
			{
				return;
			}
			bool flag = false;
			if (this._isPointerItemCanDropDownAction != null)
			{
				flag = this._isPointerItemCanDropDownAction(pointerEventData);
			}
			if (!flag)
			{
				return;
			}
			if (this._onDropDownAction != null)
			{
				this._onDropDownAction(pointerEventData);
			}
		}

		// Token: 0x06008FB9 RID: 36793 RVA: 0x001A90F8 File Offset: 0x001A74F8
		public void OnPointerEnter(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (!CommonNewDragUtility.IsPointerIdIsFirstDraggingPointerId(pointerEventData.pointerId))
			{
				return;
			}
			bool flag = false;
			if (this._isPointerItemCanDropDownAction != null)
			{
				flag = this._isPointerItemCanDropDownAction(pointerEventData);
			}
			if (!flag)
			{
				return;
			}
			if (this._onPointerEnterAction != null)
			{
				this._onPointerEnterAction(pointerEventData);
			}
		}

		// Token: 0x06008FBA RID: 36794 RVA: 0x001A9155 File Offset: 0x001A7555
		public void OnPointerExit(PointerEventData pointerEventData)
		{
			if (pointerEventData == null)
			{
				return;
			}
			if (!CommonNewDragUtility.IsPointerIdIsFirstDraggingPointerId(pointerEventData.pointerId))
			{
				return;
			}
			if (this._onPointerExitAction != null)
			{
				this._onPointerExitAction(pointerEventData);
			}
		}

		// Token: 0x0400474D RID: 18253
		private IsPointerItemCanDropDownAction _isPointerItemCanDropDownAction;

		// Token: 0x0400474E RID: 18254
		private OnDropDownAction _onDropDownAction;

		// Token: 0x0400474F RID: 18255
		private OnPointerEnterAction _onPointerEnterAction;

		// Token: 0x04004750 RID: 18256
		private OnPointerExitAction _onPointerExitAction;
	}
}
