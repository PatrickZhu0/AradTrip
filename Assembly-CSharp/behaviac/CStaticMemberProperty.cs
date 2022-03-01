using System;

namespace behaviac
{
	// Token: 0x0200476B RID: 18283
	public class CStaticMemberProperty<T> : CProperty<T>
	{
		// Token: 0x0601A48B RID: 107659 RVA: 0x00826987 File Offset: 0x00824D87
		public CStaticMemberProperty(string name, CStaticMemberProperty<T>.SetFunctionPointer sfp, CStaticMemberProperty<T>.GetFunctionPointer gfp) : base(name)
		{
			this._sfp = sfp;
			this._gfp = gfp;
		}

		// Token: 0x0601A48C RID: 107660 RVA: 0x0082699E File Offset: 0x00824D9E
		public override T GetValue(Agent self)
		{
			return this._gfp();
		}

		// Token: 0x0601A48D RID: 107661 RVA: 0x008269AB File Offset: 0x00824DAB
		public override void SetValue(Agent self, T value)
		{
			this._sfp(value);
		}

		// Token: 0x04012711 RID: 75537
		private CStaticMemberProperty<T>.SetFunctionPointer _sfp;

		// Token: 0x04012712 RID: 75538
		private CStaticMemberProperty<T>.GetFunctionPointer _gfp;

		// Token: 0x0200476C RID: 18284
		// (Invoke) Token: 0x0601A48F RID: 107663
		public delegate void SetFunctionPointer(T v);

		// Token: 0x0200476D RID: 18285
		// (Invoke) Token: 0x0601A493 RID: 107667
		public delegate T GetFunctionPointer();
	}
}
