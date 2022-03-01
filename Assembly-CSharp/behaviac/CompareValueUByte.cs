using System;

namespace behaviac
{
	// Token: 0x02004814 RID: 18452
	public class CompareValueUByte : ICompareValue<byte>
	{
		// Token: 0x0601A840 RID: 108608 RVA: 0x008349C8 File Offset: 0x00832DC8
		public override bool Equal(byte lhs, byte rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A841 RID: 108609 RVA: 0x008349CE File Offset: 0x00832DCE
		public override bool NotEqual(byte lhs, byte rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A842 RID: 108610 RVA: 0x008349D7 File Offset: 0x00832DD7
		public override bool Greater(byte lhs, byte rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A843 RID: 108611 RVA: 0x008349DD File Offset: 0x00832DDD
		public override bool GreaterEqual(byte lhs, byte rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A844 RID: 108612 RVA: 0x008349E6 File Offset: 0x00832DE6
		public override bool Less(byte lhs, byte rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A845 RID: 108613 RVA: 0x008349EC File Offset: 0x00832DEC
		public override bool LessEqual(byte lhs, byte rhs)
		{
			return lhs <= rhs;
		}
	}
}
