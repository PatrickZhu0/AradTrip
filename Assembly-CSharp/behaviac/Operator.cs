using System;
using System.Collections;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004828 RID: 18472
	public static class Operator<T>
	{
		// Token: 0x0601A8AD RID: 108717 RVA: 0x00835268 File Offset: 0x00833668
		public static T Add(T left, T right)
		{
			IComputeValue<T> computeValue = ComputerRegister.Get<T>();
			if (computeValue != null)
			{
				return computeValue.Add(left, right);
			}
			return default(T);
		}

		// Token: 0x0601A8AE RID: 108718 RVA: 0x00835294 File Offset: 0x00833694
		public static T Subtract(T left, T right)
		{
			IComputeValue<T> computeValue = ComputerRegister.Get<T>();
			if (computeValue != null)
			{
				return computeValue.Sub(left, right);
			}
			return default(T);
		}

		// Token: 0x0601A8AF RID: 108719 RVA: 0x008352C0 File Offset: 0x008336C0
		public static T Multiply(T left, T right)
		{
			IComputeValue<T> computeValue = ComputerRegister.Get<T>();
			if (computeValue != null)
			{
				return computeValue.Mul(left, right);
			}
			return default(T);
		}

		// Token: 0x0601A8B0 RID: 108720 RVA: 0x008352EC File Offset: 0x008336EC
		public static T Divide(T left, T right)
		{
			IComputeValue<T> computeValue = ComputerRegister.Get<T>();
			if (computeValue != null)
			{
				return computeValue.Div(left, right);
			}
			return default(T);
		}

		// Token: 0x0601A8B1 RID: 108721 RVA: 0x00835318 File Offset: 0x00833718
		private static bool EqualByMember(T left, T right)
		{
			Type typeFromHandle = typeof(T);
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			foreach (FieldInfo fieldInfo in typeFromHandle.GetFields(bindingAttr))
			{
				if (!fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
				{
					ICompareValue compareValue = ComparerRegister.Get(fieldInfo.FieldType);
					if (compareValue != null)
					{
						if (!compareValue.MemberEqual<T>(left, right, fieldInfo))
						{
							return false;
						}
					}
					else
					{
						object value = fieldInfo.GetValue(left);
						object value2 = fieldInfo.GetValue(right);
						if (value != null || value2 != null)
						{
							if (value == null || value2 == null)
							{
								return false;
							}
							if (!value.Equals(value2))
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0601A8B2 RID: 108722 RVA: 0x008353F8 File Offset: 0x008337F8
		public static bool ClassEqual(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			if (compareValue == null)
			{
				return Operator<T>.EqualByMember(left, right);
			}
			return compareValue.Equal(left, right);
		}

		// Token: 0x0601A8B3 RID: 108723 RVA: 0x00835424 File Offset: 0x00833824
		public static bool ListEqual(T left, T right)
		{
			IList list = left as IList;
			if (list != null)
			{
				IList list2 = right as IList;
				if (list.Count != list2.Count)
				{
					return false;
				}
				Type typeFromHandle = typeof(T);
				Type type = typeFromHandle.GetGenericArguments()[0];
				ICompareValue compareValue = ComparerRegister.Get(type);
				if (compareValue != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (!compareValue.ItemEqual(list, list2, i))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0601A8B4 RID: 108724 RVA: 0x008354B4 File Offset: 0x008338B4
		public static bool Equal(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			if (compareValue == null)
			{
				Type typeFromHandle = typeof(T);
				if (typeFromHandle.IsValueType)
				{
					return left.Equals(right);
				}
				ICompareValue<object> compareValue2 = ComparerRegister.Get<object>();
				if (compareValue2 != null)
				{
					return compareValue2.Equal(left, right);
				}
			}
			return compareValue != null && compareValue.Equal(left, right);
		}

		// Token: 0x0601A8B5 RID: 108725 RVA: 0x0083552C File Offset: 0x0083392C
		public static bool NotEqual(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			if (compareValue == null)
			{
				Type typeFromHandle = typeof(T);
				if (typeFromHandle.IsValueType)
				{
					return !left.Equals(right);
				}
				ICompareValue<object> compareValue2 = ComparerRegister.Get<object>();
				if (compareValue2 != null)
				{
					return compareValue2.NotEqual(left, right);
				}
			}
			return compareValue != null && compareValue.NotEqual(left, right);
		}

		// Token: 0x0601A8B6 RID: 108726 RVA: 0x008355A8 File Offset: 0x008339A8
		public static bool GreaterThan(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			return compareValue != null && compareValue.Greater(left, right);
		}

		// Token: 0x0601A8B7 RID: 108727 RVA: 0x008355CC File Offset: 0x008339CC
		public static bool GreaterThanOrEqual(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			return compareValue != null && compareValue.GreaterEqual(left, right);
		}

		// Token: 0x0601A8B8 RID: 108728 RVA: 0x008355F0 File Offset: 0x008339F0
		public static bool LessThan(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			return compareValue != null && compareValue.Less(left, right);
		}

		// Token: 0x0601A8B9 RID: 108729 RVA: 0x00835614 File Offset: 0x00833A14
		public static bool LessThanOrEqual(T left, T right)
		{
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			return compareValue != null && compareValue.LessEqual(left, right);
		}
	}
}
