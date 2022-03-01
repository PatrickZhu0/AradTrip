using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000DF5 RID: 3573
public class ComChangeColor : MonoBehaviour
{
	// Token: 0x06008F82 RID: 36738 RVA: 0x001A8DF5 File Offset: 0x001A71F5
	public void SetColor(bool b)
	{
		if (this.text != null)
		{
			this.text.color = ((!b) ? this.NormalColor : this.ClickColor);
		}
	}

	// Token: 0x04004743 RID: 18243
	public Color NormalColor = default(Color);

	// Token: 0x04004744 RID: 18244
	public Color ClickColor = default(Color);

	// Token: 0x04004745 RID: 18245
	public Text text;
}
