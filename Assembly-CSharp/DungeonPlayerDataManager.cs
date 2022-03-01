using System;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

// Token: 0x020041E2 RID: 16866
public class DungeonPlayerDataManager : IDungeonPlayerDataManager
{
	// Token: 0x06017505 RID: 95493 RVA: 0x0072C770 File Offset: 0x0072AB70
	public DungeonPlayerDataManager(BattleType type, eDungeonMode mode, BeDungeon beDungeon)
	{
		this.mDungeonMode = mode;
		this.mBattleType = type;
		this.mBeDungeon = beDungeon;
		this._prepareDebugData(mode);
		this.mBattlePlayers.Clear();
		for (int i = 0; i < DataManager<BattleDataManager>.GetInstance().PlayerInfo.Length; i++)
		{
			RacePlayerInfo racePlayerInfo = DataManager<BattleDataManager>.GetInstance().PlayerInfo[i];
			BattlePlayer battlePlayer = new BattlePlayer
			{
				playerActor = null,
				playerInfo = racePlayerInfo,
				state = BattlePlayer.EState.None,
				netState = BattlePlayer.eNetState.Online,
				netQuality = BattlePlayer.eNetQuality.Best,
				teamType = this.GetPlayerTeamType(racePlayerInfo.seat)
			};
			for (int j = 0; j < battlePlayer.playerInfo.potionPos.Length; j++)
			{
			}
			this.mBattlePlayers.Add(battlePlayer);
		}
		this._bindNetMessage();
	}

	// Token: 0x17001FBD RID: 8125
	// (get) Token: 0x06017506 RID: 95494 RVA: 0x0072C862 File Offset: 0x0072AC62
	public byte LoadingRate
	{
		get
		{
			return this.mLoadingRate;
		}
	}

	// Token: 0x06017507 RID: 95495 RVA: 0x0072C86A File Offset: 0x0072AC6A
	public void Clear()
	{
		this.mDungeonMode = eDungeonMode.None;
		this._unbindNetMessage();
		this.mBattlePlayers.Clear();
	}

