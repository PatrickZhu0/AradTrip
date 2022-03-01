using System;
using UnityEngine;

namespace UiParticles
{
	// Token: 0x02000D56 RID: 3414
	internal static class SetPropertyUtility
	{
		// Token: 0x06008AAB RID: 35499 RVA: 0x001978AC File Offset: 0x00195CAC
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			if (currentValue.r == newValue.r && currentValue.g == newValue.g && currentValue.b == newValue.b && currentValue.a == newValue.a)
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06008AAC RID: 35500 RVA: 0x0019790B File Offset: 0x00195D0B
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06008AAD RID: 35501 RVA: 0x00197930 File Offset: 0x00195D30
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}
	}
}
