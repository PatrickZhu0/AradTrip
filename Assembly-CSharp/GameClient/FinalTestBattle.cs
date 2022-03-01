using System;
using System.Collections.Generic;
using Battle;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020045B1 RID: 17841
	public class FinalTestBattle : MouBattle
	{
		// Token: 0x06018F9C RID: 102300 RVA: 0x007DC564 File Offset: 0x007DA964
		public FinalTestBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
			this.tableData = Singleton<TableManager>.instance.GetFinalTestTime(id);
			if (this.tableData != null)
			{
				this.hpRecoverPercent = this.tableData.MaxhpRecover;
				this.mpRecoverPercent = this.tableData.MaxmpRecover;
				this.hpRecoverTotal = this.tableData.hpRecover;
				this.mpRecoverTotal = this.tableData.mpRecover;
				this.totalTime = this.tableData.limitTime * 1000;
			}
		}

		// Token: 0x06018F9D RID: 102301 RVA: 0x007DC63E File Offset: 0x007DAA3E
		protected override void _onPostStart()
		{
			base._onPostStart();
			this._showCurrentTips();
		}

		// Token: 0x06018F9E RID: 102302 RVA: 0x007DC64C File Offset: 0x007DAA4C
		public void SetBossInfo(uint bossID01, uint bossHp01, uint bossID02, uint bossHp02)
		{
			this.bossID01 = bossID01;
			this.bossHp01 = (int)bossHp01;
			this.bossID02 = bossID02;
			this.bossHp02 = (int)bossHp02;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(169092161U, new int[]
				{
					(int)bossID01,
					(int)bossHp01,
					(int)bossID02,
					(int)bossHp02
				});
			}
		}

		// Token: 0x06018F9F RID: 102303 RVA: 0x007DC6B8 File Offset: 0x007DAAB8
		public void SetBuffInfo(ZjslDungeonBuff[] playerBuffs)
		{
			this.mPlayerBuffers = playerBuffs;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				string text = string.Empty;
				if (playerBuffs != null)
				{
					for (int i = 0; i < playerBuffs.Length; i++)
					{
						text += string.Format("[buffId ({0}) lv ({1}) target({2})]", playerBuffs[i].buffId, playerBuffs[i].buffLvl, playerBuffs[i].buffTarget);
					}
				}
				base.recordServer.MarkString(185865282U, new string[]
				{
					text
				});
			}
		}

		// Token: 0x06018FA0 RID: 102304 RVA: 0x007DC75C File Offset: 0x007DAB5C
		protected override void _createPlayers()
		{
			base._createPlayers();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeEntityData entityData = allPlayers[i].playerActor.GetEntityData();
				if (allPlayers[i].playerInfo.remainHp != 0U)
				{
					float num = allPlayers[i].playerInfo.remainHp / (float)GlobalLogic.VALUE_100000;
					num = Mathf.Clamp01(num);
					float f = num * (float)entityData.GetMaxHP();
					entityData.SetHP(IntMath.Float2Int(f));
					allPlayers[i].playerActor.m_pkGeActor.SetHPValue(num);
				}
				if (allPlayers[i].playerInfo.remainMp != 0U)
				{
					float num2 = allPlayers[i].playerInfo.remainMp / (float)GlobalLogic.VALUE_1000;
					num2 = Mathf.Clamp01(num2);
					entityData.SetMP(IntMath.Float2Int(num2 * (float)entityData.GetMaxMP()));
					allPlayers[i].playerActor.m_pkGeActor.SetMpValue(num2);
				}
				allPlayers[i].playerActor.SetPosition(dungeonDataManager.CurrentBirthPosition(), false, true, false);
				if (this.mPlayerBuffers != null && allPlayers[i].playerActor.buffController != null)
				{
					for (int j = 0; j < this.mPlayerBuffers.Length; j++)
					{
						if (this.mPlayerBuffers[j] != null && this.mPlayerBuffers[j].buffTarget == 1U && this.mPlayerBuffers[j].buffId != 0U)
						{
							allPlayers[i].playerActor.buffController.TryAddBuff((int)this.mPlayerBuffers[j].buffId, 99999999, (int)this.mPlayerBuffers[j].buffLvl);
						}
					}
				}
				this.RecordRecoverData(allPlayers[i].playerActor);
				this.m_HandleNewList.Add(allPlayers[i].playerActor.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.ChangeEquipEnd)));
			}
			this.mDungeonManager.GetBeScene().InitFriendActor(dungeonDataManager.CurrentBirthPosition());
		}

		// Token: 0x06018FA1 RID: 102305 RVA: 0x007DC99C File Offset: 0x007DAD9C
		protected void ChangeEquipEnd(BeEvent.BeEventParam param)
		{
			BeActor beActor = param.m_Obj as BeActor;
			if (beActor == null)
			{
				return;
			}
			this.RecordRecoverData(beActor);
		}

		// Token: 0x06018FA2 RID: 102306 RVA: 0x007DC9C4 File Offset: 0x007DADC4
		protected void RecordRecoverData(BeActor actor)
		{
			if (actor == null)
			{
				return;
			}
			this.hpRecover = actor.attribute.battleData.fHpRecoer;
			this.mpRecover = actor.attribute.battleData.fMpRecover;
			actor.attribute.SetAttributeValue(AttributeType.hpRecover, 0, false);
			actor.GetEntityData().battleData.hpRecover = actor.GetEntityData().battleData.fHpRecoer;
			actor.attribute.SetAttributeValue(AttributeType.mpRecover, 0, false);
			actor.GetEntityData().battleData.mpRecover = actor.GetEntityData().battleData.fMpRecover;
		}

		// Token: 0x06018FA3 RID: 102307 RVA: 0x007DCA6A File Offset: 0x007DAE6A
		private void _showCurrentTips()
		{
			SystemNotifyManager.SysDungeonAnimation(string.Format("{0}", this.mDungeonManager.GetDungeonDataManager().table.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
			this.SetFloorName();
		}

		// Token: 0x06018FA4 RID: 102308 RVA: 0x007DCA98 File Offset: 0x007DAE98
		private void SetFloorName()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null && this.tableData != null)
			{
				clientSystemBattle.SetFloor(this.tableData.ID);
			}
		}

		// Token: 0x06018FA5 RID: 102309 RVA: 0x007DCAD8 File Offset: 0x007DAED8
		public override void FrameUpdate(int delta)
		{
			base.FrameUpdate(delta);
			if (this.mDungeonManager == null || this.mDungeonManager.GetBeScene() == null)
			{
				return;
			}
			if (this.startCountDown)
			{
				if (this.alreadySendResult || this.mDungeonManager.IsFinishFight() || this.mDungeonManager.GetBeScene().state == BeSceneState.onPause)
				{
					return;
				}
				this.UpdateTotalTime(delta);
				if (this.timeStop)
				{
					this._onTimeUp();
				}
			}
			else
			{
				this.UpdateTotalTime(0);
			}
		}

		// Token: 0x06018FA6 RID: 102310 RVA: 0x007DCB6C File Offset: 0x007DAF6C
		private void CountDown(int delta)
		{
			if (!this.flag)
			{
				this.timer += delta;
				if (this.timer >= this.countDown)
				{
					this.startCountDown = true;
					this.flag = true;
					this.timer = 0;
					this.SetAIState(false);
					this.HideSettingButton(false);
				}
			}
		}

		// Token: 0x06018FA7 RID: 102311 RVA: 0x007DCBC6 File Offset: 0x007DAFC6
		private void OpenFrame()
		{
			this.uiFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<GoblinKingdomFrame>(FrameLayer.Middle, null, string.Empty) as GoblinKingdomFrame);
			if (this.uiFrame != null)
			{
				this.uiFrame.SetRoom();
			}
		}

		// Token: 0x06018FA8 RID: 102312 RVA: 0x007DCBFC File Offset: 0x007DAFFC
		private void UpdateTotalTime(int deltaTime)
		{
			this.totalTime -= deltaTime;
			if (this.totalTime > 0)
			{
				if (this.uiFrame != null)
				{
					int num = this.totalTime / 60000;
					int num2 = this.totalTime % 60000 / 1000;
					int num3 = this.totalTime % 1000 / 10;
					string time = string.Format("{0}.{1:D2}.{2:D2}", num, num2, num3);
					if (this.uiFrame != null)
					{
						this.uiFrame.SetTime(time);
					}
				}
			}
			else
			{
				string time2 = string.Format("{0}.{1:D2}.{2:D2}", 0, 0, 0);
				if (this.uiFrame != null)
				{
					this.uiFrame.SetTime(time2);
				}
				this.timeStop = true;
			}
		}

		// Token: 0x06018FA9 RID: 102313 RVA: 0x007DCCD4 File Offset: 0x007DB0D4
		protected void _onTimeUp()
		{
			if (this.alreadySendResult)
			{
				return;
			}
			if (!this.mDungeonManager.GetBeScene()._isAllBossDead())
			{
				this.RaceFail();
			}
		}

		// Token: 0x06018FAA RID: 102314 RVA: 0x007DCD0A File Offset: 0x007DB10A
		protected override void _onEnd()
		{
			base._onEnd();
			this.RemoveHandle();
		}

		// Token: 0x06018FAB RID: 102315 RVA: 0x007DCD18 File Offset: 0x007DB118
		private void RecordBossDamage()
		{
			BeDungeon beDungeon = this.mDungeonManager as BeDungeon;
			if (beDungeon != null)
			{
				if (beDungeon.bossID01 != 0U)
				{
					this.bossDamage01 = beDungeon.bossDamage01;
				}
				if (beDungeon.bossID02 != 0U)
				{
					this.bossDamage02 = beDungeon.bossDamage02;
				}
				if (this.mDungeonManager.GetBeScene() != null)
				{
					int num = this.bossHp01;
					int num2 = this.bossHp02;
					BeEntity entityByPID = this.mDungeonManager.GetBeScene().GetEntityByPID(this.bossPID01);
					BeEntity entityByPID2 = this.mDungeonManager.GetBeScene().GetEntityByPID(this.bossPID02);
					if (entityByPID != null && !entityByPID.IsDead())
					{
						num = this.bossMaxHP01 * entityByPID.GetEntityData().GetHPRate();
						if (num < 0)
						{
							num = 0;
						}
					}
					else
					{
						num = 0;
					}
					if (entityByPID2 != null && !entityByPID2.IsDead())
					{
						num2 = this.bossMaxHP02 * entityByPID2.GetEntityData().GetHPRate();
						if (num2 < 0)
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 0;
					}
					this.bossHp01 = num;
					this.bossHp02 = num2;
				}
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					this.playerHPRate = this.GetHpRate(allPlayers[i].playerActor);
					this.playerMPRate = this.GetMpRate(allPlayers[i].playerActor);
				}
			}
		}

		// Token: 0x06018FAC RID: 102316 RVA: 0x007DCE90 File Offset: 0x007DB290
		private void RaceFail()
		{
			this.alreadySendResult = true;
			this.mDungeonManager.FinishFight();
			this.RecordBossDamage();
			this.SetBossInfo();
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._failEnd());
		}

		// Token: 0x06018FAD RID: 102317 RVA: 0x007DCEC4 File Offset: 0x007DB2C4
		private void SetBossInfo()
		{
			BeDungeon beDungeon = this.mDungeonManager as BeDungeon;
			if (beDungeon != null)
			{
				if (beDungeon.bossID01 != 0U)
				{
					BeActor beActor = beDungeon.GetBeScene().FindMonsterByID((int)beDungeon.bossID01);
					if (beActor != null)
					{
						this.bossInfo01 = new BossInfo();
						this.SetBossInfo(this.bossInfo01, beActor);
					}
				}
				if (beDungeon.bossID02 != 0U)
				{
					BeActor beActor2 = beDungeon.GetBeScene().FindMonsterByID((int)beDungeon.bossID02);
					if (beActor2 != null)
					{
						this.bossInfo02 = new BossInfo();
						this.SetBossInfo(this.bossInfo02, beActor2);
					}
				}
			}
		}

		// Token: 0x06018FAE RID: 102318 RVA: 0x007DCF5C File Offset: 0x007DB35C
		private void SetBossInfo(BossInfo bossInfo, BeActor monster)
		{
			if (monster != null)
			{
				GeActorEx.GeActorDesc actorDesc = monster.m_pkGeActor.m_ActorDesc;
				AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(actorDesc.portraitIconRes, typeof(Sprite), true, 0U);
				Sprite icon = assetInst.obj as Sprite;
				bossInfo.icon = icon;
				Material material = ETCImageLoader.LoadMaterialFromSpritePath(actorDesc.portraitIconRes, true);
				bossInfo.material = material;
				bossInfo.level = monster.GetEntityData().level;
				bossInfo.name = monster.GetEntityData().name;
				bossInfo.hpRate = monster.attribute.GetHPRate().single;
			}
		}

		// Token: 0x06018FAF RID: 102319 RVA: 0x007DD004 File Offset: 0x007DB404
		protected RelaySvrDungeonRaceEndReq getDungeonRaceEndTeamReq(bool isSuccess)
		{
			RelaySvrDungeonRaceEndReq relaySvrDungeonRaceEndReq = new RelaySvrDungeonRaceEndReq();
			relaySvrDungeonRaceEndReq.raceEndInfo.sessionId = ClientApplication.playerinfo.session;
			relaySvrDungeonRaceEndReq.raceEndInfo.dungeonId = (uint)this.mDungeonManager.GetDungeonDataManager().id.dungeonID;
			relaySvrDungeonRaceEndReq.raceEndInfo.usedTime = (uint)this.mDungeonStatistics.AllFightTime(true);
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			BeDungeon beDungeon = this.mDungeonManager as BeDungeon;
			if (beDungeon == null)
			{
				return null;
			}
			relaySvrDungeonRaceEndReq.raceEndInfo.infoes = new DungeonPlayerRaceEndInfo[allPlayers.Count];
			for (int i = 0; i < allPlayers.Count; i++)
			{
				RacePlayerInfo racePlayerInfo = allPlayers[i].playerInfo;
				DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo = new DungeonPlayerRaceEndInfo
				{
					roleId = racePlayerInfo.roleId,
					pos = racePlayerInfo.seat,
					score = (byte)beDungeon.FinalDungeonScore_New(),
					beHitCount = (ushort)this.mDungeonStatistics.HitCount(racePlayerInfo.seat),
					bossDamage = (ulong)this.mDungeonStatistics.GetBossDamage(racePlayerInfo.seat),
					boss1ID = this.bossID01,
					boss1RemainHp = (uint)this.bossHp01,
					boss2ID = this.bossID02,
					boss2RemainHp = (uint)this.bossHp02,
					playerRemainHp = this.playerHPRate,
					playerRemainMp = this.playerMPRate
				};
				if (!isSuccess)
				{
					dungeonPlayerRaceEndInfo.score = 0;
				}
				if (dungeonPlayerRaceEndInfo.score == 0 && ((this.bossID01 != 0U && this.bossHp01 == 0 && this.bossID02 != 0U && this.bossHp02 == 0) || (this.bossID01 != 0U && this.bossHp01 == 0 && this.bossID02 == 0U)))
				{
					Logger.LogErrorFormat("[FinalTestEndException] {0}", new object[]
					{
						(base.recordServer == null) ? "invalid" : base.recordServer.sessionID
					});
					BeUtility.SaveBattleRecord(this);
				}
				dungeonPlayerRaceEndInfo.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", dungeonPlayerRaceEndInfo.score, dungeonPlayerRaceEndInfo.beHitCount, relaySvrDungeonRaceEndReq.raceEndInfo.usedTime));
				relaySvrDungeonRaceEndReq.raceEndInfo.infoes[i] = dungeonPlayerRaceEndInfo;
			}
			return relaySvrDungeonRaceEndReq;
		}

		// Token: 0x06018FB0 RID: 102320 RVA: 0x007DD264 File Offset: 0x007DB664
		protected override void _createMonsters()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			BeDungeon beDungeon = this.mDungeonManager as BeDungeon;
			if (beDungeon == null)
			{
				return;
			}
			List<DungeonMonster> monsters = dungeonDataManager.CurrentMonsters();
			int thisRoomMonsterCreatedCount = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), true);
			for (int i = 0; i < beScene.GetPendingEntities().Count; i++)
			{
				BeEntity beEntity = beScene.GetPendingEntities()[i];
				if (beEntity.IsBoss())
				{
					int num = 0;
					uint monsterID = (uint)beEntity.GetEntityData().monsterID;
					if (this.bossID01 != 0U && this.bossID01 == monsterID)
					{
						beDungeon.bossID01 = monsterID;
						this.bossMaxHP01 = beEntity.attribute.GetMaxHP();
						this.bossPID01 = beEntity.GetPID();
						num = this.bossHp01;
					}
					else if (this.bossID02 != 0U && this.bossID02 == monsterID)
					{
						beDungeon.bossID02 = monsterID;
						this.bossMaxHP02 = beEntity.attribute.GetMaxHP();
						this.bossPID02 = beEntity.GetPID();
						num = this.bossHp02;
					}
					else if (this.bossID01 == 0U && beDungeon.bossID01 == 0U)
					{
						beDungeon.bossID01 = monsterID;
						num = beEntity.attribute.GetMaxHP();
						this.bossMaxHP01 = num;
						this.bossID01 = monsterID;
						this.bossHp01 = num;
						this.bossPID01 = beEntity.GetPID();
					}
					else if (this.bossID02 == 0U && beDungeon.bossID02 == 0U)
					{
						beDungeon.bossID02 = monsterID;
						this.bossID02 = monsterID;
						num = beEntity.attribute.GetMaxHP();
						this.bossHp02 = num;
						this.bossMaxHP02 = num;
						this.bossPID02 = beEntity.GetPID();
					}
					if (num != 0)
					{
						beEntity.attribute.SetHP(num);
						if (beEntity.m_pkGeActor != null)
						{
							beEntity.m_pkGeActor.isSyncHPMP = true;
							beEntity.m_pkGeActor.SyncHPBar();
							beEntity.m_pkGeActor.isSyncHPMP = false;
						}
					}
					else
					{
						beEntity.DoDead(false);
					}
					BeActor beActor = beEntity as BeActor;
					if (beActor != null && beActor.buffController != null && this.mPlayerBuffers != null)
					{
						for (int j = 0; j < this.mPlayerBuffers.Length; j++)
						{
							if (this.mPlayerBuffers[j] != null && this.mPlayerBuffers[j].buffTarget == 2U)
							{
								beActor.buffController.TryAddBuff((int)this.mPlayerBuffers[j].buffId, 99999999, (int)this.mPlayerBuffers[j].buffLvl);
							}
						}
					}
				}
			}
			beScene.RegisterEvent(BeEventSceneType.onBossDead, delegate(object[] args)
			{
				this.OnBossDead();
			});
			this.thisRoomMonsterCreatedCount = thisRoomMonsterCreatedCount;
		}

		// Token: 0x06018FB1 RID: 102321 RVA: 0x007DD54C File Offset: 0x007DB94C
		private void OnBossDead()
		{
			if (this.alreadySendResult || this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			base.FrameRandom.Range100();
			this.mIsSucc = true;
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				this.alreadySendResult = true;
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					if (allPlayers[i].playerActor.isMainActor)
					{
						allPlayers[i].playerActor.buffController.TryAddBuff(29, -1, 1);
					}
				}
				if (this.mDungeonManager.IsFinishFight())
				{
					return;
				}
				if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
				{
					List<BeEntity> saveTempList = this.mDungeonManager.GetBeScene().GetSaveTempList();
					if (saveTempList.Count > 0)
					{
						BeActor beActor = saveTempList[0] as BeActor;
						if (beActor != null && allPlayers.Count > 0)
						{
							allPlayers[0].playerActor = beActor;
						}
					}
					this.RecordBossDamage();
					this.SetPlayerInfo();
					base._sendDungeonKillMonsterReq();
					base._sendDungeonRewardReq();
					base._sendDungeonBossRewardReq();
					this.mDungeonManager.FinishFight();
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._successEnd());
				}
			}
		}

		// Token: 0x06018FB2 RID: 102322 RVA: 0x007DD6B4 File Offset: 0x007DBAB4
		private void SetPlayerInfo()
		{
			BeActor playerActor = BattleMain.instance.GetLocalPlayer(0UL).playerActor;
			this.playerInfo = new FinalPlayerInfo();
			if (this.hpRecover <= 0)
			{
				this.hpRecover = 0;
			}
			this.playerInfo.addHp = this.hpRecover * this.hpRecoverTotal + (int)((float)this.hpRecoverPercent / 1000f * (float)playerActor.GetEntityData().GetMaxHP());
			if (this.mpRecover <= 0)
			{
				this.mpRecover = 0;
			}
			this.playerInfo.addMp = this.mpRecover * this.mpRecoverTotal + (int)((float)this.mpRecoverPercent / 1000f * (float)playerActor.GetEntityData().GetMaxMP());
			this.playerInfo.hp = playerActor.GetEntityData().GetHP();
			this.playerInfo.mp = playerActor.GetEntityData().GetMP();
			this.playerInfo.maxHp = playerActor.GetEntityData().GetMaxHP();
			this.playerInfo.maxMp = playerActor.GetEntityData().GetMaxMP();
			GeActorEx.GeActorDesc actorDesc = playerActor.m_pkGeActor.m_ActorDesc;
			AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(actorDesc.portraitIconRes, typeof(Sprite), true, 0U);
			Sprite icon = assetInst.obj as Sprite;
			this.playerInfo.icon = icon;
			Material material = ETCImageLoader.LoadMaterialFromSpritePath(actorDesc.portraitIconRes, true);
			this.playerInfo.material = material;
			this.playerInfo.level = playerActor.GetEntityData().level;
			this.playerInfo.name = playerActor.GetEntityData().name;
		}

		// Token: 0x06018FB3 RID: 102323 RVA: 0x007DD853 File Offset: 0x007DBC53
		protected override void _onGameStartFrame(BattlePlayer player)
		{
			base._onGameStartFrame(player);
			this.OpenFrame();
		}

		// Token: 0x06018FB4 RID: 102324 RVA: 0x007DD862 File Offset: 0x007DBC62
		public void StartCountDown()
		{
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				this.SetAIState(true);
				this.flag = false;
			}
		}

		// Token: 0x06018FB5 RID: 102325 RVA: 0x007DD890 File Offset: 0x007DBC90
		private void SetAIState(bool pauseAI)
		{
			List<BeEntity> list = new List<BeEntity>();
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				this.mDungeonManager.GetBeScene().GetEntitys2(list);
				for (int i = 0; i < list.Count; i++)
				{
					BeActor beActor = list[i] as BeActor;
					if (beActor != null && !beActor.isMainActor)
					{
						beActor.pauseAI = pauseAI;
					}
				}
			}
		}

		// Token: 0x06018FB6 RID: 102326 RVA: 0x007DD90C File Offset: 0x007DBD0C
		private void HideSettingButton(bool hide)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.HidePauseButton(hide);
			}
			if (this.blackMask != null)
			{
				Object.Destroy(this.blackMask);
			}
		}

		// Token: 0x06018FB7 RID: 102327 RVA: 0x007DD954 File Offset: 0x007DBD54
		public void StartCountDownEffect()
		{
			this.HideSettingButton(true);
			this.blackMask = Object.Instantiate<GameObject>(MonoSingleton<LeanTween>.instance.frameBlackMask);
			if (this.blackMask != null)
			{
				Image component = this.blackMask.GetComponent<Image>();
				if (component != null)
				{
					component.color = new Color(0f, 0f, 0f, 0.2f);
				}
				Utility.AttachTo(this.blackMask, Singleton<ClientSystemManager>.instance.TopLayer, false);
			}
			GameObject gameObject = Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, "UIFlatten/Prefabs/Pk/StartFight", 0f);
		}

		// Token: 0x06018FB8 RID: 102328 RVA: 0x007DD9F1 File Offset: 0x007DBDF1
		protected override void _onSceneStart()
		{
			base._onSceneStart();
			this.mDungeonManager.GetBeScene().isUseBossShow = false;
		}

		// Token: 0x06018FB9 RID: 102329 RVA: 0x007DDA0C File Offset: 0x007DBE0C
		protected override void _onAreaClear(object[] args)
		{
			if (this.alreadySendResult || this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			this.mIsSucc = true;
			base._onAreaClear(args);
			if (this.mDungeonManager.GetDungeonDataManager() != null && this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this.alreadySendResult = true;
			}
		}

		// Token: 0x06018FBA RID: 102330 RVA: 0x007DDA7C File Offset: 0x007DBE7C
		protected override SceneDungeonRaceEndReq _getDungeonRaceEndReq()
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer == null || this.mDungeonManager.GetBeScene() == null)
			{
				return null;
			}
			BeDungeon beDungeon = this.mDungeonManager as BeDungeon;
			if (beDungeon == null)
			{
				return null;
			}
			uint lastFrame = 0U;
			uint lastChecksum = 0U;
			base.GetFinalFrameInfo(ref lastFrame, ref lastChecksum);
			SceneDungeonRaceEndReq sceneDungeonRaceEndReq = new SceneDungeonRaceEndReq
			{
				beHitCount = (ushort)this.mDungeonStatistics.HitCount(mainPlayer.playerInfo.seat),
				usedTime = (uint)this.mDungeonStatistics.AllFightTime(true),
				score = (byte)beDungeon.FinalDungeonScore_New(),
				maxDamage = this.mDungeonStatistics.GetAllMaxHurtDamage(),
				skillId = this.mDungeonStatistics.GetAllMaxHurtSkillID(),
				param = this.mDungeonStatistics.GetAllMaxHurtID(),
				totalDamage = this.mDungeonStatistics.GetAllHurtDamage(),
				playerRemainHp = this.playerHPRate,
				playerRemainMp = this.playerMPRate,
				lastFrame = lastFrame,
				lastChecksum = lastChecksum,
				boss1ID = this.bossID01,
				boss1RemainHp = (uint)this.bossHp01,
				boss2ID = this.bossID02,
				boss2RemainHp = (uint)this.bossHp02
			};
			if (this.timeStop)
			{
				sceneDungeonRaceEndReq.score = 0;
			}
			sceneDungeonRaceEndReq.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", sceneDungeonRaceEndReq.score, sceneDungeonRaceEndReq.beHitCount, sceneDungeonRaceEndReq.usedTime));
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x06018FBB RID: 102331 RVA: 0x007DDC10 File Offset: 0x007DC010
		private uint GetHpRate(BeActor actor)
		{
			if (!this.mIsSucc && actor.GetEntityData().GetHP() <= 0)
			{
				return 0U;
			}
			if (actor.GetEntityData().GetHP() < 0)
			{
				actor.GetEntityData().SetHP(0);
			}
			int num = this.hpRecover * this.hpRecoverTotal;
			num = ((num > 0) ? num : 0);
			int num2 = actor.GetEntityData().GetHP() + num + (int)((float)this.hpRecoverPercent / 1000f * (float)actor.GetEntityData().GetMaxHP());
			int maxHP = actor.GetEntityData().GetMaxHP();
			float num3 = (float)num2 / (float)maxHP;
			return (uint)(num3 * (float)GlobalLogic.VALUE_100000);
		}

		// Token: 0x06018FBC RID: 102332 RVA: 0x007DDCBC File Offset: 0x007DC0BC
		private uint GetMpRate(BeActor actor)
		{
			int num = this.mpRecover * this.mpRecoverTotal;
			num = ((num > 0) ? num : 0);
			int num2 = actor.GetEntityData().GetMP() + num + (int)((float)this.mpRecoverPercent / 1000f * (float)actor.GetEntityData().GetMaxMP());
			int maxMP = actor.GetEntityData().GetMaxMP();
			float num3 = (float)num2 / (float)maxMP;
			return (uint)(num3 * (float)GlobalLogic.VALUE_1000);
		}

		// Token: 0x06018FBD RID: 102333 RVA: 0x007DDD2B File Offset: 0x007DC12B
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
		}

		// Token: 0x06018FBE RID: 102334 RVA: 0x007DDD2D File Offset: 0x007DC12D
		protected override void _onPlayerDead(BattlePlayer player)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.GetBeScene() == null)
			{
				return;
			}
			if (this.alreadySendResult || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			this.RaceFail();
		}

		// Token: 0x06018FBF RID: 102335 RVA: 0x007DDD70 File Offset: 0x007DC170
		protected void RemoveHandle()
		{
			for (int i = 0; i < this.m_HandleNewList.Count; i++)
			{
				if (this.m_HandleNewList[i] != null)
				{
					this.m_HandleNewList[i].Remove();
					this.m_HandleNewList[i] = null;
				}
			}
		}

		// Token: 0x04011F0A RID: 73482
		private uint bossID01;

		// Token: 0x04011F0B RID: 73483
		private int bossHp01;

		// Token: 0x04011F0C RID: 73484
		private uint bossID02;

		// Token: 0x04011F0D RID: 73485
		private int bossHp02;

		// Token: 0x04011F0E RID: 73486
		private int bossMaxHP01;

		// Token: 0x04011F0F RID: 73487
		private int bossMaxHP02;

		// Token: 0x04011F10 RID: 73488
		private int bossPID01;

		// Token: 0x04011F11 RID: 73489
		private int bossPID02;

		// Token: 0x04011F12 RID: 73490
		private uint playerHPRate;

		// Token: 0x04011F13 RID: 73491
		private uint playerMPRate;

		// Token: 0x04011F14 RID: 73492
		private int bossDamage01;

		// Token: 0x04011F15 RID: 73493
		private int bossDamage02;

		// Token: 0x04011F16 RID: 73494
		private int currentIndex;

		// Token: 0x04011F17 RID: 73495
		protected bool alreadySendResult;

		// Token: 0x04011F18 RID: 73496
		protected bool mIsSucc;

		// Token: 0x04011F19 RID: 73497
		private ZjslDungeonBuff[] mPlayerBuffers;

		// Token: 0x04011F1A RID: 73498
		private int totalTime = 120000;

		// Token: 0x04011F1B RID: 73499
		private int countDown = 5000;

		// Token: 0x04011F1C RID: 73500
		public UltimateChallengeDungeonTable tableData;

		// Token: 0x04011F1D RID: 73501
		public BossInfo bossInfo01;

		// Token: 0x04011F1E RID: 73502
		public BossInfo bossInfo02;

		// Token: 0x04011F1F RID: 73503
		public FinalPlayerInfo playerInfo;

		// Token: 0x04011F20 RID: 73504
		private List<BeEvent.BeEventHandleNew> m_HandleNewList = new List<BeEvent.BeEventHandleNew>();

		// Token: 0x04011F21 RID: 73505
		private int hpRecover;

		// Token: 0x04011F22 RID: 73506
		private int mpRecover;

		// Token: 0x04011F23 RID: 73507
		private int hpRecoverTotal = 5;

		// Token: 0x04011F24 RID: 73508
		private int mpRecoverTotal = 5;

		// Token: 0x04011F25 RID: 73509
		private int hpRecoverPercent = 50;

		// Token: 0x04011F26 RID: 73510
		private int mpRecoverPercent = 50;

		// Token: 0x04011F27 RID: 73511
		private int timer;

		// Token: 0x04011F28 RID: 73512
		private bool flag = true;

		// Token: 0x04011F29 RID: 73513
		private bool startCountDown = true;

		// Token: 0x04011F2A RID: 73514
		private GoblinKingdomFrame uiFrame;

		// Token: 0x04011F2B RID: 73515
		private bool timeStop;

		// Token: 0x04011F2C RID: 73516
		private GameObject blackMask;
	}
}
