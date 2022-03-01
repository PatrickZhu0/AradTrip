using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D48 RID: 3400
	public class Vector2Serializer
	{
		// Token: 0x06008A56 RID: 35414 RVA: 0x0019628C File Offset: 0x0019468C
		public static Vector2 ToVector2(string value)
		{
			string[] array = value.Split(new char[]
			{
				','
			});
			return new Vector2(float.Parse(array[0]), float.Parse(array[1]));
		}

		// Token: 0x06008A57 RID: 35415 RVA: 0x001962C0 File Offset: 0x001946C0
		public static string FromVector2(Vector2 value)
		{
			return string.Format("{0},{1}", value.x, value.y);
		}
	}
}
