using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D49 RID: 3401
	public class RectSerializer
	{
		// Token: 0x06008A59 RID: 35417 RVA: 0x001962EC File Offset: 0x001946EC
		public static Rect ToRect(string value)
		{
			string[] array = value.Split(new char[]
			{
				','
			});
			return new Rect(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]), float.Parse(array[3]));
		}

		// Token: 0x06008A5A RID: 35418 RVA: 0x00196330 File Offset: 0x00194730
		public static string FromRect(Rect value)
		{
			return string.Format("{0},{1},{2},{3}", new object[]
			{
				value.x,
				value.y,
				value.width,
				value.height
			});
		}
	}
}
