using System;
using ProtoTable;

namespace Parser
{
	// Token: 0x020045F7 RID: 17911
	public class MissionParser : IParser
	{
		// Token: 0x060192DF RID: 103135 RVA: 0x007F64C4 File Offset: 0x007F48C4
		public ParserReturn OnParse(string value)
		{
			ParserReturn result;
			result.color = "#FFFFFF";
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
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			result.color = "blue";
			result.content = tableItem.TaskName;
			result.iId = (uint)num;
			return result;
		}
	}
}
