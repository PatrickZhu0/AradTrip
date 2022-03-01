using System;
using GameClient;

namespace ActivityLimitTime
{
	// Token: 0x020018CD RID: 6349
	public class ActDetailItemDesc : ActDetailBaseDesc
	{
		// Token: 0x0600F808 RID: 63496 RVA: 0x00435408 File Offset: 0x00433808
		public override string FormatActivityDesc(string descFormat, params int[] values)
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
				if (num > 1)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)array[1], 100, 0);
					string name = itemData.Name;
					object obj = array[0];
					array[0] = name;
					array[1] = obj;
				}
			}
			return string.Format(descFormat, array);
		}
	}
}
