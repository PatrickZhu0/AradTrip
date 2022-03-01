using System;
using System.Collections.Generic;
using System.Text;
using Battle;
using GameClient;
using Protocol;
using ProtoTable;

// Token: 0x02004106 RID: 16646
public class BattlePlayer
{
	// Token: 0x17001F04 RID: 7940
	// (get) Token: 0x06016A7C RID: 92796 RVA: 0x006DDF5D File Offset: 0x006DC35D
	// (set) Token: 0x06016A7D RID: 92797 RVA: 0x006DDF65 File Offset: 0x006DC365
	public BattlePlayer.eNetQuality netQuality
	{
		get
		{
			return this.mNetQuality;
		}
		set
		{
			this.mNetQuality = value;
		}
	}

	// Token: 0x17001F05 RID: 7941
	// (get) Token: 0x06016A7E RID: 92798 RVA: 0x006DDF6E File Offset: 0x006DC36E
	// (set) Token: 0x06016A7F RID: 92799 RVA: 0x006DDF76 File Offset: 0x006DC376
	public BattlePlayer.eNetState netState
	{
		get
		{
			return this.mNetState;
		}
		set
		{
			this.mNetState = value;
		}
	}

	// Token: 0x17001F06 RID: 7942
	// (get) Token: 0x06016A80 RID: 92800 RVA: 0x006DDF7F File Offset: 0x006DC37F
	public BattlePlayer.EState lastState
	{
		get
		{
			return this.mLastState;
		}
	}

	// Token: 0x17001F07 RID: 7943
	// (get) Token: 0x06016A81 RID: 92801 RVA: 0x006DDF87 File Offset: 0x006DC387
	// (set) Token: 0x06016A82 RID: 92802 RVA: 0x006DDF8F File Offset: 0x006DC38F
	public BattlePlayer.EState state
	{
		get
		{
			return this.mState;
		}
		set
		{
			this.mLastState = this.mState;
			this.mState = value;
		}
	}

	// Token: 0x06016A83 RID: 92803 RVA: 0x006DDFA4 File Offset: 0x006DC3A4
	public void onPlayerLeave()
	{
		this.netState = BattlePlayer.eNetState.Offline;
	}

	// Token: 0x06016A84 RID: 92804 RVA: 0x006DDFAD File Offset: 0x006DC3AD
	public void onPlayerBack()
	{
		this.netState = BattlePlayer.eNetState.Online;
	}

	// Token: 0x06016A85 RID: 92805 RVA: 0x006DDFB6 File Offset: 0x006DC3B6
	public void onPlayerQuit()
	{
	}

	// Token: 0x06016A86 RID: 92806 RVA: 0x006DDFB8 File Offset: 0x006DC3B8
	public bool IsPlayerMonthCard()
	{
		return this.playerInfo != null && 0 != this.playerInfo.monthcard;
	}

	// Token: 0x06016A87 RID: 92807 RVA: 0x006DDFD8 File Offset: 0x006DC3D8
	public bool IsPlayerLoadFinish()
	{
		return this.loadRate >= 100;
	}

