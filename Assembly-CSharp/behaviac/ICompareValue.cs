using System;
using System.Collections;
using System.Reflection;

namespace behaviac
{
	// Token: 0x0200480A RID: 18442
	public interface ICompareValue
	{
		// Token: 0x0601A7FC RID: 108540
		bool ItemEqual(IList ll, IList rl, int index);

		// Token: 0x0601A7FD RID: 108541
		bool MemberEqual<U>(U lo, U ro, FieldInfo field);
	}
}
