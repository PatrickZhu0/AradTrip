using System;

namespace GameClient
{
	// Token: 0x02001CEB RID: 7403
	public class ActDetailBaseDesc : IActivityDetailDesc
	{
		// Token: 0x06012302 RID: 74498 RVA: 0x0054D960 File Offset: 0x0054BD60
		public virtual string FormatActivityDesc(string descFormat, params int[] values)
		{
			object[] array = null;
			if (values != null)
			{
				int num = values.Length;
				array = new object[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = values[i];
				}
			}
			return string.Format(descFormat, array);
		}
	}
}
