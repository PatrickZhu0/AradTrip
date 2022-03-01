using System;

namespace behaviac
{
	// Token: 0x0200482B RID: 18475
	public class ValueConverter<T>
	{
		// Token: 0x0601A8BE RID: 108734 RVA: 0x008359C9 File Offset: 0x00833DC9
		public static bool Convert(string valueStr, out T result)
		{
			result = (T)((object)StringUtils.FromString(typeof(T), valueStr, false));
			return true;
		}
	}
}
