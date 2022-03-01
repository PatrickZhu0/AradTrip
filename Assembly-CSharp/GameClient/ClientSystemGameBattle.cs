using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Battle;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200113A RID: 4410
	public class ClientSystemGameBattle : ClientSystem
	{
		// Token: 0x170019EC RID: 6636
		// (get) Token: 0x0600A7E8 RID: 42984 RVA: 0x00231561 File Offset: 0x0022F961
		public ISceneData LevelData
		{
			get
			{
				return this._levelData;
			}
		}

		// Token: 0x170019ED RID: 6637
		// (get) Token: 0x0600A7E9 RID: 42985 RVA: 0x00231569 File Offset: 0x0022F969
		public float AxisScale
		{
			get
			{
				return this._axisScale;
			}
		}

		// Token: 0x170019EE RID: 6638
		// (get) Token: 0x0600A7EA RID: 42986 RVA: 0x00231571 File Offset: 0x0022F971
		public Vector3 ServerToClient
		{
			get
			{
				return this._serverToClient;
			}
		}

		// Token: 0x170019EF RID: 6639
		// (get) Token: 0x0600A7EB RID: 42987 RVA: 0x00231579 File Offset: 0x0022F979
		public BePoison PoisonRing
		{
			get
			{
				return this.mPoisonRing;
			}
		}

		// Token: 0x170019F0 RID: 6640
		// (get) Token: 0x0600A7EC RID: 42988 RVA: 0x00231581 File Offset: 0x0022F981
		public BeFighterManager<BeItem> Items
		{
			get
			{
				return this._beTownItems;
			}
		}

		// Token: 0x170019F1 RID: 6641
		// (get) Token: 0x0600A7ED RID: 42989 RVA: 0x00231589 File Offset: 0x0022F989
		public BeFighterManager<BeFighter> OtherFighters
		{
			get
			{
				return this.mFighters;
			}
		}

		// Token: 0x170019F2 RID: 6642
		// (get) Token: 0x0600A7EE RID: 42990 RVA: 0x00231591 File Offset: 0x0022F991
		public BeFighterManager<BeBattleProjectile> Projectiles
		{
			get
			{
				return this._beProjectiles;
			}
		}

		// Token: 0x170019F3 RID: 6643
		// (get) Token: 0x0600A7EF RID: 42991 RVA: 0x00231599 File Offset: 0x0022F999
		public Dictionary<ulong, BeFightBuffManager> OtherFighterBuffs
		{
			get
			{
				return this._beTownPlayerBuffs;
			}
		}

		// Token: 0x170019F4 RID: 6644
		// (get) Token: 0x0600A7F0 RID: 42992 RVA: 0x002315A1 File Offset: 0x0022F9A1
		// (set) Token: 0x0600A7F1 RID: 42993 RVA: 0x002315A9 File Offset: 0x0022F9A9
		public int CurrentSceneID
		{
			get
			{
				return this._currentSceneId;
			}
			private set
			{
				if (this._fromSceneId != this._currentSceneId && this._currentSceneId != -1)
				{
					this._fromSceneId = this._currentSceneId;
				}
				this._currentSceneId = value;
			}
		}

		// Token: 0x170019F5 RID: 6645
		// (get) Token: 0x0600A7F2 RID: 42994 RVA: 0x002315DB File Offset: 0x0022F9DB
		public int FromSceneID
		{
			get
			{
				return this._fromSceneId;
			}
		}

		// Token: 0x170019F6 RID: 6646
		// (get) Token: 0x0600A7F3 RID: 42995 RVA: 0x002315E3 File Offset: 0x0022F9E3
		// (set) Token: 0x0600A7F4 RID: 42996 RVA: 0x002315EB File Offset: 0x0022F9EB
		private bool isTownSceneSwitching
		{
			get
			{
				return this.mIsTownSceneSwitching;
			}
			set
			{
				this.mIsTownSceneSwitching = value;
			}
		}

		// Token: 0x170019F7 RID: 6647
		// (get) Token: 0x0600A7F5 RID: 42997 RVA: 0x002315F4 File Offset: 0x0022F9F4
		public BeFighterMain MainPlayer
		{
			get
			{
				return this.mMainPlayer;
			}
		}

		// Token: 0x0600A7F6 RID: 42998 RVA: 0x002315FC File Offset: 0x0022F9FC
		public void SetTargetSceneID(int iTargetSceneID)
		{
			this.m_targetSceneID = iTargetSceneID;
		}

		// Token: 0x0600A7F7 RID: 42999 RVA: 0x00231608 File Offset: 0x0022FA08
		public void SetPoisonRing(int x, int y, int radius, uint timeStamp, int durTime, Vector2 lastCenter, float lastRadius)
		{
			if (this.mPoisonRing == null)
			{
				BePoison.BePoisonData bePoisonData = new BePoison.BePoisonData
				{
					radius = (float)radius / this._axisScale,
					x = x,
					y = y,
					startTime = timeStamp,
					durTime = durTime,
					realPos = new Vector3((float)x / this._axisScale, 0f, (float)y / this._axisScale)
				};
				this.mPoisonRing = new BePoison(bePoisonData, this);
				this.mPoisonRing.ActorData.MoveData.PosLogicToGraph = this._logicToGraph;
				this.mPoisonRing.ActorData.MoveData.PosServerToClient = this._serverToClient;
				BePoison.BePoisonData bePoisonData2 = this.mPoisonRing.ActorData as BePoison.BePoisonData;
				bePoisonData2.MoveData.ServerPosition = bePoisonData.realPos;
				this.mPoisonRing.ResetStartInfo(lastRadius, lastCenter);
				this.mPoisonRing.InitGeActor(this._geScene);
			}
			else
			{
				this.mPoisonRing.ResetCircle();
				BePoison.BePoisonData bePoisonData3 = this.mPoisonRing.ActorData as BePoison.BePoisonData;
				bePoisonData3.x = x;
				bePoisonData3.y = y;
				bePoisonData3.radius = (float)radius / this._axisScale;
				bePoisonData3.startTime = timeStamp;
				bePoisonData3.durTime = durTime;
				bePoisonData3.realPos = new Vector3((float)bePoisonData3.x / this._axisScale, 0f, (float)bePoisonData3.y / this._axisScale);
				this.mPoisonRing.StartShrink();
			}
		}

		// Token: 0x0600A7F8 RID: 43000 RVA: 0x00231781 File Offset: 0x0022FB81
		public sealed override string GetMainUIPrefabName()
		{
			return string.Empty;
		}

		// Token: 0x0600A7F9 RID: 43001 RVA: 0x00231788 File Offset: 0x0022FB88
		public sealed override void GetEnterCoroutine(AddCoroutine enter)
		{
			enter(new loadingCoroutine(base._baseSystemLoadingCoroutine), string.Empty, 1f);
			enter(new loadingCoroutine(this.FightLoadingCoroutine), string.Empty, 1f);
		}

		// Token: 0x170019F8 RID: 6648
		// (get) Token: 0x0600A7FA RID: 43002 RVA: 0x002317C4 File Offset: 0x0022FBC4
		// (set) Token: 0x0600A7FB RID: 43003 RVA: 0x002317CC File Offset: 0x0022FBCC
		public PathFinding.GridInfo GridInfo { get; private set; }

		// Token: 0x0600A7FC RID: 43004 RVA: 0x002317D5 File Offset: 0x0022FBD5
		protected sealed override string _GetLevelName()
		{
			return "Town";
		}

		// Token: 0x0600A7FD RID: 43005 RVA: 0x002317DC File Offset: 0x0022FBDC
		protected IEnumerator FightLoadingCoroutine(IASyncOperation systemOperation)
		{
			int beginTimeStamp = Environment.TickCount;
			Time.timeScale = 1f;
			Singleton<ClientSystemManager>.instance.delayCaller.Clear();
			if (base.SystemManager.CurrentSystem == null)
			{
				yield return this._SystemInitWithoutNet(systemOperation);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveAllListeners();
				UnityEvent onSwitchSystemFinished = Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished;
				if (ClientSystemGameBattle.<>f__mg$cache0 == null)
				{
					ClientSystemGameBattle.<>f__mg$cache0 = new UnityAction(ClientSystemGameBattle._NextFuncOpen);
				}
				onSwitchSystemFinished.AddListener(ClientSystemGameBattle.<>f__mg$cache0);
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
				this._BindUIEvent();
				DataManager<ItemDataManager>.GetInstance().AddSystemInvoke();
				Type systemType = base.SystemManager.CurrentSystem.GetType();
				if (systemType == typeof(ClientSystemTown) || DataManager<ChijiDataManager>.GetInstance().IsToPrepareScene)
				{
					this.m_targetSceneID = 10101;
				}
				else if (systemType == typeof(ClientSystemBattle))
				{
					this.m_targetSceneID = 10100;
				}
				DataManager<ChijiDataManager>.GetInstance().IsToPrepareScene = false;
				yield return this._SystemInitEnterToChijiSystem(systemOperation);
			}
			yield return ClientSystemManager._PreloadRes(systemOperation);
			if (EngineConfig.usePrewarmFrame)
			{
				yield return this._PrewarmFrames();
			}
			yield return Yielders.EndOfFrame;
			Singleton<ReplayServer>.GetInstance().Clear();
			int endTimeStamp = Environment.TickCount;
			Logger.LogErrorFormat(string.Format("吃鸡流程日志----FightLoadingCoroutine consumeTime {0}", endTimeStamp - beginTimeStamp), new object[0]);
			yield break;
		}

		// Token: 0x0600A7FE RID: 43006 RVA: 0x00231800 File Offset: 0x0022FC00
		public sealed override void OnEnter()
		{
			if (Global.Settings.displayHUD)
			{
				MonoSingleton<HUDInfoViewer>.instance.Init();
			}
			base.OnEnter();
			MonoSingleton<NetManager>.instance.ClearReSendData();
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.Asset, true);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.SceneActor, true);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.UIFrame, true);
			CameraAspectAdjust.MarkDirty();
			this._resetIsSwiching();
		}

		// Token: 0x0600A7FF RID: 43007 RVA: 0x00231868 File Offset: 0x0022FC68
		public sealed override void OnExit()
		{
			this._resetIsSwiching();
			if (this.m_BgmHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.m_BgmHandle);
			}
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.Asset, false);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.SceneActor, false);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.UIFrame, false);
			this.ClearScene(true);
			BeFighterMain.CommandStopAutoMove();
			this._UnBindUIEvent();
			this._ClearData();
			this.ClearBaseMainFrame();
			if (base.SystemManager.TargetSystem != null)
			{
				Type type = base.SystemManager.TargetSystem.GetType();
				if (type != null && type != typeof(ClientSystemBattle))
				{
					MonoSingleton<ManualPoolCollector>.instance.Clear();
				}
			}
			base.OnExit();
		}

		// Token: 0x0600A800 RID: 43008 RVA: 0x00231920 File Offset: 0x0022FD20
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this.UpdateScene(timeElapsed);
			this._UpdateData(timeElapsed);
			this._UpdateNpcDialog(timeElapsed);
			this._OnUpdateDelayCreateCache();
			this._OnUpdateDelayCreateItemCache();
			this._OnUpdateChiji(timeElapsed);
		}

		// Token: 0x0600A801 RID: 43009 RVA: 0x0023194C File Offset: 0x0022FD4C
		public BeNPC GetNpcByGuid(int iNpcId, ulong _npcGuid)
		{
			for (int i = 0; i < this._beNPCs.GetFightCount(); i++)
			{
				BeNPC fighter = this._beNPCs.GetFighter(i);
				if (fighter != null)
				{
					BeNPCData beNPCData = fighter.ActorData as BeNPCData;
					if (beNPCData != null)
					{
						if (beNPCData.NpcID == iNpcId && beNPCData.GUID == _npcGuid)
						{
							return fighter;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600A802 RID: 43010 RVA: 0x002319C0 File Offset: 0x0022FDC0
		private void _UpdateNpcDialog(float timeElapsed)
		{
			float num = 4.8f;
			if (this.MainPlayer != null)
			{
				if (this.m_kCurrentDialogComponent == null)
				{
					for (int i = 0; i < this._beNPCs.GetFightCount(); i++)
					{
						BeNPC fighter = this._beNPCs.GetFighter(i);
						if (fighter != null && fighter.GraphicActor != null && null != fighter.GraphicActor.NpcDialogComponent)
						{
							NpcDialogComponent npcDialogComponent = fighter.GraphicActor.NpcDialogComponent;
							if (npcDialogComponent != null)
							{
								Vector3 vector = fighter.ActorData.MoveData.Position - this.MainPlayer.ActorData.MoveData.Position;
								vector.y = 0f;
								float num2 = Mathf.Sqrt(vector.sqrMagnitude);
								if (num >= num2 && (this.m_kCurrentDialogComponent == null || this.m_kCurrentDialogComponent.TickPower > npcDialogComponent.TickPower || (this.m_kCurrentDialogComponent.TickPower == npcDialogComponent.TickPower && this.m_kCurrentDialogComponent.NextTick > npcDialogComponent.NextTick)))
								{
									this.m_kCurrentDialogComponent = npcDialogComponent;
								}
							}
						}
					}
					if (this.m_kCurrentDialogComponent != null)
					{
						this.m_kCurrentDialogComponent.BeginTick();
					}
				}
				if (this.m_kCurrentDialogComponent != null)
				{
					if (this.m_kCurrentDialogComponent.InTick)
					{
						this.m_kCurrentDialogComponent.Tick(timeElapsed);
					}
					else
					{
						this.m_kCurrentDialogComponent.EndTick();
						this.m_kCurrentDialogComponent = null;
					}
				}
			}
		}

		// Token: 0x0600A803 RID: 43011 RVA: 0x00231B60 File Offset: 0x0022FF60
		private void _UpdateData(float delta)
		{
			List<Battle.DungeonBuff> buffList = DataManager<PlayerBaseData>.GetInstance().buffList;
			bool flag = false;
			for (int i = 0; i < buffList.Count; i++)
			{
				Battle.DungeonBuff dungeonBuff = buffList[i];
				if (dungeonBuff.type == Battle.DungeonBuff.eBuffDurationType.Town || dungeonBuff.type == Battle.DungeonBuff.eBuffDurationType.SpecialTown)
				{
					dungeonBuff.lefttime -= delta;
					if (dungeonBuff.lefttime < 0f)
					{
						dungeonBuff.readymove = true;
						flag = true;
					}
				}
			}
			if (flag)
			{
				buffList.RemoveAll(new Predicate<Battle.DungeonBuff>(this.CheckCanRemoveBuff));
			}
			DataManager<PlayerBaseData>.GetInstance().BuffMgr.Update(delta);
		}

		// Token: 0x0600A804 RID: 43012 RVA: 0x00231C00 File Offset: 0x00230000
		private bool CheckCanRemoveBuff(Battle.DungeonBuff x)
		{
			if (x.readymove)
			{
				DataManager<PlayerBaseData>.GetInstance().removedBuffList.Add(x);
			}
			return x.readymove;
		}

		// Token: 0x0600A805 RID: 43013 RVA: 0x00231C24 File Offset: 0x00230024
		protected void UpdateScene(float timeElapsed)
		{
			if (this.mMainPlayer != null)
			{
				this.mMainPlayer.Update(timeElapsed);
			}
			this.mFighters.Update(timeElapsed);
			if (this._geScene != null)
			{
				this._geScene.Update((int)(timeElapsed * (float)GlobalLogic.VALUE_1000));
			}
			this._beNPCs.Update((float)((int)(timeElapsed * (float)GlobalLogic.VALUE_1000)));
			this.mRemoveBuffItem.Clear();
			bool flag = false;
			for (int i = 0; i < this.mBuffItem.Count; i++)
			{
				BeItem beItem = this.mBuffItem[i];
				if (beItem != null)
				{
					if (!beItem.IsRemoved)
					{
						beItem.Update(timeElapsed);
					}
					else
					{
						this._beTownItems.RemoveFighter(beItem.ActorData.GUID);
						flag = true;
						this.mRemoveBuffItem.Add(i);
					}
				}
				else
				{
					flag = true;
					this.mRemoveBuffItem.Add(i);
				}
			}
			if (flag)
			{
				this._beTownItems.Refresh();
			}
			for (int j = this.mRemoveBuffItem.Count - 1; j >= 0; j--)
			{
				this.mBuffItem.RemoveAt(this.mRemoveBuffItem[j]);
			}
			this._beProjectiles.Update(timeElapsed);
			if (this.mPoisonRing != null)
			{
				this.mPoisonRing.Update(timeElapsed);
			}
			if (this.mMainPlayer != null)
			{
				DataManager<PlayerBaseData>.GetInstance().Pos = this.mMainPlayer.ActorData.MoveData.ServerPosition;
				DataManager<PlayerBaseData>.GetInstance().FaceRight = this.mMainPlayer.ActorData.MoveData.FaceRight;
			}
		}

		// Token: 0x0600A806 RID: 43014 RVA: 0x00231DC4 File Offset: 0x002301C4
		public void DoTrap(ulong itemObjID, uint count = 0U)
		{
			if (this.mMainPlayer == null)
			{
				return;
			}
			SceneBattlePlaceTrapsReq cmd = new SceneBattlePlaceTrapsReq
			{
				itemGuid = itemObjID,
				itemCount = count,
				x = (uint)(this.mMainPlayer.ActorData.MoveData.ServerPosition.x * this._axisScale),
				y = (uint)(this.mMainPlayer.ActorData.MoveData.ServerPosition.z * this._axisScale)
			};
			NetManager.Instance().SendCommand<SceneBattlePlaceTrapsReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600A807 RID: 43015 RVA: 0x00231E58 File Offset: 0x00230258
		public void DoTrapEffect(uint x, uint y)
		{
			string effectPath = "Effects/Scene_effects/Scene_Chiji/Prefab/Eff_Scene_Chiji_baozha";
			Vector3 vector;
			vector..ctor(x / this._axisScale, 0f, y / this._axisScale);
			Vector3 vector2 = vector + this._serverToClient;
			Vec3 initPos = new Vec3(vector2.x, vector2.z, vector2.y);
			this._geScene.CreateEffect(effectPath, 0f, initPos, 1f, 1f, false, false);
		}

		// Token: 0x0600A808 RID: 43016 RVA: 0x00231ED4 File Offset: 0x002302D4
		protected void _OnUpdateChiji(float timeElapsed)
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.Battle)
			{
				return;
			}
			this.fChijiItemRefreshTime += timeElapsed;
			if (this.fChijiItemRefreshTime < this.fChijiTimeInterval)
			{
				return;
			}
			this.fChijiItemRefreshTime = 0f;
			List<BeItem> list = this.MainPlayer.FindNearestTownItems();
			if (list != null && list.Count > 0)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MapItemFrame>(null))
				{
					MapItemFrame mapItemFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(MapItemFrame)) as MapItemFrame;
					if (this.MainPlayer.MoveState >= BeFighterMain.EMoveState.Moveing || this.ChijiNearItemNum != list.Count)
					{
						mapItemFrame.RefreshNearItemListCount();
						this.ChijiNearItemNum = list.Count;
					}
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MapItemFrame>(FrameLayer.BelowMiddle, null, string.Empty);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MapItemFrame>(null, false);
			}
		}

		// Token: 0x0600A809 RID: 43017 RVA: 0x00231FE0 File Offset: 0x002303E0
		private void _resetIsSwiching()
		{
			this.isTownSceneSwitching = false;
			this._isSwithScene = false;
		}

		// Token: 0x0600A80A RID: 43018 RVA: 0x00231FF0 File Offset: 0x002303F0
		protected void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnJobIDChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetChanged, new ClientEventSystem.UIEventHandler(this._OnPetChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateChijiNpcData, new ClientEventSystem.UIEventHandler(this._OnUpdateChijiNpcData));
		}

		// Token: 0x0600A80B RID: 43019 RVA: 0x0023204C File Offset: 0x0023044C
		protected void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnJobIDChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetChanged, new ClientEventSystem.UIEventHandler(this._OnPetChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateChijiNpcData, new ClientEventSystem.UIEventHandler(this._OnUpdateChijiNpcData));
		}

		// Token: 0x0600A80C RID: 43020 RVA: 0x002320A7 File Offset: 0x002304A7
		private void _OnJobIDChanged(UIEvent iEvent)
		{
			this.DestroyMainPlayer();
			this.CreateMainPlayer();
			this._InitializeCameraController();
		}

		// Token: 0x0600A80D RID: 43021 RVA: 0x002320BC File Offset: 0x002304BC
		protected void _InitializeCameraController()
		{
			if (this.mMainPlayer == null)
			{
				Logger.LogError("_InitializeCameraController ==> _beTownPlayerMain == null");
				return;
			}
			if (this._levelData == null)
			{
				Logger.LogError("_InitializeCameraController ==> _levelData == null");
				return;
			}
			this._geScene.GetCamera().GetController().AttachTo(this.mMainPlayer.GraphicActor, this._levelData.GetCameraLookHeight(), this._levelData.GetCameraAngle(), this._levelData.GetCameraDistance());
			this._geScene.initScrollScript();
		}

		// Token: 0x0600A80E RID: 43022 RVA: 0x00232144 File Offset: 0x00230544
		protected void _InitializeBGM(string path)
		{
			if (this.m_BgmHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.m_BgmHandle);
			}
			this.m_BgmHandle = MonoSingleton<AudioManager>.instance.PlaySound(path, AudioType.AudioStream, 1f, true, null, false, false, null, 1f);
		}

		// Token: 0x0600A80F RID: 43023 RVA: 0x0023218E File Offset: 0x0023058E
		private void DestroyMainPlayer()
		{
			if (this.mMainPlayer != null)
			{
				this.mMainPlayer.Dispose();
				this.mMainPlayer = null;
			}
		}

		// Token: 0x0600A810 RID: 43024 RVA: 0x002321B0 File Offset: 0x002305B0
		private void CreateMainPlayer()
		{
			Vec3 vec = Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
			PetInfo followPet = DataManager<PetDataManager>.GetInstance().GetFollowPet();
			BeFighterData beFighterData = new BeFighterData
			{
				GUID = DataManager<PlayerBaseData>.GetInstance().RoleID,
				Name = DataManager<PlayerBaseData>.GetInstance().Name,
				JobID = DataManager<PlayerBaseData>.GetInstance().JobTableID,
				RoleLv = DataManager<PlayerBaseData>.GetInstance().Level,
				pkRank = DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				NameColor = PlayerInfoColor.TOWN_PLAYER,
				tittle = 0U,
				GuildPost = DataManager<PlayerBaseData>.GetInstance().guildDuty,
				GuildName = DataManager<PlayerBaseData>.GetInstance().guildName,
				petID = (int)((followPet == null) ? 0U : followPet.dataId),
				ZoneID = DataManager<PlayerBaseData>.GetInstance().ZoneID,
				AdventureTeamName = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamName(),
				WearedTitleInfo = DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo,
				GuildEmblemLv = (int)DataManager<PlayerBaseData>.GetInstance().GuildEmblemLv
			};
			beFighterData.MoveData.PosLogicToGraph = this._logicToGraph;
			beFighterData.MoveData.PosServerToClient = this._serverToClient;
			beFighterData.MoveData.ServerPosition = DataManager<PlayerBaseData>.GetInstance().Pos;
			beFighterData.MoveData.FaceRight = DataManager<PlayerBaseData>.GetInstance().FaceRight;
			beFighterData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * DataManager<PlayerBaseData>.GetInstance().MoveSpeedRate;
			this.mMainPlayer = new BeFighterMain(beFighterData, this);
			this.mMainPlayer.InitGeActor(this._geScene);
			BeFightBuffManager buffMgr = DataManager<PlayerBaseData>.GetInstance().BuffMgr;
			for (int i = 0; i < buffMgr.Count(); i++)
			{
				BeFightBuff beFightBuff = buffMgr.Get(i);
				if (beFightBuff != null)
				{
					beFightBuff.Start(this.mMainPlayer.GraphicActor);
				}
			}
			if (DataManager<ChijiDataManager>.GetInstance().IsMainPlayerDead)
			{
				this.mMainPlayer.SetDead();
			}
			BeFighterMain.OnMoveing.RemoveListener(new UnityAction<Vector3>(this._onMainPlayerMoveing));
			BeFighterMain.OnMoveing.AddListener(new UnityAction<Vector3>(this._onMainPlayerMoveing));
			BeFighterMain.OnAutoMoving.RemoveListener(new UnityAction<Vector3>(this._onMainPlayerAutoMoving));
			BeFighterMain.OnAutoMoving.AddListener(new UnityAction<Vector3>(this._onMainPlayerAutoMoving));
			BeFighterMain.OnAutoMoveFail.RemoveListener(new UnityAction(this._onMainPlayerAutoMoveFail));
			BeFighterMain.OnAutoMoveFail.AddListener(new UnityAction(this._onMainPlayerAutoMoveFail));
			BeFighterMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this._onMainPlayerAutoMoveSucc));
			BeFighterMain.OnAutoMoveSuccess.AddListener(new UnityAction(this._onMainPlayerAutoMoveSucc));
		}

		// Token: 0x0600A811 RID: 43025 RVA: 0x0023246F File Offset: 0x0023086F
		private void _SetMainPlayerShowFindPath(bool isShow)
		{
			if (this.mMainPlayer != null && this.mMainPlayer.GraphicActor != null)
			{
				this.mMainPlayer.GraphicActor.ShowFindPath(isShow);
			}
		}

		// Token: 0x0600A812 RID: 43026 RVA: 0x0023249D File Offset: 0x0023089D
		private void _onMainPlayerAutoMoveSucc()
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600A813 RID: 43027 RVA: 0x002324A6 File Offset: 0x002308A6
		private void _onMainPlayerAutoMoveFail()
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600A814 RID: 43028 RVA: 0x002324AF File Offset: 0x002308AF
		private void _onMainPlayerAutoMoving(Vector3 pos)
		{
			this._SetMainPlayerShowFindPath(true);
		}

		// Token: 0x0600A815 RID: 43029 RVA: 0x002324B8 File Offset: 0x002308B8
		private void _onMainPlayerMoveing(Vector3 pos)
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600A816 RID: 43030 RVA: 0x002324C4 File Offset: 0x002308C4
		private void _OnPetChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				uint a_nPetID = (uint)a_event.Param1;
				this.MainPlayer.CreatePet((int)a_nPetID);
			}
		}

		// Token: 0x0600A817 RID: 43031 RVA: 0x002324F4 File Offset: 0x002308F4
		private void _OnUpdateChijiNpcData(UIEvent a_event)
		{
			this._CreateDynamicNpcs();
			List<BattleNpc> npcDataList = DataManager<ChijiDataManager>.GetInstance().NpcDataList;
		}

		// Token: 0x0600A818 RID: 43032 RVA: 0x00232512 File Offset: 0x00230912
		private void _ClearData()
		{
			this.fChijiItemRefreshTime = 0f;
		}

		// Token: 0x0600A819 RID: 43033 RVA: 0x0023251F File Offset: 0x0023091F
		protected static void _NextFuncOpen()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NextFuncOpen, null, null, null, null);
		}

		// Token: 0x0600A81A RID: 43034 RVA: 0x00232534 File Offset: 0x00230934
		protected IEnumerator _SystemInitEnterGame(IASyncOperation systemOperation, bool initwithNewbieGuideBattle = false)
		{
			IEnumerator process = this._systemInitEnterGameProcess(systemOperation, initwithNewbieGuideBattle);
			ThreeStepProcess threeStepprocess = new ThreeStepProcess("SystemInitEnterGame", Singleton<ClientSystemManager>.instance.enumeratorManager, process, null, null);
			threeStepprocess.SetErrorProcessHandle(new ThreeStepProcess.ErrorProcessHandle(this._errorProcess));
			yield return threeStepprocess;
			yield break;
		}

		// Token: 0x0600A81B RID: 43035 RVA: 0x00232560 File Offset: 0x00230960
		private IEnumerator _systemInitEnterGameProcess(IASyncOperation systemOperation, bool initwithNewbieGuideBattle = false)
		{
			Singleton<PlayerDataManager>.GetInstance().InitiallizeSystem();
			GateEnterGameReq enterGame = new GateEnterGameReq
			{
				roleId = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin().roleId,
				city = string.Empty,
				inviter = 0U,
				option = 0
			};
			NetManager netMgr = NetManager.Instance();
			netMgr.SendCommand<GateEnterGameReq>(ServerType.GATE_SERVER, enterGame);
			EEnterGameState eEnterState = EEnterGameState.Invalid;
			WaitNetMessageManager.NetMessages netMsgs = null;
			List<uint> arrWaitMsgIDs = new List<uint>
			{
				500303U,
				500602U,
				300307U
			};
			arrWaitMsgIDs.AddRange(EEnterGameWaitMsg.msgs);
			Singleton<PlayerDataManager>.GetInstance().BindEnterGameMsg(arrWaitMsgIDs);
			WaitNetMessageManager.WaitMulti wait = DataManager<WaitNetMessageManager>.GetInstance().Wait(arrWaitMsgIDs.ToArray(), delegate(WaitNetMessageManager.NetMessages msgRets)
			{
				GateEnterGameRet gateEnterGameRet = new GateEnterGameRet();
				gateEnterGameRet.decode(msgRets.GetMessageData(300307U).bytes);
				if (gateEnterGameRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)gateEnterGameRet.result, string.Empty);
					eEnterState = EEnterGameState.LoginInError;
					return;
				}
				Singleton<PlayerDataManager>.GetInstance().ProcessInitNetMessage(msgRets);
				netMsgs = msgRets;
				eEnterState = EEnterGameState.Success;
			}, true, 120f, delegate()
			{
				eEnterState = EEnterGameState.TimeOut;
			});
			while (eEnterState == EEnterGameState.Invalid)
			{
				yield return Yielders.EndOfFrame;
			}
			if (!initwithNewbieGuideBattle)
			{
				systemOperation.SetProgress(0.6f);
			}
			if (eEnterState == EEnterGameState.TimeOut)
			{
				systemOperation.SetError("[TownEnterGame] 预先消息列表各种消息超时");
				Logger.LogErrorFormat(wait.m_netMessage.GetUnReceivedMessageDesc(), new object[0]);
				yield return new NormalCustomEnumError("[TownEnterGame] 预先消息列表各种消息超时", eEnumError.NetworkErrorDisconnect);
				yield break;
			}
			if (eEnterState == EEnterGameState.LoginInError)
			{
				systemOperation.SetError(string.Empty);
				yield return new NormalCustomEnumError("[TownEnterGame] 进入游戏等待消息结果错误", eEnumError.ProcessError);
				yield break;
			}
			this.IsNet = true;
			if (!initwithNewbieGuideBattle)
			{
				systemOperation.SetProgress(0.7f);
			}
			yield return Yielders.EndOfFrame;
			SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
			msgEnterScene.decode(netMsgs.GetMessageData(500303U).bytes);
			if (msgEnterScene.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgEnterScene.result, string.Empty);
				yield break;
			}
			if (msgEnterScene.mapid == 0U)
			{
				yield return new NormalCustomEnumError("[TownEnterGame] mapID无效", eEnumError.ProcessError);
				yield break;
			}
			DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
			this._InitOtherPlayerData(netMsgs.GetMessageData(500602U), msgEnterScene.mapid);
			if (SwitchFunctionUtility.IsOpen(103))
			{
				this.InitializeScene((int)msgEnterScene.mapid, msgEnterScene.mapid == 10100U);
			}
			else
			{
				this.InitializeScene((int)msgEnterScene.mapid, false);
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600A81C RID: 43036 RVA: 0x0023258C File Offset: 0x0023098C
		protected IEnumerator _SystemInitEnterToChijiSystem(IASyncOperation systemOperation)
		{
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.RELAY_SERVER);
			MessageEvents msgEvents = new MessageEvents();
			msgEvents.AddMessage(500602U, true);
			SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
			if (this.m_targetSceneID != -1 && this.m_targetSceneID != 6000)
			{
				ScenePlayerChangeSceneReq changeScene = new ScenePlayerChangeSceneReq
				{
					curDoorId = 0U,
					dstSceneId = (uint)this.m_targetSceneID,
					dstDoorId = 0U
				};
				yield return MessageUtility.WaitWithResend<ScenePlayerChangeSceneReq, SceneNotifyEnterScene>(ServerType.GATE_SERVER, msgEvents, changeScene, msgEnterScene, true, 8f, null);
			}
			systemOperation.SetProgress(0.5f);
			if (!msgEvents.IsAllMessageReceived())
			{
				Logger.LogErrorFormat("[SystemInitReturnToTown] 错误，没有收到返回城镇相关的消息 {0}", new object[]
				{
					msgEnterScene.mapid
				});
				systemOperation.SetError(string.Empty);
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
				for (;;)
				{
					yield return null;
				}
			}
			else
			{
				if (msgEnterScene.result == 0U)
				{
					this.IsNet = true;
					int currentSceneID = 0;
					currentSceneID = this.m_targetSceneID;
					this._InitOtherPlayerData(msgEvents.GetMessageData(500602U), (uint)currentSceneID);
					systemOperation.SetProgress(0.7f);
					yield return Yielders.EndOfFrame;
					DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
					Logger.LogErrorFormat("init main role pos {0}", new object[]
					{
						DataManager<PlayerBaseData>.GetInstance().Pos
					});
					if (SwitchFunctionUtility.IsOpen(103))
					{
						this.InitializeScene(currentSceneID, currentSceneID == 10100);
					}
					else
					{
						this.InitializeScene(currentSceneID, false);
					}
					if (this.m_targetSceneID == 10100)
					{
						DataManager<ChijiDataManager>.GetInstance().SendChijiBattleID();
					}
					this.m_targetSceneID = -1;
					yield return Yielders.EndOfFrame;
					yield break;
				}
				Logger.LogErrorFormat("[SystemInitReturnToTown] 错误，没有收到返回城镇相关的消息 {0}", new object[]
				{
					msgEnterScene.result
				});
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
				for (;;)
				{
					yield return null;
				}
			}
		}

		// Token: 0x0600A81D RID: 43037 RVA: 0x002325AE File Offset: 0x002309AE
		private void SetTownSceneSwitchState(bool flag)
		{
			this.isTownSceneSwitching = flag;
			Singleton<ClientSystemManager>.GetInstance().SendSceneNotifyLoadingInfoByTownSwitchScene(flag);
		}

		// Token: 0x0600A81E RID: 43038 RVA: 0x002325C4 File Offset: 0x002309C4
		public IEnumerator _NetSyncChangeScene(SceneParams data, bool bReturnScene = false)
		{
			if (this.isTownSceneSwitching)
			{
				yield break;
			}
			this.SetTownSceneSwitchState(true);
			bool isUseLoadingFrame = true;
			if (this.MainPlayer != null)
			{
				this.MainPlayer.SetEnable(false);
			}
			bool bNeedHideBottomLayer = data.targetSceneID == 6090;
			if (bNeedHideBottomLayer && Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
			{
				Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(false);
			}
			this._UnBindSceneNetMsgs();
			MessageEvents msgEvents = new MessageEvents();
			msgEvents.AddMessage(500602U, true);
			SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
			bool isPrepareToChijiRoom = false;
			if ((long)this.CurrentSceneID == 10101L && (long)data.targetSceneID == 10100L)
			{
				isPrepareToChijiRoom = true;
			}
			ScenePlayerChangeSceneReq changeScene = new ScenePlayerChangeSceneReq
			{
				curDoorId = (uint)((!isPrepareToChijiRoom) ? data.currDoorID : ((int)DataManager<ChijiDataManager>.GetInstance().ChijiBattleID)),
				dstSceneId = (uint)data.targetSceneID,
				dstDoorId = (uint)((!isPrepareToChijiRoom) ? data.targetDoorID : ((int)DataManager<ChijiDataManager>.GetInstance().SceneNodeId))
			};
			if (data.targetSceneID == 10101)
			{
				DataManager<ChijiDataManager>.GetInstance().ClearAllRelatedSystemData();
			}
			yield return MessageUtility.WaitWithResend<ScenePlayerChangeSceneReq, SceneNotifyEnterScene>(ServerType.GATE_SERVER, msgEvents, changeScene, msgEnterScene, true, 8f, null);
			if (!msgEvents.IsAllMessageReceived())
			{
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
					if (data.type == eSceneChangeType.eDungeonChapterSelect)
					{
						this.MainPlayer.CommandMoveTo(data.birthPostion);
					}
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				if (Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
				{
					Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
				}
				DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = false;
				DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = false;
				Logger.LogErrorFormat("[城镇] 切换场景失败(消息未全收到) 待在原地  当前场景ID : {0}, 当前门 : {1}, 目标场景: {2}, 目标门ID {3}", new object[]
				{
					data.currSceneID,
					data.currDoorID,
					data.targetSceneID,
					data.targetDoorID
				});
				yield break;
			}
			if (msgEnterScene.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgEnterScene.result, string.Empty);
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
				}
				if (Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
				{
					Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				yield break;
			}
			if (msgEnterScene.mapid <= 0U)
			{
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
					if (data.type == eSceneChangeType.eDungeonChapterSelect)
					{
						this.MainPlayer.CommandMoveTo(data.birthPostion);
					}
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = false;
				DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = false;
				Logger.LogErrorFormat("[城镇] 切换场景失败(场景id无效) 待在原地  当前场景ID : {0}, 当前门 : {1}, 目标场景: {2}, 目标门ID {3}", new object[]
				{
					data.currSceneID,
					data.currDoorID,
					data.targetSceneID,
					data.targetDoorID
				});
				yield break;
			}
			ITownFadingFrame loadingFrame = this.OpenTownFadingFrame(isUseLoadingFrame);
			loadingFrame.FadingIn(0.4f);
			if (data.targetSceneID == 10100)
			{
				DataManager<ChijiDataManager>.GetInstance().ClearPlayerIntrinsicData();
			}
			msgEnterScene.decode(msgEvents.GetMessageData(500303U).bytes);
			this._InitOtherPlayerData(msgEvents.GetMessageData(500602U), msgEnterScene.mapid);
			while (!loadingFrame.IsOpened())
			{
				yield return Yielders.EndOfFrame;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrames();
			CitySceneTable tableData = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>((int)msgEnterScene.mapid, string.Empty, string.Empty);
			if (tableData != null)
			{
				DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
				if (isPrepareToChijiRoom)
				{
					SceneBattleEnterBattleReq cmd = new SceneBattleEnterBattleReq
					{
						battleID = DataManager<ChijiDataManager>.GetInstance().ChijiBattleID
					};
					NetManager.Instance().SendCommand<SceneBattleEnterBattleReq>(ServerType.GATE_SERVER, cmd);
				}
				if (SwitchFunctionUtility.IsOpen(103))
				{
					this.InitializeScene((int)msgEnterScene.mapid, msgEnterScene.mapid == 10100U);
				}
				else
				{
					this.InitializeScene((int)msgEnterScene.mapid, false);
				}
				this.ClearBaseMainFrame();
				if (tableData.SceneType == CitySceneTable.eSceneType.BATTLEPEPARE || tableData.SceneType == CitySceneTable.eSceneType.BATTLE)
				{
					this.ShowPkPrePareFrme(tableData);
				}
				UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
				idleUIEvent.EventParams.CurrentSceneID = (int)msgEnterScene.mapid;
				idleUIEvent.EventID = EUIEventID.SceneChangedFinish;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
			}
			loadingFrame.FadingOut(0.2f);
			while (!loadingFrame.IsClosed())
			{
				yield return Yielders.EndOfFrame;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMainScene, null, null, null, null);
			MonoSingleton<GameFrameWork>.instance.TownNameShow(tableData.Name);
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneChangedFinish, null, null, null, null);
			if (bNeedHideBottomLayer && Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
			{
				Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
			}
			if (data.onSceneLoadFinish != null)
			{
				data.onSceneLoadFinish();
			}
			this._isSwithScene = false;
			this.SetTownSceneSwitchState(false);
			yield break;
		}

		// Token: 0x0600A81F RID: 43039 RVA: 0x002325E6 File Offset: 0x002309E6
		private ITownFadingFrame OpenTownFadingFrame(bool isUseLoadingFrame)
		{
			if (!isUseLoadingFrame)
			{
				return Singleton<ClientSystemManager>.GetInstance().OpenGlobalFrame<FadingFrame>(FrameLayer.Top, null) as ITownFadingFrame;
			}
			return Singleton<ClientSystemManager>.GetInstance().OpenGlobalFrame<TownLoadingFrame>(FrameLayer.Top, null) as ITownFadingFrame;
		}

		// Token: 0x0600A820 RID: 43040 RVA: 0x00232614 File Offset: 0x00230A14
		protected IEnumerator _errorProcess(eEnumError type, string msg)
		{
			Logger.LogErrorFormat("城镇错误 {0}, {1}", new object[]
			{
				type,
				msg
			});
			Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
			yield break;
		}

		// Token: 0x0600A821 RID: 43041 RVA: 0x00232638 File Offset: 0x00230A38
		protected IEnumerator _SystemInitWithoutNet(IASyncOperation systemOperation)
		{
			DataManager<PlayerBaseData>.GetInstance().RoleID = 0UL;
			DataManager<PlayerBaseData>.GetInstance().Name = "PlayerMain";
			DataManager<PlayerBaseData>.GetInstance().JobTableID = 10;
			this.IsNet = false;
			systemOperation.SetProgress(0.7f);
			yield return Yielders.EndOfFrame;
			this.InitializeScene(2233, false);
			systemOperation.SetProgress(1f);
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600A822 RID: 43042 RVA: 0x0023265C File Offset: 0x00230A5C
		protected void InitializeScene(int currentSceneId, bool isPKToGame = false)
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(currentSceneId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("scene id {0} is not exist!", new object[]
				{
					currentSceneId
				});
				return;
			}
			bool bNeedGC = true;
			if (this.CurrentSceneID > 0)
			{
				CitySceneTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					bNeedGC = (tableItem.AreaID != tableItem2.AreaID);
				}
			}
			this.ClearScene(bNeedGC);
			this._RegisterEvent();
			this.CurrentSceneID = currentSceneId;
			if (isPKToGame)
			{
				this._levelData = DataManager<ChijiDataManager>.GetInstance().sceneData;
				if (this._levelData == null)
				{
					this._levelData = DungeonUtility.LoadSceneData(tableItem.ResPath);
				}
			}
			else
			{
				this._levelData = DungeonUtility.LoadSceneData(tableItem.ResPath);
			}
			if (this._levelData == null)
			{
				Logger.LogError("_level data is nil");
				return;
			}
			this._logicToGraph = this._levelData.GetLogicPos();
			this._serverToClient = new Vector3(this._levelData.GetLogicXSize().x, 0f, this._levelData.GetLogicZSize().x);
			this.GridInfo = new PathFinding.GridInfo
			{
				GridSize = this._levelData.GetGridSize(),
				GridMinX = this._levelData.GetLogicXmin(),
				GridMaxX = this._levelData.GetLogicXmax(),
				GridMinY = this._levelData.GetLogicZmin(),
				GridMaxY = this._levelData.GetLogicZmax(),
				GridBlockLayer = this._levelData.GetRawBlockLayer()
			};
			this.GridInfo.GridDiagonalLength = this.GridInfo.GridSize.magnitude;
			this._geScene = new GeSceneEx();
			this._geScene.LoadScene(this._levelData, false, isPKToGame);
			Singleton<GeWeatherManager>.instance.ChangeWeather(this._levelData.GetWeatherMode());
			Singleton<GeGraphicSetting>.instance.GetSetting("PlayerDisplayNum", ref this._beDisplayNum);
			this.CreateSceneObjects();
			this._InitializeCameraController();
			this._InitializeBGM(tableItem.BGMPath);
			this._BindSceneNetMsgs();
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneJumpFinished, this.CurrentSceneID, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TownSceneInited, null, null, null, null);
		}

		// Token: 0x0600A823 RID: 43043 RVA: 0x002328C8 File Offset: 0x00230CC8
		private void _RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MoveSpeedChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerMainSpeedChanged));
		}

		// Token: 0x0600A824 RID: 43044 RVA: 0x002328E2 File Offset: 0x00230CE2
		private void _UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MoveSpeedChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerMainSpeedChanged));
		}

		// Token: 0x0600A825 RID: 43045 RVA: 0x002328FC File Offset: 0x00230CFC
		private void _OnPlayerMainSpeedChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				Vec3 vec = Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
				this.MainPlayer.ActorData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * DataManager<PlayerBaseData>.GetInstance().MoveSpeedRate;
			}
		}

		// Token: 0x0600A826 RID: 43046 RVA: 0x00232968 File Offset: 0x00230D68
		private int _Locate(List<ClientSystemGameBattle.SceneNode> nodes, int sceneID)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (nodes[i].SceneID == sceneID)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600A827 RID: 43047 RVA: 0x002329A4 File Offset: 0x00230DA4
		private bool _DFS(List<ClientSystemGameBattle.SceneNode> nodes, int current, int target, ref List<Vector3> path, ClientSystemGameBattle.DoorNode door, ref List<int> SceneIDList, ref List<int> DoorIDList)
		{
			ClientSystemGameBattle.SceneNode sceneNode = nodes[current];
			sceneNode.HasVisited = true;
			if (current == target)
			{
				if (door != null)
				{
					path.Add(door.Door.GetRegionInfo().GetEntityInfo().GetPosition());
					SceneIDList.Add(sceneNode.SceneID);
					DoorIDList.Add(door.Door.GetDoorID());
				}
				return true;
			}
			if (door != null)
			{
				path.Add(door.Door.GetRegionInfo().GetEntityInfo().GetPosition());
				SceneIDList.Add(sceneNode.SceneID);
				DoorIDList.Add(door.Door.GetDoorID());
			}
			for (int i = 0; i < sceneNode.DoorNodes.Count; i++)
			{
				ClientSystemGameBattle.DoorNode doorNode = sceneNode.DoorNodes[i];
				ClientSystemGameBattle.SceneNode sceneNode2 = nodes[doorNode.TargetSceneIndex];
				if (!sceneNode2.HasVisited && this._DFS(nodes, doorNode.TargetSceneIndex, target, ref path, doorNode, ref SceneIDList, ref DoorIDList))
				{
					return true;
				}
			}
			if (door != null)
			{
				path.RemoveAt(path.Count - 1);
				SceneIDList.RemoveAt(SceneIDList.Count - 1);
				DoorIDList.RemoveAt(DoorIDList.Count - 1);
			}
			return false;
		}

		// Token: 0x0600A828 RID: 43048 RVA: 0x00232AF4 File Offset: 0x00230EF4
		public List<Vector3> GetMovePath(int targetSceneID)
		{
			List<Vector3> result = new List<Vector3>();
			int num = this._Locate(this.m_sceneNodes, targetSceneID);
			if (num >= 0)
			{
				for (int i = 0; i < this.m_sceneNodes.Count; i++)
				{
					this.m_sceneNodes[i].HasVisited = false;
				}
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				int current = this._Locate(this.m_sceneNodes, this.CurrentSceneID);
				this._DFS(this.m_sceneNodes, current, num, ref result, null, ref list, ref list2);
				for (int j = 0; j < list.Count; j++)
				{
				}
			}
			return result;
		}

		// Token: 0x0600A829 RID: 43049 RVA: 0x00232BA3 File Offset: 0x00230FA3
		private void ClearBaseMainFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiWaitingRoomFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiMainFrame>(null, false);
		}

		// Token: 0x0600A82A RID: 43050 RVA: 0x00232BC0 File Offset: 0x00230FC0
		private void ShowPkPrePareFrme(CitySceneTable tableData)
		{
			CitySceneTable.eSceneSubType sceneSubType = tableData.SceneSubType;
			if (sceneSubType != CitySceneTable.eSceneSubType.BattlePrepare)
			{
				if (sceneSubType == CitySceneTable.eSceneSubType.Battle)
				{
					ChijiRoomData userData = new ChijiRoomData
					{
						SceneSubType = tableData.SceneSubType,
						CurrentSceneID = tableData.ID,
						TargetTownSceneID = tableData.BirthCity
					};
					DataManager<ChijiDataManager>.GetInstance().SendOccuListReq();
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiMainFrame>(FrameLayer.Bottom, userData, string.Empty);
				}
			}
			else
			{
				ChijiRoomData userData2 = new ChijiRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiWaitingRoomFrame>(FrameLayer.Bottom, userData2, string.Empty);
			}
		}

		// Token: 0x0600A82B RID: 43051 RVA: 0x00232C7E File Offset: 0x0023107E
		public void OnGraphicSettingChange(int displayNum)
		{
		}

		// Token: 0x0600A82C RID: 43052 RVA: 0x00232C80 File Offset: 0x00231080
		protected void ClearScene(bool bNeedGC = true)
		{
			if (this.PoisonRing != null)
			{
				this.PoisonRing.Dispose();
			}
			if (this.mMainPlayer != null)
			{
				this.mMainPlayer.Dispose();
			}
			this.mPoisonRing = null;
			this.mMainPlayer = null;
			this.mFighters.Clear();
			this._beTownPlayerBuffs.Clear();
			this._beTownItems.Clear();
			this._beNPCs.Clear();
			this.mBuffItem.Clear();
			this.mRemoveBuffItem.Clear();
			this._beProjectiles.Clear();
			this._beDisplayPlayerList.Clear();
			this._beDisplayNum = 0;
			this._levelData = null;
			this.GridInfo = null;
			if (this._geScene != null)
			{
				if (SwitchFunctionUtility.IsOpen(103))
				{
					this._geScene.UnloadScene(bNeedGC, this.CurrentSceneID == 10100);
				}
				else
				{
					this._geScene.UnloadScene(bNeedGC, false);
				}
				this._geScene = null;
			}
			this.CurrentSceneID = -1;
			this._UnBindSceneNetMsgs();
			this._UnRegisterEvent();
			this._OnClearDelayCreateCache();
			this._OnClearDelayCreateItemCache();
		}

		// Token: 0x0600A82D RID: 43053 RVA: 0x00232D9C File Offset: 0x0023119C
		protected void _BindSceneNetMsgs()
		{
			if (this.IsNet)
			{
				this._UnBindSceneNetMsgs();
				this._mapBindMsgHandle.Add(500603U, new Action<MsgDATA>(this._OnSyncPlayerOthers));
				this._mapBindMsgHandle.Add(500602U, new Action<MsgDATA>(this._OnSyncAddPlayerOthers));
				this._mapBindMsgHandle.Add(500604U, new Action<MsgDATA>(this._OnSyncRemovePlayerOthers));
				this._mapBindMsgHandle.Add(500502U, new Action<MsgDATA>(this._OnSyncMovePlayerOthers));
				this._mapBindMsgHandle.Add(500625U, new Action<MsgDATA>(this._OnSyncSceneItemList));
				Dictionary<uint, Action<MsgDATA>>.KeyCollection keys = this._mapBindMsgHandle.Keys;
				foreach (object obj in keys)
				{
					uint num = (uint)obj;
					NetProcess.AddMsgHandler(num, this._mapBindMsgHandle[num]);
				}
			}
		}

		// Token: 0x0600A82E RID: 43054 RVA: 0x00232E8C File Offset: 0x0023128C
		public void OnRecvSyncSceneItemAdd(SceneItemAdd res)
		{
			for (int i = 0; i < res.data.Length; i++)
			{
				uint sceneId = res.data[i].sceneId;
				foreach (SceneItem mDropItem in res.data[i].items)
				{
					BeItemData data = new BeItemData
					{
						mDropItem = mDropItem
					};
					BeItem obj = new BeItem(data, this);
					this._onAddDelayCreateItemCache(obj);
				}
			}
		}

		// Token: 0x0600A82F RID: 43055 RVA: 0x00232F10 File Offset: 0x00231310
		public void OnRecvSceneItemDel(SceneItemDel res)
		{
			if (res == null)
			{
				Logger.LogError("_OnSyncSceneItemDel ==>> msg is nil");
				return;
			}
			for (int i = 0; i < res.guids.Length; i++)
			{
				this._onRemoveDelayCreateItemCache(res.guids[i]);
				for (int j = 0; j < this._beTownItems.GetFightCount(); j++)
				{
					BeItem fighter = this._beTownItems.GetFighter(j);
					if (fighter != null && fighter.ActorData.GUID == res.guids[i])
					{
						fighter.Dispose();
						this._beTownItems.RemoveFighter(j);
						break;
					}
				}
			}
			this._beTownItems.Refresh();
		}

		// Token: 0x0600A830 RID: 43056 RVA: 0x00232FC0 File Offset: 0x002313C0
		protected void _UnBindSceneNetMsgs()
		{
			if (this.IsNet)
			{
				Dictionary<uint, Action<MsgDATA>>.KeyCollection keys = this._mapBindMsgHandle.Keys;
				foreach (object obj in keys)
				{
					uint num = (uint)obj;
					NetProcess.RemoveMsgHandler(num, this._mapBindMsgHandle[num]);
				}
				this._mapBindMsgHandle.Clear();
			}
		}

		// Token: 0x0600A831 RID: 43057 RVA: 0x0023302C File Offset: 0x0023142C
		private void CreateSceneObjects()
		{
			this.CreateSceneNpcs();
			this._CreateDynamicNpcs();
			List<BattleNpc> npcDataList = DataManager<ChijiDataManager>.GetInstance().NpcDataList;
			this.CreateMainPlayer();
			this.CreateSceneOtherPlayers();
		}

		// Token: 0x0600A832 RID: 43058 RVA: 0x0023305C File Offset: 0x0023145C
		private void CreateSceneNpcs()
		{
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("[npc]data.NpcID = {0} is not existed! to 张亮!", new object[]
					{
						npcInfo.GetEntityInfo().GetResid()
					});
				}
				else if (tableItem.Function != NpcTable.eFunction.guildDungeonActivityChest || DataManager<GuildDataManager>.GetInstance().IsShowChestModel())
				{
					BeNPCData beNPCData = new BeNPCData
					{
						NpcID = npcInfo.GetEntityInfo().GetResid(),
						ResourceID = 0,
						Name = tableItem.NpcName,
						NameColor = PlayerInfoColor.TOWN_NPC
					};
					bool flag = false;
					int num = 0;
					if (tableItem.Function == NpcTable.eFunction.Townstatue || tableItem.Function == NpcTable.eFunction.guildGuardStatue)
					{
						List<FigureStatueInfo> list = new List<FigureStatueInfo>();
						if (tableItem.Function == NpcTable.eFunction.Townstatue)
						{
							list = DataManager<GuildDataManager>.GetInstance().GetTownStatueInfo();
						}
						else if (tableItem.Function == NpcTable.eFunction.guildGuardStatue)
						{
							list = DataManager<GuildDataManager>.GetInstance().GetGuildGuardStatueInfo();
						}
						bool flag2 = false;
						for (int j = 0; j < list.Count; j++)
						{
							FigureStatueInfo figureStatueInfo = list[j];
							if (figureStatueInfo.statueType == (byte)tableItem.SubType)
							{
								JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)figureStatueInfo.occu, string.Empty, string.Empty);
								if (tableItem2 == null)
								{
									Logger.LogErrorFormat("can not find JobTable with TownStatue NPC occu ID:{0} when InitTown", new object[]
									{
										figureStatueInfo.occu
									});
								}
								else
								{
									ResTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem2.Mode, string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										beNPCData.ResourceID = tableItem3.ID;
										beNPCData.JobID = (int)figureStatueInfo.occu;
										beNPCData.avatorInfo = figureStatueInfo.avatar;
										beNPCData.StatueName = figureStatueInfo.name;
										flag = true;
										num = tableItem2.TownStatueFace;
										flag2 = true;
										break;
									}
									Logger.LogErrorFormat("can not find ResTable with TownStatue NPC mod id:{0} when InitTown", new object[]
									{
										tableItem2.Mode
									});
								}
							}
						}
						if (!flag2)
						{
							beNPCData.ResourceID = tableItem.ResID;
						}
					}
					else
					{
						beNPCData.ResourceID = tableItem.ResID;
					}
					beNPCData.MoveData.PosLogicToGraph = this._logicToGraph;
					beNPCData.MoveData.PosServerToClient = this._serverToClient;
					beNPCData.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
					BeNPC beNPC = new BeNPC(beNPCData, this);
					beNPC.InitGeActor(this._geScene);
					if (beNPC.GraphicActor != null)
					{
						beNPC.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
						if (flag)
						{
							Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
							beNPC.GraphicActor.SetRotation(rotation);
						}
					}
					this._beNPCs.AddFighter(beNPC);
				}
			}
		}

		// Token: 0x0600A833 RID: 43059 RVA: 0x00233384 File Offset: 0x00231784
		private void _CreateDynamicNpcs()
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null || tableItem.SceneType != CitySceneTable.eSceneType.BATTLE || tableItem.SceneSubType != CitySceneTable.eSceneSubType.Battle)
			{
				return;
			}
			List<BattleNpc> npcDataList = DataManager<ChijiDataManager>.GetInstance().NpcDataList;
			for (int i = 0; i < npcDataList.Count; i++)
			{
				NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>((int)npcDataList[i].npcId, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("[npc]data.NpcID = {0} is not existed in Chiji", new object[]
					{
						npcDataList[i].npcId
					});
				}
				else if (tableItem2.Function == NpcTable.eFunction.Chiji)
				{
					if (npcDataList[i].opType == 1U)
					{
						BeNPC fighter = this._beNPCs.GetFighter(npcDataList[i].npcGuid);
						if (fighter != null)
						{
							if (fighter.IsRemoved)
							{
								fighter.CancelRemove();
							}
						}
						else
						{
							BeNPCData beNPCData = new BeNPCData
							{
								NpcID = (int)npcDataList[i].npcId,
								ResourceID = tableItem2.ResID,
								Name = tableItem2.NpcName,
								NameColor = PlayerInfoColor.TOWN_NPC
							};
							beNPCData.GUID = npcDataList[i].npcGuid;
							beNPCData.MoveData.PosLogicToGraph = this._logicToGraph;
							beNPCData.MoveData.PosServerToClient = this._serverToClient;
							Vector3 serverPosition;
							serverPosition..ctor(npcDataList[i].pos.x / this._axisScale, 0.1f, npcDataList[i].pos.y / this._axisScale);
							beNPCData.MoveData.ServerPosition = serverPosition;
							BeNPC beNPC = new BeNPC(beNPCData, this);
							beNPC.InitGeActor(this._geScene);
							if (beNPC.GraphicActor != null)
							{
								beNPC.GraphicActor.SetScale(1f);
							}
							this._beNPCs.AddFighter(npcDataList[i].npcGuid, beNPC);
						}
					}
					else
					{
						BeNPC fighter2 = this._beNPCs.GetFighter(npcDataList[i].npcGuid);
						if (fighter2 != null && !fighter2.IsRemoved)
						{
							this._beNPCs.RemoveFighter(npcDataList[i].npcGuid);
						}
					}
				}
			}
		}

		// Token: 0x0600A834 RID: 43060 RVA: 0x00233604 File Offset: 0x00231A04
		protected void _CreateTownItem(BeItem item)
		{
			if (item.IsRemoved)
			{
				return;
			}
			item.ActorData.MoveData.PosLogicToGraph = this._logicToGraph;
			item.ActorData.MoveData.PosServerToClient = this._serverToClient;
			BeItemData beItemData = item.ActorData as BeItemData;
			beItemData.MoveData.ServerPosition = new Vector3(beItemData.mDropItem.pos.x / this._axisScale, 0.1f, beItemData.mDropItem.pos.y / this._axisScale);
			item.InitGeActor(this._geScene);
			if (item.IsBuffItem)
			{
				this.mBuffItem.Add(item);
			}
			this._beTownItems.AddFighter(beItemData.GUID, item);
		}

		// Token: 0x0600A835 RID: 43061 RVA: 0x002336D1 File Offset: 0x00231AD1
		protected void _onAddDelayCreateItemCache(BeItem obj)
		{
			this.mItemQueue.Add(obj);
		}

		// Token: 0x0600A836 RID: 43062 RVA: 0x002336E0 File Offset: 0x00231AE0
		protected void _onRemoveDelayCreateItemCache(ulong guid)
		{
			this.mItemQueue.RemoveAll((BeItem item) => item.ActorData.GUID == guid);
		}

		// Token: 0x0600A837 RID: 43063 RVA: 0x00233712 File Offset: 0x00231B12
		protected void _OnClearDelayCreateItemCache()
		{
			this.mItemQueue.Clear();
		}

		// Token: 0x0600A838 RID: 43064 RVA: 0x00233720 File Offset: 0x00231B20
		protected void _OnUpdateDelayCreateItemCache()
		{
			if (this.mItemQueue.Count > 0)
			{
				int num = Mathf.Min(5, this.mItemQueue.Count);
				int num2 = 0;
				while (num2 < num && this.mItemQueue.Count > 0)
				{
					BeItem item = this.mItemQueue[0];
					this.mItemQueue.RemoveAt(0);
					this._CreateTownItem(item);
					num2++;
				}
			}
		}

		// Token: 0x0600A839 RID: 43065 RVA: 0x00233794 File Offset: 0x00231B94
		private void CreateItemList()
		{
			for (int i = 0; i < this._beTownItems.GetFightCount(); i++)
			{
				BeItem fighter = this._beTownItems.GetFighter(i);
				if (fighter != null)
				{
					fighter.ActorData.MoveData.PosLogicToGraph = this._logicToGraph;
					fighter.ActorData.MoveData.PosServerToClient = this._serverToClient;
					BeItemData beItemData = fighter.ActorData as BeItemData;
					beItemData.MoveData.ServerPosition = new Vector3(beItemData.mDropItem.pos.x / this._axisScale, 0f, beItemData.mDropItem.pos.y / this._axisScale);
					fighter.InitGeActor(this._geScene);
					if (fighter.IsBuffItem)
					{
						this.mBuffItem.Add(fighter);
					}
				}
			}
		}

		// Token: 0x0600A83A RID: 43066 RVA: 0x00233874 File Offset: 0x00231C74
		private void CreateSceneOtherPlayers()
		{
			if (this.PlayerOthersData == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in this.PlayerOthersData)
			{
				SceneObject value = keyValuePair.Value;
				BeFighter beFighter = this._CreateTownPlayer(value, this.CurrentSceneID);
				if (beFighter != null)
				{
					this.mFighters.AddFighter(beFighter.ActorData.GUID, beFighter);
					this._AddDisplayActor(beFighter.ActorData.GUID);
				}
			}
		}

		// Token: 0x0600A83B RID: 43067 RVA: 0x002338F8 File Offset: 0x00231CF8
		private void _AddDisplayActor(ulong ID)
		{
			if (!this._beDisplayPlayerList.Contains(ID))
			{
				BeFighter fighter = this.mFighters.GetFighter(ID);
				if (fighter != null)
				{
					if (fighter.GraphicActor == null)
					{
						fighter.InitGeActor(this._geScene);
						if (fighter.ActorData.ActionData.ActionName.Contains("Idle"))
						{
							fighter.GraphicActor.ChangeAction(fighter.ActorData.AniNames[0], 1f, true, true, true);
						}
						else
						{
							string action = fighter.ActorData.AniNames[2];
							fighter.GraphicActor.ChangeAction(action, 1f, true, true, true);
						}
					}
					this._beDisplayPlayerList.Add(ID);
					BeFightBuffManager beFightBuffManager = null;
					if (this._beTownPlayerBuffs.ContainsKey(ID))
					{
						beFightBuffManager = this._beTownPlayerBuffs[ID];
					}
					if (beFightBuffManager == null)
					{
						return;
					}
					for (int i = 0; i < beFightBuffManager.Count(); i++)
					{
						BeFightBuff beFightBuff = beFightBuffManager.Get(i);
						if (beFightBuff != null)
						{
							beFightBuff.Start(fighter.GraphicActor);
						}
					}
					List<ulong> otherDeadPlayers = DataManager<ChijiDataManager>.GetInstance().OtherDeadPlayers;
					for (int j = 0; j < otherDeadPlayers.Count; j++)
					{
						if (otherDeadPlayers[j] == fighter.ActorData.GUID)
						{
							fighter.SetDead();
						}
					}
				}
			}
		}

		// Token: 0x0600A83C RID: 43068 RVA: 0x00233A58 File Offset: 0x00231E58
		private void _RemoveDisplayActor(ulong ID)
		{
			if (this._beDisplayPlayerList.Contains(ID))
			{
				BeFighter fighter = this.mFighters.GetFighter(ID);
				if (fighter != null)
				{
					if (fighter.GraphicActor != null)
					{
						fighter.RemoveGeActor();
					}
					this._beDisplayPlayerList.Remove(ID);
				}
			}
		}

		// Token: 0x0600A83D RID: 43069 RVA: 0x00233AA8 File Offset: 0x00231EA8
		protected void _OnUpdateDelayCreateCache()
		{
			if (this.mObjQueue.Count > 0)
			{
				SceneObject sceneObj = this.mObjQueue[0];
				this.mObjQueue.RemoveAt(0);
				this._CreateTownPlayer(sceneObj);
			}
		}

		// Token: 0x0600A83E RID: 43070 RVA: 0x00233AE6 File Offset: 0x00231EE6
		protected void _OnAddDelayCreateCache(SceneObject obj)
		{
			this.mObjQueue.Add(obj);
		}

		// Token: 0x0600A83F RID: 43071 RVA: 0x00233AF4 File Offset: 0x00231EF4
		protected void _OnRemoveDelayCreateCache(ulong objID)
		{
			this.mObjQueue.RemoveAll((SceneObject item) => item.id == objID);
		}

		// Token: 0x0600A840 RID: 43072 RVA: 0x00233B26 File Offset: 0x00231F26
		protected void _OnClearDelayCreateCache()
		{
			this.mObjQueue.Clear();
		}

		// Token: 0x0600A841 RID: 43073 RVA: 0x00233B34 File Offset: 0x00231F34
		private IEnumerator _PrewarmFrames()
		{
			string[] prewarmList = new string[]
			{
				"UIFlatten/Prefabs/Package/PackageNew",
				"UIFlatten/Prefabs/Package/BG",
				"UIFlatten/Prefabs/Package/Bottom",
				"UIFlatten/Prefabs/Package/Tabs"
			};
			int i = 0;
			int icnt = prewarmList.Length;
			while (i < icnt)
			{
				GameObject go = Singleton<AssetLoader>.instance.LoadResAsGameObject(prewarmList[i], true, 0U);
				Object.Destroy(go);
				yield return null;
				i++;
			}
			yield break;
		}

		// Token: 0x0600A842 RID: 43074 RVA: 0x00233B48 File Offset: 0x00231F48
		public void OnSceneLoadEnd()
		{
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(this.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("排查主界面角色信息未初始化原因2--CurrentSceneID = {0}", new object[]
				{
					this.CurrentSceneID
				});
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.BATTLEPEPARE)
			{
				this.UpdateChijiWaitingRoomFrame(tableItem);
			}
			else if (tableItem.SceneType == CitySceneTable.eSceneType.BATTLE)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiWaitingRoomFrame>(null, false);
				this.UpdateChijiMainFrame(tableItem);
			}
			DataManager<HeadPortraitFrameDataManager>.GetInstance().OnSendSceneHeadFrameReq();
		}

		// Token: 0x0600A843 RID: 43075 RVA: 0x00233BD8 File Offset: 0x00231FD8
		private void UpdateChijiWaitingRoomFrame(CitySceneTable TownTableData)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiWaitingRoomFrame>(null))
			{
				ChijiRoomData userData = new ChijiRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiWaitingRoomFrame>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600A844 RID: 43076 RVA: 0x00233C34 File Offset: 0x00232034
		private void UpdateChijiMainFrame(CitySceneTable TownTableData)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiMainFrame>(null))
			{
				ChijiRoomData userData = new ChijiRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiMainFrame>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600A845 RID: 43077 RVA: 0x00233C90 File Offset: 0x00232090
		private void _RefreshSceneObject(SceneObject originData, SceneObject sceneObj, ulong objId)
		{
			for (int i = 0; i < sceneObj.dirtyFields.Count; i++)
			{
				SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)sceneObj.dirtyFields[i];
				if (!originData.dirtyFields.Contains(sceneObj.dirtyFields[i]))
				{
					originData.dirtyFields.Add(sceneObj.dirtyFields[i]);
				}
				if (sceneObjectAttr == SceneObjectAttr.SOA_LEVEL)
				{
					originData.level = sceneObj.level;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_LEVEL)
				{
					originData.seasonLevel = sceneObj.seasonLevel;
					originData.seasonStar = sceneObj.seasonStar;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_STAR)
				{
					originData.seasonLevel = sceneObj.seasonLevel;
					originData.seasonStar = sceneObj.seasonStar;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_TITLE)
				{
					originData.title = sceneObj.title;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_NAME)
				{
					originData.guildName = sceneObj.guildName;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_POST)
				{
					originData.guildPost = sceneObj.guildPost;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_PET_FOLLOW)
				{
					originData.followPetDataId = sceneObj.followPetDataId;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_NAME)
				{
					originData.name = sceneObj.name;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_ZONEID)
				{
					originData.zoneId = sceneObj.zoneId;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_BUFFS)
				{
					originData.buffList = sceneObj.buffList;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_AVATAR)
				{
					originData.avatar = sceneObj.avatar;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_OCCU)
				{
					originData.occu = sceneObj.occu;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_ADVENTURE_TEAM_NAME)
				{
					originData.adventureTeamName = sceneObj.adventureTeamName;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_NEW_TITLE_NAME)
				{
					originData.wearedTitleInfo = sceneObj.wearedTitleInfo;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_EMBLEM)
				{
					originData.guildEmblemLvl = sceneObj.guildEmblemLvl;
				}
				else if (sceneObjectAttr == SceneObjectAttr.SOA_GAMEOPTIONS)
				{
					originData.gameOptions = sceneObj.gameOptions;
				}
			}
		}

		// Token: 0x0600A846 RID: 43078 RVA: 0x00233EA8 File Offset: 0x002322A8
		protected void _OnSyncAddPlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncAddPlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			Dictionary<ulong, SceneObject> dictionary = SceneObjectDecoder.DecodeSyncSceneObjectMsg(msg.bytes, ref num, msg.bytes.Length);
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in dictionary)
			{
				ulong key = keyValuePair.Key;
				if (DataManager<PlayerBaseData>.GetInstance().RoleID == key)
				{
					Logger.LogErrorFormat("出现这个提示，请通知小月月！！", new object[0]);
				}
				else
				{
					Dictionary<ulong, SceneObject>.Enumerator enumerator;
					KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
					this._OnAddDelayCreateCache(keyValuePair2.Value);
				}
			}
		}

		// Token: 0x0600A847 RID: 43079 RVA: 0x00233F4C File Offset: 0x0023234C
		protected void _OnSyncPlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncPlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			ulong objId = 0UL;
			BaseDLL.decode_uint64(msg.bytes, ref num, ref objId);
			SceneObject sceneObject = null;
			if (!this.PlayerOthersData.TryGetValue(objId, out sceneObject))
			{
				SceneObject sceneObject2 = this.mObjQueue.Find((SceneObject item) => item.id == objId);
				if (sceneObject2 != null)
				{
					sceneObject = new SceneObject();
					StreamObjectDecoder<SceneObject>.DecodePropertys(ref sceneObject, msg.bytes, ref num, msg.bytes.Length);
					this._RefreshSceneObject(sceneObject2, sceneObject, objId);
				}
				return;
			}
			if (sceneObject == null)
			{
				return;
			}
			StreamObjectDecoder<SceneObject>.DecodePropertys(ref sceneObject, msg.bytes, ref num, msg.bytes.Length);
			BeFighter beFighter = this.mFighters.GetFighter(objId);
			if (beFighter != null)
			{
				for (int i = 0; i < sceneObject.dirtyFields.Count; i++)
				{
					SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)sceneObject.dirtyFields[i];
					if (sceneObjectAttr == SceneObjectAttr.SOA_LEVEL)
					{
						beFighter.SetPlayerRoleLv(sceneObject.level);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_LEVEL)
					{
						beFighter.SetPlayerPKRank((int)sceneObject.seasonLevel, (int)sceneObject.seasonStar);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_STAR)
					{
						beFighter.SetPlayerPKRank((int)sceneObject.seasonLevel, (int)sceneObject.seasonStar);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_TITLE)
					{
						beFighter.SetPlayerTittle(sceneObject.title);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_NAME)
					{
						beFighter.SetPlayerGuildName(sceneObject.guildName);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_POST)
					{
						beFighter.SetPlayerGuildDuty(sceneObject.guildPost);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_PET_FOLLOW)
					{
						beFighter.CreatePet((int)sceneObject.followPetDataId);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_NAME)
					{
						beFighter.SetPlayerName(sceneObject.name);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_ZONEID)
					{
						beFighter.SetPlayerZoneID((int)sceneObject.zoneId);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_BUFFS)
					{
						if (sceneObject.buffList == null)
						{
							return;
						}
						if (!this._beTownPlayerBuffs.ContainsKey(objId))
						{
							this._beTownPlayerBuffs.Add(objId, new BeFightBuffManager());
						}
						BeFightBuffManager beFightBuffManager = this._beTownPlayerBuffs[objId];
						List<Battle.DungeonBuff> buffList = sceneObject.buffList;
						List<int> list = new List<int>();
						for (int j = 0; j < beFightBuffManager.Count(); j++)
						{
							BeFightBuff beFightBuff = beFightBuffManager.Get(j);
							bool flag = false;
							for (int k = 0; k < buffList.Count; k++)
							{
								if (buffList[k].uid == beFightBuff.GUID)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								list.Add(j);
							}
						}
						for (int l = list.Count - 1; l >= 0; l--)
						{
							BeFightBuff beFightBuff2 = beFightBuffManager.Get(list[l]);
							if (beFightBuff2 != null)
							{
								beFightBuff2.Finish(beFighter.GraphicActor);
							}
							beFightBuffManager.RemoveAt(list[l]);
						}
						for (int m = 0; m < buffList.Count; m++)
						{
							Battle.DungeonBuff dungeonBuff = buffList[m];
							BeFightBuff buffByGUID = beFightBuffManager.GetBuffByGUID(dungeonBuff.uid);
							if (buffByGUID == null)
							{
								BeFightBuff beFightBuff3 = beFightBuffManager.AddBuff(dungeonBuff.id, dungeonBuff.uid, objId, dungeonBuff.duration, dungeonBuff.overlay);
								if (beFightBuff3 != null)
								{
									beFightBuff3.Start(beFighter.GraphicActor);
								}
							}
							else
							{
								buffByGUID.Refresh(dungeonBuff.duration, dungeonBuff.overlay);
							}
						}
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_AVATAR || sceneObjectAttr == SceneObjectAttr.SOA_OCCU)
					{
						this._RemoveDisplayActor(objId);
						beFighter.Dispose();
						this.mFighters.RemoveFighter(objId);
						this._OnRemoveDelayCreateCache(objId);
						BeFighter beFighter2 = this._CreateTownPlayer(sceneObject, this.CurrentSceneID);
						if (beFighter2 != null)
						{
							this.mFighters.AddFighter(beFighter2.ActorData.GUID, beFighter2);
							this._AddDisplayActor(beFighter2.ActorData.GUID);
						}
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_ADVENTURE_TEAM_NAME)
					{
						beFighter.SetAdventureTeamName(sceneObject.adventureTeamName);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_NEW_TITLE_NAME)
					{
						beFighter.SetTitleName(sceneObject.wearedTitleInfo);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_EMBLEM)
					{
						beFighter.SetGuildEmblemLv((int)sceneObject.guildEmblemLvl);
					}
				}
			}
			else
			{
				SceneObject originData = this.PlayerOthersData[objId];
				this._RefreshSceneObject(originData, sceneObject, objId);
				beFighter = this._CreateTownPlayer(this.PlayerOthersData[objId], this.CurrentSceneID);
				if (beFighter != null)
				{
					this.mFighters.AddFighter(objId, beFighter);
				}
				this._AddDisplayActor(objId);
			}
		}

		// Token: 0x0600A848 RID: 43080 RVA: 0x00234470 File Offset: 0x00232870
		protected void _OnSyncRemovePlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncRemovePlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			while (msg.bytes.Length - num > 8)
			{
				ulong num2 = 0UL;
				BaseDLL.decode_uint64(msg.bytes, ref num, ref num2);
				this.PlayerOthersData.Remove(num2);
				BeFighter fighter = this.mFighters.GetFighter(num2);
				if (fighter != null)
				{
					this._RemoveDisplayActor(num2);
					fighter.Dispose();
					this.mFighters.RemoveFighter(num2);
					this._beTownPlayerBuffs.Remove(num2);
				}
				for (int i = 0; i < this.mFighters.GetFightCount(); i++)
				{
					BeFighter fighter2 = this.mFighters.GetFighter(i);
					if (fighter2 != null)
					{
						this._AddDisplayActor(fighter2.ActorData.GUID);
						if (this._beDisplayPlayerList.Count == this._beDisplayNum)
						{
							break;
						}
					}
				}
				this._OnRemoveDelayCreateCache(num2);
			}
		}

		// Token: 0x0600A849 RID: 43081 RVA: 0x00234564 File Offset: 0x00232964
		protected void _OnSyncMovePlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncMovePlayers ==>> msg is nil");
				return;
			}
			SceneSyncPlayerMove sceneSyncPlayerMove = new SceneSyncPlayerMove();
			sceneSyncPlayerMove.decode(msg.bytes);
			if (sceneSyncPlayerMove.dir.x != 0 || sceneSyncPlayerMove.dir.y != 0 || sceneSyncPlayerMove.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
			}
			BeFighter fighter = this.mFighters.GetFighter(sceneSyncPlayerMove.id);
			if (fighter != null)
			{
				fighter.AddMoveCommand(new Vector3(sceneSyncPlayerMove.pos.x / this._axisScale, 0f, sceneSyncPlayerMove.pos.y / this._axisScale) + fighter.ActorData.MoveData.PosServerToClient, new Vector3((float)sceneSyncPlayerMove.dir.x / this._axisScale, 0f, (float)sceneSyncPlayerMove.dir.y / this._axisScale), sceneSyncPlayerMove.dir.faceRight >= 1);
			}
			SceneObject sceneObject = null;
			if (this.PlayerOthersData.TryGetValue(sceneSyncPlayerMove.id, out sceneObject))
			{
				sceneObject.pos = sceneSyncPlayerMove.pos;
				if (sceneSyncPlayerMove.dir.x != 0 || sceneSyncPlayerMove.dir.y != 0)
				{
					sceneObject.dir = sceneSyncPlayerMove.dir;
				}
			}
		}

		// Token: 0x0600A84A RID: 43082 RVA: 0x002346C8 File Offset: 0x00232AC8
		private void _OnSyncSceneItemList(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncSceneItemList ==>> msg is nil");
				return;
			}
			SceneItemList sceneItemList = new SceneItemList();
			sceneItemList.decode(msg.bytes);
			this._beTownItems.Clear();
			this.mItemQueue.Clear();
			for (int i = 0; i < sceneItemList.infoes.Length; i++)
			{
				for (int j = 0; j < sceneItemList.infoes[i].items.Length; j++)
				{
					BeItemData data = new BeItemData
					{
						mDropItem = sceneItemList.infoes[i].items[j]
					};
					BeItem fighter = new BeItem(data, this);
					this._beTownItems.AddFighter(sceneItemList.infoes[i].items[j].guid, fighter);
				}
			}
			this.CreateItemList();
		}

		// Token: 0x0600A84B RID: 43083 RVA: 0x00234798 File Offset: 0x00232B98
		protected BeFighter _CreateTownPlayer(SceneObject sceneObj, int a_nSceneID)
		{
			BeFighter result = null;
			try
			{
				if ((ulong)sceneObj.sceneId != (ulong)((long)a_nSceneID))
				{
					return null;
				}
				if (sceneObj.dir == null)
				{
					return null;
				}
				if (sceneObj.pos == null)
				{
					return null;
				}
				BeFighterData beFighterData = new BeFighterData
				{
					GUID = sceneObj.id,
					Name = sceneObj.name,
					NameColor = PlayerInfoColor.TOWN_OTHER_PLAYER,
					JobID = (int)sceneObj.occu,
					RoleLv = sceneObj.level,
					pkRank = (int)sceneObj.seasonLevel,
					pkStar = (int)sceneObj.seasonStar,
					tittle = sceneObj.title,
					State = (int)sceneObj.state,
					petID = (int)sceneObj.followPetDataId,
					avatorInfo = sceneObj.avatar,
					GuildName = sceneObj.guildName,
					GuildPost = sceneObj.guildPost,
					ZoneID = (int)sceneObj.zoneId,
					awaken = (int)sceneObj.awaken
				};
				if (sceneObj.vip != null)
				{
					beFighterData.vip = (int)sceneObj.vip.level;
				}
				beFighterData.MoveData.PosLogicToGraph = this._logicToGraph;
				beFighterData.MoveData.PosServerToClient = this._serverToClient;
				beFighterData.MoveData.ServerPosition = new Vector3(sceneObj.pos.x / this._axisScale, 0f, sceneObj.pos.y / this._axisScale);
				beFighterData.MoveData.FaceRight = (sceneObj.dir.faceRight >= 1);
				Vec3 vec = (!Global.Settings.townPlayerRun) ? Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townWalkSpeed) : Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
				beFighterData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * ((float)sceneObj.moveSpeed / (float)GlobalLogic.VALUE_1000);
				beFighterData.MoveData.TargetDirection = new Vector3((float)sceneObj.dir.x / this._axisScale, 0f, (float)sceneObj.dir.y / this._axisScale);
				if (sceneObj.buffList != null)
				{
					if (!this._beTownPlayerBuffs.ContainsKey(sceneObj.id))
					{
						this._beTownPlayerBuffs.Add(sceneObj.id, new BeFightBuffManager());
					}
					BeFightBuffManager beFightBuffManager = this._beTownPlayerBuffs[sceneObj.id];
					for (int i = 0; i < sceneObj.buffList.Count; i++)
					{
						Battle.DungeonBuff dungeonBuff = sceneObj.buffList[i];
						BeFightBuff buffByGUID = beFightBuffManager.GetBuffByGUID(dungeonBuff.uid);
						if (buffByGUID != null)
						{
							buffByGUID.Refresh(dungeonBuff.duration, dungeonBuff.overlay);
						}
						else
						{
							beFightBuffManager.AddBuff(dungeonBuff.id, dungeonBuff.uid, sceneObj.id, dungeonBuff.duration, dungeonBuff.overlay);
						}
					}
				}
				result = new BeFighter(beFighterData, this);
			}
			catch (Exception ex)
			{
				Logger.LogError("TownPlayer Create Error!");
			}
			return result;
		}

		// Token: 0x0600A84C RID: 43084 RVA: 0x00234AF0 File Offset: 0x00232EF0
		protected void _CreateTownPlayer(SceneObject sceneObj)
		{
			if (sceneObj == null)
			{
				return;
			}
			BeFighter beFighter = this._CreateTownPlayer(sceneObj, this.CurrentSceneID);
			if (beFighter != null)
			{
				ulong id = sceneObj.id;
				if (this.PlayerOthersData.ContainsKey(id))
				{
					this.PlayerOthersData[id] = sceneObj;
					BeFighter fighter = this.mFighters.GetFighter(id);
					if (fighter != null)
					{
						fighter.Dispose();
						this.mFighters.RemoveFighter(id);
						this.mFighters.AddFighter(id, beFighter);
					}
					if (this._beDisplayPlayerList.Contains(beFighter.ActorData.GUID))
					{
						beFighter.InitGeActor(this._geScene);
						BeFightBuffManager beFightBuffManager = null;
						if (this._beTownPlayerBuffs.ContainsKey(beFighter.ActorData.GUID))
						{
							beFightBuffManager = this._beTownPlayerBuffs[beFighter.ActorData.GUID];
						}
						if (beFightBuffManager == null)
						{
							return;
						}
						for (int i = 0; i < beFightBuffManager.Count(); i++)
						{
							BeFightBuff beFightBuff = beFightBuffManager.Get(i);
							if (beFightBuff != null)
							{
								beFightBuff.Start(beFighter.GraphicActor);
							}
						}
						List<ulong> otherDeadPlayers = DataManager<ChijiDataManager>.GetInstance().OtherDeadPlayers;
						for (int j = 0; j < otherDeadPlayers.Count; j++)
						{
							if (otherDeadPlayers[j] == beFighter.ActorData.GUID)
							{
								beFighter.SetDead();
							}
						}
					}
					else
					{
						beFighter.RemoveGeActor();
					}
				}
				else
				{
					this.PlayerOthersData.Add(id, sceneObj);
					if (this.mFighters.GetFighter(id) == null)
					{
						this.mFighters.AddFighter(id, beFighter);
					}
					this._AddDisplayActor(id);
				}
			}
		}

		// Token: 0x0600A84D RID: 43085 RVA: 0x00234C98 File Offset: 0x00233098
		private void _InitOtherPlayerData(MsgDATA a_msg, uint a_sceneID)
		{
			this.PlayerOthersData.Clear();
			if (a_msg != null)
			{
				int num = 0;
				Dictionary<ulong, SceneObject> dictionary = SceneObjectDecoder.DecodeSyncSceneObjectMsg(a_msg.bytes, ref num, a_msg.bytes.Length);
				if (dictionary != null)
				{
					foreach (KeyValuePair<ulong, SceneObject> keyValuePair in dictionary)
					{
						ulong key = keyValuePair.Key;
						Dictionary<ulong, SceneObject>.Enumerator enumerator;
						KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
						if (keyValuePair2.Value.sceneId == a_sceneID)
						{
							if (this.PlayerOthersData.ContainsKey(key))
							{
								Dictionary<ulong, SceneObject> playerOthersData = this.PlayerOthersData;
								ulong key2 = key;
								KeyValuePair<ulong, SceneObject> keyValuePair3 = enumerator.Current;
								playerOthersData[key2] = keyValuePair3.Value;
							}
							else
							{
								Dictionary<ulong, SceneObject> playerOthersData2 = this.PlayerOthersData;
								ulong key3 = key;
								KeyValuePair<ulong, SceneObject> keyValuePair4 = enumerator.Current;
								playerOthersData2.Add(key3, keyValuePair4.Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A84E RID: 43086 RVA: 0x00234D66 File Offset: 0x00233166
		public BeFighter GetPlayer(ulong playerID)
		{
			if (playerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return this.MainPlayer;
			}
			return this.mFighters.GetFighter(playerID);
		}

		// Token: 0x0600A84F RID: 43087 RVA: 0x00234D8C File Offset: 0x0023318C
		public void OnNotifyTownPlayerLvChanged(uint iPlayerID, int iLevel)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnLevelChanged(iLevel);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.OnLevelChanged((int)DataManager<PlayerBaseData>.GetInstance().Level);
			}
		}

		// Token: 0x0600A850 RID: 43088 RVA: 0x00234E2C File Offset: 0x0023322C
		public void OnNotifyTownPlayerGuildNameChanged(uint iPlayerID, string name)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnGuildNameChanged(name);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.OnGuildNameChanged(name);
			}
		}

		// Token: 0x0600A851 RID: 43089 RVA: 0x00234EC4 File Offset: 0x002332C4
		public void OnNotifyTownPlayerAdventTeamNameChanged(uint iPlayerID, string name)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateAdventTeamName(name);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.UpdateAdventTeamName(name);
			}
		}

		// Token: 0x0600A852 RID: 43090 RVA: 0x00234F5C File Offset: 0x0023335C
		public void OnNotifyTownPlayerTitleNameChanged(uint iPlayerID, PlayerWearedTitleInfo playerWearedTitleInfo)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateTitleName(playerWearedTitleInfo);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.UpdateTitleName(playerWearedTitleInfo);
			}
		}

		// Token: 0x0600A853 RID: 43091 RVA: 0x00234FF4 File Offset: 0x002333F4
		public void OnNotifyTownPlayerGuildLvChanged(uint iPlayerID, uint guildEmblemLv)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateGuidLv((int)guildEmblemLv);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.UpdateGuidLv((int)guildEmblemLv);
			}
		}

		// Token: 0x0600A854 RID: 43092 RVA: 0x0023508C File Offset: 0x0023348C
		public void OnNotifyTownPlayerGuildDutyChanged(uint iPlayerID, byte duty)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnGuildPostChanged(duty);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.OnGuildPostChanged(duty);
			}
		}

		// Token: 0x0600A855 RID: 43093 RVA: 0x00235124 File Offset: 0x00233524
		public void OnNotifyTownPlayerTittleChanged(uint iPlayerID, int iTittle)
		{
			if (this.MainPlayer != null)
			{
				BeFighterData beFighterData = this.MainPlayer.ActorData as BeFighterData;
				if (beFighterData != null && (beFighterData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnTittleChanged(iTittle);
					}
					return;
				}
			}
			BeFighter fighter = this.mFighters.GetFighter((ulong)iPlayerID);
			if (fighter != null && fighter != null && fighter.GraphicActor != null)
			{
				fighter.GraphicActor.OnTittleChanged(iTittle);
				if (fighter.GrassStatus == BeBaseFighter.GRASS_STATUS.IN_GRASS)
				{
					fighter.GraphicActor.SetActorVisible(false);
				}
			}
		}

		// Token: 0x04005DE8 RID: 24040
		protected ISceneData _levelData;

		// Token: 0x04005DE9 RID: 24041
		private List<ClientSystemGameBattle.SceneNode> m_sceneNodes = new List<ClientSystemGameBattle.SceneNode>();

		// Token: 0x04005DEA RID: 24042
		protected GeSceneEx _geScene;

		// Token: 0x04005DEB RID: 24043
		protected Vector3 _logicToGraph;

		// Token: 0x04005DEC RID: 24044
		protected Vector3 _serverToClient;

		// Token: 0x04005DED RID: 24045
		protected BeFighterManager<BeFighter> mFighters = new BeFighterManager<BeFighter>();

		// Token: 0x04005DEE RID: 24046
		protected BeFighterMain mMainPlayer;

		// Token: 0x04005DEF RID: 24047
		public Dictionary<ulong, SceneObject> PlayerOthersData = new Dictionary<ulong, SceneObject>();

		// Token: 0x04005DF0 RID: 24048
		protected Dictionary<ulong, BeFightBuffManager> _beTownPlayerBuffs = new Dictionary<ulong, BeFightBuffManager>();

		// Token: 0x04005DF1 RID: 24049
		protected List<ulong> _beDisplayPlayerList = new List<ulong>();

		// Token: 0x04005DF2 RID: 24050
		protected int _beDisplayNum;

		// Token: 0x04005DF3 RID: 24051
		public bool IsNet = true;

		// Token: 0x04005DF4 RID: 24052
		protected float _axisScale = 10000f;

		// Token: 0x04005DF5 RID: 24053
		private bool _isSwithScene;

		// Token: 0x04005DF6 RID: 24054
		private bool mIsTownSceneSwitching;

		// Token: 0x04005DF7 RID: 24055
		private float fChijiTimeInterval = 0.15f;

		// Token: 0x04005DF8 RID: 24056
		private float fChijiItemRefreshTime;

		// Token: 0x04005DF9 RID: 24057
		protected uint m_BgmHandle = uint.MaxValue;

		// Token: 0x04005DFA RID: 24058
		private int _currentSceneId;

		// Token: 0x04005DFB RID: 24059
		protected BeFighterManager<BeItem> _beTownItems = new BeFighterManager<BeItem>();

		// Token: 0x04005DFC RID: 24060
		protected BeFighterManager<BeNPC> _beNPCs = new BeFighterManager<BeNPC>();

		// Token: 0x04005DFD RID: 24061
		protected BeFighterManager<BeBattleProjectile> _beProjectiles = new BeFighterManager<BeBattleProjectile>();

		// Token: 0x04005DFE RID: 24062
		private BePoison mPoisonRing;

		// Token: 0x04005DFF RID: 24063
		private int m_targetSceneID = -1;

		// Token: 0x04005E00 RID: 24064
		private List<SceneObject> mObjQueue = new List<SceneObject>();

		// Token: 0x04005E01 RID: 24065
		private List<BeItem> mItemQueue = new List<BeItem>();

		// Token: 0x04005E02 RID: 24066
		public int ChijiNearItemNum;

		// Token: 0x04005E03 RID: 24067
		private List<BeItem> mBuffItem = new List<BeItem>();

		// Token: 0x04005E04 RID: 24068
		private List<int> mRemoveBuffItem = new List<int>();

		// Token: 0x04005E05 RID: 24069
		private int _fromSceneId;

		// Token: 0x04005E07 RID: 24071
		private NpcDialogComponent m_kCurrentDialogComponent;

		// Token: 0x04005E08 RID: 24072
		protected Dictionary<uint, Action<MsgDATA>> _mapBindMsgHandle = new Dictionary<uint, Action<MsgDATA>>();

		// Token: 0x04005E09 RID: 24073
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache0;

		// Token: 0x0200113B RID: 4411
		private class DoorNode
		{
			// Token: 0x04005E0A RID: 24074
			public int TargetSceneIndex;

			// Token: 0x04005E0B RID: 24075
			public ISceneTownDoorData Door;
		}

		// Token: 0x0200113C RID: 4412
		private class SceneNode
		{
			// Token: 0x04005E0C RID: 24076
			public int SceneID;

			// Token: 0x04005E0D RID: 24077
			public List<ClientSystemGameBattle.DoorNode> DoorNodes;

			// Token: 0x04005E0E RID: 24078
			public bool HasVisited;
		}
	}
}
