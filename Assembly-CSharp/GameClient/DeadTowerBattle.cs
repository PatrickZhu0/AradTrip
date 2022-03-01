using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020045B0 RID: 17840
	public class DeadTowerBattle : ActivityBattle
	{
		// Token: 0x06018F7C RID: 102268 RVA: 0x007DAD61 File Offset: 0x007D9161
		public DeadTowerBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
			this.mHasSendRaceEnd = false;
		}

		// Token: 0x06018F7D RID: 102269 RVA: 0x007DAD8C File Offset: 0x007D918C
		private void _sendRaceEnd()
		{
			if (base._isNeedSendNet() && !this.mHasSendRaceEnd)
			{
				this.mHasSendRaceEnd = true;
				SceneDungeonRaceEndReq cmd = base._getDungeonRaceEndReqWithCount(5);
				MonoSingleton<NetManager>.instance.SendCommand<SceneDungeonRaceEndReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x06018F7E RID: 102270 RVA: 0x007DADCC File Offset: 0x007D91CC
		private void SetFloorName()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetFloor(this.currentIndex + 1);
			}
		}

		// Token: 0x06018F7F RID: 102271 RVA: 0x007DAE00 File Offset: 0x007D9200
		private void SetPlayer(bool recover = false)
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				if (battlePlayer != null && battlePlayer.playerActor != null)
				{
					BeActor playerActor = battlePlayer.playerActor;
					if (recover)
					{
						playerActor.attribute.PostInit(null);
						playerActor.m_pkGeActor.ResetHPBar();
						playerActor.ResetSkillCoolDown();
					}
					playerActor.buffController.RemoveDebuff(base.FunctionIsOpen(BattleFlagType.DeadTownerRemoveBuff));
				}
			}
		}

		// Token: 0x06018F80 RID: 102272 RVA: 0x007DAE8F File Offset: 0x007D928F
		protected override void _onCreateScene(object[] args)
		{
			this.SetFloorName();
			this.SetPlayer(false);
		}

		// Token: 0x06018F81 RID: 102273 RVA: 0x007DAEA0 File Offset: 0x007D92A0
		private RelaySvrDungeonRaceEndReq _LogicServerRaceEnd(int count)
		{
			if (this.mDungeonPlayers == null)
			{
				return null;
			}
			RelaySvrDungeonRaceEndReq relaySvrDungeonRaceEndReq = new RelaySvrDungeonRaceEndReq();
			relaySvrDungeonRaceEndReq.raceEndInfo.sessionId = ((base.recordServer == null) ? 0UL : Convert.ToUInt64(base.recordServer.sessionID));
			relaySvrDungeonRaceEndReq.raceEndInfo.dungeonId = (uint)this.mDungeonManager.GetDungeonDataManager().id.dungeonID;
			relaySvrDungeonRaceEndReq.raceEndInfo.usedTime = (uint)this.mDungeonStatistics.LastFightTimeWithCount(true, count);
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

		// Token: 0x06018F82 RID: 102274 RVA: 0x007DB00A File Offset: 0x007D940A
		private void _showCurrentTips()
		{
			SystemNotifyManager.SysDungeonAnimation(string.Format("{0} <color=#ffca14>{1}</color> 层", this.mDungeonManager.GetDungeonDataManager().table.Name, this.currentIndex + 1), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x06018F83 RID: 102275 RVA: 0x007DB040 File Offset: 0x007D9440
		protected override void _onPostStart()
		{
			base._onPostStart();
			this._showCurrentTips();
			this.SetFloorName();
			TalkTable tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(this.mDialogIDArray[this.currentIndex], string.Empty, string.Empty);
			if (tableItem != null)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					if (base.GetMode() != eDungeonMode.SyncFrame)
					{
						this.mDungeonManager.PauseFight(false, string.Empty, false);
						this.AddDialog(this.mDialogIDArray[this.currentIndex], delegate
						{
							this.mDungeonManager.ResumeFight(false, string.Empty, false);
						});
					}
				}, 0, 0, false);
			}
		}

		// Token: 0x06018F84 RID: 102276 RVA: 0x007DB0AC File Offset: 0x007D94AC
		protected override void _onAreaClear(object[] arg)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.mIsPlayerDeadProcessing)
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			if (allPlayers != null)
			{
				for (int i = 0; i < allPlayers.Count; i++)
				{
					BattlePlayer battlePlayer = allPlayers[i];
					if (battlePlayer.playerActor != null)
					{
						battlePlayer.playerActor.buffController.TryAddBuff(38, -1, 1);
						battlePlayer.playerActor.buffController.RemoveDebuff(base.FunctionIsOpen(BattleFlagType.DeadTownerRemoveBuff));
					}
				}
			}
			if (!this.mIsProcessAreaClear)
			{
				this.mIsProcessAreaClear = true;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._processAreaClear());
			}
		}

		// Token: 0x06018F85 RID: 102277 RVA: 0x007DB174 File Offset: 0x007D9574
		private IEnumerator _processAreaClear()
		{
			yield return base._sendDungeonReportDataIter(false);
			this.mIsProcessAreaClear = false;
			if (this.mDungeonManager != null && this.mDungeonPlayers != null)
			{
				BeScene beScene = this.mDungeonManager.GetBeScene();
				BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
				if (beScene != null && mainPlayer != null)
				{
					beScene.ForcePickUpDropItem(mainPlayer.playerActor);
				}
				this._sendDungeonClearAreaMonstersReq();
				if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._openDeadTowerFinishFrame());
					this._fireSceneChangeAreaCmd();
				}
				else if (this._isNeedCalculateDrop())
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._openDeadTowerFinishFrame());
				}
				else
				{
					ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
					if (clientSystemBattle != null)
					{
						clientSystemBattle.HidePauseButton(true);
					}
					SystemNotifyManager.SysDungeonAnimation2("怪物已清除,即将进入下一层.", CommonTipsDesc.eShowMode.SI_UNIQUE);
					MonoSingleton<AudioManager>.instance.PlaySound(5);
					Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(2000, delegate
					{
						TalkTable tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(this.mDialogIDAfterArray[this.currentIndex], string.Empty, string.Empty);
						if (tableItem != null)
						{
							this.AddDialog(this.mDialogIDAfterArray[this.currentIndex], delegate
							{
								this._fireSceneChangeAreaCmd();
							});
						}
						else
						{
							this._fireSceneChangeAreaCmd();
						}
					}, 0, 0, false);
				}
			}
			yield break;
		}

		// Token: 0x06018F86 RID: 102278 RVA: 0x007DB190 File Offset: 0x007D9590
		private void _fireSceneChangeAreaCmd()
		{
			SceneChangeArea cmd = new SceneChangeArea();
			FrameSync.instance.FireFrameCommand(cmd, false);
		}

		// Token: 0x06018F87 RID: 102279 RVA: 0x007DB1B0 File Offset: 0x007D95B0
		protected override void _onSceneAreaChange()
		{
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this.mDungeonManager.FinishFight();
				base._resetPlayerActor(false);
			}
			else
			{
				if (this._isNeedCalculateDrop())
				{
					if (this.mDungeonManager.GetBeScene() != null)
					{
						this.mDungeonManager.GetBeScene().TriggerEvent(BeEventSceneType.onDeadTowerPassFiveLayer, null);
					}
					this.SetPlayer(true);
				}
				else
				{
					List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
					for (int i = 0; i < allPlayers.Count; i++)
					{
						if (allPlayers[i].playerActor != null)
						{
							allPlayers[i].playerActor.buffController.TryAddBuff(35, 2000, 1);
							allPlayers[i].playerActor.TriggerEvent(BeEventType.onDeadTowerEnterNextLayer, null);
						}
					}
				}
				this._changeAreaByIdx();
			}
		}

		// Token: 0x06018F88 RID: 102280 RVA: 0x007DB298 File Offset: 0x007D9698
		protected override void _createPlayers()
		{
			base._createPlayers();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				allPlayers[i].playerActor.SetPosition(dungeonDataManager.CurrentBirthPosition(), false, true, false);
			}
			this.mDungeonManager.GetBeScene().InitFriendActor(dungeonDataManager.CurrentBirthPosition());
		}

		// Token: 0x06018F89 RID: 102281 RVA: 0x007DB30C File Offset: 0x007D970C
		protected override void _onPlayerDead(BattlePlayer player)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			this.mIsPlayerDeadProcessing = true;
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (player == mainPlayer)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onDeadProcess());
			}
		}

		// Token: 0x06018F8A RID: 102282 RVA: 0x007DB360 File Offset: 0x007D9760
		private IEnumerator _onDeadProcess()
		{
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
			this._sendRaceEnd();
			IDungeonFinish frame = Singleton<ClientSystemManager>.instance.OpenFrame<DungeonDeadTowerFailFrame>(FrameLayer.Middle, null, string.Empty) as IDungeonFinish;
			if (frame != null)
			{
				frame.SetLevel(this.currentIndex + 1);
			}
			yield break;
		}

		// Token: 0x06018F8B RID: 102283 RVA: 0x007DB37B File Offset: 0x007D977B
		protected override void _onStart()
		{
			this.currentIndex = this.mDungeonManager.GetDungeonDataManager().CurrentIndex();
			this._setDialogArray();
		}

		// Token: 0x06018F8C RID: 102284 RVA: 0x007DB399 File Offset: 0x007D9799
		protected override void _createDoors()
		{
		}

		// Token: 0x06018F8D RID: 102285 RVA: 0x007DB39B File Offset: 0x007D979B
		protected override void _onDoorStateChange(object[] arg)
		{
		}

		// Token: 0x06018F8E RID: 102286 RVA: 0x007DB3A0 File Offset: 0x007D97A0
		protected override void PreparePreloadRes()
		{
			PreloadManager.ClearCache();
			HGProfiler.BeginProfiler("1---preload dungeonData");
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			if (dungeonDataManager != null)
			{
				MonoSingleton<CResPreloader>.instance.AddRes(dungeonDataManager.PreloadPath(), false, 1, new ResExtrator(dungeonDataManager.Preload), 0, null, CResPreloader.ResType.OBJECT, null);
			}
			HGProfiler.EndProfiler();
			HGProfiler.BeginProfiler("2---preload created players");
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			BeActionFrameMgr frameMgr = null;
			SkillFileListCache fileCache = null;
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				frameMgr = this.mDungeonManager.GetBeScene().ActionFrameMgr;
				fileCache = this.mDungeonManager.GetBeScene().SkillFileCache;
			}
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					PreloadManager.PreloadActor(playerActor, frameMgr, fileCache, false);
				}
			}
			HGProfiler.EndProfiler();
			HGProfiler.BeginProfiler("3---preload created mosnters");
			base.PreloadEnemies();
			HGProfiler.EndProfiler();
		}

		// Token: 0x06018F8F RID: 102287 RVA: 0x007DB4A1 File Offset: 0x007D98A1
		private bool _isNeedCalculateDrop()
		{
			return (this.currentIndex + 1) % 5 == 0;
		}

		// Token: 0x06018F90 RID: 102288 RVA: 0x007DB4B0 File Offset: 0x007D98B0
		private void ClearResource()
		{
			MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(MonoSingleton<CResPreloader>.instance.priorityGameObjectKeys, false);
		}

		// Token: 0x06018F91 RID: 102289 RVA: 0x007DB4C7 File Offset: 0x007D98C7
		private void _changeAreaByIdx()
		{
			base._changeAreaFade(800U, 600U, delegate
			{
				if (this.mDungeonManager.GetDungeonDataManager().NextAreaByIndex(this.currentIndex + 1))
				{
					if (this._isNeedCalculateDrop())
					{
						this.ClearResource();
					}
					this.currentIndex++;
					base._createBase();
					this._createEntitys();
					base.PreloadMonster();
					this._onSceneStart();
					this.mDungeonManager.StartFight(false);
					base._sendSceneDungeonEnterNextAreaReq(this.mDungeonManager.GetDungeonDataManager().CurrentAreaID());
					base._sendDungeonRewardReq();
				}
			}, delegate
			{
				this._showCurrentTips();
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					clientSystemBattle.HidePauseButton(false);
				}
				List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
				if (allPlayers != null)
				{
					for (int i = 0; i < allPlayers.Count; i++)
					{
						BattlePlayer battlePlayer = allPlayers[i];
						if (battlePlayer.playerActor != null)
						{
							battlePlayer.playerActor.buffController.RemoveBuff(38, 0, 0);
						}
					}
				}
			});
		}

		// Token: 0x06018F92 RID: 102290 RVA: 0x007DB4F4 File Offset: 0x007D98F4
		private void AddDialog(int id, UnityAction action)
		{
			TaskDialogFrame.OnDialogOver onDialogOver = new TaskDialogFrame.OnDialogOver();
			if (action != null)
			{
				onDialogOver.AddListener(action);
			}
			DataManager<MissionManager>.GetInstance().CreateDialogFrame(id, 0, onDialogOver);
		}

		// Token: 0x06018F93 RID: 102291 RVA: 0x007DB524 File Offset: 0x007D9924
		private void _setDialogArray(IList<string> area, List<int> array)
		{
			List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
			for (int i = 0; i < area.Count; i++)
			{
				string[] array2 = area[i].Split(new char[]
				{
					':'
				});
				if (array2.Length >= 2)
				{
					int key = 0;
					int value = 0;
					if (int.TryParse(array2[0], out key) && int.TryParse(array2[1], out value))
					{
						list.Add(new KeyValuePair<int, int>(key, value));
					}
				}
			}
			list.Sort((KeyValuePair<int, int> x, KeyValuePair<int, int> y) => x.Key - y.Key);
			int num = 0;
			for (int j = 0; j < this.mDungeonManager.GetDungeonDataManager().asset.GetAreaConnectListLength(); j++)
			{
				if (num < list.Count && j == list[num].Key)
				{
					array.Add(list[num].Value);
					num++;
				}
				else
				{
					array.Add(0);
				}
			}
		}

		// Token: 0x06018F94 RID: 102292 RVA: 0x007DB640 File Offset: 0x007D9A40
		private void _setDialogArray()
		{
			DungeonUIConfigTable configTable = this.mDungeonManager.GetDungeonDataManager().configTable;
			if (configTable != null)
			{
				this._setDialogArray(configTable.AreaDialog, this.mDialogIDArray);
				this._setDialogArray(configTable.AreaAfterDialog, this.mDialogIDAfterArray);
			}
		}

		// Token: 0x06018F95 RID: 102293 RVA: 0x007DB688 File Offset: 0x007D9A88
		private void _sendDungeonClearAreaMonstersReq()
		{
			if (base._isNeedSendNet())
			{
				BeActor playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
				SceneDungeonClearAreaMonsters sceneDungeonClearAreaMonsters = new SceneDungeonClearAreaMonsters();
				sceneDungeonClearAreaMonsters.remainHp = (uint)playerActor.attribute.GetHP();
				sceneDungeonClearAreaMonsters.remainMp = (uint)playerActor.attribute.GetMP();
				sceneDungeonClearAreaMonsters.usedTime = (uint)this.mDungeonStatistics.CurrentFightTime(false);
				sceneDungeonClearAreaMonsters.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", sceneDungeonClearAreaMonsters.usedTime, sceneDungeonClearAreaMonsters.remainHp, sceneDungeonClearAreaMonsters.remainMp));
				sceneDungeonClearAreaMonsters.lastFrame = this.mDungeonManager.GetDungeonDataManager().GetFinalFrameDataIndex();
				MonoSingleton<NetManager>.instance.SendCommand<SceneDungeonClearAreaMonsters>(ServerType.GATE_SERVER, sceneDungeonClearAreaMonsters);
			}
		}

		// Token: 0x06018F96 RID: 102294 RVA: 0x007DB744 File Offset: 0x007D9B44
		private IEnumerator _openDeadTowerFinishFrame()
		{
			base._sendDungeonKillMonsterReq();
			Singleton<ClientSystemManager>.instance.OpenFrame<DungeonDeadTowerFinishFrame>(FrameLayer.Middle, null, string.Empty);
			while (!Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonDeadTowerFinishFrame>(null))
			{
				yield return null;
			}
			DungeonDeadTowerFinishFrame frame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(DungeonDeadTowerFinishFrame)) as DungeonDeadTowerFinishFrame;
			if (frame == null)
			{
				yield break;
			}
			bool isBossArea = this.mDungeonManager.GetDungeonDataManager().IsBossArea();
			int time = this.mDungeonStatistics.LastFightTimeWithCount(false, 5);
			int currentTop = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR_TOTAL);
			int bestTime = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_USED_TIME_TOTAL);
			if (currentTop <= this.currentIndex + 1)
			{
				bestTime = Mathf.Min(bestTime, time);
				frame.SetBestTime(bestTime);
				frame.SetIsNewRecord(time == bestTime);
			}
			else
			{
				frame.SetIsNewRecord(false);
				frame.SetBestTime(-1);
			}
			frame.SetLevel(this.currentIndex + 1);
			frame.SetCurrentTime(time);
			frame.SetFinish(isBossArea);
			yield return base._endDropIter(1, frame, false);
			DataManager<BattleDataManager>.GetInstance().BattleInfo.dropCacheItemIds.Clear();
			bool isSend = false;
			if (isBossArea)
			{
				isSend = true;
				yield return base._fireRaceEndOnLocalFrameIter();
				yield return base._sendDungeonReportDataIter(true);
				this._sendRaceEnd();
				base._sendDungeonRewardReq();
			}
			while (frame.state == DungeonDeadTowerFinishFrame.eFinishState.None)
			{
				yield return Yielders.EndOfFrame;
			}
			if (frame.state == DungeonDeadTowerFinishFrame.eFinishState.Continue)
			{
				if (!isBossArea)
				{
					this._fireSceneChangeAreaCmd();
				}
			}
			else if (frame.state == DungeonDeadTowerFinishFrame.eFinishState.Back)
			{
				if (!isSend)
				{
					yield return base._fireRaceEndOnLocalFrameIter();
					yield return base._sendDungeonReportDataIter(true);
					this._sendRaceEnd();
					base._sendDungeonRewardReq();
					yield return Yielders.EndOfFrame;
				}
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
			yield break;
		}

		// Token: 0x04011F02 RID: 73474
		private const int kRaceEndSplit = 5;

		// Token: 0x04011F03 RID: 73475
		private int currentIndex;

		// Token: 0x04011F04 RID: 73476
		private List<int> mDialogIDArray = new List<int>();

		// Token: 0x04011F05 RID: 73477
		private List<int> mDialogIDAfterArray = new List<int>();

		// Token: 0x04011F06 RID: 73478
		private bool mHasSendRaceEnd;

		// Token: 0x04011F07 RID: 73479
		private bool mIsProcessAreaClear;

		// Token: 0x04011F08 RID: 73480
		private bool mIsPlayerDeadProcessing;
	}
}
