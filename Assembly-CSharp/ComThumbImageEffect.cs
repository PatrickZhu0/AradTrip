using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F24 RID: 3876
public class ComThumbImageEffect : MonoBehaviour
{
	// Token: 0x06009753 RID: 38739 RVA: 0x001CF70D File Offset: 0x001CDB0D
	public void Set(bool status)
	{
		this.mFg.enabled = !status;
	}

	// Token: 0x04004DF9 RID: 19961
	public GameObject mToggleRoot;

	// Token: 0x04004DFA RID: 19962
	public Image mSelectedFg;

	// Token: 0x04004DFB RID: 19963
	public Image mFg;
}
