using System;

namespace Protocol
{
	// Token: 0x02000663 RID: 1635
	public class SPropertyAttribute : Attribute
	{
		// Token: 0x060055E2 RID: 21986 RVA: 0x001076F0 File Offset: 0x00105AF0
		public SPropertyAttribute(int id)
		{
			this.id = id;
		}

		// Token: 0x040021F2 RID: 8690
		public int id;
	}
}
