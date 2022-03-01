using System;

namespace behaviac
{
	// Token: 0x02004774 RID: 18292
	public class CMemberArrayItemProperty<T> : CProperty<T>
	{
		// Token: 0x0601A4AC RID: 107692 RVA: 0x00826A21 File Offset: 0x00824E21
		public CMemberArrayItemProperty(string name, CMemberArrayItemProperty<T>.SetFunctionPointer sfp, CMemberArrayItemProperty<T>.GetFunctionPointer gfp) : base(name)
		{
			this._sfp = sfp;
			this._gfp = gfp;
		}

		// Token: 0x0601A4AD RID: 107693 RVA: 0x00826A38 File Offset: 0x00824E38
		public override T GetValue(Agent self, int index)
		{
			return this._gfp(self, index);
		}

		// Token: 0x0601A4AE RID: 107694 RVA: 0x00826A47 File Offset: 0x00824E47
		public override void SetValue(Agent self, T value, int index)
		{
			this._sfp(self, value, index);
		}

		// Token: 0x04012717 RID: 75543
		private CMemberArrayItemProperty<T>.SetFunctionPointer _sfp;

		// Token: 0x04012718 RID: 75544
		private CMemberArrayItemProperty<T>.GetFunctionPointer _gfp;

		// Token: 0x02004775 RID: 18293
		// (Invoke) Token: 0x0601A4B0 RID: 107696
		public delegate void SetFunctionPointer(Agent a, T v, int index);

		// Token: 0x02004776 RID: 18294
		// (Invoke) Token: 0x0601A4B4 RID: 107700
		public delegate T GetFunctionPointer(Agent a, int index);
	}
}
