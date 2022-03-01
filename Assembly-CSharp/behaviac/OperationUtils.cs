using System;

namespace behaviac
{
	// Token: 0x0200482A RID: 18474
	public static class OperationUtils
	{
		// Token: 0x0601A8BA RID: 108730 RVA: 0x00835638 File Offset: 0x00833A38
		public static EOperatorType ParseOperatorType(string operatorType)
		{
			switch (operatorType)
			{
			case "Invalid":
				return EOperatorType.E_INVALID;
			case "Assign":
				return EOperatorType.E_ASSIGN;
			case "Assignment":
				return EOperatorType.E_ASSIGN;
			case "Add":
				return EOperatorType.E_ADD;
			case "Sub":
				return EOperatorType.E_SUB;
			case "Mul":
				return EOperatorType.E_MUL;
			case "Div":
				return EOperatorType.E_DIV;
			case "Equal":
				return EOperatorType.E_EQUAL;
			case "NotEqual":
				return EOperatorType.E_NOTEQUAL;
			case "Greater":
				return EOperatorType.E_GREATER;
			case "GreaterEqual":
				return EOperatorType.E_GREATEREQUAL;
			case "Less":
				return EOperatorType.E_LESS;
			case "LessEqual":
				return EOperatorType.E_LESSEQUAL;
			}
			return EOperatorType.E_INVALID;
		}

		// Token: 0x0601A8BB RID: 108731 RVA: 0x00835774 File Offset: 0x00833B74
		public static bool Compare<T>(T left, T right, EOperatorType comparisonType)
		{
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsValueType)
			{
				bool flag = left == null;
				bool flag2 = right == null;
				if (flag && flag2)
				{
					if (comparisonType == EOperatorType.E_EQUAL)
					{
						return true;
					}
					if (comparisonType == EOperatorType.E_NOTEQUAL)
					{
						return false;
					}
				}
				else if (flag || flag2)
				{
					if (comparisonType == EOperatorType.E_EQUAL)
					{
						return false;
					}
					if (comparisonType == EOperatorType.E_NOTEQUAL)
					{
						return true;
					}
				}
			}
			ICompareValue<T> compareValue = ComparerRegister.Get<T>();
			if (compareValue != null)
			{
				switch (comparisonType)
				{
				case EOperatorType.E_EQUAL:
					return Operator<T>.Equal(left, right);
				case EOperatorType.E_NOTEQUAL:
					return Operator<T>.NotEqual(left, right);
				case EOperatorType.E_GREATER:
					return Operator<T>.GreaterThan(left, right);
				case EOperatorType.E_GREATEREQUAL:
					return Operator<T>.GreaterThanOrEqual(left, right);
				case EOperatorType.E_LESS:
					return Operator<T>.LessThan(left, right);
				case EOperatorType.E_LESSEQUAL:
					return Operator<T>.LessThanOrEqual(left, right);
				}
			}
			if (!typeFromHandle.IsValueType)
			{
				bool flag3 = object.ReferenceEquals(left, right);
				if (flag3)
				{
					return true;
				}
			}
			if (Utils.IsCustomStructType(typeFromHandle))
			{
				bool flag4 = Operator<T>.ClassEqual(left, right);
				if (comparisonType == EOperatorType.E_EQUAL)
				{
					return flag4;
				}
				if (comparisonType == EOperatorType.E_NOTEQUAL)
				{
					return !flag4;
				}
			}
			else if (Utils.IsArrayType(typeFromHandle))
			{
				bool flag5 = Operator<T>.ListEqual(left, right);
				if (comparisonType == EOperatorType.E_EQUAL)
				{
					return flag5;
				}
				if (comparisonType == EOperatorType.E_NOTEQUAL)
				{
					return !flag5;
				}
			}
			else if (Utils.IsEnumType(typeFromHandle))
			{
				if (comparisonType == EOperatorType.E_EQUAL)
				{
					return Operator<T>.Equal(left, right);
				}
				if (comparisonType == EOperatorType.E_NOTEQUAL)
				{
					return Operator<T>.NotEqual(left, right);
				}
			}
			return false;
		}

		// Token: 0x0601A8BC RID: 108732 RVA: 0x00835914 File Offset: 0x00833D14
		public static T Compute<T>(T left, T right, EOperatorType computeType)
		{
			Type typeFromHandle = typeof(T);
			if (!Utils.IsAgentType(typeFromHandle) && !Utils.IsCustomClassType(typeFromHandle) && !Utils.IsCustomStructType(typeFromHandle) && !Utils.IsArrayType(typeFromHandle) && !Utils.IsStringType(typeFromHandle))
			{
				if (!Utils.IsEnumType(typeFromHandle) && typeFromHandle != typeof(char))
				{
					switch (computeType)
					{
					case EOperatorType.E_ADD:
						return Operator<T>.Add(left, right);
					case EOperatorType.E_SUB:
						return Operator<T>.Subtract(left, right);
					case EOperatorType.E_MUL:
						return Operator<T>.Multiply(left, right);
					case EOperatorType.E_DIV:
						return Operator<T>.Divide(left, right);
					}
				}
			}
			return left;
		}
	}
}
