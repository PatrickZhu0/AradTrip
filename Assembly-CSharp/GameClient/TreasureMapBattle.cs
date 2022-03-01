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
	// Token: 0x020045E0 RID: 17888
	public class TreasureMapBattle : BaseBattle
	{
		// Token: 0x06019255 RID: 102997 RVA: 0x007F09B4 File Offset: 0x007EEDB4
		public TreasureMapBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06019256 RID: 102998 RVA: 0x007F0A1D File Offset: 0x007EEE1D
		public void AddRegionIdLibary(int id)
		{
			if (!this.mRegionIdLibrary.Contains(id))
			{
				this.mRegionIdLibrary.Add(id);
				this.mCurRegionIdLibary.Add(id);
			}
		}

		// Token: 0x06019257 RID: 102999 RVA: 0x007F0A48 File Offset: 0x007EEE48
		public void AddReduceIdLibary(int id)
		{
			if (!this.mReduceRegionIds.Contains(id))
			{
				this.mReduceRegionIds.Add(id);
				this.mCurReduceRegionIds.Add(id);
			}
		}

		// Token: 0x06019258 RID: 103000 RVA: 0x007F0A74 File Offset: 0x007EEE74
		public void GenerateRegion(VInt3 pos)
		{
			if (this.mDropItemCount <= this.mCurReduceRegionIds.Count && this.mCurReduceRegionIds.Count > 0)
			{
				int resId = this.mCurReduceRegionIds[this.mCurReduceRegionIds.Count - 1];
				this.mCurReduceRegionIds.RemoveAt(this.mCurReduceRegionIds.Count - 1);
				this.AddRegionInfo(resId, pos);
				this.mDropItemCount--;
			}
			else if (this.mCurRegionIdLibary.Count > 0)
			{
				int index = base.FrameRandom.InRange(0, this.mCurRegionIdLibary.Count);
				int num = this.mCurRegionIdLibary[index];
				if (this.mCurReduceRegionIds.Contains(num))
				{
					this.mCurRegionIdLibary.RemoveAt(index);
					this.mCurReduceRegionIds.Remove(num);
				}
				this.AddRegionInfo(num, pos);
				this.mDropItemCount--;
			}
		}

		// Token: 0x06019259 RID: 103001 RVA: 0x007F0B6A File Offset: 0x007EEF6A
		protected sealed override void _onStart()
		{
			this.GetChapterPassed();
			this._updateDungeonMap();
		}

		// Token: 0x0601925A RID: 103002 RVA: 0x007F0B78 File Offset: 0x007EEF78
		private void _updateDungeonMap()
		{
			TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
			if (treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null && this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null)
			{
				treasureMapFrame.TreasureDungeonMap.SetDungeonData(this.mDungeonManager.GetDungeonDataManager().asset);
			}
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null && clientSystemBattle.dungeonMapCom != null)
			{
				clientSystemBattle.dungeonMapCom.InitTreasureMapDungeonUI();
			}
		}

		// Token: 0x0601925B RID: 103003 RVA: 0x007F0C02 File Offset: 0x007EF002
		private void GetChapterPassed()
		{
			this.mIsChapterNoPassed = ComCommonChapterInfo._isAllDiffNoScores(base.dungeonManager.GetDungeonDataManager().id.dungeonID);
		}

		// Token: 0x0601925C RID: 103004 RVA: 0x007F0C24 File Offset: 0x007EF024
		public override void OnAfterSeedInited()
		{
			if (base.dungeonManager != null && base.dungeonManager.GetDungeonDataManager() != null)
			{
				this.mInitSeed = base.FrameRandom.GetSeed();
				base.dungeonManager.GetDungeonDataManager().OnInitDungeonData(base.FrameRandom);
				base.dungeonManager.GetDungeonDataManager().GetBossRoom(ref this.mBossX, ref this.mBossY, ref this.mBossIndex);
				base.dungeonManager.GetDungeonDataManager().GetEndRoom(ref this.mEndX, ref this.mEndY);
				this.mDropItemCount = base.dungeonManager.GetDungeonDataManager().GetRoomCountByType(6);
			}
		}

		// Token: 0x0601925D RID: 103005 RVA: 0x007F0CC8 File Offset: 0x007EF0C8
		public static TreasureMapGenerator.POS_TYPE GetPosType(int x, int y)
		{
			if (x == 0 && y == 0)
			{
				return TreasureMapGenerator.POS_TYPE.LEFT_TOP_CORNER;
			}
			if (y == (int)(TreasureMapGenerator.MAX_ROW - 1) && x == 0)
			{
				return TreasureMapGenerator.POS_TYPE.LEFT_BOTTOM_CORNER;
			}
			if (y == 0 && x == (int)(TreasureMapGenerator.MAX_COL - 1))
			{
				return TreasureMapGenerator.POS_TYPE.RIGHT_TOP_CORNER;
			}
			if (x == (int)(TreasureMapGenerator.MAX_COL - 1) && y == (int)(TreasureMapGenerator.MAX_ROW - 1))
			{
				return TreasureMapGenerator.POS_TYPE.RIGHT_BOTTOM_CORNER;
			}
			if (y == 0)
			{
				return TreasureMapGenerator.POS_TYPE.TOP_CORNER;
			}
			if (y == (int)(TreasureMapGenerator.MAX_ROW - 1))
			{
				return TreasureMapGenerator.POS_TYPE.BOTTOM_CORNER;
			}
			if (x == 0)
			{
				return TreasureMapGenerator.POS_TYPE.LEFT_CORNER;
			}
			if (x == (int)(TreasureMapGenerator.MAX_COL - 1))
			{
				return TreasureMapGenerator.POS_TYPE.RIGHT_CORNER;
			}
			return TreasureMapGenerator.POS_TYPE.NORMAL;
		}

		// Token: 0x0601925E RID: 103006 RVA: 0x007F0D58 File Offset: 0x007EF158
		public bool IsInBossRoom()
		{
			DungeonDataManager dungeonDataManager = base.dungeonManager.GetDungeonDataManager();
			if (dungeonDataManager != null)
			{
				IDungeonConnectData dungeonConnectData = dungeonDataManager.CurrentDataConnect();
				if (dungeonConnectData == null)
				{
					return false;
				}
				if (dungeonConnectData.GetPositionX() == this.mBossX && dungeonConnectData.GetPositionY() == this.mBossY)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601925F RID: 103007 RVA: 0x007F0DAC File Offset: 0x007EF1AC
		public void AddRegionInfo(int resId, VInt3 pos)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null || this.mDungeonManager.GetBeScene() == null)
			{
				return;
			}
			this.mGlobalRegionIdGen++;
			CustomSceneRegionInfo regionInfo = new CustomSceneRegionInfo(resId, pos, this.mGlobalRegionIdGen);
			this.mDungeonManager.GetDungeonDataManager().AddDynamicRegion(regionInfo);
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<int> regions = dungeonDataManager.CurrentDynamicRegions();
			beScene.CreateDynamicRegion(new BeRegionBase.TriggerTarget(this._doorTriggerAllPlayers), regionInfo, regions);
		}

		// Token: 0x06019260 RID: 103008 RVA: 0x007F0E48 File Offset: 0x007EF248
		public bool IsInEndRoom()
		{
			DungeonDataManager dungeonDataManager = base.dungeonManager.GetDungeonDataManager();
			if (dungeonDataManager != null)
			{
				IDungeonConnectData dungeonConnectData = dungeonDataManager.CurrentDataConnect();
				if (dungeonConnectData == null)
				{
					return false;
				}
				if (dungeonConnectData.GetPositionX() == this.mEndX && dungeonConnectData.GetPositionY() == this.mEndY)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06019261 RID: 103009 RVA: 0x007F0E9C File Offset: 0x007EF29C
		public void OnBossFleeAway(BeActor boss)
		{
			this._MoveBoss();
			if (boss != null && !boss.IsDead())
			{
				this.mCurBossHP = boss.attribute.GetHP();
			}
			TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
			if (treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
			{
				treasureMapFrame.TreasureDungeonMap.RefreshBoss(this.mBossX, this.mBossY, this.IsNearBoss());
			}
		}

		// Token: 0x06019262 RID: 103010 RVA: 0x007F0F0C File Offset: 0x007EF30C
		public bool IsNearBoss()
		{
			if (this.mIsBossDead)
			{
				return false;
			}
			DungeonDataManager dungeonDataManager = base.dungeonManager.GetDungeonDataManager();
			if (dungeonDataManager != null)
			{
				IDungeonConnectData dungeonConnectData = dungeonDataManager.CurrentDataConnect();
				if (dungeonConnectData == null)
				{
					return false;
				}
				if (dungeonConnectData.GetPositionX() == this.mBossX && dungeonConnectData.GetPositionY() == this.mBossY)
				{
					return false;
				}
				TreasureMapGenerator.POS_TYPE posType = TreasureMapBattle.GetPosType(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
				if (TreasureMapBattle.crossLinkDir.ContainsKey((int)posType))
				{
					List<int[]> list = TreasureMapBattle.crossLinkDir[(int)posType];
					for (int i = 0; i < list.Count; i++)
					{
						int[] array = list[i];
						int num = dungeonConnectData.GetPositionX() + array[0];
						int num2 = dungeonConnectData.GetPositionY() + array[1];
						if (num == this.mBossX && num2 == this.mBossY)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06019263 RID: 103011 RVA: 0x007F0FF8 File Offset: 0x007EF3F8
		private void _MoveBoss()
		{
			DungeonDataManager dungeonDataManager = base.dungeonManager.GetDungeonDataManager();
			if (dungeonDataManager == null)
			{
				return;
			}
			int num = this.mBossX;
			int num2 = this.mBossY;
			int num3 = 0;
			int num4 = 0;
			int num5 = -1;
			if (dungeonDataManager.GenBossNextRoom(this.mBossIndex, base.FrameRandom, ref num3, ref num4, ref num5))
			{
				this.mBossX = num3;
				this.mBossY = num4;
				this.mBossIndex = num5;
				return;
			}
			Logger.LogErrorFormat("GenBossNextRoom failed :{0} {1} {2} {3}", new object[]
			{
				this.mBossIndex,
				this.mBossX,
				this.mBossY,
				this.mInitSeed
			});
			TreasureMapGenerator.POS_TYPE posType = TreasureMapBattle.GetPosType(this.mBossX, this.mBossY);
			bool flag = false;
			if (TreasureMapBattle.linkDir.ContainsKey((int)posType))
			{
				List<int[]> list = TreasureMapBattle.linkDir[(int)posType];
				int index = base.FrameRandom.InRange(0, list.Count);
				int[] array = list[index];
				num3 = this.mBossX + array[0];
				num4 = this.mBossY + array[1];
				int num6 = list.Count;
				while (dungeonDataManager != null && num6 > 0)
				{
					if ((num3 != this.mEndX || num4 != this.mEndY) && dungeonDataManager.CanWalkToRoom(this.mBossX, this.mBossY, num3, num4, ref num5))
					{
						flag = true;
						this.mBossX = num3;
						this.mBossY = num4;
						this.mBossIndex = num5;
						break;
					}
					index = list.Count - num6;
					array = list[index];
					num3 = this.mBossX + array[0];
					num4 = this.mBossY + array[1];
					num6--;
				}
			}
			if (!flag)
			{
				Logger.LogErrorFormat("Boss Can not Move at {0} {1} Type {2} End {3} {4} Seed {5}", new object[]
				{
					this.mBossX,
					this.mBossY,
					posType,
					this.mEndX,
					this.mEndY,
					this.mInitSeed
				});
			}
			else
			{
				Logger.LogErrorFormat("Boss from  {0} {1} to {2} {3} shiftDoor {4}", new object[]
				{
					num,
					num2,
					this.mBossX,
					this.mBossY,
					this.mDoorShiftCount
				});
			}
		}

		// Token: 0x06019264 RID: 103012 RVA: 0x007F1278 File Offset: 0x007EF678
		private ClientSystemBattle _getValidSystem()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.TargetSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				return clientSystemBattle;
			}
			return Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		}

		// Token: 0x06019265 RID: 103013 RVA: 0x007F12AE File Offset: 0x007EF6AE
		private TreasureMapFrame _getValidTreasureMapFrame()
		{
			if (this.treasureMapFrame == null)
			{
				this.treasureMapFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<TreasureMapFrame>(FrameLayer.Middle, null, string.Empty) as TreasureMapFrame);
			}
			return this.treasureMapFrame;
		}

		// Token: 0x06019266 RID: 103014 RVA: 0x007F12E0 File Offset: 0x007EF6E0
		protected sealed override void _createEntitys()
		{
			base._createEntitys();
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				BeActor beActor = beScene.FindAPendingMonster();
				if (beActor != null)
				{
					bool face = beActor.GetFace();
					List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
					if (allPlayers != null)
					{
						int count = allPlayers.Count;
						for (int i = 0; i < count; i++)
						{
							BeActor playerActor = allPlayers[i].playerActor;
							if (playerActor != null)
							{
								bool bFace = beActor.GetPosition().x - playerActor.GetPosition().x <= 0;
								playerActor.SetFace(bFace, false, false);
							}
						}
					}
				}
			}
			if (this.mStarted)
			{
				ClientSystemBattle clientSystemBattle = this._getValidSystem();
				if (clientSystemBattle != null)
				{
					clientSystemBattle.ShowLevelTip(this.mDungeonManager.GetBeScene().sceneData.GetTipsID());
				}
			}
		}

		// Token: 0x06019267 RID: 103015 RVA: 0x007F13D0 File Offset: 0x007EF7D0
		protected sealed override void _onEnd()
		{
			this.mStarted = false;
			this._clearBossData();
			if (this.mDungeonRaceEndReqCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDungeonRaceEndReqCoroutine);
			}
		}

		// Token: 0x06019268 RID: 103016 RVA: 0x007F13FC File Offset: 0x007EF7FC
		protected sealed override void _createDoors()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonDoor> list = dungeonDataManager.CurrentDoors();
			TransportDoorType chanceDoorType = beScene.GetChanceDoorType();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].door != null)
				{
					beScene.AddTransportDoor(list[i].door.GetRegionInfo(), new BeRegionBase.TriggerTarget(this._doorTriggerAllPlayers), new BeRegionBase.TriggerRegion(this._doorCallback), list[i].isconnectwithboss, list[i].isvisited, list[i].doorType, list[i].isEggDoor);
				}
			}
		}

		// Token: 0x06019269 RID: 103017 RVA: 0x007F14C4 File Offset: 0x007EF8C4
		protected void _resetPlayerActor(bool force = true)
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					if (force)
					{
						playerActor.sgSwitchStates(new BeStateData(0, 0));
					}
					else
					{
						playerActor.sgPushState(new BeStateData(0, 0));
					}
					playerActor.Reset();
					playerActor.SetAttackButtonState(ButtonState.RELEASE, true);
				}
			}
		}

		// Token: 0x0601926A RID: 103018 RVA: 0x007F153C File Offset: 0x007EF93C
		protected void _changeAreaFade(uint fadein, uint fadeout, DungeonFadeCallback cb, DungeonFadeCallback finishcb = null)
		{
			this.mDungeonManager.OpenFade(delegate
			{
				if (FrameSync.instance != null)
				{
					FrameSync.instance.ResetMove();
					FrameSync.instance.isFire = false;
				}
				this._resetPlayerActor(false);
				InputManager.isForceLock = true;
			}, cb, delegate
			{
				if (finishcb != null)
				{
					finishcb();
				}
				if (FrameSync.instance != null)
				{
					FrameSync.instance.isFire = true;
				}
				InputManager.isForceLock = false;
				ClientSystemBattle clientSystemBattle = this._getValidSystem();
				if (clientSystemBattle != null && clientSystemBattle.comShowHit != null)
				{
					clientSystemBattle.comShowHit.ClearHitNumber();
				}
			}, fadein, fadeout);
		}

		// Token: 0x0601926B RID: 103019 RVA: 0x007F1584 File Offset: 0x007EF984
		private void DoSpecialGCClear(bool clearKey = false)
		{
			if (this.mDungeonManager.GetDungeonDataManager().table != null && this.mDungeonManager.GetDungeonDataManager().table.NeedForceGC)
			{
				if (clearKey)
				{
					MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(MonoSingleton<CResPreloader>.instance.priorityGameObjectKeys, false);
				}
				else
				{
					MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
				}
			}
		}

		// Token: 0x0601926C RID: 103020 RVA: 0x007F15EC File Offset: 0x007EF9EC
		protected override void _onCreateScene(object[] args)
		{
			this._updateDungeonState(false);
		}

		// Token: 0x0601926D RID: 103021 RVA: 0x007F15F5 File Offset: 0x007EF9F5
		protected override void _onDoorStateChange(object[] args)
		{
			this._updateDungeonState((bool)args[0]);
		}

		// Token: 0x0601926E RID: 103022 RVA: 0x007F1608 File Offset: 0x007EFA08
		protected void _updateDungeonState(bool isOpen)
		{
			TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
			if (treasureMapFrame != null)
			{
				IDungeonConnectData dungeonConnectData = this.mDungeonManager.GetDungeonDataManager().CurrentDataConnect();
				if (dungeonConnectData == null)
				{
					return;
				}
				if (treasureMapFrame.TreasureDungeonMap != null)
				{
					treasureMapFrame.TreasureDungeonMap.SetStartPosition(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
					if (isOpen)
					{
						treasureMapFrame.TreasureDungeonMap.SetOpenPosition(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
					}
					treasureMapFrame.TreasureDungeonMap.SetViewPortData(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
				}
			}
		}

		// Token: 0x0601926F RID: 103023 RVA: 0x007F1698 File Offset: 0x007EFA98
		private bool _doorCallback(ISceneRegionInfoData info, BeRegionTarget target)
		{
			this.mStartPassDoor = (int)Time.realtimeSinceStartup;
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight() || this.mDungeonManager.GetBeScene() == null || this.mDungeonManager.GetBeScene().state >= BeSceneState.onBulletTime)
			{
				return false;
			}
			bool result = true;
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				BeActor beActor = beScene.FindMonsterByID(12550031);
				if (beActor != null)
				{
					beActor.buffController.TryAddBuff(29, -1, 1);
				}
			}
			ISceneTransportDoorData door = info as ISceneTransportDoorData;
			if (door != null)
			{
				this._changeAreaFade(600U, 300U, delegate
				{
					MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(MonoSingleton<CResPreloader>.instance.priorityGameObjectKeys, true);
					if (Singleton<RecordServer>.instance != null)
					{
						Singleton<RecordServer>.instance.FlushProcess();
					}
					this._clearBossData();
					List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
					for (int i = 0; i < allPlayers.Count; i++)
					{
						allPlayers[i].playerActor.TriggerEvent(BeEventType.OnBeforePassDoor, null);
					}
					if (this.mDungeonManager.GetDungeonDataManager().NextArea(door.GetDoortype()))
					{
						for (int j = 0; j < allPlayers.Count; j++)
						{
							allPlayers[j].playerActor.TriggerEvent(BeEventType.onStartPassDoor, null);
						}
						SystemNotifyManager.ClearDungeonSkillTip();
						if (this.recordServer != null && this.recordServer.IsProcessRecord())
						{
							this.recordServer.MarkString(58295574U, new string[]
							{
								door.GetDoortype().ToString(),
								door.GetNextdoortype().ToString(),
								this.mDungeonManager.GetDungeonDataManager().CurrentScenePath()
							});
						}
						this.mDoorShiftCount++;
						this._createBase();
						this._createEntitys();
						this.PreloadMonster();
						this._onSceneStart();
						this.mDungeonManager.StartFight(false);
					}
				}, delegate
				{
					if (this.mLevelMgr != null)
					{
						this.mLevelMgr.PassedDoor();
					}
					List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
					for (int i = 0; i < allPlayers.Count; i++)
					{
						allPlayers[i].playerActor.ShowTransport(false);
						allPlayers[i].playerActor.TriggerEvent(BeEventType.onPassedDoor, null);
						if (allPlayers[i].playerActor.pet != null)
						{
							allPlayers[i].playerActor.SetPetAlongside();
						}
						BeActor playerActor = allPlayers[i].playerActor;
						if (playerActor.aiManager != null && playerActor.aiManager.isAutoFight)
						{
							playerActor.aiManager.StopCurrentCommand();
							if (playerActor != null && playerActor.IsProcessRecord())
							{
								playerActor.GetRecordServer().MarkInt(53048598U, new int[]
								{
									playerActor.GetPID()
								});
							}
						}
					}
					this._showActivityMonsterTips();
					if (this.IsInEndRoom())
					{
						beScene.onEnterEndRoom();
					}
				});
			}
			return result;
		}

		// Token: 0x06019270 RID: 103024 RVA: 0x007F1788 File Offset: 0x007EFB88
		private void _showActivityMonsterTips()
		{
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> list = dungeonDataManager.CurrentMonsters();
			for (int i = 0; i < list.Count; i++)
			{
				DungeonMonster dungeonMonster = list[i];
				if (dungeonMonster != null)
				{
					string text = string.Empty;
					MonsterID monsterID = new MonsterID
					{
						resID = dungeonMonster.typeId,
						monsterLevel = 0
					};
					UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(monsterID.resID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						text = tableItem.Name;
					}
					if (!string.IsNullOrEmpty(text))
					{
						DEntityType monsterType = dungeonMonster.monsterType;
						if (monsterType != DEntityType.ACTIVITY_BOSS_POS)
						{
							if (monsterType == DEntityType.ACTIVITY_ELITE_POS)
							{
								SystemNotifyManager.SystemNotify(1280, text);
							}
						}
						else
						{
							SystemNotifyManager.SystemNotify(1281, text);
						}
					}
				}
			}
		}

		// Token: 0x06019271 RID: 103025 RVA: 0x007F1874 File Offset: 0x007EFC74
		protected List<BattlePlayer> _doorTriggerAllPlayers()
		{
			if (this.mDungeonPlayers != null)
			{
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				this.mCachBeActor.Clear();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					this.mCachBeActor.Add(allPlayers[i]);
				}
			}
			return this.mCachBeActor;
		}

		// Token: 0x06019272 RID: 103026 RVA: 0x007F18D4 File Offset: 0x007EFCD4
		protected sealed override void _createMonsters()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> monsters = dungeonDataManager.CurrentMonsters();
			int num = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), false);
			this.mThisRoomMonsterCreatedCount = num;
			bool flag = !this.mIsBossDead && !this.IsInBossRoom() && this.mDoorShiftCount != 0;
			if (flag)
			{
				if (this.mFirstShiftDoor)
				{
					if (this.mDoorShiftCount > 5)
					{
						this.mFirstShiftDoor = false;
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = ((this.mDoorShiftCount - 6) % 2 == 0);
				}
			}
			if (flag)
			{
				this._MoveBoss();
			}
			TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
			if (treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
			{
				if (this.mIsBossDead)
				{
					treasureMapFrame.TreasureDungeonMap.RefreshBoss(-1, -1, this.IsNearBoss());
				}
				else
				{
					treasureMapFrame.TreasureDungeonMap.RefreshBoss(this.mBossX, this.mBossY, this.IsNearBoss());
				}
			}
			if (this.IsInEndRoom() || this.mIsBossDead)
			{
				if (this.mThisRoomMonsterCreatedCount <= 0)
				{
					beScene.ClearEventAndState();
				}
				return;
			}
			if (this.IsInBossRoom())
			{
				BeActor beActor = beScene.CreateMonster(this.mBossId, false, null, 0, -1, null, false);
				if (beActor == null)
				{
					Logger.LogErrorFormat("Can not create boss {0}", new object[]
					{
						this.mBossId
					});
					return;
				}
				if (this.mCurBossHP < 0)
				{
					this.mCurBossHP = beActor.attribute.GetHP();
				}
				else
				{
					beActor.attribute.SetHP(this.mCurBossHP);
					if (beActor.m_pkGeActor != null)
					{
						beActor.m_pkGeActor.isSyncHPMP = true;
						beActor.m_pkGeActor.SyncHPBar();
						beActor.m_pkGeActor.isSyncHPMP = false;
					}
				}
				this.mBossEventHandle = beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onBossDead));
				ISceneData sceneData = dungeonDataManager.CurrentSceneData();
				if (sceneData != null && sceneData.GetBirthPosition() != null)
				{
					VInt3 rkPos = new VInt3(sceneData.GetBirthPosition().GetPosition());
					beActor.SetPosition(rkPos, true, true, false);
					ClientSystemBattle clientSystemBattle = this._getValidSystem();
					if (clientSystemBattle != null)
					{
						clientSystemBattle.ShowTreasureBossWarning();
					}
				}
			}
			else if (this.mThisRoomMonsterCreatedCount <= 0)
			{
				beScene.ClearEventAndState();
			}
		}

		// Token: 0x06019273 RID: 103027 RVA: 0x007F1B5D File Offset: 0x007EFF5D
		private void _clearBossData()
		{
			if (this.mBossEventHandle != null)
			{
				this.mBossEventHandle.Remove();
				this.mBossEventHandle = null;
			}
		}

		// Token: 0x06019274 RID: 103028 RVA: 0x007F1B7C File Offset: 0x007EFF7C
		private void onBossDead(object[] args)
		{
			this.mIsBossDead = true;
			this.mCurBossHP = -1;
			TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
			if (treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
			{
				treasureMapFrame.TreasureDungeonMap.RefreshBoss(-1, -1, this.IsNearBoss());
			}
			this._clearBossData();
		}

		// Token: 0x06019275 RID: 103029 RVA: 0x007F1BD0 File Offset: 0x007EFFD0
		protected sealed override void _createDestructs()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> destructs = dungeonDataManager.CurrentDestructs();
			beScene.CreateDestructList2(destructs);
		}

		// Token: 0x06019276 RID: 103030 RVA: 0x007F1C04 File Offset: 0x007F0004
		protected sealed override void _createRegions()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<int> regions = dungeonDataManager.CurrentRegions();
			List<CustomSceneRegionInfo> list = dungeonDataManager.CurrentDynamicRegionInfoes();
			List<int> regions2 = dungeonDataManager.CurrentDynamicRegions();
			if (beScene != null)
			{
				beScene.CreateRegions(new BeRegionBase.TriggerTarget(this._doorTriggerAllPlayers), regions);
				for (int i = 0; i < list.Count; i++)
				{
					beScene.CreateDynamicRegion(new BeRegionBase.TriggerTarget(this._doorTriggerAllPlayers), list[i], regions2);
				}
			}
		}

		// Token: 0x06019277 RID: 103031 RVA: 0x007F1C90 File Offset: 0x007F0090
		protected sealed override void _createPlayers()
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
			int num2 = 0;
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
					num2 += (int)playerInfo.level;
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
					beActor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
					{
						BeBuff beBuff = args[0] as BeBuff;
						TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
						if (beBuff != null && beBuff.buffID == 570206 && treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
						{
							treasureMapFrame.TreasureDungeonMap.OpenAllRoom();
						}
						if (beBuff != null && treasureMapFrame != null && treasureMapFrame.TreasureMapBuff != null)
						{
							treasureMapFrame.TreasureMapBuff.HideLock(beBuff.buffID);
						}
						if (beBuff != null && treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
						{
							if (beBuff.buffID == 570205)
							{
								treasureMapFrame.TreasureDungeonMap.ClearCurrentRoomSpecialTag(TreasureMapGenerator.ROOM_TYPE.KEY_ROOM);
							}
							if (beBuff.buffID == 570206)
							{
								treasureMapFrame.TreasureDungeonMap.ClearCurrentRoomSpecialTag(TreasureMapGenerator.ROOM_TYPE.MAP_ROOM);
							}
						}
					});
					beScene.RegisterEvent(BeEventSceneType.onMonsterDead, delegate(object[] args)
					{
						if (args.Length > 0)
						{
							BeActor beActor2 = args[0] as BeActor;
							if (beActor2 != null && beActor2.GetEntityData().MonsterIDEqual(12540011))
							{
								TreasureMapFrame treasureMapFrame = this._getValidTreasureMapFrame();
								if (treasureMapFrame != null && treasureMapFrame.TreasureDungeonMap != null)
								{
									treasureMapFrame.TreasureDungeonMap.ClearCurrentRoomSpecialTag(TreasureMapGenerator.ROOM_TYPE.DROPITEM_ROOM);
								}
							}
						}
					});
					beActor.RegisterEvent(BeEventType.onDeadProtectEnd, delegate(object[] args)
					{
						this._CheckFightEnd();
					});
					beActor.RegisterEvent(BeEventType.onDead, delegate(object[] arsg)
					{
						BattlePlayer battlePlayer;
						if (battlePlayer.state != BattlePlayer.EState.Dead)
						{
							bool flag = true;
							for (int l = 0; l < players.Count; l++)
							{
								battlePlayer = players[l];
								if (!battlePlayer.playerActor.IsDead())
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								for (int l = 0; l < players.Count; l++)
								{
									BattlePlayer battlePlayer2 = players[l];
									battlePlayer2.playerActor.StartDeadProtect();
								}
							}
						}
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
					beActor.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
					{
						if (args != null)
						{
							int skillID = (int)args[2];
							int id = 0;
							if (args.Length >= 5)
							{
								id = (int)args[4];
							}
							this._onPlayerHitOther(skillID, id);
						}
					});
					beActor.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
					{
						this._onPlayerReborn(battlePlayer);
						Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.PLAYER_REBORN, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Format("{0}, {1}", battlePlayer.playerInfo.roleId, battlePlayer.statistics.data.rebornCount));
					});
					if (petData != null)
					{
						beActor.SetPetData(petData);
					}
					beActor.CreateFollowMonster();
					this.InitAutoFight(beActor);
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
			if (num2 > 0 && players.Count > 0)
			{
				MonsterIDData monsterIDData = new MonsterIDData(12530031);
				this.mBossId = monsterIDData.GenMonsterID(num2 / players.Count);
			}
		}

		// Token: 0x06019278 RID: 103032 RVA: 0x007F228C File Offset: 0x007F068C
		protected void InitAutoFight(BeActor actor)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(actor.attribute.professtion, string.Empty, string.Empty);
			if (tableItem != null)
			{
				actor.InitAutoFight(tableItem.AIConfig1, tableItem.AIConfig2, tableItem.AIConfig3, 0, 0, 0, 0, true);
			}
		}

		// Token: 0x06019279 RID: 103033 RVA: 0x007F22DC File Offset: 0x007F06DC
		protected virtual void _onPlayerHit(BattlePlayer player)
		{
			player.statistics.OnHit();
		}

		// Token: 0x0601927A RID: 103034 RVA: 0x007F22E9 File Offset: 0x007F06E9
		protected virtual void _onPlayerHitOther(int skillID, int id)
		{
			if (this.playerHitCallBack != null)
			{
				this.playerHitCallBack(skillID, id);
			}
		}

		// Token: 0x0601927B RID: 103035 RVA: 0x007F2304 File Offset: 0x007F0704
		protected virtual void _onPlayerReborn(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(52000022U, new int[]
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
			this._CheckFightEnd();
		}

		// Token: 0x0601927C RID: 103036 RVA: 0x007F243C File Offset: 0x007F083C
		protected void _CheckFightEnd()
		{
			if (this.mDungeonManager == null || this.mDungeonPlayers == null)
			{
				return;
			}
			if (this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			bool flag = true;
			byte seat = this.mDungeonPlayers.GetMainPlayer().playerInfo.seat;
			bool flag2 = this.mDungeonManager.GetBeScene().isAllEnemyDead();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				if (!battlePlayer.playerActor.IsDead() || battlePlayer.playerActor.IsInDeadProtect)
				{
					flag = false;
					break;
				}
			}
			if (flag2 && this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this._sendDungeonRaceEndReq(false);
			}
			else if (flag)
			{
				this._sendDungeonRaceEndReq(true);
			}
			if ((flag2 && this.mDungeonManager.GetDungeonDataManager().IsBossArea()) || flag)
			{
				this.mDungeonManager.FinishFight();
			}
		}

		// Token: 0x0601927D RID: 103037 RVA: 0x007F2554 File Offset: 0x007F0954
		protected void _sendDungeonRaceEndReq(bool dead = false)
		{
			this.mIsNormalFinsh = !dead;
			if (base._isNeedSendNet())
			{
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRebornFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(null, false);
				}
				if (base.GetMode() == eDungeonMode.SyncFrame)
				{
					if (!dead)
					{
						this.mDungeonRaceEndReqCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonTeamRaceEndReqIter(false, DungeonScore.C));
					}
					else if (this.mDungeonPlayers.IsAllPlayerDead())
					{
						Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
						this.mDungeonRaceEndReqCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonTeamRaceEndReqIter(false, DungeonScore.C));
					}
				}
				else
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonRaceEndReqIter(false, DungeonScore.C));
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

		// Token: 0x0601927E RID: 103038 RVA: 0x007F2638 File Offset: 0x007F0A38
		protected override void _onAreaClear(object[] args)
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.CloseLevelTip();
			}
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(3092391746U);
			}
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this._CheckFightEnd();
			}
			else
			{
				if (this.mThisRoomMonsterCreatedCount > 0)
				{
					SystemNotifyManager.SystemNotify(6000, string.Empty);
					MonoSingleton<AudioManager>.instance.PlaySound(5);
				}
				int num = this.mDungeonManager.GetDungeonDataManager().CurrentIndex();
				this._updateDungeonState(true);
			}
		}

		// Token: 0x0601927F RID: 103039 RVA: 0x007F26E4 File Offset: 0x007F0AE4
		protected virtual void _onPlayerDead(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(53048694U, new int[]
				{
					player.playerActor.m_iID
				});
			}
			base._playDungeonDead();
			player.state = BattlePlayer.EState.Dead;
			player.statistics.Dead();
			byte seat = player.playerInfo.seat;
			byte seat2 = this.mDungeonPlayers.GetMainPlayer().playerInfo.seat;
			if (seat == seat2 && BattleMain.IsModeMultiplayer(base.GetMode()))
			{
				BattlePlayer firstAlivePlayer = this.mDungeonPlayers.GetFirstAlivePlayer();
				if (firstAlivePlayer != null)
				{
					this.mDungeonManager.GetGeScene().AttachCameraTo(firstAlivePlayer.playerActor.m_pkGeActor);
				}
			}
			if (this.mDungeonPlayers.IsAllPlayerDead() || seat == seat2)
			{
				this._startPlayerDeadProcess(player);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerDead, null, null, null, null);
		}

		// Token: 0x06019280 RID: 103040 RVA: 0x007F27E4 File Offset: 0x007F0BE4
		private void _stopPlayerDeadProcess()
		{
			if (this.mDeadProcess != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDeadProcess);
				this.mDeadProcess = null;
			}
		}

		// Token: 0x06019281 RID: 103041 RVA: 0x007F2808 File Offset: 0x007F0C08
		private void _startPlayerDeadProcess(BattlePlayer player)
		{
			this._stopPlayerDeadProcess();
			if (!this.mDungeonManager.IsFinishFight())
			{
				this.mDeadProcess = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._playerDeadProcess(player));
			}
		}

		// Token: 0x06019282 RID: 103042 RVA: 0x007F2838 File Offset: 0x007F0C38
		protected override void _onPlayerLeave(BattlePlayer player)
		{
			if (player != null)
			{
				player.netState = BattlePlayer.eNetState.Offline;
				if (base.recordServer != null && base.recordServer.IsProcessRecord())
				{
					base.recordServer.Mark(51999254U, new int[]
					{
						player.playerActor.m_iID
					}, new string[]
					{
						player.playerInfo.name
					});
				}
			}
			if (this.mDungeonPlayers != null && this.mDungeonPlayers.IsAllPlayerDead())
			{
				this._startPlayerDeadProcess(player);
			}
		}

		// Token: 0x06019283 RID: 103043 RVA: 0x007F28C8 File Offset: 0x007F0CC8
		protected sealed override void _onPlayerBack(BattlePlayer player)
		{
			player.netState = BattlePlayer.eNetState.Online;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(51998742U, new int[]
				{
					player.playerActor.m_iID
				}, new string[]
				{
					player.playerInfo.name
				});
			}
		}

		// Token: 0x06019284 RID: 103044 RVA: 0x007F292F File Offset: 0x007F0D2F
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			if (player != null && player.playerActor != null)
			{
				player.playerActor.EndDeadProtect();
			}
			this._CheckFightEnd();
		}

		// Token: 0x06019285 RID: 103045 RVA: 0x007F2954 File Offset: 0x007F0D54
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

		// Token: 0x06019286 RID: 103046 RVA: 0x007F2970 File Offset: 0x007F0D70
		protected sealed override void _onPostStart()
		{
			if (base.GetMode() != eDungeonMode.Test && DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				SystemNotifyManager.SystemNotify(1033, string.Empty);
			}
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null || this.mDungeonManager.GetBeScene() == null || this.mDungeonManager.GetBeScene().sceneData == null)
			{
				return;
			}
			string hardString = ChapterUtility.GetHardString(3);
			SystemNotifyManager.SystemNotify(6001, new object[]
			{
				this.mDungeonManager.GetDungeonDataManager().table.Name,
				hardString
			});
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowLevelTip(this.mDungeonManager.GetBeScene().sceneData.GetTipsID());
			}
			this.mStarted = true;
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.RegisterEvent(BeEventSceneType.onBossDead, delegate(object[] args)
				{
					List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
					for (int i = 0; i < allPlayers.Count; i++)
					{
						BeActor playerActor = allPlayers[i].playerActor;
						if (playerActor != null && !playerActor.IsDead())
						{
							playerActor.SetAutoFight(false);
						}
						if (playerActor != null && playerActor.IsDead() && playerActor.GetRecordServer().IsProcessRecord())
						{
							playerActor.GetRecordServer().Mark(3075614530U);
						}
					}
				});
			}
		}

		// Token: 0x06019287 RID: 103047 RVA: 0x007F2A74 File Offset: 0x007F0E74
		private IEnumerator _sendDungeonRaceEndReqIter(bool modifyScore = false, DungeonScore score = DungeonScore.C)
		{
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return this._sendDungeonReportDataIter();
			MessageEvents msgEvent = new MessageEvents();
			SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
			SceneDungeonRaceEndReq req = this._getDungeonRaceEndReq();
			if (req == null)
			{
				yield break;
			}
			if (modifyScore)
			{
				req.score = (byte)score;
				req.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", req.score, req.beHitCount, req.usedTime));
			}
			if (this.mDungeonManager.GetDungeonDataManager() != null)
			{
				this.mDungeonManager.GetDungeonDataManager().LockBattleEnd();
			}
			yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msgEvent, req, res, true, 3f, 3, 33);
			if (msgEvent.IsAllMessageReceived())
			{
				this._onSceneDungeonRaceEndRes(res);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(9991);
			}
			yield break;
		}

		// Token: 0x06019288 RID: 103048 RVA: 0x007F2AA0 File Offset: 0x007F0EA0
		protected virtual SceneDungeonRaceEndReq _getDungeonRaceEndReq()
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
				score = (byte)this.mDungeonStatistics.FinalDungeonScore(),
				maxDamage = this.mDungeonStatistics.GetAllMaxHurtDamage(),
				skillId = this.mDungeonStatistics.GetAllMaxHurtSkillID(),
				param = this.mDungeonStatistics.GetAllMaxHurtID(),
				totalDamage = this.mDungeonStatistics.GetAllHurtDamage(),
				lastFrame = lastFrame,
				lastChecksum = lastChecksum
			};
			sceneDungeonRaceEndReq.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", sceneDungeonRaceEndReq.score, sceneDungeonRaceEndReq.beHitCount, sceneDungeonRaceEndReq.usedTime));
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(51999232U, new int[]
				{
					(int)sceneDungeonRaceEndReq.lastFrame
				});
			}
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x06019289 RID: 103049 RVA: 0x007F2BF8 File Offset: 0x007F0FF8
		private IEnumerator _sendDungeonTeamRaceEndReqIter(bool modifyScore = false, DungeonScore score = DungeonScore.C)
		{
			MessageEvents msgEvent = new MessageEvents();
			SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
			RelaySvrDungeonRaceEndReq req = this._getDungeonRaceEndTeamReq();
			if (modifyScore)
			{
				for (int i = 0; i < req.raceEndInfo.infoes.Length; i++)
				{
					DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo = req.raceEndInfo.infoes[i];
					dungeonPlayerRaceEndInfo.score = (byte)score;
					dungeonPlayerRaceEndInfo.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", dungeonPlayerRaceEndInfo.score, dungeonPlayerRaceEndInfo.beHitCount, req.raceEndInfo.usedTime));
				}
			}
			BattleMain.instance.WaitForResult();
			if (SwitchFunctionUtility.IsOpen(51))
			{
				yield return MessageUtility.Wait<RelaySvrDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.RELAY_SERVER, msgEvent, req, res, false, 60f);
				if (!msgEvent.IsAllMessageReceived())
				{
					Singleton<ClientSystemManager>.instance.QuitToLoginSystem(9991);
					yield break;
				}
				this._onSceneDungeonRaceEndRes(res);
			}
			else
			{
				yield return MessageUtility.Wait<RelaySvrDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.RELAY_SERVER, msgEvent, req, res, false, 20f);
				if (msgEvent.IsAllMessageReceived())
				{
					this._onSceneDungeonRaceEndRes(res);
				}
			}
			yield break;
		}

		// Token: 0x0601928A RID: 103050 RVA: 0x007F2C24 File Offset: 0x007F1024
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
					score = (byte)this.mDungeonStatistics.FinalDungeonScore(),
					beHitCount = (ushort)this.mDungeonStatistics.HitCount(playerInfo.seat)
				};
				dungeonPlayerRaceEndInfo.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", dungeonPlayerRaceEndInfo.score, dungeonPlayerRaceEndInfo.beHitCount, relaySvrDungeonRaceEndReq.raceEndInfo.usedTime));
				relaySvrDungeonRaceEndReq.raceEndInfo.infoes[i] = dungeonPlayerRaceEndInfo;
			}
			return relaySvrDungeonRaceEndReq;
		}

		// Token: 0x0601928B RID: 103051 RVA: 0x007F2D68 File Offset: 0x007F1168
		protected IEnumerator _sendDungeonReportDataIter()
		{
			if (base.GetMode() == eDungeonMode.LocalFrame)
			{
				if (this.mDungeonManager == null)
				{
					yield break;
				}
				if (this.mDungeonManager.GetDungeonDataManager() == null)
				{
					yield break;
				}
				this.mDungeonManager.GetDungeonDataManager().PushFinalFrameData();
				this.mDungeonManager.GetDungeonDataManager().SendWorldDungeonReportFrame();
				yield return null;
				while (!this.mDungeonManager.GetDungeonDataManager().IsAllReportDataServerRecived())
				{
					yield return null;
				}
				this.mDungeonManager.GetDungeonDataManager().UnlockUpdateCheck();
			}
			yield break;
		}

		// Token: 0x0601928C RID: 103052 RVA: 0x007F2D84 File Offset: 0x007F1184
		protected virtual void _onSceneDungeonRaceEndRes(SceneDungeonRaceEndRes res)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(3071420226U);
			}
			if (res.result == 0U)
			{
				DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleEndInfo(res);
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					clientSystemBattle.HidePauseButton(true);
				}
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._finishProcess(res));
				if (res.score == 0)
				{
					DataManager<DevelopGuidanceManager>.GetInstance().SignalGuidanceEntrace();
				}
			}
			else
			{
				Logger.LogErrorCode(res.result);
			}
		}

		// Token: 0x0601928D RID: 103053 RVA: 0x007F2E34 File Offset: 0x007F1234
		private IEnumerator _finishProcess(SceneDungeonRaceEndRes res)
		{
			if (res.hasRaceEndDrop != 0)
			{
				yield return this._requestRaceEndDrops((int)res.raceEndDropBaseMulti);
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null && this.mDungeonManager.GetDungeonDataManager().table != null)
			{
				Vec3 pos = this.mDungeonManager.GetBeScene().GeGDeadBossPosition();
				pos.x += 2.4f;
				this.mDungeonManager.GetBeScene().DropItems(this.mDungeonManager.GetDungeonDataManager().GetRaceEndDrops(), new VInt3(pos), false, true, null);
				yield return new WaitForSeconds(1.5f);
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			this._openDungeonFinishFrame(res);
			yield return this._waitForFrameClose(typeof(DungeonFinishFrame));
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				yield break;
			}
			DungeonTable tableData = base.dungeonManager.GetDungeonDataManager().table;
			int id = base.dungeonManager.GetDungeonDataManager().id.dungeonID;
			if (tableData != null && this.mIsNormalFinsh && ChapterUtility.PreconditionIDList(id).Count != 0 && this.mIsChapterNoPassed && tableData.SubType != DungeonTable.eSubType.S_WEEK_HELL)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<BossMissionCompletePromptFrame>(FrameLayer.Middle, null, string.Empty);
				yield return this._waitForFrameClose(typeof(BossMissionCompletePromptFrame));
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			Singleton<ClientSystemManager>.instance.OpenFrame<DungeonMenuFrame>(FrameLayer.Middle, null, string.Empty);
			yield return Yielders.EndOfFrame;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRewardFinish, null, null, null, null);
			yield break;
		}

		// Token: 0x0601928E RID: 103054 RVA: 0x007F2E58 File Offset: 0x007F1258
		private void _openDungeonFinishFrame(SceneDungeonRaceEndRes res)
		{
			base.PveBattleResult = ((res.score != 0) ? BattleResult.Success : BattleResult.Fail);
			DungeonFinishFrame dungeonFinishFrame = Singleton<ClientSystemManager>.instance.OpenFrame<DungeonFinishFrame>(FrameLayer.Middle, null, string.Empty) as DungeonFinishFrame;
			dungeonFinishFrame.SetData(res);
			dungeonFinishFrame.SetDrops(this._getAllRewardItems(res).ToArray());
		}

		// Token: 0x0601928F RID: 103055 RVA: 0x007F2EB0 File Offset: 0x007F12B0
		protected List<ComItemList.Items> _getAllRewardItems(SceneDungeonRaceEndRes res)
		{
			List<ComItemList.Items> list = this._getTeamRewardItem(res);
			List<ComItemList.Items> collection = this._getRaceEndDropItem();
			List<ComItemList.Items> collection2 = this._getPickedDropItems();
			list.AddRange(collection);
			list.AddRange(collection2);
			return list;
		}

		// Token: 0x06019290 RID: 103056 RVA: 0x007F2EE4 File Offset: 0x007F12E4
		protected List<ComItemList.Items> _getPickedDropItems()
		{
			TreasureMapBattle.<_getPickedDropItems>c__AnonStoreyB <_getPickedDropItems>c__AnonStoreyB = new TreasureMapBattle.<_getPickedDropItems>c__AnonStoreyB();
			<_getPickedDropItems>c__AnonStoreyB.allGots = DataManager<BattleDataManager>.GetInstance().BattleInfo.dropCacheItemIds;
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			int i;
			for (i = 0; i < <_getPickedDropItems>c__AnonStoreyB.allGots.Count; i++)
			{
				ComItemList.Items items = list.Find((ComItemList.Items x) => x.id == <_getPickedDropItems>c__AnonStoreyB.allGots[i].typeId);
				if (items != null)
				{
					items.count += (uint)<_getPickedDropItems>c__AnonStoreyB.allGots[i].num;
				}
				else
				{
					list.Add(new ComItemList.Items
					{
						id = <_getPickedDropItems>c__AnonStoreyB.allGots[i].typeId,
						count = (uint)<_getPickedDropItems>c__AnonStoreyB.allGots[i].num,
						type = ComItemList.eItemType.Custom,
						strenthLevel = <_getPickedDropItems>c__AnonStoreyB.allGots[i].strenthLevel,
						equipType = <_getPickedDropItems>c__AnonStoreyB.allGots[i].equipType
					});
				}
			}
			return list;
		}

		// Token: 0x06019291 RID: 103057 RVA: 0x007F301C File Offset: 0x007F141C
		protected List<ComItemList.Items> _getRaceEndDropItem()
		{
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return list;
			}
			List<DungeonDropItem> raceEndDrops = this.mDungeonManager.GetDungeonDataManager().GetRaceEndDrops();
			for (int i = 0; i < raceEndDrops.Count; i++)
			{
				ComItemList.Items item = new ComItemList.Items
				{
					count = (uint)raceEndDrops[i].num,
					id = raceEndDrops[i].typeId,
					type = ComItemList.eItemType.Custom,
					strenthLevel = raceEndDrops[i].strenthLevel,
					equipType = raceEndDrops[i].equipType
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06019292 RID: 103058 RVA: 0x007F30DC File Offset: 0x007F14DC
		protected List<ComItemList.Items> _getTeamRewardItem(SceneDungeonRaceEndRes res)
		{
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			if (res.teamReward != null && res.teamReward.id > 0U)
			{
				ComItemList.Items item = new ComItemList.Items
				{
					count = res.teamReward.num,
					id = (int)res.teamReward.id,
					type = ComItemList.eItemType.Custom,
					flag = ComItemList.eItemExtraFlag.ExtraReward,
					strenthLevel = (int)res.teamReward.strength,
					equipType = (EEquipType)res.teamReward.equipType
				};
				list.Insert(0, item);
			}
			if (res.veteranReturnReward != null && res.veteranReturnReward.id > 0U)
			{
				ComItemList.Items item2 = new ComItemList.Items
				{
					count = res.veteranReturnReward.num,
					id = (int)res.veteranReturnReward.id,
					type = ComItemList.eItemType.Custom,
					flag = ComItemList.eItemExtraFlag.ExtraReward,
					strenthLevel = (int)res.veteranReturnReward.strength,
					equipType = (EEquipType)res.veteranReturnReward.equipType
				};
				list.Insert(0, item2);
			}
			return list;
		}

		// Token: 0x06019293 RID: 103059 RVA: 0x007F31EC File Offset: 0x007F15EC
		private IEnumerator _waitForFrameClose(Type type)
		{
			yield return Yielders.EndOfFrame;
			while (Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06019294 RID: 103060 RVA: 0x007F3208 File Offset: 0x007F1608
		protected IEnumerator _requestRaceEndDrops(int multi)
		{
			if (!base._isNeedSendNet())
			{
				yield break;
			}
			MessageEvents msg = new MessageEvents();
			SceneDungeonEndDropReq req = new SceneDungeonEndDropReq();
			SceneDungeonEndDropRes res = new SceneDungeonEndDropRes();
			req.multi = (byte)multi;
			yield return base._sendMsgWithResend<SceneDungeonEndDropReq, SceneDungeonEndDropRes>(ServerType.GATE_SERVER, msg, req, res, true, 10f, 3, 3);
			if (msg.IsAllMessageReceived())
			{
			}
			yield break;
		}

		// Token: 0x06019295 RID: 103061 RVA: 0x007F322C File Offset: 0x007F162C
		// Note: this type is marked as 'beforefieldinit'.
		static TreasureMapBattle()
		{
			Dictionary<int, List<int[]>> dictionary = new Dictionary<int, List<int[]>>();
			Dictionary<int, List<int[]>> dictionary2 = dictionary;
			int key = 0;
			List<int[]> list = new List<int[]>();
			List<int[]> list2 = list;
			int[] array = new int[2];
			array[0] = 1;
			list2.Add(array);
			list.Add(new int[]
			{
				0,
				1
			});
			dictionary2.Add(key, list);
			Dictionary<int, List<int[]>> dictionary3 = dictionary;
			int key2 = 1;
			list = new List<int[]>();
			List<int[]> list3 = list;
			int[] array2 = new int[2];
			array2[0] = 1;
			list3.Add(array2);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				0,
				-1
			});
			dictionary3.Add(key2, list);
			Dictionary<int, List<int[]>> dictionary4 = dictionary;
			int key3 = 2;
			list = new List<int[]>();
			List<int[]> list4 = list;
			int[] array3 = new int[2];
			array3[0] = 1;
			list4.Add(array3);
			list.Add(new int[]
			{
				0,
				-1
			});
			dictionary4.Add(key3, list);
			Dictionary<int, List<int[]>> dictionary5 = dictionary;
			int key4 = 3;
			list = new List<int[]>();
			List<int[]> list5 = list;
			int[] array4 = new int[2];
			array4[0] = -1;
			list5.Add(array4);
			list.Add(new int[]
			{
				0,
				1
			});
			dictionary5.Add(key4, list);
			Dictionary<int, List<int[]>> dictionary6 = dictionary;
			int key5 = 4;
			list = new List<int[]>();
			List<int[]> list6 = list;
			int[] array5 = new int[2];
			array5[0] = -1;
			list6.Add(array5);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				0,
				-1
			});
			dictionary6.Add(key5, list);
			Dictionary<int, List<int[]>> dictionary7 = dictionary;
			int key6 = 5;
			list = new List<int[]>();
			List<int[]> list7 = list;
			int[] array6 = new int[2];
			array6[0] = -1;
			list7.Add(array6);
			list.Add(new int[]
			{
				0,
				-1
			});
			dictionary7.Add(key6, list);
			Dictionary<int, List<int[]>> dictionary8 = dictionary;
			int key7 = 6;
			list = new List<int[]>();
			List<int[]> list8 = list;
			int[] array7 = new int[2];
			array7[0] = 1;
			list8.Add(array7);
			list.Add(new int[]
			{
				0,
				1
			});
			List<int[]> list9 = list;
			int[] array8 = new int[2];
			array8[0] = -1;
			list9.Add(array8);
			dictionary8.Add(key7, list);
			Dictionary<int, List<int[]>> dictionary9 = dictionary;
			int key8 = 7;
			list = new List<int[]>();
			list.Add(new int[]
			{
				0,
				-1
			});
			List<int[]> list10 = list;
			int[] array9 = new int[2];
			array9[0] = -1;
			list10.Add(array9);
			List<int[]> list11 = list;
			int[] array10 = new int[2];
			array10[0] = 1;
			list11.Add(array10);
			dictionary9.Add(key8, list);
			Dictionary<int, List<int[]>> dictionary10 = dictionary;
			int key9 = 8;
			list = new List<int[]>();
			List<int[]> list12 = list;
			int[] array11 = new int[2];
			array11[0] = -1;
			list12.Add(array11);
			list.Add(new int[]
			{
				0,
				-1
			});
			List<int[]> list13 = list;
			int[] array12 = new int[2];
			array12[0] = 1;
			list13.Add(array12);
			list.Add(new int[]
			{
				0,
				1
			});
			dictionary10.Add(key9, list);
			TreasureMapBattle.linkDir = dictionary;
			dictionary = new Dictionary<int, List<int[]>>();
			Dictionary<int, List<int[]>> dictionary11 = dictionary;
			int key10 = 0;
			list = new List<int[]>();
			List<int[]> list14 = list;
			int[] array13 = new int[2];
			array13[0] = 1;
			list14.Add(array13);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				1,
				1
			});
			dictionary11.Add(key10, list);
			Dictionary<int, List<int[]>> dictionary12 = dictionary;
			int key11 = 1;
			list = new List<int[]>();
			List<int[]> list15 = list;
			int[] array14 = new int[2];
			array14[0] = 1;
			list15.Add(array14);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				0,
				-1
			});
			list.Add(new int[]
			{
				1,
				1
			});
			list.Add(new int[]
			{
				1,
				-1
			});
			dictionary12.Add(key11, list);
			Dictionary<int, List<int[]>> dictionary13 = dictionary;
			int key12 = 2;
			list = new List<int[]>();
			List<int[]> list16 = list;
			int[] array15 = new int[2];
			array15[0] = 1;
			list16.Add(array15);
			list.Add(new int[]
			{
				0,
				-1
			});
			list.Add(new int[]
			{
				1,
				-1
			});
			dictionary13.Add(key12, list);
			Dictionary<int, List<int[]>> dictionary14 = dictionary;
			int key13 = 3;
			list = new List<int[]>();
			List<int[]> list17 = list;
			int[] array16 = new int[2];
			array16[0] = -1;
			list17.Add(array16);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				-1,
				1
			});
			dictionary14.Add(key13, list);
			Dictionary<int, List<int[]>> dictionary15 = dictionary;
			int key14 = 4;
			list = new List<int[]>();
			List<int[]> list18 = list;
			int[] array17 = new int[2];
			array17[0] = -1;
			list18.Add(array17);
			list.Add(new int[]
			{
				0,
				-1
			});
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				-1,
				-1
			});
			list.Add(new int[]
			{
				-1,
				1
			});
			dictionary15.Add(key14, list);
			Dictionary<int, List<int[]>> dictionary16 = dictionary;
			int key15 = 5;
			list = new List<int[]>();
			List<int[]> list19 = list;
			int[] array18 = new int[2];
			array18[0] = -1;
			list19.Add(array18);
			list.Add(new int[]
			{
				0,
				-1
			});
			list.Add(new int[]
			{
				-1,
				-1
			});
			dictionary16.Add(key15, list);
			Dictionary<int, List<int[]>> dictionary17 = dictionary;
			int key16 = 6;
			list = new List<int[]>();
			List<int[]> list20 = list;
			int[] array19 = new int[2];
			array19[0] = 1;
			list20.Add(array19);
			List<int[]> list21 = list;
			int[] array20 = new int[2];
			array20[0] = -1;
			list21.Add(array20);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				1,
				1
			});
			list.Add(new int[]
			{
				-1,
				1
			});
			dictionary17.Add(key16, list);
			Dictionary<int, List<int[]>> dictionary18 = dictionary;
			int key17 = 7;
			list = new List<int[]>();
			List<int[]> list22 = list;
			int[] array21 = new int[2];
			array21[0] = -1;
			list22.Add(array21);
			list.Add(new int[]
			{
				0,
				-1
			});
			List<int[]> list23 = list;
			int[] array22 = new int[2];
			array22[0] = 1;
			list23.Add(array22);
			list.Add(new int[]
			{
				-1,
				-1
			});
			list.Add(new int[]
			{
				1,
				-1
			});
			dictionary18.Add(key17, list);
			Dictionary<int, List<int[]>> dictionary19 = dictionary;
			int key18 = 8;
			list = new List<int[]>();
			List<int[]> list24 = list;
			int[] array23 = new int[2];
			array23[0] = -1;
			list24.Add(array23);
			list.Add(new int[]
			{
				0,
				-1
			});
			List<int[]> list25 = list;
			int[] array24 = new int[2];
			array24[0] = 1;
			list25.Add(array24);
			list.Add(new int[]
			{
				0,
				1
			});
			list.Add(new int[]
			{
				-1,
				-1
			});
			list.Add(new int[]
			{
				1,
				1
			});
			list.Add(new int[]
			{
				1,
				-1
			});
			list.Add(new int[]
			{
				1,
				1
			});
			dictionary19.Add(key18, list);
			TreasureMapBattle.crossLinkDir = dictionary;
		}

		// Token: 0x04012041 RID: 73793
		private int mDoorShiftCount;

		// Token: 0x04012042 RID: 73794
		private int mBossX;

		// Token: 0x04012043 RID: 73795
		private int mBossY;

		// Token: 0x04012044 RID: 73796
		private int mBossIndex = -1;

		// Token: 0x04012045 RID: 73797
		private int mEndX;

		// Token: 0x04012046 RID: 73798
		private int mEndY;

		// Token: 0x04012047 RID: 73799
		private uint mInitSeed;

		// Token: 0x04012048 RID: 73800
		private bool mFirstShiftDoor = true;

		// Token: 0x04012049 RID: 73801
		private bool mIsNormalFinsh;

		// Token: 0x0401204A RID: 73802
		private bool mIsChapterNoPassed;

		// Token: 0x0401204B RID: 73803
		private int mThisRoomMonsterCreatedCount;

		// Token: 0x0401204C RID: 73804
		private int mStartPassDoor;

		// Token: 0x0401204D RID: 73805
		private bool mStarted;

		// Token: 0x0401204E RID: 73806
		private bool mIsBossDead;

		// Token: 0x0401204F RID: 73807
		private int mGlobalRegionIdGen;

		// Token: 0x04012050 RID: 73808
		private BeEventHandle mBossEventHandle;

		// Token: 0x04012051 RID: 73809
		private int mBossId = -1;

		// Token: 0x04012052 RID: 73810
		private int mCurBossHP = -1;

		// Token: 0x04012053 RID: 73811
		private Coroutine mDungeonRaceEndReqCoroutine;

		// Token: 0x04012054 RID: 73812
		private List<BattlePlayer> mCachBeActor = new List<BattlePlayer>();

		// Token: 0x04012055 RID: 73813
		private List<int> mRegionIdLibrary = new List<int>();

		// Token: 0x04012056 RID: 73814
		private List<int> mReduceRegionIds = new List<int>();

		// Token: 0x04012057 RID: 73815
		private List<int> mCurRegionIdLibary = new List<int>();

		// Token: 0x04012058 RID: 73816
		private List<int> mCurReduceRegionIds = new List<int>();

		// Token: 0x04012059 RID: 73817
		private int mDropItemCount;

		// Token: 0x0401205A RID: 73818
		private static readonly Dictionary<int, List<int[]>> linkDir;

		// Token: 0x0401205B RID: 73819
		private static readonly Dictionary<int, List<int[]>> crossLinkDir;

		// Token: 0x0401205C RID: 73820
		private TreasureMapFrame treasureMapFrame;

		// Token: 0x0401205D RID: 73821
		public Action<int, int> playerHitCallBack;

		// Token: 0x0401205E RID: 73822
		private Coroutine mDeadProcess;
	}
}
