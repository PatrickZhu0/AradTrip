using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045A9 RID: 17833
	public class BaseMatchPVPBattle : BaseBattle
	{
		// Token: 0x06018EF7 RID: 102135 RVA: 0x007CF1C7 File Offset: 0x007CD5C7
		public BaseMatchPVPBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018EF8 RID: 102136 RVA: 0x007CF1D2 File Offset: 0x007CD5D2
		protected int _getMatchRoundIndex()
		{
			return this.mRoundIndex;
		}

		// Token: 0x06018EF9 RID: 102137 RVA: 0x007CF1DA File Offset: 0x007CD5DA
		protected void _nextMatchRoundIndex()
		{
			this.mRoundIndex++;
		}

		// Token: 0x06018EFA RID: 102138 RVA: 0x007CF1EC File Offset: 0x007CD5EC
		protected void _openDungeonReadyFightFrame(byte redSeat, byte blueSeat)
		{
			DungeonReadyFightFrame.MatchedFighters matchedFighters = new DungeonReadyFightFrame.MatchedFighters();
			matchedFighters.redTeamSeat = redSeat;
			matchedFighters.blueTeamSeat = blueSeat;
			matchedFighters.roundIndex = this._getMatchRoundIndex();
			Singleton<ClientSystemManager>.instance.OpenFrame<DungeonReadyFightFrame>(FrameLayer.Middle, matchedFighters, string.Empty);
		}

		// Token: 0x06018EFB RID: 102139 RVA: 0x007CF22B File Offset: 0x007CD62B
		protected void _closeDungeonReadyFightFrame()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonReadyFightFrame>(null, false);
		}

		// Token: 0x06018EFC RID: 102140 RVA: 0x007CF23C File Offset: 0x007CD63C
		protected bool _sendRelaySvrEndGameReq()
		{
			if (this._getRelaySvrEndGameReq() == null)
			{
				return false;
			}
			MonoSingleton<NetManager>.instance.SendCommand<RelaySvrEndGameReq>(ServerType.RELAY_SERVER, this._getRelaySvrEndGameReq());
			return true;
		}

		// Token: 0x06018EFD RID: 102141 RVA: 0x007CF26C File Offset: 0x007CD66C
		protected RelaySvrEndGameReq _getRelaySvrEndGameReq()
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			PkPlayerRaceEndInfo[] array = new PkPlayerRaceEndInfo[allPlayers.Count];
			PkRaceEndInfo pkRaceEndInfo = new PkRaceEndInfo();
			pkRaceEndInfo.gamesessionId = ClientApplication.playerinfo.session;
			pkRaceEndInfo.infoes = array;
			RelaySvrEndGameReq relaySvrEndGameReq = new RelaySvrEndGameReq();
			relaySvrEndGameReq.end = pkRaceEndInfo;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				PkPlayerRaceEndInfo pkPlayerRaceEndInfo = new PkPlayerRaceEndInfo();
				array[i] = pkPlayerRaceEndInfo;
				pkPlayerRaceEndInfo.roleId = allPlayers[i].playerInfo.roleId;
				pkPlayerRaceEndInfo.pos = allPlayers[i].playerInfo.seat;
				pkPlayerRaceEndInfo.result = (byte)this._getRaceEndResult(allPlayers[i].teamType);
				if (allPlayers[i].playerActor != null)
				{
					pkPlayerRaceEndInfo.remainHp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetHPRate().single) * 1000f);
					pkPlayerRaceEndInfo.remainMp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetMPRate().single) * 1000f);
					pkPlayerRaceEndInfo.damagePercent = allPlayers[i].GetPKAllDamageRate();
				}
			}
			return relaySvrEndGameReq;
		}

		// Token: 0x06018EFE RID: 102142 RVA: 0x007CF3C8 File Offset: 0x007CD7C8
		protected PKResult _getRaceEndResult(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (!this.mDungeonPlayers.IsTeamPlayerAllFighted(type))
			{
				return PKResult.WIN;
			}
			if (!this.mDungeonPlayers.IsTeamPlayerAllFighted(BattlePlayer.GetTargetTeamType(type)))
			{
				return PKResult.LOSE;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			PKResult result = PKResult.INVALID;
			int num = -1;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].teamType == type)
				{
					int lastPKRoundIndex = allPlayers[i].GetLastPKRoundIndex();
					if (lastPKRoundIndex > num)
					{
						result = allPlayers[i].GetLastPKResult();
						num = lastPKRoundIndex;
					}
				}
			}
			return result;
		}

		// Token: 0x06018EFF RID: 102143 RVA: 0x007CF460 File Offset: 0x007CD860
		protected void _showMatchResult(PKResult pkResult)
		{
			BattlePvpFrame battlePvpFrame = BattleUIHelper.GetBattleUIFrame<BattlePvpFrame>() as BattlePvpFrame;
			if (battlePvpFrame != null)
			{
				battlePvpFrame.ShowPkResult(pkResult);
				if (pkResult == PKResult.WIN)
				{
					MonoSingleton<AudioManager>.instance.PlaySound(19);
				}
				else if (pkResult == PKResult.LOSE)
				{
					MonoSingleton<AudioManager>.instance.PlaySound(20);
				}
			}
		}

		// Token: 0x06018F00 RID: 102144 RVA: 0x007CF4B4 File Offset: 0x007CD8B4
		protected void _hiddenMatchResult()
		{
			BattlePvpFrame battlePvpFrame = BattleUIHelper.GetBattleUIFrame<BattlePvpFrame>() as BattlePvpFrame;
			if (battlePvpFrame != null)
			{
				battlePvpFrame.HiddenPkResult();
			}
		}

		// Token: 0x06018F01 RID: 102145 RVA: 0x007CF4D8 File Offset: 0x007CD8D8
		protected void _showMainPlayerIsNextPlayer()
		{
			Battle3v3Frame battle3v3Frame = BattleUIHelper.GetBattleUIFrame<Battle3v3Frame>() as Battle3v3Frame;
			if (battle3v3Frame != null)
			{
				battle3v3Frame.ShowPVP3V3Tips();
			}
		}

		// Token: 0x06018F02 RID: 102146 RVA: 0x007CF4FC File Offset: 0x007CD8FC
		protected void _hiddenMainPlayerIsNextPlayer()
		{
			Battle3v3Frame battle3v3Frame = BattleUIHelper.GetBattleUIFrame<Battle3v3Frame>() as Battle3v3Frame;
			if (battle3v3Frame != null)
			{
				battle3v3Frame.HiddenPVP3V3Tips();
			}
		}

		// Token: 0x06018F03 RID: 102147 RVA: 0x007CF520 File Offset: 0x007CD920
		protected PKResult _getMatchPVPResult(byte seat, ePVPBattleEndType a_eEndType)
		{
			BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
			if (!this._isValidCharacter(playerBySeat))
			{
				Logger.LogErrorFormat("[战斗] 传入座位号 {0} 玩家为空", new object[]
				{
					seat
				});
				return PKResult.INVALID;
			}
			BattlePlayer targetPlayer = this.mDungeonPlayers.GetTargetPlayer(playerBySeat.playerInfo.seat);
			if (!this._isValidCharacter(targetPlayer))
			{
				Logger.LogErrorFormat("[战斗] 传入座位号 {0} 玩家敌对玩家为空", new object[]
				{
					seat
				});
				return PKResult.INVALID;
			}
			PKResult result = PKResult.INVALID;
			if (a_eEndType == ePVPBattleEndType.onTimeOut)
			{
				VFactor hprate = playerBySeat.playerActor.GetEntityData().GetHPRate();
				VFactor hprate2 = targetPlayer.playerActor.GetEntityData().GetHPRate();
				if (hprate == hprate2)
				{
					result = PKResult.DRAW;
				}
				else if (hprate > hprate2)
				{
					result = PKResult.WIN;
				}
				else
				{
					result = PKResult.LOSE;
				}
			}
			else if (a_eEndType == ePVPBattleEndType.onAllEnemyDied)
			{
				if (this.mDungeonPlayers.IsPlayerDeadByBattlePlayer(playerBySeat) && this.mDungeonPlayers.IsPlayerDeadByBattlePlayer(targetPlayer))
				{
					result = PKResult.DRAW;
				}
				else if (this.mDungeonPlayers.IsPlayerDeadByBattlePlayer(playerBySeat))
				{
					result = PKResult.LOSE;
				}
				else if (this.mDungeonPlayers.IsPlayerDeadByBattlePlayer(targetPlayer))
				{
					result = PKResult.WIN;
				}
			}
			this._setMatchPVPResultForBattlePlayer(playerBySeat, targetPlayer, result, a_eEndType);
			return result;
		}

		// Token: 0x06018F04 RID: 102148 RVA: 0x007CF660 File Offset: 0x007CDA60
		private void _setMatchPVPResultForBattlePlayer(BattlePlayer player, BattlePlayer targetPlayer, PKResult result, ePVPBattleEndType endType)
		{
			if (player == null || targetPlayer == null)
			{
				Logger.LogErrorFormat("[战斗] 保存战斗结果出错，因为传入玩家对象为空", new object[0]);
				return;
			}
			uint selfHpRate = (uint)(player.playerActor.GetEntityData().GetHPRate().single * 10000f);
			uint selfHpRate2 = (uint)(targetPlayer.playerActor.GetEntityData().GetHPRate().single * 10000f);
			player.AddPKResult(this._getMatchRoundIndex(), targetPlayer.GetPlayerSeat(), result, endType, selfHpRate);
			targetPlayer.AddPKResult(this._getMatchRoundIndex(), player.GetPlayerSeat(), this._getTargetPkResult(result), endType, selfHpRate2);
			player.AddDamageData(targetPlayer.GetPlayerSeat(), targetPlayer.GetLastHurtedRate());
			targetPlayer.AddDamageData(player.GetPlayerSeat(), player.GetLastHurtedRate());
		}

		// Token: 0x06018F05 RID: 102149 RVA: 0x007CF720 File Offset: 0x007CDB20
		private PKResult _getTargetPkResult(PKResult pkResult)
		{
			switch (pkResult)
			{
			case PKResult.WIN:
				return PKResult.LOSE;
			case PKResult.LOSE:
				return PKResult.WIN;
			case PKResult.DRAW:
			case PKResult.INVALID:
				return pkResult;
			}
			Logger.LogErrorFormat("[战斗] 错误pk结果类型 {0}", new object[]
			{
				pkResult
			});
			return PKResult.INVALID;
		}

		// Token: 0x06018F06 RID: 102150 RVA: 0x007CF77C File Offset: 0x007CDB7C
		protected void _fireDoublePressConfigFrame()
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				return;
			}
			bool attackReplaceLigui = false;
			BeActor playerActor = mainPlayer.playerActor;
			if (playerActor != null && playerActor.GetEntityData() != null && playerActor.GetEntityData().professtion == 11)
			{
				attackReplaceLigui = Singleton<SettingManager>.GetInstance().GetLiGuiValue("SETTING_LIGUI");
			}
			string key = (!BattleMain.IsModePvP(base.GetBattleType())) ? "STR_CHASER_PVE" : "STR_CHASER_PVP";
			byte chaserSwitch = (byte)Singleton<SettingManager>.GetInstance().GetChaserSetting(key);
			DoublePressConfigCommand doublePressConfigCommand = new DoublePressConfigCommand();
			doublePressConfigCommand.attackReplaceLigui = attackReplaceLigui;
			doublePressConfigCommand.hasDoublePress = Global.Settings.hasDoubleRun;
			doublePressConfigCommand.hasRunAttackConfig = (Singleton<SettingManager>.GetInstance().GetRunAttackMode() == InputManager.RunAttackMode.QTE);
			doublePressConfigCommand.canUseCrystalSkill = BeUtility.CheckVipAutoUseCrystalSkill();
			doublePressConfigCommand.backHitConfig = Singleton<SettingManager>.GetInstance().GetValue("STR_BACKHIT");
			doublePressConfigCommand.autoHitConfig = Singleton<SettingManager>.GetInstance().GetValue("STR_AUTOHIT");
			doublePressConfigCommand.paladinAttackCharge = (Singleton<SettingManager>.GetInstance().GetPaladinAttack() == InputManager.PaladinAttack.OPEN);
			doublePressConfigCommand.chaserSwitch = chaserSwitch;
			doublePressConfigCommand.xuanWuManualAttack = (Singleton<SettingManager>.GetInstance().GetSlideMode("3612") == InputManager.SlideSetting.SLIDE);
			doublePressConfigCommand.floatShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1006") == InputManager.SlideSetting.SLIDE);
			doublePressConfigCommand.headShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1104") == InputManager.SlideSetting.SLIDE);
			FrameSync.instance.FireFrameCommand(doublePressConfigCommand, false);
		}

		// Token: 0x06018F07 RID: 102151 RVA: 0x007CF8F0 File Offset: 0x007CDCF0
		protected bool _updateCameraForBattlePlayer(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				Logger.LogError("[战斗] 设置跟随相机的目标玩家为空");
				return false;
			}
			GeSceneEx geScene = this.mDungeonManager.GetGeScene();
			if (geScene == null)
			{
				Logger.LogError("[战斗] 设置跟随相机的 geScene 为空");
				return false;
			}
			geScene.AttachCameraTo(player.playerActor.m_pkGeActor);
			return true;
		}

		// Token: 0x06018F08 RID: 102152 RVA: 0x007CF948 File Offset: 0x007CDD48
		protected void _startRoundReadyFight(int countTimeInSec, int fightTimeInSec, bool startAI = true)
		{
			GameObject gameObject = Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, "UIFlatten/Prefabs/Pk/StartFight", 0f);
			this.mDungeonManager.GetBeScene().TriggerEvent(BeEventSceneType.on3v3SwitchNext, null);
			List<BattlePlayer> players = this.mDungeonPlayers.GetAllPlayers();
			this.mDungeonManager.GetBeScene().StartPKCountDown(countTimeInSec, delegate
			{
				ClientSystemBattle.StartTimer(fightTimeInSec);
				for (int i = 0; i < players.Count; i++)
				{
					if (this._isValidCharacter(players[i]))
					{
						BeActor playerActor = players[i].playerActor;
						if (players[i].isFighting)
						{
							playerActor.StartInitCDForSkill(false);
							playerActor.pkRestrainPosition = false;
						}
						this._unlimitCharactorRestrainZoneWithBattlePlayer(players[i]);
						if (startAI && playerActor.aiManager != null)
						{
							playerActor.pauseAI = false;
							if (this.recordServer != null && this.recordServer.IsProcessRecord())
							{
								this.recordServer.Mark(169088064U);
							}
							if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
							{
								Singleton<RecordServer>.GetInstance().RecordStartFrame();
							}
						}
					}
				}
				this._onMatchBattlePlayerReady2Fight();
			});
		}

		// Token: 0x06018F09 RID: 102153 RVA: 0x007CF9C8 File Offset: 0x007CDDC8
		protected bool _adjustBalanceMatchPlayer(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BattlePlayer targetPlayer = this.mDungeonPlayers.GetTargetPlayer(player.GetPlayerSeat());
			if (!this._isValidCharacter(targetPlayer))
			{
				Logger.LogErrorFormat("[战斗] 多人匹配 天平调整 {0} 对手为空", new object[]
				{
					player.GetPlayerSeat()
				});
				return false;
			}
			player.playerActor.UseAdjustBalance();
			player.playerActor.GetEntityData().AdjustHPForPvP((int)player.playerInfo.level, (int)targetPlayer.playerInfo.level, (int)player.playerInfo.occupation, (int)targetPlayer.playerInfo.occupation, base.PkRaceType);
			return true;
		}

		// Token: 0x06018F0A RID: 102154 RVA: 0x007CFA70 File Offset: 0x007CDE70
		protected BeActor _createMatchPlayer(BattlePlayer player)
		{
			BeActor beActor = this._createCharacterForBattlePlayer(player);
			if (beActor == null)
			{
				return null;
			}
			this._initCharactorData(player);
			this._initFollowCameara(player);
			this._createCharacterExtraUI(player);
			this._bindCharactorEvents(player);
			return beActor;
		}

		// Token: 0x06018F0B RID: 102155 RVA: 0x007CFAB0 File Offset: 0x007CDEB0
		private BeActor _createCharacterForBattlePlayer(BattlePlayer player)
		{
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return null;
			}
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene == null)
			{
				return null;
			}
			RacePlayerInfo playerInfo = player.playerInfo;
			Dictionary<int, int> skillInfo = BattlePlayer.GetSkillInfo(playerInfo);
			List<ItemProperty> equips = BattlePlayer.GetEquips(playerInfo, true);
			List<ItemProperty> sideEquips = BattlePlayer.GetSideEquips(playerInfo, true);
			int weaponStrengthenLevel = BattlePlayer.GetWeaponStrengthenLevel(playerInfo);
			List<BuffInfoData> rankBuff = BattlePlayer.GetRankBuff(playerInfo);
			PetData petData = BattlePlayer.GetPetData(playerInfo, true);
			Dictionary<int, string> avatar = BattlePlayer.GetAvatar(playerInfo);
			bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
			bool isAIRobot = playerInfo.robotAIType > 0;
			BeActor beActor = beScene.CreateCharacter(player.IsLocalPlayer(), (int)playerInfo.occupation, (int)playerInfo.level, player.GetPlayerCamp(), skillInfo, equips, null, 0, string.Empty, weaponStrengthenLevel, rankBuff, petData, sideEquips, avatar, isShowWeapon, isAIRobot);
			beActor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
			if (petData != null)
			{
				beActor.SetPetData(petData);
				beActor.CreateFollowMonster();
			}
			if (beActor.m_pkGeActor != null)
			{
				beActor.m_pkGeActor.PushPostLoadCommand(delegate
				{
				});
			}
			player.playerActor = beActor;
			player.isFighting = true;
			return beActor;
		}

		// Token: 0x06018F0C RID: 102156 RVA: 0x007CFC10 File Offset: 0x007CE010
		private bool _initFollowCameara(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer == null)
			{
				return false;
			}
			if (mainPlayer.teamType == player.teamType)
			{
				this._updateCameraForBattlePlayer(player);
			}
			return true;
		}

		// Token: 0x06018F0D RID: 102157 RVA: 0x007CFC5C File Offset: 0x007CE05C
		private bool _initCharactorData(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			RacePlayerInfo playerInfo = player.playerInfo;
			if (playerActor.GetEntityData() != null)
			{
				playerActor.GetEntityData().SetCrystalNum(BattlePlayer.GetCrsytalNum(playerInfo));
			}
			playerActor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
			this._setCharactorAtBirthPosition(player);
			this._limitCharactorRestrainZone(player);
			if (playerInfo.robotAIType > 0)
			{
				this._initCharactorAIForRobot(playerActor, (int)playerInfo.robotAIType, (int)playerInfo.robotHard);
			}
			playerActor.isMainActor = true;
			playerActor.UseProtect();
			playerActor.UseActorData();
			return true;
		}

		// Token: 0x06018F0E RID: 102158 RVA: 0x007CFCF0 File Offset: 0x007CE0F0
		protected bool _setCharactorAtBirthPosition(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			VInt3 rkPos = new VInt3((!player.IsTeamRed()) ? 40000 : -40000, 0, 0);
			playerActor.SetPosition(rkPos, true, true, false);
			playerActor.SetFace(!player.IsTeamRed(), false, false);
			playerActor.m_iRemoveTime = GlobalLogic.VALUE_1000 * 120;
			return true;
		}

		// Token: 0x06018F0F RID: 102159 RVA: 0x007CFD60 File Offset: 0x007CE160
		protected bool _resetCharactorStatus(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			playerActor.ResetActorStatus();
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.ForceDoDeadEntityByOwner(playerActor);
			}
			return true;
		}

		// Token: 0x06018F10 RID: 102160 RVA: 0x007CFDA4 File Offset: 0x007CE1A4
		protected void _sceneEntityRemoveAll()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.Pvp3v3EntityRemoveAll();
			}
		}

		// Token: 0x06018F11 RID: 102161 RVA: 0x007CFDCC File Offset: 0x007CE1CC
		protected bool _limitCharactorRestrainZone(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			playerActor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, false);
			if (player.IsTeamRed())
			{
				playerActor.pkRestrainPosition = true;
				playerActor.pkRestrainRangeX = new VInt2(-4.4f, -3.6f);
			}
			else
			{
				playerActor.pkRestrainPosition = true;
				playerActor.pkRestrainRangeX = new VInt2(3.6f, 4.4f);
			}
			return true;
		}

		// Token: 0x06018F12 RID: 102162 RVA: 0x007CFE44 File Offset: 0x007CE244
		private bool _unlimitCharactorRestrainZoneWithBattlePlayer(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			playerActor.pkRestrainPosition = false;
			playerActor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, true);
			return true;
		}

		// Token: 0x06018F13 RID: 102163 RVA: 0x007CFE7C File Offset: 0x007CE27C
		private void _initCharactorAIForRobot(BeActor actor, int aiLevel, int matchNum = 0)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AIConfigTable>();
			AIConfigTable aiconfigTable = null;
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AIConfigTable aiconfigTable2 = keyValuePair.Value as AIConfigTable;
				if (aiconfigTable2.JobID == actor.GetEntityData().professtion && aiconfigTable2.AIType == aiLevel)
				{
					aiconfigTable = aiconfigTable2;
				}
			}
			actor.isPkRobot = true;
			if (aiconfigTable != null)
			{
				actor.InitAutoFight(aiconfigTable.AIActionPath, aiconfigTable.AIDestinationSelectPath, aiconfigTable.AIEventPath, aiconfigTable.AIAttackDelay, aiconfigTable.AIDestinationChangeTerm, aiconfigTable.AIThinkTargetTerm, aiconfigTable.AIKeepDistance, true);
			}
			else
			{
				Logger.LogErrorFormat("找不到机器人AI难度:{0}", new object[]
				{
					aiLevel
				});
			}
			float[] array = new float[]
			{
				0.35f,
				0.5f,
				0.6f
			};
			if (matchNum >= 1 && matchNum <= 3)
			{
				BeEntityData entityData = actor.GetEntityData();
				if (entityData != null)
				{
					float num = array[matchNum - 1];
					int maxHP = entityData.GetMaxHP();
					int num2 = IntMath.Float2Int((float)entityData.GetMaxHP() * num);
					entityData.SetMaxHP(num2);
					entityData.SetHP(num2);
					actor.m_pkGeActor.ResetHPBar();
				}
			}
		}

		// Token: 0x06018F14 RID: 102164 RVA: 0x007CFFDC File Offset: 0x007CE3DC
		private bool _createCharacterExtraUI(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BeActor playerActor = player.playerActor;
			RacePlayerInfo playerInfo = player.playerInfo;
			if (player.IsLocalPlayer())
			{
				playerActor.isLocalActor = true;
				playerActor.m_pkGeActor.CreatePKHPBar((!player.IsTeamRed()) ? CPKHPBar.PKBarType.Right : CPKHPBar.PKBarType.Left, playerInfo.name, PlayerInfoColor.PK_PLAYER);
			}
			else
			{
				if (Singleton<ReplayServer>.GetInstance().IsReplay() && player.IsTeamRed() && player.playerInfo.seat == 0)
				{
					playerActor.isLocalActor = true;
				}
				playerActor.m_pkGeActor.CreatePKHPBar((!player.IsTeamRed()) ? CPKHPBar.PKBarType.Right : CPKHPBar.PKBarType.Left, playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER);
			}
			if (this._isSameTeam(player))
			{
				playerActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_PLAYER, playerInfo.level, null, 0f);
				playerActor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_PLAYER, string.Empty, null, 0, 0);
			}
			else
			{
				playerActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER, playerInfo.level, null, 0f);
				playerActor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_OTHER_PLAYER, string.Empty, null, 0, 0);
				playerActor.m_pkGeActor.CreateFootIndicator(null);
			}
			return true;
		}

		// Token: 0x06018F15 RID: 102165 RVA: 0x007D0154 File Offset: 0x007CE554
		private bool _isSameTeam(BattlePlayer player)
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			return BattlePlayer.IsDataValidBattlePlayer(mainPlayer) && mainPlayer.teamType == player.teamType;
		}

		// Token: 0x06018F16 RID: 102166 RVA: 0x007D018C File Offset: 0x007CE58C
		private bool _bindCharactorEvents(BattlePlayer player)
		{
			if (!this._isValidCharacter(player))
			{
				return false;
			}
			BattlePlayer currentBattlePlayer = player;
			BeActor playerActor = currentBattlePlayer.playerActor;
			playerActor.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
			{
				this._onMatchBattlePlayerDeadEvent(currentBattlePlayer);
			});
			return true;
		}

		// Token: 0x06018F17 RID: 102167 RVA: 0x007D01DD File Offset: 0x007CE5DD
		private bool _unbindEventsForBattlePlayer(BattlePlayer player)
		{
			return true;
		}

		// Token: 0x06018F18 RID: 102168 RVA: 0x007D01E0 File Offset: 0x007CE5E0
		protected bool _killOneTeamPlayer(BattlePlayer.eDungeonPlayerTeamType type)
		{
			BattlePlayer currentTeamFightingPlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(type);
			if (!this._isValidCharacter(currentTeamFightingPlayer))
			{
				return false;
			}
			if (!currentTeamFightingPlayer.isFighting)
			{
				return false;
			}
			if (currentTeamFightingPlayer.playerActor.IsDead())
			{
				return false;
			}
			currentTeamFightingPlayer.playerActor.DoDead(false);
			this._onMatchBattlePlayerDeadEvent(currentTeamFightingPlayer);
			return true;
		}

		// Token: 0x06018F19 RID: 102169 RVA: 0x007D023C File Offset: 0x007CE63C
		private bool _isValidCharacter(BattlePlayer player)
		{
			return BattlePlayer.IsDataValidBattlePlayer(player) && player.playerActor != null;
		}

		// Token: 0x06018F1A RID: 102170 RVA: 0x007D0266 File Offset: 0x007CE666
		private void _onMatchBattlePlayerDeadEvent(BattlePlayer player)
		{
			if (player != null)
			{
			}
			if (player != null)
			{
				player.state = BattlePlayer.EState.Dead;
			}
			this._onMatchBattlePlayerDead(player);
			if (player != null)
			{
				player.isFighting = false;
			}
		}

		// Token: 0x06018F1B RID: 102171 RVA: 0x007D028F File Offset: 0x007CE68F
		protected virtual void _onMatchBattlePlayerDead(BattlePlayer player)
		{
		}

		// Token: 0x06018F1C RID: 102172 RVA: 0x007D0291 File Offset: 0x007CE691
		protected virtual void _onMatchBattlePlayerReady2Fight()
		{
		}

		// Token: 0x04011EEE RID: 73454
		private int mRoundIndex;
	}
}
