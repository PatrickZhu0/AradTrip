using System;

namespace Spine.Unity
{
	// Token: 0x020049F9 RID: 18937
	public class DoubleBuffered<T> where T : new()
	{
		// Token: 0x0601B532 RID: 111922 RVA: 0x008689F0 File Offset: 0x00866DF0
		public T GetCurrent()
		{
			return (!this.usingA) ? this.b : this.a;
		}

		// Token: 0x0601B533 RID: 111923 RVA: 0x00868A0E File Offset: 0x00866E0E
		public T GetNext()
		{
			this.usingA = !this.usingA;
			return (!this.usingA) ? this.b : this.a;
		}

		// Token: 0x04013073 RID: 77939
		private readonly T a = Activator.CreateInstance<T>();

		// Token: 0x04013074 RID: 77940
		private readonly T b = Activator.CreateInstance<T>();

		// Token: 0x04013075 RID: 77941
		private bool usingA;
	}
}
