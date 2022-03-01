using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000074 RID: 116
	[RequireComponent(typeof(RectTransform))]
	internal class FastVerticalLayout : MonoBehaviour
	{
		// Token: 0x06000278 RID: 632 RVA: 0x00012E31 File Offset: 0x00011231
		private void Start()
		{
			this.rectTransForm = base.GetComponent<RectTransform>();
			this._InitRectTransForm(this.rectTransForm);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00012E4B File Offset: 0x0001124B
		private void OnEnable()
		{
			this.MarkDirty();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00012E54 File Offset: 0x00011254
		private void OnDestroy()
		{
			for (int i = 0; i < this.m_akChilds.Count; i++)
			{
				SortElement.Delloc(this.m_akChilds[i]);
			}
			this.m_akChilds.Clear();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00012E99 File Offset: 0x00011299
		private int _SortLayout(SortElement left, SortElement right)
		{
			return right.iOrder - left.iOrder;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00012EA8 File Offset: 0x000112A8
		public void MarkDirty()
		{
			for (int i = 0; i < this.m_akChilds.Count; i++)
			{
				SortElement.Delloc(this.m_akChilds[i]);
			}
			this.m_akChilds.Clear();
			for (int j = 0; j < base.transform.childCount; j++)
			{
				int num = (!this.bReverse) ? j : (base.transform.childCount - 1 - j);
				RectTransform rectTransform = base.transform.GetChild(num) as RectTransform;
				if (rectTransform != null)
				{
					LayoutSortOrder component = rectTransform.gameObject.GetComponent<LayoutSortOrder>();
					SortElement sortElement = SortElement.Alloc();
					sortElement.rectTransform = rectTransform;
					sortElement.iOrder = ((!(component == null)) ? component.SortID : 0);
					this.m_akChilds.Add(sortElement);
				}
			}
			if (this.m_akChilds.Count > 1)
			{
				this.m_akChilds.Sort(new Comparison<SortElement>(this._SortLayout));
			}
			this.m_bDirty = true;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00012FC1 File Offset: 0x000113C1
		private void _InitRectTransForm(RectTransform rectTransform)
		{
			if (rectTransform != null)
			{
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.zero;
				rectTransform.pivot = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00012FFC File Offset: 0x000113FC
		private void Update()
		{
			float num = this.fTop;
			if (this.m_akChilds != null)
			{
				for (int i = 0; i < this.m_akChilds.Count; i++)
				{
					RectTransform rectTransform = this.m_akChilds[i].rectTransform;
					if (rectTransform != null && rectTransform.gameObject.activeSelf)
					{
						this.tempVector3.y = num;
						rectTransform.localPosition = this.tempVector3;
						if (i != base.transform.childCount - 1)
						{
							num += this.fInterval + rectTransform.sizeDelta.y;
						}
						else
						{
							num += this.fBottom + rectTransform.sizeDelta.y;
						}
					}
				}
			}
			if (this.rectTransForm != null)
			{
				this.tempVector.x = this.rectTransForm.sizeDelta.x;
				this.tempVector.y = num;
				this.rectTransForm.sizeDelta = this.tempVector;
			}
			this.m_bDirty = false;
		}

		// Token: 0x0400026D RID: 621
		public float fTop;

		// Token: 0x0400026E RID: 622
		public float fBottom;

		// Token: 0x0400026F RID: 623
		public float fInterval;

		// Token: 0x04000270 RID: 624
		public bool bReverse;

		// Token: 0x04000271 RID: 625
		private bool m_bDirty;

		// Token: 0x04000272 RID: 626
		private RectTransform rectTransForm;

		// Token: 0x04000273 RID: 627
		private Vector2 tempVector = Vector2.zero;

		// Token: 0x04000274 RID: 628
		private Vector3 tempVector3 = Vector3.zero;

		// Token: 0x04000275 RID: 629
		private List<SortElement> m_akChilds = new List<SortElement>();
	}
}
