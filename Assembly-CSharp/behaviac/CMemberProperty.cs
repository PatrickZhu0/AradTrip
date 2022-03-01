using System;

namespace behaviac
{
	// Token: 0x02004771 RID: 18289
	public class CMemberProperty<T> : CProperty<T>
	{
		// Token: 0x0601A4A1 RID: 107681 RVA: 0x008269ED File Offset: 0x00824DED
		public CMemberProperty(string name, CMemberProperty<T>.SetFunctionPointer sfp, CMemberProperty<T>.GetFunctionPointer gfp) : base(name)
		{
			this._sfp = sfp;
			this._gfp = gfp;
		}

		// Token: 0x0601A4A2 RID: 107682 RVA: 0x00826A04 File Offset: 0x00824E04
		public override T GetValue(Agent self)
		{
			return this._gfp(self);
		}

		// Token: 0x0601A4A3 RID: 107683 RVA: 0x00826A12 File Offset: 0x00824E12
		public override void SetValue(Agent self, T value)
		{
			this._sfp(self, value);
		}

		// Token: 0x04012715 RID: 75541
		private CMemberProperty<T>.SetFunctionPointer _sfp;

		// Token: 0x04012716 RID: 75542
		private CMemberProperty<T>.GetFunctionPointer _gfp;

		// Token: 0x02004772 RID: 18290
		// (Invoke) Token: 0x0601A4A5 RID: 107685
		public delegate void SetFunctionPointer(Agent a, T v);

		// Token: 0x02004773 RID: 18291
		// (Invoke) Token: 0x0601A4A9 RID: 107689
		public delegate T GetFunctionPointer(Agent a);
	}
}
