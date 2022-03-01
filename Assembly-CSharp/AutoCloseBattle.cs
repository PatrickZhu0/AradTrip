using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
public class AutoCloseBattle : MonoBehaviour
{
	// Token: 0x060008F8 RID: 2296 RVA: 0x0002F75B File Offset: 0x0002DB5B
	private void Start()
	{
		this.self = base.gameObject;
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x0002F769 File Offset: 0x0002DB69
	public void SetCloseTime(float time)
	{
		this.closeTime = time;
		this.flag = true;
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x0002F779 File Offset: 0x0002DB79
	private void Update()
	{
		if (!this.flag || this.self == null)
		{
			return;
		}
		this.UpdateCloseTime();
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x0002F79E File Offset: 0x0002DB9E
	protected void UpdateCloseTime()
	{
		if (this.closeTime > 0f)
		{
			this.closeTime -= this.deltaTime;
		}
		else
		{
			this.CloseSelf();
		}
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x0002F7CE File Offset: 0x0002DBCE
	private void CloseSelf()
	{
		if (this.self == null)
		{
			return;
		}
		this.flag = false;
		Object.Destroy(this.self);
		this.self = null;
	}

	// Token: 0x040006EA RID: 1770
	private GameObject self;

	// Token: 0x040006EB RID: 1771
	private float deltaTime = 0.033f;

	// Token: 0x040006EC RID: 1772
	private float closeTime;

	// Token: 0x040006ED RID: 1773
	private bool flag;
}
