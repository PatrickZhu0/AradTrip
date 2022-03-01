using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace behaviac
{
	// Token: 0x0200480B RID: 18443
	public class ICompareValue<T> : ICompareValue
	{
		// Token: 0x0601A7FF RID: 108543 RVA: 0x006D5220 File Offset: 0x006D3620
		public bool ItemEqual(IList ll, IList rl, int index)
		{
			List<T> list = (List<T>)ll;
			List<T> list2 = (List<T>)rl;
			T left = list[index];
			T right = list2[index];
			return OperationUtils.Compare<T>(left, right, EOperatorType.E_EQUAL);
		}

		// Token: 0x0601A800 RID: 108544 RVA: 0x006D5254 File Offset: 0x006D3654
		public bool MemberEqual<U>(U lo, U ro, FieldInfo field)
		{
			T left = (T)((object)field.GetValue(lo));
			T right = (T)((object)field.GetValue(ro));
			return OperationUtils.Compare<T>(left, right, EOperatorType.E_EQUAL);
		}

		// Token: 0x0601A801 RID: 108545 RVA: 0x006D528D File Offset: 0x006D368D
		public virtual bool Equal(T lhs, T rhs)
		{
			return false;
		}

		// Token: 0x0601A802 RID: 108546 RVA: 0x006D5290 File Offset: 0x006D3690
		public virtual bool NotEqual(T lhs, T rhs)
		{
			return false;
		}

		// Token: 0x0601A803 RID: 108547 RVA: 0x006D5293 File Offset: 0x006D3693
		public virtual bool Greater(T lhs, T rhs)
		{
			return false;
		}

		// Token: 0x0601A804 RID: 108548 RVA: 0x006D5296 File Offset: 0x006D3696
		public virtual bool GreaterEqual(T lhs, T rhs)
		{
			return false;
		}

		// Token: 0x0601A805 RID: 108549 RVA: 0x006D5299 File Offset: 0x006D3699
		public virtual bool Less(T lhs, T rhs)
		{
			return false;
		}

		// Token: 0x0601A806 RID: 108550 RVA: 0x006D529C File Offset: 0x006D369C
		public virtual bool LessEqual(T lhs, T rhs)
		{
			return false;
		}
	}
}
