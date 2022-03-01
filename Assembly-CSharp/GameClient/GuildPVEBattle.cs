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
	// Token: 0x020045B2 RID: 17842
	public class GuildPVEBattle : PVEBattle
	{
		// Token: 0x06018FC1 RID: 102337 RVA: 0x007DDDD0 File Offset: 0x007DC1D0
		public GuildPVEBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
			this.mDungeonLvRecord = null;
			this.mIsCriticalElementDestroyed = false;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonLvlTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonLvlTable guildDungeonLvlTable = keyValuePair.Value as GuildDungeonLvlTable;
					if (guildDungeonLvlTable != null)
					{
						if (guildDungeonLvlTable.DungeonId == id)
						{
							this.mDungeonLvRecord = guildDungeonLvlTable;
							break;
						}
					}
				}
			}
		}

		// Token: 0x17002096 RID: 8342
		// (get) Token: 0x06018FC2 RID: 102338 RVA: 0x007DDE70 File Offset: 0x007DC270
		public GuildDungeonLvlTable ValidTable
		{
			get
			{
				return this.mDungeonLvRecord;
			}
		}

		// Token: 0x06018FC3 RID: 102339 RVA: 0x007DDE78 File Offset: 0x007DC278
		public void SetBossInfo(ulong curHP, ulong maxHP)
		{
			this.mInitBossHP = (int)curHP;
			this.mBossInfo.curHP = curHP;
			this.mBossInfo.maxHP = maxHP;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkString(185865280U, new string[]
				{
					curHP.ToString()
				});
			}
		}

		// Token: 0x06018FC4 RID: 102340 RVA: 0x007DDEE8 File Offset: 0x007DC2E8
		public void SetBuffInfo(Protocol.DungeonBuff[] playerBuffs)
		{
			this.mPlayerBuffers = playerBuffs;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				string text = string.Empty;
				if (playerBuffs != null)
				{
					for (int i = 0; i < playerBuffs.Length; i++)
					{
						text += string.Format("[buffId ({0}) lv ({1})]", playerBuffs[i].buffId, playerBuffs[i].buffLvl);
					}
				}
				base.recordServer.MarkString(185865344U, new string[]
				{
					text
				});
			}
		}

		// Token: 0x06018FC5 RID: 102341 RVA: 0x007DDF7C File Offset: 0x007DC37C
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> players = this.mDungeonPlayers.GetAllPlayers();
			VInt3 birthPosition = dungeonDataManager.GetBirthPosition();
			VInt3[] array = new VInt3[5];
			array[0] = birthPosition;
			int num = 1;
			for (int i = 1; i <= players.Count - 1; i++)
			{
				VInt3 vint = birthPosition;
				vint.x += BeAIManager.DIR_VALUE2[i - 1, 0] * VInt.one.i;
				vint.y += BeAIManager.DIR_VALUE2[i - 1, 1] * VInt.one.i;
				if (!beScene.IsInBlockPlayer(vint))
				{
					array[num++] = vint;
				}
			}
			for (int j = num; j <= players.Count - 1; j++)
			{
				array[j] = birthPosition;
			}
			for (int k = 0; k < players.Count; k++)
			{
				BattlePlayer battlePlayer = players[k];
				if (battlePlayer.playerActor == null)
				{
					RacePlayerInfo playerInfo = battlePlayer.playerInfo;
					PetData petData = BattlePlayer.GetPetData(playerInfo, false);
					bool isLocalActor = playerInfo.accid == ClientApplication.playerinfo.accid;
					bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
					bool isAIRobot = playerInfo.robotAIType > 0;
					BeActor beActor = beScene.CreateCharacter(isLocalActor, (int)playerInfo.occupation, (int)playerInfo.level, 0, BattlePlayer.GetSkillInfo(playerInfo), BattlePlayer.GetEquips(playerInfo, false), BattlePlayer.GetBuffList(playerInfo), (int)playerInfo.seat, playerInfo.name, BattlePlayer.GetWeaponStrengthenLevel(playerInfo), BattlePlayer.GetRankBuff(playerInfo), petData, BattlePlayer.GetSideEquips(playerInfo, false), BattlePlayer.GetAvatar(playerInfo), isShowWeapon, isAIRobot);
					beActor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
					beActor.SetScale(VInt.Float2VIntValue(Global.Settings.charScale));
					if (beActor.GetEntityData() != null)
					{
						beActor.GetEntityData().SetCrystalNum(BattlePlayer.GetCrsytalNum(playerInfo));
					}
					battlePlayer.playerActor = beActor;
					beActor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
					beActor.SetPosition(dungeonDataManager.GetBirthPosition(), true, true, false);
					beActor.isMainActor = true;
					beActor.UseProtect();
					beActor.m_iRemoveTime = int.MaxValue;
					if (this.mPlayerBuffers != null && beActor.buffController != null)
					{
						for (int l = 0; l < this.mPlayerBuffers.Length; l++)
						{
							if (this.mPlayerBuffers[l] != null)
							{
								beActor.buffController.TryAddBuff((int)this.mPlayerBuffers[l].buffId, 99999999, (int)this.mPlayerBuffers[l].buffLvl);
							}
						}
					}
					if (beActor.m_pkGeActor != null)
					{
						beActor.m_pkGeActor.AddSimpleShadow(Vector3.one);
					}
					if (playerInfo.accid == ClientApplication.playerinfo.accid)
					{
						beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.TOWN_PLAYER, playerInfo.level, null, 0f);
					}
					else
					{
						beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.LEVEL_PLAYER, playerInfo.level, null, 0f);
					}
					beActor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.LEVEL_PLAYER, string.Empty, null, 0, 0);
					if (playerInfo.accid == ClientApplication.playerinfo.accid)
					{
						this.mDungeonManager.GetGeScene().AttachCameraTo(beActor.m_pkGeActor);
						beActor.skillDamageManager.InitData(beScene);
						beActor.isLocalActor = true;
						beActor.UseActorData();
						beActor.m_pkGeActor.CreateFootIndicator("Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_guo");
					}
					else if (Singleton<GeGraphicSetting>.instance.IsLowLevel())
					{
						GeEffectManager effectManager = beActor.m_pkGeActor.GetEffectManager();
						if (effectManager != null)
						{
							effectManager.useCube = true;
						}
					}
					beActor.RegisterEvent(BeEventType.onAfterDead, delegate(object[] arsg)
					{
						if (battlePlayer.state != BattlePlayer.EState.Dead)
						{
							this._onPlayerDead(battlePlayer);
						}
						Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.PLAYER_DEAD, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Format("{0}, {1}", battlePlayer.playerInfo.roleId, battlePlayer.statistics.data.deadCount));
					});
					beActor.RegisterEvent(BeEventType.onDead, delegate(object[] arsg)
					{
						BattlePlayer battlePlayer;
						if (battlePlayer.state != BattlePlayer.EState.Dead)
						{
							if (!this.CanReborn())
							{
								return;
							}
							int num2 = 5;
							if (this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null && this.mDungeonManager.GetDungeonDataManager().table != null)
							{
								num2 = this.mDungeonManager.GetDungeonDataManager().table.RebornCount;
							}
							else
							{
								Logger.LogErrorFormat("GuildPVERebornCount can not fetched!", new object[0]);
							}
							bool flag = true;
							for (int m = 0; m < players.Count; m++)
							{
								battlePlayer = players[m];
								if (!battlePlayer.playerActor.IsDead())
								{
									flag = false;
									break;
								}
							}
							bool flag2 = true;
							if (flag)
							{
								for (int m = 0; m < players.Count; m++)
								{
									BattlePlayer battlePlayer2 = players[m];
									if (battlePlayer2.playerActor.dungeonRebornCount < num2)
									{
										battlePlayer2.playerActor.StartDeadProtect();
										flag2 = false;
									}
								}
								if (flag2)
								{
									this._CheckGuildFightEnd();
								}
							}
						}
					});
					beActor.RegisterEvent(BeEventType.onDeadProtectEnd, delegate(object[] args)
					{
						this._CheckGuildFightEnd();
					});
					beActor.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
					{
						this._onPlayerGuildReborn(battlePlayer);
						Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.PLAYER_REBORN, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Format("{0}, {1}", battlePlayer.playerInfo.roleId, battlePlayer.statistics.data.rebornCount));
					});
					beActor.RegisterEvent(BeEventType.onHit, delegate(object[] args)
					{
						if (args != null)
						{
							BeEntity beEntity = (BeEntity)args[2];
							if (beEntity != null && beEntity.m_iCamp != battlePlayer.playerActor.m_iCamp)
							{
								this._onPlayerHit(battlePlayer);
							}
						}
						else
						{
							this._onPlayerHit(battlePlayer);
						}
					});
					beActor.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
					{
						int skill = (int)args[0];
						this._onPlayerUseSkill(battlePlayer, skill);
					});
					base.SetAccompanyInfo(battlePlayer);
					if (petData != null)
					{
						beActor.SetPetData(petData);
					}
					beActor.CreateFollowMonster();
					base.InitAutoFight(beActor);
					this.ChangeActorAttribute(beActor);
					beActor.SetForceRunMode(false);
					if (Global.Settings.isDebug && Global.Settings.playerHP > 0)
					{
						beActor.GetEntityData().SetHP(Global.Settings.playerHP);
						beActor.GetEntityData().SetMaxHP(Global.Settings.playerHP);
						beActor.m_pkGeActor.ResetHPBar();
					}
				}
				else
				{
					battlePlayer.playerActor.ResetMoveCmd();
					if (battlePlayer.playerActor.actionManager != null)
					{
						battlePlayer.playerActor.actionManager.StopAll();
					}
				}
				battlePlayer.playerActor.SetPosition(array[k], true, true, false);
				beScene.InitFriendActor(dungeonDataManager.GetBirthPosition());
			}
		}

		// Token: 0x06018FC6 RID: 102342 RVA: 0x007DE594 File Offset: 0x007DC994
		protected override void _createMonsters()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> monsters = dungeonDataManager.CurrentMonsters();
			BeActor beActor = null;
			int thisRoomMonsterCreatedCount = 0;
			if (this.mDungeonLvRecord != null)
			{
				if (this.mDungeonLvRecord.dungeonLvl > 1)
				{
					thisRoomMonsterCreatedCount = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), ref beActor);
				}
				else
				{
					thisRoomMonsterCreatedCount = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), true);
				}
			}
			else
			{
				Logger.LogErrorFormat("DungeonId {0} can't find Record", new object[]
				{
					dungeonDataManager.id.dungeonID
				});
			}
			if (beActor != null)
			{
				beActor.attribute.SetHP(this.mInitBossHP);
				if (base.recordServer != null && base.recordServer.IsProcessRecord())
				{
					base.recordServer.Mark(12093320U, new int[]
					{
						this.mInitBossHP,
						beActor.m_iID,
						beActor.GetPosition().x,
						beActor.GetPosition().y,
						beActor.GetPosition().z,
						beActor.moveXSpeed.i,
						beActor.moveYSpeed.i,
						beActor.moveZSpeed.i,
						(!beActor.GetFace()) ? 0 : 1,
						beActor.attribute.GetHP(),
						beActor.attribute.GetMP(),
						beActor.GetAllStatTag(),
						beActor.attribute.battleData.attack.ToInt()
					}, new string[]
					{
						beActor.GetName()
					});
				}
				if (beActor.m_pkGeActor != null)
				{
					beActor.m_pkGeActor.isSyncHPMP = true;
					beActor.m_pkGeActor.SyncHPBar();
					beActor.m_pkGeActor.isSyncHPMP = false;
				}
			}
			this.thisRoomMonsterCreatedCount = thisRoomMonsterCreatedCount;
		}

		// Token: 0x06018FC7 RID: 102343 RVA: 0x007DE79D File Offset: 0x007DCB9D
		public override void OnCriticalElementDisappear()
		{
			this.mIsCriticalElementDestroyed = true;
			this._DoFightEnd(false, false);
		}

		// Token: 0x06018FC8 RID: 102344 RVA: 0x007DE7AE File Offset: 0x007DCBAE
		public override bool CanReborn()
		{
			return this.mDungeonLvRecord != null && this.mDungeonLvRecord.dungeonLvl > 1;
		}

		// Token: 0x06018FC9 RID: 102345 RVA: 0x007DE7D0 File Offset: 0x007DCBD0
		protected void _onPlayerGuildReborn(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(24614400U, new int[]
				{
					player.playerActor.m_iID
				});
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				battlePlayer.playerActor.EndDeadProtect();
			}
			byte seat = player.playerInfo.seat;
			byte seat2 = this.mDungeonPlayers.GetMainPlayer().playerInfo.seat;
			if (BattleMain.IsModeMultiplayer(base.GetMode()) && seat == seat2)
			{
				this.mDungeonManager.GetGeScene().AttachCameraTo(player.playerActor.m_pkGeActor);
			}
			player.state = BattlePlayer.EState.None;
			player.statistics.Reborn();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornSuccess, player.playerInfo.seat, null, null, null);
			if (seat2 == seat && Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRebornFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(null, false);
			}
			this._CheckGuildFightEnd();
		}

		// Token: 0x06018FCA RID: 102346 RVA: 0x007DE908 File Offset: 0x007DCD08
		private void _CheckGuildFightEnd()
		{
			if (this.mDungeonManager == null || this.mDungeonPlayers == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			if (this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			bool flag = true;
			bool flag2 = this.mDungeonManager.GetBeScene().isAllEnemyDead();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				if (!battlePlayer.playerActor.IsDead() || battlePlayer.playerActor.IsInDeadProtect)
				{
					flag = false;
				}
			}
			if (flag2 && this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				if (!flag)
				{
					this._DoFightEnd(true, false);
				}
				else
				{
					this._DoFightEnd(false, false);
				}
			}
			else if (flag)
			{
				this._DoFightEnd(false, false);
			}
		}

		// Token: 0x06018FCB RID: 102347 RVA: 0x007DE9FC File Offset: 0x007DCDFC
		protected override void _onPlayerDead(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(24614144U, new int[]
				{
					player.playerActor.m_iID
				});
			}
			base._playDungeonDead();
			player.state = BattlePlayer.EState.Dead;
			player.statistics.Dead();
			byte seat = player.playerInfo.seat;
			bool flag = this.CanReborn();
			if (flag)
			{
				player.playerActor.buffController.TryAddBuff(24, GlobalLogic.VALUE_10000, 1);
			}
			byte seat2 = this.mDungeonPlayers.GetMainPlayer().playerInfo.seat;
			if (seat == seat2 && BattleMain.IsModeMultiplayer(base.GetMode()))
			{
				BattlePlayer firstAlivePlayer = this.mDungeonPlayers.GetFirstAlivePlayer();
				if (firstAlivePlayer != null)
				{
					this.mDungeonManager.GetGeScene().AttachCameraTo(firstAlivePlayer.playerActor.m_pkGeActor);
				}
			}
			if (flag && (this.mDungeonPlayers.IsAllPlayerDead() || seat == seat2))
			{
				this._startPlayerDeadProcess(player);
			}
			if (!flag && this.mDungeonPlayers.IsAllPlayerDead())
			{
				this._DoFightEnd(false, false);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerDead, null, null, null, null);
		}

		// Token: 0x06018FCC RID: 102348 RVA: 0x007DEB41 File Offset: 0x007DCF41
		private void _startPlayerDeadProcess(BattlePlayer player)
		{
			this._stopPlayerDeadProcess();
			if (!this.mDungeonManager.IsFinishFight())
			{
				this.mDeadProcess = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._playerDeadProcess(player));
			}
		}

		// Token: 0x06018FCD RID: 102349 RVA: 0x007DEB70 File Offset: 0x007DCF70
		private void _stopPlayerDeadProcess()
		{
			if (this.mDeadProcess != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDeadProcess);
				this.mDeadProcess = null;
			}
		}

		// Token: 0x06018FCE RID: 102350 RVA: 0x007DEB94 File Offset: 0x007DCF94
		private IEnumerator _playerDeadProcess(BattlePlayer player)
		{
			if (player != null && player.IsLocalPlayer())
			{
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRebornFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(null, false);
				}
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonRebornFrame>(FrameLayer.Middle, null, string.Empty);
			}
			yield return Yielders.EndOfFrame;
			while (DungeonRebornFrame.sState == DungeonRebornFrame.eState.None)
			{
				yield return Yielders.EndOfFrame;
			}
			if (DungeonRebornFrame.sState == DungeonRebornFrame.eState.Cancel)
			{
				IFrameCommand cmd = FrameCommandFactory.CreateCommand(28U);
				if (FrameSync.instance != null)
				{
					FrameSync.instance.FireFrameCommand(cmd, false);
				}
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRebornFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(null, false);
				}
			}
			yield break;
		}

		// Token: 0x06018FCF RID: 102351 RVA: 0x007DEBAF File Offset: 0x007DCFAF
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (player != null && player.playerActor != null)
			{
				player.playerActor.EndDeadProtect();
			}
			this._CheckGuildFightEnd();
		}

		// Token: 0x06018FD0 RID: 102352 RVA: 0x007DEBF0 File Offset: 0x007DCFF0
		private ClientSystemBattle _getValidSystem()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.TargetSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				return clientSystemBattle;
			}
			return Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		}

		// Token: 0x06018FD1 RID: 102353 RVA: 0x007DEC26 File Offset: 0x007DD026
		public bool isNormalLevel()
		{
			return this.mDungeonLvRecord == null || this.mDungeonLvRecord.dungeonLvl <= 1;
		}

		// Token: 0x06018FD2 RID: 102354 RVA: 0x007DEC48 File Offset: 0x007DD048
		protected sealed override void _onStart()
		{
			base._onStart();
			if (!this.isNormalLevel())
			{
				if (this.mDungeonLvRecord != null)
				{
					UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(this.mDungeonLvRecord.bossId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.mBossInfo.bossName = tableItem.Name;
						ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							this.mBossInfo.iconPath = tableItem2.IconPath;
						}
					}
				}
				Singleton<ClientSystemManager>.instance.OpenFrame<GuildPVEBattleFrame>(FrameLayer.Middle, this.mBossInfo, string.Empty);
			}
		}

		// Token: 0x06018FD3 RID: 102355 RVA: 0x007DECF4 File Offset: 0x007DD0F4
		private void _DoFightEnd(bool isSuccess, bool isSync = false)
		{
			if (this.mDungeonManager == null || this.mDungeonPlayers == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			if (this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			base.FrameRandom.Range100();
			this.m_CanFinishFight = true;
			if (this.mDungeonLvRecord != null)
			{
				int dungeonLvl = this.mDungeonLvRecord.dungeonLvl;
				if (dungeonLvl != 1)
				{
					if (dungeonLvl == 2 || dungeonLvl == 3)
					{
						if (!isSuccess)
						{
							List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
							for (int i = 0; i < allPlayers.Count; i++)
							{
								RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
								uint bossDamage = this.mDungeonStatistics.GetBossDamage(playerInfo.seat);
								if (bossDamage > 0U)
								{
									isSuccess = true;
									break;
								}
							}
						}
					}
				}
			}
			if (isSuccess)
			{
				if (isSync)
				{
					this.mIsSyncSuccess = true;
				}
				base._sendDungeonKillMonsterReq();
				base._sendDungeonRewardReq();
				base._sendDungeonBossRewardReq();
				this._sendDungeonRaceEndReqByGuild();
			}
			else
			{
				this._sendDungeonRaceEndReqByGuild();
			}
			this.mDungeonManager.FinishFight();
		}

		// Token: 0x06018FD4 RID: 102356 RVA: 0x007DEE24 File Offset: 0x007DD224
		protected void _sendDungeonRaceEndReqByGuild()
		{
			if (base._isNeedSendNet())
			{
				if (base.GetMode() == eDungeonMode.SyncFrame)
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonTeamRaceEndReqIterByGuild(false, DungeonScore.C));
				}
				else
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonRaceEndReqIterByGuild(false, DungeonScore.C));
				}
			}
			else
			{
				SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes
				{
					result = 0U
				};
				this._onSceneDungeonRaceEndRes(res);
			}
			base.ClearBgm();
			base._playDungeonFinish();
		}

		// Token: 0x06018FD5 RID: 102357 RVA: 0x007DEE9C File Offset: 0x007DD29C
		private IEnumerator _sendDungeonTeamRaceEndReqIterByGuild(bool modifyScore = false, DungeonScore score = DungeonScore.C)
		{
			MessageEvents msgEvent = new MessageEvents();
			SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
			RelaySvrDungeonRaceEndReq req = this._getDungeonRaceEndTeamReq();
			if (modifyScore)
			{
				for (int i = 0; i < req.raceEndInfo.infoes.Length; i++)
				{
					req.raceEndInfo.infoes[i].score = (byte)score;
				}
			}
			BattleMain.instance.WaitForResult();
			yield return MessageUtility.Wait<RelaySvrDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.RELAY_SERVER, msgEvent, req, res, false, 20f);
			if (msgEvent.IsAllMessageReceived())
			{
				this._onSceneDungeonRaceEndRes(res);
			}
			yield break;
		}

		// Token: 0x06018FD6 RID: 102358 RVA: 0x007DEEC8 File Offset: 0x007DD2C8
		private IEnumerator _sendDungeonRaceEndReqIterByGuild(bool modifyScore = false, DungeonScore score = DungeonScore.C)
		{
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
			MessageEvents msgEvent = new MessageEvents();
			SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
			SceneDungeonRaceEndReq req = this._getDungeonRaceEndReqByGuild();
			if (req == null)
			{
				yield break;
			}
			if (modifyScore)
			{
				req.score = (byte)score;
			}
			yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msgEvent, req, res, true, 3f, 3, 33);
			if (msgEvent.IsAllMessageReceived())
			{
				this._onSceneDungeonRaceEndRes(res);
			}
			yield break;
		}

		// Token: 0x06018FD7 RID: 102359 RVA: 0x007DEEF4 File Offset: 0x007DD2F4
		protected SceneDungeonRaceEndReq _getDungeonRaceEndReqByGuild()
		{
			if (this.mDungeonPlayers == null || this.mDungeonStatistics == null)
			{
				return null;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			uint lastFrame = 0U;
			uint lastChecksum = 0U;
			base.GetFinalFrameInfo(ref lastFrame, ref lastChecksum);
			SceneDungeonRaceEndReq sceneDungeonRaceEndReq = new SceneDungeonRaceEndReq
			{
				beHitCount = (ushort)this.mDungeonStatistics.HitCount(mainPlayer.playerInfo.seat),
				usedTime = (uint)this.mDungeonStatistics.AllFightTime(true),
				score = (byte)this.GetFinalDungeonScore(),
				maxDamage = this.mDungeonStatistics.GetAllMaxHurtDamage(),
				skillId = this.mDungeonStatistics.GetAllMaxHurtSkillID(),
				param = this.mDungeonStatistics.GetAllMaxHurtID(),
				totalDamage = this.mDungeonStatistics.GetAllHurtDamage(),
				lastFrame = lastFrame,
				lastChecksum = lastChecksum,
				bossDamage = (ulong)((mainPlayer == null) ? this.mDungeonStatistics.GetTotalBossDamage() : this.mDungeonStatistics.GetBossDamage(mainPlayer.GetPlayerSeat()))
			};
			sceneDungeonRaceEndReq.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", sceneDungeonRaceEndReq.score, sceneDungeonRaceEndReq.beHitCount, sceneDungeonRaceEndReq.usedTime));
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x06018FD8 RID: 102360 RVA: 0x007DF03C File Offset: 0x007DD43C
		private RelaySvrDungeonRaceEndReq _getDungeonRaceEndTeamReq()
		{
			RelaySvrDungeonRaceEndReq relaySvrDungeonRaceEndReq = new RelaySvrDungeonRaceEndReq();
			relaySvrDungeonRaceEndReq.raceEndInfo.sessionId = ClientApplication.playerinfo.session;
			relaySvrDungeonRaceEndReq.raceEndInfo.dungeonId = (uint)this.mDungeonManager.GetDungeonDataManager().id.dungeonID;
			relaySvrDungeonRaceEndReq.raceEndInfo.usedTime = (uint)this.mDungeonStatistics.AllFightTime(true);
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			relaySvrDungeonRaceEndReq.raceEndInfo.infoes = new DungeonPlayerRaceEndInfo[allPlayers.Count];
			for (int i = 0; i < allPlayers.Count; i++)
			{
				RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
				DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo = new DungeonPlayerRaceEndInfo
				{
					roleId = playerInfo.roleId,
					pos = playerInfo.seat,
					score = (byte)this.GetFinalDungeonScore(),
					beHitCount = (ushort)this.mDungeonStatistics.HitCount(playerInfo.seat),
					bossDamage = (ulong)this.mDungeonStatistics.GetBossDamage(playerInfo.seat)
				};
				dungeonPlayerRaceEndInfo.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", dungeonPlayerRaceEndInfo.score, dungeonPlayerRaceEndInfo.beHitCount, relaySvrDungeonRaceEndReq.raceEndInfo.usedTime));
				relaySvrDungeonRaceEndReq.raceEndInfo.infoes[i] = dungeonPlayerRaceEndInfo;
			}
			return relaySvrDungeonRaceEndReq;
		}

		// Token: 0x06018FD9 RID: 102361 RVA: 0x007DF194 File Offset: 0x007DD594
		public DungeonScore GetFinalDungeonScore()
		{
			if (this.mDungeonLvRecord != null)
			{
				if (this.mDungeonStatistics == null)
				{
					Logger.LogErrorFormat("GetFinalDungeonScore mDungeonStatistics is null", new object[0]);
					return DungeonScore.C;
				}
				if (this.mDungeonLvRecord.dungeonLvl > 1)
				{
					if ((ulong)this.mDungeonStatistics.GetTotalBossDamage() >= (ulong)((long)this.mDungeonLvRecord.threeStarDamage))
					{
						return DungeonScore.SSS;
					}
					if ((ulong)this.mDungeonStatistics.GetTotalBossDamage() >= (ulong)((long)this.mDungeonLvRecord.twoStarDamage))
					{
						return DungeonScore.SS;
					}
					if ((ulong)this.mDungeonStatistics.GetTotalBossDamage() >= (ulong)((long)this.mDungeonLvRecord.oneStarDamage))
					{
						return DungeonScore.S;
					}
					if (this.mDungeonStatistics.GetTotalBossDamage() > 0U)
					{
						return DungeonScore.A;
					}
				}
				else if (!this.mIsCriticalElementDestroyed)
				{
					return this.mDungeonStatistics.FinalDungeonScore();
				}
			}
			if (this.mIsSyncSuccess)
			{
				return DungeonScore.A;
			}
			return DungeonScore.C;
		}

		// Token: 0x06018FDA RID: 102362 RVA: 0x007DF274 File Offset: 0x007DD674
		protected override void _onAreaClear(object[] args)
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.CloseLevelTip();
			}
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(2990895686U);
			}
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this._DoFightEnd(true, false);
			}
			else
			{
				if (this.thisRoomMonsterCreatedCount > 0)
				{
					SystemNotifyManager.SystemNotify(6000, string.Empty);
					MonoSingleton<AudioManager>.instance.PlaySound(5);
				}
				int num = this.mDungeonManager.GetDungeonDataManager().CurrentIndex();
				this.areaIndex = (1U << num | this.areaIndex);
				base._updateDungeonState(true);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DisplayMissionTips, null, null, null, null);
		}

		// Token: 0x06018FDB RID: 102363 RVA: 0x007DF348 File Offset: 0x007DD748
		protected sealed override void _onPlayerLeave(BattlePlayer player)
		{
			if (player != null)
			{
				player.netState = BattlePlayer.eNetState.Offline;
				if (base.recordServer != null && base.recordServer.IsProcessRecord())
				{
					base.recordServer.Mark(24614161U, new int[]
					{
						player.playerActor.m_iID
					}, new string[]
					{
						player.playerInfo.name
					});
				}
			}
			if (this.mDungeonPlayers.IsAllPlayerDead())
			{
				this._CheckGuildFightEnd();
			}
		}

		// Token: 0x06018FDC RID: 102364 RVA: 0x007DF3CC File Offset: 0x007DD7CC
		protected override void _onTeamCopyRaceEnd()
		{
			if (this.mDungeonManager != null && !this.mDungeonManager.IsFinishFight())
			{
				this._DoFightEnd(true, true);
				if (this.mDungeonManager.GetBeScene() != null)
				{
					this.mDungeonManager.GetBeScene().ClearAllMonsters();
				}
			}
		}

		// Token: 0x06018FDD RID: 102365 RVA: 0x007DF41C File Offset: 0x007DD81C
		[MessageHandle(608520U, false, 0)]
		private void _OnReceiveBattleEndData(MsgDATA msg)
		{
			if (base.dungeonManager == null || base.dungeonManager.GetDungeonDataManager() == null || base.dungeonManager.GetDungeonDataManager().id == null)
			{
				return;
			}
			WorldGuildDungeonEndNotify worldGuildDungeonEndNotify = new WorldGuildDungeonEndNotify();
			worldGuildDungeonEndNotify.decode(msg.bytes);
			if (worldGuildDungeonEndNotify.dungeonId == (uint)base.dungeonManager.GetDungeonDataManager().id.dungeonID)
			{
				TeamCopyRaceEnd cmd = new TeamCopyRaceEnd();
				FrameSync.instance.FireFrameCommand(cmd, true);
			}
		}

		// Token: 0x06018FDE RID: 102366 RVA: 0x007DF4A0 File Offset: 0x007DD8A0
		[MessageHandle(608521U, false, 0)]
		private void _OnReceiveBossBloodData(MsgDATA msg)
		{
			WorldGuildDungeonBossOddBlood worldGuildDungeonBossOddBlood = new WorldGuildDungeonBossOddBlood();
			worldGuildDungeonBossOddBlood.decode(msg.bytes);
			this.mBossInfo.curHP = worldGuildDungeonBossOddBlood.bossOddBlood;
			this.mBossInfo.maxHP = worldGuildDungeonBossOddBlood.bossTotalBlood;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBossHPRefresh, this.mBossInfo, null, null, null);
		}

		// Token: 0x04011F2D RID: 73517
		private int mInitBossHP = 1000;

		// Token: 0x04011F2E RID: 73518
		private Protocol.DungeonBuff[] mPlayerBuffers;

		// Token: 0x04011F2F RID: 73519
		private GuildDungeonLvlTable mDungeonLvRecord;

		// Token: 0x04011F30 RID: 73520
		private bool mIsCriticalElementDestroyed;

		// Token: 0x04011F31 RID: 73521
		private Coroutine mDeadProcess;

		// Token: 0x04011F32 RID: 73522
		private bool mIsSyncSuccess;

		// Token: 0x04011F33 RID: 73523
		private GuildPVEBattle.BossInfo mBossInfo = new GuildPVEBattle.BossInfo();

		// Token: 0x020045B3 RID: 17843
		public class BossInfo
		{
			// Token: 0x04011F34 RID: 73524
			public ulong curHP = 100UL;

			// Token: 0x04011F35 RID: 73525
			public ulong maxHP = 100UL;

			// Token: 0x04011F36 RID: 73526
			public string iconPath = string.Empty;

			// Token: 0x04011F37 RID: 73527
			public string bossName = string.Empty;
		}
	}
}
