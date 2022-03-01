using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F4F RID: 3919
	internal class ComWhiteCircle : MonoBehaviour
	{
		// Token: 0x0600985C RID: 39004 RVA: 0x001D50C0 File Offset: 0x001D34C0
		public void Setup(Vector2 pos, float radius, ComMapScene a_comScene)
		{
			this.m_scene = a_comScene;
			if (this.imageTrans == null)
			{
				this.m_Image = base.GetComponent<Image>();
				this.imageTrans = this.m_Image.GetComponent<RectTransform>();
			}
			this.imageTrans.anchoredPosition = new Vector2(pos.x * this.m_scene.XRate, pos.y * this.m_scene.ZRate);
			this.imageTrans.sizeDelta = new Vector2(radius * 12.8f, radius * 10f);
		}

		// Token: 0x04004EA0 RID: 20128
		private ComMapScene m_scene;

		// Token: 0x04004EA1 RID: 20129
		private RectTransform imageTrans;

		// Token: 0x04004EA2 RID: 20130
		private Image m_Image;
	}
}
