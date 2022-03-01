using System;

namespace Assets.Scripts.Common
{
	// Token: 0x02000254 RID: 596
	public class PooledClassObject
	{
		// Token: 0x06001372 RID: 4978 RVA: 0x000688AC File Offset: 0x00066CAC
		public virtual void OnRelease()
		{
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x000688AE File Offset: 0x00066CAE
		public virtual void OnUse()
		{
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x000688B0 File Offset: 0x00066CB0
		public void Release()
		{
			this.OnRelease();
			this.holder.Release(this);
		}

		// Token: 0x04000D31 RID: 3377
		public bool bChkReset = true;

		// Token: 0x04000D32 RID: 3378
		public IObjPoolCtrl holder;

		// Token: 0x04000D33 RID: 3379
		public uint usingSeq;
	}
}
