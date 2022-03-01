using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F71 RID: 3953
	internal class ConsumeFactory
	{
		// Token: 0x060098F6 RID: 39158 RVA: 0x001D6478 File Offset: 0x001D4878
		public static ICommonConsume CreateByItemID(int a_nItemID, ClientFrameBinder comFrameBinder)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(a_nItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			ItemTable.eSubType subType = tableItem.SubType;
			switch (subType)
			{
			case ItemTable.eSubType.GOLD:
				return new GoldConsume(comFrameBinder);
			case ItemTable.eSubType.POINT:
				return new PointConsume(comFrameBinder);
			case ItemTable.eSubType.EXP:
				return new ExpConsume(comFrameBinder);
			default:
				switch (subType)
				{
				case ItemTable.eSubType.ST_BLESS_CRYSTAL_VALUE:
					return new BlessCrystalConsume(comFrameBinder);
				case ItemTable.eSubType.ST_INHERIT_BLESS_VALUE:
					return new PassBlessConsume(comFrameBinder);
				default:
					if (subType == ItemTable.eSubType.GoldJarPoint)
					{
						return new GoldJarScoreConsume(comFrameBinder);
					}
					if (subType == ItemTable.eSubType.MagicJarPoint)
					{
						return new MagicJarScoreConsume(comFrameBinder);
					}
					switch (subType)
					{
					case ItemTable.eSubType.ST_FANTASY_COIN:
						return new FantasyTripConsume(comFrameBinder);
					default:
						if (subType == ItemTable.eSubType.ST_HIRE_COIN)
						{
							return new WarriorRecruitConsume(comFrameBinder);
						}
						if (subType != ItemTable.eSubType.ST_CREDIT_POINT)
						{
							return new ItemConsume(a_nItemID, comFrameBinder);
						}
						return new CreditTicketConsume(comFrameBinder);
					case ItemTable.eSubType.ST_SECRET_SELL_COIN:
						return new AnniversaryPointConsume(comFrameBinder);
					}
					break;
				case ItemTable.eSubType.ST_GOLD_REWARD_VALUE:
					return new BountyConsume(comFrameBinder);
				}
				break;
			case ItemTable.eSubType.WARRIOR_SOUL:
				return new WarriorsoulConsume(comFrameBinder);
			case ItemTable.eSubType.DUEL_COIN:
				return new DuelcoinConsume(comFrameBinder);
			case ItemTable.eSubType.ResurrectionCcurrency:
				return new ResurrectionCcurrencyComsume(comFrameBinder);
			case ItemTable.eSubType.BindGOLD:
				return new BindGoldConsume(comFrameBinder);
			case ItemTable.eSubType.BindPOINT:
				return new BindPointConsume(comFrameBinder);
			case ItemTable.eSubType.GuildContri:
				return new GuildContributionConsume(comFrameBinder);
			}
		}

		// Token: 0x060098F7 RID: 39159 RVA: 0x001D65D4 File Offset: 0x001D49D4
		public static ICommonConsume CreateByCountType(ComCommonConsume.eCountType type, object arg = null, ClientFrameBinder comFrameBinder = null)
		{
			switch (type)
			{
			case ComCommonConsume.eCountType.Fatigue:
				return new FatigueConsume(comFrameBinder);
			case ComCommonConsume.eCountType.MouCount:
				return new BaseActivityConsume((int)arg, comFrameBinder);
			case ComCommonConsume.eCountType.NorthCount:
				return new BaseActivityConsume((int)arg, comFrameBinder);
			case ComCommonConsume.eCountType.HellTiketCount:
				return new HellTiketConsume(comFrameBinder);
			case ComCommonConsume.eCountType.DeadTower:
				return new DeadTowerCountConsume((int)arg);
			case ComCommonConsume.eCountType.Final_Test:
				return new FinalTestCountConsume((int)arg);
			default:
				return null;
			}
		}
	}
}
