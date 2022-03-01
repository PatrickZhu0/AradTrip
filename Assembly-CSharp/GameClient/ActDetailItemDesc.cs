using System;

namespace GameClient
{
	// Token: 0x02001CEA RID: 7402
	public class ActDetailItemDesc : ActDetailBaseDesc
	{
		// Token: 0x06012300 RID: 74496 RVA: 0x0054D9AC File Offset: 0x0054BDAC
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
