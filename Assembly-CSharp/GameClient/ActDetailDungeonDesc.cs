using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CEC RID: 7404
	public class ActDetailDungeonDesc : ActDetailBaseDesc
	{
		// Token: 0x06012304 RID: 74500 RVA: 0x0054DA28 File Offset: 0x0054BE28
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
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>((int)array[1], string.Empty, string.Empty);
					if (tableItem != null)
					{
						string name = tableItem.Name;
						object obj = array[0];
						array[0] = name;
						array[1] = obj;
					}
				}
			}
			return string.Format(descFormat, array);
		}
	}
}
