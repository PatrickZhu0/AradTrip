using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200481A RID: 18458
	public class ComparerRegister
	{
		// Token: 0x0601A86A RID: 108650 RVA: 0x00834AE8 File Offset: 0x00832EE8
		private static void Register()
		{
			CompareValueBool value = new CompareValueBool();
			ComparerRegister.ms_valueComparers.Add(typeof(bool), value);
			CompareValueInt value2 = new CompareValueInt();
			ComparerRegister.ms_valueComparers.Add(typeof(int), value2);
			CompareValueLong value3 = new CompareValueLong();
			ComparerRegister.ms_valueComparers.Add(typeof(long), value3);
			CompareValueShort value4 = new CompareValueShort();
			ComparerRegister.ms_valueComparers.Add(typeof(short), value4);
			CompareValueByte value5 = new CompareValueByte();
			ComparerRegister.ms_valueComparers.Add(typeof(sbyte), value5);
			CompareValueUInt value6 = new CompareValueUInt();
			ComparerRegister.ms_valueComparers.Add(typeof(uint), value6);
			CompareValueULong value7 = new CompareValueULong();
			ComparerRegister.ms_valueComparers.Add(typeof(ulong), value7);
			CompareValueUShort value8 = new CompareValueUShort();
			ComparerRegister.ms_valueComparers.Add(typeof(ushort), value8);
			CompareValueUByte value9 = new CompareValueUByte();
			ComparerRegister.ms_valueComparers.Add(typeof(byte), value9);
			CompareValueChar value10 = new CompareValueChar();
			ComparerRegister.ms_valueComparers.Add(typeof(char), value10);
			CompareValueFloat value11 = new CompareValueFloat();
			ComparerRegister.ms_valueComparers.Add(typeof(float), value11);
			CompareValueDouble value12 = new CompareValueDouble();
			ComparerRegister.ms_valueComparers.Add(typeof(double), value12);
			CompareValueString value13 = new CompareValueString();
			ComparerRegister.ms_valueComparers.Add(typeof(string), value13);
			CompareValueObject value14 = new CompareValueObject();
			ComparerRegister.ms_valueComparers.Add(typeof(object), value14);
		}

		// Token: 0x0601A86B RID: 108651 RVA: 0x00834C83 File Offset: 0x00833083
		public static void Init()
		{
			if (ComparerRegister.ms_valueComparers == null)
			{
				ComparerRegister.ms_valueComparers = new Dictionary<Type, ICompareValue>();
				ComparerRegister.Register();
			}
		}

		// Token: 0x0601A86C RID: 108652 RVA: 0x00834C9E File Offset: 0x0083309E
		public static void Cleanup()
		{
			ComparerRegister.ms_valueComparers.Clear();
			ComparerRegister.ms_valueComparers = null;
		}

		// Token: 0x0601A86D RID: 108653 RVA: 0x00834CB0 File Offset: 0x008330B0
		public static void RegisterType<T, TCOMPARER>() where TCOMPARER : ICompareValue, new()
		{
			TCOMPARER tcomparer = Activator.CreateInstance<TCOMPARER>();
			ComparerRegister.ms_valueComparers.Add(typeof(T), tcomparer);
		}

		// Token: 0x0601A86E RID: 108654 RVA: 0x00834CE0 File Offset: 0x008330E0
		public static ICompareValue<T> Get<T>()
		{
			Type typeFromHandle = typeof(T);
			if (ComparerRegister.ms_valueComparers.ContainsKey(typeFromHandle))
			{
				ICompareValue compareValue = ComparerRegister.ms_valueComparers[typeFromHandle];
				return (ICompareValue<T>)compareValue;
			}
			return null;
		}

		// Token: 0x0601A86F RID: 108655 RVA: 0x00834D1C File Offset: 0x0083311C
		public static ICompareValue Get(Type type)
		{
			if (ComparerRegister.ms_valueComparers.ContainsKey(type))
			{
				return ComparerRegister.ms_valueComparers[type];
			}
			return null;
		}

		// Token: 0x0401292B RID: 76075
		private static Dictionary<Type, ICompareValue> ms_valueComparers;
	}
}
