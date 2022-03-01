using System;

// Token: 0x0200010B RID: 267
public class PooledClassObj : ObjectLeakDitector
{
	// Token: 0x060005CA RID: 1482 RVA: 0x00024E74 File Offset: 0x00023274
	public virtual void OnReused()
	{
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00024E76 File Offset: 0x00023276
	public virtual void OnRecycle()
	{
	}
}
