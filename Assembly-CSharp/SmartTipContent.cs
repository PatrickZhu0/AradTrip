using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004740 RID: 18240
internal class SmartTipContent : MonoBehaviour
{
	// Token: 0x0601A34D RID: 107341 RVA: 0x00823848 File Offset: 0x00821C48
	public void SetText(string left, string right)
	{
		this.m_kObjectLeft.text = left;
		this.m_kObjectRight.text = right;
		this.m_dirty = true;
	}

	// Token: 0x0601A34E RID: 107342 RVA: 0x0082386C File Offset: 0x00821C6C
	public void LateUpdate()
	{
		if (!this.m_dirty)
		{
			return;
		}
		this.m_dirty = true;
		if (this.m_kElement == null)
		{
			this.m_kElement = base.transform.GetComponent<LayoutElement>();
			this.m_Rect = (base.transform as RectTransform);
		}
		if (this.m_kElement == null)
		{
			return;
		}
		float preferredHeight = Mathf.Max(LayoutUtility.GetPreferredSize(this.m_kObjectLeft.rectTransform, 1), LayoutUtility.GetPreferredSize(this.m_kObjectRight.rectTransform, 1));
		this.m_kElement.preferredHeight = preferredHeight;
	}

	// Token: 0x04012676 RID: 75382
	public Text m_kObjectLeft;

	// Token: 0x04012677 RID: 75383
	public Text m_kObjectRight;

	// Token: 0x04012678 RID: 75384
	protected bool m_dirty;

	// Token: 0x04012679 RID: 75385
	protected LayoutElement m_kElement;

	// Token: 0x0401267A RID: 75386
	protected RectTransform m_Rect;
}
