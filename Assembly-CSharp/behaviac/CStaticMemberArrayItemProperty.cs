using System;

namespace behaviac
{
	// Token: 0x0200476E RID: 18286
	public class CStaticMemberArrayItemProperty<T> : CProperty<T>
	{
		// Token: 0x0601A496 RID: 107670 RVA: 0x008269B9 File Offset: 0x00824DB9
		public CStaticMemberArrayItemProperty(string name, CStaticMemberArrayItemProperty<T>.SetFunctionPointer sfp, CStaticMemberArrayItemProperty<T>.GetFunctionPointer gfp) : base(name)
		{
			this._sfp = sfp;
			this._gfp = gfp;
		}

		// Token: 0x0601A497 RID: 107671 RVA: 0x008269D0 File Offset: 0x00824DD0
		public override T GetValue(Agent self, int index)
		{
			return this._gfp(index);
		}

		// Token: 0x0601A498 RID: 107672 RVA: 0x008269DE File Offset: 0x00824DDE
		public override void SetValue(Agent self, T value, int index)
		{
			this._sfp(value, index);
		}

		// Token: 0x04012713 RID: 75539
		private CStaticMemberArrayItemProperty<T>.SetFunctionPointer _sfp;

		// Token: 0x04012714 RID: 75540
		private CStaticMemberArrayItemProperty<T>.GetFunctionPointer _gfp;

		// Token: 0x0200476F RID: 18287
		// (Invoke) Token: 0x0601A49A RID: 107674
		public delegate void SetFunctionPointer(T v, int index);

		// Token: 0x02004770 RID: 18288
		// (Invoke) Token: 0x0601A49E RID: 107678
		public delegate T GetFunctionPointer(int index);
	}
}
