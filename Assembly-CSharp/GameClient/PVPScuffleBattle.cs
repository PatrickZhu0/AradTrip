using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C1 RID: 17857
	public class PVPScuffleBattle : PVPBattle
	{
		// Token: 0x060190F6 RID: 102646 RVA: 0x007E76DC File Offset: 0x007E5ADC
		public PVPScuffleBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x060190F7 RID: 102647 RVA: 0x007E76E8 File Offset: 0x007E5AE8
		protected override void _createPlayers()
		{
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
				bool isLocalActor = playerInfo.accid == ClientApplication.playerinfo.accid;
				int teamType = (int)currentBattlePlayer.teamType;
				bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
				bool isAIRobot = playerInfo.robotAIType > 0;
				BeActor actor = beScene.CreateCharacter(isLocalActor, (int)playerInfo.occupation, (int)playerInfo.level, teamType, skillInfo, equips, null, 0, string.Empty, weaponStrengthenLevel, rankBuff, petData, sideEquips, avatar, isShowWeapon, isAIRobot);
				actor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
				if (actor == null || actor.m_pkGeActor == null)
				{
					return;
				}
				if (actor.GetEntityData() != null)
				{
					actor.GetEntityData().SetCrystalNum(BattlePlayer.GetCrsytalNum(playerInfo));
				}
				actor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
				allPlayers[i].playerActor = actor;
				actor.SetFace(teamType != 0, false, false);
				actor.m_iRemoveTime = GlobalLogic.VALUE_1000 * 240;
				actor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, false);
				actor.pkRestrainPosition = true;
				if (teamType == 0)
				{
					actor.pkRestrainRangeX = new VInt2(-6f, -3.6f);
				}
				else
				{
					actor.pkRestrainRangeX = new VInt2(3.6f, 6f);
				}
				beScene.RegisterEvent(BeEventSceneType.onStartPK, delegate(object[] args)
				{
					actor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, true);
				});
				actor.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
				{
					this._onPlayerDead(currentBattlePlayer);
				});
				actor.RegisterEvent(BeEventType.onKill, delegate(object[] args)
				{
					this.OnKill(currentBattlePlayer, args);
				});
				actor.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
				{
					this.OnSummon(currentBattlePlayer, args);
				});
				PlayerInfoColor playerInfoColor = (teamType != 1) ? PlayerInfoColor.PK_OTHER_PLAYER : PlayerInfoColor.PK_PLAYER;
				actor.m_pkGeActor.CreateInfoBar(playerInfo.name, playerInfoColor, playerInfo.level, null, 0f);
				actor.m_pkGeActor.CreatePKHPBar((teamType != 0) ? CPKHPBar.PKBarType.Right : CPKHPBar.PKBarType.Left, playerInfo.name, playerInfoColor);
				actor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, playerInfoColor, string.Empty, null, 0, 0);
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					actor.isLocalActor = true;
				}
				else if (Singleton<ReplayServer>.GetInstance().IsReplay() && i == 0)
				{
					actor.isLocalActor = true;
				}
				actor.m_pkGeActor.AddSimpleShadow(Vector3.one);
				if (petData != null)
				{
					actor.SetPetData(petData);
				}
				actor.CreateFollowMonster();
				actor.isMainActor = true;
				actor.UseProtect();
				actor.UseActorData();
			}
			for (int j = 0; j < allPlayers.Count; j++)
			{
				if (allPlayers[j].teamType == BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
				{
					allPlayers[j].playerActor.m_pkGeActor.CreateFootIndicator("Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_hong");
				}
				else
				{
					allPlayers[j].playerActor.m_pkGeActor.CreateFootIndicator("Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_lan");
				}
				allPlayers[j].playerActor.UseAdjustBalance();
				allPlayers[j].playerActor.GetEntityData().AdjustHPForScufflePVP((int)allPlayers[j].playerInfo.level, (int)allPlayers[j].playerInfo.occupation);
			}
			this._postCreatePlayer();
			this.SetActorPos(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			this.SetActorPos(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			this.mDungeonManager.GetGeScene().AttachCameraTo(this.mDungeonPlayers.GetMainPlayer().playerActor.m_pkGeActor);
		}

		// Token: 0x060190F8 RID: 102648 RVA: 0x007E7BAC File Offset: 0x007E5FAC
		private void SetActorPos(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> list = this.mDungeonPlayers.GetAllPlayers().FindAll((BattlePlayer x) => x.GetPlayerCamp() == (int)type);
			int count = list.Count;
			if (count != 1)
			{
				if (count != 2)
				{
					if (count == 3)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (i <= 1)
							{
								VInt3 rkPos = new VInt3((float)((type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed) ? 4 : -4), (float)(-2 + 4 * i), 0f);
								list[i].playerActor.SetPosition(rkPos, false, true, false);
							}
							else
							{
								VInt3 rkPos2 = new VInt3((float)((type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed) ? 6 : -6), 0f, 0f);
								list[i].playerActor.SetPosition(rkPos2, false, true, false);
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < list.Count; j++)
					{
						VInt3 rkPos3 = new VInt3((float)((type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed) ? 4 : -4), (float)(-2 + 4 * j), 0f);
						list[j].playerActor.SetPosition(rkPos3, false, true, false);
					}
				}
			}
			else
			{
				for (int k = 0; k < list.Count; k++)
				{
					VInt3 rkPos4 = new VInt3((float)((type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed) ? 4 : -4), 0f, 0f);
					list[k].playerActor.SetPosition(rkPos4, false, true, false);
				}
			}
		}

		// Token: 0x060190F9 RID: 102649 RVA: 0x007E7D64 File Offset: 0x007E6164
		protected override void _onEnd()
		{
			this._unbindNetMessage();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			string text = string.Empty;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					text = text + playerActor.GetName() + ";";
				}
			}
			Singleton<GameStatisticManager>.instance.DoStatFinishMeleeBattle(text);
		}

		// Token: 0x060190FA RID: 102650 RVA: 0x007E7DD0 File Offset: 0x007E61D0
		private void _bindNetMessage()
		{
			NetProcess.AddMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x060190FB RID: 102651 RVA: 0x007E7DE8 File Offset: 0x007E61E8
		private void _unbindNetMessage()
		{
			NetProcess.RemoveMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x060190FC RID: 102652 RVA: 0x007E7E00 File Offset: 0x007E6200
		private void _onSceneRoomMatchPkRaceEnd(MsgDATA data)
		{
			SceneRoomMatchPkRaceEnd sceneRoomMatchPkRaceEnd = new SceneRoomMatchPkRaceEnd();
			sceneRoomMatchPkRaceEnd.decode(data.bytes);
			this._convert2BattlePlayer(sceneRoomMatchPkRaceEnd);
			this._openDungeon3v3FinishFrame(sceneRoomMatchPkRaceEnd);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK2V2CrossScoreGetRaceEndResult, null, null, null, null);
		}

		// Token: 0x060190FD RID: 102653 RVA: 0x007E7E40 File Offset: 0x007E6240
		private void _convert2BattlePlayer(SceneRoomMatchPkRaceEnd res)
		{
			if (res == null)
			{
				Logger.LogErrorFormat("[战斗] [3v3] raceEnd 为空", new object[0]);
				return;
			}
			for (int i = 0; i < res.slotInfos.Length; i++)
			{
				RoomSlotBattleEndInfo roomSlotBattleEndInfo = res.slotInfos[i];
				if (roomSlotBattleEndInfo != null)
				{
					BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(roomSlotBattleEndInfo.seat);
					if (playerBySeat != null)
					{
						if (playerBySeat.IsLocalPlayer())
						{
							playerBySeat.ConvertSceneRoomMatchPkRaceEnd2LocalBattlePlayer(res);
						}
						playerBySeat.ConvertRoomSlotBattleEndInfo2BattlePlayer(roomSlotBattleEndInfo);
					}
				}
			}
		}

		// Token: 0x060190FE RID: 102654 RVA: 0x007E7ECC File Offset: 0x007E62CC
		private void _openDungeon3v3FinishFrame(SceneRoomMatchPkRaceEnd res)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_RACE_ID_CHECK))
				{
					if (ClientApplication.playerinfo != null && res.raceId != 0UL && res.raceId == ClientApplication.playerinfo.session)
					{
						Singleton<ClientSystemManager>.instance.OpenFrame<Dungeon3v3FinishFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
				else
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<Dungeon3v3FinishFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
		}

		// Token: 0x17002098 RID: 8344
		// (get) Token: 0x060190FF RID: 102655 RVA: 0x007E7F58 File Offset: 0x007E6358
		// (set) Token: 0x06019100 RID: 102656 RVA: 0x007E7F60 File Offset: 0x007E6360
		private PVPScuffleBattle.ePVP3V3ProcessStatus curPVP3V3ProcessStatus
		{
			get
			{
				return this.mCurPVP3V3ProcessStatus;
			}
			set
			{
				this.mCurPVP3V3ProcessStatus = value;
			}
		}

		// Token: 0x06019101 RID: 102657 RVA: 0x007E7F69 File Offset: 0x007E6369
		private bool _isTimeUp(int delta)
		{
			this.mTickTime -= delta;
			return !this._isTickTimeUp();
		}

		// Token: 0x06019102 RID: 102658 RVA: 0x007E7F82 File Offset: 0x007E6382
		private bool _isTickTimeUp()
		{
			return this.mTickTime <= 0;
		}

		// Token: 0x06019103 RID: 102659 RVA: 0x007E7F90 File Offset: 0x007E6390
		protected override void _onGameStartFrame(BattlePlayer player)
		{
			this.mPlayer = player;
			this.mTickTime = 2000;
			this.curPVP3V3ProcessStatus = PVPScuffleBattle.ePVP3V3ProcessStatus.WaitFirstVoteVSFlag;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3FinishVoteForFight, null, null, null, null);
		}

		// Token: 0x06019104 RID: 102660 RVA: 0x007E7FC0 File Offset: 0x007E63C0
		public override void FrameUpdate(int delta)
		{
			base.FrameUpdate(delta);
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.alreadySendResult)
			{
				return;
			}
			if (this._isTimeUp(delta) || base.IsTimeUp())
			{
				return;
			}
			PVPScuffleBattle.ePVP3V3ProcessStatus curPVP3V3ProcessStatus = this.curPVP3V3ProcessStatus;
			if (curPVP3V3ProcessStatus != PVPScuffleBattle.ePVP3V3ProcessStatus.None)
			{
				if (curPVP3V3ProcessStatus != PVPScuffleBattle.ePVP3V3ProcessStatus.WaitFirstVoteVSFlag)
				{
					if (curPVP3V3ProcessStatus == PVPScuffleBattle.ePVP3V3ProcessStatus.RoundStart)
					{
						this.curPVP3V3ProcessStatus = PVPScuffleBattle.ePVP3V3ProcessStatus.None;
						base._onGameStartFrame(this.mPlayer);
					}
				}
				else if (!this._isTimeUp(delta))
				{
					this.mTickTime = 0;
					this.curPVP3V3ProcessStatus = PVPScuffleBattle.ePVP3V3ProcessStatus.RoundStart;
				}
			}
		}

		// Token: 0x06019105 RID: 102661 RVA: 0x007E8070 File Offset: 0x007E6470
		protected override void _onStart()
		{
			base._onStart();
			this._bindNetMessage();
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetDungeonMapActive(false);
			}
		}

		// Token: 0x06019106 RID: 102662 RVA: 0x007E80A0 File Offset: 0x007E64A0
		private ClientSystemBattle _getValidSystem()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.TargetSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				return clientSystemBattle;
			}
			return Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		}

		// Token: 0x06019107 RID: 102663 RVA: 0x007E80D8 File Offset: 0x007E64D8
		protected override void _onPlayerDead(BattlePlayer player)
		{
			if (this.alreadySendResult)
			{
				return;
			}
			if (this.mDungeonManager == null || this.mDungeonPlayers == null)
			{
				return;
			}
			if (this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (player.playerActor != null)
			{
				player.playerActor.ClearProtect();
			}
			if (this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue) || this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType.eTeamRed))
			{
				this.mDungeonManager.FinishFight();
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					this._saveResult(ePVPBattleEndType.onAllEnemyDied);
					if (this.mfinishBattle != null)
					{
						return;
					}
					this.mfinishBattle = MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._FinishBattle(ePVPBattleEndType.onAllEnemyDied));
				}
			}
			if (player != null && player.playerActor != null)
			{
				player.playerActor.SetAttackButtonState(ButtonState.RELEASE, true);
			}
			List<BattlePlayer> list = BattleMain.instance.GetPlayerManager().GetAllPlayers().FindAll((BattlePlayer x) => x.GetPlayerCamp() == player.GetPlayerCamp() && !x.playerActor.IsDead());
			if (player.IsLocalPlayer())
			{
				if (list.Count > 0)
				{
					this.mDungeonManager.GetGeScene().AttachCameraTo(list[0].playerActor.m_pkGeActor);
				}
				base._unloadInputManger();
			}
		}

		// Token: 0x06019108 RID: 102664 RVA: 0x007E823D File Offset: 0x007E663D
		private void _LogicServerSendResult(ePVPBattleEndType a_eEndType)
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

		// Token: 0x06019109 RID: 102665 RVA: 0x007E8270 File Offset: 0x007E6670
		protected override void _saveResult(ePVPBattleEndType a_eEndType)
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
			bool flag = this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			bool flag2 = this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != null && allPlayers[i].playerInfo != null)
				{
					byte seat = allPlayers[i].playerInfo.seat;
					bool flag3 = allPlayers[i].IsTeamRed();
					PkPlayerRaceEndInfo pkPlayerRaceEndInfo = new PkPlayerRaceEndInfo
					{
						roleId = allPlayers[i].playerInfo.roleId,
						pos = seat,
						remainHp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetHPRate().single) * 1000f),
						remainMp = (uint)(Mathf.Max(0f, allPlayers[i].playerActor.GetEntityData().GetMPRate().single) * 1000f)
					};
					if (a_eEndType == ePVPBattleEndType.onTimeOut)
					{
						pkPlayerRaceEndInfo.result = 2;
					}
					else if (flag)
					{
						if (flag3)
						{
							pkPlayerRaceEndInfo.result = 1;
						}
						else
						{
							pkPlayerRaceEndInfo.result = 2;
						}
					}
					else if (flag3)
					{
						pkPlayerRaceEndInfo.result = 2;
					}
					else
					{
						pkPlayerRaceEndInfo.result = 1;
					}
					array[i] = pkPlayerRaceEndInfo;
				}
			}
			pkRaceEndInfo.infoes = array;
			pkRaceEndInfo.replayScore = base._getVideoScore(array);
			relaySvrEndGameReq.end = pkRaceEndInfo;
			this.savedReq = relaySvrEndGameReq;
		}

		// Token: 0x0601910A RID: 102666 RVA: 0x007E846C File Offset: 0x007E686C
		protected override void _onTimeUp()
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
				this.mfinishBattle = MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._FinishBattle(ePVPBattleEndType.onTimeOut));
			}
		}

		// Token: 0x0601910B RID: 102667 RVA: 0x007E84C0 File Offset: 0x007E68C0
		private void OnKill(BattlePlayer player, object[] args)
		{
			BeEntity beEntity = args[0] as BeEntity;
			if (beEntity != null)
			{
				BeActor beActor = beEntity as BeActor;
				if (beActor != null && beActor.isMainActor)
				{
					player.statistics.killPlayers++;
				}
			}
		}

		// Token: 0x0601910C RID: 102668 RVA: 0x007E8508 File Offset: 0x007E6908
		private void OnSummon(BattlePlayer player, object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.GetEntityData().isSummonMonster)
			{
				beActor.RegisterEvent(BeEventType.onKill, delegate(object[] obj)
				{
					BeEntity beEntity = obj[0] as BeEntity;
					if (beEntity != null)
					{
						BeActor beActor2 = beEntity as BeActor;
						if (beActor2 != null && beActor2.isMainActor)
						{
							player.statistics.killPlayers++;
						}
					}
				});
			}
		}

		// Token: 0x0601910D RID: 102669 RVA: 0x007E8558 File Offset: 0x007E6958
		protected override PKResult _getPKResulte(byte seat, ePVPBattleEndType a_eEndType)
		{
			BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
			if (a_eEndType == ePVPBattleEndType.onTimeOut)
			{
				return PKResult.LOSE;
			}
			if (a_eEndType != ePVPBattleEndType.onAllEnemyDied)
			{
				return PKResult.INVALID;
			}
			if (playerBySeat.playerActor.IsDead())
			{
				return PKResult.LOSE;
			}
			return PKResult.WIN;
		}

		// Token: 0x0601910E RID: 102670 RVA: 0x007E8598 File Offset: 0x007E6998
		protected override void _ShowResultEffect(ePVPBattleEndType a_eEndType)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<Dungeon3v3FinishFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0601910F RID: 102671 RVA: 0x007E85D0 File Offset: 0x007E69D0
		public PKResult GetRaceEndResult(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (this.mEndType == ePVPBattleEndType.onTimeOut)
			{
				return PKResult.LOSE;
			}
			if (this.mDungeonPlayers.IsTeamPlayerAllDead(type) && !this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.GetTargetTeamType(type)))
			{
				return PKResult.LOSE;
			}
			if (!this.mDungeonPlayers.IsTeamPlayerAllDead(type) && this.mDungeonPlayers.IsTeamPlayerAllDead(BattlePlayer.GetTargetTeamType(type)))
			{
				return PKResult.WIN;
			}
			return PKResult.DRAW;
		}

		// Token: 0x04011FB3 RID: 73651
		private PVPScuffleBattle.ePVP3V3ProcessStatus mCurPVP3V3ProcessStatus;

		// Token: 0x04011FB4 RID: 73652
		private int mTickTime;

		// Token: 0x04011FB5 RID: 73653
		private BattlePlayer mPlayer;

		// Token: 0x020045C2 RID: 17858
		private enum ePVP3V3ProcessStatus
		{
			// Token: 0x04011FB7 RID: 73655
			None,
			// Token: 0x04011FB8 RID: 73656
			WaitFirstVoteVSFlag,
			// Token: 0x04011FB9 RID: 73657
			RoundStart
		}
	}
}
