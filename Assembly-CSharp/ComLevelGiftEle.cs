using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001757 RID: 5975
internal class ComLevelGiftEle : MonoBehaviour
{
	// Token: 0x17001CE1 RID: 7393
	// (get) Token: 0x0600EBDE RID: 60382 RVA: 0x003EDDB6 File Offset: 0x003EC1B6
	// (set) Token: 0x0600EBDF RID: 60383 RVA: 0x003EDDBE File Offset: 0x003EC1BE
	public RectTransform mrt
	{
		get
		{
			return this.rt;
		}
		set
		{
			this.rt = value;
		}
	}

	// Token: 0x04008F1B RID: 36635
	public GameObject IconRoot;

	// Token: 0x04008F1C RID: 36636
	public Image icon0;

	// Token: 0x04008F1D RID: 36637
	public Image icon1;

	// Token: 0x04008F1E RID: 36638
	public Image icon2;

	// Token: 0x04008F1F RID: 36639
	public GameObject TextRoot;

	// Token: 0x04008F20 RID: 36640
	public Text text0;

	// Token: 0x04008F21 RID: 36641
	public Text text1;

	// Token: 0x04008F22 RID: 36642
	public Text text2;

	// Token: 0x04008F23 RID: 36643
	public GameObject Accomplish;

	// Token: 0x04008F24 RID: 36644
	public GameObject Uncomplete;

	// Token: 0x04008F25 RID: 36645
	public Text UncompleteText;

	// Token: 0x04008F26 RID: 36646
	public Button Receive;

	// Token: 0x04008F27 RID: 36647
	public Text ReceiveText;

	// Token: 0x04008F28 RID: 36648
	public int ElementIndex;

	// Token: 0x04008F29 RID: 36649
	public UIGray ReceiveGray;

	// Token: 0x04008F2A RID: 36650
	public Text AccomplishText;

	// Token: 0x04008F2B RID: 36651
	public Text LevelLimit;

	// Token: 0x04008F2C RID: 36652
	public Text LevelTitle;

	// Token: 0x04008F2D RID: 36653
	private RectTransform rt;
}
