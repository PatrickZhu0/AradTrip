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
	// Token: 0x020045A7 RID: 17831
	public class BaseBattle : GameBindSystem, IBattle, IOnExecCommand, IDungeonAudio
	{
		// Token: 0x06018E8A RID: 102026 RVA: 0x007CCDDC File Offset: 0x007CB1DC
		public BaseBattle(BattleType type, eDungeonMode mode, int dungeonID)
		{
			this.mBattleType = type;
			this.mMode = mode;
			this._PveBattleResult = BattleResult.None;
			BeDungeon beDungeon = new BeDungeon(type, mode, dungeonID)
			{
				mBattle = this
			};
			this.mDungeonStatistics = beDungeon;
			this.mDungeonManager = beDungeon;
			this.mDungeonEnumeratorManager = beDungeon;
			this.mDungeonPlayers = beDungeon.GetDungeonPlayerDataManager();
			this.mTrialManager = new TrailManagerImp();
			this.mProjectilePool = new BeProjectilePoolImp();
			this.mProjectilePool.Init();
			this.mAICommandPool = new BeAICommandPoolImp();
			this.mAICommandPool.Init();
			this.mframeRandom.mRecordServer = this.mRecordServer;
			this.mRecordServer.battleType = type;
			this.mRecordServer.FrameRandom = this.FrameRandom;
		}

		// Token: 0x17002089 RID: 8329
		// (get) Token: 0x06018E8B RID: 102027 RVA: 0x007CCED6 File Offset: 0x007CB2D6
		public int LoadingStep
		{
			get
			{
				return this.m_loadingStep;
			}
		}

		// Token: 0x06018E8C RID: 102028 RVA: 0x007CCEDE File Offset: 0x007CB2DE
		public void SetBattleFlag(ulong flag)
		{
			this._battleFlag = flag;
		}

		// Token: 0x06018E8D RID: 102029 RVA: 0x007CCEE8 File Offset: 0x007CB2E8
		public bool HasFlag(BattleFlagType iFlag)
		{
			ulong num = this._battleFlag & (ulong)iFlag;
			return num != 0UL;
		}

		// Token: 0x06018E8E RID: 102030 RVA: 0x007CCF08 File Offset: 0x007CB308
		public bool FunctionIsOpen(BattleFlagType iFlag)
		{
			ulong num = this._battleFlag & (ulong)iFlag;
			return num != 0UL;
		}

		// Token: 0x1700208A RID: 8330
		// (get) Token: 0x06018E8F RID: 102031 RVA: 0x007CCF26 File Offset: 0x007CB326
		// (set) Token: 0x06018E90 RID: 102032 RVA: 0x007CCF2E File Offset: 0x007CB32E
		public int PkRaceType
		{
			get
			{
				return this.pkRaceType;
			}
			set
			{
				this.pkRaceType = value;
			}
		}

		// Token: 0x1700208B RID: 8331
		// (get) Token: 0x06018E91 RID: 102033 RVA: 0x007CCF37 File Offset: 0x007CB337
		// (set) Token: 0x06018E92 RID: 102034 RVA: 0x007CCF3F File Offset: 0x007CB33F
		public BattleResult PveBattleResult
		{
			get
			{
				return this._PveBattleResult;
			}
			set
			{
				this._PveBattleResult = value;
			}
		}

		// Token: 0x1700208C RID: 8332
		// (get) Token: 0x06018E93 RID: 102035 RVA: 0x007CCF48 File Offset: 0x007CB348
		public TrailManagerImp TrailManager
		{
			get
			{
				return this.mTrialManager;
			}
		}

		// Token: 0x1700208D RID: 8333
		// (get) Token: 0x06018E94 RID: 102036 RVA: 0x007CCF50 File Offset: 0x007CB350
		public BeProjectilePoolImp BeProjectilePool
		{
			get
			{
				return this.mProjectilePool;
			}
		}

		// Token: 0x1700208E RID: 8334
		// (get) Token: 0x06018E95 RID: 102037 RVA: 0x007CCF58 File Offset: 0x007CB358
		public BeAICommandPoolImp BeAICommandPool
		{
			get
			{
				return this.mAICommandPool;
			}
		}

		// Token: 0x1700208F RID: 8335
		// (get) Token: 0x06018E96 RID: 102038 RVA: 0x007CCF60 File Offset: 0x007CB360
		public FrameRandomImp FrameRandom
		{
			get
			{
				return this.mframeRandom;
			}
		}

		// Token: 0x17002090 RID: 8336
		// (get) Token: 0x06018E97 RID: 102039 RVA: 0x007CCF68 File Offset: 0x007CB368
		// (set) Token: 0x06018E98 RID: 102040 RVA: 0x007CCF70 File Offset: 0x007CB370
		public LevelManager LevelMgr
		{
			get
			{
				return this.mLevelMgr;
			}
			set
			{
				this.mLevelMgr = value;
			}
		}

		// Token: 0x17002091 RID: 8337
		// (get) Token: 0x06018E99 RID: 102041 RVA: 0x007CCF79 File Offset: 0x007CB379
		public LogicServer logicServer
		{
			get
			{
				return this.mLogicServer;
			}
		}

		// Token: 0x17002092 RID: 8338
		// (get) Token: 0x06018E9A RID: 102042 RVA: 0x007CCF81 File Offset: 0x007CB381
		public IDungeonPlayerDataManager dungeonPlayerManager
		{
			get
			{
				return this.mDungeonPlayers;
			}
		}

		// Token: 0x17002093 RID: 8339
		// (get) Token: 0x06018E9B RID: 102043 RVA: 0x007CCF89 File Offset: 0x007CB389
		public IDungeonManager dungeonManager
		{
			get
			{
				return this.mDungeonManager;
			}
		}

		// Token: 0x17002094 RID: 8340
		// (get) Token: 0x06018E9C RID: 102044 RVA: 0x007CCF91 File Offset: 0x007CB391
		public IDungeonStatistics dungeonStatistics
		{
			get
			{
				return this.mDungeonStatistics;
			}
		}

		// Token: 0x17002095 RID: 8341
		// (get) Token: 0x06018E9D RID: 102045 RVA: 0x007CCF99 File Offset: 0x007CB399
		public RecordServer recordServer
		{
			get
			{
				return this.mRecordServer;
			}
		}

		// Token: 0x06018E9E RID: 102046 RVA: 0x007CCFA1 File Offset: 0x007CB3A1
		public BattleType GetBattleType()
		{
			return this.mBattleType;
		}

		// Token: 0x06018E9F RID: 102047 RVA: 0x007CCFA9 File Offset: 0x007CB3A9
		public eDungeonMode GetMode()
		{
			return this.mMode;
		}

		// Token: 0x06018EA0 RID: 102048 RVA: 0x007CCFB4 File Offset: 0x007CB3B4
		public void End(bool needEndRecord = true)
		{
			this._doStatFinishBattle();
			if (this.mLevelMgr != null)
			{
				this.mLevelMgr.DeInit();
				this.mLevelMgr = null;
			}
			if (needEndRecord)
			{
				this.recordServer.EndRecord("BaseBattleEnd");
			}
			this._unbindEvents();
			this._unloadInputManger();
			BeUtility.ResetCamera();
			this.ClearBgm();
			this._onEnd();
			this.mDungeonManager.DestoryBeScene();
			this.mDungeonManager = null;
			this.mDungeonPlayers = null;
			this.mDungeonStatistics = null;
			this.mDungeonEnumeratorManager = null;
			this.mLogicServer = null;
		}

		// Token: 0x06018EA1 RID: 102049 RVA: 0x007CD048 File Offset: 0x007CB448
		private void _doStatFinishBattle()
		{
			try
			{
				Singleton<GameStatisticManager>.instance.DoStatFinishBattle(this.mDungeonManager.GetDungeonDataManager().id.dungeonID);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[战斗数据] 结束战斗统计 {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x06018EA2 RID: 102050 RVA: 0x007CD0A8 File Offset: 0x007CB4A8
		public void StartLogicServer(LogicServer logicServer)
		{
			this.mLogicServer = logicServer;
			this.FrameRandom.ResetSeed((uint)ClientApplication.playerinfo.session);
			this.OnAfterSeedInited();
			this.mDungeonManager.GetDungeonDataManager().FirstArea();
			this._onStart();
			this._createBase();
			this._createEntitys();
			this._onSceneStart();
			this._bindEvents();
			this.mDungeonManager.StartFight(false);
		}

		// Token: 0x06018EA3 RID: 102051 RVA: 0x007CD114 File Offset: 0x007CB514
		public IEnumerator Start(IASyncOperation op)
		{
			float startTime = Time.realtimeSinceStartup;
			this.m_loadingStep = 0;
			Singleton<GeEffectPool>.GetInstance().ClearAll();
			this.m_loadingStep = 1;
			if (this.mMode == eDungeonMode.SyncFrame)
			{
			}
			FrameSync.instance.isFire = true;
			FrameSync.instance.SetDungeonMode(this.mMode);
			this.m_loadingStep = 2;
			if (this.mMode == eDungeonMode.SyncFrame)
			{
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					WaitServerConnected waitConnect = new WaitServerConnected(ServerType.RELAY_SERVER, ClientApplication.relayServer.ip, ClientApplication.relayServer.port, ClientApplication.playerinfo.accid, 4f, 3, 1f);
					yield return waitConnect;
					if (waitConnect.GetResult() != WaitServerConnected.eResult.Success)
					{
						yield return new NormalCustomEnumError("[战斗] 连接服务器失败", eEnumError.ProcessError);
						yield break;
					}
					Singleton<ClientReconnectManager>.instance.canReconnectRelay = true;
				}
				this.FrameRandom.ResetSeed((uint)ClientApplication.playerinfo.session);
				this.OnAfterSeedInited();
				FrameSync.instance.Init();
				FrameSync.instance.SetStartTick();
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					MessageEvents msgEvents = new MessageEvents();
					RelaySvrLoginReq req = new RelaySvrLoginReq();
					RelaySvrLoginRes res = new RelaySvrLoginRes();
					BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
					req.accid = mainPlayer.playerInfo.accid;
					req.roleid = mainPlayer.playerInfo.roleId;
					req.seat = mainPlayer.playerInfo.seat;
					req.session = ClientApplication.playerinfo.session;
					this.m_loadingStep = 33;
					yield return MessageUtility.Wait<RelaySvrLoginReq, RelaySvrLoginRes>(ServerType.RELAY_SERVER, msgEvents, req, res, false, 20f);
					if (!msgEvents.IsAllMessageReceived())
					{
						this.m_loadingStep = 34;
						yield return new NormalCustomEnumError("[战斗] 登录战服超时", eEnumError.ProcessError);
						yield break;
					}
					if (res.result != 0U)
					{
						this.m_loadingStep = 35;
						yield return new NormalCustomEnumError("[战斗] 登录战服失败", eEnumError.ProcessError);
						yield break;
					}
					this.m_loadingStep = 36;
					op.SetProgress(0.05f);
					op.SetProgressInfo("login");
				}
			}
			else
			{
				this.FrameRandom.ResetSeed((uint)ClientApplication.playerinfo.session);
				this.OnAfterSeedInited();
				FrameSync.instance.Init();
				FrameSync.instance.SetStartTick();
			}
			this.m_loadingStep = 3;
			op.SetProgress(0.1f);
			this.mDungeonPlayers.SendMainPlayerLoadRate(4);
			this.m_loadingStep = 4;
			yield return Yielders.EndOfFrame;
			this.m_loadingStep = 5;
			this.mDungeonManager.GetDungeonDataManager().FirstArea();
			this.m_loadingStep = 6;
			this._onStart();
			this.m_loadingStep = 7;
			op.SetProgress(0.15f);
			op.SetProgressInfo("_onStart");
			this._createBase();
			this.m_loadingStep = 8;
			op.SetProgress(0.2f);
			op.SetProgressInfo("_createBase");
			this.m_loadingStep = 9;
			this.mDungeonPlayers.SendMainPlayerLoadRate(20);
			yield return Yielders.EndOfFrame;
			this.m_loadingStep = 10;
			HGProfiler.BeginProfiler("0---load players & first room mosnters");
			this._createEntitys();
			this.m_loadingStep = 11;
			HGProfiler.EndProfiler();
			while (!this._isBattleLoadFinish())
			{
				yield return Yielders.EndOfFrame;
			}
			this.m_loadingStep = 12;
			op.SetProgress(0.5f);
			op.SetProgressInfo("_createEntitys");
			this.mDungeonPlayers.SendMainPlayerLoadRate(50);
			this.m_loadingStep = 13;
			yield return Yielders.EndOfFrame;
			this._createInput();
			this.m_loadingStep = 14;
			this._onStartResourceLoaded();
			this.m_loadingStep = 15;
			op.SetProgress(0.6f);
			op.SetProgressInfo("_onStartResourceLoaded");
			yield return Yielders.EndOfFrame;
			this.PreparePreloadRes();
			this.m_loadingStep = 16;
			op.SetProgress(0.7f);
			op.SetProgressInfo("PreparePreloadRes");
			this.mDungeonPlayers.SendMainPlayerLoadRate(55);
			yield return Yielders.EndOfFrame;
			this.m_loadingStep = 17;
			this._onSceneStart();
			this.m_loadingStep = 18;
			op.SetProgress(0.8f);
			op.SetProgressInfo("_onSceneStart");
			this.mDungeonPlayers.SendMainPlayerLoadRate(60);
			yield return Yielders.EndOfFrame;
			this.m_loadingStep = 19;
			Logger.LogErrorFormat("[战斗加载] 预加载之前 加载用时 {0}", new object[]
			{
				Time.realtimeSinceStartup - startTime
			});
			yield return ClientSystemManager._PreloadRes(op);
			this.m_loadingStep = 20;
			this.mDungeonPlayers.SendMainPlayerLoadRate(90);
			Logger.LogErrorFormat("[战斗加载] 加载用时 {0}", new object[]
			{
				Time.realtimeSinceStartup - startTime
			});
			this.m_loadingStep = 21;
			op.SetProgress(0.95f);
			op.SetProgressInfo("RelaySvrNotifyGameStart2");
			this.mDungeonPlayers.SendMainPlayerLoadRate(100);
			this.m_loadingStep = 22;
			this._bindEvents();
			this.m_loadingStep = 23;
			if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
			{
				Singleton<ReplayServer>.GetInstance().ReadyToLiveShow();
			}
			if (!Singleton<ReplayServer>.GetInstance().IsReplay() || Singleton<ReplayServer>.GetInstance().IsLiveShow())
			{
				float timeOutCount = 0f;
				while (!FrameSync.instance.isGetStartFrame)
				{
					if (timeOutCount >= 130f)
					{
						this.m_loadingStep = 28;
						break;
					}
					this.m_loadingStep = 29;
					yield return Yielders.EndOfFrame;
					this.m_loadingStep = 30;
					timeOutCount += Time.unscaledDeltaTime;
				}
				if (!FrameSync.instance.isGetStartFrame)
				{
					this.m_loadingStep = 31;
					yield return new NormalCustomEnumError("[战斗] 进入游戏消息超时", eEnumError.ProcessError);
					this.m_loadingStep = 32;
					yield break;
				}
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(1200, delegate
				{
					Singleton<ReplayServer>.GetInstance().Start();
				}, 0, 0, false);
			}
			this.m_loadingStep = 24;
			this.mDungeonManager.StartFight(false);
			this.m_loadingStep = 25;
			op.SetProgress(1f);
			op.SetProgressInfo("Loading...");
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				this.mDungeonManager.GetDungeonDataManager().SendDungeonEnterRace();
			}
			this.m_loadingStep = 26;
			this.PushBgm(this.mDungeonManager.GetDungeonDataManager().table.BGMPath);
			this.m_loadingStep = 27;
			yield break;
		}

		// Token: 0x06018EA4 RID: 102052 RVA: 0x007CD136 File Offset: 0x007CB536
		public BeScene Restart()
		{
			this._onRestart();
			return this.mDungeonManager.GetBeScene();
		}

		// Token: 0x06018EA5 RID: 102053 RVA: 0x007CD149 File Offset: 0x007CB549
		public virtual void OnCriticalElementDisappear()
		{
		}

		// Token: 0x06018EA6 RID: 102054 RVA: 0x007CD14B File Offset: 0x007CB54B
		public virtual void OnAfterSeedInited()
		{
		}

		// Token: 0x06018EA7 RID: 102055 RVA: 0x007CD14D File Offset: 0x007CB54D
		public virtual bool CanReborn()
		{
			return true;
		}

		// Token: 0x06018EA8 RID: 102056 RVA: 0x007CD150 File Offset: 0x007CB550
		public virtual bool IsRebornCountLimit()
		{
			return false;
		}

		// Token: 0x06018EA9 RID: 102057 RVA: 0x007CD153 File Offset: 0x007CB553
		public virtual int GetLeftRebornCount()
		{
			return 0;
		}

		// Token: 0x06018EAA RID: 102058 RVA: 0x007CD156 File Offset: 0x007CB556
		public virtual int GetMaxRebornCount()
		{
			return 0;
		}

		// Token: 0x06018EAB RID: 102059 RVA: 0x007CD159 File Offset: 0x007CB559
		public virtual void AddMaxRebornCount(int count)
		{
		}

		// Token: 0x06018EAC RID: 102060 RVA: 0x007CD15C File Offset: 0x007CB55C
		protected void GetFinalFrameInfo(ref uint lastframe, ref uint lastCheckSum)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			if (this.HasFlag(BattleFlagType.UseOldCheatSync))
			{
				lastframe = dungeonDataManager.GetFinalFrameDataIndex();
				lastCheckSum = dungeonDataManager.GetFinalRandomNum();
			}
			else
			{
				lastframe = dungeonDataManager.GetRaceEndFrameIndex();
				lastCheckSum = dungeonDataManager.GetRaceEndRandomNum();
				if (lastframe == 0U)
				{
					lastframe = dungeonDataManager.GetFinalFrameDataIndex();
					lastCheckSum = dungeonDataManager.GetFinalRandomNum();
					Logger.LogErrorFormat("time out race end {0} {1}", new object[]
					{
						lastframe,
						lastCheckSum
					});
				}
			}
		}

		// Token: 0x06018EAD RID: 102061 RVA: 0x007CD204 File Offset: 0x007CB604
		protected virtual void PreparePreloadRes()
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			PreloadManager.ClearCache();
			PreloadManager.battleType = this.mBattleType;
			HGProfiler.BeginProfiler("1---preload dungeonData");
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			if (dungeonDataManager != null)
			{
				MonoSingleton<CResPreloader>.instance.AddRes(dungeonDataManager.PreloadPath(), false, 1, new ResExtrator(dungeonDataManager.Preload), 0, null, CResPreloader.ResType.OBJECT, null);
			}
			HGProfiler.EndProfiler();
			HGProfiler.BeginProfiler("2---preload created players");
			this.playerRoleIDList.Clear();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					bool useCube = false;
					if (Singleton<GeGraphicSetting>.instance.IsLowLevel() && !BattleMain.IsModePvP(this.mBattleType) && !allPlayers[i].playerActor.isLocalActor)
					{
						useCube = true;
					}
					if (((BeClientSwitch.FunctionIsOpen(ClientSwitchType.SkillPre) && !BattleMain.IsModePvP(this.mBattleType)) || this.mBattleType == BattleType.ChijiPVP) && !Singleton<GeGraphicSetting>.instance.IsLowLevel() && !this.playerRoleIDList.Contains(allPlayers[i].playerActor.professionID))
					{
						this.playerRoleIDList.Add(allPlayers[i].playerActor.professionID);
						this.PreloadJobRes(allPlayers[i]);
					}
					PreloadManager.PreloadActor(playerActor, null, null, useCube);
				}
			}
			HGProfiler.EndProfiler();
			HGProfiler.BeginProfiler("3---preload created mosnters");
			this.PreloadEnemies();
			HGProfiler.EndProfiler();
			HGProfiler.BeginProfiler("5---preload all not created HELL monsters");
			this._PreloadHell();
			HGProfiler.EndProfiler();
		}

		// Token: 0x06018EAE RID: 102062 RVA: 0x007CD3A8 File Offset: 0x007CB7A8
		protected void PreloadAllMonsters()
		{
			if (this.GetBattleType() == BattleType.TreasureMap)
			{
				return;
			}
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonArea> areas = dungeonDataManager.battleInfo.areas;
			for (int i = 0; i < areas.Count; i++)
			{
				List<DungeonMonster> monsters = areas[i].monsters;
				for (int j = 0; j < monsters.Count; j++)
				{
					PreloadManager.PreloadMonsterID(monsters[j].typeId, null, null, false);
					List<DungeonMonster> summonerMonsters = monsters[j].summonerMonsters;
					if (summonerMonsters != null)
					{
						for (int k = 0; k < summonerMonsters.Count; k++)
						{
							PreloadManager.PreloadMonsterID(summonerMonsters[k].typeId, null, null, false);
						}
					}
				}
			}
		}

		// Token: 0x06018EAF RID: 102063 RVA: 0x007CD494 File Offset: 0x007CB894
		protected void PreloadEnemies()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene == null)
			{
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				List<BeEntity> list = null;
				if (i == 0)
				{
					list = beScene.GetEntities();
				}
				else if (i == 1)
				{
					list = beScene.GetPendingEntities();
				}
				for (int j = 0; j < list.Count; j++)
				{
					BeActor beActor = list[j] as BeActor;
					if (beActor != null && beActor.IsMonster())
					{
						PreloadManager.PreloadActor(beActor, null, null, false);
					}
					if (list[j] is BeObject && list[j].m_iResID == 60111)
					{
						PreloadManager.PreloadResID(list[j].m_iResID, null, null, false);
					}
				}
			}
		}

		// Token: 0x06018EB0 RID: 102064 RVA: 0x007CD565 File Offset: 0x007CB965
		protected void PreloadMonster()
		{
			MonoSingleton<CResPreloader>.instance.Clear(false);
			PreloadManager.ClearCache();
			this.PreloadEnemies();
			MonoSingleton<CResPreloader>.instance.DoPreLoadAsync(false, true);
		}

		// Token: 0x06018EB1 RID: 102065 RVA: 0x007CD58A File Offset: 0x007CB98A
		protected void PreloadHell()
		{
			MonoSingleton<CResPreloader>.instance.Clear(false);
			PreloadManager.ClearCache();
			this._PreloadHell();
			MonoSingleton<CResPreloader>.instance.DoPreLoadAsync(false, true);
		}

		// Token: 0x06018EB2 RID: 102066 RVA: 0x007CD5B0 File Offset: 0x007CB9B0
		protected void _PreloadHell()
		{
			MonoSingleton<CResPreloader>.instance.SetTag(CResPreloader.PreloadTag.HELL);
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			Battle.DungeonHellInfo dungeonHealInfo = dungeonDataManager.battleInfo.dungeonHealInfo;
			if (dungeonHealInfo != null)
			{
				for (int i = 0; i < dungeonHealInfo.waveInfos.Count; i++)
				{
					for (int j = 0; j < dungeonHealInfo.waveInfos[i].monsters.Count; j++)
					{
						PreloadManager.PreloadMonsterID(dungeonHealInfo.waveInfos[i].monsters[j].typeId, null, null, false);
					}
				}
			}
			MonoSingleton<CResPreloader>.instance.SetTag(CResPreloader.PreloadTag.NONE);
		}

		// Token: 0x06018EB3 RID: 102067 RVA: 0x007CD670 File Offset: 0x007CBA70
		private void _bindEvents()
		{
			FrameSync.instance.SetMainLogic(this.mDungeonManager);
			base.InitBindSystem(null);
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.RegisterEvent(BeEventSceneType.onClear, new BeEventHandle.Del(this._onAreaClearEvent));
				beScene.RegisterEvent(BeEventSceneType.onDoorStateChange, new BeEventHandle.Del(this._onDoorStateChange));
				beScene.RegisterEvent(BeEventSceneType.onMonsterRemoved, new BeEventHandle.Del(this._onMonsterRemoved));
				beScene.RegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this._onMonsterDead));
				beScene.RegisterEvent(BeEventSceneType.onEggDead, new BeEventHandle.Del(this._onEggDead));
			}
		}

		// Token: 0x06018EB4 RID: 102068 RVA: 0x007CD710 File Offset: 0x007CBB10
		private void _unbindEvents()
		{
			if (this.mMode == eDungeonMode.SyncFrame)
			{
				FrameSync.instance.UnInit();
			}
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			FrameSync.instance.ClearMainLogic();
			base.ExistBindSystem();
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.UnRegisterEvent(BeEventSceneType.onClear, new BeEventHandle.Del(this._onAreaClearEvent));
				beScene.UnRegisterEvent(BeEventSceneType.onDoorStateChange, new BeEventHandle.Del(this._onDoorStateChange));
				beScene.UnRegisterEvent(BeEventSceneType.onMonsterRemoved, new BeEventHandle.Del(this._onMonsterRemoved));
				beScene.UnRegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this._onMonsterDead));
				beScene.UnRegisterEvent(BeEventSceneType.onEggDead, new BeEventHandle.Del(this._onEggDead));
			}
		}

		// Token: 0x06018EB5 RID: 102069 RVA: 0x007CD7C4 File Offset: 0x007CBBC4
		protected void _createInput()
		{
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null && mainPlayer.playerActor != null)
			{
				this._loadInputManager(mainPlayer.playerActor);
			}
		}

		// Token: 0x06018EB6 RID: 102070 RVA: 0x007CD810 File Offset: 0x007CBC10
		protected void _reLoadSkillButton()
		{
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			if (this.mDungeonPlayers == null)
			{
				return;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null)
			{
				this.mInputManager.LoadJoystick(Singleton<SettingManager>.GetInstance().GetJoystickMode());
				this.mInputManager.LoadSkillButton(mainPlayer.playerActor);
				this.mInputManager.ResetSkillJoystick();
			}
		}

		// Token: 0x06018EB7 RID: 102071 RVA: 0x007CD87C File Offset: 0x007CBC7C
		protected void _unloadInputManger()
		{
			if (this.mInputManager != null)
			{
				this.mInputManager.Unload();
				this.mInputManager = null;
			}
		}

		// Token: 0x06018EB8 RID: 102072 RVA: 0x007CD89B File Offset: 0x007CBC9B
		protected void _hiddenInputManagerJump()
		{
			if (this.mInputManager != null)
			{
				this.mInputManager.HiddenJump();
			}
		}

		// Token: 0x06018EB9 RID: 102073 RVA: 0x007CD8B3 File Offset: 0x007CBCB3
		protected void _hiddenAllInput()
		{
			if (this.mInputManager != null)
			{
				this.mInputManager.SetVisible(false);
			}
		}

		// Token: 0x06018EBA RID: 102074 RVA: 0x007CD8CC File Offset: 0x007CBCCC
		protected void _showAllInput()
		{
			if (this.mInputManager != null)
			{
				this.mInputManager.SetVisible(true);
			}
		}

		// Token: 0x06018EBB RID: 102075 RVA: 0x007CD8E8 File Offset: 0x007CBCE8
		private void _loadInputManager(BeActor actor)
		{
			this._unloadInputManger();
			if (this.mInputManager == null)
			{
				this.mInputManager = new InputManager();
			}
			if (this.mInputManager != null)
			{
				this.mInputManager.LoadJoystick(Singleton<SettingManager>.GetInstance().GetJoystickMode());
				this.mInputManager.LoadSkillButton(actor);
				this.mInputManager.InitState();
				InputManager.instance = this.mInputManager;
			}
		}

		// Token: 0x06018EBC RID: 102076 RVA: 0x007CD954 File Offset: 0x007CBD54
		protected void _createBase()
		{
			if (this.recordServer != null && this.recordServer.IsProcessRecord())
			{
				this.recordServer.MarkString(142055432U, new string[]
				{
					this.GetBattleType().ToString()
				});
			}
			this.mDungeonManager.CreateBeScene();
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				beScene.CreateDecorator();
				beScene.ClearBossDeadBody();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonAreaChanged, null, null, null, null);
			this._onCreateScene(null);
		}

		// Token: 0x06018EBD RID: 102077 RVA: 0x007CD9EC File Offset: 0x007CBDEC
		protected virtual void _createEntitys()
		{
			if (this.recordServer != null && this.recordServer.IsProcessRecord())
			{
				this.recordServer.Mark(8947848U);
			}
			this._createHealDestruct();
			this._createDoors();
			this._createPlayers();
			this._createRegions();
			this._createMonsters();
			this._createDestructs();
		}

		// Token: 0x06018EBE RID: 102078 RVA: 0x007CDA48 File Offset: 0x007CBE48
		protected virtual bool _isBattleLoadFinish()
		{
			return true;
		}

		// Token: 0x06018EBF RID: 102079 RVA: 0x007CDA4C File Offset: 0x007CBE4C
		protected bool _isNeedSendNet()
		{
			eDungeonMode eDungeonMode = this.mMode;
			return eDungeonMode == eDungeonMode.LocalFrame || eDungeonMode == eDungeonMode.SyncFrame;
		}

		// Token: 0x06018EC0 RID: 102080 RVA: 0x007CDA78 File Offset: 0x007CBE78
		public void PostStart()
		{
			this._onPostStart();
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				this.mDungeonManager.GetBeScene().TriggerEventNew(BeEventSceneType.onEnter, default(EventParam));
			}
			if (GlobalEventSystem.GetInstance() != null)
			{
				GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleInitFinished, null, null, null, null);
			}
			if (Singleton<GameStatisticManager>.instance != null && this.mDungeonManager.GetDungeonDataManager() != null && this.mDungeonManager.GetDungeonDataManager().id != null)
			{
				Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.ENTER, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Empty);
			}
		}

		// Token: 0x06018EC1 RID: 102081 RVA: 0x007CDB44 File Offset: 0x007CBF44
		private void _onAreaClearEvent(object[] args)
		{
			this._onAreaClear(args);
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLEAR_ROOM, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), null);
			if (!this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this._playDungeonClear();
			}
		}

		// Token: 0x06018EC2 RID: 102082 RVA: 0x007CDBA4 File Offset: 0x007CBFA4
		private int _getMainPlayerResourceID()
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null)
			{
				return (int)mainPlayer.playerInfo.occupation;
			}
			return -1;
		}

		// Token: 0x06018EC3 RID: 102083 RVA: 0x007CDBD0 File Offset: 0x007CBFD0
		protected void _playDungeonClear()
		{
			if (this.mBattleType != BattleType.MutiPlayer && this.mBattleType != BattleType.GuildPVP && this.mBattleType != BattleType.PVP3V3Battle && this.mBattleType != BattleType.MoneyRewardsPVP && this.mBattleType != BattleType.ScufflePVP && this.mBattleType != BattleType.ChijiPVP)
			{
				Singleton<VoiceManager>.instance.PlayVoiceByOccupation(VoiceTable.eVoiceType.DUNGEONCLEARROOM, this._getMainPlayerResourceID());
			}
		}

		// Token: 0x06018EC4 RID: 102084 RVA: 0x007CDC3B File Offset: 0x007CC03B
		protected void _playDungeonDead()
		{
		}

		// Token: 0x06018EC5 RID: 102085 RVA: 0x007CDC3D File Offset: 0x007CC03D
		protected void _playDungeonFinish()
		{
			Singleton<VoiceManager>.instance.PlayVoiceByOccupation(VoiceTable.eVoiceType.DUNGEONFINISH, this._getMainPlayerResourceID());
		}

		// Token: 0x06018EC6 RID: 102086 RVA: 0x007CDC50 File Offset: 0x007CC050
		protected void _playDungeonUsePowerSkill()
		{
			Singleton<VoiceManager>.instance.PlayVoiceByOccupation(VoiceTable.eVoiceType.DUNGEONPOWERSKILL, this._getMainPlayerResourceID());
		}

		// Token: 0x06018EC7 RID: 102087 RVA: 0x007CDC63 File Offset: 0x007CC063
		protected void _playDungeonSkillPower()
		{
			Singleton<VoiceManager>.instance.PlayVoiceByOccupation(VoiceTable.eVoiceType.DUNGEONKILLPOWER, this._getMainPlayerResourceID());
		}

		// Token: 0x06018EC8 RID: 102088 RVA: 0x007CDC76 File Offset: 0x007CC076
		protected virtual void _onAreaClear(object[] args)
		{
		}

		// Token: 0x06018EC9 RID: 102089 RVA: 0x007CDC78 File Offset: 0x007CC078
		protected virtual void _onCreateScene(object[] args)
		{
		}

		// Token: 0x06018ECA RID: 102090 RVA: 0x007CDC7A File Offset: 0x007CC07A
		protected virtual void _onDoorStateChange(object[] args)
		{
		}

		// Token: 0x06018ECB RID: 102091 RVA: 0x007CDC7C File Offset: 0x007CC07C
		protected virtual void _onMonsterRemoved(object[] args)
		{
		}

		// Token: 0x06018ECC RID: 102092 RVA: 0x007CDC7E File Offset: 0x007CC07E
		protected virtual void _onMonsterDead(object[] args)
		{
		}

		// Token: 0x06018ECD RID: 102093 RVA: 0x007CDC80 File Offset: 0x007CC080
		protected virtual void _onEggDead(object[] args)
		{
		}

		// Token: 0x06018ECE RID: 102094 RVA: 0x007CDC82 File Offset: 0x007CC082
		protected virtual void _onStart()
		{
		}

		// Token: 0x06018ECF RID: 102095 RVA: 0x007CDC84 File Offset: 0x007CC084
		protected virtual void _onStartResourceLoaded()
		{
		}

		// Token: 0x06018ED0 RID: 102096 RVA: 0x007CDC86 File Offset: 0x007CC086
		protected virtual void _onPostStart()
		{
		}

		// Token: 0x06018ED1 RID: 102097 RVA: 0x007CDC88 File Offset: 0x007CC088
		protected virtual void _onEnd()
		{
		}

		// Token: 0x06018ED2 RID: 102098 RVA: 0x007CDC8A File Offset: 0x007CC08A
		protected virtual void _onRestart()
		{
		}

		// Token: 0x06018ED3 RID: 102099 RVA: 0x007CDC8C File Offset: 0x007CC08C
		protected virtual void _createArea()
		{
		}

		// Token: 0x06018ED4 RID: 102100 RVA: 0x007CDC8E File Offset: 0x007CC08E
		protected virtual void _createRegions()
		{
		}

		// Token: 0x06018ED5 RID: 102101 RVA: 0x007CDC90 File Offset: 0x007CC090
		protected virtual void _createDecorators()
		{
		}

		// Token: 0x06018ED6 RID: 102102 RVA: 0x007CDC92 File Offset: 0x007CC092
		protected virtual void _createHealDestruct()
		{
		}

		// Token: 0x06018ED7 RID: 102103 RVA: 0x007CDC94 File Offset: 0x007CC094
		protected virtual void _createMonsters()
		{
		}

		// Token: 0x06018ED8 RID: 102104 RVA: 0x007CDC96 File Offset: 0x007CC096
		protected virtual void _createDestructs()
		{
		}

		// Token: 0x06018ED9 RID: 102105 RVA: 0x007CDC98 File Offset: 0x007CC098
		protected virtual void _createDoors()
		{
		}

		// Token: 0x06018EDA RID: 102106 RVA: 0x007CDC9A File Offset: 0x007CC09A
		protected virtual void _createPlayers()
		{
		}

		// Token: 0x06018EDB RID: 102107 RVA: 0x007CDC9C File Offset: 0x007CC09C
		protected virtual void _onSceneStart()
		{
		}

		// Token: 0x06018EDC RID: 102108 RVA: 0x007CDC9E File Offset: 0x007CC09E
		protected virtual void _onUpdate(int delta)
		{
		}

		// Token: 0x06018EDD RID: 102109 RVA: 0x007CDCA0 File Offset: 0x007CC0A0
		private bool _playBgm(BaseBattle.BgmNode node)
		{
			if (node != null)
			{
				node.handle = MonoSingleton<AudioManager>.instance.PlaySound(node.path, AudioType.AudioStream, Global.Settings.bgmBattle, true, null, false, false, null, 1f);
				return true;
			}
			return false;
		}

		// Token: 0x06018EDE RID: 102110 RVA: 0x007CDCE1 File Offset: 0x007CC0E1
		private bool _stopBgm(BaseBattle.BgmNode node)
		{
			if (node != null && node.handle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(node.handle);
				node.handle = uint.MaxValue;
				return true;
			}
			return false;
		}

		// Token: 0x06018EDF RID: 102111 RVA: 0x007CDD10 File Offset: 0x007CC110
		public bool PushBgm(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				BaseBattle.BgmNode bgmNode = new BaseBattle.BgmNode
				{
					path = path
				};
				if (this._playBgm(bgmNode))
				{
					if (this.mBgmStack.Count > 0)
					{
						this._stopBgm(this.mBgmStack.Peek());
					}
					this.mBgmStack.Push(bgmNode);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06018EE0 RID: 102112 RVA: 0x007CDD78 File Offset: 0x007CC178
		public void PopBgm()
		{
			if (this.mBgmStack.Count > 0)
			{
				this._stopBgm(this.mBgmStack.Pop());
			}
			if (this.mBgmStack.Count > 0)
			{
				this._playBgm(this.mBgmStack.Peek());
			}
		}

		// Token: 0x06018EE1 RID: 102113 RVA: 0x007CDDCB File Offset: 0x007CC1CB
		public void ClearBgm()
		{
			while (this.mBgmStack.Count > 0)
			{
				this._stopBgm(this.mBgmStack.Pop());
			}
		}

		// Token: 0x06018EE2 RID: 102114 RVA: 0x007CDDF5 File Offset: 0x007CC1F5
		public virtual void BeforeExecFrameCommand(byte seat, IFrameCommand cmd)
		{
		}

		// Token: 0x06018EE3 RID: 102115 RVA: 0x007CDDF8 File Offset: 0x007CC1F8
		public virtual void AfterExecFrameCommand(byte seat, IFrameCommand cmd)
		{
			BattlePlayer battlePlayer = null;
			FrameCommandID id = cmd.GetID();
			switch (id)
			{
			case FrameCommandID.Leave:
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
					if (battlePlayer == null)
					{
						return;
					}
					battlePlayer.onPlayerLeave();
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerLeave, null, null, null, null);
				this._onPlayerLeave(battlePlayer);
				break;
			case FrameCommandID.Reborn:
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
				}
				this._onReborn(battlePlayer);
				break;
			default:
				switch (id)
				{
				case FrameCommandID.TeamCopyRaceEnd:
					this._onTeamCopyRaceEnd();
					if (this.mDungeonManager != null)
					{
						this.mDungeonManager.FinishFight();
					}
					if (!Singleton<ReplayServer>.GetInstance().IsLiveShow())
					{
						FrameSync.instance.SetDungeonMode(eDungeonMode.LocalFrame);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleFrameSyncEnd, null, null, null, null);
					break;
				default:
					if (id == FrameCommandID.GameStart)
					{
						if (this.mDungeonPlayers != null)
						{
							battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
						}
						if (this.mBattleType == BattleType.ScufflePVP)
						{
							this._onGameStartFrame(battlePlayer);
						}
						else if (this.mBattleType == BattleType.PVP3V3Battle || !Singleton<ReplayServer>.GetInstance().IsReplay())
						{
							this._onGameStartFrame(battlePlayer);
						}
					}
					break;
				case FrameCommandID.CancelReborn:
					if (this.mDungeonPlayers != null)
					{
						battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
					}
					this._onPlayerCancelReborn(battlePlayer);
					break;
				}
				break;
			case FrameCommandID.ReconnectEnd:
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
					if (battlePlayer == null)
					{
						return;
					}
					battlePlayer.onPlayerBack();
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerBack, null, null, null, null);
				this._onPlayerBack(battlePlayer);
				break;
			case FrameCommandID.AutoFight:
			{
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
				}
				AutoFightCommand autoFightCommand = cmd as AutoFightCommand;
				if (autoFightCommand != null && battlePlayer != null)
				{
					battlePlayer.isAutoFight = autoFightCommand.openAutoFight;
				}
				break;
			}
			case FrameCommandID.PlayerQuit:
				break;
			case FrameCommandID.RaceEnd:
				this._onRaceEnd();
				if (this.mDungeonManager != null)
				{
					this.mDungeonManager.FinishFight();
				}
				FrameSync.instance.SetDungeonMode(eDungeonMode.LocalFrame);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleFrameSyncEnd, null, null, null, null);
				break;
			case FrameCommandID.NetQuality:
			{
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
				}
				NetQualityCommand netQualityCommand = cmd as NetQualityCommand;
				if (netQualityCommand != null && battlePlayer != null)
				{
					battlePlayer.netQuality = (BattlePlayer.eNetQuality)netQualityCommand.quality;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerInfoChange, null, null, null, null);
				}
				break;
			}
			case FrameCommandID.SceneChangeArea:
				this._onSceneAreaChange();
				break;
			case FrameCommandID.MatchRoundVote:
				if (this.mDungeonPlayers != null)
				{
					battlePlayer = this.mDungeonPlayers.GetPlayerBySeat(seat);
				}
				this._onMatchRoundVote(battlePlayer);
				break;
			}
		}

		// Token: 0x06018EE4 RID: 102116 RVA: 0x007CE0F4 File Offset: 0x007CC4F4
		private void _fireRaceEndOnLocalFrame()
		{
			if (this.mMode == eDungeonMode.LocalFrame)
			{
				RaceEndCommand cmd = new RaceEndCommand();
				FrameSync.instance.FireFrameCommand(cmd, false);
			}
		}

		// Token: 0x06018EE5 RID: 102117 RVA: 0x007CE120 File Offset: 0x007CC520
		protected IEnumerator _fireRaceEndOnLocalFrameIter()
		{
			this._fireRaceEndOnLocalFrame();
			yield return null;
			yield break;
		}

		// Token: 0x06018EE6 RID: 102118 RVA: 0x007CE13B File Offset: 0x007CC53B
		protected virtual void _onMatchRoundVote(BattlePlayer player)
		{
		}

		// Token: 0x06018EE7 RID: 102119 RVA: 0x007CE13D File Offset: 0x007CC53D
		protected virtual void _onRaceEnd()
		{
		}

		// Token: 0x06018EE8 RID: 102120 RVA: 0x007CE13F File Offset: 0x007CC53F
		protected virtual void _onTeamCopyRaceEnd()
		{
		}

		// Token: 0x06018EE9 RID: 102121 RVA: 0x007CE141 File Offset: 0x007CC541
		protected virtual void _onSceneAreaChange()
		{
		}

		// Token: 0x06018EEA RID: 102122 RVA: 0x007CE143 File Offset: 0x007CC543
		protected virtual void _onPlayerLeave(BattlePlayer player)
		{
		}

		// Token: 0x06018EEB RID: 102123 RVA: 0x007CE145 File Offset: 0x007CC545
		protected virtual void _onPlayerBack(BattlePlayer player)
		{
		}

		// Token: 0x06018EEC RID: 102124 RVA: 0x007CE147 File Offset: 0x007CC547
		protected virtual void _onGameStartFrame(BattlePlayer player)
		{
		}

		// Token: 0x06018EED RID: 102125 RVA: 0x007CE149 File Offset: 0x007CC549
		protected virtual void _onReborn(BattlePlayer player)
		{
		}

		// Token: 0x06018EEE RID: 102126 RVA: 0x007CE14B File Offset: 0x007CC54B
		protected virtual void _onPlayerCancelReborn(BattlePlayer player)
		{
		}

		// Token: 0x06018EEF RID: 102127 RVA: 0x007CE14D File Offset: 0x007CC54D
		protected virtual bool _CanFinishFight()
		{
			return true;
		}

		// Token: 0x06018EF0 RID: 102128 RVA: 0x007CE150 File Offset: 0x007CC550
		protected IEnumerator _sendMsgWithResend<T0, T1>(ServerType serverType, MessageEvents msgEvents, T0 req, T1 res, bool isShowWaitFrame = true, float timeout = 2f, int msgWaitCount = 3, int msgResendCount = 3) where T0 : IProtocolStream, IGetMsgID where T1 : IProtocolStream, IGetMsgID
		{
			if (req != null)
			{
				int sendRet = NetManager.Instance().SendCommand<T0>(serverType, req);
			}
			if (res != null)
			{
				uint msgId = res.GetMsgID();
				msgEvents.AddMessage(msgId, true);
				Action<MsgDATA> handle = delegate(MsgDATA recivedMsgData)
				{
					msgEvents.SetMessageData(recivedMsgData.id, recivedMsgData);
				};
				NetProcess.AddMsgHandler(msgId, handle);
				int waitCount = 0;
				int resendCount = 0;
				float tmpTimeout = timeout;
				while (!msgEvents.IsAllMessageReceived())
				{
					if (tmpTimeout > 0f)
					{
						tmpTimeout -= Time.unscaledDeltaTime;
						yield return Yielders.EndOfFrame;
					}
					else
					{
						tmpTimeout = timeout;
						waitCount++;
						if (waitCount >= msgWaitCount)
						{
							waitCount = 0;
							resendCount++;
							if (resendCount > msgResendCount)
							{
								break;
							}
							if (req != null)
							{
								int sendRet = NetManager.Instance().SendCommand<T0>(serverType, req);
							}
						}
					}
				}
				NetProcess.RemoveMsgHandler(msgId, handle);
				if (msgEvents.IsAllMessageReceived())
				{
					MsgDATA messageData = msgEvents.GetMessageData(msgId);
					res.decode(messageData.bytes);
				}
			}
			yield break;
		}

		// Token: 0x06018EF1 RID: 102129 RVA: 0x007CE19C File Offset: 0x007CC59C
		public virtual void Update(int delta)
		{
			if (this.mDungeonManager != null && this.mDungeonManager.GetGeScene() != null)
			{
				this.mDungeonManager.GetGeScene().Update(delta);
			}
			if (this.mInputManager != null)
			{
				this.mInputManager.Update(delta);
			}
			this._onUpdate(delta);
		}

		// Token: 0x06018EF2 RID: 102130 RVA: 0x007CE1F3 File Offset: 0x007CC5F3
		public virtual void FrameUpdate(int delta)
		{
		}

		// Token: 0x06018EF3 RID: 102131 RVA: 0x007CE1F8 File Offset: 0x007CC5F8
		private void PreloadJobRes(BattlePlayer player)
		{
			List<int> skillList = BattlePlayer.GetSkillList(player.playerInfo);
			for (int i = 0; i < skillList.Count; i++)
			{
				SkillPreTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillPreTable>(skillList[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (player.IsLocalPlayer() && tableItem.LocalInfoID.Count > 0)
					{
						for (int j = 0; j < tableItem.LocalInfoID.Length; j++)
						{
							SkillPreInfoTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillPreInfoTable>(tableItem.LocalInfoID[j], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								MonoSingleton<CResPreloader>.instance.AddRes(tableItem2.Path, false, tableItem2.Count, null, 0, null, CResPreloader.ResType.OBJECT, null);
							}
						}
					}
					if (tableItem.InfoID.Count > 0)
					{
						for (int k = 0; k < tableItem.InfoID.Length; k++)
						{
							SkillPreInfoTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SkillPreInfoTable>(tableItem.InfoID[k], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								MonoSingleton<CResPreloader>.instance.AddRes(tableItem3.Path, false, tableItem3.Count, null, 0, null, CResPreloader.ResType.OBJECT, null);
							}
						}
					}
				}
			}
		}

		// Token: 0x06018EF4 RID: 102132 RVA: 0x007CE348 File Offset: 0x007CC748
		public void InitLevelManager()
		{
			if (this.dungeonManager == null)
			{
				return;
			}
			if (this.dungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			if (this.dungeonManager.GetDungeonDataManager().table == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.dungeonManager.GetDungeonDataManager().table.dungeonLevelPath))
			{
				return;
			}
			this.mLevelMgr = new LevelManager();
			this.mLevelMgr.Init(this.dungeonManager.GetDungeonDataManager().table.dungeonLevelPath, this);
		}

		// Token: 0x06018EF5 RID: 102133 RVA: 0x007CE3D8 File Offset: 0x007CC7D8
		public void SetDungeonClearInfo(uint[] IdArr)
		{
			string arg = string.Empty;
			for (int i = 0; i < IdArr.Length; i++)
			{
				arg += IdArr[i];
			}
			if (this.recordServer == null || this.recordServer.IsProcessRecord())
			{
			}
		}

		// Token: 0x04011ED8 RID: 73432
		protected InputManager mInputManager;

		// Token: 0x04011ED9 RID: 73433
		private eDungeonMode mMode;

		// Token: 0x04011EDA RID: 73434
		private BattleType mBattleType = BattleType.None;

		// Token: 0x04011EDB RID: 73435
		protected IDungeonPlayerDataManager mDungeonPlayers;

		// Token: 0x04011EDC RID: 73436
		protected IDungeonManager mDungeonManager;

		// Token: 0x04011EDD RID: 73437
		protected IDungeonStatistics mDungeonStatistics;

		// Token: 0x04011EDE RID: 73438
		protected IDungeonEnumeratorManager mDungeonEnumeratorManager;

		// Token: 0x04011EDF RID: 73439
		protected FrameRandomImp mframeRandom = new FrameRandomImp();

		// Token: 0x04011EE0 RID: 73440
		protected TrailManagerImp mTrialManager;

		// Token: 0x04011EE1 RID: 73441
		protected BeProjectilePoolImp mProjectilePool;

		// Token: 0x04011EE2 RID: 73442
		protected BeAICommandPoolImp mAICommandPool;

		// Token: 0x04011EE3 RID: 73443
		protected List<int> playerRoleIDList = new List<int>();

		// Token: 0x04011EE4 RID: 73444
		protected int pkRaceType = -1;

		// Token: 0x04011EE5 RID: 73445
		protected LevelManager mLevelMgr;

		// Token: 0x04011EE6 RID: 73446
		private int m_loadingStep;

		// Token: 0x04011EE7 RID: 73447
		protected ulong _battleFlag;

		// Token: 0x04011EE8 RID: 73448
		private BattleResult _PveBattleResult;

		// Token: 0x04011EE9 RID: 73449
		protected RecordServer mRecordServer = Singleton<RecordServer>.GetInstance();

		// Token: 0x04011EEA RID: 73450
		private LogicServer mLogicServer;

		// Token: 0x04011EEB RID: 73451
		private Stack<BaseBattle.BgmNode> mBgmStack = new Stack<BaseBattle.BgmNode>();

		// Token: 0x020045A8 RID: 17832
		private class BgmNode
		{
			// Token: 0x04011EEC RID: 73452
			public string path = string.Empty;

			// Token: 0x04011EED RID: 73453
			public uint handle = uint.MaxValue;
		}
	}
}
