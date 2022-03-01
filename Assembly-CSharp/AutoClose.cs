using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
public class AutoClose : MonoBehaviour
{
	// Token: 0x060008F4 RID: 2292 RVA: 0x0002F6EE File Offset: 0x0002DAEE
	private void Start()
	{
		base.Invoke("CloseSelf", this.CloseTime);
		this.self = base.gameObject;
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x0002F70D File Offset: 0x0002DB0D
	public bool SelfExist()
	{
		return !(this.self == null);
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x0002F723 File Offset: 0x0002DB23
	private void CloseSelf()
	{
		if (this.self != null)
		{
			Object.Destroy(this.self);
			this.self = null;
		}
	}

	// Token: 0x040006E8 RID: 1768
	public float CloseTime = 2f;

	// Token: 0x040006E9 RID: 1769
	private GameObject self;
}