	// Token: 0x06017508 RID: 95496 RVA: 0x0072C884 File Offset: 0x0072AC84
	private RacePlayerInfo GetPlayerTemplate(int seat)
	{
		RacePlayerInfo racePlayerInfo = new RacePlayerInfo
		{
			level = 50,
			name = DataManager<PlayerBaseData>.GetInstance().Name,
			seat = (byte)seat,
			occupation = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
			accid = ((seat != 0) ? 999U : ClientApplication.playerinfo.accid)
		};
		if (Global.Settings.isDebug && Global.Settings.isGiveEquips)
		{
			string[] array = Global.Settings.equipList.Split(new char[]
			{
				','
			});
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				int item = Convert.ToInt32(array[i]);
				list.Add(item);
			}
			List<RaceEquip> equips = BeUtility.GetEquips(list.ToArray());
			racePlayerInfo.equips = equips.ToArray();
		}
		List<RacePet> list2 = new List<RacePet>
		{
			new RacePet
			{
				dataId = (uint)Global.Settings.petID,
				level = (ushort)Global.Settings.petLevel,
				hunger = (ushort)Global.Settings.petHunger,
				skillIndex = (byte)Global.Settings.petSkillIndex
			}
		};
		racePlayerInfo.pets = list2.ToArray();
		NewbieGuideBattle.InitNewbieGuidePlayerInfo(ref racePlayerInfo);
		List<RaceSkillInfo> list3 = new List<RaceSkillInfo>();
		if (Global.Settings.startSystem == EClientSystem.Battle)
		{
			Dictionary<int, int> skillInfoByPid = Singleton<TableManager>.instance.GetSkillInfoByPid(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			Dictionary<int, int>.Enumerator enumerator = skillInfoByPid.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.instance;
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				SkillTable tableItem = instance.GetTableItem<SkillTable>(keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null)
				{
					KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
					if (keyValuePair2.Key <= 10000)
					{
						List<RaceSkillInfo> list4 = list3;
						RaceSkillInfo raceSkillInfo = new RaceSkillInfo();
						RaceSkillInfo raceSkillInfo2 = raceSkillInfo;
						KeyValuePair<int, int> keyValuePair3 = enumerator.Current;
						raceSkillInfo2.id = (ushort)keyValuePair3.Key;
						RaceSkillInfo raceSkillInfo3 = raceSkillInfo;
						KeyValuePair<int, int> keyValuePair4 = enumerator.Current;
						raceSkillInfo3.level = (byte)keyValuePair4.Value;
						raceSkillInfo.slot = 0;
						list4.Add(raceSkillInfo);
					}
				}
			}
			racePlayerInfo.skills = list3.ToArray();
		}
		else
		{
			IList<int> newbieGuidePlayerSkills = NewbieGuideBattle.GetNewbieGuidePlayerSkills();
			for (int j = 0; j < newbieGuidePlayerSkills.Count; j++)
			{
				list3.Add(new RaceSkillInfo
				{
					id = (ushort)newbieGuidePlayerSkills[j],
					level = 1,
					slot = 0
				});
			}
			racePlayerInfo.skills = list3.ToArray();
		}
		return racePlayerInfo;
	}

	// Token: 0x06017509 RID: 95497 RVA: 0x0072CB30 File Offset: 0x0072AF30
	private void _prepareDebugData(eDungeonMode mode)
	{
		if (mode == eDungeonMode.Test)
		{
			RacePlayerInfo[] array = new RacePlayerInfo[Global.Settings.testPlayerNum];
			for (int i = 0; i < Global.Settings.testPlayerNum; i++)
			{
				array[i] = this.GetPlayerTemplate(i);
			}
			DataManager<BattleDataManager>.GetInstance().PlayerInfo = array;
		}
	}

	// Token: 0x0601750A RID: 95498 RVA: 0x0072CB84 File Offset: 0x0072AF84
	public List<BattlePlayer> GetAllPlayers()
	{
		if (this.mBattlePlayers == null)
		{
			this.mBattlePlayers = new List<BattlePlayer>();
		}
		return this.mBattlePlayers;
	}

	// Token: 0x0601750B RID: 95499 RVA: 0x0072CBA4 File Offset: 0x0072AFA4
	public BattlePlayer GetPlayerBySeat(byte seat)
	{
		BattlePlayer result = null;
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (this.mBattlePlayers[i].playerInfo != null && seat == this.mBattlePlayers[i].playerInfo.seat)
			{
				result = this.mBattlePlayers[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x0601750C RID: 95500 RVA: 0x0072CC14 File Offset: 0x0072B014
	public BattlePlayer GetPlayerByRoleID(ulong roleId)
	{
		BattlePlayer result = null;
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (this.mBattlePlayers[i].playerInfo != null && roleId == this.mBattlePlayers[i].playerInfo.roleId)
			{
				result = this.mBattlePlayers[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x0601750D RID: 95501 RVA: 0x0072CC84 File Offset: 0x0072B084
	public BattlePlayer GetMainPlayer()
	{
		BattlePlayer result = null;
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			result = this.mBattlePlayers[0];
		}
		else
		{
			for (int i = 0; i < this.mBattlePlayers.Count; i++)
			{
				if (this.mBattlePlayers[i].playerInfo != null && ClientApplication.playerinfo.accid == this.mBattlePlayers[i].playerInfo.accid)
				{
					result = this.mBattlePlayers[i];
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x0601750E RID: 95502 RVA: 0x0072CD1E File Offset: 0x0072B11E
	public bool IsPlayerDeadByBattlePlayer(BattlePlayer player)
	{
		return player != null && player.playerActor != null && player.playerActor.IsDead();
	}

	// Token: 0x0601750F RID: 95503 RVA: 0x0072CD40 File Offset: 0x0072B140
	public bool IsPlayerDead(byte seat)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		return this.IsPlayerDeadByBattlePlayer(playerBySeat);
	}

	// Token: 0x06017510 RID: 95504 RVA: 0x0072CD5C File Offset: 0x0072B15C
	public bool IsAllPlayerDead()
	{
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (!this.IsPlayerDeadByBattlePlayer(this.mBattlePlayers[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017511 RID: 95505 RVA: 0x0072CDA0 File Offset: 0x0072B1A0
	public BattlePlayer GetFirstAlivePlayer()
	{
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (!this.IsPlayerDeadByBattlePlayer(this.mBattlePlayers[i]))
			{
				return this.mBattlePlayers[i];
			}
		}
		return null;
	}

	// Token: 0x06017512 RID: 95506 RVA: 0x0072CDF0 File Offset: 0x0072B1F0
	public void SendMainPlayerLoadRate(int rate)
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay() && !Singleton<ReplayServer>.GetInstance().IsLiveShow())
		{
			return;
		}
		if (this.mDungeonMode == eDungeonMode.SyncFrame)
		{
			byte progress = this._getFinalRate(rate);
			RelaySvrReportLoadProgress cmd = new RelaySvrReportLoadProgress
			{
				progress = progress
			};
			NetManager.Instance().SendCommand<RelaySvrReportLoadProgress>(ServerType.RELAY_SERVER, cmd);
			this.mLoadingRate = progress;
			this._updateMainPlayerProcess(progress);
		}
	}

	// Token: 0x06017513 RID: 95507 RVA: 0x0072CE5A File Offset: 0x0072B25A
	private byte _getFinalRate(int rate)
	{
		if (rate < 0)
		{
			return 0;
		}
		if (rate > 100)
		{
			return 100;
		}
		return (byte)rate;
	}

	// Token: 0x06017514 RID: 95508 RVA: 0x0072CE74 File Offset: 0x0072B274
	private void _updateMainPlayerProcess(byte progress)
	{
		BattlePlayer mainPlayer = this.GetMainPlayer();
		if (mainPlayer != null)
		{
			this._updatePlayerLoadProcess(mainPlayer.playerInfo.seat, progress);
		}
	}

	// Token: 0x06017515 RID: 95509 RVA: 0x0072CEA0 File Offset: 0x0072B2A0
	private void _updatePlayerLoadProcess(byte seat, byte progress)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		if (playerBySeat != null)
		{
			playerBySeat.loadRate = progress;
		}
	}

	// Token: 0x06017516 RID: 95510 RVA: 0x0072CEC7 File Offset: 0x0072B2C7
	public string GetMainPlayerLoadInfo()
	{
		return string.Empty;
	}

	// Token: 0x06017517 RID: 95511 RVA: 0x0072CECE File Offset: 0x0072B2CE
	public void SetMainPlayerLoadInfo(string info)
	{
	}

	// Token: 0x06017518 RID: 95512 RVA: 0x0072CED0 File Offset: 0x0072B2D0
	public byte GetPlayerLoadRate(byte seat)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		if (playerBySeat != null)
		{
			return playerBySeat.loadRate;
		}
		return 0;
	}

	// Token: 0x06017519 RID: 95513 RVA: 0x0072CEF3 File Offset: 0x0072B2F3
	private void _bindNetMessage()
	{
		NetProcess.AddMsgHandler(1300016U, new Action<MsgDATA>(this._dungeonPlayerDataMsgBinder));
	}

	// Token: 0x0601751A RID: 95514 RVA: 0x0072CF0B File Offset: 0x0072B30B
	private void _unbindNetMessage()
	{
		NetProcess.RemoveMsgHandler(1300016U, new Action<MsgDATA>(this._dungeonPlayerDataMsgBinder));
	}

	// Token: 0x0601751B RID: 95515 RVA: 0x0072CF24 File Offset: 0x0072B324
	private void _dungeonPlayerDataMsgBinder(MsgDATA data)
	{
		if (data.id == 1300016U)
		{
			RelaySvrNotifyLoadProgress relaySvrNotifyLoadProgress = new RelaySvrNotifyLoadProgress();
			relaySvrNotifyLoadProgress.decode(data.bytes);
			this._onRelaySvrNotifyLoadProgress(relaySvrNotifyLoadProgress);
		}
	}

	// Token: 0x0601751C RID: 95516 RVA: 0x0072CF5A File Offset: 0x0072B35A
	private void _onRelaySvrNotifyLoadProgress(RelaySvrNotifyLoadProgress res)
	{
		this._updatePlayerLoadProcess(res.pos, res.progress);
	}

	// Token: 0x0601751D RID: 95517 RVA: 0x0072CF6E File Offset: 0x0072B36E
	public BattlePlayer.eDungeonPlayerTeamType GetPlayerTeamType(byte seat)
	{
		if ((int)seat < this._getTeamCount())
		{
			return BattlePlayer.eDungeonPlayerTeamType.eTeamRed;
		}
		return BattlePlayer.eDungeonPlayerTeamType.eTeamBlue;
	}

	// Token: 0x0601751E RID: 95518 RVA: 0x0072CF7F File Offset: 0x0072B37F
	public int GetPlayerCount()
	{
		if (this.mBattlePlayers == null)
		{
			return 0;
		}
		return this.mBattlePlayers.Count;
	}

	// Token: 0x0601751F RID: 95519 RVA: 0x0072CF99 File Offset: 0x0072B399
	public int GetSeatCount()
	{
		if (this.mDungeonMode != eDungeonMode.SyncFrame)
		{
			return 2;
		}
		if (this.mBattleType == BattleType.PVP3V3Battle)
		{
			return 6;
		}
		if (this.mBattleType == BattleType.ScufflePVP)
		{
			return 4;
		}
		return 2;
	}

	// Token: 0x06017520 RID: 95520 RVA: 0x0072CFC8 File Offset: 0x0072B3C8
	private int _getTeamCount()
	{
		return this.GetSeatCount() / 2;
	}

	// Token: 0x06017521 RID: 95521 RVA: 0x0072CFD4 File Offset: 0x0072B3D4
	public BattlePlayer GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType type)
	{
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (this.mBattlePlayers[i].teamType == type && this.mBattlePlayers[i].isFighting)
			{
				return this.mBattlePlayers[i];
			}
		}
		return null;
	}

	// Token: 0x06017522 RID: 95522 RVA: 0x0072D038 File Offset: 0x0072B438
	public byte GetCurrentTeamFightingPlayerSeat(BattlePlayer.eDungeonPlayerTeamType type)
	{
		BattlePlayer currentTeamFightingPlayer = this.GetCurrentTeamFightingPlayer(type);
		if (!BattlePlayer.IsDataValidBattlePlayer(currentTeamFightingPlayer))
		{
			return byte.MaxValue;
		}
		return currentTeamFightingPlayer.playerInfo.seat;
	}

	// Token: 0x06017523 RID: 95523 RVA: 0x0072D06C File Offset: 0x0072B46C
	public void SetPlayerVoteFightState(byte seat, bool isFight)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		if (playerBySeat == null)
		{
			return;
		}
		playerBySeat.isVote = isFight;
	}

	// Token: 0x06017524 RID: 95524 RVA: 0x0072D090 File Offset: 0x0072B490
	public bool GetPlayerVoteFightState(byte seat)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		return playerBySeat != null && playerBySeat.isVote;
	}

	// Token: 0x06017525 RID: 95525 RVA: 0x0072D0B4 File Offset: 0x0072B4B4
	public bool IsTeamPlayerAllFighted(BattlePlayer.eDungeonPlayerTeamType type)
	{
		for (int i = 0; i < this.GetPlayerCount(); i++)
		{
			if (this.mBattlePlayers[i].teamType == type && !this.mBattlePlayers[i].isPassedInRound)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017526 RID: 95526 RVA: 0x0072D108 File Offset: 0x0072B508
	public bool IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType type)
	{
		for (int i = 0; i < this.GetPlayerCount(); i++)
		{
			if (this.mBattlePlayers[i] != null && this.mBattlePlayers[i].playerActor != null && this.mBattlePlayers[i].teamType == type && !this.mBattlePlayers[i].playerActor.IsDead())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017527 RID: 95527 RVA: 0x0072D188 File Offset: 0x0072B588
	public BattlePlayer GetTargetPlayer(byte seat)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return null;
		}
		BattlePlayer.eDungeonPlayerTeamType targetTeamType = BattlePlayer.GetTargetTeamType(playerBySeat.teamType);
		return this.GetCurrentTeamFightingPlayer(targetTeamType);
	}

	// Token: 0x06017528 RID: 95528 RVA: 0x0072D1C0 File Offset: 0x0072B5C0
	private int _getTeamCount(BattlePlayer.eDungeonPlayerTeamType type)
	{
		int num = 0;
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (this.mBattlePlayers[i].teamType == type)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06017529 RID: 95529 RVA: 0x0072D208 File Offset: 0x0072B608
	public bool IsKillEnemyMatchPlayer(byte seat)
	{
		BattlePlayer playerBySeat = this.GetPlayerBySeat(seat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return false;
		}
		int killMatchPlayerCount = playerBySeat.GetKillMatchPlayerCount();
		if (killMatchPlayerCount <= 0)
		{
			return false;
		}
		int num = this._getTeamCount(BattlePlayer.GetTargetTeamType(playerBySeat.teamType));
		return killMatchPlayerCount >= num;
	}

	// Token: 0x0601752A RID: 95530 RVA: 0x0072D254 File Offset: 0x0072B654
	public bool GetTeamVotePlayers(List<BattlePlayer> votePlayers, BattlePlayer.eDungeonPlayerTeamType type)
	{
		if (votePlayers == null)
		{
			return false;
		}
		List<BattlePlayer> allPlayers = this.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].teamType == type)
			{
				if (!allPlayers[i].hasFighted)
				{
					if (!allPlayers[i].isFighting)
					{
						if (allPlayers[i].isVote)
						{
							votePlayers.Add(allPlayers[i]);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601752B RID: 95531 RVA: 0x0072D2EC File Offset: 0x0072B6EC
	public bool GetTeamNotVotePlayers(List<BattlePlayer> notVotePlayers, BattlePlayer.eDungeonPlayerTeamType type)
	{
		if (notVotePlayers == null)
		{
			return false;
		}
		List<BattlePlayer> allPlayers = this.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].teamType == type)
			{
				if (!allPlayers[i].hasFighted)
				{
					if (!allPlayers[i].isFighting)
					{
						if (!allPlayers[i].isVote)
						{
							notVotePlayers.Add(allPlayers[i]);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601752C RID: 95532 RVA: 0x0072D384 File Offset: 0x0072B784
	public int GetTeamPlayerCount(BattlePlayer.eDungeonPlayerTeamType type)
	{
		int num = 0;
		for (int i = 0; i < this.mBattlePlayers.Count; i++)
		{
			if (this.mBattlePlayers[i].teamType == type)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0601752D RID: 95533 RVA: 0x0072D3CC File Offset: 0x0072B7CC
	public int GetMainPlayerTeamPlayerCount()
	{
		BattlePlayer mainPlayer = this.GetMainPlayer();
		if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
		{
			return 0;
		}
		return this.GetTeamPlayerCount(mainPlayer.teamType);
	}

	// Token: 0x04010C23 RID: 68643
	protected List<BattlePlayer> mBattlePlayers = new List<BattlePlayer>();

	// Token: 0x04010C24 RID: 68644
	protected eDungeonMode mDungeonMode;

	// Token: 0x04010C25 RID: 68645
	protected BattleType mBattleType = BattleType.None;

	// Token: 0x04010C26 RID: 68646
	protected BeDungeon mBeDungeon;

	// Token: 0x04010C27 RID: 68647
	private List<BattlePlayer> mCacheTeamPlayers = new List<BattlePlayer>();

	// Token: 0x04010C28 RID: 68648
	private byte mLoadingRate;

	// Token: 0x04010C29 RID: 68649
	private const int kPK3V3SeatCount = 6;

	// Token: 0x04010C2A RID: 68650
	private const int kSingleSeatCount = 2;

	// Token: 0x04010C2B RID: 68651
	private const int kPK2V2SeatCount = 4;
}
