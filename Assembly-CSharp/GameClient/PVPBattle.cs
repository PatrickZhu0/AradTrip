using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C0 RID: 17856
	public class PVPBattle : BaseBattle
	{
		// Token: 0x060190DC RID: 102620 RVA: 0x007D947A File Offset: 0x007D787A
		public PVPBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x060190DD RID: 102621 RVA: 0x007D9490 File Offset: 0x007D7890
		public override void FrameUpdate(int delta)
		{
			base.FrameUpdate(delta);
			if (this.gameTimer != null)
			{
				this.gameTimer.UpdateTimer(delta);
			}
			if (this.isReplay)
			{
				return;
			}
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.alreadySendResult)
			{
				return;
			}
			if (this.gameTimer != null && this.gameTimer.IsTimeUp())
			{
				this._onTimeUp();
			}
		}

		// Token: 0x060190DE RID: 102622 RVA: 0x007D9510 File Offset: 0x007D7910
		protected bool IsTimeUp()
		{
			return this.gameTimer == null || this.gameTimer.IsTimeUp();
		}

		// Token: 0x060190DF RID: 102623 RVA: 0x007D9534 File Offset: 0x007D7934
		protected override void _onGameStartFrame(BattlePlayer player)
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<PkLoadingFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<Dungeon3v3LoadingFrame>(null, false);
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null)
			{
				DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
			}
			this.StartCountDown(true);
		}

		// Token: 0x060190E0 RID: 102624 RVA: 0x007D9588 File Offset: 0x007D7988
		public void StartCountDown(bool startAI = true)
		{
			GameObject gameObject = Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, "UIFlatten/Prefabs/Pk/StartFight", 0f);
			this.mDungeonManager.GetBeScene().StartPKCountDown(4, delegate
			{
				ClientSystemBattle.StartTimer(240);
				this.gameTimer.SetCountdown(240);
				this.gameTimer.StartTimer();
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					BeActor playerActor = allPlayers[i].playerActor;
					if (playerActor != null)
					{
						playerActor.StartInitCDForSkill(false);
						playerActor.pkRestrainPosition = false;
					}
					if (startAI && playerActor != null && playerActor.aiManager != null)
					{
						playerActor.pauseAI = false;
						if (this.recordServer != null && this.recordServer.IsProcessRecord())
						{
							this.recordServer.Mark(3091343169U);
						}
						if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
						{
							Singleton<RecordServer>.GetInstance().RecordStartFrame();
						}
					}
				}
				this.mDungeonManager.GetBeScene().TriggerEvent(BeEventSceneType.onStartPK, null);
			});
		}

		// Token: 0x060190E1 RID: 102625 RVA: 0x007D95DC File Offset: 0x007D79DC
		protected virtual void _onTimeUp()
		{
			if (this.alreadySendResult)
			{
				return;
			}
			this.mEndType = ePVPBattleEndType.onTimeOut;
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				if (this.mfinishBattle != null)
				{
					return;
				}
				this.mfinishBattle = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._FinishBattle(ePVPBattleEndType.onTimeOut));
			}
		}

		// Token: 0x060190E2 RID: 102626 RVA: 0x007D9630 File Offset: 0x007D7A30
		public void _stopRobotAI()
		{
			if (this.mDungeonPlayers == null)
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null && !playerActor.IsDead() && !playerActor.pauseAI && playerActor.aiManager != null)
				{
					playerActor.aiManager.Stop();
				}
			}
		}

		// Token: 0x060190E3 RID: 102627 RVA: 0x007D96AC File Offset: 0x007D7AAC
		protected virtual void _onPlayerDead(BattlePlayer player)
		{
			if (this.alreadySendResult)
			{
				return;
			}
			this._stopRobotAI();
			this.mDungeonManager.FinishFight();
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				this._saveResult(ePVPBattleEndType.onAllEnemyDied);
				if (this.mfinishBattle != null)
				{
					return;
				}
				this.mfinishBattle = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._FinishBattle(ePVPBattleEndType.onAllEnemyDied));
			}
		}

		// Token: 0x060190E4 RID: 102628 RVA: 0x007D9710 File Offset: 0x007D7B10
		public void LogicServerSendResult(ePVPBattleEndType a_eEndType)
		{
			if (base.GetBattleType() != BattleType.ScufflePVP && base.GetBattleType() != BattleType.PVP3V3Battle)
			{
				if (this.savedReq == null)
				{
					this._saveResult(a_eEndType);
				}
				if (this.savedReq != null)
				{
					LogicServer.ReportPkRaceEndToLogicServer(this.savedReq);
				}
				this.alreadySendResult = true;
			}
		}

		// Token: 0x060190E5 RID: 102629 RVA: 0x007D9768 File Offset: 0x007D7B68
		protected IEnumerator _FinishBattle(ePVPBattleEndType a_eEndType)
		{
			if (Singleton<RecordServer>.instance != null)
			{
			}
			yield return Yielders.GetWaitForSeconds((float)Global.Settings.bullteTime * Global.Settings.bullteScale / 1000f);
			yield return Yielders.GetWaitForSeconds(0.5f);
			this._ShowResultEffect(a_eEndType);
			yield return Yielders.GetWaitForSeconds(2f);
			this._sendResult(a_eEndType);
			yield break;
		}

		// Token: 0x060190E6 RID: 102630 RVA: 0x007D978C File Offset: 0x007D7B8C
		protected virtual PKResult _getPKResulte(byte seat, ePVPBattleEndType a_eEndType)
		{
			BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
			if (a_eEndType == ePVPBattleEndType.onTimeOut)
			{
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					if (allPlayers[i].playerInfo.seat != seat)
					{
						VFactor hprate = playerBySeat.playerActor.GetEntityData().GetHPRate();
						VFactor hprate2 = allPlayers[i].playerActor.GetEntityData().GetHPRate();
						PKResult result;
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
						return result;
					}
				}
			}
			else if (a_eEndType == ePVPBattleEndType.onAllEnemyDied)
			{
				if (playerBySeat.playerActor.IsDead())
				{
					return PKResult.LOSE;
				}
				return PKResult.WIN;
			}
			return PKResult.INVALID;
		}

		// Token: 0x060190E7 RID: 102631 RVA: 0x007D9864 File Offset: 0x007D7C64
		public void OnPlayWinAction(ePVPBattleEndType a_eEndType)
		{
			if (this.mDungeonPlayers == null)
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (BattlePlayer.IsDataValidBattlePlayer(allPlayers[i]))
				{
					PKResult pkresult = this._getPKResulte(allPlayers[i].playerInfo.seat, a_eEndType);
					if (pkresult == PKResult.WIN)
					{
						BeActor playerActor = allPlayers[i].playerActor;
						if (playerActor != null)
						{
							this.handler = BeUtility.ShowWin(playerActor, this.handler);
						}
					}
				}
			}
		}

		// Token: 0x060190E8 RID: 102632 RVA: 0x007D98FC File Offset: 0x007D7CFC
		protected virtual void _ShowResultEffect(ePVPBattleEndType a_eEndType)
		{
			BattlePvpFrame battlePvpFrame = BattleUIHelper.GetBattleUIFrame<BattlePvpFrame>() as BattlePvpFrame;
			if (battlePvpFrame != null && this.mDungeonPlayers != null)
			{
				BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
				if (mainPlayer != null && mainPlayer.playerInfo != null)
				{
					PKResult pkresult = this._getPKResulte(mainPlayer.playerInfo.seat, a_eEndType);
					battlePvpFrame.ShowPkResult(pkresult);
					if (pkresult == PKResult.WIN)
					{
						MonoSingleton<AudioManager>.instance.PlaySound(19);
					}
					else if (pkresult == PKResult.LOSE)
					{
						MonoSingleton<AudioManager>.instance.PlaySound(20);
					}
				}
			}
		}

		// Token: 0x060190E9 RID: 102633 RVA: 0x007D998C File Offset: 0x007D7D8C
		protected uint _getVideoScore(PkPlayerRaceEndInfo[] playerInfos)
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			if (allPlayers.Count < 2)
			{
				return 0U;
			}
			if (allPlayers[0] == null || allPlayers[1] == null)
			{
				return 0U;
			}
			if (allPlayers[0].playerInfo == null || allPlayers[1].playerInfo == null)
			{
				return 0U;
			}
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			num += this._getHitScore(allPlayers[0].playerActor.actorData);
			num += this._getHitScore(allPlayers[1].playerActor.actorData);
			num2 += this._getSeasonScore(allPlayers[0].playerInfo.seasonLevel, (PKResult)playerInfos[0].result);
			num2 += this._getSeasonScore(allPlayers[1].playerInfo.seasonLevel, (PKResult)playerInfos[1].result);
			num3 += this._getExtraScore(allPlayers[0].playerActor.actorData);
			num3 += this._getExtraScore(allPlayers[1].playerActor.actorData);
			float num4 = 0f;
			if (this.mDungeonManager != null)
			{
				SimpleTimer pkTimer = this.mDungeonManager.GetBeScene().pkTimer;
				if (pkTimer != null)
				{
					num4 = this._getTimeFactor(pkTimer.GetPassTime());
				}
			}
			return (uint)((num + num3 + num2) * num4);
		}

		// Token: 0x060190EA RID: 102634 RVA: 0x007D9AF4 File Offset: 0x007D7EF4
		private float _getTimeFactor(int passTime)
		{
			int num = Mathf.Abs(150 - passTime);
			if (num < 10)
			{
				return 1f;
			}
			if (num < 30)
			{
				return 0.9f;
			}
			if (num < 60)
			{
				return 0.85f;
			}
			if (num < 90)
			{
				return 0.8f;
			}
			if (num < 240)
			{
				return 0.7f;
			}
			return 0.7f;
		}

		// Token: 0x060190EB RID: 102635 RVA: 0x007D9B5C File Offset: 0x007D7F5C
		private uint _getHitScore(BeActorData data)
		{
			return data.GetDamageScore() + data.GetExtraScore();
		}

		// Token: 0x060190EC RID: 102636 RVA: 0x007D9B6B File Offset: 0x007D7F6B
		private uint _getExtraScore(BeActorData data)
		{
			return data.GetExtraScore();
		}

		// Token: 0x060190ED RID: 102637 RVA: 0x007D9B74 File Offset: 0x007D7F74
		private uint _getSeasonScore(uint seasonLevel, PKResult result)
		{
			uint num = 0U;
			uint[] array = new uint[]
			{
				0U,
				105U,
				150U,
				255U,
				270U,
				300U,
				360U,
				450U
			};
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>((int)seasonLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int mainLevel = (int)tableItem.MainLevel;
				if (mainLevel < array.Length)
				{
					num = array[mainLevel];
				}
			}
			if (result == PKResult.WIN)
			{
				num = (uint)(num * 0.7f);
			}
			else if (result == PKResult.LOSE)
			{
				num = (uint)(num * 0.3f);
			}
			else
			{
				num = 0U;
			}
			return num;
		}

		// Token: 0x060190EE RID: 102638 RVA: 0x007D9BF8 File Offset: 0x007D7FF8
		protected virtual void _saveResult(ePVPBattleEndType a_eEndType)
		{
			if (this.savedReq != null)
			{
				return;
			}
			if (this.mDungeonPlayers == null)
			{
				return;
			}
			this.mEndType = a_eEndType;
			RelaySvrEndGameReq relaySvrEndGameReq = new RelaySvrEndGameReq();
			PkRaceEndInfo pkRaceEndInfo = new PkRaceEndInfo
			{
				gamesessionId = ClientApplication.playerinfo.session
			};
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			PkPlayerRaceEndInfo[] array = new PkPlayerRaceEndInfo[allPlayers.Count];
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != null && allPlayers[i].playerInfo != null)
				{
					byte seat = allPlayers[i].playerInfo.seat;
					PkPlayerRaceEndInfo pkPlayerRaceEndInfo = new PkPlayerRaceEndInfo
					{
						roleId = allPlayers[i].playerInfo.roleId,
						pos = seat,
						remainHp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetHPRate().single) * 1000f),
						remainMp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetMPRate().single) * 1000f),
						result = (byte)this._getPKResulte(seat, a_eEndType)
					};
					array[i] = pkPlayerRaceEndInfo;
				}
			}
			pkRaceEndInfo.infoes = array;
			pkRaceEndInfo.replayScore = this._getVideoScore(array);
			relaySvrEndGameReq.end = pkRaceEndInfo;
			this.savedReq = relaySvrEndGameReq;
		}

		// Token: 0x060190EF RID: 102639 RVA: 0x007D9D84 File Offset: 0x007D8184
		private void _sendResult(ePVPBattleEndType a_eEndType)
		{
			if (this.savedReq == null)
			{
				this._saveResult(a_eEndType);
			}
			try
			{
				if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
				{
					int duration = 0;
					if (this.mDungeonManager != null)
					{
						SimpleTimer pkTimer = this.mDungeonManager.GetBeScene().pkTimer;
						if (pkTimer != null)
						{
							duration = pkTimer.GetPassTime();
						}
					}
					else
					{
						duration = 240;
					}
					Singleton<RecordServer>.GetInstance().RecordEndReq(this.savedReq, duration);
				}
			}
			catch (Exception ex)
			{
				if (this.mDungeonManager != null)
				{
					Logger.LogErrorFormat("_sendResult IsReplayRecord is corrupt! {0} record server is null {1} dungeon scene is null {2}", new object[]
					{
						ex.ToString(),
						Singleton<RecordServer>.GetInstance() == null,
						this.mDungeonManager.GetBeScene() == null
					});
				}
				else
				{
					Logger.LogErrorFormat("_sendResult IsReplayRecord is corrupt! {0} record server is null {1} dungeon is null {2}", new object[]
					{
						ex.ToString(),
						Singleton<RecordServer>.GetInstance() == null,
						this.mDungeonManager == null
					});
				}
				return;
			}
			try
			{
				if (this.savedReq == null)
				{
					if (this.mfinishBattle != null)
					{
						MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mfinishBattle);
					}
					Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
					this.mfinishBattle = null;
					this.alreadySendResult = true;
					return;
				}
				MonoSingleton<NetManager>.instance.SendCommand<RelaySvrEndGameReq>(ServerType.RELAY_SERVER, this.savedReq);
				if (Singleton<RecordServer>.instance != null)
				{
				}
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat("_sendResult savedReq is corrupt! {0} NetManager.instance is null {1} GameFrameWork is null {2}  ClientReconnectManager is null {3}", new object[]
				{
					ex2.ToString(),
					MonoSingleton<NetManager>.instance == null,
					MonoSingleton<GameFrameWork>.instance == null,
					Singleton<ClientReconnectManager>.instance == null
				});
				return;
			}
			try
			{
				Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
				if (BattleMain.instance != null)
				{
					BattleMain.instance.WaitForResult();
				}
				this.mfinishBattle = null;
				this.alreadySendResult = true;
			}
			catch (Exception ex3)
			{
				Logger.LogErrorFormat("_sendResult this point is corrupt reason {0}! or  ClientReconnectManager is null {1} BattleMain is null {2}", new object[]
				{
					ex3.ToString(),
					Singleton<ClientReconnectManager>.instance == null,
					BattleMain.instance == null
				});
			}
		}

		// Token: 0x060190F0 RID: 102640 RVA: 0x007D9FEC File Offset: 0x007D83EC
		protected override void _createPlayers()
		{
			int val = -1;
			BeScene beScene = this.mDungeonManager.GetBeScene();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer currentBattlePlayer = allPlayers[i];
				RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
				Dictionary<int, int> skillInfo = BattlePlayer.GetSkillInfo(playerInfo);
				List<ItemProperty> equips = BattlePlayer.GetEquips(playerInfo, true);
				List<ItemProperty> sideEquips = BattlePlayer.GetSideEquips(playerInfo, true);
				int weaponStrengthenLevel = BattlePlayer.GetWeaponStrengthenLevel(playerInfo);
				List<BuffInfoData> rankBuff = BattlePlayer.GetRankBuff(playerInfo);
				PetData petData = BattlePlayer.GetPetData(playerInfo, true);
				Dictionary<int, string> avatar = BattlePlayer.GetAvatar(playerInfo);
				List<Battle.DungeonBuff> buffList = BattlePlayer.GetBuffList(playerInfo);
				bool isLocalActor = playerInfo.accid == ClientApplication.playerinfo.accid;
				bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
				bool isAIRobot = playerInfo.robotAIType > 0;
				BeActor actor = beScene.CreateCharacter(isLocalActor, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, skillInfo, equips, (base.PkRaceType != 8) ? null : buffList, 0, string.Empty, weaponStrengthenLevel, rankBuff, petData, sideEquips, avatar, isShowWeapon, isAIRobot);
				actor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
				if (actor.GetEntityData() != null)
				{
					actor.GetEntityData().SetCrystalNum(BattlePlayer.GetCrsytalNum(playerInfo));
				}
				actor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
				allPlayers[i].playerActor = actor;
				VInt3 rkPos = new VInt3((i != 0) ? 40000 : -40000, 0, 0);
				actor.SetPosition(rkPos, true, true, false);
				actor.SetFace(i != 0, false, false);
				actor.m_iRemoveTime = GlobalLogic.VALUE_1000 * 120;
				actor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, false);
				if (i == 0)
				{
					actor.pkRestrainPosition = true;
					actor.pkRestrainRangeX = new VInt2(-4.4f, -3.6f);
				}
				else
				{
					actor.pkRestrainPosition = true;
					actor.pkRestrainRangeX = new VInt2(3.6f, 4.4f);
				}
				beScene.RegisterEvent(BeEventSceneType.onStartPK, delegate(object[] args)
				{
					actor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, true);
					actor.pkRestrainPosition = false;
				});
				if (Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					actor.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
					{
					});
				}
				else
				{
					actor.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
					{
						this._onPlayerDead(currentBattlePlayer);
					});
				}
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					actor.isLocalActor = true;
					actor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_PLAYER, playerInfo.level, null, 0f);
					actor.m_pkGeActor.CreatePKHPBar((i != 0) ? CPKHPBar.PKBarType.Right : CPKHPBar.PKBarType.Left, playerInfo.name, PlayerInfoColor.PK_PLAYER);
					actor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_PLAYER, string.Empty, null, 0, 0);
				}
				else
				{
					if (Singleton<ReplayServer>.GetInstance().IsReplay() && i == 0)
					{
						actor.isLocalActor = true;
					}
					actor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER, playerInfo.level, null, 0f);
					actor.m_pkGeActor.CreatePKHPBar((i != 0) ? CPKHPBar.PKBarType.Right : CPKHPBar.PKBarType.Left, playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER);
					actor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_OTHER_PLAYER, string.Empty, null, 0, 0);
					actor.m_pkGeActor.CreateFootIndicator(null);
				}
				if (actor.m_pkGeActor != null)
				{
					actor.m_pkGeActor.AddSimpleShadow(Vector3.one);
				}
				if (playerInfo.robotAIType > 0)
				{
					this.InitAIForRobot(actor, (int)playerInfo.robotAIType, (int)playerInfo.robotHard);
				}
				if (petData != null)
				{
					actor.SetPetData(petData);
				}
				actor.CreateFollowMonster();
				val = Math.Max(val, (int)playerInfo.level);
				actor.isMainActor = true;
				actor.UseProtect();
				actor.UseActorData();
			}
			for (int j = 0; j < allPlayers.Count; j++)
			{
				allPlayers[j].playerActor.UseAdjustBalance();
				BattlePlayer battlePlayer = allPlayers[(j != 0) ? 0 : 1];
				allPlayers[j].playerActor.GetEntityData().AdjustHPForPvP((int)allPlayers[j].playerInfo.level, (int)battlePlayer.playerInfo.level, (int)allPlayers[j].playerInfo.occupation, (int)battlePlayer.playerInfo.occupation, base.PkRaceType);
			}
			this._postCreatePlayer();
			this.mDungeonManager.GetGeScene().AttachCameraTo(this.mDungeonPlayers.GetMainPlayer().playerActor.m_pkGeActor);
		}

		// Token: 0x060190F1 RID: 102641 RVA: 0x007DA5B0 File Offset: 0x007D89B0
		public virtual void _postCreatePlayer()
		{
			if (Global.Settings.isDebug)
			{
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					BeActor playerActor = allPlayers[i].playerActor;
					if ((Global.Settings.playerHP > 0 && allPlayers[i] == mainPlayer) || (Global.Settings.monsterHP > 0 && allPlayers[i] != mainPlayer))
					{
						int num = 0;
						if (Global.Settings.playerHP > 0 && allPlayers[i] == mainPlayer)
						{
							num = Global.Settings.playerHP;
						}
						if (Global.Settings.monsterHP > 0 && allPlayers[i] != mainPlayer)
						{
							num = Global.Settings.monsterHP;
						}
						playerActor.GetEntityData().SetHP(num);
						playerActor.GetEntityData().SetMaxHP(num);
						playerActor.m_pkGeActor.ResetHPBar();
					}
				}
			}
		}

		// Token: 0x060190F2 RID: 102642 RVA: 0x007DA6BC File Offset: 0x007D8ABC
		protected sealed override bool _isBattleLoadFinish()
		{
			bool flag = true;
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			if (allPlayers != null)
			{
				for (int i = 0; i < allPlayers.Count; i++)
				{
					BattlePlayer battlePlayer = allPlayers[i];
					if (battlePlayer != null)
					{
						BeActor playerActor = battlePlayer.playerActor;
						if (playerActor != null && playerActor.m_pkGeActor != null)
						{
							flag = ((!flag) ? flag : playerActor.m_pkGeActor.IsAvatarLoadFinished());
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060190F3 RID: 102643 RVA: 0x007DA738 File Offset: 0x007D8B38
		private void InitAIForRobot(BeActor actor, int aiLevel, int matchNum = 0)
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

		// Token: 0x060190F4 RID: 102644 RVA: 0x007DA898 File Offset: 0x007D8C98
		[MessageHandle(506705U, false, 0)]
		private void _OnReceivePkEndData(MsgDATA msg)
		{
			SceneMatchPkRaceEnd sceneMatchPkRaceEnd = new SceneMatchPkRaceEnd();
			sceneMatchPkRaceEnd.decode(msg.bytes);
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().RecordResult(sceneMatchPkRaceEnd);
			}
			if (Singleton<RecordServer>.GetInstance() != null)
			{
			}
			BattleMain.instance.End();
			Singleton<ClientSystemManager>.instance.OpenFrame<PKBattleResultFrame>(FrameLayer.Middle, sceneMatchPkRaceEnd, string.Empty);
			if (Singleton<RecordServer>.GetInstance() != null)
			{
			}
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("PkEnd");
			}
		}

		// Token: 0x04011FAB RID: 73643
		protected bool alreadySendResult;

		// Token: 0x04011FAC RID: 73644
		private BeEventHandle handler;

		// Token: 0x04011FAD RID: 73645
		protected RelaySvrEndGameReq savedReq;

		// Token: 0x04011FAE RID: 73646
		private SimpleTimer2 gameTimer = new SimpleTimer2();

		// Token: 0x04011FAF RID: 73647
		public bool isReplay;

		// Token: 0x04011FB0 RID: 73648
		protected ePVPBattleEndType mEndType;

		// Token: 0x04011FB1 RID: 73649
		protected Coroutine mfinishBattle;
	}
}
