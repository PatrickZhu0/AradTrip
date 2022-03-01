using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.UI
{
	// Token: 0x02000F41 RID: 3905
	public class ComUIListElementSelectionScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerUpHandler
	{
		// Token: 0x060097F2 RID: 38898 RVA: 0x001D2506 File Offset: 0x001D0906
		public void SetBelongedList(ComUIListScript belongedList, int indexInList)
		{
			this.m_belongedList = belongedList;
			this.m_indexInList = indexInList;
		}

		// Token: 0x060097F3 RID: 38899 RVA: 0x001D2516 File Offset: 0x001D0916
		public bool ClearInputStatus()
		{
			this.m_needClearInputStatus = true;
			return this.m_isDown;
		}

		// Token: 0x060097F4 RID: 38900 RVA: 0x001D2525 File Offset: 0x001D0925
		public void ExecuteInputStatus()
		{
			this.m_isDown = false;
			this.m_isHold = false;
			this.m_canClick = false;
		}

		// Token: 0x060097F5 RID: 38901 RVA: 0x001D253C File Offset: 0x001D093C
		private void LateUpdate()
		{
			if (this.m_needClearInputStatus)
			{
				this.ExecuteInputStatus();
				this.m_needClearInputStatus = false;
			}
		}

		// Token: 0x060097F6 RID: 38902 RVA: 0x001D2558 File Offset: 0x001D0958
		public void OnBeginDrag(PointerEventData eventData)
		{
			this.m_canClick = false;
			if (this.m_belongedList != null && this.m_belongedList.m_scrollRect != null)
			{
				this.m_belongedList.m_scrollRect.OnBeginDrag(eventData);
			}
		}

		// Token: 0x060097F7 RID: 38903 RVA: 0x001D25A4 File Offset: 0x001D09A4
		public void OnDrag(PointerEventData eventData)
		{
			this.m_canClick = false;
			if (this.m_belongedList != null && this.m_belongedList.m_scrollRect != null)
			{
				this.m_belongedList.m_scrollRect.OnDrag(eventData);
			}
		}

		// Token: 0x060097F8 RID: 38904 RVA: 0x001D25F0 File Offset: 0x001D09F0
		public void OnDrop(PointerEventData eventData)
		{
		}

		// Token: 0x060097F9 RID: 38905 RVA: 0x001D25F4 File Offset: 0x001D09F4
		public void OnEndDrag(PointerEventData eventData)
		{
			this.m_canClick = false;
			if (this.m_belongedList != null && this.m_belongedList.m_scrollRect != null)
			{
				this.m_belongedList.m_scrollRect.OnEndDrag(eventData);
			}
			this.ClearInputStatus();
		}

		// Token: 0x060097FA RID: 38906 RVA: 0x001D2648 File Offset: 0x001D0A48
		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.m_canClick && this.m_belongedList != null && this.m_indexInList >= 0)
			{
				this.m_belongedList.SelectElement(this.m_indexInList, true);
			}
			this.ClearInputStatus();
		}

		// Token: 0x060097FB RID: 38907 RVA: 0x001D2696 File Offset: 0x001D0A96
		public void OnPointerDown(PointerEventData eventData)
		{
			this.m_isDown = true;
			this.m_isHold = false;
			this.m_canClick = true;
		}

		// Token: 0x060097FC RID: 38908 RVA: 0x001D26AD File Offset: 0x001D0AAD
		public void OnPointerUp(PointerEventData eventData)
		{
			this.ClearInputStatus();
		}

		// Token: 0x04004E68 RID: 20072
		protected ComUIListScript m_belongedList;

		// Token: 0x04004E69 RID: 20073
		protected int m_indexInList;

		// Token: 0x04004E6A RID: 20074
		private const float c_clickAreaValue = 40f;

		// Token: 0x04004E6B RID: 20075
		private const float c_holdTimeValue = 1f;

		// Token: 0x04004E6C RID: 20076
		private bool m_canClick;

		// Token: 0x04004E6D RID: 20077
		[HideInInspector]
		private bool m_isDown;

		// Token: 0x04004E6E RID: 20078
		private bool m_isHold;

		// Token: 0x04004E6F RID: 20079
		private bool m_needClearInputStatus;
	}
}
