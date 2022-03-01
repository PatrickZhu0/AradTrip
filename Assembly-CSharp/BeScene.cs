using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;

// Token: 0x020041B3 RID: 16819
[LoggerModel("Chapter")]
public class BeScene : BeStateManager<BeSceneState>
{
	// Token: 0x060171C3 RID: 94659 RVA: 0x00716FB0 File Offset: 0x007153B0
	protected BeScene()
	{
		base.state = BeSceneState.onCreate;
		this.mIsBossScene = false;
		this.mIsDoorOpened = false;
		this.checkAcc = 0;
		this.mPrePauseState = BeSceneState.onNone;
		this._initSceneExData();
	}

	// Token: 0x17001F8A RID: 8074
	// (get) Token: 0x060171C4 RID: 94660 RVA: 0x007170B5 File Offset: 0x007154B5
	// (set) Token: 0x060171C5 RID: 94661 RVA: 0x007170BD File Offset: 0x007154BD
	public BaseBattle mBattle { get; set; }

	// Token: 0x17001F8B RID: 8075
	// (get) Token: 0x060171C6 RID: 94662 RVA: 0x007170C6 File Offset: 0x007154C6
	public FrameRandomImp FrameRandom
	{
		get
		{
			return this.mBattle.FrameRandom;
		}
	}

	// Token: 0x17001F8C RID: 8076
	// (get) Token: 0x060171C7 RID: 94663 RVA: 0x007170D3 File Offset: 0x007154D3
	public TrailManagerImp TrailManager
	{
		get
		{
			return this.mBattle.TrailManager;
		}
	}

	// Token: 0x17001F8D RID: 8077
	// (get) Token: 0x060171C8 RID: 94664 RVA: 0x007170E0 File Offset: 0x007154E0
	public BeProjectilePoolImp BeProjectilePool
	{
		get
		{
			return this.mBattle.BeProjectilePool;
		}
	}

	// Token: 0x17001F8E RID: 8078
	// (get) Token: 0x060171C9 RID: 94665 RVA: 0x007170ED File Offset: 0x007154ED
	public BeActionFrameMgr ActionFrameMgr
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17001F8F RID: 8079
	// (get) Token: 0x060171CA RID: 94666 RVA: 0x007170F0 File Offset: 0x007154F0
	public SkillFileListCache SkillFileCache
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17001F90 RID: 8080
	// (get) Token: 0x060171CB RID: 94667 RVA: 0x007170F3 File Offset: 0x007154F3
	public BeAICommandPoolImp BeAICommandPool
	{
		get
		{
			return this.mBattle.BeAICommandPool;
		}
	}

	// Token: 0x060171CC RID: 94668 RVA: 0x00717100 File Offset: 0x00715500
	public bool IsBossDead()
	{
		return this.mIsBossScene && this.bossDead;
	}

	// Token: 0x17001F91 RID: 8081
	// (get) Token: 0x060171CD RID: 94669 RVA: 0x00717116 File Offset: 0x00715516
	public bool IsBossScene
	{
		get
		{
			return this.mIsBossScene;
		}
	}

	// Token: 0x17001F92 RID: 8082
	// (get) Token: 0x060171CF RID: 94671 RVA: 0x00717127 File Offset: 0x00715527
	// (set) Token: 0x060171CE RID: 94670 RVA: 0x0071711E File Offset: 0x0071551E
	public int singleBloodBarCount { get; set; }

	// Token: 0x17001F93 RID: 8083
	// (get) Token: 0x060171D0 RID: 94672 RVA: 0x0071712F File Offset: 0x0071552F
	public int GameTime
	{
		get
		{
			return this.mDurtime;
		}
	}

	// Token: 0x17001F94 RID: 8084
	// (set) Token: 0x060171D1 RID: 94673 RVA: 0x00717137 File Offset: 0x00715537
	public bool isTickAI
	{
		set
		{
			this.mIsTickAI = value;
		}
	}

	// Token: 0x17001F95 RID: 8085
	// (get) Token: 0x060171D2 RID: 94674 RVA: 0x00717140 File Offset: 0x00715540
	public DelayCaller DelayCaller
	{
		get
		{
			if (this.mDelayCaller == null)
			{
				Logger.LogError("delayCaller is nil");
			}
			return this.mDelayCaller;
		}
	}

	// Token: 0x17001F96 RID: 8086
	// (get) Token: 0x060171D3 RID: 94675 RVA: 0x0071715D File Offset: 0x0071555D
	public ISceneData sceneData
	{
		get
		{
			return this.mSceneData;
		}
	}

	// Token: 0x17001F97 RID: 8087
	// (get) Token: 0x060171D4 RID: 94676 RVA: 0x00717165 File Offset: 0x00715565
	public GeSceneEx currentGeScene
	{
		get
		{
			if (this.mCurrentGeScene == null)
			{
				Logger.LogError("currentGeScene is nil");
			}
			return this.mCurrentGeScene;
		}
	}

	// Token: 0x060171D5 RID: 94677 RVA: 0x00717182 File Offset: 0x00715582
	public bool IsShowTransportDoorCount()
	{
		return this.simpleTimer.IsCount();
	}

	// Token: 0x17001F98 RID: 8088
	// (get) Token: 0x060171D6 RID: 94678 RVA: 0x0071718F File Offset: 0x0071558F
	public int curTransportTimerId
	{
		get
		{
			return this.mCurTransportTimerID;
		}
	}

