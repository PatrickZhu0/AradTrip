using System;

namespace behaviac
{
	// Token: 0x0200481C RID: 18460
	public interface IComputeValue<T> : IComputeValue
	{
		// Token: 0x0601A871 RID: 108657
		T Add(T opr1, T opr2);

		// Token: 0x0601A872 RID: 108658
		T Sub(T opr1, T opr2);

		// Token: 0x0601A873 RID: 108659
		T Mul(T opr1, T opr2);

		// Token: 0x0601A874 RID: 108660
		T Div(T opr1, T opr2);
	}
}
