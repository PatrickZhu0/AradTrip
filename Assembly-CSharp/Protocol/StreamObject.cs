using System;
using System.Collections.Generic;
using System.Reflection;

namespace Protocol
{
	// Token: 0x02000664 RID: 1636
	public class StreamObject
	{
		// Token: 0x060055E4 RID: 21988 RVA: 0x00105968 File Offset: 0x00103D68
		public virtual bool GetStructProperty(FieldInfo field, byte[] buffer, ref int pos, int length)
		{
			return false;
		}

		// Token: 0x040021F3 RID: 8691
		public List<int> dirtyFields = new List<int>();
	}
}
