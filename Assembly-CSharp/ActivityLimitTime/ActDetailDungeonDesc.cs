using System;
using ProtoTable;

namespace ActivityLimitTime
{
	// Token: 0x020018CE RID: 6350
	public class ActDetailDungeonDesc : ActDetailBaseDesc
	{
		// Token: 0x0600F80A RID: 63498 RVA: 0x00435484 File Offset: 0x00433884
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
