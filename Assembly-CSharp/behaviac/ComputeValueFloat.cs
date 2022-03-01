using System;

namespace behaviac
{
	// Token: 0x02004825 RID: 18469
	public class ComputeValueFloat : IComputeValue<float>, IComputeValue
	{
		// Token: 0x0601A89E RID: 108702 RVA: 0x00835024 File Offset: 0x00833424
		public float Add(float lhs, float rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A89F RID: 108703 RVA: 0x00835038 File Offset: 0x00833438
		public float Sub(float lhs, float rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A8A0 RID: 108704 RVA: 0x0083504C File Offset: 0x0083344C
		public float Mul(float lhs, float rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A8A1 RID: 108705 RVA: 0x00835060 File Offset: 0x00833460
		public float Div(float lhs, float rhs)
		{
			return lhs / rhs;
		}
	}
}
