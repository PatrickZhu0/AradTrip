using System;

namespace GameClient
{
	// Token: 0x02000662 RID: 1634
	public class SortListDecoder
	{
		// Token: 0x060055E0 RID: 21984 RVA: 0x0010721C File Offset: 0x0010561C
		public static BaseSortListEntry GetEntry(SortListType type)
		{
			switch (type)
			{
			case SortListType.SORTLIST_1V1_SEASON:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIANHUN:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIQI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_AXIULUO:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MOFASHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SANDA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIEBA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QUMO:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGQISHI:
				return new SeasonSortListEntry();
			case SortListType.SORTLIST_GUILD_BATTLE_SCORE:
				return new GuildBattleScore();
			case SortListType.SORTLIST_GUILD_BATTLE_MEMBER:
				return new GuildBattleMemberScore();
			case SortListType.SORTLIST_GUILD_MEMBER_SCORE:
				return new GuildBattleMemberScore();
			case SortListType.SORTLIST_GUILD_LEVEL:
				return new GuildLevelSortListEntry();
			case SortListType.SORTLIST_GUILD_BATTLE_WEEK_SCORE:
				return new GuildBattleTerrScoreRank();
			default:
				switch (type)
				{
				case SortListType.SORTLIST_LEVEL:
				case SortListType.SORTLIST_XINFUCHONGJISAI:
					break;
				case SortListType.SORTLIST_WEAPON:
					goto IL_3B4;
				default:
					if (type == SortListType.SORTLIST_ACHIEVEMENT_SCORE)
					{
						return new AchievementScoreSortListEntry();
					}
					if (type == SortListType.SORTLIST_ADVENTURE_TEAM_GRADE)
					{
						return new AdventureTeamGradeSortListEntry();
					}
					if (type == SortListType.SORTLIST_TOWER_1)
					{
						goto IL_3AE;
					}
					if (type != SortListType.SORTLIST_PREMIUM_LEAGUE)
					{
						return null;
					}
					return new MoneyRewardsSortListEntry();
				case SortListType.SORTLIST_SCORE_WAR:
					return new ScoreWarSortListEntry();
				case SortListType.SORTLIST_NEW_YEAR_RED_PACKET:
					return new NewYearRedPacketSortListEntry();
				}
				break;
			case SortListType.SORTLIST_LEVEL_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_JIANHUN:
			case SortListType.SORTLIST_LEVEL_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_GUIQI:
			case SortListType.SORTLIST_LEVEL_OCCU_AXIULUO:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_LEVEL_OCCU_MANYOU:
			case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI:
			case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_MOFASHI:
			case SortListType.SORTLIST_LEVEL_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_LEVEL_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_SANDA:
			case SortListType.SORTLIST_LEVEL_OCCU_JIEBA:
			case SortListType.SORTLIST_LEVEL_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_LEVEL_OCCU_QUMO:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENGQISHI:
				break;
			case SortListType.SORTLIST_WEAPON_TT_ITEM_HUGESWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_KATANA:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_REVOLVER:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_HANDCANNON:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_WAND:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_STAFF:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SHORT_SWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_GLOVE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_BIKAI:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_CLAW:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_OFG:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_EAST_STICK:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSSBOW:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_RIFLE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_BEAMSWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SICKLE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_AXE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_BEADS:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSS:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SPEAR:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_STICK:
				goto IL_3B4;
			case SortListType.SORTLIST_TOWER_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_JIANHUN:
			case SortListType.SORTLIST_TOWER_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_GUIQI:
			case SortListType.SORTLIST_TOWER_OCCU_AXIULUO:
			case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_TOWER_OCCU_MANYOU:
			case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI:
			case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_TOWER_OCCU_MOFASHI:
			case SortListType.SORTLIST_TOWER_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_TOWER_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_TOWER_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_TOWER_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_TOWER_OCCU_SANDA:
			case SortListType.SORTLIST_TOWER_OCCU_JIEBA:
			case SortListType.SORTLIST_TOWER_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_TOWER_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_TOWER_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_TOWER_OCCU_QUMO:
			case SortListType.SORTLIST_TOWER_OCCU_SHENGQISHI:
				goto IL_3AE;
			case SortListType.SORTLIST_CHIJI_SCORE:
				return new ChijiScoreSortListEntry();
			case SortListType.SORTLIST_2V2_SCORE_WAR:
				return new ScoreWarSortListEntry();
			}
			return new LevelSortListEntry();
			IL_3AE:
			return new DeathTowerSortListEntry();
			IL_3B4:
			return new ItemSortListEntry();
		}

		// Token: 0x060055E1 RID: 21985 RVA: 0x0010762C File Offset: 0x00105A2C
		public static BaseSortList Decode(byte[] buffer, ref int pos, int length, bool isUpdate = false)
		{
			byte b = 0;
			BaseDLL.decode_int8(buffer, ref pos, ref b);
			if (0 > b || 252 < b)
			{
				return null;
			}
			BaseSortList baseSortList = new BaseSortList();
			baseSortList.type = (SortListType)b;
			BaseDLL.decode_uint16(buffer, ref pos, ref baseSortList.start);
			BaseDLL.decode_uint16(buffer, ref pos, ref baseSortList.totalNum);
			BaseDLL.decode_uint16(buffer, ref pos, ref baseSortList.num);
			for (int i = 0; i < (int)baseSortList.num; i++)
			{
				BaseSortListEntry entry = SortListDecoder.GetEntry(baseSortList.type);
				if (entry == null)
				{
					return null;
				}
				entry.Decode(buffer, ref pos);
				baseSortList.entries.Add(entry);
			}
			baseSortList.selfEntry = SortListDecoder.GetEntry(baseSortList.type);
			baseSortList.selfEntry.Decode(buffer, ref pos);
			return baseSortList;
		}
	}
}