	// Token: 0x060171D7 RID: 94679 RVA: 0x00717198 File Offset: 0x00715598
	public void StopTransportDoorCount(int timerId = -1)
	{
		if (timerId != -1 && timerId != this.mCurTransportTimerID)
		{
			return;
		}
		this.simpleTimer.StopTimer();
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null)
		{
			clientSystemBattle.ShowDigit(false);
		}
	}

	// Token: 0x060171D8 RID: 94680 RVA: 0x007171E4 File Offset: 0x007155E4
	public void StartTransportDoorCount(int countSecond, SimpleTimer2.TimeUpCallBack timeupCallback)
	{
		ClientSystemBattle system = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (system != null)
		{
			system.ShowDigit(true);
			system.SetCountDigit(countSecond);
		}
		this.mCurTransportTimerID++;
		this.simpleTimer.SetCountdown(countSecond);
		this.simpleTimer.secondCallBack = delegate(int second)
		{
			if (system != null)
			{
				system.SetCountDigit(countSecond - second);
			}
		};
		this.simpleTimer.timeupCallBack = delegate()
		{
			timeupCallback();
			if (system != null)
			{
				system.ShowDigit(false);
			}
		};
		this.simpleTimer.StartTimer();
	}

	// Token: 0x060171D9 RID: 94681 RVA: 0x0071729A File Offset: 0x0071569A
	public void StartPKCountDown(int countSecond, SimpleTimer2.TimeUpCallBack timeupCallback)
	{
		this.simpleTimer.timeupCallBack = timeupCallback;
		this.simpleTimer.SetCountdown(countSecond);
		this.simpleTimer.StartTimer();
	}

	// Token: 0x060171DA RID: 94682 RVA: 0x007172BF File Offset: 0x007156BF
	public void SetTraceDoor(bool flag)
	{
		this.isTraceDoor = flag;
	}

	// Token: 0x060171DB RID: 94683 RVA: 0x007172C8 File Offset: 0x007156C8
	public void Reset()
	{
		this._initSceneExData();
	}

	// Token: 0x060171DC RID: 94684 RVA: 0x007172D0 File Offset: 0x007156D0
	private void _initSceneExData()
	{
		this.singleBloodBarCount = -1;
	}

	// Token: 0x060171DD RID: 94685 RVA: 0x007172D9 File Offset: 0x007156D9
	public void UnRegisterEvent(BeEventSceneType type, BeEventHandle.Del del)
	{
		if (this.mProcessor != null)
		{
			this.mProcessor.RemoveEventHandler((int)type, del);
		}
	}

	// Token: 0x060171DE RID: 94686 RVA: 0x007172F4 File Offset: 0x007156F4
	public BeEventHandle RegisterEvent(BeEventSceneType type, BeEventHandle.Del del)
	{
		BeEventHandle result = null;
		if (this.mProcessor != null)
		{
			result = this.mProcessor.AddEventHandler((int)type, del);
		}
		return result;
	}

	// Token: 0x060171DF RID: 94687 RVA: 0x0071731D File Offset: 0x0071571D
	public void RemoveHandle(BeEventHandle handle)
	{
		if (this.mProcessor != null)
		{
			this.mProcessor.RemoveHandler(handle);
		}
	}

	// Token: 0x060171E0 RID: 94688 RVA: 0x00717336 File Offset: 0x00715736
	public void TriggerEvent(BeEventSceneType type, object[] args = null)
	{
		if (this.mProcessor != null)
		{
			this.mProcessor.HandleEvent((int)type, args);
		}
	}

	// Token: 0x060171E1 RID: 94689 RVA: 0x00717350 File Offset: 0x00715750
	public void UnRegisterAll()
	{
		if (this.mProcessor != null)
		{
			this.mProcessor.ClearAll();
		}
		this.ClearEventAllNew();
	}

	// Token: 0x060171E2 RID: 94690 RVA: 0x0071736E File Offset: 0x0071576E
	public bool IsBossSceneClear()
	{
		return this.mIsBossScene && base.state >= BeSceneState.onClear;
	}

	// Token: 0x060171E3 RID: 94691 RVA: 0x0071738C File Offset: 0x0071578C
	private void _onClearEvent()
	{
		if (!this.mIsBossScene && this.mHell == null)
		{
			this._setTransportDoor(true);
		}
		this.FrameRandom.Range100();
		base.state = BeSceneState.onClear;
		this.TriggerEvent(BeEventSceneType.onClear, null);
		this.traceDoor = null;
		this.traceDoorPos = VInt3.zero;
		if (!this.mIsBossScene && this.isTraceDoor)
		{
			this.ChooseADoorToChance();
		}
	}

	// Token: 0x060171E4 RID: 94692 RVA: 0x007173FF File Offset: 0x007157FF
	public BeEvent.BeEventHandleNew RegisterEventNew(BeEventSceneType eventType, BeEvent.BeEventHandleNew.Function function)
	{
		if (this.m_EventManager == null)
		{
			this.m_EventManager = new BeEventManager();
		}
		return this.m_EventManager.RegisterEvent((int)eventType, function);
	}

	// Token: 0x060171E5 RID: 94693 RVA: 0x00717424 File Offset: 0x00715824
	public void TriggerEventNew(BeEventSceneType eventType, BeEvent.BeEventParam eventParam)
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.TriggerEvent((int)eventType, eventParam);
	}

	// Token: 0x060171E6 RID: 94694 RVA: 0x0071743F File Offset: 0x0071583F
	public EventParam TriggerEventNew(BeEventSceneType eventType, EventParam eventParam = default(EventParam))
	{
		if (this.m_EventManager == null)
		{
			return eventParam;
		}
		return this.m_EventManager.TriggerEvent((int)eventType, eventParam);
	}

	// Token: 0x060171E7 RID: 94695 RVA: 0x0071745B File Offset: 0x0071585B
	public void ClearEventAllNew()
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.ClearAll();
	}

	// Token: 0x060171E8 RID: 94696 RVA: 0x00717474 File Offset: 0x00715874
	public void RemoveEventNew(BeEvent.BeEventHandleNew handle)
	{
		if (this.m_EventManager == null)
		{
			return;
		}
		this.m_EventManager.RemoveSceneHandle(handle);
	}

	// Token: 0x060171E9 RID: 94697 RVA: 0x00717490 File Offset: 0x00715890
	public void LoadTaskMonsters(int taskID)
	{
		if (taskID <= 0)
		{
			return;
		}
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(taskID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.taskMonsters = tableItem.MonsterIDs;
		}
	}

	// Token: 0x060171EA RID: 94698 RVA: 0x007174CD File Offset: 0x007158CD
	public bool IsTaskMonster(int monsterID)
	{
		return this.taskMonsters != null && monsterID > 0 && this.taskMonsters.Contains(BeUtility.GetOnlyMonsterID(monsterID));
	}

	// Token: 0x060171EB RID: 94699 RVA: 0x007174F4 File Offset: 0x007158F4
	private void _initState()
	{
		GeEffectEx effect = null;
		BeStateManager<BeSceneState>.IStateEventManager stateEventManager = base._addState(BeSceneState.onBulletTime, delegate(BeSceneState fromState)
		{
			Time.timeScale = Global.Settings.bullteScale;
			DAssetObject effectRes;
			effectRes.m_AssetPath = "Effects/Scene_effects/EffectUI/EffUI_suduxian";
			effectRes.m_AssetObj = null;
			BattlePlayer mainPlayer = this.mBattle.dungeonPlayerManager.GetMainPlayer();
			if (mainPlayer != null)
			{
				effect = mainPlayer.playerActor.m_pkGeActor.CreateEffect(effectRes, new EffectsFrames(), 0f, mainPlayer.playerActor.GetPosition().vec3, 1f, 1f, false, false, false);
			}
			this.bossDeadTimeStamp = Utility.GetTimeStamp();
		}, delegate(BeSceneState toState)
		{
			Time.timeScale = 1f;
			if (effect != null)
			{
				effect.Remove();
				effect = null;
			}
		});
		BeStateManager<BeSceneState>.BaseEventNode node = new BeStateManager<BeSceneState>.BaseEventNode("bullte2fight", VInt.Float2VIntValue((float)Global.Settings.bullteTime * Global.Settings.bullteScale), delegate()
		{
			this.state = BeSceneState.onFight;
		}, BeStateManager<BeSceneState>.eBeStateReentrantType.Continue);
		stateEventManager.Add(node);
		BeStateManager<BeSceneState>.IStateEventManager stateEventManager2 = base._addState(BeSceneState.onReady, delegate(BeSceneState fromState)
		{
		}, delegate(BeSceneState toState)
		{
			for (int i = 0; i < this.mEntitys.Count; i++)
			{
				BeActor beActor = this.mEntitys[i] as BeActor;
				if (beActor != null)
				{
					if (beActor.m_iCamp == 1 && !beActor.isMainActor)
					{
						beActor.StartAI(null, true);
					}
					else if (beActor.m_iCamp == 0 && this.mBattle.GetBattleType() == BattleType.GuildPVE)
					{
						beActor.StartAI(null, true);
					}
				}
			}
		});
		BeStateManager<BeSceneState>.BaseEventNode node2 = new BeStateManager<BeSceneState>.BaseEventNode("onready2fight", GlobalLogic.VALUE_1000, delegate()
		{
			base.state = BeSceneState.onFight;
		}, BeStateManager<BeSceneState>.eBeStateReentrantType.Reset);
		stateEventManager2.Add(node2);
		base._addState(BeSceneState.onFight, delegate(BeSceneState from)
		{
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonOnFight, null, null, null, null);
		}, delegate(BeSceneState to)
		{
		});
		base._addState(BeSceneState.onFinish, delegate(BeSceneState from)
		{
			if (this.mBattle == null || this.mBattle.dungeonPlayerManager == null)
			{
				return;
			}
			if (BattleMain.IsModePVP3V3(this.mBattle.GetBattleType()))
			{
				PVP3V3Battle pvp3V3Battle = this.mBattle as PVP3V3Battle;
				if (pvp3V3Battle == null)
				{
					return;
				}
				BeActor winActor = pvp3V3Battle.GetWinActor();
				if (winActor != null)
				{
					winActor.winHandler = BeUtility.ShowWin(winActor, winActor.winHandler);
				}
			}
			else if (this.mBattle is PVPBattle)
			{
				PVPBattle pvpbattle = this.mBattle as PVPBattle;
				if (pvpbattle != null)
				{
					pvpbattle.OnPlayWinAction(ePVPBattleEndType.onAllEnemyDied);
				}
			}
			else
			{
				if (this.mBattle.dungeonPlayerManager.GetMainPlayer() == null)
				{
					return;
				}
				BeActor playerActor = this.mBattle.dungeonPlayerManager.GetMainPlayer().playerActor;
				if (playerActor != null && this.mBattle.GetBattleType() != BattleType.NewbieGuide)
				{
					playerActor.winHandler = BeUtility.ShowWin(playerActor, playerActor.winHandler);
				}
			}
		}, delegate(BeSceneState to)
		{
		});
	}

	// Token: 0x060171EC RID: 94700 RVA: 0x00717639 File Offset: 0x00715A39
	public void OnReady()
	{
		if (this.isUseBossShow)
		{
			this.DelayCaller.DelayCall(100, delegate
			{
				this.DoBossShow();
			}, 0, 0, false);
		}
		this.FinishTraceDoor();
	}

	// Token: 0x060171ED RID: 94701 RVA: 0x0071766C File Offset: 0x00715A6C
	public void DoBossShow()
	{
		if (this.mIsBossScene)
		{
			if (this.mBattle.GetBattleType() == BattleType.DeadTown || this.mBattle.GetBattleType() == BattleType.ChampionMatch || this.mBattle.GetBattleType() == BattleType.TreasureMap)
			{
				return;
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowBossWarning();
			}
		}
	}

	// Token: 0x060171EE RID: 94702 RVA: 0x007176D8 File Offset: 0x00715AD8
	protected int _genID()
	{
		return ++this.sID;
	}

	// Token: 0x060171EF RID: 94703 RVA: 0x007176F6 File Offset: 0x00715AF6
	public void ClearSID()
	{
		this.sID = 0;
	}

	// Token: 0x060171F0 RID: 94704 RVA: 0x00717700 File Offset: 0x00715B00
	public static BeScene CreateScene(string path)
	{
		BeScene beScene = new BeScene();
		beScene.Load(path);
		beScene.mDurtime = 0;
		if (BattleMain.instance != null && BattleMain.battleType == BattleType.Dungeon)
		{
			beScene.LoadTaskMonsters(DataManager<MissionManager>.GetInstance().GetMainTask(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId));
		}
		return beScene;
	}

	// Token: 0x060171F1 RID: 94705 RVA: 0x00717756 File Offset: 0x00715B56
	private void _originEntityRemoveAll()
	{
		this._EntityRemoveAll(true, delegate(BeEntity item)
		{
			if (item.m_iCamp == 0)
			{
				return this._isNeedRemoveByBeEntity(item);
			}
			item.ClearEvent();
			if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.OnRemove) && item is BeActor)
			{
				item.OnDead();
			}
			item.OnRemove(false);
			return true;
		});
	}

	// Token: 0x060171F2 RID: 94706 RVA: 0x0071776B File Offset: 0x00715B6B
	public void Pvp3v3EntityRemoveAll()
	{
		this._EntityRemoveAll(true, delegate(BeEntity item)
		{
			if (item.m_iCamp == 1 || item.m_iCamp == 0)
			{
				return this._isNeedRemoveByBeEntity(item);
			}
			item.ClearEvent();
			item.OnRemove(false);
			return true;
		});
	}

	// Token: 0x060171F3 RID: 94707 RVA: 0x00717780 File Offset: 0x00715B80
	private bool _isNeedRemoveByBeEntity(BeEntity item)
	{
		if (item == null)
		{
			return true;
		}
		BeActor beActor = item as BeActor;
		if (beActor != null && !beActor.IsDead())
		{
			if (beActor.GetEntityData().isPet)
			{
				return false;
			}
			bool flag;
			if (this.mBattle != null && !this.mBattle.FunctionIsOpen(BattleFlagType.EntityRemoveInPassDoor))
			{
				flag = ((beActor.GetEntityData().isSummonMonster && !beActor.stateController.HasBornAbility(BeAbilityType.MOVE)) || (!beActor.stateController.HasBornAbility(BeAbilityType.BLOCK) && !beActor.stateController.NotRemoveTransDoor()));
			}
			else
			{
				flag = ((beActor.GetEntityData().isSummonMonster && !beActor.stateController.HasBornAbility(BeAbilityType.MOVE)) || (!beActor.stateController.BlockByScene() && !beActor.stateController.NotRemoveTransDoor()));
			}
			if (flag)
			{
				item.TriggerEvent(BeEventType.onDead, new object[]
				{
					new int[]
					{
						0
					},
					false,
					item
				});
				item.SetIsDead(true);
				item.ClearEvent();
				item.OnDead();
				item.OnRemove(false);
				return true;
			}
		}
		if (item is BeProjectile || item is BeObject)
		{
			item.ClearEvent();
			item.OnRemove(false);
			return true;
		}
		return false;
	}

	// Token: 0x060171F4 RID: 94708 RVA: 0x007178E3 File Offset: 0x00715CE3
	public void SetDayTime(bool isDayTime)
	{
		this.mIsDayTime = isDayTime;
	}

	// Token: 0x060171F5 RID: 94709 RVA: 0x007178EC File Offset: 0x00715CEC
	public bool IsDayTime()
	{
		return this.mIsDayTime;
	}

	// Token: 0x060171F6 RID: 94710 RVA: 0x007178F4 File Offset: 0x00715CF4
	public void ReloadScene(ISceneData data)
	{
		if (data == null)
		{
			Logger.LogError("data is nil");
			return;
		}
		this.mSceneData = data;
		this.mCurrentGeScene.ReloadSceneWithSameScene(this.mSceneData);
		this._setBlockInfo();
		this._RemoveRegion(true, delegate(BeRegionBase item)
		{
			item.Remove();
			return true;
		});
		this.mDoorList.Clear();
		this.mDecoratorList.RemoveAll(delegate(GeActorEx item)
		{
			this.mCurrentGeScene.DestroyActor(item);
			return true;
		});
		base._resetState();
		this.mIsBossScene = false;
		this.mIsDoorOpened = false;
		this.mPrePauseState = BeSceneState.onNone;
		base.state = BeSceneState.onCreate;
	}

	// Token: 0x060171F7 RID: 94711 RVA: 0x00717999 File Offset: 0x00715D99
	public void ReloadScene(string path)
	{
		this._originEntityRemoveAll();
		this.LoadSceneData(path);
		this.ReloadScene(this.mSceneData);
		this.mDurtime = 0;
		Singleton<GeWeatherManager>.instance.ChangeWeather(this.sceneData.GetWeatherMode());
	}

	// Token: 0x060171F8 RID: 94712 RVA: 0x007179D0 File Offset: 0x00715DD0
	private bool _loadSceneData(string path)
	{
		this.mSceneData = DungeonUtility.LoadSceneData(path);
		if (this.mSceneData != null)
		{
			this.logicWidth = this.sceneData.GetLogicX();
			this.logicHeight = this.sceneData.GetLogicZ();
			this.logicXSize = new VInt2(this.sceneData.GetLogicXSize().x, this.sceneData.GetLogicXSize().y);
			this.logicZSize = new VInt2(this.sceneData.GetLogicZSize().x, this.sceneData.GetLogicZSize().y);
			this.logicGrild = new VInt2(this.sceneData.GetGridSize().x, this.sceneData.GetGridSize().y);
			return true;
		}
		Logger.LogErrorFormat("can't load with path \"{0}\"!", new object[]
		{
			path
		});
		return false;
	}

	// Token: 0x060171F9 RID: 94713 RVA: 0x00717AC4 File Offset: 0x00715EC4
	private void _setBlockInfo()
	{
		this.mBlockInfo = new byte[this.mSceneData.GetBlockLayerLength()];
		if (this.mSceneData.GetBlockLayerLength() > 0)
		{
			Array.Copy(this.mSceneData.GetRawBlockLayer(), this.mBlockInfo, this.mSceneData.GetBlockLayerLength());
		}
	}

	// Token: 0x060171FA RID: 94714 RVA: 0x00717B19 File Offset: 0x00715F19
	public void LoadSceneData(string path)
	{
		if (this._loadSceneData(path))
		{
			this._setBlockInfo();
		}
	}

	// Token: 0x060171FB RID: 94715 RVA: 0x00717B30 File Offset: 0x00715F30
	private void _loadDynSceneSetting()
	{
		if (this.sceneData == null)
		{
			return;
		}
		DynSceneSetting lightmapsettings = Singleton<AssetLoader>.instance.LoadRes(this.sceneData.GetLightmapsettingsPath(), typeof(DynSceneSetting), true, 0U).obj as DynSceneSetting;
		this.sceneData.SetLightmapsettings(lightmapsettings);
		if (this.sceneData.GetLightmapsettings() != null)
		{
			this.sceneData.GetLightmapsettings().Apply();
		}
	}

	// Token: 0x060171FC RID: 94716 RVA: 0x00717BA7 File Offset: 0x00715FA7
	public void Load(string path)
	{
		this._initState();
		this.LoadSceneData(path);
		this.AttachGeScene();
	}

	// Token: 0x060171FD RID: 94717 RVA: 0x00717BBC File Offset: 0x00715FBC
	public void AttachGeScene()
	{
		this.DettachGeScene();
		this._loadDynSceneSetting();
		this.mCurrentGeScene = new GeSceneEx();
		this.mCurrentGeScene.LoadScene(this.sceneData, true, false);
		Singleton<GeWeatherManager>.instance.ChangeWeather(this.sceneData.GetWeatherMode());
	}

	// Token: 0x060171FE RID: 94718 RVA: 0x00717C09 File Offset: 0x00716009
	public void DettachGeScene()
	{
		if (this.mCurrentGeScene != null)
		{
			this.mCurrentGeScene.UnloadScene(true, false);
			this.mCurrentGeScene = null;
		}
	}

	// Token: 0x060171FF RID: 94719 RVA: 0x00717C2A File Offset: 0x0071602A
	private void DettachEntity()
	{
	}

	// Token: 0x06017200 RID: 94720 RVA: 0x00717C2C File Offset: 0x0071602C
	public List<BeEntity> GetSaveTempList()
	{
		return this.mTempSaveEntitys;
	}

	// Token: 0x06017201 RID: 94721 RVA: 0x00717C34 File Offset: 0x00716034
	public void RemoveToTemp(BeEntity actor)
	{
		this.mEntitys.Remove(actor);
		this.mTempSaveEntitys.Add(actor);
	}

	// Token: 0x06017202 RID: 94722 RVA: 0x00717C4F File Offset: 0x0071604F
	public void RestoreFromTemp(BeEntity actor)
	{
		if (!this.mEntitys.Contains(actor))
		{
			this.mEntitys.Add(actor);
		}
		this.mTempSaveEntitys.Remove(actor);
	}

	// Token: 0x06017203 RID: 94723 RVA: 0x00717C7B File Offset: 0x0071607B
	public void ClearTempSavedEntitys()
	{
		this.mTempSaveEntitys.RemoveAll(delegate(BeEntity x)
		{
			x.ClearEvent();
			x.OnRemove(true);
			return true;
		});
	}

	// Token: 0x06017204 RID: 94724 RVA: 0x00717CA6 File Offset: 0x007160A6
	public void ClearBossDeadBody()
	{
		this.mDeadBody.RemoveAll(delegate(BeEntity x)
		{
			x.ClearEvent();
			x.OnRemove(true);
			return true;
		});
	}

	// Token: 0x06017205 RID: 94725 RVA: 0x00717CD4 File Offset: 0x007160D4
	public void ClearAllEntity(bool removeMechanismFlag = false)
	{
		this.mHell = null;
		this._EntityRemoveAll(true, delegate(BeEntity x)
		{
			BeActor beActor = x as BeActor;
			if (removeMechanismFlag && beActor != null)
			{
				beActor.RemoveAllMechanism();
			}
			x.ClearEvent();
			x.OnRemove(true);
			return true;
		});
	}

	// Token: 0x06017206 RID: 94726 RVA: 0x00717D08 File Offset: 0x00716108
	public void Unload()
	{
		this.mPrePauseState = BeSceneState.onNone;
		this.ClearBossDeadBody();
		this.ClearTempSavedEntitys();
		this.ClearAllEntity(false);
		base._clearAllStates();
		this.UnRegisterAll();
		if (this.DelayCaller != null)
		{
			this.DelayCaller.Clear();
		}
		this.BeAICommandPool.Clear();
		this.BeProjectilePool.Clear();
		this.DettachGeScene();
		Singleton<GeAnimatInstPool>.instance.ClearAll();
		BeActionFrameMgr.Clear();
		BeActionFrameMgr.ClearSkillObjectCache();
		SkillFileListCache.Clear();
		this.mSceneData = null;
	}

	// Token: 0x06017207 RID: 94727 RVA: 0x00717D90 File Offset: 0x00716190
	private void _setTransportDoor(bool state)
	{
		if (this.mIsDoorOpened != state)
		{
			this.mIsDoorOpened = state;
			for (int i = 0; i < this.mDoorList.Count; i++)
			{
				BeRegionTransportDoor beRegionTransportDoor = this.mDoorList[i] as BeRegionTransportDoor;
				if (beRegionTransportDoor != null)
				{
					if (!beRegionTransportDoor.isEggDoor || !state)
					{
						beRegionTransportDoor.active = state;
						beRegionTransportDoor.activeEffect = state;
					}
				}
			}
			this.TriggerEvent(BeEventSceneType.onDoorStateChange, new object[]
			{
				state
			});
		}
	}

	// Token: 0x06017208 RID: 94728 RVA: 0x00717E20 File Offset: 0x00716220
	public void OpenEggDoor()
	{
		for (int i = 0; i < this.mDoorList.Count; i++)
		{
			BeRegionTransportDoor beRegionTransportDoor = this.mDoorList[i] as BeRegionTransportDoor;
			if (beRegionTransportDoor != null && beRegionTransportDoor.isEggDoor)
			{
				beRegionTransportDoor.active = true;
				beRegionTransportDoor.activeEffect = true;
			}
		}
	}

	// Token: 0x06017209 RID: 94729 RVA: 0x00717E7A File Offset: 0x0071627A
	public List<BeRegionBase> GetDoorList()
	{
		return this.mDoorList;
	}

	// Token: 0x0601720A RID: 94730 RVA: 0x00717E84 File Offset: 0x00716284
	public BeActor AddActor(int iResID, int iCamp, int iID = -1, bool useCube = false)
	{
		if (iID == -1)
		{
			iID = this._genID();
		}
		BeActor beActor = new BeActor(iResID, iCamp, iID);
		this.mCheckMonsterDirtyFlag = true;
		this.mPendingArray.Add(beActor);
		beActor.SetBeScene(this);
		beActor.Create(0, useCube);
		return beActor;
	}

	// Token: 0x0601720B RID: 94731 RVA: 0x00717ED0 File Offset: 0x007162D0
	public BeProjectile AddProjectile(int iResID, int iCamp, int type, int value, int triggerSkillLevel = 1, BeEntity owner = null, int iID = -1, bool useCube = false)
	{
		if (iID == -1)
		{
			iID = this._genID();
		}
		BeProjectile projectile = this.BeProjectilePool.GetProjectile(iResID, iCamp, iID, useCube);
		if (owner != null)
		{
			projectile.SetOwner(owner);
		}
		projectile.triggerSkillLevel = triggerSkillLevel;
		projectile.SetType((ProjectType)type, value);
		this.mPendingArray.Add(projectile);
		projectile.SetBeScene(this);
		projectile.Create(0f, useCube);
		this.TriggerEvent(BeEventSceneType.onAddEntity, new object[]
		{
			projectile
		});
		return projectile;
	}

	// Token: 0x0601720C RID: 94732 RVA: 0x00717F54 File Offset: 0x00716354
	public BeObject AddLogicObject(int resID, int camp = 2)
	{
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			BeObject logicObject = new BeObject(resID, camp, this._genID());
			this.mPendingArray.Add(logicObject);
			logicObject.SetBeScene(this);
			logicObject.Create(1);
			logicObject.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				logicObject.SetBlockLayer(false);
			});
			return logicObject;
		}
		return null;
	}

	// Token: 0x0601720D RID: 94733 RVA: 0x00717FE4 File Offset: 0x007163E4
	public BeRegion AddRegion(ISceneRegionInfoData info, BeRegionBase.TriggerTarget target)
	{
		BeRegion beRegion = new BeRegion();
		beRegion.SetBeScene(this);
		beRegion.Create(info, false);
		beRegion.SetPosition(new VInt3(info.GetEntityInfo().GetPosition()));
		beRegion.SetScale((VInt)info.GetEntityInfo().GetScale());
		beRegion.triggerTarget = target;
		if (beRegion != null)
		{
			this.mPendingRegion.Add(beRegion);
		}
		return beRegion;
	}

	// Token: 0x0601720E RID: 94734 RVA: 0x0071804C File Offset: 0x0071644C
	public BeRegionDropItem AddDropItem(ISceneRegionInfoData info, DungeonDropItem dropItem, VInt3 originPos, bool needAdd = true, bool needTargetList = true)
	{
		if (needAdd)
		{
			List<int> dropItemIds = DataManager<BattleDataManager>.GetInstance().BattleInfo.dropItemIds;
			int num = dropItemIds.BinarySearch(dropItem.id);
			if (num < 0)
			{
				DataManager<BattleDataManager>.GetInstance().BattleInfo.dropItemIds.Insert(~num, dropItem.id);
				DataManager<BattleDataManager>.GetInstance().BattleInfo.dropCacheItemIds.Add(dropItem);
			}
			else
			{
				Logger.LogErrorFormat("already pick up the item with id {0}", new object[]
				{
					dropItem.id
				});
			}
		}
		BeRegionDropItem beRegionDropItem = new BeRegionDropItem();
		beRegionDropItem.SetBeScene(this);
		beRegionDropItem.SetDropItem(dropItem);
		beRegionDropItem.Create(info, false);
		beRegionDropItem.SetScale((VInt)info.GetEntityInfo().GetScale());
		beRegionDropItem.SetPosition(originPos);
		if (needTargetList)
		{
			beRegionDropItem.triggerTarget = new BeRegionBase.TriggerTarget(this._regionTargetList);
		}
		else
		{
			beRegionDropItem.triggerTarget = new BeRegionBase.TriggerTarget(this._defaultRegionTargetList);
		}
		beRegionDropItem.StartTrail(originPos, new VInt3(info.GetEntityInfo().GetPosition()));
		if (beRegionDropItem != null)
		{
			this.mPendingRegion.Add(beRegionDropItem);
		}
		return beRegionDropItem;
	}

	// Token: 0x0601720F RID: 94735 RVA: 0x0071816C File Offset: 0x0071656C
	public void ForcePickUpDropItem(BeActor actor)
	{
		for (int i = 0; i < this.mRegions.Count; i++)
		{
			BeRegionDropItem beRegionDropItem = this.mRegions[i] as BeRegionDropItem;
			if (beRegionDropItem != null)
			{
				beRegionDropItem.ForceTriggerEnter(actor);
			}
		}
	}

	// Token: 0x06017210 RID: 94736 RVA: 0x007181B4 File Offset: 0x007165B4
	public bool CheckInDoorRange(BeActor actor)
	{
		bool result = false;
		for (int i = 0; i < this.mDoorList.Count; i++)
		{
			BeRegionTransportDoor beRegionTransportDoor = this.mDoorList[i] as BeRegionTransportDoor;
			if (beRegionTransportDoor != null && beRegionTransportDoor.CheckInDoorRange(actor))
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06017211 RID: 94737 RVA: 0x00718208 File Offset: 0x00716608
	private List<BattlePlayer> _regionTargetList()
	{
		List<BattlePlayer> list = new List<BattlePlayer>();
		BattlePlayer mainPlayer = this.mBattle.dungeonPlayerManager.GetMainPlayer();
		list.Add(mainPlayer);
		return list;
	}

	// Token: 0x06017212 RID: 94738 RVA: 0x00718234 File Offset: 0x00716634
	private List<BattlePlayer> _defaultRegionTargetList()
	{
		if (this.defaultTargetList == null)
		{
			this.defaultTargetList = new List<BattlePlayer>();
		}
		return this.defaultTargetList;
	}

	// Token: 0x06017213 RID: 94739 RVA: 0x00718254 File Offset: 0x00716654
	public BeRegionTransportDoor AddTransportDoor(ISceneRegionInfoData info, BeRegionBase.TriggerTarget target, BeRegionBase.TriggerRegion callback = null, bool isboss = false, bool isvisited = false, TransportDoorType doorType = TransportDoorType.None, bool isEggDoor = false)
	{
		BeRegionTransportDoor beRegionTransportDoor = new BeRegionTransportDoor();
		beRegionTransportDoor.SetBeScene(this);
		beRegionTransportDoor.Create(info, isboss, doorType);
		beRegionTransportDoor.SetPosition(new VInt3(info.GetEntityInfo().GetPosition()));
		beRegionTransportDoor.SetScale((VInt)info.GetEntityInfo().GetScale());
		beRegionTransportDoor.SetVisited(isvisited);
		beRegionTransportDoor.SetDoorType(doorType);
		beRegionTransportDoor.isEggDoor = isEggDoor;
		beRegionTransportDoor.triggerTarget = target;
		beRegionTransportDoor.triggerRegion = callback;
		if (this.mBattle.recordServer.IsProcessRecord())
		{
			this.mBattle.recordServer.MarkInt(142055321U, new int[]
			{
				beRegionTransportDoor.position.x,
				beRegionTransportDoor.position.y,
				beRegionTransportDoor.position.z,
				(int)doorType
			});
		}
		this.mDoorList.Add(beRegionTransportDoor);
		this.mPendingRegion.Add(beRegionTransportDoor);
		return beRegionTransportDoor;
	}

	// Token: 0x06017214 RID: 94740 RVA: 0x0071834C File Offset: 0x0071674C
	public void SetBossTransportDoorEffectState(bool isopen)
	{
		for (int i = 0; i < this.mDoorList.Count; i++)
		{
			BeRegionTransportDoor beRegionTransportDoor = this.mDoorList[i] as BeRegionTransportDoor;
			if (beRegionTransportDoor != null && beRegionTransportDoor.IsBoss())
			{
				beRegionTransportDoor.activeEffect = isopen;
			}
		}
	}

	// Token: 0x06017215 RID: 94741 RVA: 0x007183A0 File Offset: 0x007167A0
	public void SetTransportDoorEnable(TransportDoorType type, bool isenable)
	{
		for (int i = 0; i < this.mDoorList.Count; i++)
		{
			BeRegionTransportDoor beRegionTransportDoor = this.mDoorList[i] as BeRegionTransportDoor;
			if (beRegionTransportDoor != null)
			{
				ISceneTransportDoorData sceneTransportDoorData = beRegionTransportDoor.regionInfo as ISceneTransportDoorData;
				if (sceneTransportDoorData != null && sceneTransportDoorData.GetDoortype() == type)
				{
					beRegionTransportDoor.activeEffect = isenable;
					beRegionTransportDoor.active = isenable;
					break;
				}
			}
		}
	}

	// Token: 0x06017216 RID: 94742 RVA: 0x00718414 File Offset: 0x00716814
	public void CreateLogic()
	{
		for (int i = 0; i < this.sceneData.GetDestructibleInfoLength(); i++)
		{
			ISceneEntityInfoData entityInfo = this.sceneData.GetRegionInfo(i).GetEntityInfo();
			this.CreateDestruct(entityInfo.GetResid(), new VInt3(entityInfo.GetPosition()), entityInfo.GetColor(), new VInt(entityInfo.GetScale()));
		}
	}

	// Token: 0x06017217 RID: 94743 RVA: 0x00718478 File Offset: 0x00716878
	private void _birthMonster(BeActor actor, UnitTable.eType type)
	{
		if (actor.attribute.type != 8)
		{
			this._setTransportDoor(false);
		}
		if (actor.m_iCamp == 1)
		{
			if (type != UnitTable.eType.MONSTER && type != UnitTable.eType.ELITE)
			{
				if (type == UnitTable.eType.BOSS)
				{
					actor.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
					{
						this.CheckBossDead(actor);
					});
					actor.RegisterEvent(BeEventType.OnBuffDamage, delegate(object[] args)
					{
						this.CheckBossDead(actor);
					});
					actor.RegisterEvent(BeEventType.onSpecialDead, delegate(object[] args)
					{
						this.CheckBossDead(actor);
					});
				}
			}
		}
	}

	// Token: 0x06017218 RID: 94744 RVA: 0x0071853C File Offset: 0x0071693C
	private void CheckBossDead(BeActor actor)
	{
		if (actor.GetLifeState() == 2)
		{
			BeEntityData entityData = actor.GetEntityData();
			if (this.mIsBossScene && entityData != null && entityData.type == 3 && entityData.battleData != null && !this.isBossDeaded && entityData.GetHP() <= 0 && base.state < BeSceneState.onBulletTime && this._isAllBossDead())
			{
				this.isBossDeaded = true;
				if (this.mBattle.GetBattleType() != BattleType.DeadTown)
				{
					base.state = BeSceneState.onBulletTime;
				}
				this._deadBoss(actor);
			}
		}
	}

	// Token: 0x06017219 RID: 94745 RVA: 0x007185D8 File Offset: 0x007169D8
	public bool _isAllBossDead()
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && beActor.IsBoss() && !beActor.IsDead())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601721A RID: 94746 RVA: 0x00718634 File Offset: 0x00716A34
	public bool isAllEnemyDead()
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null)
			{
				BeEntityData entityData = beActor.GetEntityData();
				if (entityData != null && beActor.m_iCamp == 1 && entityData.type != 8 && entityData.type != 9 && (entityData.type == 3 || entityData.type == 2 || entityData.type == 1) && entityData.battleData != null)
				{
					if (!beActor.IsDead())
					{
						return false;
					}
					if (beActor.GetLifeState() < 4)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601721B RID: 94747 RVA: 0x007186F4 File Offset: 0x00716AF4
	private void _deadMonster(BeActor actor)
	{
		if (this._isEnemyMonster(actor))
		{
			this.TriggerEvent(BeEventSceneType.onMonsterDead, new object[]
			{
				actor
			});
		}
		else
		{
			if (actor == null)
			{
				return;
			}
			BeEntityData entityData = actor.GetEntityData();
			if (entityData != null && entityData.type == 9)
			{
				this.TriggerEvent(BeEventSceneType.onEggDead, null);
			}
		}
	}

	// Token: 0x0601721C RID: 94748 RVA: 0x0071874C File Offset: 0x00716B4C
	private bool _isEnemyMonster(BeActor actor)
	{
		if (actor == null)
		{
			return false;
		}
		BeEntityData entityData = actor.GetEntityData();
		return entityData != null && (actor.m_iCamp == 1 && entityData.type != 8 && entityData.type != 9);
	}

	// Token: 0x0601721D RID: 94749 RVA: 0x00718798 File Offset: 0x00716B98
	private void _removeMonster(BeActor actor)
	{
		if (this._isEnemyMonster(actor))
		{
			this.TriggerEvent(BeEventSceneType.onMonsterRemoved, null);
		}
	}

	// Token: 0x0601721E RID: 94750 RVA: 0x007187AE File Offset: 0x00716BAE
	private void _removeDestruct()
	{
		this.TriggerEvent(BeEventSceneType.onMonsterRemoved, null);
	}

	// Token: 0x0601721F RID: 94751 RVA: 0x007187B8 File Offset: 0x00716BB8
	private void UpdateCheckMosnterClear(int delta)
	{
		if (base.state == BeSceneState.onFinish || base.state == BeSceneState.onNone || base.state == BeSceneState.onReady || base.state == BeSceneState.onPause)
		{
			return;
		}
		this.checkAcc += delta;
		if (this.mCheckMonsterDirtyFlag || this.checkAcc >= this.checkMosnterClearInterval)
		{
			this.mCheckMonsterDirtyFlag = false;
			this.checkAcc = 0;
			this.CheckMonsterClear();
		}
	}

	// Token: 0x06017220 RID: 94752 RVA: 0x00718834 File Offset: 0x00716C34
	private void CheckMonsterClear()
	{
		if (this.isAllEnemyDead())
		{
			if (base.state != BeSceneState.onPause && base.state != BeSceneState.onClear)
			{
				this._onClearEvent();
			}
		}
		else if (base.state != BeSceneState.onFight && base.state != BeSceneState.onPause && base.state != BeSceneState.onBulletTime)
		{
			base.state = BeSceneState.onFight;
			this._setTransportDoor(false);
		}
	}

	// Token: 0x06017221 RID: 94753 RVA: 0x007188A1 File Offset: 0x00716CA1
	public Vec3 GeGDeadBossPosition()
	{
		return this.mgeDeadBossPositionGE;
	}

	// Token: 0x06017222 RID: 94754 RVA: 0x007188AC File Offset: 0x00716CAC
	private void _deadBoss(BeActor actor)
	{
		this.TriggerEvent(BeEventSceneType.onBossDead, null);
		bool flag = this.mIsBossScene && actor.GetEntityData().type == 3;
		if (flag)
		{
			this.bossDead = true;
			this.mgeDeadBossPositionGE = actor.GetGePosition(PositionType.ORIGIN);
			this.ClearMonsters(actor);
			if (actor != null && actor.CurrentBeBattle != null && !actor.CurrentBeBattle.HasFlag(BattleFlagType.PendingArray_Dont_Remove))
			{
				this.ClearPendingMonster(actor);
			}
		}
	}

	// Token: 0x06017223 RID: 94755 RVA: 0x00718930 File Offset: 0x00716D30
	private void _MakeMonsterDead(List<BeEntity> entityList, BeActor actor)
	{
		for (int i = 0; i < entityList.Count; i++)
		{
			BeActor beActor = entityList[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && (actor == null || (actor != null && actor != beActor)) && beActor.m_iCamp == 1 && beActor.GetEntityData().type != 8 && beActor.GetEntityData().type != 9)
			{
				beActor.GetEntityData().SetHP(-1);
				beActor.JudgeDead();
				beActor.DoDead(false);
			}
		}
	}

	// Token: 0x06017224 RID: 94756 RVA: 0x007189CD File Offset: 0x00716DCD
	private void ClearPendingMonster(BeActor actor)
	{
		this._MakeMonsterDead(this.mPendingArray, actor);
	}

	// Token: 0x06017225 RID: 94757 RVA: 0x007189DC File Offset: 0x00716DDC
	private void ClearMonsters(BeActor actor)
	{
		this._MakeMonsterDead(this.mEntitys, actor);
	}

	// Token: 0x06017226 RID: 94758 RVA: 0x007189EC File Offset: 0x00716DEC
	public BeActor FindAPendingMonster()
	{
		for (int i = 0; i < this.mPendingArray.Count; i++)
		{
			BeActor beActor = this.mPendingArray[i] as BeActor;
			if (beActor != null && beActor.m_iCamp == 1 && beActor.GetEntityData().type != 8 && beActor.GetEntityData().type != 9)
			{
				return beActor;
			}
		}
		return null;
	}

	// Token: 0x06017227 RID: 94759 RVA: 0x00718A60 File Offset: 0x00716E60
	private void _createMonsterUI(BeActor actor, UnitTable monsterData, BeActor owner = null, bool isSummon = false)
	{
		if (monsterData.Type == UnitTable.eType.SKILL_MONSTER && !monsterData.ShowName)
		{
			return;
		}
		bool enemy = true;
		if (BattleMain.IsModePvP(this.mBattle.GetBattleType()))
		{
			BeActor playerActor = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
			if (owner != null && playerActor == owner)
			{
				enemy = false;
			}
		}
		else if (actor.m_iCamp <= 0)
		{
			enemy = false;
		}
		if (actor.m_pkGeActor == null)
		{
			Logger.LogErrorFormat("_createMonsterUI is null monsterId {0} name {1} pid {2}", new object[]
			{
				monsterData.ID,
				monsterData.Name,
				actor.GetPID()
			});
			return;
		}
		actor.m_pkGeActor.CreateHPBarMonster(monsterData.Type, actor.GetEntityData().name, Color.white, this.singleBloodBarCount, enemy);
		if (monsterData.MonsterTitle > 0)
		{
			actor.m_pkGeActor.CreateInfoBar(monsterData.Name, PlayerInfoColor.BOSS, 0, null, 0f);
			actor.m_pkGeActor.AddTittleComponent(monsterData.MonsterTitle, monsterData.Name, 0, string.Empty, 0, 0, PlayerInfoColor.BOSS, string.Empty, null, 0, 0);
		}
		switch (monsterData.Type)
		{
		case UnitTable.eType.MONSTER:
			if (monsterData.ShowName)
			{
				actor.m_pkGeActor.CreateMonsterInfoBar(monsterData.Name, PlayerInfoColor.ELITE_MONSTER);
				actor.m_pkGeActor.SetHeadInfoVisible(false);
			}
			if (Utility.IsStringValid(monsterData.FootEffectName))
			{
				actor.m_pkGeActor.CreateFootIndicator(monsterData.FootEffectName);
			}
			break;
		case UnitTable.eType.ELITE:
			actor.m_pkGeActor.CreateMonsterInfoBar(monsterData.Name, PlayerInfoColor.ELITE_MONSTER);
			if (Utility.IsStringValid(monsterData.FootEffectName))
			{
				actor.m_pkGeActor.CreateFootIndicator(monsterData.FootEffectName);
			}
			break;
		case UnitTable.eType.BOSS:
			actor.m_pkGeActor.CreateMonsterInfoBar(monsterData.Name, PlayerInfoColor.BOSS);
			if ((!isSummon && monsterData.ShowFootBar != 4) || monsterData.ShowFootBar == 5)
			{
				actor.m_pkGeActor.CreateMonsterLoop();
			}
			break;
		case UnitTable.eType.SKILL_MONSTER:
			if (monsterData.ShowName)
			{
				actor.m_pkGeActor.CreateMonsterInfoBar(monsterData.Name, PlayerInfoColor.TOWN_NPC);
				actor.m_pkGeActor.SetHeadInfoVisible(false);
			}
			if (!monsterData.ShowHPBar)
			{
				actor.m_pkGeActor.SetHPBarVisible(false);
			}
			break;
		}
	}

	// Token: 0x06017228 RID: 94760 RVA: 0x00718CCC File Offset: 0x007170CC
	public BeActor CreateMonster(int monsterID, bool isSummon = false, List<int> prefix = null, int externalSkillLevel = 0, int camp = -1, BeActor owner = null, bool useCube = false)
	{
		MonsterIDData monsterIDData = new MonsterIDData(monsterID);
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterIDData.mid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterID, string.Empty, string.Empty);
		}
		if (tableItem != null)
		{
			int mode = tableItem.Mode;
			if (camp == -1)
			{
				camp = (int)tableItem.Camp;
			}
			BeActor actor = this.AddActor(mode, camp, -1, useCube);
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num = monsterIDData.level;
			if (externalSkillLevel > 0)
			{
				num = externalSkillLevel;
			}
			if (tableItem.AttackSkillID != 0)
			{
				dictionary.Add(tableItem.AttackSkillID, num);
			}
			for (int i = 0; i < tableItem.SkillIDs.Count; i++)
			{
				int num2 = tableItem.SkillIDs[i];
				if (num2 != 0 && !dictionary.ContainsKey(num2))
				{
					SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num2, string.Empty, string.Empty);
					if (tableItem2 != null && (monsterIDData.level >= tableItem2.LevelLimit || monsterIDData.type == 7 || tableItem.APCIsSpecialConfig >= 1))
					{
						dictionary.Add(num2, num);
						if (tableItem.APCIsSpecialConfig > 0 && tableItem2.TopLevel > 0)
						{
							num = Math.Min(num, tableItem2.TopLevel);
						}
					}
				}
			}
			actor.SetDefaultHitSFX(tableItem.DefaultAttackHitSFXID);
			actor.SetDefaultWeapenTag(tableItem.AIWeaponTag);
			if (tableItem.APCWeaponRes > 0)
			{
				actor.ReplaceWeapon(tableItem.APCWeaponRes, tableItem.AIWeaponTag, tableItem.APCWeaponStrengthLevel);
			}
			actor.InitData(monsterIDData.level, 0, dictionary, (tableItem.APCIsSpecialConfig <= 0) ? string.Empty : "apc", 0, null, null, 0, null, null, null, null, false, false, false, SkillSystemSourceType.None);
			actor.beHitEffect = tableItem.Hurt;
			actor.runSpeed = new VInt3(Global.Settings.monsterRunSpeed);
			actor.walkSpeed = new VInt3(Global.Settings.monsterWalkSpeed);
			BeEntityData entityData = actor.GetEntityData();
			if (entityData != null)
			{
				entityData.weight = VInt.Float2VIntValue(Global.Settings.gravity) * VFactor.NewVFactor((long)tableItem.Weight, (long)GlobalLogic.VALUE_100);
				entityData.exp = tableItem.Exp;
				entityData.type = (int)tableItem.Type;
				entityData.skillMonsterCanBeAttack = (tableItem.SkillMonsterCanBeAttack > 0);
				entityData.autoFightNeedAttackFirst = (tableItem.AutoFightNeedAttackFirst > 0);
				entityData.getupIDRand = tableItem.GetupSkillRand;
				entityData.getupID = tableItem.GetupSkillID;
				entityData.hitIDRand = tableItem.HitSkillRand;
				entityData.hitID = tableItem.HitSkillID;
				entityData.camp = camp;
				entityData.normalAttackID = tableItem.AttackSkillID;
				actor.walkSpeed *= new VFactor((long)tableItem.WalkSpeed, (long)GlobalLogic.VALUE_100);
				actor.runSpeed *= new VFactor((long)tableItem.WalkSpeed, (long)GlobalLogic.VALUE_100);
				entityData.isMonster = true;
				entityData.monsterID = tableItem.ID;
				entityData.monsterData = tableItem;
				entityData.overHeadHeight = (float)tableItem.overHeadHeight / (float)GlobalLogic.VALUE_1000;
				entityData.buffOriginHeight = (float)tableItem.buffOriginHeight / (float)GlobalLogic.VALUE_1000;
				entityData.simpleMonsterID = BeUtility.GetOnlyMonsterID(tableItem.ID);
				entityData.enhancedRadius = tableItem.enhanceRadius * (int)(10000L / (long)GlobalLogic.VALUE_1000);
				entityData.monsterIDData = monsterIDData;
				entityData.name = tableItem.Name;
				entityData.isSpecialAPC = (tableItem.APCIsSpecialConfig > 0);
				entityData.isShowSkillSpeech = true;
				entityData.walkAnimationSpeedPercent = tableItem.WalkAnimationSpeedPerent;
				entityData.height = tableItem.Height;
			}
			if (tableItem.FloatValue > 0)
			{
				actor.floatingHeight = VInt.NewVInt(tableItem.FloatValue, 1000);
			}
			this.InitMonsterAttribute(actor.GetEntityData(), tableItem, tableItem.MonsterMode, monsterIDData.difficulty, monsterIDData.type, monsterIDData.level);
			actor.SetMoveSpeedZAcc(actor.GetEntityData().weight);
			if (owner != null)
			{
				actor.attribute.SetResistMagic(owner.attribute.GetResistMagic());
			}
			this.FixUnitAttribute(actor.GetEntityData(), tableItem, camp);
			this.ChangeMonsterAbility(actor, tableItem, true);
			this.SetMonsterAiInfo(actor, tableItem);
			this.SetMonsterProtect(actor, tableItem);
			this.AddBornBuff(actor, tableItem);
			if (prefix != null && prefix.Count > 0)
			{
				this.DealPrefix(actor, prefix, tableItem);
			}
			this._createMonsterUI(actor, tableItem, owner, isSummon);
			if (actor.m_pkGeActor != null)
			{
				if (tableItem.Type == UnitTable.eType.BOSS)
				{
					actor.m_pkGeActor.SetMaterial("HeroGo/Surface/General_Rim_Flash");
				}
				if (!actor.IsSkillMonster() && tableItem.ShowFootBar != 3)
				{
					actor.m_pkGeActor.AddSimpleShadow(Vector3.one);
				}
			}
			actor.walkSpeeches = tableItem.WalkSpeech;
			actor.attackSpeeches = tableItem.AttackSpeech;
			actor.birthSpeeches = tableItem.BirthSpeech;
			if (entityData.type == 1 || (actor.walkSpeeches.Count > 0 && actor.walkSpeeches[0] > 0) || (actor.attackSpeeches.Count > 0 && actor.attackSpeeches[0] > 0) || (actor.birthSpeeches.Count > 0 && actor.birthSpeeches[0] > 0))
			{
				actor.RegisterEvent(BeEventType.onStateChange, delegate(object[] args2)
				{
					ActionState actionState = (ActionState)args2[0];
					if (actionState != ActionState.AS_BIRTH && !actor.IsCastingSkill() && actor.GetStateGraph().CurrentStateHasTag(7))
					{
						actor.m_pkGeActor.ShowHeadDialog(string.Empty, true, false, false, false, 3.5f, false);
					}
					else
					{
						actor.ShowSpeech(actionState);
					}
				});
			}
			if (tableItem.GetupBati > 0)
			{
				int batiDuration = tableItem.GetupBati;
				actor.RegisterEvent(BeEventType.onStateChange, delegate(object[] args3)
				{
					ActionState actionState = (ActionState)args3[0];
					if (actionState == ActionState.AS_GETUP && (uint)this.FrameRandom.Range1000() <= (uint)(Global.Settings.monsterGetupBatiFactor * (float)GlobalLogic.VALUE_1000))
					{
						actor.buffController.TryAddBuff(34, batiDuration, 1);
					}
				});
			}
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.Scale, actor.GetEntityData().level, true);
			if (valueFromUnionCell != GlobalLogic.VALUE_100)
			{
				VFactor f = new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_100);
				actor.SetScale(actor.GetScale().i * f);
			}
			int num3 = TableManager.GetValueFromUnionCell(tableItem.ExistDuration, actor.GetEntityData().level, true);
			if (BattleMain.IsModePvP(this.mBattle.GetBattleType()))
			{
				num3 = TableManager.GetValueFromUnionCell(tableItem.PVPExistDuration, actor.GetEntityData().level, true);
			}
			if (owner != null)
			{
				int[] array = new int[]
				{
					num3,
					GlobalLogic.VALUE_1000
				};
				owner.TriggerEvent(BeEventType.onChangeSummonLifeTime, new object[]
				{
					actor,
					array
				});
				num3 = array[0] * VFactor.NewVFactor(array[1], GlobalLogic.VALUE_1000);
			}
			if (num3 > 0)
			{
				actor.buffController.TryAddBuff(12, num3, 1);
			}
			if (tableItem.ShowName)
			{
				actor.m_pkGeActor.SetHeadInfoVisible(true);
			}
			this.TriggerEvent(BeEventSceneType.onCreateMonster, new object[]
			{
				actor
			});
			if (actor != null && actor.GetEntityData() != null && actor.GetEntityData().battleData != null)
			{
				actor.GetEntityData().battleData.initDefence = actor.GetEntityData().battleData.defence;
				actor.GetEntityData().battleData.initMagicDefence = actor.GetEntityData().battleData.magicDefence;
			}
			if (base.state >= BeSceneState.onBulletTime)
			{
				actor.DoDead(false);
			}
			return actor;
		}
		Logger.LogErrorFormat("UnitTable can't find item with ID : {0}", new object[]
		{
			monsterID
		});
		return null;
	}

	// Token: 0x06017229 RID: 94761 RVA: 0x007195B0 File Offset: 0x007179B0
	public Dictionary<int, int> GetMonsterSkillInfo(int monsterID, int externalSkillLevel = 0)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		MonsterIDData monsterIDData = new MonsterIDData(monsterID);
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterIDData.mid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterID, string.Empty, string.Empty);
		}
		if (tableItem == null)
		{
			return dictionary;
		}
		int mode = tableItem.Mode;
		int num = monsterIDData.level;
		if (externalSkillLevel > 0)
		{
			num = externalSkillLevel;
		}
		if (tableItem.AttackSkillID != 0)
		{
			dictionary.Add(tableItem.AttackSkillID, num);
		}
		for (int i = 0; i < tableItem.SkillIDs.Count; i++)
		{
			int num2 = tableItem.SkillIDs[i];
			if (num2 != 0 && !dictionary.ContainsKey(num2))
			{
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num2, string.Empty, string.Empty);
				if (tableItem2 != null && (monsterIDData.level >= tableItem2.LevelLimit || monsterIDData.type == 7 || tableItem.APCIsSpecialConfig >= 1))
				{
					dictionary.Add(num2, num);
					if (tableItem.APCIsSpecialConfig > 0 && tableItem2.TopLevel > 0)
					{
						num = Math.Min(num, tableItem2.TopLevel);
					}
				}
			}
		}
		return dictionary;
	}

	// Token: 0x0601722A RID: 94762 RVA: 0x007196FC File Offset: 0x00717AFC
	public void DealPrefix(BeActor monster, List<int> prefix, UnitTable monsterData)
	{
		List<string> list = new List<string>();
		string text = null;
		for (int i = 0; i < prefix.Count; i++)
		{
			if (prefix[i] > 0)
			{
				MonsterPrefixTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MonsterPrefixTable>(prefix[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int j = 0; j < tableItem.BufferInfoID.Count; j++)
					{
						int num = tableItem.BufferInfoID[j];
						if (num > 0)
						{
							BuffInfoData buffInfoData = new BuffInfoData(num, monster.GetEntityData().level, 0);
							if (buffInfoData.condition <= BuffCondition.NONE)
							{
								monster.buffController.TryAddBuff(buffInfoData, null, false, default(VRate), null);
							}
							else
							{
								monster.buffController.AddTriggerBuff(buffInfoData);
							}
						}
					}
					if (tableItem.type == 1)
					{
						text = tableItem.Name;
					}
					else
					{
						list.Add(tableItem.Name);
					}
				}
			}
		}
		string text2 = string.Empty;
		for (int k = 0; k < list.Count; k++)
		{
			text2 += string.Format("<color=white>{0}\n</color>", list[k]);
		}
		if (text == null)
		{
			text = string.Empty;
		}
		if (text != null)
		{
			text2 += string.Format("<color=#8918FFFF>{0}{1}</color>", text, monsterData.Name);
			if (monster.GetEntityData() != null)
			{
				monster.GetEntityData().name = string.Format("{0}{1}", text, monsterData.Name);
			}
		}
		monster.m_pkGeActor.CreateMonsterInfoBar(text2, PlayerInfoColor.PREFIX_MONSTER);
		if (Utility.IsStringValid(monsterData.PrefixEffect))
		{
			monster.m_pkGeActor.CreateEffect(monsterData.PrefixEffect, "[actor]Orign", 999999f, new Vec3(0f, 0f, 0f), 1f, 1f, true, false, EffectTimeType.SYNC_ANIMATION, false);
		}
	}

	// Token: 0x0601722B RID: 94763 RVA: 0x00719900 File Offset: 0x00717D00
	public BeActor SummonAccompany(int accompanyID, VInt3 pos, int camp, BeActor owner)
	{
		return this.SummonMonster(accompanyID, pos, camp, owner, false, 0, false, 0, true, false);
	}

	// Token: 0x0601722C RID: 94764 RVA: 0x00719920 File Offset: 0x00717D20
	public BeActor SummonMonster(int monsterID, VInt3 pos, int camp, BeActor owner = null, bool related = false, int summonMonsterSkillLevel = 0, bool isShowBlood = true, int originSummonId = 0, bool forceDisplayModel = false, bool isSameFace = false)
	{
		if (monsterID <= 0)
		{
			return null;
		}
		bool useCube = false;
		if (!BattleMain.IsModePvP(this.mBattle.GetBattleType()) && camp == 0 && owner != null && !forceDisplayModel)
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(63, string.Empty, string.Empty);
			if (!tableItem.ValueD.Contains(originSummonId) && !owner.isLocalActor && Singleton<SettingManager>.instance.GetCommmonSet("SETTING_SUMMONDISSET") == SettingManager.SetCommonType.Close)
			{
				useCube = true;
			}
		}
		BeActor monster = this.CreateMonster(monsterID, true, null, summonMonsterSkillLevel, camp, owner, useCube);
		if (monster == null || (monster != null && monster.GetEntityData() == null))
		{
			return null;
		}
		monster.m_iCamp = camp;
		monster.GetEntityData().isSummonMonster = true;
		UnitTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monster.GetEntityData().monsterID, string.Empty, string.Empty);
		if (tableItem2 != null && tableItem2.BornAI == UnitTable.eBornAI.Start)
		{
			monster.StartAI(null, monster.GetEntityData().type != 7);
		}
		monster.SetPosition(pos, true, true, false);
		if (owner != null)
		{
			if (isSameFace)
			{
				monster.SetFace(owner.GetFace(), false, false);
			}
			else
			{
				monster.SetFace(!owner.GetFace(), false, false);
			}
		}
		if (!isShowBlood)
		{
			monster.m_pkGeActor.RemoveHPBarMonster();
		}
		if (tableItem2 != null)
		{
			if (tableItem2.FloatValue > 0)
			{
				monster.SetFloating((int)((long)tableItem2.FloatValue * 10000L / (long)GlobalLogic.VALUE_1000), false);
			}
			if ((monster.GetEntityData().type != 8 && monster.GetEntityData().type != 9) || tableItem2.ShowFootBar == 1)
			{
				if (BattleMain.IsModePvP(this.mBattle.GetBattleType()))
				{
					if ((owner != null && owner == BattleMain.instance.GetLocalPlayer(0UL).playerActor) || (BattleMain.battleType == BattleType.ScufflePVP && owner.m_iCamp == BattleMain.instance.GetLocalPlayer(0UL).playerActor.m_iCamp))
					{
						monster.m_pkGeActor.CreateFootIndicator("Effects/Hero_Zhaohuanshi/Bingnaisi/Prefab/Eff_Zhaohuanbingnaisi_zhaohuan_02");
					}
					else if (owner != null && owner == BattleMain.instance.GetLocalTargetPlayer().playerActor)
					{
						monster.m_pkGeActor.CreateFootIndicator("Effects/Hero_Zhaohuanshi/Bingnaisi/Prefab/Eff_Zhaohuanbingnaisi_zhaohuan_03");
					}
				}
				else if (tableItem2.ShowFootBar != 2 && tableItem2.ShowFootBar != 3 && tableItem2.ShowFootBar != 5)
				{
					monster.m_pkGeActor.CreateFootIndicator("Effects/Hero_Zhaohuanshi/Bingnaisi/Prefab/Eff_Zhaohuanbingnaisi_zhaohuan_02");
				}
			}
		}
		if (owner != null)
		{
			if (related)
			{
				this.AdjustSummonMonsterAttribute(owner, monster);
				BeEventHandle handle = owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					if (!monster.IsDead())
					{
						monster.DoDead(false);
					}
				});
				monster.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					handle.Remove();
				});
			}
			monster.SetOwner(owner);
			if (monster.aiManager.followDistance > 0f)
			{
				monster.aiManager.followTarget = owner;
			}
			if ((!BattleMain.IsModePvP(this.mBattle.GetBattleType()) && owner.isLocalActor) || (BattleMain.IsModePvP(this.mBattle.GetBattleType()) && owner.isMainActor))
			{
				monster.UseActorData();
			}
			if (monster.GetEntityData().type != 8 && monster.GetEntityData().type != 9 && owner == BattleMain.instance.GetLocalPlayer(0UL).playerActor)
			{
				string name = string.Format("Lv.{0} {1}", monster.GetEntityData().level, tableItem2.Name);
				monster.m_pkGeActor.CreateMonsterInfoBar(name, PlayerInfoColor.SUMMON_MONSTER);
			}
		}
		if (monster.m_iCamp != 0)
		{
			this._birthMonster(monster, (UnitTable.eType)monster.GetEntityData().type);
		}
		if (owner != null)
		{
			this.TriggerEvent(BeEventSceneType.onSummon, new object[]
			{
				monster,
				owner,
				owner.m_iCurSkillID
			});
		}
		if (owner == null || BattleMain.IsModePvP(this.mBattle.GetBattleType()))
		{
		}
		if (monster.GetEntityData().type != 8 && monster.GetEntityData().type != 9)
		{
			monster.buffController.TryAddBuff(2, GlobalLogic.VALUE_1000, 1);
		}
		if (this.mBattle != null && this.mBattle.recordServer != null && this.mBattle.recordServer.IsProcessRecord())
		{
			this.mBattle.recordServer.MarkInt(142055424U, new int[]
			{
				(owner == null) ? 0 : owner.m_iID,
				monsterID
			});
		}
		return monster;
	}

	// Token: 0x0601722D RID: 94765 RVA: 0x00719EB9 File Offset: 0x007182B9
	public BeActor DuplicateMonster(BeActor monster)
	{
		return this.DuplicateMonster(monster, VFactor.one, 0);
	}

	// Token: 0x0601722E RID: 94766 RVA: 0x00719EC8 File Offset: 0x007182C8
	public BeActor DuplicateMonster(BeActor monster, VFactor percent, int maxNum = 0)
	{
		if (monster == null)
		{
			return null;
		}
		if (monster.GetEntityData() == null)
		{
			return null;
		}
		if (!monster.stateController.CanDuplicate())
		{
			return null;
		}
		BeEntityData entityData = monster.GetEntityData();
		int monsterID = entityData.monsterID + entityData.level * GlobalLogic.VALUE_100;
		if (maxNum > 0)
		{
			int summonCountByID = monster.CurrentBeScene.GetSummonCountByID(entityData.monsterID, monster);
			if (summonCountByID >= maxNum)
			{
				return null;
			}
		}
		BeActor beActor = this.CreateMonster(monsterID, false, null, 0, monster.m_iCamp, null, false);
		BeEntityData entityData2 = beActor.GetEntityData();
		entityData2.isSummonMonster = true;
		beActor.SetOwner(monster);
		beActor.SetPosition(monster.GetPosition(), false, true, false);
		beActor.StartAI(null, true);
		beActor.stateController.SetAbilityEnable(BeAbilityType.DUPLICATE, false);
		int num = entityData.GetMaxHP() * percent;
		entityData2.SetHP(num);
		entityData2.SetMaxHP(num);
		entityData2.battleData.attack = entityData.battleData.attack * percent;
		entityData2.battleData.magicAttack = entityData.battleData.magicAttack * percent;
		if (beActor.m_pkGeActor != null)
		{
			beActor.m_pkGeActor.ResetHPBar();
		}
		return beActor;
	}

	// Token: 0x0601722F RID: 94767 RVA: 0x0071A014 File Offset: 0x00718414
	public void AdjustSummonMonsterAttribute(BeActor owner, BeActor monster)
	{
		if (owner == null || monster == null)
		{
			return;
		}
		if (monster.attribute.monsterData.MonsterMode == 5)
		{
			UnitTable unitTable = this.GetSummonMonsterAttr(monster.attribute.monsterData.ID);
			if (unitTable == null)
			{
				unitTable = monster.attribute.monsterData;
			}
			monster.attribute.SetAttributeValue(AttributeType.attack, owner.attribute.GetAttributeValue(AttributeType.magicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.magicAttack, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.magicAttack, owner.attribute.GetAttributeValue(AttributeType.magicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.magicAttack, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.ignoreDefAttackAdd, owner.attribute.GetAttributeValue(AttributeType.ignoreDefMagicAttackAdd) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ignoreDefMagicAttackAdd, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.ignoreDefMagicAttackAdd, owner.attribute.GetAttributeValue(AttributeType.ignoreDefMagicAttackAdd) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ignoreDefMagicAttackAdd, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.baseAtk, owner.attribute.GetAttributeValue(AttributeType.baseInt) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseInt, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.baseInt, owner.attribute.GetAttributeValue(AttributeType.baseInt) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseInt, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.baseSta, owner.attribute.GetAttributeValue(AttributeType.baseSta) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseSta, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.baseSpr, owner.attribute.GetAttributeValue(AttributeType.baseSpr) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseSpr, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.ciriticalAttack, owner.attribute.GetAttributeValue(AttributeType.ciriticalAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ciriticalAttack, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.SetAttributeValue(AttributeType.ciriticalMagicAttack, owner.attribute.GetAttributeValue(AttributeType.ciriticalMagicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ciriticalMagicAttack, unitTable), GlobalLogic.VALUE_100000), false);
			monster.attribute.ChangeMaxHpByResist();
			monster.attribute.battleData.RefreshMpInfo();
			if (BattleMain.IsModePvP(this.mBattle.GetBattleType()))
			{
				PkHPProfessionAdjustTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkHPProfessionAdjustTable>(monster.attribute.simpleMonsterID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this.mBattle.PkRaceType == 6)
					{
						monster.attribute.AdjustHPForPvP((double)VRate.Factor(tableItem.factor_3v3).single);
					}
					else if (this.mBattle.PkRaceType == 8)
					{
						monster.attribute.AdjustHPForPvP((double)VRate.Factor(tableItem.factor_chiji).single);
					}
					else
					{
						monster.attribute.AdjustHPForPvP((double)VRate.Factor(tableItem.factor).single);
					}
				}
			}
			if (monster != null && monster.m_pkGeActor != null)
			{
				monster.m_pkGeActor.SyncHPBar();
			}
			for (int i = 1; i < 5; i++)
			{
				monster.attribute.battleData.magicElementsAttack[i] = owner.attribute.battleData.magicElementsAttack[i] * VRate.Factor(GlobalLogic.VALUE_1000);
			}
			if (monster.attribute.simpleMonsterID == 900 || monster.attribute.simpleMonsterID == 905 || monster.attribute.simpleMonsterID == 909)
			{
				for (int j = 1; j < 5; j++)
				{
					monster.attribute.battleData.magicELements[j] = owner.attribute.battleData.magicELements[j];
				}
			}
		}
		else
		{
			monster.attribute.SetAttributeValue(AttributeType.attack, owner.attribute.GetAttributeValue(AttributeType.magicAttack), false);
			monster.attribute.SetAttributeValue(AttributeType.magicAttack, owner.attribute.GetAttributeValue(AttributeType.magicAttack), false);
			monster.attribute.SetAttributeValue(AttributeType.baseAtk, owner.attribute.GetAttributeValue(AttributeType.baseInt), false);
			monster.attribute.SetAttributeValue(AttributeType.baseInt, owner.attribute.GetAttributeValue(AttributeType.baseInt), false);
		}
	}

	// Token: 0x06017230 RID: 94768 RVA: 0x0071A4D8 File Offset: 0x007188D8
	public BeActor CreateRemoteMonster(DungeonMonster remoteData, VInt3 pos, VFactor scale, bool faceLeft = false)
	{
		bool isDead = false;
		BeActor monster = this.CreateMonster(remoteData.typeId, false, remoteData.prefixes, 0, -1, null, false);
		if (monster == null)
		{
			return null;
		}
		monster.SetPosition(pos, true, true, false);
		monster.SetScale(monster.GetScale().i * scale);
		monster.SetFace(faceLeft, false, false);
		if (monster.floatingHeight > 0)
		{
			monster.SetFloating(monster.floatingHeight, true);
		}
		if (base.state == BeSceneState.onFinish)
		{
			monster.DoDead(false);
			monster.sgForceSwitchState(new BeStateData(11, 0));
			this._dropItem(remoteData, monster);
			DataManager<BattleDataManager>.GetInstance().BattleInfo.KillMonster(remoteData.id);
		}
		else
		{
			monster.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				if (!isDead)
				{
					isDead = true;
					remoteData.removed = true;
					this._dropItem(remoteData, monster);
					DataManager<BattleDataManager>.GetInstance().BattleInfo.KillMonster(remoteData.id);
				}
			});
			this._birthMonster(monster, (UnitTable.eType)monster.GetEntityData().type);
		}
		if (this.IsTaskMonster(remoteData.typeId))
		{
			monster.m_pkGeActor.SetTaskMonster(monster.attribute.name);
		}
		return monster;
	}

	// Token: 0x06017231 RID: 94769 RVA: 0x0071A680 File Offset: 0x00718A80
	public BeActor CreateMonster(int monsterId, VInt3 pos)
	{
		BeActor beActor = this.CreateMonster(monsterId, false, null, 0, -1, null, false);
		if (beActor == null)
		{
			return null;
		}
		beActor.SetPosition(pos, true, true, false);
		if (beActor.floatingHeight > 0)
		{
			beActor.SetFloating(beActor.floatingHeight, true);
		}
		if (base.state == BeSceneState.onFinish)
		{
			beActor.DoDead(false);
			beActor.sgForceSwitchState(new BeStateData(11, 0));
		}
		else
		{
			this._birthMonster(beActor, (UnitTable.eType)beActor.GetEntityData().type);
		}
		if (this.IsTaskMonster(monsterId))
		{
			beActor.m_pkGeActor.SetTaskMonster(beActor.attribute.name);
		}
		return beActor;
	}

	// Token: 0x06017232 RID: 94770 RVA: 0x0071A726 File Offset: 0x00718B26
	public BeActor CreateRemoteMonster(DungeonMonster remoteData, ISceneEntityInfoData localData, bool faceLeft = false)
	{
		return this.CreateRemoteMonster(remoteData, new VInt3(localData.GetPosition()), VFactor.NewVFactorF(localData.GetScale(), 1000), faceLeft);
	}

	// Token: 0x06017233 RID: 94771 RVA: 0x0071A74B File Offset: 0x00718B4B
	private void _dropItem(DungeonMonster remoteData, BeEntity actor)
	{
		if (remoteData.dropItems.Count > 0)
		{
			this.DropItems(remoteData.dropItems, actor.GetPosition(), true, true, null);
		}
	}

	// Token: 0x06017234 RID: 94772 RVA: 0x0071A774 File Offset: 0x00718B74
	public void DropItems(List<DungeonDropItem> dropList, VInt3 epos, bool needClear = true, bool needTargetList = true, List<BeRegionDropItem> retList = null)
	{
		int num = this.logicWidth;
		int num2 = this.logicHeight;
		epos.z = 0;
		float num3 = 2.4f;
		for (int i = 0; i < dropList.Count; i++)
		{
			DungeonDropItem dropItem = dropList[i];
			Vec3 vec = epos.vec3;
			vec.x += Random.Range(-num3, num3);
			vec.y += Random.Range(-num3, num3);
			vec.z = 0f;
			vec.x = Mathf.Clamp(vec.x, this.logicXSize.fx, this.logicXSize.fy);
			vec.y = Mathf.Clamp(vec.y, this.logicZSize.fx, this.logicZSize.fy);
			BeRegionDropItem beRegionDropItem = this.AddDropItem(DungeonUtility.CreateSceneRegionInfoData(4, BeAIManager.FindStandPosition(new VInt3(vec), this, i % 2 == 0, false, 12).vector3), dropItem, epos, needClear, needTargetList);
			if (beRegionDropItem != null && retList != null)
			{
				retList.Add(beRegionDropItem);
			}
		}
		if (needClear)
		{
			dropList.Clear();
		}
	}

	// Token: 0x06017235 RID: 94773 RVA: 0x0071A8AC File Offset: 0x00718CAC
	private void _dropMonster(DungeonMonster monster, ISceneEntityInfoData info)
	{
		if (monster.summonerMonsters != null)
		{
			for (int i = 0; i < monster.summonerMonsters.Count; i++)
			{
				DungeonMonster remoteData = monster.summonerMonsters[i];
				BeActor beActor = this.CreateRemoteMonster(remoteData, info, false);
				if (beActor.GetEntityData().type != 9 && beActor.GetEntityData().type != 8)
				{
					beActor.buffController.TryAddBuff(2, GlobalLogic.VALUE_1000, 1);
				}
			}
			monster.summonerMonsters = null;
			if (base.state != BeSceneState.onFinish)
			{
				base.state = BeSceneState.onReady;
			}
		}
	}

	// Token: 0x06017236 RID: 94774 RVA: 0x0071A948 File Offset: 0x00718D48
	public BeObject CreateDestruct(int resid, VInt3 pos, Color color, VInt scale)
	{
		DestrucTable tableItem = Singleton<TableManager>.instance.GetTableItem<DestrucTable>(resid, string.Empty, string.Empty);
		if (tableItem != null)
		{
			BeObject beObject = this.AddLogicObject(tableItem.Mode, 2);
			if (beObject != null)
			{
				beObject.SetPosition(pos, false, true, false);
				beObject.SetScale(scale);
				beObject.SetBlockLayer(true);
				beObject.SetSplitCount(tableItem.IdleSplitCount);
				beObject.SetMaxStage(tableItem.IdleCount + 1);
				beObject.SetDeadEffect(tableItem.DeadEffect);
				beObject.SetDamageCount(tableItem.DestructHitCount);
				beObject.beHitEffect = tableItem.Hurt;
				beObject.m_pkGeActor.SetDyeColor(color, beObject.m_pkGeActor.renderObject);
				if (!tableItem.IsDestruct)
				{
					beObject.SetCanBeBreak(false);
				}
				return beObject;
			}
			Logger.LogErrorFormat("don't contain the id with {0}, Model {1}", new object[]
			{
				resid,
				tableItem.Mode
			});
		}
		return null;
	}

	// Token: 0x06017237 RID: 94775 RVA: 0x0071AA2F File Offset: 0x00718E2F
	public BeObject CreateDestruct(ISceneEntityInfoData info)
	{
		return this.CreateDestruct(info.GetResid(), new VInt3(info.GetPosition()), info.GetColor(), VInt.Float2VIntValue(info.GetScale()));
	}

	// Token: 0x06017238 RID: 94776 RVA: 0x0071AA60 File Offset: 0x00718E60
	private BeObject _createRemoteDestruct(DungeonMonster monster, ISceneEntityInfoData info)
	{
		if (monster != null && monster.id > 0)
		{
			BeObject destruct = this.CreateDestruct(info);
			if (destruct != null && monster != null)
			{
				destruct.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					monster.id = -1;
					this._dropItem(monster, destruct);
					if (monster.summonerMonsters != null && monster.summonerMonsters.Count > 0)
					{
						this._setTransportDoor(false);
					}
				});
				if (monster.summonerMonsters != null && monster.summonerMonsters.Count > 0)
				{
					destruct.RegisterEvent(BeEventType.onRemove, delegate(object[] args)
					{
						this._dropMonster(monster, info);
					});
				}
				return destruct;
			}
		}
		return null;
	}

	// Token: 0x06017239 RID: 94777 RVA: 0x0071AB3C File Offset: 0x00718F3C
	public int CreateMonsterList(List<DungeonMonster> monsters, bool isBoss, VInt3 birthPos, bool needClear = true)
	{
		this.mIsBossScene = isBoss;
		int num = 0;
		for (int i = 0; i < monsters.Count; i++)
		{
			DungeonMonster dungeonMonster = monsters[i];
			ISceneEntityInfoData sceneEntityInfoData = null;
			for (int j = 0; j < this.sceneData.GetMonsterInfoLength(); j++)
			{
				ISceneMonsterInfoData monsterInfo = this.sceneData.GetMonsterInfo(j);
				monsterInfo.SetMonsterID(monsterInfo.GetEntityInfo().GetResid());
				if (j == dungeonMonster.pointId % GlobalLogic.VALUE_100)
				{
					sceneEntityInfoData = monsterInfo.GetEntityInfo();
					break;
				}
			}
			if (sceneEntityInfoData != null && !dungeonMonster.removed)
			{
				dungeonMonster.monsterType = sceneEntityInfoData.GetType();
				BeActor beActor = this.CreateRemoteMonster(dungeonMonster, sceneEntityInfoData, VInt.Float2VIntValue(sceneEntityInfoData.GetPosition().x) > birthPos.x);
				if (beActor.GetRecordServer().IsProcessRecord())
				{
					beActor.GetRecordServer().MarkString(142055425U, new string[]
					{
						beActor.GetName(),
						beActor.m_iID.ToString(),
						sceneEntityInfoData.GetPosition().ToString(),
						beActor.GetPosition()
					});
				}
				if (beActor != null && !beActor.IsSkillMonster())
				{
					num++;
				}
			}
		}
		for (int k = 0; k < monsters.Count; k++)
		{
			if (monsters[k].summonerId <= 0)
			{
			}
		}
		if (needClear && num <= 0)
		{
			this._onClearEvent();
			base._updateState(0);
		}
		return num;
	}

	// Token: 0x0601723A RID: 94778 RVA: 0x0071ACF1 File Offset: 0x007190F1
	public void ClearEventAndState()
	{
		this._onClearEvent();
		base._updateState(0);
	}

	// Token: 0x0601723B RID: 94779 RVA: 0x0071AD00 File Offset: 0x00719100
	public int CreateMonsterList(List<DungeonMonster> monsters, bool isBoss, VInt3 birthPos, ref BeActor boss)
	{
		this.mIsBossScene = isBoss;
		boss = null;
		int num = 0;
		for (int i = 0; i < monsters.Count; i++)
		{
			DungeonMonster dungeonMonster = monsters[i];
			ISceneEntityInfoData sceneEntityInfoData = null;
			for (int j = 0; j < this.sceneData.GetMonsterInfoLength(); j++)
			{
				ISceneMonsterInfoData monsterInfo = this.sceneData.GetMonsterInfo(j);
				monsterInfo.SetMonsterID(monsterInfo.GetEntityInfo().GetResid());
				if (j == dungeonMonster.pointId % GlobalLogic.VALUE_100)
				{
					sceneEntityInfoData = monsterInfo.GetEntityInfo();
					break;
				}
			}
			if (sceneEntityInfoData != null && !dungeonMonster.removed)
			{
				dungeonMonster.monsterType = sceneEntityInfoData.GetType();
				BeActor beActor = this.CreateRemoteMonster(dungeonMonster, sceneEntityInfoData, VInt.Float2VIntValue(sceneEntityInfoData.GetPosition().x) > birthPos.x);
				if (beActor != null && beActor.IsBoss())
				{
					boss = beActor;
				}
				if (beActor != null && beActor.GetRecordServer().IsProcessRecord())
				{
					beActor.GetRecordServer().MarkString(142055426U, new string[]
					{
						beActor.GetName(),
						beActor.m_iID.ToString(),
						sceneEntityInfoData.GetPosition().ToString(),
						beActor.GetPosition()
					});
				}
				if (beActor != null && !beActor.IsSkillMonster())
				{
					num++;
				}
			}
		}
		for (int k = 0; k < monsters.Count; k++)
		{
			if (monsters[k].summonerId <= 0)
			{
			}
		}
		if (num <= 0)
		{
			this._onClearEvent();
			base._updateState(0);
		}
		return num;
	}

	// Token: 0x0601723C RID: 94780 RVA: 0x0071AED4 File Offset: 0x007192D4
	public void CreateDestructList2(List<DungeonMonster> destructs)
	{
		BeScene.<CreateDestructList2>c__AnonStoreyC <CreateDestructList2>c__AnonStoreyC = new BeScene.<CreateDestructList2>c__AnonStoreyC();
		<CreateDestructList2>c__AnonStoreyC.$this = this;
		if (this.sceneData == null)
		{
			return;
		}
		<CreateDestructList2>c__AnonStoreyC.offset = this.sceneData.GetMonsterInfoLength();
		int i;
		for (i = 0; i < this.sceneData.GetDestructibleInfoLength(); i++)
		{
			DungeonMonster dungeonMonster = destructs.Find((DungeonMonster x) => x.pointId % GlobalLogic.VALUE_100 == <CreateDestructList2>c__AnonStoreyC.offset + i && x.typeId == <CreateDestructList2>c__AnonStoreyC.$this.sceneData.GetDestructibleInfo(i).GetEntityInfo().GetResid());
			if (dungeonMonster != null)
			{
				this._createRemoteDestruct(dungeonMonster, this.sceneData.GetDestructibleInfo(i).GetEntityInfo());
			}
		}
	}

	// Token: 0x0601723D RID: 94781 RVA: 0x0071AF84 File Offset: 0x00719384
	public void SetMonsterListTarget(BeActor target)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && beActor.hasAI && beActor.m_iCamp != 0)
			{
				beActor.UpdateAITarget(target);
			}
		}
	}

	// Token: 0x0601723E RID: 94782 RVA: 0x0071AFE4 File Offset: 0x007193E4
	public void CreateMonsterLocal(BeActor target)
	{
		if (target == null)
		{
			Logger.LogError("target is nil");
			return;
		}
		if (Global.Settings.isCreateMonsterLocal)
		{
			for (int i = 0; i < this.sceneData.GetMonsterInfoLength(); i++)
			{
				int resid = this.sceneData.GetMonsterInfo(i).GetEntityInfo().GetResid();
				Vector3 position = this.sceneData.GetMonsterInfo(i).GetEntityInfo().GetPosition();
				BeActor beActor = this.CreateMonster(resid, false, null, 0, -1, null, false);
				beActor.StartAI(target, true);
				beActor.SetPosition(new VInt3(position), false, true, false);
				beActor.SetScale((VInt)this.sceneData.GetMonsterInfo(i).GetEntityInfo().GetScale());
			}
		}
	}

	// Token: 0x0601723F RID: 94783 RVA: 0x0071B0A4 File Offset: 0x007194A4
	private void _createCharacterUI(BeActor actor, int playerSeat)
	{
		if (actor.hasHP)
		{
			switch (BattleMain.battleType)
			{
			case BattleType.Single:
			case BattleType.Dungeon:
			case BattleType.DeadTown:
			case BattleType.Mou:
			case BattleType.North:
			case BattleType.NewbieGuide:
			case BattleType.Hell:
			case BattleType.YuanGu:
			case BattleType.GoldRush:
			case BattleType.ChampionMatch:
			case BattleType.GuildPVE:
			case BattleType.TrainingPVE:
			case BattleType.FinalTestBattle:
			case BattleType.RaidPVE:
			case BattleType.TreasureMap:
			case BattleType.AnniversaryPVE_III:
				actor.m_pkGeActor.CreateHPBarCharactor(playerSeat);
				break;
			}
		}
	}

	// Token: 0x06017240 RID: 94784 RVA: 0x0071B144 File Offset: 0x00719544
	public BeActor CreateCharacter(bool isLocalActor, int professtionID, int level, int camp, Dictionary<int, int> skillInfo, List<ItemProperty> equips = null, List<Battle.DungeonBuff> buffList = null, int playerSeat = 0, string name = "", int strengthenLevel = 0, List<BuffInfoData> rankBuffList = null, PetData petData = null, List<ItemProperty> sideEquips = null, Dictionary<int, string> avatar = null, bool isShowWeapon = false, bool isAIRobot = false)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professtionID, string.Empty, string.Empty);
		BeActor actor = this.AddActor(tableItem.Mode, camp, -1, false);
		if (actor != null)
		{
			actor.SetDefaultWeapenTag(tableItem.DefaultWeaponTag);
			actor.SetDefaultWeapenType(tableItem.DefaultWeaponType);
			actor.isLocalActor = isLocalActor;
			actor.InitData(level, tableItem.FightID, skillInfo, "Data/AI/Hero_Skill_AI", professtionID, equips, buffList, strengthenLevel, rankBuffList, petData, sideEquips, avatar, isShowWeapon, isAIRobot, false, SkillSystemSourceType.None);
			actor.boxRadius = VInt.NewVInt(tableItem.DefaultBoxRadius, GlobalLogic.VALUE_1000);
			actor.walkAction = Global.Settings.walkAction;
			actor.runAction = Global.Settings.runAction;
			actor.walkSpeed = new VInt3(Global.Settings.walkSpeed);
			actor.runSpeed = new VInt3(Global.Settings.runSpeed);
			actor.walkSpeedFactor = Global.Settings.walkAniFactor;
			actor.runSpeedFactor = Global.Settings.runAniFactor;
			if (petData == null || petData.id > 0)
			{
			}
			BeEntityData entityData = actor.GetEntityData();
			if (entityData != null)
			{
				entityData.weight = tableItem.Weight * 10000;
				entityData.type = 0;
				entityData.jumpAttackID = tableItem.JumpAttackID;
				entityData.runAttackID = tableItem.RunAttackID;
				entityData.jumpAttackCount = tableItem.JumpAttackNum;
				entityData.name = name;
				entityData.height = tableItem.Height;
				actor.RegisterEvent(BeEventType.onTouchGround, delegate(object[] args)
				{
					actor.jumpAttackUseCount = 0;
				});
				actor.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
				{
					if (actor.m_iCurSkillID == actor.GetEntityData().jumpAttackID)
					{
						actor.jumpAttackUseCount++;
					}
				});
			}
			actor.hitEffect = tableItem.DefaultHitEffect;
			this._createCharacterUI(actor, playerSeat);
			return actor;
		}
		return null;
	}

	// Token: 0x06017241 RID: 94785 RVA: 0x0071B364 File Offset: 0x00719764
	public void CreateRegions(BeRegionBase.TriggerTarget target, List<int> regions)
	{
		if (target == null)
		{
			target = new BeRegionBase.TriggerTarget(this._regionTargetList);
		}
		for (int i = 0; i < this.sceneData.GetRegionInfoLength(); i++)
		{
			ISceneRegionInfoData regionInfo = this.sceneData.GetRegionInfo(i);
			if (!regions.Contains(regionInfo.GetEntityInfo().GetGlobalid()))
			{
				BeRegion beRegion = this.AddRegion(regionInfo, target);
				if (beRegion != null)
				{
					beRegion.triggerRegion = delegate(ISceneRegionInfoData info2, BeRegionTarget target2)
					{
						regions.Add(info2.GetEntityInfo().GetGlobalid());
						return true;
					};
				}
			}
		}
	}

	// Token: 0x06017242 RID: 94786 RVA: 0x0071B3F8 File Offset: 0x007197F8
	public void CreateDynamicRegion(BeRegionBase.TriggerTarget target, CustomSceneRegionInfo regionInfo, List<int> regions)
	{
		if (target == null)
		{
			target = new BeRegionBase.TriggerTarget(this._regionTargetList);
		}
		if (!regions.Contains(regionInfo.GetGlobalid()))
		{
			BeRegion beRegion = this.AddCustomRegion(regionInfo, target);
			if (beRegion != null)
			{
				beRegion.triggerRegion = delegate(ISceneRegionInfoData info2, BeRegionTarget target2)
				{
					regions.Add(info2.GetEntityInfo().GetGlobalid());
					return true;
				};
			}
		}
	}

	// Token: 0x06017243 RID: 94787 RVA: 0x0071B460 File Offset: 0x00719860
	public BeRegion AddCustomRegion(CustomSceneRegionInfo info, BeRegionBase.TriggerTarget target)
	{
		BeRegion beRegion = new BeRegion();
		beRegion.SetBeScene(this);
		beRegion.Create(info, false);
		beRegion.SetPosition(info.GetLogicPosition());
		beRegion.SetScale((VInt)info.GetEntityInfo().GetScale());
		beRegion.triggerTarget = target;
		if (beRegion != null)
		{
			this.mPendingRegion.Add(beRegion);
		}
		return beRegion;
	}

	// Token: 0x06017244 RID: 94788 RVA: 0x0071B4BE File Offset: 0x007198BE
	public void onEnterEndRoom()
	{
		this._setTransportDoor(true);
	}

	// Token: 0x06017245 RID: 94789 RVA: 0x0071B4C8 File Offset: 0x007198C8
	public void CreateDecorator()
	{
		for (int i = 0; i < this.sceneData.GetDecoratorInfoLenth(); i++)
		{
			ISceneDecoratorInfoData decoratorInfo = this.sceneData.GetDecoratorInfo(i);
			GeActorEx geActorEx = this.mCurrentGeScene.CreateActor(decoratorInfo.GetEntityInfo().GetResid(), 0, 0, true, true, true, false);
			if (geActorEx != null)
			{
				this.mDecoratorList.Add(geActorEx);
				geActorEx.SetPosition(decoratorInfo.GetEntityInfo().GetPosition());
				geActorEx.SetScaleV3(decoratorInfo.GetLocalScale());
				geActorEx.SetRotation(decoratorInfo.GetRotation());
				geActorEx.SetDyeColor(decoratorInfo.GetEntityInfo().GetColor(), geActorEx.renderObject);
				this.SetBlockLayer(decoratorInfo.GetEntityInfo().GetResid(), new VInt3(decoratorInfo.GetEntityInfo().GetPosition().x, decoratorInfo.GetEntityInfo().GetPosition().z, decoratorInfo.GetEntityInfo().GetPosition().y), true);
			}
		}
	}

	// Token: 0x06017246 RID: 94790 RVA: 0x0071B5C0 File Offset: 0x007199C0
	public void InitMonsterAttribute(BeEntityData attribute, UnitTable monsterData, int mode, int difficulty, int type, int level)
	{
		if (mode == 5)
		{
			type = (int)monsterData.Type;
			if (BattleMain.IsModePvP(this.mBattle.GetBattleType()))
			{
				mode = 6;
			}
		}
		MonsterAttributeTable monsterAttributeTable = (MonsterAttributeTable)Singleton<TableManager>.GetInstance().GetMonsterAttribute(mode, difficulty, type, level);
		if (monsterAttributeTable != null)
		{
			for (int i = 0; i < 41; i++)
			{
				AttributeType attributeType = (AttributeType)i;
				int monsterAttributeTableProperty = Singleton<TableManager>.GetInstance().GetMonsterAttributeTableProperty(attributeType, monsterAttributeTable);
				if (monsterAttributeTableProperty != 0)
				{
					attribute.SetAttributeValue(attributeType, monsterAttributeTableProperty, false);
				}
			}
		}
	}

	// Token: 0x06017247 RID: 94791 RVA: 0x0071B644 File Offset: 0x00719A44
	public void FixUnitAttribute(BeEntityData attribute, UnitTable fixUnitData, int camp)
	{
		UnitTable summonMonsterAttr = this.GetSummonMonsterAttr(fixUnitData.ID);
		UnitTable unitTable;
		if (summonMonsterAttr != null)
		{
			unitTable = summonMonsterAttr;
		}
		else
		{
			unitTable = fixUnitData;
		}
		attribute.SetMagicElementTypes(unitTable.Elements, true);
		UnionCell[] array = new UnionCell[]
		{
			unitTable.LightAttack,
			unitTable.FireAttack,
			unitTable.IceAttack,
			unitTable.DarkAttack
		};
		UnionCell[] array2 = new UnionCell[]
		{
			unitTable.LightDefence,
			unitTable.FireDefence,
			unitTable.IceDefence,
			unitTable.DarkDefence
		};
		for (int i = 1; i < 5; i++)
		{
			CrypticInt32[] magicElementsAttack = attribute.battleData.magicElementsAttack;
			int num = i;
			magicElementsAttack[num] += TableManager.GetValueFromUnionCell(array[i - 1], attribute.level, true);
			CrypticInt32[] magicElementsDefence = attribute.battleData.magicElementsDefence;
			int num2 = i;
			magicElementsDefence[num2] += TableManager.GetValueFromUnionCell(array2[i - 1], attribute.level, true);
		}
		UnionCell[] array3 = new UnionCell[]
		{
			unitTable.abnormalResist1,
			unitTable.abnormalResist2,
			unitTable.abnormalResist3,
			unitTable.abnormalResist4,
			unitTable.abnormalResist5,
			unitTable.abnormalResist6,
			unitTable.abnormalResist7,
			unitTable.abnormalResist8,
			unitTable.abnormalResist9,
			unitTable.abnormalResist10,
			unitTable.abnormalResist11,
			unitTable.abnormalResist12,
			unitTable.abnormalResist13
		};
		for (int j = 0; j < 13; j++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(array3[j], attribute.level, true);
			if (valueFromUnionCell != 0)
			{
				CrypticInt32[] abnormalResists = attribute.battleData.abnormalResists;
				int num3 = j;
				abnormalResists[num3] += valueFromUnionCell;
			}
		}
		for (int k = 0; k < 41; k++)
		{
			AttributeType attributeType = (AttributeType)k;
			int monsterTableProperty = Singleton<TableManager>.GetInstance().GetMonsterTableProperty(attributeType, unitTable);
			if (monsterTableProperty != GlobalLogic.VALUE_100000)
			{
				int attributeValue = attribute.GetAttributeValue(attributeType);
				int value = attributeValue * VFactor.NewVFactor((long)monsterTableProperty, (long)(GlobalLogic.VALUE_1000 * GlobalLogic.VALUE_100));
				attribute.SetAttributeValue(attributeType, value, false);
			}
		}
		attribute.PostInit(null);
		int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(unitTable.maxFixHp, attribute.level, true);
		if (valueFromUnionCell2 > 0)
		{
			if (attribute.battleData != null)
			{
				attribute.battleData.SetNeedChangeSta(false);
			}
			attribute.SetHP(valueFromUnionCell2);
			attribute.SetMaxHP(valueFromUnionCell2);
		}
		int dungeonID = this.mBattle.dungeonManager.GetDungeonDataManager().id.dungeonID;
		int count = this.mBattle.dungeonPlayerManager.GetAllPlayers().Count;
		if (camp != 0)
		{
			DungeonDifficultyAdjustTable dungeonDifficultyAdjustTable = (DungeonDifficultyAdjustTable)Singleton<TableManager>.GetInstance().GetDungeonDifficultyAdjustInfo(dungeonID, count);
			if (dungeonDifficultyAdjustTable != null)
			{
				VFactor vfactor = new VFactor((long)dungeonDifficultyAdjustTable.MonsterHPFactor, (long)GlobalLogic.VALUE_1000);
				VFactor f = new VFactor((long)dungeonDifficultyAdjustTable.MonsterAttackFactor, (long)GlobalLogic.VALUE_1000);
				if (unitTable.Type == UnitTable.eType.BOSS)
				{
					vfactor = new VFactor((long)dungeonDifficultyAdjustTable.BossHPFactor, (long)GlobalLogic.VALUE_1000);
					f = new VFactor((long)dungeonDifficultyAdjustTable.BossAttackFactor, (long)GlobalLogic.VALUE_1000);
				}
				if (vfactor <= VFactor.NewVFactor((long)GlobalLogic.VALUE_1000, (long)GlobalLogic.VALUE_1000))
				{
					vfactor = VFactor.NewVFactor((long)GlobalLogic.VALUE_1000, (long)GlobalLogic.VALUE_1000);
				}
				attribute.SetMaxHP(attribute.GetMaxHP() * vfactor);
				attribute.SetHP(attribute.GetMaxHP());
				attribute.battleData.attack = Mathf.Max(1, attribute.battleData.attack * f);
			}
		}
		if (attribute.GetHP() <= 0)
		{
			this.isBattleDataError = true;
		}
		if (Global.Settings.isDebug && Global.Settings.monsterHP > 0)
		{
			attribute.SetHP(Global.Settings.monsterHP);
			attribute.SetMaxHP(Global.Settings.monsterHP);
		}
	}

	// Token: 0x06017248 RID: 94792 RVA: 0x0071BA84 File Offset: 0x00719E84
	private UnitTable GetSummonMonsterAttr(int originMonsterId)
	{
		if (this.mBattle == null)
		{
			return null;
		}
		int[] array = new int[]
		{
			originMonsterId
		};
		this.TriggerEvent(BeEventSceneType.onChangeSummonMonsterAttr, new object[]
		{
			array
		});
		if (array[0] == originMonsterId)
		{
			return null;
		}
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(array[0], string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("创建怪物失败，表中找不到ID为:{0}的怪物", new object[]
			{
				array[0]
			});
			return null;
		}
		return tableItem;
	}

	// Token: 0x06017249 RID: 94793 RVA: 0x0071BB04 File Offset: 0x00719F04
	public void ChangeMonsterAbility(BeActor monster, UnitTable unitData, bool isSetIn = true)
	{
		for (int i = 0; i < unitData.AbilityChange.Count; i++)
		{
			BeAbilityType abilityType = (BeAbilityType)unitData.AbilityChange[i];
			monster.stateController.SetAbilityEnable(abilityType, !isSetIn);
			monster.stateController.SetBornAbility(abilityType, !isSetIn);
		}
	}

	// Token: 0x0601724A RID: 94794 RVA: 0x0071BB5C File Offset: 0x00719F5C
	public void SetMonsterAiInfo(BeActor monster, UnitTable data)
	{
		if (data != null)
		{
			BeAIManager beAIManager = new BeActorAIManager();
			monster.InitAI(beAIManager);
			if (beAIManager != null)
			{
				beAIManager.SetAIInfo(data, false);
			}
			monster.SetActorNeedCost(false);
		}
	}

	// Token: 0x0601724B RID: 94795 RVA: 0x0071BB94 File Offset: 0x00719F94
	public void SetMonsterProtect(BeActor monster, UnitTable data)
	{
		if (data.UseProtect > 0 && monster.protectManager != null)
		{
			VRate floatHurtPercent = (data.ProtectFloatPercent <= 0) ? ((VRate)Global.Settings.defaultFloatHurt) : new VRate(data.ProtectFloatPercent);
			VRate floatHurtLevelPercent = (data.ProtectFloatPercent2 <= 0) ? ((VRate)Global.Settings.defaultFloatLevelHurat) : new VRate(data.ProtectFloatPercent2);
			VRate groundHurtPercent = (data.ProtectGroundPercent <= 0) ? ((VRate)Global.Settings.defaultGroundHurt) : new VRate(data.ProtectGroundPercent);
			VRate standHurtPercent = (data.ProtectStandPercent <= 0) ? ((VRate)Global.Settings.defaultStandHurt) : new VRate(data.ProtectStandPercent);
			monster.protectManager.SetValue(floatHurtPercent, floatHurtLevelPercent, groundHurtPercent, standHurtPercent);
			monster.protectManager.SetEnable(true);
		}
	}

	// Token: 0x0601724C RID: 94796 RVA: 0x0071BC84 File Offset: 0x0071A084
	public void AddBornBuff(BeActor monster, UnitTable data)
	{
		if (data == null)
		{
			return;
		}
		monster.delayCaller.DelayCall(30, delegate
		{
			FlatBufferArray<int> bornBuff = data.BornBuff;
			for (int i = 0; i < bornBuff.Count; i++)
			{
				int num = bornBuff[i];
				if (num > 0)
				{
					int buffLevel = monster.GetEntityData().level;
					monster.buffController.TryAddBuff(num, -1, buffLevel);
				}
			}
			for (int j = 0; j < data.BornBuff2.Count; j++)
			{
				int num2 = data.BornBuff2[j];
				if (num2 > 0)
				{
					BuffInfoData buffInfoData = new BuffInfoData(num2, monster.GetEntityData().level, 0);
					if (buffInfoData.condition <= BuffCondition.NONE)
					{
						monster.buffController.TriggerBuffInfo(buffInfoData, null, null);
					}
					else
					{
						monster.buffController.AddTriggerBuff(buffInfoData);
					}
				}
			}
			for (int k = 0; k < data.BornMechanism.Count; k++)
			{
				int num3 = data.BornMechanism[k];
				if (num3 > 0)
				{
					monster.AddMechanism(num3, monster.GetEntityData().level, MechanismSourceType.NONE, null, 0);
				}
			}
		}, 0, 0, false);
	}

	// Token: 0x0601724D RID: 94797 RVA: 0x0071BCD4 File Offset: 0x0071A0D4
	public void ForceDoDeadEntityByOwner(BeEntity owner)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] != null)
			{
				if (this.mEntitys[i].GetEntityData() == null || !this.mEntitys[i].GetEntityData().isPet)
				{
					if (this.mEntitys[i] != owner && this.mEntitys[i].GetOwner() == owner)
					{
						this.mEntitys[i].DoDead(false);
					}
				}
			}
		}
	}

	// Token: 0x0601724E RID: 94798 RVA: 0x0071BD84 File Offset: 0x0071A184
	public List<BeEntity> GetEntities()
	{
		return this.mEntitys;
	}

	// Token: 0x0601724F RID: 94799 RVA: 0x0071BD8C File Offset: 0x0071A18C
	public void GetEntitys2(List<BeEntity> entityList)
	{
		entityList.AddRange(this.mEntitys);
		if (this.mPendingArray.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.mPendingArray.Count; i++)
		{
			if (!entityList.Contains(this.mPendingArray[i]))
			{
				entityList.Add(this.mPendingArray[i]);
			}
		}
	}

	// Token: 0x06017250 RID: 94800 RVA: 0x0071BE01 File Offset: 0x0071A201
	public List<BeEntity> GetFullEntities()
	{
		this.ForceUpdatePendingArray();
		return this.mEntitys;
	}

	// Token: 0x06017251 RID: 94801 RVA: 0x0071BE0F File Offset: 0x0071A20F
	public List<BeEntity> GetPendingEntities()
	{
		return this.mPendingArray;
	}

	// Token: 0x06017252 RID: 94802 RVA: 0x0071BE17 File Offset: 0x0071A217
	public int GetEntityCount()
	{
		return this.mEntitys.Count;
	}

	// Token: 0x06017253 RID: 94803 RVA: 0x0071BE24 File Offset: 0x0071A224
	public BeEntity GetEntityAt(int iIndex)
	{
		return this.mEntitys[iIndex];
	}

	// Token: 0x06017254 RID: 94804 RVA: 0x0071BE34 File Offset: 0x0071A234
	public void Update(int iDeltaTime)
	{
		this.FrameRandom.Range100();
		if (this.m_EventManager != null)
		{
			this.m_EventManager.Update();
		}
		base._updateState(iDeltaTime);
		switch (base.state)
		{
		case BeSceneState.onReady:
		case BeSceneState.onFight:
		case BeSceneState.onClear:
		case BeSceneState.onBulletTime:
		case BeSceneState.onFinish:
			this.mDurtime += iDeltaTime;
			this.UpdateDelayCaller(iDeltaTime);
			this.UpdateEntities(iDeltaTime);
			this.UpdateRegions(iDeltaTime);
			if (this.mBattle != null && this.mBattle.LevelMgr != null)
			{
				this.mBattle.LevelMgr.Update(iDeltaTime);
			}
			if (base.state == BeSceneState.onClear)
			{
				this.UpdateShowArrowForDoor(iDeltaTime);
			}
			this.UpdateTimer(iDeltaTime);
			break;
		}
	}

	// Token: 0x06017255 RID: 94805 RVA: 0x0071BF0D File Offset: 0x0071A30D
	public void UpdateCheckGlobalLogicValues(int deltaTime)
	{
		if (this.isBattleDataError)
		{
			return;
		}
		this.checkBattleDataErrorAcc += deltaTime;
		if (GlobalLogic.GetTotalSum() != 253400)
		{
			this.isBattleDataError = true;
		}
	}

	// Token: 0x06017256 RID: 94806 RVA: 0x0071BF40 File Offset: 0x0071A340
	public void UpdateGraphic(int iDeltaTime)
	{
		switch (base.state)
		{
		case BeSceneState.onReady:
		case BeSceneState.onFight:
		case BeSceneState.onClear:
		case BeSceneState.onBulletTime:
		case BeSceneState.onFinish:
			if (base.state == BeSceneState.onBulletTime && Singleton<ReplayServer>.GetInstance() != null && !Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				double timeStamp = Utility.GetTimeStamp();
				if (this.bossDeadTimeStamp > 0.0 && timeStamp - this.bossDeadTimeStamp >= 5.0)
				{
					Time.timeScale = 1f;
					this.bossDeadTimeStamp = -1.0;
				}
			}
			if (this.isBattleDataError)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("战斗数据异常！", null, string.Empty, false);
				this.isBattleDataError = false;
				this.mDelayCaller.DelayCall(GlobalLogic.VALUE_2000, delegate
				{
					Singleton<ClientSystemManager>.GetInstance()._QuitToLoginImpl();
				}, 0, 0, false);
			}
			this.UpdateCheckGlobalLogicValues(iDeltaTime);
			this.UpdateEntitiesGraphic(iDeltaTime);
			this.UpdateShowArrowForMonster(iDeltaTime);
			this.mBattle.TrailManager.Update(iDeltaTime);
			this.UpdateBlindMask(iDeltaTime);
			if (Global.Settings.debugDrawBlock && this.mCurrentGeScene != null)
			{
				this.mCurrentGeScene.SetBlockData(this.mSceneData, this.mBlockInfo);
			}
			break;
		}
		this.SetDebugDraw(false);
	}

	// Token: 0x06017257 RID: 94807 RVA: 0x0071C0B0 File Offset: 0x0071A4B0
	private void UpdateTimer(int delta)
	{
		if (this.simpleTimer != null)
		{
			this.simpleTimer.UpdateTimer(delta);
		}
		if (this.pkTimer == null)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				this.pkTimer = ClientSystemBattle.TimerController;
			}
		}
		if (this.pkTimer != null)
		{
			this.pkTimer.UpdateTimer(delta);
		}
	}

	// Token: 0x06017258 RID: 94808 RVA: 0x0071C123 File Offset: 0x0071A523
	private void UpdateDelayCaller(int delta)
	{
		if (this.mDelayCaller != null)
		{
			this.mDelayCaller.Update(delta);
		}
	}

	// Token: 0x06017259 RID: 94809 RVA: 0x0071C13C File Offset: 0x0071A53C
	public void ForceUpdatePendingArray()
	{
		this.mEntitys.AddRange(this.mPendingArray);
		this.mPendingArray.Clear();
	}

	// Token: 0x0601725A RID: 94810 RVA: 0x0071C15C File Offset: 0x0071A55C
	public BeObject CreateHellDestruct(Battle.DungeonHellInfo info)
	{
		if (info == null)
		{
			return null;
		}
		if (info.state == eDungeonHellState.End)
		{
			return null;
		}
		DungeonHellMode mode = info.mode;
		if (mode != DungeonHellMode.Normal && mode != DungeonHellMode.Hard && mode != DungeonHellMode.Hard_Ultimate)
		{
			return this.mHell;
		}
		VInt3 zero = VInt3.zero;
		if (this.sceneData.GetBirthPosition() != null)
		{
			zero = new VInt3(this.sceneData.GetBirthPosition().GetPosition());
		}
		this.mHell = this.CreateDestruct(3017, zero, Color.white, VInt.one);
		this.mHell.SetCanBeAttacked(false);
		this.mHell.RegisterEvent(BeEventType.onDead, delegate(object[] xargs)
		{
			this.mHell = null;
		});
		return this.mHell;
	}

	// Token: 0x0601725B RID: 94811 RVA: 0x0071C21C File Offset: 0x0071A61C
	private bool CheckEntityCanRemoveFlag(BeEntity item)
	{
		if (item.GetLifeState() == 4)
		{
			BeActor beActor = item as BeActor;
			if (beActor != null)
			{
				if (beActor.m_iCamp != 1)
				{
					if (beActor.isLocalActor)
					{
						return false;
					}
				}
			}
			if (item.m_iRemoveTime <= 0)
			{
				if (beActor == null || beActor.m_iCamp == 1)
				{
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601725C RID: 94812 RVA: 0x0071C284 File Offset: 0x0071A684
	private bool CheckEntityCanRemove(BeEntity item)
	{
		if (item.GetLifeState() == 4)
		{
			BeActor beActor = item as BeActor;
			if (beActor != null)
			{
				if (beActor.m_iCamp == 1)
				{
					this._deadMonster(beActor);
				}
				else if (beActor.isLocalActor)
				{
					return false;
				}
			}
			if (item.m_iRemoveTime <= 0)
			{
				if (beActor != null && beActor.m_iCamp == 1)
				{
					this._removeMonster(beActor);
				}
				else if (item is BeObject)
				{
					this._removeDestruct();
				}
				item.OnRemove(false);
				if (item.dontDelete)
				{
					this.mDeadBody.Add(item);
				}
				item.ClearEvent();
				if (item is BeProjectile)
				{
					this.BeProjectilePool.PutProjectile(item as BeProjectile);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601725D RID: 94813 RVA: 0x0071C350 File Offset: 0x0071A750
	private void UpdateEntitiesGraphic(int iDeltaTime)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null)
			{
				beEntity.UpdateGraphic(iDeltaTime);
			}
		}
		for (int j = 0; j < this.mTempSaveEntitys.Count; j++)
		{
			BeEntity beEntity2 = this.mTempSaveEntitys[j];
			if (beEntity2 != null)
			{
				beEntity2.UpdateGraphic(iDeltaTime);
			}
		}
	}

	// Token: 0x0601725E RID: 94814 RVA: 0x0071C3D8 File Offset: 0x0071A7D8
	private void UpdateEntities(int iDeltaTime)
	{
		if (this.mPendingArray.Count > 0)
		{
			this.mEntitys.AddRange(this.mPendingArray);
			this.mPendingArray.Clear();
		}
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null)
			{
				if (base.state != BeSceneState.onReady && !flag && beEntity.hasAI && !beEntity.pauseAI && this.mIsTickAI)
				{
					beEntity.aiManager.Update(iDeltaTime);
				}
				beEntity.Update(iDeltaTime);
				if (base.state != BeSceneState.onReady && !flag && beEntity.hasAI && !beEntity.pauseAI && this.mIsTickAI)
				{
					beEntity.aiManager.PostUpdate(iDeltaTime);
				}
				if (beEntity.GetLifeState() == 4)
				{
					beEntity.m_iRemoveTime -= iDeltaTime;
				}
				if (this.CheckEntityCanRemoveFlag(beEntity))
				{
					flag2 = true;
				}
			}
		}
		if (flag2)
		{
			this._EntityRemoveAll(false, new Predicate<BeEntity>(this.CheckEntityCanRemove));
		}
		for (int j = 0; j < this.mEntitys.Count; j++)
		{
			BeEntity beEntity2 = this.mEntitys[j];
			if (beEntity2 != null)
			{
				beEntity2.PostUpate();
			}
		}
		this.UpdateCheckMosnterClear(iDeltaTime);
	}

	// Token: 0x0601725F RID: 94815 RVA: 0x0071C555 File Offset: 0x0071A955
	private void _EntityRemoveAll(bool bForceUpdatePending, Predicate<BeEntity> match)
	{
		if (bForceUpdatePending)
		{
			this.ForceUpdatePendingArray();
		}
		this.mEntitys.RemoveAll(match);
	}

	// Token: 0x06017260 RID: 94816 RVA: 0x0071C570 File Offset: 0x0071A970
	private bool CheckRegionCanRemove(BeRegionBase item)
	{
		return item.canRemove;
	}

	// Token: 0x06017261 RID: 94817 RVA: 0x0071C578 File Offset: 0x0071A978
	private void UpdateRegions(int deltaTime)
	{
		if (this.mPendingRegion.Count > 0)
		{
			this.mRegions.AddRange(this.mPendingRegion);
			this.mPendingRegion.Clear();
		}
		bool flag = false;
		for (int i = 0; i < this.mRegions.Count; i++)
		{
			BeRegionBase beRegionBase = this.mRegions[i];
			if (!this.CheckRegionCanRemove(beRegionBase))
			{
				beRegionBase.Update(deltaTime);
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			this._RemoveRegion(false, new Predicate<BeRegionBase>(this.CheckRegionCanRemove));
		}
	}

	// Token: 0x06017262 RID: 94818 RVA: 0x0071C610 File Offset: 0x0071AA10
	private void _RemoveRegion(bool bForceUpdatePending, Predicate<BeRegionBase> match)
	{
		if (bForceUpdatePending && this.mPendingRegion.Count > 0)
		{
			this.mRegions.AddRange(this.mPendingRegion);
			this.mPendingRegion.Clear();
		}
		this.mRegions.RemoveAll(match);
	}

	// Token: 0x06017263 RID: 94819 RVA: 0x0071C660 File Offset: 0x0071AA60
	public DGrid CalGridByPosition(VInt3 position)
	{
		int x = (position.x - this.logicXSize.x) / this.logicGrild.x;
		int y = (position.y - this.logicZSize.x) / this.logicGrild.y;
		return new DGrid(x, y);
	}

	// Token: 0x06017264 RID: 94820 RVA: 0x0071C6B4 File Offset: 0x0071AAB4
	public VInt3 CalPositionByGrid(DGrid grid)
	{
		return new VInt3(grid.x * this.logicGrild.x + this.logicXSize.x, (grid.y + 1) * this.logicGrild.y + this.logicZSize.x, 0);
	}

	// Token: 0x06017265 RID: 94821 RVA: 0x0071C708 File Offset: 0x0071AB08
	public bool IsInBlockPlayer(DGrid grid)
	{
		int x = grid.x;
		int y = grid.y;
		byte[] array = this.mBlockInfo;
		int num = y * this.logicWidth + x;
		return x < 0 || x >= this.logicWidth || y < 0 || y >= this.logicHeight || array[num] >= 1;
	}

	// Token: 0x06017266 RID: 94822 RVA: 0x0071C768 File Offset: 0x0071AB68
	public bool IsInBlockPlayer(VInt3 position)
	{
		DGrid grid = this.CalGridByPosition(position);
		return this.IsInBlockPlayer(grid);
	}

	// Token: 0x06017267 RID: 94823 RVA: 0x0071C784 File Offset: 0x0071AB84
	public bool IsInLogicScene(VInt3 position)
	{
		return position.x <= this.logicXSize.y && position.x >= this.logicXSize.x && position.y <= this.logicZSize.y && position.y >= this.logicZSize.x;
	}

	// Token: 0x06017268 RID: 94824 RVA: 0x0071C7F0 File Offset: 0x0071ABF0
	public void SetBlock(DGrid grid, bool isBlock)
	{
		byte[] array = this.mBlockInfo;
		int x = grid.x;
		int y = grid.y;
		if (x < 0 || x >= this.logicWidth || y < 0 || y >= this.logicHeight)
		{
			return;
		}
		int num = y * this.logicWidth + x;
		if (isBlock)
		{
			array[num] = 1;
		}
		else
		{
			array[num] = 0;
		}
	}

	// Token: 0x06017269 RID: 94825 RVA: 0x0071C85C File Offset: 0x0071AC5C
	protected byte[] _GetBlockData(int iResID, out int width, out int height)
	{
		string blockDataResPath = FBModelDataSerializer.GetBlockDataResPath(iResID);
		DModelData dmodelData = null;
		if (!string.IsNullOrEmpty(blockDataResPath))
		{
			dmodelData = (Singleton<AssetLoader>.instance.LoadRes(blockDataResPath, typeof(DModelData), true, 0U).obj as DModelData);
		}
		if (null != dmodelData)
		{
			width = dmodelData.blockGridChunk.gridWidth;
			height = dmodelData.blockGridChunk.gridHeight;
			return dmodelData.blockGridChunk.gridBlockData;
		}
		width = 1;
		height = 1;
		return BeScene.DEFAULT_BLOCK_DATA;
	}

	// Token: 0x0601726A RID: 94826 RVA: 0x0071C8DC File Offset: 0x0071ACDC
	public void SetBlockLayer(int iResID, VInt3 pos, bool block = true)
	{
		DGrid dgrid = new DGrid(GlobalLogic.VALUE_5, GlobalLogic.VALUE_10);
		int num;
		int num2;
		byte[] array = this._GetBlockData(iResID, out num, out num2);
		bool flag = true;
		if (num == 1 && num2 == 1)
		{
			return;
		}
		dgrid.x = num;
		dgrid.y = num2;
		DGrid dgrid2 = this.CalGridByPosition(pos);
		int x = dgrid2.x;
		int y = dgrid2.y;
		int num3 = x - dgrid.x / 2 + 1;
		int num4 = y - dgrid.y / 2 + 1;
		for (int i = num3; i < num3 + dgrid.x; i++)
		{
			for (int j = num4; j < num4 + dgrid.y; j++)
			{
				if (flag)
				{
					int num5 = i - num3 + (j - num4) * num;
					bool flag2 = array[num5] == 1;
					if (flag2)
					{
						if (block)
						{
							this.SetBlock(new DGrid(i, j), true);
						}
						else
						{
							this.SetBlock(new DGrid(i, j), false);
						}
					}
				}
				else
				{
					this.SetBlock(new DGrid(i, j), block);
				}
			}
		}
	}

	// Token: 0x0601726B RID: 94827 RVA: 0x0071CA0C File Offset: 0x0071AE0C
	public void UpdateShowArrowForMonster(int delta)
	{
		this.arrowAcc += delta;
		if (this.arrowAcc > this.arrowUpdateInterval)
		{
			this.arrowAcc -= this.arrowUpdateInterval;
			BattlePlayer mainPlayer = this.mBattle.dungeonPlayerManager.GetMainPlayer();
			if (mainPlayer != null && mainPlayer.playerActor != null)
			{
				for (int i = 0; i < this.mEntitys.Count; i++)
				{
					BeActor beActor = this.mEntitys[i] as BeActor;
					if (beActor != null && beActor.m_iCamp != mainPlayer.playerActor.m_iCamp && beActor.GetEntityData() != null && beActor.GetEntityData().type != 9 && !beActor.GetEntityData().isPet && beActor.GetEntityData().type != 8 && !this.IsInScreen(beActor.GetPosition().vec3) && !beActor.stateController.IsInvisible())
					{
						this.TraceActor(beActor);
						return;
					}
				}
			}
			this.TraceActor(null);
		}
	}

	// Token: 0x0601726C RID: 94828 RVA: 0x0071CB30 File Offset: 0x0071AF30
	public void ChooseADoorToChance()
	{
		TransportDoorType transportDoorType = TransportDoorType.None;
		if (this.mBattle.GetBattleType() == BattleType.Hell && this.mBattle.dungeonManager.GetDungeonDataManager().IsHellAreaVisited() == 0)
		{
			this.traceDoorPos = this.mBattle.dungeonManager.GetDungeonDataManager().CurrentGuideHellPosition(ref transportDoorType);
		}
		else
		{
			this.traceDoorPos = this.mBattle.dungeonManager.GetDungeonDataManager().CurrentGuidePosition(ref transportDoorType);
		}
	}

	// Token: 0x0601726D RID: 94829 RVA: 0x0071CBAC File Offset: 0x0071AFAC
	public TransportDoorType GetChanceDoorType()
	{
		TransportDoorType result = TransportDoorType.None;
		this.mBattle.dungeonManager.GetDungeonDataManager().CurrentGuidePosition(ref result);
		return result;
	}

	// Token: 0x0601726E RID: 94830 RVA: 0x0071CBD4 File Offset: 0x0071AFD4
	public VInt3 GetDoorPosition()
	{
		VInt3 zero = VInt3.zero;
		this.ChooseADoorToChance();
		if (this.traceDoorPos != VInt3.zero)
		{
			zero = this.traceDoorPos;
			zero.z = VInt.zeroDotOne.i;
			zero.x = Mathf.Clamp(zero.x, this.logicXSize.x, this.logicXSize.y);
			zero.y = Mathf.Clamp(zero.y, this.logicZSize.x, this.logicZSize.y);
		}
		return zero;
	}

	// Token: 0x0601726F RID: 94831 RVA: 0x0071CC70 File Offset: 0x0071B070
	public VInt3 GetSceneCenterPosition()
	{
		VInt3 zero = VInt3.zero;
		int num = Mathf.Abs(this.logicXSize.y - this.logicXSize.x);
		int num2 = Mathf.Abs(this.logicZSize.y - this.logicZSize.x);
		zero.x = this.logicXSize.x + num / 2;
		zero.y = this.logicZSize.x + num2 / 2;
		zero.z = VInt.zeroDotOne.i;
		return zero;
	}

	// Token: 0x06017270 RID: 94832 RVA: 0x0071CD00 File Offset: 0x0071B100
	public void UpdateShowArrowForDoor(int delta)
	{
		this.arrowAcc += delta;
		if (this.arrowAcc > this.arrowUpdateInterval)
		{
			this.arrowAcc -= this.arrowUpdateInterval;
			if (this.traceDoorPos != VInt3.zero)
			{
				VInt3 vint = this.traceDoorPos;
				vint.z = VInt.zeroDotOne.i;
				vint.x = Mathf.Clamp(vint.x, this.logicXSize.x, this.logicXSize.y);
				vint.y = Mathf.Clamp(vint.y, this.logicZSize.x, this.logicZSize.y);
				if (!this.IsInScreen(vint.vec3))
				{
					this.TracePosition(vint.vec3, true, false, default(Vector3));
				}
				else
				{
					this.FinishTraceDoor();
				}
			}
		}
	}

	// Token: 0x06017271 RID: 94833 RVA: 0x0071CDF8 File Offset: 0x0071B1F8
	public void FinishTraceDoor()
	{
		this.TracePosition(Vec3.zero, true, true, default(Vector3));
	}

	// Token: 0x06017272 RID: 94834 RVA: 0x0071CE1C File Offset: 0x0071B21C
	public void StartBlindMask()
	{
		this.isBlind = true;
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null)
		{
			clientSystemBattle.SetBlindMask(true);
		}
	}

	// Token: 0x06017273 RID: 94835 RVA: 0x0071CE50 File Offset: 0x0071B250
	public void StopBlindMask()
	{
		this.isBlind = false;
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null)
		{
			clientSystemBattle.SetBlindMask(false);
		}
	}

	// Token: 0x06017274 RID: 94836 RVA: 0x0071CE84 File Offset: 0x0071B284
	public void UpdateBlindMask(int delta)
	{
		if (!this.isBlind)
		{
			return;
		}
		BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
		if (localPlayer != null)
		{
			BeActor playerActor = localPlayer.playerActor;
			Vector3 gePosition = playerActor.GetGePosition();
			Vector2 blindMaskPosition = this.currentGeScene.WorldPosToScreenPos(gePosition);
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetBlindMaskPosition(blindMaskPosition);
			}
		}
	}

	// Token: 0x06017275 RID: 94837 RVA: 0x0071CEEC File Offset: 0x0071B2EC
	public void TraceActor(BeActor target)
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (target == null || target.IsDead())
		{
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowArrow(false, 0f, true, false);
			}
			return;
		}
		if (target.m_pkGeActor == null)
		{
			return;
		}
		Vector3 headPos;
		headPos..ctor(target.GetPosition().vector3.x, target.m_pkGeActor.GetOverHeadPosition().y, target.GetPosition().vector3.z);
		this.TracePosition(target.GetPosition().vec3, false, false, headPos);
	}

	// Token: 0x06017276 RID: 94838 RVA: 0x0071CF9C File Offset: 0x0071B39C
	public void TracePosition(Vec3 pos, bool withGo = false, bool forceRemove = false, Vector3 headPos = default(Vector3))
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		Vector2 vector = this.currentGeScene.WorldPosToScreenPos(pos.vector3());
		Vector2 vector2 = this.currentGeScene.WorldPosToScreenPos(headPos);
		float num = (!(headPos == default(Vector3))) ? vector2.y : vector.y;
		if (forceRemove || (vector.x > 0f && vector.x <= (float)Screen.width && num > 0f && num <= (float)Screen.height))
		{
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowArrow(false, 0f, true, withGo);
			}
		}
		else
		{
			Vector2 vector3;
			vector3..ctor((float)(Screen.width / 2), (float)Screen.height / 2f);
			bool right = true;
			vector3.x = (float)Screen.width;
			if (vector.x < 0f)
			{
				right = false;
				vector3.x = 0f;
			}
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowArrow(true, vector.y / (float)Screen.height, right, withGo);
			}
		}
	}

	// Token: 0x06017277 RID: 94839 RVA: 0x0071D0C8 File Offset: 0x0071B4C8
	public bool IsInScreen(Vec3 pos)
	{
		Vector2 vector = this.currentGeScene.WorldPosToScreenPos(new Vector3(pos.x, pos.z, pos.y));
		return vector.x > 0f && vector.x <= (float)Screen.width && vector.y > 0f && vector.y <= (float)Screen.height;
	}

	// Token: 0x06017278 RID: 94840 RVA: 0x0071D144 File Offset: 0x0071B544
	public void SetDebugDraw(bool flag)
	{
		int i = 0;
		int count = this.mEntitys.Count;
		while (i < count)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity.m_pkGeActor != null)
			{
				beEntity.m_pkGeActor.showDebugBox = Global.Settings.showDebugBox;
			}
			i++;
		}
	}

	// Token: 0x06017279 RID: 94841 RVA: 0x0071D19C File Offset: 0x0071B59C
	public void DeleteEnemeyActorById(int resId)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity.m_iCamp == 1 && beEntity.m_iResID == resId)
			{
				beEntity.DoDead(false);
				break;
			}
		}
	}

	// Token: 0x0601727A RID: 94842 RVA: 0x0071D1F8 File Offset: 0x0071B5F8
	public void ClearAllMonsters()
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && beActor.m_iCamp == 1 && beActor.GetEntityData().type != 8 && beActor.GetEntityData().type != 9)
			{
				beActor.GetEntityData().SetHP(-1);
				beActor.JudgeDead();
				beActor.DoDead(false);
			}
		}
	}

	// Token: 0x0601727B RID: 94843 RVA: 0x0071D28C File Offset: 0x0071B68C
	public void ClearAllCharacter()
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null && beEntity.m_iCamp == 1)
			{
				beEntity.DoHurt(int.MaxValue, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
				beEntity.DoDead(false);
			}
		}
	}

	// Token: 0x0601727C RID: 94844 RVA: 0x0071D2EB File Offset: 0x0071B6EB
	public bool HasEntity(BeEntity entity)
	{
		return this.mEntitys.Contains(entity);
	}

	// Token: 0x0601727D RID: 94845 RVA: 0x0071D2FC File Offset: 0x0071B6FC
	public void InitFriendActor(VInt3 pos)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && beActor.GetEntityData().isSummonMonster)
			{
				if (beActor.actionManager != null)
				{
					beActor.actionManager.StopAll();
				}
				beActor.SetPosition(pos, false, true, false);
				if (beActor.isFloating)
				{
					bool force = !this.IsUseRestoreFloatingNew();
					beActor.RestoreFloating(force);
				}
			}
		}
	}

	// Token: 0x0601727E RID: 94846 RVA: 0x0071D39D File Offset: 0x0071B79D
	private bool IsUseRestoreFloatingNew()
	{
		return this.mBattle != null && !this.mBattle.HasFlag(BattleFlagType.PassDoorSetFloat);
	}

	// Token: 0x0601727F RID: 94847 RVA: 0x0071D3C8 File Offset: 0x0071B7C8
	public bool GetSummonBySummoner(List<BeActor> monsters, BeActor summoner, bool checkPendingList = false, bool isMagicSummon = false)
	{
		if (monsters == null)
		{
			return false;
		}
		monsters.Clear();
		List<BeEntity> list = (!checkPendingList) ? this.mEntitys : this.mPendingArray;
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i] as BeActor;
			if (beActor != null && (beActor == null || !beActor.IsDead()))
			{
				BeEntityData entityData = beActor.GetEntityData();
				if (entityData != null)
				{
					if (!isMagicSummon || beActor.IsSummonMonster())
					{
						if (entityData.isSummonMonster && beActor.GetOwner() as BeActor == summoner && !entityData.isPet)
						{
							monsters.Add(beActor);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06017280 RID: 94848 RVA: 0x0071D494 File Offset: 0x0071B894
	public int GetSummonCountByID(int mid, BeActor owner = null)
	{
		int num = 0;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && (beActor == null || !beActor.IsDead()))
			{
				BeEntityData entityData = beActor.GetEntityData();
				if (entityData != null)
				{
					if (entityData.isSummonMonster && entityData.MonsterIDEqual(mid))
					{
						if (owner != null)
						{
							if (beActor.GetOwner() == owner)
							{
								num++;
							}
						}
						else
						{
							num++;
						}
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06017281 RID: 94849 RVA: 0x0071D538 File Offset: 0x0071B938
	public int GetMonsterCountByIdCamp(int monsterId, int camp)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.FindMonsterByIDAndCamp(list, monsterId, camp);
		int count = list.Count;
		ListPool<BeActor>.Release(list);
		return count;
	}

	// Token: 0x06017282 RID: 94850 RVA: 0x0071D568 File Offset: 0x0071B968
	public int GetMonsterCount()
	{
		int num = 0;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				BeActor beActor = this.mEntitys[i] as BeActor;
				if (beActor.IsMonster())
				{
					num++;
				}
			}
		}
		for (int j = 0; j < this.mPendingArray.Count; j++)
		{
			if (this.mPendingArray[j] is BeActor && !this.mPendingArray[j].IsDead())
			{
				BeActor beActor2 = this.mPendingArray[j] as BeActor;
				if (beActor2.IsMonster())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06017283 RID: 94851 RVA: 0x0071D658 File Offset: 0x0071BA58
	public BeEntity GetEntityByPID(int pid)
	{
		BeEntity result = null;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null && beEntity.m_iID == pid)
			{
				return beEntity;
			}
		}
		return result;
	}

	// Token: 0x06017284 RID: 94852 RVA: 0x0071D6A8 File Offset: 0x0071BAA8
	public BeEntity GetEntityByResId(int resId, BeActor owner = null)
	{
		BeEntity result = null;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (owner == null || beEntity.GetOwner() == null || beEntity.GetOwner() == owner)
			{
				if (beEntity != null && !beEntity.IsDead() && beEntity.m_iResID == resId)
				{
					return beEntity;
				}
			}
		}
		return result;
	}

	// Token: 0x06017285 RID: 94853 RVA: 0x0071D724 File Offset: 0x0071BB24
	public void GetEntitysByResId(List<BeEntity> entitys, int resId)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null && !beEntity.IsDead() && beEntity.m_iResID == resId)
			{
				entitys.Add(beEntity);
			}
		}
	}

	// Token: 0x06017286 RID: 94854 RVA: 0x0071D780 File Offset: 0x0071BB80
	public bool FindMonsterByID(List<BeActor> monsters, int mid, bool isEnemy = true)
	{
		if (monsters == null || mid == 0)
		{
			return false;
		}
		monsters.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				BeActor beActor = this.mEntitys[i] as BeActor;
				if (isEnemy)
				{
					if (beActor.IsMonster() && (beActor.GetEntityData().MonsterIDEqual(mid) || mid == 0))
					{
						monsters.Add(beActor);
					}
				}
				else if (beActor.attribute != null && beActor.attribute.isMonster && beActor.GetCamp() == 0 && (beActor.GetEntityData().MonsterIDEqual(mid) || mid == 0))
				{
					monsters.Add(beActor);
				}
			}
		}
		return true;
	}

	// Token: 0x06017287 RID: 94855 RVA: 0x0071D87C File Offset: 0x0071BC7C
	public bool FindMonsterByIDAndCamp(List<BeActor> monsters, int mid, int camp)
	{
		if (monsters == null || mid == 0)
		{
			return false;
		}
		monsters.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				BeActor beActor = this.mEntitys[i] as BeActor;
				if (beActor.GetCamp() == camp && (beActor.GetEntityData().MonsterIDEqual(mid) || mid == 0))
				{
					monsters.Add(beActor);
				}
			}
		}
		return true;
	}

	// Token: 0x06017288 RID: 94856 RVA: 0x0071D928 File Offset: 0x0071BD28
	public void FindAllMonsters(List<BeActor> targets, BeActor attacker, bool friend = false, IEntityFilter filter = null)
	{
		int num = -1;
		targets.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor)
			{
				if (!this.mEntitys[i].IsDead())
				{
					if (friend || (attacker != this.mEntitys[i] && this.mEntitys[i].m_iCamp != attacker.m_iCamp))
					{
						if (!friend || this.mEntitys[i].m_iCamp == attacker.m_iCamp)
						{
							if (!(this.mEntitys[i] as BeActor).IsSkillMonster())
							{
								if (this.mEntitys[i].stateController.CanBeTargeted())
								{
									if (num == -1)
									{
										num = i;
									}
									if (filter == null || filter.isFit(this.mEntitys[i]))
									{
										targets.Add(this.mEntitys[i] as BeActor);
									}
								}
							}
						}
					}
				}
			}
		}
		if (filter != null && filter.isUseDefault() && num >= 0 && targets.Count <= 0 && filter != null && num < this.mEntitys.Count)
		{
			targets.Add(this.mEntitys[num] as BeActor);
		}
	}

	// Token: 0x06017289 RID: 94857 RVA: 0x0071DAC4 File Offset: 0x0071BEC4
	public BeActor FindMonsterByID(int mid)
	{
		if (mid == 0)
		{
			return null;
		}
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				BeActor beActor = this.mEntitys[i] as BeActor;
				if (beActor.attribute != null && beActor.attribute.isMonster && beActor.GetEntityData().MonsterIDEqual(mid))
				{
					return beActor;
				}
			}
		}
		return null;
	}

	// Token: 0x0601728A RID: 94858 RVA: 0x0071DB68 File Offset: 0x0071BF68
	public bool FindMainActor(List<BeActor> list)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		List<BattlePlayer> allPlayers = this.mBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !playerActor.IsDead())
			{
				if (playerActor.isMainActor)
				{
					list.Add(playerActor);
				}
			}
		}
		return true;
	}

	// Token: 0x0601728B RID: 94859 RVA: 0x0071DBE4 File Offset: 0x0071BFE4
	public BeActor FindNearestRangeTarget(VInt3 pos, BeActor attacker, VInt radius, List<BeActor> inList = null)
	{
		BeActor result = null;
		int num = int.MaxValue;
		VInt2 a = new VInt2(pos.x, pos.y);
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				if (attacker != this.mEntitys[i] && this.mEntitys[i].m_iCamp != attacker.m_iCamp)
				{
					if (!(this.mEntitys[i] as BeActor).IsSkillMonster())
					{
						if (this.mEntitys[i].stateController.CanBeTargeted())
						{
							if (inList == null || !inList.Contains(this.mEntitys[i] as BeActor))
							{
								VInt3 position = this.mEntitys[i].GetPosition();
								VInt2 b = new VInt2(position.x, position.y);
								int magnitude = (a - b).magnitude;
								if (magnitude <= radius && magnitude < num)
								{
									result = (this.mEntitys[i] as BeActor);
									num = magnitude;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0601728C RID: 94860 RVA: 0x0071DD62 File Offset: 0x0071C162
	public bool FindTargets(List<BeActor> targets, BeActor attacker, VInt radius, bool friend = false, IEntityFilter filter = null)
	{
		return targets != null && this.FindTargetsByEntity(targets, attacker, radius, friend, filter);
	}

	// Token: 0x0601728D RID: 94861 RVA: 0x0071DD7C File Offset: 0x0071C17C
	public bool FindTargetsByEntity(List<BeActor> targets, BeEntity attacker, VInt radius, bool friend = false, IEntityFilter filter = null)
	{
		targets.Clear();
		if (attacker == null || attacker.IsDead())
		{
			return false;
		}
		VInt3 position = attacker.GetPosition();
		VInt2 a = new VInt2(position.x, position.y);
		int num = -1;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor)
			{
				if (!this.mEntitys[i].IsDead())
				{
					if (friend || (attacker != this.mEntitys[i] && this.mEntitys[i].m_iCamp != attacker.m_iCamp))
					{
						if (!friend || this.mEntitys[i].m_iCamp == attacker.m_iCamp)
						{
							if (!(this.mEntitys[i] as BeActor).IsSkillMonster())
							{
								if (this.mEntitys[i].stateController.CanBeTargeted())
								{
									VInt3 position2 = this.mEntitys[i].GetPosition();
									VInt2 b = new VInt2(position2.x, position2.y);
									int magnitude = (a - b).magnitude;
									if (magnitude <= radius)
									{
										if (num == -1)
										{
											num = i;
										}
										if (filter == null || filter.isFit(this.mEntitys[i]))
										{
											targets.Add(this.mEntitys[i] as BeActor);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if (filter != null && filter.isUseDefault() && num >= 0 && targets.Count <= 0 && filter != null && num < this.mEntitys.Count)
		{
			targets.Add(this.mEntitys[num] as BeActor);
		}
		return true;
	}

	// Token: 0x0601728E RID: 94862 RVA: 0x0071DF98 File Offset: 0x0071C398
	public List<BeActor> GetFilterTarget(List<BeActor> targets, IEntityFilter filter = null, bool judgeDead = true)
	{
		targets.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null)
			{
				if (!judgeDead || !beActor.IsDead())
				{
					if (filter != null && filter.isFit(beActor))
					{
						targets.Add(beActor);
					}
				}
			}
		}
		for (int j = 0; j < this.mPendingArray.Count; j++)
		{
			BeActor beActor2 = this.mPendingArray[j] as BeActor;
			if (beActor2 != null)
			{
				if (!judgeDead || !beActor2.IsDead())
				{
					if (filter != null && filter.isFit(beActor2))
					{
						targets.Add(beActor2);
					}
				}
			}
		}
		return targets;
	}

	// Token: 0x0601728F RID: 94863 RVA: 0x0071E07C File Offset: 0x0071C47C
	public BeActor FindTarget(BeActor attacker, VInt radius)
	{
		if (attacker == null || attacker.IsDead())
		{
			return null;
		}
		VInt3 position = attacker.GetPosition();
		VInt2 a = new VInt2(position.x, position.y);
		BeActor result = null;
		int num = int.MaxValue;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && attacker != this.mEntitys[i] && !this.mEntitys[i].IsDead() && this.mEntitys[i].m_iCamp != attacker.m_iCamp)
			{
				if (this.mEntitys[i].stateController.CanBeTargeted())
				{
					VInt3 position2 = this.mEntitys[i].GetPosition();
					VInt2 b = new VInt2(position2.x, position2.y);
					int magnitude = (a - b).magnitude;
					if (magnitude <= radius && magnitude < num)
					{
						BeActor beActor = this.mEntitys[i] as BeActor;
						if (!beActor.IsSkillMonster())
						{
							num = magnitude;
							result = beActor;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06017290 RID: 94864 RVA: 0x0071E1E4 File Offset: 0x0071C5E4
	public bool FindFaceTargetsX(List<BeActor> targets, BeActor attacker, VInt xDis)
	{
		targets.Clear();
		if (attacker == null || attacker.IsDead())
		{
			return false;
		}
		VInt3 position = attacker.GetPosition();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null)
			{
				if (!beActor.IsDead())
				{
					if (attacker != beActor && beActor.m_iCamp != attacker.m_iCamp)
					{
						if (!beActor.IsSkillMonster())
						{
							if (beActor.stateController.CanBeTargeted())
							{
								VInt3 position2 = beActor.GetPosition();
								if (attacker.GetFace() && position.x - position2.x >= 0 && position.x - position2.x <= xDis)
								{
									targets.Add(beActor);
								}
								else if (!attacker.GetFace() && position2.x - position.x >= 0 && position2.x - position.x <= xDis)
								{
									targets.Add(beActor);
								}
							}
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06017291 RID: 94865 RVA: 0x0071E338 File Offset: 0x0071C738
	public bool FindSummonMonster(List<BeActor> summonList, BeEntity owner)
	{
		if (summonList == null)
		{
			return false;
		}
		summonList.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor)
			{
				if (!this.mEntitys[i].IsDead())
				{
					if (this.mEntitys[i] != owner)
					{
						if (this.mEntitys[i].GetOwner() != null && this.mEntitys[i].GetOwner() == owner)
						{
							summonList.Add((BeActor)this.mEntitys[i]);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06017292 RID: 94866 RVA: 0x0071E408 File Offset: 0x0071C808
	public BeActor FindNearestFacedTarget(BeActor attacker, VInt2 distance)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 position = attacker.GetPosition();
		VInt2 vint = new VInt2(position.x, position.y);
		DBox dbox = default(DBox);
		if (attacker.GetFace())
		{
			dbox._min.x = vint.x - distance.x;
			dbox._max.x = vint.x;
		}
		else
		{
			dbox._min.x = vint.x;
			dbox._max.x = vint.x + distance.x;
		}
		dbox._min.y = vint.y - distance.y;
		dbox._max.y = vint.y + distance.y;
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && beActor != attacker && !beActor.IsDead() && beActor.m_iCamp != attacker.m_iCamp && !beActor.IsSkillMonster())
			{
				VInt2 vint2 = new VInt2(beActor.GetPosition().x, beActor.GetPosition().y);
				if (beActor.stateController.CanBeTargeted())
				{
					if (dbox.containPoint(ref vint2))
					{
						list.Add(beActor);
					}
				}
			}
		}
		BeActor result = null;
		int num = int.MaxValue;
		for (int j = 0; j < list.Count; j++)
		{
			int num2 = Mathf.Abs(list[j].GetPosition().x - attacker.GetPosition().x);
			if (num2 < num)
			{
				num = num2;
				result = list[j];
			}
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017293 RID: 94867 RVA: 0x0071E614 File Offset: 0x0071CA14
	public BeActor FindTargetByPriority(BeActor attacker, VInt radius)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		BeActor beActor = null;
		this.FindTargets(list, attacker, radius, false, null);
		if (list != null && list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (beActor == null)
				{
					beActor = list[i];
				}
				else
				{
					TargetPriority prioritty = this.GetPrioritty(beActor);
					TargetPriority prioritty2 = this.GetPrioritty(list[i]);
					if (prioritty2 > prioritty)
					{
						beActor = list[i];
					}
					else if (prioritty2 == prioritty)
					{
						int distance = beActor.GetDistance(attacker);
						int distance2 = list[i].GetDistance(attacker);
						if (distance2 < distance)
						{
							beActor = list[i];
						}
					}
				}
			}
		}
		ListPool<BeActor>.Release(list);
		return beActor;
	}

	// Token: 0x06017294 RID: 94868 RVA: 0x0071E6D8 File Offset: 0x0071CAD8
	protected TargetPriority GetPrioritty(BeActor actor)
	{
		if (!actor.IsMonster())
		{
			return TargetPriority.Player;
		}
		if (actor.IsBoss())
		{
			return TargetPriority.Boss;
		}
		if (actor.GetEntityData().monsterData.Type == UnitTable.eType.ELITE || actor.GetEntityData().monsterData.Type == UnitTable.eType.HELL)
		{
			return TargetPriority.Elite;
		}
		return TargetPriority.Normal;
	}

	// Token: 0x06017295 RID: 94869 RVA: 0x0071E730 File Offset: 0x0071CB30
	public BeActor GetResentmentActor(bool high = true)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.FindMainActor(list);
		if (list.Count == 0)
		{
			ListPool<BeActor>.Release(list);
			return null;
		}
		this.SortResentmentList(list);
		BeActor result = (!high) ? list[list.Count - 1] : list[0];
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017296 RID: 94870 RVA: 0x0071E78D File Offset: 0x0071CB8D
	public void SortResentmentList(List<BeActor> list)
	{
		list.Sort(delegate(BeActor a, BeActor b)
		{
			Mechanism2004 mechanism = a.GetMechanism(5300) as Mechanism2004;
			Mechanism2004 mechanism2 = a.GetMechanism(5300) as Mechanism2004;
			if (mechanism != null && mechanism2 != null)
			{
				if (mechanism.IsBetray() && !mechanism2.IsBetray())
				{
					return -1;
				}
				if (!mechanism.IsBetray() && mechanism2.IsBetray())
				{
					return 1;
				}
				int resentmentValue = mechanism.GetResentmentValue();
				int resentmentValue2 = mechanism2.GetResentmentValue();
				if (resentmentValue > resentmentValue2)
				{
					return -1;
				}
				if (resentmentValue < resentmentValue2)
				{
					return 1;
				}
				if (resentmentValue == resentmentValue2)
				{
					return a.GetPID().CompareTo(b.GetPID());
				}
			}
			return a.GetPID().CompareTo(b.GetPID());
		});
	}

	// Token: 0x06017297 RID: 94871 RVA: 0x0071E7B4 File Offset: 0x0071CBB4
	public bool FindFaceTargets(List<BeEntity> targets, BeActor attacker, VInt2 distance, VFactor yReduceFactor, VInt xReduce)
	{
		if (targets == null)
		{
			return false;
		}
		targets.Clear();
		VInt3 position = attacker.GetPosition();
		VInt2 vint = new VInt2(position.x, position.y);
		DBox dbox = default(DBox);
		if (attacker.GetFace())
		{
			dbox._min.x = vint.x - distance.x;
			dbox._max.x = vint.x + xReduce.i;
		}
		else
		{
			dbox._min.x = vint.x - xReduce.i;
			dbox._max.x = vint.x + distance.x;
		}
		dbox._min.y = vint.y - distance.y;
		dbox._max.y = vint.y + distance.y * (VFactor.one - yReduceFactor);
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			BeObject beObject = this.mEntitys[i] as BeObject;
			if (this.mEntitys[i] is BeObject || (this.mEntitys[i] is BeActor && beActor != attacker && !beActor.IsDead() && beActor.m_iCamp != attacker.m_iCamp && !(this.mEntitys[i] as BeActor).IsSkillMonster()))
			{
				VInt2 vint2 = new VInt2(this.mEntitys[i].GetPosition().x, this.mEntitys[i].GetPosition().y);
				if (this.mEntitys[i].stateController.CanBeTargeted())
				{
					if (dbox.containPoint(ref vint2))
					{
						targets.Add(this.mEntitys[i]);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06017298 RID: 94872 RVA: 0x0071E9E4 File Offset: 0x0071CDE4
	public bool IsEnemyClear(BeActor attacker)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && beActor != attacker && !beActor.IsDead() && beActor.m_iCamp != attacker.m_iCamp)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017299 RID: 94873 RVA: 0x0071EA4C File Offset: 0x0071CE4C
	public bool FindActorInRange(List<BeActor> list, VInt3 pos, VInt radius, int camp = -1, int monsterID = 0)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null)
			{
				VInt a = (pos - beActor.GetPosition()).magnitude;
				if (beActor != null && !beActor.IsDead() && a <= radius && beActor.stateController.CanBeTargeted())
				{
					if (camp <= -1 || beActor.GetCamp() == camp)
					{
						if (monsterID != 0 && BeUtility.IsMonsterIDEqual(monsterID, beActor.GetEntityData().simpleMonsterID))
						{
							list.Add(beActor);
						}
						else if (monsterID == 0 && !beActor.IsSkillMonster())
						{
							list.Add(beActor);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601729A RID: 94874 RVA: 0x0071EB48 File Offset: 0x0071CF48
	public bool FindMainActorInRange(List<BeActor> list, VInt3 pos, VInt radius)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		List<BattlePlayer> allPlayers = this.mBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !playerActor.IsDead())
			{
				VInt a = (pos - playerActor.GetPosition()).magnitude;
				if (playerActor != null && !playerActor.IsDead() && a <= radius && playerActor.isMainActor)
				{
					list.Add(playerActor);
				}
			}
		}
		return true;
	}

	// Token: 0x0601729B RID: 94875 RVA: 0x0071EBFC File Offset: 0x0071CFFC
	public void FindTargets(List<BeActor> list, BeActor attacker, bool isFriend, IEntityFilter filter)
	{
		if (list == null || filter == null)
		{
			return;
		}
		list.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null)
			{
				if (isFriend || (attacker != this.mEntitys[i] && this.mEntitys[i].m_iCamp != attacker.m_iCamp))
				{
					if (!isFriend || this.mEntitys[i].m_iCamp == attacker.m_iCamp)
					{
						if (!(this.mEntitys[i] as BeActor).IsSkillMonster())
						{
							if (this.mEntitys[i].stateController.CanBeTargeted())
							{
								if (filter.isFit(beActor))
								{
									list.Add(beActor);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601729C RID: 94876 RVA: 0x0071ED0C File Offset: 0x0071D10C
	public bool FindActorById(List<BeActor> list, int monsterID)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && monsterID != 0 && BeUtility.IsMonsterIDEqual(monsterID, beActor.GetEntityData().simpleMonsterID))
			{
				list.Add(beActor);
			}
		}
		return true;
	}

	// Token: 0x0601729D RID: 94877 RVA: 0x0071ED8C File Offset: 0x0071D18C
	public bool FindActorById2(List<BeActor> list, int monsterID, bool canBeTarget = false)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && monsterID != 0 && BeUtility.IsMonsterIDEqual(monsterID, beActor.GetEntityData().simpleMonsterID))
			{
				if (canBeTarget)
				{
					if (beActor.stateController != null && beActor.stateController.CanBeTargeted())
					{
						list.Add(beActor);
					}
				}
				else
				{
					list.Add(beActor);
				}
			}
		}
		if (this.mPendingArray.Count > 0)
		{
			for (int j = 0; j < this.mPendingArray.Count; j++)
			{
				BeActor beActor2 = this.mPendingArray[j] as BeActor;
				if (beActor2 != null && !beActor2.IsDead() && monsterID != 0 && BeUtility.IsMonsterIDEqual(monsterID, beActor2.GetEntityData().simpleMonsterID))
				{
					if (canBeTarget)
					{
						if (beActor2.stateController != null && beActor2.stateController.CanBeTargeted())
						{
							list.Add(beActor2);
						}
					}
					else
					{
						list.Add(beActor2);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601729E RID: 94878 RVA: 0x0071EED8 File Offset: 0x0071D2D8
	public bool CheckMonsterAlive(int monsterId)
	{
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && monsterId != 0 && BeUtility.IsMonsterIDEqual(monsterId, beActor.GetEntityData().simpleMonsterID))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601729F RID: 94879 RVA: 0x0071EF44 File Offset: 0x0071D344
	public VInt3 GetLogicPosInRange(BeActor actor, int radius)
	{
		VInt3 position = actor.GetPosition();
		int x = this.FrameRandom.InRange(position.x - radius, position.x + radius);
		int y = this.FrameRandom.InRange(position.y - radius, position.y + radius);
		return new VInt3(x, y, position.z);
	}

	// Token: 0x060172A0 RID: 94880 RVA: 0x0071EFA4 File Offset: 0x0071D3A4
	public VInt3 GetRandomPos(int searchCount = 10)
	{
		VInt3 vint = VInt3.zero;
		int num = 0;
		DGrid grid = default(DGrid);
		DGrid dgrid = this.CalGridByPosition(new VInt3(this.logicXSize.x, this.logicZSize.x, 0));
		DGrid dgrid2 = this.CalGridByPosition(new VInt3(this.logicXSize.y, this.logicZSize.y, 0));
		do
		{
			num++;
			int x = this.FrameRandom.InRange(dgrid.x, dgrid2.x);
			int y = this.FrameRandom.InRange(dgrid.y, dgrid2.y);
			grid = new DGrid(x, y);
			vint = this.CalPositionByGrid(grid);
			if (!this.IsInBlockPlayer(vint))
			{
				break;
			}
		}
		while (num < searchCount);
		return vint;
	}

	// Token: 0x060172A1 RID: 94881 RVA: 0x0071F070 File Offset: 0x0071D470
	public VInt3 GetPosInXAxis(BeActor target, int searchCount = 10)
	{
		VInt3 position = target.GetPosition();
		int num = 0;
		do
		{
			num++;
			int num2 = (num % 2 != 0) ? 1 : -1;
			position.x += num2 * num * GlobalLogic.VALUE_10000;
			if (!this.IsInBlockPlayer(position))
			{
				break;
			}
		}
		while (num < searchCount);
		return position;
	}

	// Token: 0x060172A2 RID: 94882 RVA: 0x0071F0CC File Offset: 0x0071D4CC
	public bool FindBoss(List<BeActor> list)
	{
		if (list == null)
		{
			return false;
		}
		list.Clear();
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeActor beActor = this.mEntitys[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && beActor.IsBoss())
			{
				list.Add(beActor);
			}
		}
		return true;
	}

	// Token: 0x060172A3 RID: 94883 RVA: 0x0071F139 File Offset: 0x0071D539
	public void PauseLogic()
	{
		if (base.state == BeSceneState.onPause)
		{
			return;
		}
		this.mPrePauseState = base.state;
		base.state = BeSceneState.onPause;
		if (this.mCurrentGeScene != null)
		{
			this.mCurrentGeScene.PauseLogic();
		}
	}

	// Token: 0x060172A4 RID: 94884 RVA: 0x0071F171 File Offset: 0x0071D571
	public void ResumeLogic()
	{
		base.state = this.mPrePauseState;
		this.mPrePauseState = BeSceneState.onNone;
		if (this.mCurrentGeScene != null)
		{
			this.mCurrentGeScene.ResumeLogic();
		}
	}

	// Token: 0x060172A5 RID: 94885 RVA: 0x0071F19C File Offset: 0x0071D59C
	public void Pause(bool pauseAnimation = true)
	{
		if (!pauseAnimation)
		{
			return;
		}
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (beEntity != null && !beEntity.IsPause() && beEntity.m_pkGeActor != null)
			{
				beEntity.m_pkGeActor.Pause(63, true);
			}
		}
		if (this.currentGeScene != null)
		{
			GeEffectManager effectManager = this.currentGeScene.GetEffectManager();
			if (effectManager != null)
			{
				effectManager.Pause(GeEffectType.EffectUnique);
				effectManager.Pause(GeEffectType.EffectMultiple);
				effectManager.Pause(GeEffectType.EffectGlobal);
			}
		}
	}

	// Token: 0x060172A6 RID: 94886 RVA: 0x0071F238 File Offset: 0x0071D638
	public void Resume(bool pauseAnimation = true)
	{
		if (!pauseAnimation)
		{
			return;
		}
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			BeEntity beEntity = this.mEntitys[i];
			if (!beEntity.IsPause())
			{
				beEntity.m_pkGeActor.Resume(63);
			}
		}
		GeEffectManager effectManager = this.currentGeScene.GetEffectManager();
		if (effectManager != null)
		{
			effectManager.Resume(GeEffectType.EffectUnique);
			effectManager.Resume(GeEffectType.EffectMultiple);
			effectManager.Resume(GeEffectType.EffectGlobal);
		}
	}

	// Token: 0x060172A7 RID: 94887 RVA: 0x0071F2B4 File Offset: 0x0071D6B4
	public bool HavePlayerUseAwakeSkill()
	{
		if (this.mBattle == null)
		{
			return false;
		}
		if (this.mBattle.dungeonPlayerManager == null)
		{
			return false;
		}
		List<BattlePlayer> allPlayers = this.mBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor != null)
			{
				if (allPlayers[i].playerActor.IsCastingSkill())
				{
					BeSkill curSkill = allPlayers[i].playerActor.GetCurSkill();
					if (curSkill != null && curSkill.skillData != null && curSkill.skillData.SkillCategory == 4)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x04010A75 RID: 68213
	protected ISceneData mSceneData;

	// Token: 0x04010A76 RID: 68214
	public int logicWidth;

	// Token: 0x04010A77 RID: 68215
	public int logicHeight;

	// Token: 0x04010A78 RID: 68216
	public VInt2 logicZSize;

	// Token: 0x04010A79 RID: 68217
	public VInt2 logicXSize;

	// Token: 0x04010A7A RID: 68218
	public VInt2 logicGrild;

	// Token: 0x04010A7B RID: 68219
	public byte[] mBlockInfo;

	// Token: 0x04010A7C RID: 68220
	private bool mIsBossScene;

	// Token: 0x04010A7D RID: 68221
	private bool mIsDoorOpened;

	// Token: 0x04010A7E RID: 68222
	private bool isTraceDoor = true;

	// Token: 0x04010A7F RID: 68223
	public bool isUseBossShow = true;

	// Token: 0x04010A80 RID: 68224
	protected List<BeEntity> mEntitys = new List<BeEntity>();

	// Token: 0x04010A81 RID: 68225
	protected List<BeEntity> mPendingArray = new List<BeEntity>();

	// Token: 0x04010A82 RID: 68226
	protected List<BeEntity> mDeadBody = new List<BeEntity>();

	// Token: 0x04010A83 RID: 68227
	protected List<BeEntity> mTempSaveEntitys = new List<BeEntity>();

	// Token: 0x04010A84 RID: 68228
	protected List<BeRegionBase> mRegions = new List<BeRegionBase>();

	// Token: 0x04010A85 RID: 68229
	protected List<BeRegionBase> mPendingRegion = new List<BeRegionBase>();

	// Token: 0x04010A86 RID: 68230
	private List<BeRegionBase> mDoorList = new List<BeRegionBase>();

	// Token: 0x04010A87 RID: 68231
	protected DelayCaller mDelayCaller = new DelayCaller();

	// Token: 0x04010A88 RID: 68232
	protected BeEventProcessor mProcessor = new BeEventProcessor();

	// Token: 0x04010A89 RID: 68233
	protected GeSceneEx mCurrentGeScene;

	// Token: 0x04010A8A RID: 68234
	protected List<GeActorEx> mDecoratorList = new List<GeActorEx>();

	// Token: 0x04010A8B RID: 68235
	protected bool mIsTickAI = true;

	// Token: 0x04010A8C RID: 68236
	protected IList<int> taskMonsters;

	// Token: 0x04010A8D RID: 68237
	protected BeRegionBase traceDoor;

	// Token: 0x04010A8E RID: 68238
	protected VInt3 traceDoorPos = VInt3.zero;

	// Token: 0x04010A8F RID: 68239
	private bool isBlind;

	// Token: 0x04010A90 RID: 68240
	private bool bossDead;

	// Token: 0x04010A91 RID: 68241
	protected bool isBattleDataError;

	// Token: 0x04010A92 RID: 68242
	protected int checkBattleDataErrorAcc;

	// Token: 0x04010A93 RID: 68243
	private SimpleTimer2 simpleTimer = new SimpleTimer2();

	// Token: 0x04010A94 RID: 68244
	public SimpleTimer pkTimer;

	// Token: 0x04010A95 RID: 68245
	protected BeEventManager m_EventManager;

	// Token: 0x04010A98 RID: 68248
	protected int mDurtime;

	// Token: 0x04010A99 RID: 68249
	private int mCurTransportTimerID;

	// Token: 0x04010A9A RID: 68250
	private double bossDeadTimeStamp = -1.0;

	// Token: 0x04010A9B RID: 68251
	protected int sID;

	// Token: 0x04010A9C RID: 68252
	private bool mIsDayTime;

	// Token: 0x04010A9D RID: 68253
	private List<BattlePlayer> defaultTargetList;

	// Token: 0x04010A9E RID: 68254
	private bool isBossDeaded;

	// Token: 0x04010A9F RID: 68255
	private int checkMosnterClearInterval = GlobalLogic.VALUE_1000;

	// Token: 0x04010AA0 RID: 68256
	private int checkAcc;

	// Token: 0x04010AA1 RID: 68257
	private bool mCheckMonsterDirtyFlag;

	// Token: 0x04010AA2 RID: 68258
	private Vec3 mgeDeadBossPositionGE = Vec3.zero;

	// Token: 0x04010AA3 RID: 68259
	private BeObject mHell;

	// Token: 0x04010AA4 RID: 68260
	protected static readonly byte[] DEFAULT_BLOCK_DATA = new byte[]
	{
		1
	};

	// Token: 0x04010AA5 RID: 68261
	private int arrowAcc;

	// Token: 0x04010AA6 RID: 68262
	private int arrowUpdateInterval = 1000;

	// Token: 0x04010AA7 RID: 68263
	private BeSceneState mPrePauseState;

	// Token: 0x020041B4 RID: 16820
	private enum PrefixType
	{
		// Token: 0x04010AB2 RID: 68274
		LOW,
		// Token: 0x04010AB3 RID: 68275
		HIGH
	}
}
