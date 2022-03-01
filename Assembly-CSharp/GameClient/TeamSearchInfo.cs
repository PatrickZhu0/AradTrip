using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001308 RID: 4872
	internal class TeamSearchInfo
	{
		// Token: 0x0600BD2E RID: 48430 RVA: 0x002C40D3 File Offset: 0x002C24D3
		public TeamSearchInfo()
		{
			this.Reset();
		}

		// Token: 0x0600BD2F RID: 48431 RVA: 0x002C40E4 File Offset: 0x002C24E4
		public uint[] GetTargetTeamList(uint teamDungeonID)
		{
			List<uint> list = new List<uint>();
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>((int)teamDungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.Type == TeamDungeonTable.eType.DUNGEON || tableItem.Type == TeamDungeonTable.eType.CityMonster || tableItem.ShowIndependent == 1)
				{
					list.Add(teamDungeonID);
				}
				else
				{
					Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<TeamDungeonTable>();
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
						if (teamDungeonTable != null && (long)teamDungeonTable.MenuID == (long)((ulong)teamDungeonID))
						{
							list.Add((uint)teamDungeonTable.ID);
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600BD30 RID: 48432 RVA: 0x002C41A5 File Offset: 0x002C25A5
		public void Reset()
		{
			this.teamID = 0U;
			this.teamName = string.Empty;
			this.chapterID = 0U;
			this.hardType = byte.MaxValue;
		}

		// Token: 0x0600BD31 RID: 48433 RVA: 0x002C41CB File Offset: 0x002C25CB
		public void Debug()
		{
		}

		// Token: 0x04006A65 RID: 27237
		public uint teamID;

		// Token: 0x04006A66 RID: 27238
		public string teamName;

		// Token: 0x04006A67 RID: 27239
		public uint chapterID;

		// Token: 0x04006A68 RID: 27240
		public byte hardType;
	}
}
