using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000054 RID: 84
	[ExecuteInEditMode]
	internal class ComSetImageColor : MonoBehaviour
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x0001085C File Offset: 0x0000EC5C
		public void SetColor(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.colors.Length)
			{
				Color color = this.colors[iIndex];
				if (null != this.img)
				{
					this.img.color = color;
				}
			}
		}

		// Token: 0x040001EB RID: 491
		public Color[] colors = new Color[0];

		// Token: 0x040001EC RID: 492
		public Image img;
	}
}