	// Token: 0x17001F08 RID: 7944
	// (get) Token: 0x06016A88 RID: 92808 RVA: 0x006DDFE7 File Offset: 0x006DC3E7
	// (set) Token: 0x06016A89 RID: 92809 RVA: 0x006DDFEF File Offset: 0x006DC3EF
	public byte loadRate
	{
		get
		{
			return this.mLoadRate;
		}
		set
		{
			if (this.mLoadRate < value)
			{
				this.mLoadRate = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonPlayerLoadProgressChanged, null, null, null, null);
			}
		}
	}

	// Token: 0x17001F09 RID: 7945
	// (get) Token: 0x06016A8A RID: 92810 RVA: 0x006DE017 File Offset: 0x006DC417
	// (set) Token: 0x06016A8B RID: 92811 RVA: 0x006DE01F File Offset: 0x006DC41F
	public bool isAutoFight
	{
		get
		{
			return this.mIsAutoFight;
		}
		set
		{
			this.mIsAutoFight = value;
		}
	}

	// Token: 0x17001F0A RID: 7946
	// (get) Token: 0x06016A8C RID: 92812 RVA: 0x006DE028 File Offset: 0x006DC428
	// (set) Token: 0x06016A8D RID: 92813 RVA: 0x006DE030 File Offset: 0x006DC430
	public BattlePlayer.eDungeonPlayerTeamType teamType
	{
		get
		{
			return this.mTeamType;
		}
		set
		{
			this.mTeamType = value;
		}
	}

	// Token: 0x17001F0B RID: 7947
	// (get) Token: 0x06016A8F RID: 92815 RVA: 0x006DE042 File Offset: 0x006DC442
	// (set) Token: 0x06016A8E RID: 92814 RVA: 0x006DE039 File Offset: 0x006DC439
	public BattlePlayer.eFightingStatus fightingStatus
	{
		get
		{
			return this.mFightingStatus;
		}
		set
		{
			this.mFightingStatus = value;
		}
	}

	// Token: 0x17001F0C RID: 7948
	// (get) Token: 0x06016A90 RID: 92816 RVA: 0x006DE04A File Offset: 0x006DC44A
	// (set) Token: 0x06016A91 RID: 92817 RVA: 0x006DE052 File Offset: 0x006DC452
	public bool isFighting
	{
		get
		{
			return this.mIsFighting;
		}
		set
		{
			this.mIsFighting = value;
		}
	}

	// Token: 0x17001F0D RID: 7949
	// (get) Token: 0x06016A92 RID: 92818 RVA: 0x006DE05B File Offset: 0x006DC45B
	public bool hasFighted
	{
		get
		{
			return this.GetLastPKResult() != PKResult.INVALID;
		}
	}

	// Token: 0x17001F0E RID: 7950
	// (get) Token: 0x06016A93 RID: 92819 RVA: 0x006DE06C File Offset: 0x006DC46C
	public bool isPassedInRound
	{
		get
		{
			PKResult lastPKResult = this.GetLastPKResult();
			return lastPKResult == PKResult.DRAW || PKResult.LOSE == lastPKResult;
		}
	}

	// Token: 0x06016A94 RID: 92820 RVA: 0x006DE08E File Offset: 0x006DC48E
	public PKResult GetLastPKResult()
	{
		if (this.statistics == null)
		{
			return PKResult.INVALID;
		}
		return this.statistics.GetLastPKResult();
	}

	// Token: 0x06016A95 RID: 92821 RVA: 0x006DE0A8 File Offset: 0x006DC4A8
	public int GetPKResultRank()
	{
		if (this.statistics == null)
		{
			return 1;
		}
		return this.statistics.raceResultRank;
	}

	// Token: 0x06016A96 RID: 92822 RVA: 0x006DE0C2 File Offset: 0x006DC4C2
	public void SetPKResultRank(int rank)
	{
		if (this.statistics == null)
		{
			Logger.LogErrorFormat("[战斗玩家] 设置排名失败 {0}", new object[]
			{
				rank
			});
			return;
		}
		this.statistics.raceResultRank = rank;
	}

	// Token: 0x06016A97 RID: 92823 RVA: 0x006DE0F8 File Offset: 0x006DC4F8
	public int GetKillMatchPlayerCount()
	{
		if (this.statistics == null)
		{
			return 0;
		}
		if (DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_3V3_Melee || DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_2V2_Melee)
		{
			return this.statistics.killPlayers;
		}
		return this.statistics.GetKillMatchPlayerCount();
	}

	// Token: 0x06016A98 RID: 92824 RVA: 0x006DE14A File Offset: 0x006DC54A
	public int GetLastPKRoundIndex()
	{
		if (this.statistics == null)
		{
			return -1;
		}
		return this.statistics.GetLastPKRoundIndex();
	}

	// Token: 0x06016A99 RID: 92825 RVA: 0x006DE164 File Offset: 0x006DC564
	public uint GetRaceEndResultSeasonLevel()
	{
		if (this.statistics == null)
		{
			return 0U;
		}
		if (this.statistics.raceResult == null)
		{
			return 0U;
		}
		if (this.statistics.raceResult.beforeRaceResult == null)
		{
			return 0U;
		}
		return this.statistics.raceResult.beforeRaceResult.seasonLevel;
	}

	// Token: 0x06016A9A RID: 92826 RVA: 0x006DE1BC File Offset: 0x006DC5BC
	public uint GetRaceEndResultScoreWarContriScore()
	{
		if (this.statistics == null)
		{
			return uint.MaxValue;
		}
		if (this.statistics.raceResult == null)
		{
			return uint.MaxValue;
		}
		if (this.statistics.raceResult.beforeRaceResult == null)
		{
			return uint.MaxValue;
		}
		return this.statistics.raceResult.beforeRaceResult.scoreWarContriScore;
	}

	// Token: 0x06016A9B RID: 92827 RVA: 0x006DE214 File Offset: 0x006DC614
	public uint GetRaceEndResultScoreWarBaseScore()
	{
		if (this.statistics == null)
		{
			return uint.MaxValue;
		}
		if (this.statistics.raceResult == null)
		{
			return uint.MaxValue;
		}
		if (this.statistics.raceResult.beforeRaceResult == null)
		{
			return uint.MaxValue;
		}
		return this.statistics.raceResult.beforeRaceResult.scoreWarBaseScore;
	}

	// Token: 0x06016A9C RID: 92828 RVA: 0x006DE26C File Offset: 0x006DC66C
	public uint GetRaceEndResultAddGlory()
	{
		if (this.statistics == null)
		{
			return 0U;
		}
		if (this.statistics.raceResult == null)
		{
			return 0U;
		}
		if (this.statistics.raceResult.beforeRaceResult == null)
		{
			return 0U;
		}
		return this.statistics.raceResult.beforeRaceResult.changeGlory;
	}

	// Token: 0x06016A9D RID: 92829 RVA: 0x006DE2C4 File Offset: 0x006DC6C4
	public void AddPKResult(int roundIndex, byte seat, PKResult result, ePVPBattleEndType endType, uint selfHpRate)
	{
		this.statistics.AddPKResult(roundIndex, seat, result, endType, selfHpRate);
	}

	// Token: 0x06016A9E RID: 92830 RVA: 0x006DE2D8 File Offset: 0x006DC6D8
	public uint GetLastHurtedRate()
	{
		return this.statistics.GetLastHurtedRate();
	}

	// Token: 0x06016A9F RID: 92831 RVA: 0x006DE2E5 File Offset: 0x006DC6E5
	public void AddDamageData(byte targetSeat, uint rate)
	{
		if (this.mLastRound >= this.statistics.GetLastPKRoundIndex())
		{
			return;
		}
		this.mLastRound = this.statistics.GetLastPKRoundIndex();
		this.mPKAllDamageRate += rate;
	}

	// Token: 0x06016AA0 RID: 92832 RVA: 0x006DE31D File Offset: 0x006DC71D
	public uint GetPKAllDamageRate()
	{
		return this.mPKAllDamageRate;
	}

	// Token: 0x06016AA1 RID: 92833 RVA: 0x006DE328 File Offset: 0x006DC728
	public bool ConvertSceneRoomMatchPkRaceEnd2LocalBattlePlayer(SceneRoomMatchPkRaceEnd endInfo)
	{
		if (endInfo == null)
		{
			Logger.LogErrorFormat("[战斗玩家] 比赛结果为空", new object[0]);
			return false;
		}
		if (this.statistics == null)
		{
			Logger.LogErrorFormat("[战斗玩家] 统计数据为空", new object[0]);
			return false;
		}
		if (!this.IsLocalPlayer())
		{
			Logger.LogErrorFormat("[战斗玩家] 不为本地玩家", new object[0]);
			return false;
		}
		PlayerStatistics.MatchRacePKResult raceResult = this.statistics.raceResult;
		raceResult.addPkCoinFromRace = endInfo.addPkCoinFromRace;
		raceResult.addPkCoinFromActivity = endInfo.addPkCoinFromActivity;
		raceResult.totalPkCoinFromRace = endInfo.totalPkCoinFromRace;
		raceResult.totalPkCoinFromActivity = endInfo.totalPkCoinFromActivity;
		raceResult.changeSeasonExp = endInfo.changeSeasonExp;
		raceResult.isInPvPActivity = endInfo.isInPvPActivity;
		raceResult.raceResult = (PKResult)endInfo.result;
		if (raceResult.beforeRaceResult == null)
		{
			raceResult.beforeRaceResult = new PlayerStatistics.MatchRacePlayerResult();
		}
		raceResult.beforeRaceResult.matchScore = endInfo.oldMatchScore;
		raceResult.beforeRaceResult.pkCoin = endInfo.oldPkCoin;
		raceResult.beforeRaceResult.pkValue = endInfo.oldPkValue;
		raceResult.beforeRaceResult.seasonExp = endInfo.oldSeasonExp;
		raceResult.beforeRaceResult.seasonLevel = endInfo.oldSeasonLevel;
		raceResult.beforeRaceResult.seasonStar = endInfo.oldSeasonStar;
		raceResult.beforeRaceResult.changeGlory = endInfo.getHonor;
		if (raceResult.afterRaceResult == null)
		{
			raceResult.afterRaceResult = new PlayerStatistics.MatchRacePlayerResult();
		}
		raceResult.afterRaceResult.matchScore = endInfo.newMatchScore;
		raceResult.afterRaceResult.pkValue = endInfo.newPkValue;
		raceResult.afterRaceResult.seasonExp = endInfo.newSeasonExp;
		raceResult.afterRaceResult.seasonLevel = endInfo.newSeasonLevel;
		raceResult.afterRaceResult.seasonStar = endInfo.newSeasonStar;
		return true;
	}

	// Token: 0x06016AA2 RID: 92834 RVA: 0x006DE4E0 File Offset: 0x006DC8E0
	public bool ConvertRoomSlotBattleEndInfo2BattlePlayer(RoomSlotBattleEndInfo slotInfo)
	{
		if (slotInfo == null)
		{
			Logger.LogErrorFormat("[战斗玩家] 玩家座位结果为空", new object[0]);
			return false;
		}
		if (this.statistics == null)
		{
			Logger.LogErrorFormat("[战斗玩家] 数据为空", new object[0]);
			return false;
		}
		if (slotInfo.seat != this.GetPlayerSeat())
		{
			Logger.LogErrorFormat("[战斗玩家] 玩家座位号错误", new object[0]);
			return false;
		}
		PlayerStatistics.MatchRacePKResult raceResult = this.statistics.raceResult;
		raceResult.raceResult = (PKResult)slotInfo.resultFlag;
		raceResult.roomId = slotInfo.roomId;
		raceResult.roomType = (RoomType)slotInfo.roomType;
		if (raceResult.beforeRaceResult == null)
		{
			raceResult.beforeRaceResult = new PlayerStatistics.MatchRacePlayerResult();
		}
		raceResult.beforeRaceResult.seasonLevel = slotInfo.seasonLevel;
		raceResult.beforeRaceResult.seasonExp = slotInfo.seasonExp;
		raceResult.beforeRaceResult.seasonStar = slotInfo.seasonStar;
		raceResult.beforeRaceResult.scoreWarContriScore = slotInfo.scoreWarContriScore;
		raceResult.beforeRaceResult.scoreWarBaseScore = slotInfo.scoreWarBaseScore;
		raceResult.beforeRaceResult.changeGlory = slotInfo.getHonor;
		return true;
	}

	// Token: 0x17001F0F RID: 7951
	// (get) Token: 0x06016AA3 RID: 92835 RVA: 0x006DE5F2 File Offset: 0x006DC9F2
	// (set) Token: 0x06016AA4 RID: 92836 RVA: 0x006DE5FA File Offset: 0x006DC9FA
	public bool isVote
	{
		get
		{
			return this.mIsVote;
		}
		set
		{
			this.mIsVote = value;
		}
	}

	// Token: 0x06016AA5 RID: 92837 RVA: 0x006DE603 File Offset: 0x006DCA03
	public RoomType GetMatchRoomType()
	{
		if (this.statistics == null)
		{
			return RoomType.ROOM_TYPE_INVALID;
		}
		if (this.statistics.raceResult == null)
		{
			return RoomType.ROOM_TYPE_INVALID;
		}
		return this.statistics.raceResult.roomType;
	}

	// Token: 0x06016AA6 RID: 92838 RVA: 0x006DE634 File Offset: 0x006DCA34
	public byte GetPlayerSeat()
	{
		if (!BattlePlayer.IsDataValidBattlePlayer(this))
		{
			return byte.MaxValue;
		}
		return this.playerInfo.seat;
	}

	// Token: 0x06016AA7 RID: 92839 RVA: 0x006DE652 File Offset: 0x006DCA52
	public string GetPlayerName()
	{
		if (!BattlePlayer.IsDataValidBattlePlayer(this))
		{
			return string.Empty;
		}
		return this.playerInfo.name;
	}

	// Token: 0x06016AA8 RID: 92840 RVA: 0x006DE670 File Offset: 0x006DCA70
	public string GetPlayerServerName()
	{
		if (!BattlePlayer.IsDataValidBattlePlayer(this))
		{
			return string.Empty;
		}
		return this.playerInfo.serverName;
	}

	// Token: 0x06016AA9 RID: 92841 RVA: 0x006DE68E File Offset: 0x006DCA8E
	public bool IsTeamBlue()
	{
		return !this.IsTeamRed();
	}

	// Token: 0x06016AAA RID: 92842 RVA: 0x006DE699 File Offset: 0x006DCA99
	public bool IsTeamRed()
	{
		return BattlePlayer.eDungeonPlayerTeamType.eTeamRed == this.teamType;
	}

	// Token: 0x06016AAB RID: 92843 RVA: 0x006DE6A4 File Offset: 0x006DCAA4
	public bool IsLocalPlayer()
	{
		return BattlePlayer.IsDataValidBattlePlayer(this) && this.playerInfo.accid == ClientApplication.playerinfo.accid;
	}

	// Token: 0x06016AAC RID: 92844 RVA: 0x006DE6CB File Offset: 0x006DCACB
	public int GetPlayerCamp()
	{
		return (!this.IsTeamRed()) ? 1 : 0;
	}

	// Token: 0x06016AAD RID: 92845 RVA: 0x006DE6E0 File Offset: 0x006DCAE0
	public string GetBattlePlayerInfo()
	{
		if (!BattlePlayer.IsDataValidBattlePlayer(this))
		{
			return "[玩家] ****无效对象***";
		}
		return string.Format("\n[玩家基本信息] {0} 座位号:{1} 账号ID:{2} 角色ID:{3}\n等级:{4} 职业:{5} HP:{6}，MP:{7}\n工会名字:{8}\n匹配积分:{9}, pk积分:{10}\n赛季属性:{11}, 赛季星级:{12}, 赛季等级:{13}\n月卡:{14}\n队伍类型:{15}, 战斗状态:{16}，是否在战斗：{17}, 是否已经战斗过:{18}, 最近一场战斗结果:{19}, 最近一场战斗场次:{20}\n", new object[]
		{
			this.playerInfo.name,
			this.playerInfo.seat,
			this.playerInfo.accid,
			this.playerInfo.roleId,
			this.playerInfo.level,
			this.playerInfo.occupation,
			this.playerInfo.remainHp,
			this.playerInfo.remainMp,
			this.playerInfo.guildName,
			this.playerInfo.matchScore,
			this.playerInfo.pkValue,
			this.playerInfo.seasonAttr,
			this.playerInfo.seasonStar,
			this.playerInfo.seasonLevel,
			this.playerInfo.monthcard,
			this.teamType,
			this.fightingStatus,
			this.isFighting,
			this.hasFighted,
			this.GetLastPKResult(),
			this.GetLastPKRoundIndex()
		});
	}

	// Token: 0x06016AAE RID: 92846 RVA: 0x006DE882 File Offset: 0x006DCC82
	public static BattlePlayer.eDungeonPlayerTeamType GetTargetTeamType(BattlePlayer.eDungeonPlayerTeamType type)
	{
		if (type == BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
		{
			return BattlePlayer.eDungeonPlayerTeamType.eTeamRed;
		}
		if (type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
		{
			Logger.LogErrorFormat("[战斗] 错误类型 {0}", new object[]
			{
				type
			});
			return BattlePlayer.eDungeonPlayerTeamType.eTeamRed;
		}
		return BattlePlayer.eDungeonPlayerTeamType.eTeamBlue;
	}

	// Token: 0x06016AAF RID: 92847 RVA: 0x006DE8B4 File Offset: 0x006DCCB4
	public static bool IsDataValidBattlePlayer(BattlePlayer player)
	{
		return player != null && player.playerInfo != null;
	}

	// Token: 0x06016AB0 RID: 92848 RVA: 0x006DE8CC File Offset: 0x006DCCCC
	public static Dictionary<int, int> GetSkillInfo(RacePlayerInfo info)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < info.skills.Length; i++)
		{
			RaceSkillInfo raceSkillInfo = info.skills[i];
			if (!dictionary.ContainsKey((int)raceSkillInfo.id))
			{
				dictionary.Add((int)raceSkillInfo.id, (int)raceSkillInfo.level);
			}
			else
			{
				Logger.LogErrorFormat("alreay has skill:{0} level:{1} this level:{2}", new object[]
				{
					raceSkillInfo.id,
					dictionary[(int)raceSkillInfo.id],
					raceSkillInfo.level
				});
			}
		}
		return dictionary;
	}

	// Token: 0x06016AB1 RID: 92849 RVA: 0x006DE96C File Offset: 0x006DCD6C
	public static Dictionary<int, int> GetSkillSlotMap(RacePlayerInfo info)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < info.skills.Length; i++)
		{
			RaceSkillInfo raceSkillInfo = info.skills[i];
			int key = (int)(raceSkillInfo.slot + 3);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add((int)(raceSkillInfo.slot + 3), (int)raceSkillInfo.id);
			}
		}
		return dictionary;
	}

	// Token: 0x06016AB2 RID: 92850 RVA: 0x006DE9CC File Offset: 0x006DCDCC
	public static List<int> GetSkillList(RacePlayerInfo info)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < info.skills.Length; i++)
		{
			list.Add((int)info.skills[i].id);
		}
		return list;
	}

	// Token: 0x06016AB3 RID: 92851 RVA: 0x006DEA0C File Offset: 0x006DCE0C
	public static int GetTitleID(RacePlayerInfo player)
	{
		int result = 0;
		for (int i = 0; i < player.equips.Length; i++)
		{
			RaceEquip raceEquip = player.equips[i];
			if (BattleMain.battleType == BattleType.NewbieGuide || BattleMain.battleType == BattleType.TrainingSkillCombo || BattleMain.battleType == BattleType.Training || Array.IndexOf<ulong>(player.wearingEqIds, raceEquip.uid) >= 0)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)raceEquip.id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SubType == ItemTable.eSubType.TITLE)
				{
					result = (int)raceEquip.id;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06016AB4 RID: 92852 RVA: 0x006DEAB8 File Offset: 0x006DCEB8
	public static List<ItemProperty> GetEquips(RacePlayerInfo player, bool isPVP)
	{
		List<ItemProperty> list = new List<ItemProperty>();
		for (int i = 0; i < player.equips.Length; i++)
		{
			RaceEquip raceEquip = player.equips[i];
			if (BattleMain.battleType == BattleType.NewbieGuide || BattleMain.battleType == BattleType.TrainingSkillCombo || BattleMain.battleType == BattleType.Training || Array.IndexOf<ulong>(player.wearingEqIds, raceEquip.uid) >= 0)
			{
				ItemProperty itemProperty = BattlePlayer.GetItemProperty(raceEquip, isPVP);
				if (itemProperty != null)
				{
					list.Add(itemProperty);
				}
				else
				{
					Logger.LogErrorFormat("带入的装备{0}无法找到", new object[]
					{
						raceEquip.id
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06016AB5 RID: 92853 RVA: 0x006DEB64 File Offset: 0x006DCF64
	public static ItemProperty GetEquip(RaceEquip equip, bool isPvp)
	{
		ItemProperty itemProperty = BattlePlayer.GetItemProperty(equip, isPvp);
		if (itemProperty == null)
		{
			Logger.LogErrorFormat("带入的装备{0}无法找到", new object[]
			{
				equip.id
			});
		}
		return itemProperty;
	}

	// Token: 0x06016AB6 RID: 92854 RVA: 0x006DEBA0 File Offset: 0x006DCFA0
	public static Dictionary<int, string> GetAvatar(PlayerAvatar avatar)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		uint[] array = BeUtility.CopyVector(avatar.equipItemIds);
		BeUtility.DealWithFashion(array);
		for (int i = 0; i < array.Length; i++)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)array[i], string.Empty, string.Empty);
			if (tableItem != null)
			{
				bool flag = false;
				if (tableItem.SubType >= ItemTable.eSubType.FASHION_HAIR && tableItem.SubType <= ItemTable.eSubType.FASHION_EPAULET)
				{
					flag = true;
				}
				else if (tableItem.SubType >= ItemTable.eSubType.HEAD && tableItem.SubType <= ItemTable.eSubType.BOOT && DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.ChiJi)
				{
					flag = true;
				}
				if (flag)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						dictionary.Add((int)tableItem.SubType, tableItem2.ModelPath);
					}
				}
			}
		}
		return dictionary;
	}

	// Token: 0x06016AB7 RID: 92855 RVA: 0x006DEC8F File Offset: 0x006DD08F
	public static Dictionary<int, string> GetAvatar(RacePlayerInfo player)
	{
		return BattlePlayer.GetAvatar(player.avatar);
	}

	// Token: 0x06016AB8 RID: 92856 RVA: 0x006DEC9C File Offset: 0x006DD09C
	public static List<ItemProperty> GetSideEquips(RacePlayerInfo player, bool isPVP)
	{
		List<ItemProperty> list = new List<ItemProperty>();
		for (int i = 0; i < player.secondWeapons.Length; i++)
		{
			RaceEquip raceEquip = player.secondWeapons[i];
			ItemProperty itemProperty = BattlePlayer.GetItemProperty(raceEquip, isPVP);
			if (itemProperty != null)
			{
				list.Add(itemProperty);
			}
			else
			{
				Logger.LogErrorFormat("带入的装备{0}无法找到", new object[]
				{
					raceEquip.id
				});
			}
		}
		return list;
	}

	// Token: 0x06016AB9 RID: 92857 RVA: 0x006DED0C File Offset: 0x006DD10C
	private static ItemProperty GetItemProperty(RaceEquip equip, bool isPVP)
	{
		ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)equip.id, 100, 0);
		if (itemData != null)
		{
			itemData.isPVP = isPVP;
			itemData.BaseProp.props[0] = (int)equip.phyAtk;
			itemData.BaseProp.props[1] = (int)equip.magAtk;
			itemData.BaseProp.props[2] = (int)equip.phydef;
			itemData.BaseProp.props[3] = (int)equip.magdef;
			itemData.BaseProp.props[4] = (int)equip.strenth;
			itemData.BaseProp.props[7] = (int)equip.stamina;
			itemData.BaseProp.props[5] = (int)equip.intellect;
			itemData.BaseProp.props[6] = (int)equip.spirit;
			itemData.BaseProp.props[40] = (int)equip.disMagAtk;
			itemData.BaseProp.props[39] = (int)equip.disphyAtk;
			itemData.BaseProp.props[60] = (int)equip.indpendAtkStreng;
			itemData.BaseProp.props[44] = (int)equip.dismagdef;
			itemData.BaseProp.props[43] = (int)equip.disphydef;
			itemData.BaseProp.props[41] = (int)equip.phyDefPercent;
			itemData.BaseProp.props[42] = (int)equip.magDefPercent;
			itemData.BaseProp.props[59] = (int)equip.independAtk;
			if (equip.equipType == 2)
			{
				if (equip.enhanceType == 1)
				{
					CrypticInt32[] props = itemData.BaseProp.props;
					int num = 4;
					props[num] += (int)(equip.enhanceNum * (uint)GlobalLogic.VALUE_1000);
				}
				else if (equip.enhanceType == 2)
				{
					CrypticInt32[] props2 = itemData.BaseProp.props;
					int num2 = 5;
					props2[num2] += (int)(equip.enhanceNum * (uint)GlobalLogic.VALUE_1000);
				}
				else if (equip.enhanceType == 3)
				{
					CrypticInt32[] props3 = itemData.BaseProp.props;
					int num3 = 7;
					props3[num3] += (int)(equip.enhanceNum * (uint)GlobalLogic.VALUE_1000);
				}
				else if (equip.enhanceType == 4)
				{
					CrypticInt32[] props4 = itemData.BaseProp.props;
					int num4 = 6;
					props4[num4] += (int)(equip.enhanceNum * (uint)GlobalLogic.VALUE_1000);
				}
			}
			if (equip.strPropEx.Length > 0)
			{
				for (int i = 1; i < itemData.BaseProp.magicElementsAttack.Length; i++)
				{
					itemData.BaseProp.magicElementsAttack[i] = equip.strPropEx[i - 1];
				}
			}
			if (equip.defPropEx.Length > 0)
			{
				for (int j = 1; j < itemData.BaseProp.magicElementsDefence.Length; j++)
				{
					itemData.BaseProp.magicElementsDefence[j] = equip.defPropEx[j - 1];
				}
			}
			itemData.BaseProp.props[19] = equip.abnormalResistsTotal;
			if (equip.abnormalResists.Length > 0)
			{
				for (int k = 0; k < 13; k++)
				{
					itemData.BaseProp.abnormalResists[k] = equip.abnormalResists[k];
				}
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(637, string.Empty, string.Empty);
			if (equip.fashionAttrId > 0U)
			{
				EquipProp equipProp = EquipProp.CreateFromTable((int)equip.fashionAttrId);
				if (isPVP && equipProp != null && tableItem != null)
				{
					int value = tableItem.Value;
					VFactor f = new VFactor((long)value, (long)GlobalLogic.VALUE_1000);
					equipProp.props[59] = equipProp.props[59] * f;
				}
				itemData.BaseProp = equipProp;
			}
			if (itemData.Type == ItemTable.eType.FASHION)
			{
				EquipProp equipProp2 = EquipProp.CreateFromTable(itemData.FashionBaseAttributeID);
				if (isPVP && equipProp2 != null && tableItem != null)
				{
					int value2 = tableItem.Value;
					VFactor f2 = new VFactor((long)value2, (long)GlobalLogic.VALUE_1000);
					equipProp2.props[59] = equipProp2.props[59] * f2;
				}
				if (equipProp2 != null)
				{
					if (itemData.BaseProp != null)
					{
						itemData.BaseProp += equipProp2;
					}
					else
					{
						itemData.BaseProp = equipProp2;
					}
				}
			}
			for (int l = 0; l < equip.properties.Length; l++)
			{
				RaceItemRandProperty raceItemRandProperty = equip.properties[l];
				EServerProp type = (EServerProp)raceItemRandProperty.type;
				MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(type);
				if (enumAttribute != null)
				{
					itemData.RandamProp.props[(int)enumAttribute.Prop] = (int)raceItemRandProperty.value;
				}
			}
			if (equip.magicCard > 0U && itemData.mPrecEnchantmentCard != null)
			{
				itemData.mPrecEnchantmentCard = new PrecEnchantmentCard
				{
					iEnchantmentCardID = (int)equip.magicCard,
					iEnchantmentCardLevel = (int)equip.magicCardLv
				};
			}
			if (equip.mountPrecBeads != null && equip.mountPrecBeads.Length > 0)
			{
				itemData.PrecBeadBattle = BeUtility.SwitchPrecBead(equip.mountPrecBeads);
			}
			if (!isPVP && equip.inscriptionIds != null && equip.inscriptionIds.Length > 0)
			{
				itemData.InscriptionHoles = BeUtility.SwitchInscriptHoleData(equip.inscriptionIds);
			}
			itemData.StrengthenLevel = (int)equip.strengthen;
			ItemProperty battleProperty = itemData.GetBattleProperty(0);
			battleProperty.itemID = (int)equip.id;
			battleProperty.guid = equip.uid;
			return battleProperty;
		}
		return null;
	}

	// Token: 0x06016ABA RID: 92858 RVA: 0x006DF3CC File Offset: 0x006DD7CC
	public static List<Battle.DungeonBuff> GetBuffList(RacePlayerInfo player)
	{
		if (player == null || player.buffs == null)
		{
			return null;
		}
		List<Battle.DungeonBuff> list = new List<Battle.DungeonBuff>();
		for (int i = 0; i < player.buffs.Length; i++)
		{
			RaceBuffInfo raceBuffInfo = player.buffs[i];
			BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>((int)raceBuffInfo.id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				Battle.DungeonBuff.eBuffDurationType type = Battle.DungeonBuff.eBuffDurationType.Battle;
				if (tableItem.durationType == 2)
				{
					type = Battle.DungeonBuff.eBuffDurationType.OnlyUseInBattle;
				}
				list.Add(new Battle.DungeonBuff
				{
					id = (int)raceBuffInfo.id,
					overlay = (int)raceBuffInfo.overlayNums,
					lefttime = raceBuffInfo.duration,
					duration = raceBuffInfo.duration,
					type = type
				});
			}
		}
		return list;
	}

	// Token: 0x06016ABB RID: 92859 RVA: 0x006DF498 File Offset: 0x006DD898
	public static int GetWeaponStrengthenLevel(RacePlayerInfo player)
	{
		if (player == null)
		{
			return 0;
		}
		for (int i = 0; i < player.equips.Length; i++)
		{
			RaceEquip raceEquip = player.equips[i];
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)raceEquip.id, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SubType == ItemTable.eSubType.WEAPON)
			{
				return (int)raceEquip.strengthen;
			}
		}
		return 1;
	}

	// Token: 0x06016ABC RID: 92860 RVA: 0x006DF504 File Offset: 0x006DD904
	public static List<BuffInfoData> GetRankBuff(RacePlayerInfo player)
	{
		if (player == null)
		{
			return null;
		}
		List<BuffInfoData> list = new List<BuffInfoData>();
		IList<int> seasonAttrBuffIDs = SeasonDataManager.GetSeasonAttrBuffIDs((int)player.seasonAttr);
		if (seasonAttrBuffIDs != null)
		{
			for (int i = 0; i < seasonAttrBuffIDs.Count; i++)
			{
				if (seasonAttrBuffIDs[i] > 0)
				{
					list.Add(new BuffInfoData
					{
						buffID = seasonAttrBuffIDs[i]
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06016ABD RID: 92861 RVA: 0x006DF578 File Offset: 0x006DD978
	public static int GetCrsytalNum(RacePlayerInfo player)
	{
		int num = 0;
		if (player.raceItems.Length > 0)
		{
			for (int i = 0; i < player.raceItems.Length; i++)
			{
				if (player.raceItems[i].id == 300000106U)
				{
					num += (int)player.raceItems[i].num;
				}
			}
		}
		return num;
	}

	// Token: 0x06016ABE RID: 92862 RVA: 0x006DF5D8 File Offset: 0x006DD9D8
	public static PetData GetPetData(RacePlayerInfo player, bool isPvp)
	{
		PetData petData = new PetData();
		List<BuffInfoData> list = new List<BuffInfoData>();
		for (int i = 0; i < player.pets.Length; i++)
		{
			RacePet racePet = player.pets[i];
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)racePet.dataId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.InnateSkill > 0)
				{
					BeUtility.AddBuffFromSkill(tableItem.InnateSkill, (int)racePet.level, list, isPvp);
				}
				if (tableItem.PetType == PetTable.ePetType.PT_ATTACK)
				{
					petData.id = tableItem.MonsterID;
					if (tableItem.Skills.Length <= (int)racePet.skillIndex || racePet.skillIndex < 0)
					{
						Logger.LogErrorFormat("player accid {0} roleid {1} serverName {2} GetPetData petid {3} skill is out of Range {4}", new object[]
						{
							player.accid,
							player.roleId,
							player.serverName,
							racePet.dataId,
							racePet.skillIndex
						});
						racePet.skillIndex = 0;
					}
					if (tableItem.Skills.Length <= (int)racePet.skillIndex)
					{
						petData.skillID = 0;
					}
					else
					{
						petData.skillID = tableItem.Skills[(int)racePet.skillIndex];
					}
					petData.hunger = (int)racePet.hunger;
					petData.level = (int)racePet.level;
				}
				else
				{
					int petSkillIDByJob = PetDataManager.GetPetSkillIDByJob((int)racePet.dataId, (int)player.occupation, (int)racePet.skillIndex);
					BeUtility.AddBuffFromSkill(petSkillIDByJob, (int)racePet.level, list, isPvp);
				}
			}
		}
		petData.buffs = list;
		return petData;
	}

	// Token: 0x06016ABF RID: 92863 RVA: 0x006DF77C File Offset: 0x006DDB7C
	public static void DebugPrint(RacePlayerInfo player)
	{
		if (player == null)
		{
			return;
		}
		StringBuilder stringBuilder = StringBuilderCache.Acquire(2000);
		stringBuilder.AppendFormat("<color=red>[robot]</color> name:{0} level:{1} ai:{2}\n", player.name, player.level, player.robotAIType);
		for (int i = 0; i < player.skills.Length; i++)
		{
			stringBuilder.AppendFormat("skill {0}: L{1}\n", player.skills[i].id, player.skills[i].level);
		}
		for (int j = 0; j < player.equips.Length; j++)
		{
			stringBuilder.AppendFormat("equip:{0}\n", player.equips[j].id);
		}
	}

	// Token: 0x06016AC0 RID: 92864 RVA: 0x006DF844 File Offset: 0x006DDC44
	private RaceItem _findRaceItemById(int id)
	{
		for (int i = 0; i < this.playerInfo.raceItems.Length; i++)
		{
			RaceItem raceItem = this.playerInfo.raceItems[i];
			if (raceItem != null && (ulong)raceItem.id == (ulong)((long)id))
			{
				return raceItem;
			}
		}
		return null;
	}

	// Token: 0x06016AC1 RID: 92865 RVA: 0x006DF898 File Offset: 0x006DDC98
	private RaceItem _addRaceItemById(int id)
	{
		RaceItem raceItem = this._findRaceItemById(id);
		if (raceItem == null)
		{
			List<RaceItem> list = new List<RaceItem>(this.playerInfo.raceItems);
			raceItem = new RaceItem();
			raceItem.id = (uint)id;
			raceItem.num = 0;
			list.Add(raceItem);
			this.playerInfo.raceItems = list.ToArray();
		}
		return raceItem;
	}

	// Token: 0x06016AC2 RID: 92866 RVA: 0x006DF8F4 File Offset: 0x006DDCF4
	private int _getItemIDByRaceType(DungeonItem.eType type)
	{
		ItemConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemConfigTable>((int)type, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.ItemID;
		}
		return 0;
	}

	// Token: 0x06016AC3 RID: 92867 RVA: 0x006DF925 File Offset: 0x006DDD25
	private RaceItem _findRaceItem(DungeonItem.eType type)
	{
		return this._findRaceItemById(this._getItemIDByRaceType(type));
	}

	// Token: 0x06016AC4 RID: 92868 RVA: 0x006DF934 File Offset: 0x006DDD34
	public bool CanUseItem(DungeonItem.eType type, ushort num = 1)
	{
		return this.CanUseItemById(this._getItemIDByRaceType(type), num);
	}

	// Token: 0x06016AC5 RID: 92869 RVA: 0x006DF944 File Offset: 0x006DDD44
	public bool CanUseItemById(int id, ushort num = 1)
	{
		if (this.playerInfo == null || this.playerInfo.raceItems == null)
		{
			return false;
		}
		RaceItem raceItem = this._findRaceItemById(id);
		return raceItem != null && raceItem != null && raceItem.num >= num;
	}

	// Token: 0x06016AC6 RID: 92870 RVA: 0x006DF994 File Offset: 0x006DDD94
	public int AddItemById(int id, ushort num)
	{
		if (this.playerInfo == null || this.playerInfo.raceItems == null)
		{
			return 0;
		}
		RaceItem raceItem = this._addRaceItemById(id);
		if (raceItem == null)
		{
			return 0;
		}
		RaceItem raceItem2 = raceItem;
		raceItem2.num += num;
		Logger.LogErrorFormat("[BattlePlayer] 添加数量 {0}, {1}", new object[]
		{
			num,
			raceItem.num
		});
		return (int)raceItem.num;
	}

	// Token: 0x06016AC7 RID: 92871 RVA: 0x006DFA0C File Offset: 0x006DDE0C
	public int UseItemById(int id, ushort num = 1)
	{
		if (this.playerActor == null)
		{
			return 0;
		}
		if (this.playerInfo == null || this.playerInfo.raceItems == null)
		{
			return 0;
		}
		RaceItem raceItem = this._findRaceItemById(id);
		if (raceItem != null && raceItem.num >= num)
		{
			RaceItem raceItem2 = raceItem;
			raceItem2.num -= num;
			if (num > 0)
			{
				UseItemFrameCommand useItemFrameCommand = new UseItemFrameCommand();
				useItemFrameCommand.itemID = raceItem.id;
				useItemFrameCommand.itemNum = (uint)num;
				this.statistics.UseItem((int)raceItem.id, (int)num);
				FrameSync.instance.FireFrameCommand(useItemFrameCommand, true);
			}
			return (int)raceItem.num;
		}
		return 0;
	}

	// Token: 0x06016AC8 RID: 92872 RVA: 0x006DFAB2 File Offset: 0x006DDEB2
	public int UseItem(DungeonItem.eType type, ushort num = 1)
	{
		return this.UseItemById(this._getItemIDByRaceType(type), num);
	}

	// Token: 0x0401027B RID: 66171
	public const byte kFullLoadRate = 100;

	// Token: 0x0401027C RID: 66172
	protected BattlePlayer.eNetQuality mNetQuality = BattlePlayer.eNetQuality.Best;

	// Token: 0x0401027D RID: 66173
	protected BattlePlayer.eNetState mNetState;

	// Token: 0x0401027E RID: 66174
	protected BattlePlayer.EState mLastState;

	// Token: 0x0401027F RID: 66175
	protected BattlePlayer.EState mState;

	// Token: 0x04010280 RID: 66176
	private byte mLoadRate;

	// Token: 0x04010281 RID: 66177
	private bool mIsAutoFight;

	// Token: 0x04010282 RID: 66178
	public RacePlayerInfo playerInfo;

	// Token: 0x04010283 RID: 66179
	public BeActor playerActor;

	// Token: 0x04010284 RID: 66180
	public PlayerStatistics statistics = new PlayerStatistics();

	// Token: 0x04010285 RID: 66181
	private BattlePlayer.eDungeonPlayerTeamType mTeamType = BattlePlayer.eDungeonPlayerTeamType.eTeamBlue;

	// Token: 0x04010286 RID: 66182
	private BattlePlayer.eFightingStatus mFightingStatus;

	// Token: 0x04010287 RID: 66183
	private bool mIsFighting;

	// Token: 0x04010288 RID: 66184
	private uint mPKAllDamageRate;

	// Token: 0x04010289 RID: 66185
	private int mLastRound = -1;

	// Token: 0x0401028A RID: 66186
	private bool mIsVote;

	// Token: 0x02004107 RID: 16647
	public enum EState
	{
		// Token: 0x0401028C RID: 66188
		None,
		// Token: 0x0401028D RID: 66189
		Normal = 0,
		// Token: 0x0401028E RID: 66190
		Dead
	}

	// Token: 0x02004108 RID: 16648
	public enum eDungeonPlayerTeamType
	{
		// Token: 0x04010290 RID: 66192
		eTeamRed,
		// Token: 0x04010291 RID: 66193
		eTeamBlue
	}

	// Token: 0x02004109 RID: 16649
	public enum eNetState
	{
		// Token: 0x04010293 RID: 66195
		None,
		// Token: 0x04010294 RID: 66196
		Offline,
		// Token: 0x04010295 RID: 66197
		Online,
		// Token: 0x04010296 RID: 66198
		Quit
	}

	// Token: 0x0200410A RID: 16650
	public enum eNetQuality
	{
		// Token: 0x04010298 RID: 66200
		Off,
		// Token: 0x04010299 RID: 66201
		Bad,
		// Token: 0x0401029A RID: 66202
		Good,
		// Token: 0x0401029B RID: 66203
		Best
	}

	// Token: 0x0200410B RID: 16651
	public enum eFightingStatus
	{
		// Token: 0x0401029D RID: 66205
		None,
		// Token: 0x0401029E RID: 66206
		Fighting,
		// Token: 0x0401029F RID: 66207
		Dead
	}
}
