using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using Protocol;
using ProtoTable;

// Token: 0x02004550 RID: 17744
public class BattleFactory
{
	// Token: 0x06018B3D RID: 101181 RVA: 0x007B810C File Offset: 0x007B650C
	private static void _prepareTrainigData()
	{
		RacePlayerInfo racePlayerInfo = new RacePlayerInfo
		{
			accid = ClientApplication.playerinfo.accid,
			roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
			level = DataManager<PlayerBaseData>.GetInstance().Level,
			name = DataManager<PlayerBaseData>.GetInstance().Name,
			seat = 0,
			occupation = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
		};
		List<RaceSkillInfo> list = new List<RaceSkillInfo>();
		Dictionary<int, int> skillInfoByPid = Singleton<TableManager>.instance.GetSkillInfoByPid(DataManager<PlayerBaseData>.GetInstance().JobTableID);
		Dictionary<int, int>.Enumerator enumerator = skillInfoByPid.GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<RaceSkillInfo> list2 = list;
			RaceSkillInfo raceSkillInfo = new RaceSkillInfo();
			RaceSkillInfo raceSkillInfo2 = raceSkillInfo;
			KeyValuePair<int, int> keyValuePair = enumerator.Current;
			raceSkillInfo2.id = (ushort)keyValuePair.Key;
			RaceSkillInfo raceSkillInfo3 = raceSkillInfo;
			KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
			raceSkillInfo3.level = (byte)keyValuePair2.Value;
			raceSkillInfo.slot = 0;
			list2.Add(raceSkillInfo);
		}
		racePlayerInfo.skills = list.ToArray();
		DataManager<BattleDataManager>.GetInstance().PlayerInfo = new RacePlayerInfo[]
		{
			racePlayerInfo
		};
		BattleFactory._prepareSingleArea();
	}

	// Token: 0x06018B3E RID: 101182 RVA: 0x007B821C File Offset: 0x007B661C
	private static void PrepareTrainingData2()
	{
		RacePlayerInfo racePlayerInfo = new RacePlayerInfo
		{
			accid = ClientApplication.playerinfo.accid,
			roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
			level = DataManager<PlayerBaseData>.GetInstance().Level,
			name = DataManager<PlayerBaseData>.GetInstance().Name,
			seat = 0,
			occupation = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
		};
		List<RaceSkillInfo> list = new List<RaceSkillInfo>();
		List<SkillBarGrid> pvpSkillBar = DataManager<SkillDataManager>.GetInstance().GetPvpSkillBar();
		for (int i = 0; i < pvpSkillBar.Count; i++)
		{
			SkillBarGrid skillBarGrid = pvpSkillBar[i];
			Skill skillByID = DataManager<SkillDataManager>.GetInstance().GetSkillByID((int)skillBarGrid.id, true, SkillSystemSourceType.None);
			list.Add(new RaceSkillInfo
			{
				id = skillBarGrid.id,
				level = skillByID.level,
				slot = skillBarGrid.slot
			});
		}
		racePlayerInfo.skills = list.ToArray();
		RacePlayerInfo racePlayerInfo2 = new RacePlayerInfo();
		AIConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<AIConfigTable>(Global.Settings.trainingAIConfigId, string.Empty, string.Empty);
		if (Global.Settings.isTrainingAIOpen && tableItem != null)
		{
			racePlayerInfo2.occupation = (byte)tableItem.JobID;
			racePlayerInfo2.robotAIType = (byte)tableItem.AIType;
			racePlayerInfo2.name = "决斗场机器人";
			RobotConfigTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<RobotConfigTable>(Global.Settings.trainingRobotId, string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.Skills != null)
			{
				list.Clear();
				for (int j = 0; j < tableItem2.SkillsLength; j++)
				{
					list.Add(new RaceSkillInfo
					{
						id = (ushort)tableItem2.Skills[j],
						level = 1,
						slot = (byte)(j + 3)
					});
				}
				racePlayerInfo2.skills = list.ToArray();
				if (tableItem != null)
				{
					List<RaceEquip> list2 = new List<RaceEquip>();
					for (int k = 0; k < tableItem.EquipsLength; k++)
					{
						list2.Add(new RaceEquip
						{
							id = (uint)tableItem.Equips[k]
						});
					}
					racePlayerInfo2.equips = list2.ToArray();
				}
			}
		}
		else
		{
			racePlayerInfo2.occupation = 10;
			racePlayerInfo2.robotAIType = 0;
			racePlayerInfo2.name = "陪练魂剑士";
			int[] equipsData = new int[]
			{
				146970001,
				146971001,
				146972001,
				146973001,
				146974001,
				167290001,
				167291001,
				167292001,
				167210003
			};
			List<RaceEquip> equips = BeUtility.GetEquips(equipsData);
			racePlayerInfo2.equips = equips.ToArray();
		}
		racePlayerInfo2.level = 65;
		racePlayerInfo2.seat = 1;
		DataManager<BattleDataManager>.GetInstance().PlayerInfo = new RacePlayerInfo[]
		{
			racePlayerInfo,
			racePlayerInfo2
		};
	}

	// Token: 0x06018B3F RID: 101183 RVA: 0x007B84F0 File Offset: 0x007B68F0
	private static void _prepareSingleArea()
	{
		DataManager<BattleDataManager>.GetInstance().BattleInfo.startAreaId = 1;
		DungeonArea item = new DungeonArea
		{
			id = 1
		};
		DataManager<BattleDataManager>.GetInstance().BattleInfo.areas = new List<DungeonArea>
		{
			item
		};
	}

	// Token: 0x06018B40 RID: 101184 RVA: 0x007B853C File Offset: 0x007B693C
	private static void PrepareTrainingPVE()
	{
		RacePlayerInfo racePlayerInfo = BattleFactory.PrepareMainPlayerData(false);
		DataManager<BattleDataManager>.GetInstance().PlayerInfo = new RacePlayerInfo[]
		{
			racePlayerInfo
		};
	}

	// Token: 0x06018B41 RID: 101185 RVA: 0x007B8564 File Offset: 0x007B6964
	private static RacePlayerInfo PrepareMainPlayerData(bool isPvp = true)
	{
		RacePlayerInfo racePlayerInfo = new RacePlayerInfo
		{
			accid = ClientApplication.playerinfo.accid,
			roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
			level = DataManager<PlayerBaseData>.GetInstance().Level,
			name = DataManager<PlayerBaseData>.GetInstance().Name,
			seat = 0,
			occupation = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
		};
		List<RaceSkillInfo> list = new List<RaceSkillInfo>();
		List<SkillBarGrid> list2 = new List<SkillBarGrid>();
		if (isPvp)
		{
			list2 = DataManager<SkillDataManager>.GetInstance().GetPvpSkillBar();
		}
		else
		{
			list2 = DataManager<SkillDataManager>.GetInstance().GetPveSkillBar();
		}
		for (int i = 0; i < list2.Count; i++)
		{
			SkillBarGrid skillBarGrid = list2[i];
			Skill skillByID = DataManager<SkillDataManager>.GetInstance().GetSkillByID((int)skillBarGrid.id, isPvp, SkillSystemSourceType.None);
			list.Add(new RaceSkillInfo
			{
				id = skillBarGrid.id,
				level = skillByID.level,
				slot = skillBarGrid.slot
			});
		}
		racePlayerInfo.skills = list.ToArray();
		return racePlayerInfo;
	}

	// Token: 0x06018B42 RID: 101186 RVA: 0x007B8680 File Offset: 0x007B6A80
	public static BaseBattle CreateBattle(BattleType type, eDungeonMode mode = eDungeonMode.LocalFrame, int id = 0)
	{
		switch (type)
		{
		case BattleType.Single:
			BattleFactory._prepareTrainigData();
			return new TrainingBatte(type, mode, 0);
		case BattleType.MutiPlayer:
			BattleFactory._prepareSingleArea();
			return new PVPBattle(type, eDungeonMode.SyncFrame, id);
		case BattleType.Dungeon:
		case BattleType.Hell:
		case BattleType.YuanGu:
			return new PVEBattle(type, mode, id);
		case BattleType.DeadTown:
			return new DeadTowerBattle(type, mode, id);
		case BattleType.Mou:
		case BattleType.GoldRush:
			return new MouBattle(type, mode, id);
		case BattleType.North:
			return new NorthBattle(type, mode, id);
		case BattleType.NewbieGuide:
			return new NewbieGuideBattle(type, eDungeonMode.Test, 1);
		case BattleType.Training:
			BattleFactory._prepareSingleArea();
			BattleFactory.PrepareTrainingData2();
			return new TrainingBatte2(type, eDungeonMode.LocalFrame, 10);
		case BattleType.TrainingSkillCombo:
			return new TrainingSkillComboBattle(type, mode, id);
		case BattleType.GuildPVP:
			BattleFactory._prepareSingleArea();
			return new GuildPVPBattle(type, eDungeonMode.SyncFrame, id);
		case BattleType.MoneyRewardsPVP:
			BattleFactory._prepareSingleArea();
			return new MoneyRewardsPVPBattle(type, eDungeonMode.SyncFrame, id);
		case BattleType.PVP3V3Battle:
			BattleFactory._prepareSingleArea();
			return new PVP3V3Battle(type, eDungeonMode.SyncFrame, id);
		case BattleType.ChampionMatch:
			return new ChampionMatchBattle(type, mode, id);
		case BattleType.ScufflePVP:
			BattleFactory._prepareSingleArea();
			return new PVPScuffleBattle(type, eDungeonMode.SyncFrame, id);
		case BattleType.GuildPVE:
			return new GuildPVEBattle(type, mode, id);
		case BattleType.TrainingPVE:
			BattleFactory._prepareSingleArea();
			BattleFactory.PrepareTrainingPVE();
			return new TrainingPVEBattle(type, mode, 60);
		case BattleType.ChijiPVP:
			BattleFactory._prepareSingleArea();
			return new ChiJiPVPBattle(type, eDungeonMode.SyncFrame, id);
		case BattleType.FinalTestBattle:
			return new FinalTestBattle(type, mode, id);
		case BattleType.RaidPVE:
			return new RaidBattle(type, mode, id);
		case BattleType.TreasureMap:
			return new TreasureMapBattle(type, mode, id);
		case BattleType.AnniversaryPVE_III:
			return new TimeLimiteBattle(type, mode, id);
		default:
			Logger.LogErrorFormat("没有处理 eDungeonMode {0} 的战斗", new object[]
			{
				type
			});
			return null;
		}
	}
}
