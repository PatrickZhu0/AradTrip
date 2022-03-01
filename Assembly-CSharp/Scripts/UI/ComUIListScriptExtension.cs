using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.UI
{
	// Token: 0x02000F44 RID: 3908
	[RequireComponent(typeof(ComScrollRectExtension))]
	public class ComUIListScriptExtension : ComUIListScript
	{
		// Token: 0x06009801 RID: 38913 RVA: 0x001D47A0 File Offset: 0x001D2BA0
		protected virtual void OnEnable()
		{
			if (this.m_scrollRectExtend == null)
			{
				this.m_scrollRectExtend = base.GetComponentInChildren<ComScrollRectExtension>(base.gameObject);
			}
			if (this.m_scrollRectExtend)
			{
				this.m_scrollRectExtend.onDragEnd.AddListener(new UnityAction(this._OnScrollRectDragEnd));
			}
		}

		// Token: 0x06009802 RID: 38914 RVA: 0x001D4801 File Offset: 0x001D2C01
		protected virtual void OnDisable()
		{
			if (this.m_scrollRectExtend)
			{
				this.m_scrollRectExtend.onDragEnd.RemoveListener(new UnityAction(this._OnScrollRectDragEnd));
			}
		}

		// Token: 0x06009803 RID: 38915 RVA: 0x001D4830 File Offset: 0x001D2C30
		private void _OnScrollRectDragEnd()
		{
			if (this.OnItemLocalPosAllInRectView != null && this.m_scrollRect != null && this.m_content != null)
			{
				RectTransform component = this.m_scrollRect.GetComponent<RectTransform>();
				RectTransform component2 = this.m_content.GetComponent<RectTransform>();
				if (component != null && component2 != null)
				{
					switch (this.m_listType)
					{
					case ComUIListScript.enUIListType.Vertical:
					case ComUIListScript.enUIListType.Horizontal:
					case ComUIListScript.enUIListType.VerticalGrid:
					case ComUIListScript.enUIListType.HorizontalGrid:
						this.InvokeOnItemLocalPosAllInRectView();
						break;
					}
				}
			}
		}

		// Token: 0x06009804 RID: 38916 RVA: 0x001D48C8 File Offset: 0x001D2CC8
		private void InvokeOnItemLocalPosAllInRectView()
		{
			if (this.OnItemLocalPosAllInRectView != null)
			{
				for (int i = 0; i < this.m_elementScripts.Count; i++)
				{
					ComUIListElementScript comUIListElementScript = this.m_elementScripts[i];
					if (!(comUIListElementScript == null))
					{
						if (this.IsRectTotalInScrollArea(ref comUIListElementScript.m_rect, 0))
						{
							this.OnItemLocalPosAllInRectView(comUIListElementScript);
						}
					}
				}
			}
		}

		// Token: 0x06009805 RID: 38917 RVA: 0x001D4938 File Offset: 0x001D2D38
		public new void UnInitialize()
		{
			base.UnInitialize();
			if (this.m_scrollRectExtend)
			{
				this.m_scrollRectExtend.onDragEnd.RemoveAllListeners();
				this.m_scrollRectExtend = null;
			}
			this.OnItemLocalPosAllInRectView = null;
		}

		// Token: 0x06009806 RID: 38918 RVA: 0x001D4970 File Offset: 0x001D2D70
		public bool IsElementTotalInScrollArea(int index = 0)
		{
			if (index < 0 || index >= this.m_elementAmount)
			{
				return false;
			}
			stRect stRect = this.m_useOptimized ? this.m_elementsRect[index] : this.m_elementScripts[index].m_rect;
			return this.IsRectTotalInScrollArea(ref stRect, index);
		}

		// Token: 0x06009807 RID: 38919 RVA: 0x001D49CC File Offset: 0x001D2DCC
		protected bool IsRectTotalInScrollArea(ref stRect rect, int index = 0)
		{
			Vector2 zero = Vector2.zero;
			zero.x = this.m_contentRectTransform.anchoredPosition.x + (float)rect.m_right;
			zero.y = this.m_contentRectTransform.anchoredPosition.y + (float)rect.m_bottom;
			return zero.x - (float)rect.m_width >= 0f && zero.x - this.m_scrollAreaSize.x <= 0f && zero.y + (float)rect.m_height <= 0f && zero.y + this.m_scrollAreaSize.y >= 0f;
		}

		// Token: 0x04004E71 RID: 20081
		[HideInInspector]
		public ComUIListScriptExtension.OnItemLocalPosAllInRectViewDelegate OnItemLocalPosAllInRectView;

		// Token: 0x04004E72 RID: 20082
		protected ComScrollRectExtension m_scrollRectExtend;

		// Token: 0x02000F45 RID: 3909
		// (Invoke) Token: 0x06009809 RID: 38921
		public delegate void OnItemLocalPosAllInRectViewDelegate(ComUIListElementScript item);
	}
}
