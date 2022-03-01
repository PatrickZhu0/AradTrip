using System;

namespace behaviac
{
	// Token: 0x02004765 RID: 18277
	public class TValue<T> : IValue
	{
		// Token: 0x0601A459 RID: 107609 RVA: 0x008267C3 File Offset: 0x00824BC3
		public TValue(T v)
		{
			Utils.Clone<T>(ref this.value, v);
		}

		// Token: 0x0601A45A RID: 107610 RVA: 0x008267D7 File Offset: 0x00824BD7
		public TValue(TValue<T> rhs)
		{
			Utils.Clone<T>(ref this.value, rhs.value);
		}

		// Token: 0x0601A45B RID: 107611 RVA: 0x008267F0 File Offset: 0x00824BF0
		public TValue<T> Clone()
		{
			return new TValue<T>(this);
		}

		// Token: 0x0601A45C RID: 107612 RVA: 0x008267F8 File Offset: 0x00824BF8
		public void Log(Agent agent, string name, bool bForce)
		{
		}

		// Token: 0x0401270C RID: 75532
		public T value;
	}
}
