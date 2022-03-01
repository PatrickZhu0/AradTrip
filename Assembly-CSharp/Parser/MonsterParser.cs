using System;
using ProtoTable;

namespace Parser
{
	// Token: 0x020045F3 RID: 17907
	public class MonsterParser : IParser
	{
		// Token: 0x060192D0 RID: 103120 RVA: 0x007F60B0 File Offset: 0x007F44B0
		public ParserReturn OnParse(string value)
		{
			ParserReturn result;
			result.color = "#ffffff";
			result.iId = 0U;
			result.content = string.Empty;
			string text = value.TrimStart(new char[]
			{
				'['
			});
			text = text.TrimEnd(new char[]
			{
				']'
			});
			int num = int.Parse(text);
			UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			result.color = "#179fcb";
			result.content = tableItem.Name;
			result.iId = (uint)num;
			return result;
		}
	}
}
