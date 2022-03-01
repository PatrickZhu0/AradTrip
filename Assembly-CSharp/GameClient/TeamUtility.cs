using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C21 RID: 7201
	public class TeamUtility
	{
		// Token: 0x06011AA7 RID: 72359 RVA: 0x0052CDAC File Offset: 0x0052B1AC
		public static void OnMissionTraceSelectTeam(bool isSelect)
		{
			int num = (!DataManager<TeamDataManager>.GetInstance().HasTeam()) ? 0 : 1;
			int num2 = (!isSelect) ? 0 : 1;
			bool isOpen = TeamUtility.kMissionTraceOpenFlag[num, num2, 0];
			bool flag = TeamUtility.kMissionTraceOpenFlag[num, num2, 1];
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				TeamUtility._opFrame<TeamMainFrame>(isOpen);
				TeamUtility._opFrame<TeamMainMenuFrame>(flag);
				if (flag && !DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
				}
				if (flag && DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList)
				{
					DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList = false;
				}
			}
		}

		// Token: 0x06011AA8 RID: 72360 RVA: 0x0052CE60 File Offset: 0x0052B260
		private static void _opFrame<T>(bool isOpen) where T : ClientFrame
		{
			if (isOpen)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(typeof(T)))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<T>((T)((object)null), false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<T>(FrameLayer.Bottom, null, string.Empty);
			}
			else if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(typeof(T)))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<T>((T)((object)null), false);
			}
		}

		// Token: 0x06011AA9 RID: 72361 RVA: 0x0052CEE0 File Offset: 0x0052B2E0
		public static bool IsNormalTeamDungeonID(int teamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
			return tableItem != null && (tableItem.ShowIndependent == 1 || tableItem.Type == TeamDungeonTable.eType.DUNGEON);
		}

		// Token: 0x06011AAA RID: 72362 RVA: 0x0052CF24 File Offset: 0x0052B324
		public static bool IsEliteTeamDungeonID(int teamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
			return tableItem != null && TeamUtility.IsEliteDungeonID(tableItem.DungeonID);
		}

		// Token: 0x06011AAB RID: 72363 RVA: 0x0052CF5C File Offset: 0x0052B35C
		public static bool IsEliteDungeonID(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			return tableItem != null && tableItem.ThreeType == DungeonTable.eThreeType.T_T_TEAM_ELITE;
		}

		// Token: 0x06011AAC RID: 72364 RVA: 0x0052CF90 File Offset: 0x0052B390
		public static TeamUtility.eType GetTeamDungeonType(int teamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return TeamUtility.eType.NoTarget;
			}
			if (tableItem.ShowIndependent == 1)
			{
				return TeamUtility.eType.NoTarget;
			}
			if (tableItem.Type == TeamDungeonTable.eType.DUNGEON)
			{
				return TeamUtility.eType.Dungeon;
			}
			if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
			{
				return TeamUtility.eType.AttackCityMonster;
			}
			return TeamUtility.eType.Menu;
		}

		// Token: 0x06011AAD RID: 72365 RVA: 0x0052CFE8 File Offset: 0x0052B3E8
		public static int GetMenuTeamDungeonID(int teamDungeonID)
		{
			switch (TeamUtility.GetTeamDungeonType(teamDungeonID))
			{
			case TeamUtility.eType.NoTarget:
			case TeamUtility.eType.Menu:
				return teamDungeonID;
			case TeamUtility.eType.Dungeon:
			{
				TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.MenuID;
				}
				break;
			}
			case TeamUtility.eType.AttackCityMonster:
			{
				TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					return tableItem2.MenuID;
				}
				break;
			}
			}
			return -1;
		}

		// Token: 0x06011AAE RID: 72366 RVA: 0x0052D06C File Offset: 0x0052B46C
		public static void GetSpriteByOccu(ref Image image, byte occu)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref image, tableItem2.IconPath, true);
					return;
				}
			}
		}

		// Token: 0x06011AAF RID: 72367 RVA: 0x0052D0C5 File Offset: 0x0052B4C5
		// Note: this type is marked as 'beforefieldinit'.
		static TeamUtility()
		{
			bool[,,] array = new bool[2, 2, 2];
			array[0, 1, 1] = true;
			array[1, 1, 0] = true;
			TeamUtility.kMissionTraceOpenFlag = array;
		}

		// Token: 0x0400B814 RID: 47124
		public const uint kDefaultTeamDungeonID = 1U;

		// Token: 0x0400B815 RID: 47125
		private static bool[,,] kMissionTraceOpenFlag;

		// Token: 0x0400B816 RID: 47126
		private const int kTeamMainMenuIdx = 0;

		// Token: 0x0400B817 RID: 47127
		private const int kTeamMain = 1;

		// Token: 0x02001C22 RID: 7202
		public enum eType
		{
			// Token: 0x0400B819 RID: 47129
			NoTarget,
			// Token: 0x0400B81A RID: 47130
			Menu,
			// Token: 0x0400B81B RID: 47131
			Dungeon,
			// Token: 0x0400B81C RID: 47132
			AttackCityMonster
		}
	}
}
