using System;
using UnityEngine;

// Token: 0x02004614 RID: 17940
public class PathAutoTrace : MonoBehaviour
{
	// Token: 0x06019388 RID: 103304 RVA: 0x007FA7D5 File Offset: 0x007F8BD5
	public void Initialize()
	{
		base.transform.gameObject.SetActive(true);
	}

	// Token: 0x06019389 RID: 103305 RVA: 0x007FA7E8 File Offset: 0x007F8BE8
	public void SetVisible(bool bVisible)
	{
		base.transform.gameObject.SetActive(bVisible);
	}
}
