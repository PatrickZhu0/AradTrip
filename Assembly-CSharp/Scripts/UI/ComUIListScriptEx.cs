using System;
using UnityEngine;

namespace Scripts.UI
{
	// Token: 0x02000F4E RID: 3918
	public class ComUIListScriptEx : ComUIListScript
	{
		// Token: 0x06009856 RID: 38998 RVA: 0x001D4AA0 File Offset: 0x001D2EA0
		protected override ComUIListElementScript CreateElement(int index, ref stRect rect)
		{
			ComUIListElementScript comUIListElementScript = null;
			if (this.m_unUsedElementScripts.Count > 0)
			{
				bool flag = false;
				for (int i = 0; i < this.m_unUsedElementScripts.Count; i++)
				{
					if (this.m_unUsedElementScripts[i] != null && this.m_unUsedElementScripts[i].m_index == index)
					{
						comUIListElementScript = this.m_unUsedElementScripts[i];
						this.m_unUsedElementScripts.RemoveAt(i);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					comUIListElementScript = this.m_unUsedElementScripts[0];
					this.m_unUsedElementScripts.RemoveAt(0);
				}
			}
			else if (this.m_elementTemplate != null)
			{
				GameObject gameObject = base.InstantiateElement(this.m_elementTemplate);
				gameObject.transform.SetParent(this.m_content.transform);
				gameObject.transform.localScale = Vector3.one;
				comUIListElementScript = gameObject.GetComponent<ComUIListElementScript>();
			}
			if (comUIListElementScript != null)
			{
				if (this.onBindItem != null && comUIListElementScript.gameObjectBindScript == null)
				{
					comUIListElementScript.gameObjectBindScript = this.onBindItem(comUIListElementScript.gameObject);
				}
				comUIListElementScript.Initialize();
				comUIListElementScript.Enable(this, index, this.m_elementName, ref rect, this.IsSelectedIndex(index));
				this.m_elementScripts.Add(comUIListElementScript);
				if (this.onItemVisiable != null)
				{
					this.onItemVisiable(comUIListElementScript);
				}
			}
			return comUIListElementScript;
		}

		// Token: 0x06009857 RID: 38999 RVA: 0x001D4C14 File Offset: 0x001D3014
		public void MoveItemToFirstPosition(int index)
		{
			if (index < 0 || index >= this.m_elementAmount)
			{
				return;
			}
			if (!this.IsItemCoverScrollRect())
			{
				return;
			}
			stRect stRect = this.m_useOptimized ? this.m_elementsRect[index] : this.m_elementScripts[index].m_rect;
			stRect stRect2 = this.m_useOptimized ? this.m_elementsRect[this.m_elementAmount - 1] : this.m_elementScripts[this.m_elementAmount - 1].m_rect;
			switch (this.m_listType)
			{
			case ComUIListScript.enUIListType.Vertical:
			case ComUIListScript.enUIListType.VerticalGrid:
			{
				float num = -((float)stRect.m_top + this.m_elementSpacing.y / 2f);
				float num2 = -((float)stRect2.m_bottom - this.m_elementSpacing.y / 2f);
				if (num2 - num < this.m_scrollAreaSize.y)
				{
					this.m_contentRectTransform.anchoredPosition = new Vector2(this.m_contentRectTransform.anchoredPosition.x, num2 - this.m_scrollAreaSize.y);
				}
				else
				{
					this.m_contentRectTransform.anchoredPosition = new Vector2(this.m_contentRectTransform.anchoredPosition.x, num);
				}
				break;
			}
			case ComUIListScript.enUIListType.Horizontal:
			case ComUIListScript.enUIListType.HorizontalGrid:
			{
				float num3 = -((float)stRect.m_left - this.m_elementSpacing.x / 2f);
				float num4 = -((float)stRect2.m_right + this.m_elementSpacing.x / 2f);
				if (num3 - num4 < this.m_scrollAreaSize.x)
				{
					this.m_contentRectTransform.anchoredPosition = new Vector2(num4 + this.m_scrollAreaSize.x, this.m_contentRectTransform.anchoredPosition.y);
				}
				else
				{
					this.m_contentRectTransform.anchoredPosition = new Vector2(num3, this.m_contentRectTransform.anchoredPosition.y);
				}
				break;
			}
			}
		}

		// Token: 0x06009858 RID: 39000 RVA: 0x001D4E34 File Offset: 0x001D3234
		public void MoveItemToMiddlePosition(int index)
		{
			if (index < 0 || index >= this.m_elementAmount)
			{
				return;
			}
			if (!this.IsItemCoverScrollRect())
			{
				return;
			}
			stRect stRect = this.m_useOptimized ? this.m_elementsRect[index] : this.m_elementScripts[index].m_rect;
			stRect stRect2 = this.m_useOptimized ? this.m_elementsRect[this.m_elementAmount - 1] : this.m_elementScripts[this.m_elementAmount - 1].m_rect;
			switch (this.m_listType)
			{
			case ComUIListScript.enUIListType.Vertical:
			case ComUIListScript.enUIListType.VerticalGrid:
			{
				float num = -this.m_scrollAreaSize.y * 0.5f - stRect.m_center.y;
				if (num <= 0f)
				{
					num = 0f;
				}
				else if (num + (float)stRect2.m_bottom > -this.m_scrollAreaSize.y)
				{
					num = -this.m_scrollAreaSize.y - (float)stRect2.m_bottom;
				}
				this.m_contentRectTransform.anchoredPosition = new Vector2(this.m_contentRectTransform.anchoredPosition.x, num);
				break;
			}
			case ComUIListScript.enUIListType.Horizontal:
			case ComUIListScript.enUIListType.HorizontalGrid:
			{
				float num2 = this.m_scrollAreaSize.x * 0.5f - stRect.m_center.x;
				if (num2 >= 0f)
				{
					num2 = 0f;
				}
				else if (num2 + (float)stRect2.m_right < this.m_scrollAreaSize.x)
				{
					num2 = this.m_scrollAreaSize.x - (float)stRect2.m_right;
				}
				this.m_contentRectTransform.anchoredPosition = new Vector2(num2, this.m_contentRectTransform.anchoredPosition.y);
				break;
			}
			}
		}

		// Token: 0x06009859 RID: 39001 RVA: 0x001D501C File Offset: 0x001D341C
		private bool IsItemCoverScrollRect()
		{
			bool result = false;
			switch (this.m_listType)
			{
			case ComUIListScript.enUIListType.Vertical:
			case ComUIListScript.enUIListType.VerticalGrid:
				if (this.m_contentSize.y > this.m_scrollAreaSize.y)
				{
					result = true;
				}
				break;
			case ComUIListScript.enUIListType.Horizontal:
			case ComUIListScript.enUIListType.HorizontalGrid:
				if (this.m_contentSize.x > this.m_scrollAreaSize.x)
				{
					result = true;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600985A RID: 39002 RVA: 0x001D5092 File Offset: 0x001D3492
		public void ResetComUiListScriptEx()
		{
			if (this.m_scrollRect != null)
			{
				this.m_scrollRect.StopMovement();
			}
			base.ResetContentPosition();
		}
	}
}
