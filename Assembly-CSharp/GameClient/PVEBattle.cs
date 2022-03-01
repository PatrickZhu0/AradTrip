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
	// Token: 0x020045B9 RID: 17849
	[LoggerModel("Chapter")]
	public class PVEBattle : BaseBattle
	{
		// Token: 0x06019058 RID: 102488 RVA: 0x007D03E0 File Offset: 0x007CE7E0
		public PVEBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
			if (base.dungeonManager != null && base.dungeonManager.GetDungeonDataManager() != null && base.dungeonManager.GetDungeonDataManager().table != null && base.dungeonManager.GetDungeonDataManager().table.LimitTime > 0)
			{
				this.m_timeLimit = new SimpleTimer2();
				this.m_timeLimit.SetCountdown(base.dungeonManager.GetDungeonDataManager().table.LimitTime + 5);
			}
		}

		// Token: 0x06019059 RID: 102489 RVA: 0x007D0499 File Offset: 0x007CE899
		private void _resetHellData()
		{
			this.mHellState = PVEBattle.eHellProcessState.onHellNone;
			this.mCurrentHellObject = null;
			this.mHasHellPlayBGM = false;
			this.mWaitHellTipsTimeCounter = 6;
			this.mWaitOneSeconedCounter = 1000;
		}

		// Token: 0x0601905A RID: 102490 RVA: 0x007D04C4 File Offset: 0x007CE8C4
		private ClientSystemBattle _getValidSystem()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.TargetSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				return clientSystemBattle;
			}
			return Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		}

		// Token: 0x0601905B RID: 102491 RVA: 0x007D04FA File Offset: 0x007CE8FA
		public void OpenHellClose()
		{
			this.mHellOpen = true;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(2990876486U);
			}
		}

		// Token: 0x0601905C RID: 102492 RVA: 0x007D0530 File Offset: 0x007CE930
		private void _updateDungeonMap()
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null && clientSystemBattle.dungeonMapCom != null && this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null)
			{
				clientSystemBattle.dungeonMapCom.SetDungeonData(this.mDungeonManager.GetDungeonDataManager().asset);
				int id = this.mDungeonManager.GetDungeonDataManager().FindDataConnectIDByAreaID(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.areaId);
				clientSystemBattle.dungeonMapCom.SetHell(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode, id);
			}
		}

		// Token: 0x0601905D RID: 102493 RVA: 0x007D05D8 File Offset: 0x007CE9D8
		protected void _updateDungeonState(bool isOpen)
		{
			if (base.GetBattleType() == BattleType.AnniversaryPVE_III || this.mDungeonManager.GetDungeonDataManager().table.ThreeType == DungeonTable.eThreeType.T_RACECAR)
			{
				return;
			}
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				IDungeonConnectData dungeonConnectData = this.mDungeonManager.GetDungeonDataManager().CurrentDataConnect();
				if (dungeonConnectData == null)
				{
					return;
				}
				if (clientSystemBattle.dungeonMapCom != null)
				{
					if (this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_DEVILDDOM)
					{
						clientSystemBattle.dungeonMapCom.SetDropProgress(this.areaIndex);
					}
					clientSystemBattle.dungeonMapCom.SetStartPosition(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
					if (isOpen)
					{
						clientSystemBattle.dungeonMapCom.SetOpenPosition(dungeonConnectData.GetPositionX(), dungeonConnectData.GetPositionY());
					}
				}
			}
		}

		// Token: 0x0601905E RID: 102494 RVA: 0x007D06A8 File Offset: 0x007CEAA8
		public void SetEggRoom(bool flag)
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null && clientSystemBattle.dungeonMapCom != null)
			{
				clientSystemBattle.dungeonMapCom.SetEggRoomState(flag);
			}
		}

		// Token: 0x0601905F RID: 102495 RVA: 0x007D06E0 File Offset: 0x007CEAE0
		protected void _hiddenDungeonMap(bool isShow)
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetDungeonMapActive(isShow);
			}
		}

		// Token: 0x06019060 RID: 102496 RVA: 0x007D0701 File Offset: 0x007CEB01
		protected void _sendDungeonDropProgressReq()
		{
			if (base._isNeedSendNet() && this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_DEVILDDOM)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWorldDungeonGetAreaIndex());
			}
		}

		// Token: 0x06019061 RID: 102497 RVA: 0x007D073C File Offset: 0x007CEB3C
		private IEnumerator _onWorldDungeonGetAreaIndex()
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			WorldDungeonGetAreaIndexReq req = new WorldDungeonGetAreaIndexReq();
			req.dungeonId = (uint)this.mDungeonManager.GetDungeonDataManager().battleInfo.dungeonId;
			WorldDungeonGetAreaIndexRes res = new WorldDungeonGetAreaIndexRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<WorldDungeonGetAreaIndexReq, WorldDungeonGetAreaIndexRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (msg.IsAllMessageReceived())
			{
				this.areaIndex = res.areaIndex >> 1;
				this._updateDungeonState(false);
			}
			yield break;
		}

		// Token: 0x06019062 RID: 102498 RVA: 0x007D0757 File Offset: 0x007CEB57
		protected void _sendDungeonKillMonsterReq()
		{
			if (base._isNeedSendNet())
			{
				this.mDungeonManager.GetDungeonDataManager().SendKillMonsters();
			}
		}

		// Token: 0x06019063 RID: 102499 RVA: 0x007D0774 File Offset: 0x007CEB74
		protected void _resendNoVertifyDungeonKillMonsters()
		{
			if (base._isNeedSendNet() && this.mDungeonManager.GetDungeonDataManager().HasNoVertifyKilledMonsters())
			{
				this.mDungeonManager.GetDungeonDataManager().SendNoVertifyKilledMonsters();
			}
		}

		// Token: 0x06019064 RID: 102500 RVA: 0x007D07A8 File Offset: 0x007CEBA8
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
				Singleton<RecordServer>.GetInstance().MarkInt(142055433U, new int[]
				{
					(int)sceneDungeonRaceEndReq.lastFrame
				});
			}
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x06019065 RID: 102501 RVA: 0x007D0900 File Offset: 0x007CED00
		protected override void _onGameStartFrame(BattlePlayer player)
		{
			if (this.m_timeLimit != null)
			{
				this.m_timeLimit.StartTimer();
				Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnCountDownStart, new UIEventParam
				{
					m_Int = this.m_timeLimit.CountDown - 5
				});
			}
		}

		// Token: 0x06019066 RID: 102502 RVA: 0x007D0950 File Offset: 0x007CED50
		protected SceneDungeonRaceEndReq _getDungeonRaceEndReqWithCount(int count)
		{
			if (this.mDungeonPlayers == null || this.mDungeonStatistics == null)
			{
				return null;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer == null)
			{
				return null;
			}
			uint lastFrame = 0U;
			uint lastChecksum = 0U;
			base.GetFinalFrameInfo(ref lastFrame, ref lastChecksum);
			SceneDungeonRaceEndReq sceneDungeonRaceEndReq = new SceneDungeonRaceEndReq
			{
				beHitCount = (ushort)this.mDungeonStatistics.HitCount(mainPlayer.playerInfo.seat),
				usedTime = (uint)this.mDungeonStatistics.LastFightTimeWithCount(true, count),
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
				Singleton<RecordServer>.GetInstance().MarkInt(142055440U, new int[]
				{
					(int)sceneDungeonRaceEndReq.lastFrame
				});
			}
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x06019067 RID: 102503 RVA: 0x007D0AB0 File Offset: 0x007CEEB0
		private IEnumerator _sendDungeonRaceEndReqIter(bool modifyScore = false, DungeonScore score = DungeonScore.C)
		{
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return this._sendDungeonReportDataIter(true);
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
			if (this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null)
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

		// Token: 0x06019068 RID: 102504 RVA: 0x007D0ADC File Offset: 0x007CEEDC
		protected IEnumerator _sendDungeonReportDataIter(bool needWaitRaceEnd = true)
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
				if (needWaitRaceEnd && !base.HasFlag(BattleFlagType.UseOldCheatSync))
				{
					DungeonDataManager datamgr = this.mDungeonManager.GetDungeonDataManager();
					yield return datamgr.WaitForRaceEndCmdInTime();
				}
				if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
				{
					yield break;
				}
				this.mDungeonManager.GetDungeonDataManager().PushFinalFrameData();
				this.mDungeonManager.GetDungeonDataManager().SendWorldDungeonReportFrame();
				yield return null;
				while (this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null && !this.mDungeonManager.GetDungeonDataManager().IsAllReportDataServerRecived())
				{
					yield return null;
				}
				if (this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null)
				{
					this.mDungeonManager.GetDungeonDataManager().UnlockUpdateCheck();
				}
			}
			yield break;
		}

		// Token: 0x06019069 RID: 102505 RVA: 0x007D0B00 File Offset: 0x007CEF00
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

		// Token: 0x0601906A RID: 102506 RVA: 0x007D0C44 File Offset: 0x007CF044
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

		// Token: 0x0601906B RID: 102507 RVA: 0x007D0C70 File Offset: 0x007CF070
		protected void _sendDungeonRaceEndReq(bool dead = false)
		{
			this.isNormalFinsh = !dead;
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

		// Token: 0x0601906C RID: 102508 RVA: 0x007D0D54 File Offset: 0x007CF154
		protected void _sendDungeonRaceEndFail(DungeonScore score = DungeonScore.C)
		{
			if (base._isNeedSendNet())
			{
				if (base.GetMode() == eDungeonMode.SyncFrame)
				{
					this.mDungeonRaceEndReqCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonTeamRaceEndReqIter(true, score));
				}
				else
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonRaceEndReqIter(true, score));
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
		}

		// Token: 0x0601906D RID: 102509 RVA: 0x007D0DC4 File Offset: 0x007CF1C4
		protected List<ComItemList.Items> _getPickedDropItems()
		{
			PVEBattle.<_getPickedDropItems>c__AnonStorey9 <_getPickedDropItems>c__AnonStorey = new PVEBattle.<_getPickedDropItems>c__AnonStorey9();
			<_getPickedDropItems>c__AnonStorey.allGots = DataManager<BattleDataManager>.GetInstance().BattleInfo.dropCacheItemIds;
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			int i;
			for (i = 0; i < <_getPickedDropItems>c__AnonStorey.allGots.Count; i++)
			{
				ComItemList.Items items = list.Find((ComItemList.Items x) => x.id == <_getPickedDropItems>c__AnonStorey.allGots[i].typeId);
				if (items != null)
				{
					items.count += (uint)<_getPickedDropItems>c__AnonStorey.allGots[i].num;
				}
				else
				{
					list.Add(new ComItemList.Items
					{
						id = <_getPickedDropItems>c__AnonStorey.allGots[i].typeId,
						count = (uint)<_getPickedDropItems>c__AnonStorey.allGots[i].num,
						type = ComItemList.eItemType.Custom,
						strenthLevel = <_getPickedDropItems>c__AnonStorey.allGots[i].strenthLevel,
						equipType = <_getPickedDropItems>c__AnonStorey.allGots[i].equipType
					});
				}
			}
			return list;
		}

		// Token: 0x0601906E RID: 102510 RVA: 0x007D0EFC File Offset: 0x007CF2FC
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

		// Token: 0x0601906F RID: 102511 RVA: 0x007D100C File Offset: 0x007CF40C
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

		// Token: 0x06019070 RID: 102512 RVA: 0x007D10CC File Offset: 0x007CF4CC
		protected List<ComItemList.Items> _getAllRewardItems(SceneDungeonRaceEndRes res)
		{
			List<ComItemList.Items> list = this._getTeamRewardItem(res);
			List<ComItemList.Items> collection = this._getRaceEndDropItem();
			List<ComItemList.Items> collection2 = this._getPickedDropItems();
			if (DataManager<BattleDataManager>.GetInstance() != null && DataManager<BattleDataManager>.GetInstance().mSelfRollItems.Count > 0)
			{
				list.AddRange(DataManager<BattleDataManager>.GetInstance().mSelfRollItems);
			}
			list.AddRange(collection);
			list.AddRange(collection2);
			return list;
		}

		// Token: 0x06019071 RID: 102513 RVA: 0x007D1130 File Offset: 0x007CF530
		private void _openDungeonFinishFrame(SceneDungeonRaceEndRes res)
		{
			base.PveBattleResult = ((res.score != 0) ? BattleResult.Success : BattleResult.Fail);
			DungeonFinishFrame dungeonFinishFrame = Singleton<ClientSystemManager>.instance.OpenFrame<DungeonFinishFrame>(FrameLayer.Middle, null, string.Empty) as DungeonFinishFrame;
			if (dungeonFinishFrame != null)
			{
				dungeonFinishFrame.SetData(res);
				dungeonFinishFrame.SetDrops(this._getAllRewardItems(res).ToArray());
			}
		}

		// Token: 0x06019072 RID: 102514 RVA: 0x007D118C File Offset: 0x007CF58C
		protected IEnumerator _waitForFrameClose(Type type)
		{
			yield return Yielders.EndOfFrame;
			while (Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06019073 RID: 102515 RVA: 0x007D11A8 File Offset: 0x007CF5A8
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

		// Token: 0x06019074 RID: 102516 RVA: 0x007D11CC File Offset: 0x007CF5CC
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

		// Token: 0x06019075 RID: 102517 RVA: 0x007D1234 File Offset: 0x007CF634
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
				this.mDungeonManager.GetBeScene().DropItems(this.mDungeonManager.GetDungeonDataManager().GetRaceEndDrops(), new VInt3(pos), false, true, null);
				yield return Yielders.GetWaitForSeconds(1.5f);
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			bool isItemRoll = false;
			bool isSingleItemRoll = false;
			isSingleItemRoll = (res.rollSingleReward != null && res.rollSingleReward.Length > 0);
			isItemRoll = (res.rollReward != null && res.rollReward.Length > 0);
			if (isItemRoll)
			{
				Vec3 pos2 = this.mDungeonManager.GetBeScene().GeGDeadBossPosition();
				List<BeRegionDropItem> dropItems = new List<BeRegionDropItem>();
				this.mDungeonManager.GetBeScene().DropItems(DataManager<BattleDataManager>.GetInstance().mAllRollRewardItems, new VInt3(pos2), false, false, dropItems);
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonRollFrame>(FrameLayer.Middle, null, string.Empty);
				yield return this._waitForFrameClose(typeof(DungeonRollFrame));
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRollResultFrame>(null))
				{
					float waitTime = 5f;
					SystemValueTable systemValueItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(632, string.Empty, string.Empty);
					if (systemValueItem != null)
					{
						waitTime = Convert.ToSingle(systemValueItem.Value);
					}
					yield return Yielders.GetWaitForSeconds(waitTime);
					for (int i = 0; i < dropItems.Count; i++)
					{
						if (dropItems[i] != null)
						{
							dropItems[i].RemoveAll();
						}
					}
					Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRollResultFrame>(null, false);
				}
			}
			else if (isSingleItemRoll)
			{
				Vec3 position = this.mDungeonManager.GetBeScene().GeGDeadBossPosition();
				this.mDungeonManager.GetBeScene().DropItems(DataManager<BattleDataManager>.GetInstance().mAllRollRewardItems, new VInt3(position), false, true, null);
			}
			this._openDungeonFinishFrame(res);
			yield return this._waitForFrameClose(typeof(DungeonFinishFrame));
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (res.hasRaceEndChest != 0)
			{
				if (BattleMain.instance == null)
				{
					yield break;
				}
				if (!(this is GuildPVEBattle))
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<DungeonRewardFrame>(FrameLayer.Middle, null, string.Empty);
					yield return this._waitForFrameClose(typeof(DungeonRewardFrame));
				}
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				yield break;
			}
			int id = base.dungeonManager.GetDungeonDataManager().id.dungeonID;
			DungeonTable tableData = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableData != null && this.isNormalFinsh && ChapterUtility.PreconditionIDList(id).Count != 0 && this.isChapterNoPassed && tableData.SubType != DungeonTable.eSubType.S_WEEK_HELL)
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

		// Token: 0x06019076 RID: 102518 RVA: 0x007D1258 File Offset: 0x007CF658
		protected virtual void _onSceneDungeonRaceEndRes(SceneDungeonRaceEndRes res)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(2990876481U);
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

		// Token: 0x06019077 RID: 102519 RVA: 0x007D1305 File Offset: 0x007CF705
		protected void _sendDungeonRewardReq()
		{
			if (this.mDungeonManager == null)
			{
				return;
			}
			if (this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			this._resendNoVertifyDungeonRewards();
			if (base._isNeedSendNet())
			{
				this.mDungeonManager.GetDungeonDataManager().SendPickedDrops();
			}
		}

		// Token: 0x06019078 RID: 102520 RVA: 0x007D1348 File Offset: 0x007CF748
		protected void _sendDungeonBossRewardReq()
		{
			if (this.mDungeonManager == null)
			{
				return;
			}
			if (this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			if (base._isNeedSendNet())
			{
				this.mDungeonManager.GetDungeonDataManager().SendBossDrops();
			}
			Vec3 position = this.mDungeonManager.GetBeScene().GeGDeadBossPosition();
			this.mDungeonManager.GetBeScene().DropItems(this.mDungeonManager.GetDungeonDataManager().battleInfo.bossDropItems, new VInt3(position), true, true, null);
		}

		// Token: 0x06019079 RID: 102521 RVA: 0x007D13CC File Offset: 0x007CF7CC
		protected void _resendNoVertifyDungeonRewards()
		{
			if (this.mDungeonManager == null)
			{
				return;
			}
			if (this.mDungeonManager.GetDungeonDataManager() == null)
			{
				return;
			}
			if (base._isNeedSendNet() && this.mDungeonManager.GetDungeonDataManager().HasNoVertifyDrops())
			{
				this.mDungeonManager.GetDungeonDataManager().SendNoVertifyDrops();
			}
		}

		// Token: 0x0601907A RID: 102522 RVA: 0x007D1426 File Offset: 0x007CF826
		protected void _sendSceneDungeonEnterNextAreaReq(int nextAreaID)
		{
			if (base._isNeedSendNet())
			{
				this.mDungeonManager.GetDungeonDataManager().SendSceneDungeonAreaChange(nextAreaID);
			}
		}

		// Token: 0x0601907B RID: 102523 RVA: 0x007D1444 File Offset: 0x007CF844
		protected override void _onCreateScene(object[] args)
		{
			this._updateDungeonState(false);
		}

		// Token: 0x0601907C RID: 102524 RVA: 0x007D144D File Offset: 0x007CF84D
		protected override void _onDoorStateChange(object[] args)
		{
			this._updateDungeonState((bool)args[0]);
		}

		// Token: 0x0601907D RID: 102525 RVA: 0x007D145D File Offset: 0x007CF85D
		protected sealed override void _onMonsterDead(object[] args)
		{
			this._sendDungeonRewardReq();
		}

		// Token: 0x0601907E RID: 102526 RVA: 0x007D1465 File Offset: 0x007CF865
		protected sealed override void _onEggDead(object[] args)
		{
			this._sendDungeonRewardReq();
		}

		// Token: 0x0601907F RID: 102527 RVA: 0x007D1470 File Offset: 0x007CF870
		public override void OnCriticalElementDisappear()
		{
			if (this.mDungeonManager == null)
			{
				Logger.LogErrorFormat("OnCriticalElementDisappear occur data error!!", new object[0]);
				return;
			}
			if (!this.mDungeonManager.IsFinishFight())
			{
				this.m_CanFinishFight = true;
				base.FrameRandom.Range100();
				this._sendDungeonRaceEndFail(DungeonScore.C);
				this.mDungeonManager.FinishFight();
			}
		}

		// Token: 0x06019080 RID: 102528 RVA: 0x007D14CE File Offset: 0x007CF8CE
		protected sealed override void _onMonsterRemoved(object[] args)
		{
			this._sendDungeonKillMonsterReq();
			this._sendDungeonRewardReq();
		}

		// Token: 0x06019081 RID: 102529 RVA: 0x007D14DC File Offset: 0x007CF8DC
		protected override void _onAreaClear(object[] args)
		{
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.CloseLevelTip();
			}
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(142055680U);
			}
			if (this.mDungeonManager.GetDungeonDataManager().IsHellArea())
			{
				Battle.DungeonHellInfo dungeonHellInfo = this.mDungeonManager.GetDungeonDataManager().CurrentHellDestructs();
				if (dungeonHellInfo != null && dungeonHellInfo.state != eDungeonHellState.End)
				{
					return;
				}
			}
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this._CheckFightEnd();
			}
			else
			{
				if (this.thisRoomMonsterCreatedCount > 0)
				{
					SystemNotifyManager.SystemNotify(6000, string.Empty);
					MonoSingleton<AudioManager>.instance.PlaySound(5);
				}
				if (this._rejectEnterBossAreaInHellMode())
				{
					this.mDungeonManager.GetBeScene().SetBossTransportDoorEffectState(false);
				}
				int num = this.mDungeonManager.GetDungeonDataManager().CurrentIndex();
				this.areaIndex = (1U << num | this.areaIndex);
				this._updateDungeonState(true);
			}
		}

		// Token: 0x06019082 RID: 102530 RVA: 0x007D15EE File Offset: 0x007CF9EE
		private bool _rejectEnterBossAreaInHellMode()
		{
			return base.GetBattleType() == BattleType.Hell && this.mDungeonManager.GetDungeonDataManager().IsBossAreaNearby() && 0 == this.mDungeonManager.GetDungeonDataManager().IsHellAreaVisited();
		}

		// Token: 0x06019083 RID: 102531 RVA: 0x007D1628 File Offset: 0x007CFA28
		protected override void _onStart()
		{
			this.GetChapterPassed();
			if (base.GetBattleType() != BattleType.AnniversaryPVE_III && this.mDungeonManager.GetDungeonDataManager().table.ThreeType != DungeonTable.eThreeType.T_RACECAR)
			{
				this._updateDungeonMap();
			}
			this._sendDungeonDropProgressReq();
		}

		// Token: 0x06019084 RID: 102532 RVA: 0x007D1664 File Offset: 0x007CFA64
		private void GetChapterPassed()
		{
			this.isChapterNoPassed = ComCommonChapterInfo._isAllDiffNoScores(base.dungeonManager.GetDungeonDataManager().id.dungeonID);
		}

		// Token: 0x06019085 RID: 102533 RVA: 0x007D1688 File Offset: 0x007CFA88
		protected override void _onEnd()
		{
			this._resetHellData();
			this.mStarted = false;
			if (this.mDungeonRaceEndReqCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDungeonRaceEndReqCoroutine);
			}
			if (this.mDungeonHellTipCorutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDungeonHellTipCorutine);
			}
		}

		// Token: 0x06019086 RID: 102534 RVA: 0x007D16D8 File Offset: 0x007CFAD8
		protected override void _onPostStart()
		{
			if (base.GetMode() != eDungeonMode.Test && DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				SystemNotifyManager.SystemNotify(1033, string.Empty);
			}
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null || this.mDungeonManager.GetBeScene() == null || this.mDungeonManager.GetBeScene().sceneData == null)
			{
				return;
			}
			string text = ChapterUtility.GetHardString(this.mDungeonManager.GetDungeonDataManager().id.diffID);
			if (this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_CITYMONSTER || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
			{
				text = string.Empty;
			}
			else if (this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_WEEK_HELL || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_ANNIVERSARY_HARD || this.mDungeonManager.GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_ANNIVERSARY_NORMAL)
			{
				text = ChapterUtility.GetHardString(3);
			}
			else if (this.mDungeonManager.GetDungeonDataManager().IsHardRaid)
			{
				text = "噩梦";
			}
			if (base.GetBattleType() != BattleType.AnniversaryPVE_III && this.mDungeonManager.GetDungeonDataManager().table.ThreeType != DungeonTable.eThreeType.T_RACECAR)
			{
				SystemNotifyManager.SystemNotify(6001, new object[]
				{
					this.mDungeonManager.GetDungeonDataManager().table.Name,
					text
				});
			}
			ClientSystemBattle clientSystemBattle = this._getValidSystem();
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowLevelTip(this.mDungeonManager.GetBeScene().sceneData.GetTipsID());
				if (base.GetBattleType() == BattleType.AnniversaryPVE_III || this.mDungeonManager.GetDungeonDataManager().table.ThreeType == DungeonTable.eThreeType.T_RACECAR)
				{
					clientSystemBattle.HideTextRoot();
					clientSystemBattle.HideTimeAndScore();
				}
			}
			this.mStarted = true;
			if (base.GetBattleType() == BattleType.Hell)
			{
				if (DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode == DungeonHellMode.Hard_Ultimate)
				{
					Singleton<PluginManager>.GetInstance().TriggerMobileVibrate();
				}
				this.mDungeonHellTipCorutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._hellEnterTips());
			}
			this.ShowAlienLand();
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
							playerActor.GetRecordServer().Mark(3024234305U);
						}
					}
				});
			}
		}

		// Token: 0x06019087 RID: 102535 RVA: 0x007D19A8 File Offset: 0x007CFDA8
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

		// Token: 0x06019088 RID: 102536 RVA: 0x007D1A94 File Offset: 0x007CFE94
		protected void ShowAlienLand()
		{
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			if (dungeonDataManager == null)
			{
				return;
			}
			BattleInfo battleInfo = dungeonDataManager.battleInfo;
			if (battleInfo == null)
			{
				return;
			}
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(battleInfo.dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SubType != DungeonTable.eSubType.S_DEVILDDOM)
			{
				return;
			}
			if (battleInfo.dropOverMonster == null)
			{
				return;
			}
			List<DungeonArea> areas = battleInfo.areas;
			if (areas == null)
			{
				return;
			}
			int i = 0;
			while (i < areas.Count)
			{
				if (areas[i].id != dungeonDataManager.CurrentAreaID())
				{
					i++;
				}
				else
				{
					List<DungeonMonster> monsters = areas[i].monsters;
					if (monsters == null)
					{
						return;
					}
					int j;
					for (j = 0; j < monsters.Count; j++)
					{
						uint num = battleInfo.dropOverMonster.Find((uint value) => (ulong)value == (ulong)((long)monsters[j].id));
						if (num != 0U)
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("resist_magic_challenge_reward_over"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							break;
						}
					}
					break;
				}
			}
		}

		// Token: 0x06019089 RID: 102537 RVA: 0x007D1BF0 File Offset: 0x007CFFF0
		protected sealed override void _createRegions()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<int> regions = dungeonDataManager.CurrentRegions();
			if (beScene != null)
			{
				beScene.CreateRegions(new BeRegionBase.TriggerTarget(this._doorTriggerAllPlayers), regions);
			}
		}

		// Token: 0x0601908A RID: 102538 RVA: 0x007D1C38 File Offset: 0x007D0038
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
								playerActor.SetPetAlongside();
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

		// Token: 0x0601908B RID: 102539 RVA: 0x007D1D30 File Offset: 0x007D0130
		protected sealed override void _createHealDestruct()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			Battle.DungeonHellInfo dungeonHellInfo = dungeonDataManager.CurrentHellDestructs();
			this._resetHellData();
			if (dungeonHellInfo != null)
			{
				this.mCurrentHellObject = beScene.CreateHellDestruct(dungeonHellInfo);
				this.mHellState = PVEBattle.eHellProcessState.onHellInit;
			}
		}

		// Token: 0x0601908C RID: 102540 RVA: 0x007D1D7C File Offset: 0x007D017C
		protected override void _createMonsters()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> monsters = dungeonDataManager.CurrentMonsters();
			int num = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), true);
			this.thisRoomMonsterCreatedCount = num;
		}

		// Token: 0x0601908D RID: 102541 RVA: 0x007D1DC4 File Offset: 0x007D01C4
		protected sealed override void _createDestructs()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> destructs = dungeonDataManager.CurrentDestructs();
			beScene.CreateDestructList2(destructs);
		}

		// Token: 0x0601908E RID: 102542 RVA: 0x007D1DF8 File Offset: 0x007D01F8
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

		// Token: 0x0601908F RID: 102543 RVA: 0x007D1E58 File Offset: 0x007D0258
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

		// Token: 0x06019090 RID: 102544 RVA: 0x007D1EA0 File Offset: 0x007D02A0
		private bool _doorCallback(ISceneRegionInfoData info, BeRegionTarget target)
		{
			this.startPassDoor = (int)Time.realtimeSinceStartup;
			bool result = true;
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene != null)
			{
				BeActor playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
				if (playerActor != null && !playerActor.IsDead())
				{
					beScene.ForcePickUpDropItem(playerActor);
				}
			}
			ISceneTransportDoorData door = info as ISceneTransportDoorData;
			if (door != null)
			{
				if (this.mHellState == PVEBattle.eHellProcessState.onHellProcessFinish || this.mHellState == PVEBattle.eHellProcessState.onHellProcessReportFinish)
				{
					result = false;
				}
				else if (this._rejectEnterBossAreaInHellMode() && this.mDungeonManager.GetDungeonDataManager().IsNextAreaBoss(door.GetDoortype()))
				{
					SystemNotifyManager.SystemNotify(5018, string.Empty);
					result = false;
				}
				else if (this.mDungeonManager.GetDungeonDataManager().IsYiJieCheckPoint() && this.mDungeonManager.GetDungeonDataManager().IsNextAreaBoss(door.GetDoortype()) && !this.eggRoomOpen)
				{
					result = false;
				}
				else
				{
					this._changeAreaFade(600U, 300U, delegate
					{
						if (!Singleton<PluginManager>.instance.IsLargeMemoryDevice() || !Singleton<GeGraphicSetting>.instance.IsHighLevel())
						{
							MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(MonoSingleton<CResPreloader>.instance.priorityGameObjectKeys, false);
						}
						else
						{
							this.DoSpecialGCClear(true);
						}
						if (Singleton<RecordServer>.instance != null)
						{
							Singleton<RecordServer>.instance.FlushProcess();
						}
						bool isFinishFight = false;
						if (this.GetBattleType() == BattleType.RaidPVE)
						{
							isFinishFight = this.mDungeonManager.IsFinishFight();
						}
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
								if (allPlayers[j].playerActor.pet != null)
								{
									GeActorEx pkGeActor = allPlayers[j].playerActor.pet.m_pkGeActor;
									if (pkGeActor != null)
									{
										pkGeActor.SetActorVisible(false);
									}
								}
							}
							SystemNotifyManager.ClearDungeonSkillTip();
							if (this.recordServer != null && this.recordServer.IsProcessRecord())
							{
								this.recordServer.MarkString(142055441U, new string[]
								{
									door.GetDoortype().ToString(),
									door.GetNextdoortype().ToString(),
									this.mDungeonManager.GetDungeonDataManager().CurrentScenePath()
								});
							}
							this._createBase();
							this._createEntitys();
							this.PreloadMonster();
							this._onSceneStart();
							this.mDungeonManager.StartFight(isFinishFight);
							this._sendSceneDungeonEnterNextAreaReq(this.mDungeonManager.GetDungeonDataManager().CurrentAreaID());
							this._sendDungeonRewardReq();
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
								GeActorEx pkGeActor = allPlayers[i].playerActor.pet.m_pkGeActor;
								if (pkGeActor != null)
								{
									pkGeActor.SetActorVisible(true);
								}
							}
							BeActor playerActor2 = allPlayers[i].playerActor;
							if (playerActor2.aiManager != null && playerActor2.aiManager.isAutoFight)
							{
								playerActor2.aiManager.StopCurrentCommand();
								if (playerActor2 != null && playerActor2.IsProcessRecord())
								{
									playerActor2.GetRecordServer().MarkInt(142055442U, new int[]
									{
										playerActor2.GetPID()
									});
								}
							}
						}
						this._showActivityMonsterTips();
						this.ShowAlienLand();
					});
				}
			}
			return result;
		}

		// Token: 0x06019091 RID: 102545 RVA: 0x007D1FEC File Offset: 0x007D03EC
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

		// Token: 0x06019092 RID: 102546 RVA: 0x007D2068 File Offset: 0x007D0468
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
					playerActor.RemoveDeadHandle();
					playerActor.Reset();
					playerActor.SetAttackButtonState(ButtonState.RELEASE, true);
				}
			}
		}

		// Token: 0x06019093 RID: 102547 RVA: 0x007D20E4 File Offset: 0x007D04E4
		protected override void _createDoors()
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

		// Token: 0x06019094 RID: 102548 RVA: 0x007D21AC File Offset: 0x007D05AC
		private IEnumerator _hellEnterTips()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonHellTipsFrame>(null, false);
			DungeonHellTipsFrame frame = Singleton<ClientSystemManager>.instance.OpenFrame<DungeonHellTipsFrame>(FrameLayer.TopMost, null, string.Empty) as DungeonHellTipsFrame;
			frame.SetHellType(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode);
			if (DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode == DungeonHellMode.Hard_Ultimate)
			{
				frame.ShowEffect();
				yield return Yielders.GetWaitForSeconds(3.2f);
				frame.HideUI();
				yield return Yielders.GetWaitForSeconds(4.8f);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnHardUltimateStart, null, null, null, null);
			}
			else
			{
				yield return Yielders.GetWaitForSeconds(3.2f);
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonHellTipsFrame>(null, false);
			yield break;
		}

		// Token: 0x06019095 RID: 102549 RVA: 0x007D21C0 File Offset: 0x007D05C0
		public void SetAccompanyInfo(BattlePlayer battlePlayer)
		{
			RacePlayerInfo playerInfo = battlePlayer.playerInfo;
			for (int i = 0; i < playerInfo.retinues.Length; i++)
			{
				if (playerInfo.retinues[i].isMain > 0)
				{
					break;
				}
			}
		}

		// Token: 0x06019096 RID: 102550 RVA: 0x007D2208 File Offset: 0x007D0608
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
					beActor.RegisterEvent(BeEventType.onDeadProtectEnd, delegate(object[] args)
					{
						this._CheckFightEnd();
					});
					beActor.RegisterEvent(BeEventType.onDead, delegate(object[] arsg)
					{
						BattlePlayer battlePlayer;
						if (battlePlayer.state != BattlePlayer.EState.Dead)
						{
							if (battlePlayer.IsLocalPlayer() && this.mDungeonManager != null && this.mDungeonManager.GetDungeonDataManager() != null && this.mDungeonManager.GetDungeonDataManager().isDeViILDdOM() && Singleton<GameStatisticManager>.GetInstance() != null)
							{
								Singleton<GameStatisticManager>.GetInstance().DoStartAnotherWorldDie(this.mDungeonManager.GetDungeonDataManager().CurrentAreaID());
							}
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
					beActor.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
					{
						this._onPlayerReborn(battlePlayer);
						Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.PLAYER_REBORN, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Format("{0}, {1}", battlePlayer.playerInfo.roleId, battlePlayer.statistics.data.rebornCount));
					});
					beActor.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
					{
						int skill = (int)args[0];
						this._onPlayerUseSkill(battlePlayer, skill);
					});
					this.SetAccompanyInfo(battlePlayer);
					if (petData != null)
					{
						beActor.SetPetData(petData);
					}
					beActor.CreateFollowMonster();
					this.InitAutoFight(beActor);
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

		// Token: 0x06019097 RID: 102551 RVA: 0x007D27B0 File Offset: 0x007D0BB0
		protected void InitAutoFight(BeActor actor)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(actor.attribute.professtion, string.Empty, string.Empty);
			if (tableItem != null)
			{
				actor.InitAutoFight(tableItem.AIConfig1, tableItem.AIConfig2, tableItem.AIConfig3, 0, 0, 0, 0, true);
			}
		}

		// Token: 0x06019098 RID: 102552 RVA: 0x007D2800 File Offset: 0x007D0C00
		protected virtual void ChangeActorAttribute(BeActor actor)
		{
		}

		// Token: 0x06019099 RID: 102553 RVA: 0x007D2802 File Offset: 0x007D0C02
		protected virtual void _onPlayerHit(BattlePlayer player)
		{
			player.statistics.OnHit();
		}

		// Token: 0x0601909A RID: 102554 RVA: 0x007D2810 File Offset: 0x007D0C10
		protected virtual void _onPlayerReborn(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(142055443U, new int[]
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

		// Token: 0x0601909B RID: 102555 RVA: 0x007D2948 File Offset: 0x007D0D48
		protected virtual void _onPlayerDead(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(142055444U, new int[]
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

		// Token: 0x0601909C RID: 102556 RVA: 0x007D2A48 File Offset: 0x007D0E48
		private void _stopPlayerDeadProcess()
		{
			if (this.mDeadProcess != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDeadProcess);
				this.mDeadProcess = null;
			}
		}

		// Token: 0x0601909D RID: 102557 RVA: 0x007D2A6C File Offset: 0x007D0E6C
		private void _startPlayerDeadProcess(BattlePlayer player)
		{
			this._stopPlayerDeadProcess();
			if (!this.mDungeonManager.IsFinishFight())
			{
				this.mDeadProcess = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._playerDeadProcess(player));
			}
		}

		// Token: 0x0601909E RID: 102558 RVA: 0x007D2A9C File Offset: 0x007D0E9C
		protected override void _onPlayerLeave(BattlePlayer player)
		{
			if (player != null)
			{
				player.netState = BattlePlayer.eNetState.Offline;
				if (base.recordServer != null && base.recordServer.IsProcessRecord())
				{
					base.recordServer.MarkString(142055445U, new string[]
					{
						player.playerActor.m_iID.ToString(),
						player.playerInfo.name
					});
				}
			}
			if (this.mDungeonPlayers != null && this.mDungeonPlayers.IsAllPlayerDead())
			{
				this._startPlayerDeadProcess(player);
			}
		}

		// Token: 0x0601909F RID: 102559 RVA: 0x007D2B30 File Offset: 0x007D0F30
		protected sealed override void _onPlayerBack(BattlePlayer player)
		{
			if (player != null)
			{
				player.netState = BattlePlayer.eNetState.Online;
				if (base.recordServer != null && base.recordServer.IsProcessRecord())
				{
					base.recordServer.MarkString(142055446U, new string[]
					{
						player.playerActor.m_iID.ToString(),
						player.playerInfo.name
					});
				}
			}
		}

		// Token: 0x060190A0 RID: 102560 RVA: 0x007D2BA2 File Offset: 0x007D0FA2
		protected virtual void _onPlayerUseSkill(BattlePlayer player, int skill)
		{
		}

		// Token: 0x060190A1 RID: 102561 RVA: 0x007D2BA4 File Offset: 0x007D0FA4
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			if (player != null && player.playerActor != null)
			{
				player.playerActor.EndDeadProtect();
			}
			this._CheckFightEnd();
		}

		// Token: 0x060190A2 RID: 102562 RVA: 0x007D2BC8 File Offset: 0x007D0FC8
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

		// Token: 0x060190A3 RID: 102563 RVA: 0x007D2BE4 File Offset: 0x007D0FE4
		public void CreateNPC(int npcID)
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			object[] summoneds = new object[1];
			MonsterIDData monsterIDData = new MonsterIDData(npcID);
			if (monsterIDData.level <= 0)
			{
				monsterIDData.level = 1;
			}
			if (mainPlayer.playerActor.DoSummon(npcID, monsterIDData.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, summoneds, true))
			{
			}
		}

		// Token: 0x060190A4 RID: 102564 RVA: 0x007D2C48 File Offset: 0x007D1048
		public override void FrameUpdate(int delta)
		{
			this._updateHellProcess(delta);
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.m_timeLimit != null && this.m_timeLimit.IsCount() && !this.m_timeLimit.IsTimeUp())
			{
				this.m_timeLimit.UpdateTimer(delta);
				Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnCountDownUpdate, new UIEventParam
				{
					m_Int = delta
				});
				if (this.m_timeLimit.IsTimeUp())
				{
					if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
					{
						bool flag = this.mDungeonManager.GetBeScene().isAllEnemyDead();
						if (flag && this.mDungeonManager.GetDungeonDataManager().IsBossArea())
						{
							this.DoFightSuccess();
							return;
						}
					}
					this.OnCriticalElementDisappear();
				}
			}
		}

		// Token: 0x060190A5 RID: 102565 RVA: 0x007D2D34 File Offset: 0x007D1134
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
				this._sendDungeonKillMonsterReq();
				this._sendDungeonRewardReq();
				this._sendDungeonBossRewardReq();
				this._sendDungeonRaceEndReq(false);
			}
			else if (flag)
			{
				this._sendDungeonRaceEndReq(true);
			}
			if ((flag2 && this.mDungeonManager.GetDungeonDataManager().IsBossArea()) || flag)
			{
				this.mDungeonManager.FinishFight();
				if (this.mDungeonManager.GetDungeonDataManager().isDeViILDdOM())
				{
					this.SendGameStatictise();
				}
			}
		}

		// Token: 0x060190A6 RID: 102566 RVA: 0x007D2E7C File Offset: 0x007D127C
		public void DoFightSuccess()
		{
			base.FrameRandom.Range100();
			this.m_CanFinishFight = true;
			this._sendDungeonKillMonsterReq();
			this._sendDungeonRewardReq();
			this._sendDungeonBossRewardReq();
			this._sendDungeonRaceEndReq(false);
			if (this.mDungeonManager.GetBeScene() != null)
			{
				this.mDungeonManager.GetBeScene().ClearAllMonsters();
			}
			this.mDungeonManager.FinishFight();
		}

		// Token: 0x060190A7 RID: 102567 RVA: 0x007D2EE0 File Offset: 0x007D12E0
		private void SendGameStatictise()
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null && playerActor.isLocalActor)
				{
					int num = this.mDungeonManager.GetDungeonDataManager().CurrentAreaID();
					Mechanism2004 mechanism = playerActor.GetMechanism(5300) as Mechanism2004;
					if (mechanism != null)
					{
						Singleton<GameStatisticManager>.instance.SendBatrayCount(mechanism.betrayCnt.ToString(), string.Format("running_{0}", num));
						Singleton<GameStatisticManager>.instance.SendBatrayCount(mechanism.betrayTotal.ToString(), string.Format("end_{0}", base.dungeonManager.GetDungeonDataManager().id.dungeonID));
					}
				}
			}
		}

		// Token: 0x060190A8 RID: 102568 RVA: 0x007D2FC4 File Offset: 0x007D13C4
		private void _updateHellProcess(int delta)
		{
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			if (dungeonDataManager == null)
			{
				return;
			}
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene == null)
			{
				return;
			}
			Battle.DungeonHellInfo dungeonHellInfo = dungeonDataManager.CurrentHellDestructs();
			if (dungeonHellInfo == null || dungeonHellInfo.mode == DungeonHellMode.Null || dungeonHellInfo.waveInfos.Count < 3)
			{
				return;
			}
			if (this.mCurrentHellObject == null)
			{
				return;
			}
			switch (this.mHellState)
			{
			case PVEBattle.eHellProcessState.onHellInit:
				this.mCurrentHellObject.SetCanBeAttacked(false);
				this.mHasHellPlayBGM = false;
				if (dungeonHellInfo.mode == DungeonHellMode.Hard || dungeonHellInfo.mode == DungeonHellMode.Hard_Ultimate)
				{
					this.mHasHellPlayBGM = base.PushBgm(dungeonDataManager.table.HellDamnHardBGMPath);
				}
				else
				{
					this.mHasHellPlayBGM = base.PushBgm(dungeonDataManager.table.HellHardBGMPath);
				}
				this._setHellInfoState(dungeonHellInfo, eDungeonHellState.Ready);
				this.mCurrentHellObject.currentStage = 0;
				this.mCurrentHellObject.sgSwitchStates(new BeStateData(0, 0));
				this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
				break;
			case PVEBattle.eHellProcessState.onHellTipsInit:
			{
				this.mWaitHellTipsTimeCounter = 6;
				string text = string.Empty;
				eDungeonHellState state = dungeonHellInfo.state;
				if (state != eDungeonHellState.Start)
				{
					if (state != eDungeonHellState.Monster1)
					{
						if (state == eDungeonHellState.Monster2Pre)
						{
							if (dungeonHellInfo.mode == DungeonHellMode.Hard_Ultimate)
							{
								CommonTipsDesc tableItem = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5022, string.Empty, string.Empty);
								text = tableItem.Descs;
							}
							else
							{
								CommonTipsDesc tableItem2 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5017, string.Empty, string.Empty);
								text = tableItem2.Descs;
							}
						}
					}
					else if (dungeonHellInfo.mode == DungeonHellMode.Hard_Ultimate)
					{
						CommonTipsDesc tableItem3 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5021, string.Empty, string.Empty);
						text = tableItem3.Descs;
					}
					else if (dungeonHellInfo.mode == DungeonHellMode.Hard)
					{
						CommonTipsDesc tableItem4 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5016, string.Empty, string.Empty);
						text = tableItem4.Descs;
					}
					else
					{
						CommonTipsDesc tableItem5 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5017, string.Empty, string.Empty);
						text = tableItem5.Descs;
					}
				}
				else
				{
					CommonTipsDesc tableItem6 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(5015, string.Empty, string.Empty);
					text = tableItem6.Descs;
				}
				if (string.IsNullOrEmpty(text))
				{
					this.mHellState = PVEBattle.eHellProcessState.onHellProcessFinish;
				}
				else
				{
					this._setHellTips(text);
					this.mHellState = PVEBattle.eHellProcessState.onHellTips;
				}
				break;
			}
			case PVEBattle.eHellProcessState.onHellTips:
				this.mWaitOneSeconedCounter -= delta;
				if (this.mWaitOneSeconedCounter < 0)
				{
					this.mWaitOneSeconedCounter += 1000;
					this.mWaitHellTipsTimeCounter--;
					if (this.mWaitHellTipsTimeCounter > 0)
					{
						this._setHellTipsLeftCount(this.mWaitHellTipsTimeCounter);
					}
					else
					{
						this._closeHellTips();
						switch (dungeonHellInfo.state)
						{
						case eDungeonHellState.Start:
							this.mCurrentHellObject.currentStage = 1;
							this.mCurrentHellObject.sgSwitchStates(new BeStateData(0, 0));
							if (this._dropHellWaveMonster(dungeonHellInfo.waveInfos[0], this.mCurrentHellObject.GetPosition()))
							{
								this._setHellInfoState(dungeonHellInfo, eDungeonHellState.Monster1);
								this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleFight;
							}
							else
							{
								this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
							}
							break;
						case eDungeonHellState.Monster1:
							if (dungeonHellInfo.mode == DungeonHellMode.Hard || dungeonHellInfo.mode == DungeonHellMode.Hard_Ultimate)
							{
								if (this._dropHellWaveMonster(dungeonHellInfo.waveInfos[1], this.mCurrentHellObject.GetPosition()))
								{
									this._setHellInfoState(dungeonHellInfo, eDungeonHellState.Monster2Pre);
									this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleFight;
								}
								else
								{
									this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
								}
							}
							else
							{
								dungeonHellInfo.state = eDungeonHellState.Monster2;
								if (this._dropHellWaveMonster(dungeonHellInfo.waveInfos[2], this.mCurrentHellObject.GetPosition()))
								{
									this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleFight;
								}
								else
								{
									this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
								}
							}
							break;
						case eDungeonHellState.Monster2Pre:
							dungeonHellInfo.state = eDungeonHellState.Monster2;
							if (this._dropHellWaveMonster(dungeonHellInfo.waveInfos[2], this.mCurrentHellObject.GetPosition()))
							{
								this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleFight;
							}
							else
							{
								this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
							}
							break;
						}
					}
				}
				break;
			case PVEBattle.eHellProcessState.onHellProcessStart:
				switch (dungeonHellInfo.state)
				{
				case eDungeonHellState.Ready:
					this._setHellInfoState(dungeonHellInfo, eDungeonHellState.Start);
					this.mHellState = PVEBattle.eHellProcessState.onHellTipsInit;
					break;
				case eDungeonHellState.Monster1:
					this.mCurrentHellObject.currentStage = 2;
					this.mCurrentHellObject.sgSwitchStates(new BeStateData(0, 0));
					this.mHellState = PVEBattle.eHellProcessState.onHellTipsInit;
					break;
				case eDungeonHellState.Monster2Pre:
					this.mHellState = PVEBattle.eHellProcessState.onHellTipsInit;
					break;
				case eDungeonHellState.Monster2:
					dungeonHellInfo.state = eDungeonHellState.End;
					beScene.state = BeSceneState.onBulletTime;
					beScene.DropItems(dungeonHellInfo.dropItems, this.mCurrentHellObject.GetPosition(), true, true, null);
					this.mCurrentHellObject.ForceDoDead();
					if (this.mHasHellPlayBGM)
					{
						base.PopBgm();
					}
					this._sendDungeonRewardReq();
					beScene.state = BeSceneState.onFight;
					MonoSingleton<CResPreloader>.instance.RemovePriorityKeys(CResPreloader.PreloadTag.HELL);
					if (this.mHellOpen && base.GetMode() == eDungeonMode.SyncFrame)
					{
						this.mHellState = PVEBattle.eHellProcessState.onHellProcessFinish;
						SystemNotifyManager.SystemNotify(5020, string.Empty);
						this.mHellFinishDurTime = 0;
					}
					else
					{
						this.mHellFinishDurTime = -1;
					}
					break;
				}
				break;
			case PVEBattle.eHellProcessState.onHellProcessBattleFight:
				if (beScene.state == BeSceneState.onFight)
				{
					this.mHellState = PVEBattle.eHellProcessState.onHellProcessBattleClear;
				}
				break;
			case PVEBattle.eHellProcessState.onHellProcessBattleClear:
				if (beScene.state == BeSceneState.onClear)
				{
					this.mHellState = PVEBattle.eHellProcessState.onHellProcessStart;
				}
				break;
			case PVEBattle.eHellProcessState.onHellProcessFinish:
				if (this.mHellFinishDurTime >= 0)
				{
					this.mHellFinishDurTime += delta;
					if (this.mHellFinishDurTime >= 8000)
					{
						this.mHellState = PVEBattle.eHellProcessState.onHellProcessReportFinish;
						if (Singleton<RecordServer>.GetInstance() != null && Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
						{
							Singleton<RecordServer>.GetInstance().EndRecord("HellEnd");
						}
						BeUtility.ResetCamera();
						if (Singleton<NewbieGuideManager>.instance != null)
						{
							Singleton<NewbieGuideManager>.instance.CleanWeakGuide();
						}
						if (Singleton<ClientSystemManager>.instance != null && Singleton<ClientSystemManager>.instance.delayCaller != null)
						{
							Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(10, delegate
							{
								Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
							}, 0, 0, false);
						}
					}
				}
				break;
			}
		}

		// Token: 0x060190A9 RID: 102569 RVA: 0x007D3654 File Offset: 0x007D1A54
		private bool _dropHellWaveMonster(Battle.DungeonHellWaveInfo wave, VInt3 pos)
		{
			if (wave.monsters.Count > 0)
			{
				for (int i = 0; i < wave.monsters.Count; i++)
				{
					int num = base.FrameRandom.InRange(-20000L, 30000L);
					int num2 = base.FrameRandom.InRange(-20000L, 30000L);
					VInt3 pos2 = new VInt3(pos.x + num, pos.y + num2, pos.z);
					pos2 = BeAIManager.FindStandPositionNew(pos2, this.mDungeonManager.GetBeScene(), false, false, 40);
					BeActor beActor = this.mDungeonManager.GetBeScene().CreateRemoteMonster(wave.monsters[i], pos2, VFactor.one, false);
					if (beActor != null)
					{
						if (beActor.GetRecordServer().IsProcessRecord())
						{
							beActor.GetRecordServer().Mark(142120961U, new int[]
							{
								beActor.m_iID,
								pos.x,
								pos.y,
								pos.z,
								pos2.x,
								pos2.y,
								pos2.z
							}, new string[]
							{
								beActor.GetName()
							});
						}
						beActor.StartAI(null, true);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x060190AA RID: 102570 RVA: 0x007D37AA File Offset: 0x007D1BAA
		private bool _setHellInfoState(Battle.DungeonHellInfo info, eDungeonHellState state)
		{
			if (info.state <= state)
			{
				info.state = state;
				return true;
			}
			return false;
		}

		// Token: 0x060190AB RID: 102571 RVA: 0x007D37C2 File Offset: 0x007D1BC2
		private DungeonHellGuideFrame _setHellTips(string text)
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonHellGuideFrame>(null, false);
			this.mHellTipsFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<DungeonHellGuideFrame>(FrameLayer.Middle, null, string.Empty) as DungeonHellGuideFrame);
			this.mHellTipsFrame.SetDescription(text);
			return this.mHellTipsFrame;
		}

		// Token: 0x060190AC RID: 102572 RVA: 0x007D37FE File Offset: 0x007D1BFE
		private void _setHellTipsLeftCount(int count)
		{
			if (this.mHellTipsFrame != null)
			{
				this.mHellTipsFrame.SetLeftCount(count);
			}
		}

		// Token: 0x060190AD RID: 102573 RVA: 0x007D3817 File Offset: 0x007D1C17
		private void _closeHellTips()
		{
			if (this.mHellTipsFrame != null)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonHellGuideFrame>(this.mHellTipsFrame, false);
			}
			this.mHellTipsFrame = null;
		}

		// Token: 0x060190AE RID: 102574 RVA: 0x007D383C File Offset: 0x007D1C3C
		public void SendLimitDungeonFightEnd(bool isSuccess)
		{
			base.FrameRandom.Range100();
			this.m_CanFinishFight = true;
			if (isSuccess)
			{
				this._sendDungeonKillMonsterReq();
				this._sendDungeonRewardReq();
				this._sendDungeonBossRewardReq();
				this._sendDungeonRaceEndReq(false);
			}
			else
			{
				this._sendDungeonRaceEndFail(DungeonScore.C);
			}
			this.mDungeonManager.FinishFight();
		}

		// Token: 0x04011F4D RID: 73549
		protected int thisRoomMonsterCreatedCount;

		// Token: 0x04011F4E RID: 73550
		private DungeonHellGuideFrame mHellTipsFrame;

		// Token: 0x04011F4F RID: 73551
		private PVEBattle.eHellProcessState mHellState;

		// Token: 0x04011F50 RID: 73552
		private BeObject mCurrentHellObject;

		// Token: 0x04011F51 RID: 73553
		private bool mHasHellPlayBGM;

		// Token: 0x04011F52 RID: 73554
		private bool mStarted;

		// Token: 0x04011F53 RID: 73555
		private const int kWaitHellTipsTime = 6;

		// Token: 0x04011F54 RID: 73556
		private int mWaitHellTipsTimeCounter = 6;

		// Token: 0x04011F55 RID: 73557
		private int mWaitOneSeconedCounter = 1000;

		// Token: 0x04011F56 RID: 73558
		private int mHellFinishDurTime = -1;

		// Token: 0x04011F57 RID: 73559
		private bool mHellOpen;

		// Token: 0x04011F58 RID: 73560
		private bool eggRoomOpen = true;

		// Token: 0x04011F59 RID: 73561
		protected bool m_CanFinishFight;

		// Token: 0x04011F5A RID: 73562
		private SimpleTimer2 m_timeLimit;

		// Token: 0x04011F5B RID: 73563
		private const int DELAY_LIMIT_TIME = 5;

		// Token: 0x04011F5C RID: 73564
		protected uint areaIndex;

		// Token: 0x04011F5D RID: 73565
		private Coroutine mDungeonRaceEndReqCoroutine;

		// Token: 0x04011F5E RID: 73566
		private Coroutine mDungeonHellTipCorutine;

		// Token: 0x04011F5F RID: 73567
		private bool isNormalFinsh;

		// Token: 0x04011F60 RID: 73568
		private bool isChapterNoPassed;

		// Token: 0x04011F61 RID: 73569
		private List<BattlePlayer> mCachBeActor = new List<BattlePlayer>();

		// Token: 0x04011F62 RID: 73570
		private int startPassDoor;

		// Token: 0x04011F63 RID: 73571
		private Coroutine mDeadProcess;

		// Token: 0x020045BA RID: 17850
		private enum eHellProcessState
		{
			// Token: 0x04011F66 RID: 73574
			onHellNone,
			// Token: 0x04011F67 RID: 73575
			onHellInit,
			// Token: 0x04011F68 RID: 73576
			onHellTipsInit,
			// Token: 0x04011F69 RID: 73577
			onHellTips,
			// Token: 0x04011F6A RID: 73578
			onWaitHellProcessStart,
			// Token: 0x04011F6B RID: 73579
			onHellProcessStart,
			// Token: 0x04011F6C RID: 73580
			onHellProcessBattleFight,
			// Token: 0x04011F6D RID: 73581
			onHellProcessBattleClear,
			// Token: 0x04011F6E RID: 73582
			onHellProcessFinish,
			// Token: 0x04011F6F RID: 73583
			onHellProcessReportFinish
		}
	}
}
