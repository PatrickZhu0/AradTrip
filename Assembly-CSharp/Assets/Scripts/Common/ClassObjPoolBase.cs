using System;
using System.Collections.Generic;

namespace Assets.Scripts.Common
{
	// Token: 0x02000251 RID: 593
	public abstract class ClassObjPoolBase : IObjPoolCtrl
	{
		// Token: 0x0600136A RID: 4970
		public abstract void Release(PooledClassObject obj);

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x00068707 File Offset: 0x00066B07
		// (set) Token: 0x0600136C RID: 4972 RVA: 0x00068714 File Offset: 0x00066B14
		public int capacity
		{
			get
			{
				return this.pool.Capacity;
			}
			set
			{
				this.pool.Capacity = value;
			}
		}

		// Token: 0x04000D2F RID: 3375
		protected List<object> pool = new List<object>(128);

		// Token: 0x04000D30 RID: 3376
		protected uint reqSeq;
	}
}
