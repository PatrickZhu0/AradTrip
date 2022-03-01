using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200006A RID: 106
internal class DelayScrollRect : UIBehaviour
{
	// Token: 0x0600024D RID: 589 RVA: 0x000122AE File Offset: 0x000106AE
	public void SetValue(float fValue)
	{
		this.m_fValue = fValue;
		this.m_bDirty = true;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x000122C0 File Offset: 0x000106C0
	protected override void OnRectTransformDimensionsChange()
	{
		if (this.m_bDirty)
		{
			if (this.m_kScrollRect.vertical)
			{
				this.m_kScrollRect.verticalNormalizedPosition = this.m_fValue;
			}
			else if (this.m_kScrollRect.horizontal)
			{
				this.m_kScrollRect.horizontalNormalizedPosition = this.m_fValue;
			}
			this.m_bDirty = false;
		}
		base.OnRectTransformDimensionsChange();
	}

	// Token: 0x0400024A RID: 586
	public ScrollRect m_kScrollRect;

	// Token: 0x0400024B RID: 587
	private float m_fValue;

	// Token: 0x0400024C RID: 588
	private bool m_bDirty;
}
