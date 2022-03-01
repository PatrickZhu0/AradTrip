using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004827 RID: 18471
	public class ComputerRegister
	{
		// Token: 0x0601A8A8 RID: 108712 RVA: 0x008350D4 File Offset: 0x008334D4
		private static void Register()
		{
			ComputeValueInt value = new ComputeValueInt();
			ComputerRegister.ms_valueComputers.Add(typeof(int), value);
			ComputeValueLong value2 = new ComputeValueLong();
			ComputerRegister.ms_valueComputers.Add(typeof(long), value2);
			ComputeValueShort value3 = new ComputeValueShort();
			ComputerRegister.ms_valueComputers.Add(typeof(short), value3);
			ComputeValueByte value4 = new ComputeValueByte();
			ComputerRegister.ms_valueComputers.Add(typeof(sbyte), value4);
			ComputeValueUInt value5 = new ComputeValueUInt();
			ComputerRegister.ms_valueComputers.Add(typeof(uint), value5);
			ComputeValueULong value6 = new ComputeValueULong();
			ComputerRegister.ms_valueComputers.Add(typeof(ulong), value6);
			ComputeValueUShort value7 = new ComputeValueUShort();
			ComputerRegister.ms_valueComputers.Add(typeof(ushort), value7);
			ComputeValueUByte value8 = new ComputeValueUByte();
			ComputerRegister.ms_valueComputers.Add(typeof(byte), value8);
			ComputeValueFloat value9 = new ComputeValueFloat();
			ComputerRegister.ms_valueComputers.Add(typeof(float), value9);
			ComputeValueDouble value10 = new ComputeValueDouble();
			ComputerRegister.ms_valueComputers.Add(typeof(double), value10);
		}

		// Token: 0x0601A8A9 RID: 108713 RVA: 0x008351FB File Offset: 0x008335FB
		public static void Init()
		{
			if (ComputerRegister.ms_valueComputers == null)
			{
				ComputerRegister.ms_valueComputers = new Dictionary<Type, IComputeValue>();
				ComputerRegister.Register();
			}
		}

		// Token: 0x0601A8AA RID: 108714 RVA: 0x00835216 File Offset: 0x00833616
		public static void Cleanup()
		{
			ComputerRegister.ms_valueComputers.Clear();
			ComputerRegister.ms_valueComputers = null;
		}

		// Token: 0x0601A8AB RID: 108715 RVA: 0x00835228 File Offset: 0x00833628
		public static IComputeValue<T> Get<T>()
		{
			Type typeFromHandle = typeof(T);
			if (ComputerRegister.ms_valueComputers.ContainsKey(typeFromHandle))
			{
				IComputeValue computeValue = ComputerRegister.ms_valueComputers[typeFromHandle];
				return (IComputeValue<T>)computeValue;
			}
			return null;
		}

		// Token: 0x0401292C RID: 76076
		private static Dictionary<Type, IComputeValue> ms_valueComputers;
	}
}
