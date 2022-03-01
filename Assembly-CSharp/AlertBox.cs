using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000136 RID: 310
public class AlertBox : MonoBehaviour
{
	// Token: 0x060008F1 RID: 2289 RVA: 0x0002F6C0 File Offset: 0x0002DAC0
	public void SetMessage(string msg)
	{
		this.msg.text = msg;
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x0002F6CE File Offset: 0x0002DACE
	public void Close()
	{
		Object.Destroy(base.gameObject);
	}

	// Token: 0x040006E6 RID: 1766
	public Text title;

	// Token: 0x040006E7 RID: 1767
	public Text msg;
}
