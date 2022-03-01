using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200415C RID: 16732
	public class BeClientSwitch
	{
		// Token: 0x06016DE6 RID: 93670 RVA: 0x00708CA4 File Offset: 0x007070A4
		public static bool FunctionIsOpen(ClientSwitchType type)
		{
			if (BeClientSwitch.m_RocordDataDic.ContainsKey((int)type))
			{
				return BeClientSwitch.m_RocordDataDic[(int)type];
			}
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>((int)type, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return true;
			}
			BeClientSwitch.m_RocordDataDic.Add((int)type, tableItem.Open);
			return tableItem.Open;
		}

		// Token: 0x040105B4 RID: 66996
		protected static Dictionary<int, bool> m_RocordDataDic = new Dictionary<int, bool>();
	}
}
