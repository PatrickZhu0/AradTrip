using System;

namespace behaviac
{
	// Token: 0x02004813 RID: 18451
	public class CompareValueUShort : ICompareValue<ushort>
	{
		// Token: 0x0601A839 RID: 108601 RVA: 0x00834993 File Offset: 0x00832D93
		public override bool Equal(ushort lhs, ushort rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A83A RID: 108602 RVA: 0x00834999 File Offset: 0x00832D99
		public override bool NotEqual(ushort lhs, ushort rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A83B RID: 108603 RVA: 0x008349A2 File Offset: 0x00832DA2
		public override bool Greater(ushort lhs, ushort rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A83C RID: 108604 RVA: 0x008349A8 File Offset: 0x00832DA8
		public override bool GreaterEqual(ushort lhs, ushort rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A83D RID: 108605 RVA: 0x008349B1 File Offset: 0x00832DB1
		public override bool Less(ushort lhs, ushort rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A83E RID: 108606 RVA: 0x008349B7 File Offset: 0x00832DB7
		public override bool LessEqual(ushort lhs, ushort rhs)
		{
			return lhs <= rhs;
		}
	}
}
