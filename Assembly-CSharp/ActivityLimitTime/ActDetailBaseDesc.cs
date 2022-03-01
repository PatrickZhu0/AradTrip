using System;

namespace ActivityLimitTime
{
	// Token: 0x020018CC RID: 6348
	public class ActDetailBaseDesc : IActivityDetailDesc
	{
		// Token: 0x0600F806 RID: 63494 RVA: 0x004353BC File Offset: 0x004337BC
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
