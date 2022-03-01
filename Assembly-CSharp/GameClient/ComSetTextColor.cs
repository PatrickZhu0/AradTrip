using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000055 RID: 85
	[ExecuteInEditMode]
	internal class ComSetTextColor : MonoBehaviour
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x000108C4 File Offset: 0x0000ECC4
		public void SetColor(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.colors.Length)
			{
				Color color = this.colors[iIndex];
				if (null != this.text)
				{
					this.text.color = color;
				}
			}
		}

		// Token: 0x040001ED RID: 493
		public Color[] colors = new Color[0];

		// Token: 0x040001EE RID: 494
		public Text text;
	}
}
