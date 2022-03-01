using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F01 RID: 3841
	[RequireComponent(typeof(RectTransform))]
	internal class ComLayoutMax : MonoBehaviour
	{
		// Token: 0x06009627 RID: 38439 RVA: 0x001C699E File Offset: 0x001C4D9E
		public void Awake()
		{
			this.m_rect = base.GetComponent<RectTransform>();
		}

		// Token: 0x06009628 RID: 38440 RVA: 0x001C69AC File Offset: 0x001C4DAC
		public void Update()
		{
			if (this.m_rect != null && this.BaseRect != null)
			{
				if (this.BaseRect.sizeDelta.x <= this.MaxSize.x)
				{
					this.m_rect.sizeDelta = new Vector2(this.BaseRect.sizeDelta.x, this.m_rect.sizeDelta.y);
				}
				else
				{
					this.m_rect.sizeDelta = new Vector2(this.MaxSize.x, this.m_rect.sizeDelta.y);
				}
				if (this.BaseRect.sizeDelta.y <= this.MaxSize.y)
				{
					this.m_rect.sizeDelta = new Vector2(this.m_rect.sizeDelta.x, this.BaseRect.sizeDelta.y);
				}
				else
				{
					this.m_rect.sizeDelta = new Vector2(this.m_rect.sizeDelta.x, this.MaxSize.y);
				}
			}
		}

		// Token: 0x04004D0B RID: 19723
		public Vector2 MaxSize;

		// Token: 0x04004D0C RID: 19724
		public RectTransform BaseRect;

		// Token: 0x04004D0D RID: 19725
		private RectTransform m_rect;
	}
}
