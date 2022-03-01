using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000E56 RID: 3670
	public class SwitchFunctionUtility
	{
		// Token: 0x060091E4 RID: 37348 RVA: 0x001B08F4 File Offset: 0x001AECF4
		public static bool IsOpen(int id)
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(id, string.Empty, string.Empty);
			return tableItem == null || tableItem.Open;
		}
	}
}
