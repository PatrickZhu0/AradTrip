using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012B9 RID: 4793
	internal class SeasonDataManager : DataManager<SeasonDataManager>
	{
		// Token: 0x17001B40 RID: 6976
		// (get) Token: 0x0600B8C6 RID: 47302 RVA: 0x002A542C File Offset: 0x002A382C
		// (set) Token: 0x0600B8C7 RID: 47303 RVA: 0x002A5434 File Offset: 0x002A3834
		public int seasonID { get; private set; }

		// Token: 0x17001B41 RID: 6977
		// (get) Token: 0x0600B8C8 RID: 47304 RVA: 0x002A543D File Offset: 0x002A383D
		// (set) Token: 0x0600B8C9 RID: 47305 RVA: 0x002A5445 File Offset: 0x002A3845
		public int seasonEndTime { get; private set; }

		// Token: 0x17001B42 RID: 6978
		// (get) Token: 0x0600B8CA RID: 47306 RVA: 0x002A544E File Offset: 0x002A384E
		// (set) Token: 0x0600B8CB RID: 47307 RVA: 0x002A5456 File Offset: 0x002A3856
		public int seasonAttrMappedSeasonID { get; set; }

		// Token: 0x17001B43 RID: 6979
		// (get) Token: 0x0600B8CC RID: 47308 RVA: 0x002A545F File Offset: 0x002A385F
		// (set) Token: 0x0600B8CD RID: 47309 RVA: 0x002A5467 File Offset: 0x002A3867
		public int seasonAttrID { get; set; }

		// Token: 0x17001B44 RID: 6980
		// (get) Token: 0x0600B8CE RID: 47310 RVA: 0x002A5470 File Offset: 0x002A3870
		// (set) Token: 0x0600B8CF RID: 47311 RVA: 0x002A5478 File Offset: 0x002A3878
		public int seasonAttrEndTime { get; set; }

		// Token: 0x17001B45 RID: 6981
		// (get) Token: 0x0600B8D0 RID: 47312 RVA: 0x002A5481 File Offset: 0x002A3881
		// (set) Token: 0x0600B8D1 RID: 47313 RVA: 0x002A5489 File Offset: 0x002A3889
		public List<byte> seasonUplevelRecords { get; set; }

		// Token: 0x17001B46 RID: 6982
		// (get) Token: 0x0600B8D2 RID: 47314 RVA: 0x002A5492 File Offset: 0x002A3892
		// (set) Token: 0x0600B8D3 RID: 47315 RVA: 0x002A549A File Offset: 0x002A389A
		public int seasonLevel { get; set; }

		// Token: 0x17001B47 RID: 6983
		// (get) Token: 0x0600B8D4 RID: 47316 RVA: 0x002A54A3 File Offset: 0x002A38A3
		// (set) Token: 0x0600B8D5 RID: 47317 RVA: 0x002A54AB File Offset: 0x002A38AB
		public int seasonOldLevel { get; set; }

		// Token: 0x17001B48 RID: 6984
		// (get) Token: 0x0600B8D6 RID: 47318 RVA: 0x002A54B4 File Offset: 0x002A38B4
		// (set) Token: 0x0600B8D7 RID: 47319 RVA: 0x002A54BC File Offset: 0x002A38BC
		public int seasonStar { get; set; }

		// Token: 0x17001B49 RID: 6985
		// (get) Token: 0x0600B8D8 RID: 47320 RVA: 0x002A54C5 File Offset: 0x002A38C5
		// (set) Token: 0x0600B8D9 RID: 47321 RVA: 0x002A54CD File Offset: 0x002A38CD
		public int seasonOldStar { get; set; }

		// Token: 0x17001B4A RID: 6986
		// (get) Token: 0x0600B8DA RID: 47322 RVA: 0x002A54D6 File Offset: 0x002A38D6
		// (set) Token: 0x0600B8DB RID: 47323 RVA: 0x002A54DE File Offset: 0x002A38DE
		public int seasonExp { get; set; }

		// Token: 0x17001B4B RID: 6987
		// (get) Token: 0x0600B8DC RID: 47324 RVA: 0x002A54E7 File Offset: 0x002A38E7
		// (set) Token: 0x0600B8DD RID: 47325 RVA: 0x002A54EF File Offset: 0x002A38EF
		public int seasonOldExp { get; set; }

		// Token: 0x17001B4C RID: 6988
		// (get) Token: 0x0600B8DE RID: 47326 RVA: 0x002A54F8 File Offset: 0x002A38F8
		// (set) Token: 0x0600B8DF RID: 47327 RVA: 0x002A5500 File Offset: 0x002A3900
		public int seasonRank { get; private set; }

		// Token: 0x0600B8E0 RID: 47328 RVA: 0x002A5509 File Offset: 0x002A3909
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.PkRankData;
		}

		// Token: 0x0600B8E1 RID: 47329 RVA: 0x002A5510 File Offset: 0x002A3910
		public override void Initialize()
		{
			this.seasonID = 1;
			this.seasonEndTime = 0;
			this.seasonLevel = 0;
			this.seasonOldLevel = 0;
			this.seasonStar = 0;
			this.seasonOldStar = 0;
			this.seasonExp = 0;
			this.seasonOldExp = 0;
			this.seasonRank = -1;
			this.seasonAttrMappedSeasonID = 0;
			this.seasonAttrID = 0;
			this.seasonAttrEndTime = 0;
			this._InitSeasonRewards();
			this._InitSeasonAttrs();
			this._BindNetMsg();
			this._BindGameEvent();
		}

		// Token: 0x0600B8E2 RID: 47330 RVA: 0x002A558C File Offset: 0x002A398C
		public override void Clear()
		{
			this.seasonID = 1;
			this.seasonEndTime = 0;
			this.seasonLevel = 0;
			this.seasonOldLevel = 0;
			this.seasonStar = 0;
			this.seasonOldStar = 0;
			this.seasonExp = 0;
			this.seasonOldExp = 0;
			this.seasonRank = -1;
			this.seasonAttrMappedSeasonID = 0;
			this.seasonAttrID = 0;
			this.seasonAttrEndTime = 0;
			this._ClearSeasonRewards();
			this._ClearSeasonAttrs();
			this._UnBindNetMsg();
			this._UnBindGameEvent();
		}

		// Token: 0x0600B8E3 RID: 47331 RVA: 0x002A5605 File Offset: 0x002A3A05
		public int GetMaxRankID()
		{
			return 65000;
		}

		// Token: 0x0600B8E4 RID: 47332 RVA: 0x002A560C File Offset: 0x002A3A0C
		public int GetMinRankID()
		{
			return 14501;
		}

		// Token: 0x0600B8E5 RID: 47333 RVA: 0x002A5614 File Offset: 0x002A3A14
		public void GetPreLevel(int a_nLevel, int a_nStar, int a_nExp, out int a_nPreLevel, out int a_nPreStar, out int a_nPreExp)
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(161, string.Empty, string.Empty).Value;
			a_nPreLevel = a_nLevel;
			a_nPreStar = a_nStar;
			while (a_nExp < value)
			{
				SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nPreLevel, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("赛季段位表 找不到ID：{0}", new object[]
					{
						a_nPreLevel
					});
					break;
				}
				if (a_nLevel == this.GetMaxRankID() && a_nStar > 1)
				{
					a_nPreLevel = a_nLevel;
					a_nPreStar = a_nStar - 1;
				}
				else
				{
					a_nPreLevel = tableItem.PreId;
					a_nPreStar = 0;
				}
				tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nPreLevel, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("赛季段位表 找不到ID：{0}", new object[]
					{
						a_nPreLevel
					});
					break;
				}
				a_nExp += tableItem.MaxExp;
			}
			a_nPreExp = a_nExp - value;
		}

		// Token: 0x0600B8E6 RID: 47334 RVA: 0x002A5710 File Offset: 0x002A3B10
		public string GetRankName(int a_nRankID, bool a_bWithSubName = true)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nRankID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.ID >= this.GetMaxRankID())
			{
				return TR.Value(string.Format("pk_rank_main{0}", (int)tableItem.MainLevel));
			}
			if (a_bWithSubName)
			{
				return string.Format("{0}{1}", TR.Value(string.Format("pk_rank_main{0}", (int)tableItem.MainLevel)), TR.Value(string.Format("pk_rank_sub{0}", tableItem.SmallLevel)));
			}
			return TR.Value(string.Format("pk_rank_main{0}", (int)tableItem.MainLevel));
		}

		// Token: 0x0600B8E7 RID: 47335 RVA: 0x002A57CC File Offset: 0x002A3BCC
		public string GetSimpleRankName(int a_nRankID)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nRankID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return TR.Value(string.Format("pk_rank_simple{0}", (int)tableItem.MainLevel));
			}
			return string.Empty;
		}

		// Token: 0x0600B8E8 RID: 47336 RVA: 0x002A5818 File Offset: 0x002A3C18
		public bool IsBattleFailReduceRank(int a_nRankID)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nRankID, string.Empty, string.Empty);
			return tableItem != null && tableItem.IsFailLevelReduce == 1;
		}

		// Token: 0x0600B8E9 RID: 47337 RVA: 0x002A584C File Offset: 0x002A3C4C
		public PromotionInfo GetPromotionInfo(int a_nRankID, PKResult a_eResult = PKResult.INVALID)
		{
			PromotionInfo promotionInfo = new PromotionInfo();
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nRankID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.IsPromotion == 1)
			{
				string[] array = tableItem.PromotionRule.Split(new char[]
				{
					','
				});
				promotionInfo.nNextSeasonLevel = tableItem.AfterId;
				promotionInfo.nTargetWinCount = int.Parse(array[0]);
				promotionInfo.nTotalCount = int.Parse(array[1]);
				promotionInfo.nCurrentLoseCount = 0;
				promotionInfo.nCurrentWinCount = 0;
				promotionInfo.arrRecords = new List<byte>();
				if (this.seasonUplevelRecords != null)
				{
					for (int i = 0; i < this.seasonUplevelRecords.Count; i++)
					{
						promotionInfo.arrRecords.Add(this.seasonUplevelRecords[i]);
					}
				}
				if (a_eResult != PKResult.INVALID)
				{
					promotionInfo.arrRecords.Add((byte)a_eResult);
				}
				for (int j = 0; j < promotionInfo.arrRecords.Count; j++)
				{
					if (promotionInfo.arrRecords[j] == 1)
					{
						promotionInfo.nCurrentWinCount++;
					}
					else if (promotionInfo.arrRecords[j] == 2 || promotionInfo.arrRecords[j] == 4)
					{
						promotionInfo.nCurrentLoseCount++;
					}
				}
				if (promotionInfo.nCurrentWinCount >= promotionInfo.nTargetWinCount)
				{
					promotionInfo.eState = EPromotionState.Successed;
				}
				else if (promotionInfo.nCurrentLoseCount > promotionInfo.nTotalCount - promotionInfo.nTargetWinCount)
				{
					promotionInfo.eState = EPromotionState.Failed;
				}
				else
				{
					promotionInfo.eState = EPromotionState.Promoting;
				}
			}
			else
			{
				promotionInfo.eState = EPromotionState.Invalid;
			}
			return promotionInfo;
		}

		// Token: 0x0600B8EA RID: 47338 RVA: 0x002A5A00 File Offset: 0x002A3E00
		public bool IsLevelValid(int a_nSeasonLevel)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nSeasonLevel, string.Empty, string.Empty) != null;
		}

		// Token: 0x0600B8EB RID: 47339 RVA: 0x002A5A20 File Offset: 0x002A3E20
		public string GetMainSeasonLevelIcon(int a_nSeasonLevel)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nSeasonLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Icon;
			}
			return string.Empty;
		}

		// Token: 0x0600B8EC RID: 47340 RVA: 0x002A5A58 File Offset: 0x002A3E58
		public string GetMainSeasonLevelSmallIcon(int a_nSeasonLevel)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nSeasonLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.SmallIcon;
			}
			return string.Empty;
		}

		// Token: 0x0600B8ED RID: 47341 RVA: 0x002A5A90 File Offset: 0x002A3E90
		public string GetSubSeasonLevelIcon(int a_nSeasonLevel)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nSeasonLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.SubLevelIcon;
			}
			return string.Empty;
		}

		// Token: 0x0600B8EE RID: 47342 RVA: 0x002A5AC8 File Offset: 0x002A3EC8
		public static IList<int> GetSeasonAttrBuffIDs(int a_nSeasonAttrID)
		{
			SeasonAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonAttrTable>(a_nSeasonAttrID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.BuffIDs;
			}
			return null;
		}

		// Token: 0x0600B8EF RID: 47343 RVA: 0x002A5AF9 File Offset: 0x002A3EF9
		public List<SeasonLevel> GetSeasonRewards()
		{
			return this.m_arrSeasonRewards;
		}

		// Token: 0x0600B8F0 RID: 47344 RVA: 0x002A5B01 File Offset: 0x002A3F01
		public List<SeasonLevel> GetSeasonAttrs()
		{
			return this.m_arrSeasonAttrs;
		}

		// Token: 0x0600B8F1 RID: 47345 RVA: 0x002A5B0C File Offset: 0x002A3F0C
		public SeasonLevel GetSeasonAttr(int a_nSeasonAttrID)
		{
			for (int i = 0; i < this.m_arrSeasonAttrs.Count; i++)
			{
				if (this.m_arrSeasonAttrs[i].attrTable.ID == a_nSeasonAttrID)
				{
					return this.m_arrSeasonAttrs[i];
				}
			}
			return null;
		}

		// Token: 0x0600B8F2 RID: 47346 RVA: 0x002A5B60 File Offset: 0x002A3F60
		public bool IsMainLevelSame(int a_leftSeasonID, int a_rightSeasonID)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_leftSeasonID, string.Empty, string.Empty);
			SeasonLevelTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_rightSeasonID, string.Empty, string.Empty);
			return tableItem != null && tableItem2 != null && tableItem2.MainLevel == tableItem.MainLevel;
		}

		// Token: 0x0600B8F3 RID: 47347 RVA: 0x002A5BBC File Offset: 0x002A3FBC
		public int GetNextAttrID()
		{
			if (this.GetMaxRankID() == this.seasonLevel && this.seasonRank >= 1 && this.seasonRank <= 10)
			{
				SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(this.seasonLevel, string.Empty, string.Empty);
				return tableItem.AttrID + 1;
			}
			SeasonLevelTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(this.seasonLevel, string.Empty, string.Empty);
			return tableItem2.AttrID;
		}

		// Token: 0x0600B8F4 RID: 47348 RVA: 0x002A5C38 File Offset: 0x002A4038
		public void RequestSelfPKRank()
		{
			WorldSortListSelfInfoReq worldSortListSelfInfoReq = new WorldSortListSelfInfoReq();
			worldSortListSelfInfoReq.type = 40;
			NetManager.Instance().SendCommand<WorldSortListSelfInfoReq>(ServerType.GATE_SERVER, worldSortListSelfInfoReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldSortListSelfInfoRet>(delegate(WorldSortListSelfInfoRet msgRet)
			{
				this.seasonRank = (int)msgRet.ranking;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PKSelfLevelUpdated, msgRet.ranking, null, null, null);
			}, false, 15f, null);
		}

		// Token: 0x0600B8F5 RID: 47349 RVA: 0x002A5C80 File Offset: 0x002A4080
		public void RequsetMyPkRecord()
		{
			SceneReplayListReq sceneReplayListReq = new SceneReplayListReq();
			sceneReplayListReq.type = 1;
			NetManager.Instance().SendCommand<SceneReplayListReq>(ServerType.GATE_SERVER, sceneReplayListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneReplayListRes>(delegate(SceneReplayListRes msgRet)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PKMyRecordUpdated, msgRet, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600B8F6 RID: 47350 RVA: 0x002A5CD8 File Offset: 0x002A40D8
		public void RequsetPeakPkRecord()
		{
			SceneReplayListReq sceneReplayListReq = new SceneReplayListReq();
			sceneReplayListReq.type = 2;
			NetManager.Instance().SendCommand<SceneReplayListReq>(ServerType.GATE_SERVER, sceneReplayListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneReplayListRes>(delegate(SceneReplayListRes msgRet)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PKPeakRecordUpdated, msgRet, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600B8F7 RID: 47351 RVA: 0x002A5D30 File Offset: 0x002A4130
		public void NotifyVideoPlayed(ulong a_raceID)
		{
			SceneReplayView sceneReplayView = new SceneReplayView();
			sceneReplayView.raceid = a_raceID;
			NetManager.Instance().SendCommand<SceneReplayView>(ServerType.GATE_SERVER, sceneReplayView);
		}

		// Token: 0x0600B8F8 RID: 47352 RVA: 0x002A5D57 File Offset: 0x002A4157
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(506713U, new Action<MsgDATA>(this._OnNetSeasonStart));
			NetProcess.AddMsgHandler(506705U, new Action<MsgDATA>(this._OnNetPKEnd));
		}

		// Token: 0x0600B8F9 RID: 47353 RVA: 0x002A5D85 File Offset: 0x002A4185
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(506713U, new Action<MsgDATA>(this._OnNetSeasonStart));
			NetProcess.RemoveMsgHandler(506705U, new Action<MsgDATA>(this._OnNetPKEnd));
		}

		// Token: 0x0600B8FA RID: 47354 RVA: 0x002A5DB3 File Offset: 0x002A41B3
		private void _BindGameEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataSeasonChanged));
		}

		// Token: 0x0600B8FB RID: 47355 RVA: 0x002A5DEB File Offset: 0x002A41EB
		private void _UnBindGameEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataSeasonChanged));
		}

		// Token: 0x0600B8FC RID: 47356 RVA: 0x002A5E24 File Offset: 0x002A4224
		private void _OnNetSeasonStart(MsgDATA a_msgData)
		{
			SceneSyncSeasonInfo sceneSyncSeasonInfo = new SceneSyncSeasonInfo();
			sceneSyncSeasonInfo.decode(a_msgData.bytes);
			this.seasonLevel = (int)sceneSyncSeasonInfo.seasonLevel;
			this.seasonStar = (int)sceneSyncSeasonInfo.seasonStar;
			this.seasonExp = (int)sceneSyncSeasonInfo.seasonExp;
			this.m_eSeasonPlayStatus = (SeasonPlayStatus)sceneSyncSeasonInfo.seasonStatus;
			this.seasonID = (int)sceneSyncSeasonInfo.seasonId;
			this.seasonEndTime = (int)sceneSyncSeasonInfo.endTime;
			this.seasonAttrMappedSeasonID = (int)sceneSyncSeasonInfo.seasonAttrLevel;
			this.seasonAttrID = (int)sceneSyncSeasonInfo.seasonAttr;
			this.seasonAttrEndTime = (int)sceneSyncSeasonInfo.seasonAttrEndTime;
			this._TryShowSeasonStart();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SeasonStarted, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PKRankChanged, null, null, null, null);
		}

		// Token: 0x0600B8FD RID: 47357 RVA: 0x002A5EDC File Offset: 0x002A42DC
		private void _OnNetPKEnd(MsgDATA a_msgData)
		{
			SceneMatchPkRaceEnd sceneMatchPkRaceEnd = new SceneMatchPkRaceEnd();
			sceneMatchPkRaceEnd.decode(a_msgData.bytes);
			this.seasonLevel = (int)sceneMatchPkRaceEnd.newSeasonLevel;
			this.seasonOldLevel = (int)sceneMatchPkRaceEnd.oldSeasonLevel;
			this.seasonStar = (int)sceneMatchPkRaceEnd.newSeasonStar;
			this.seasonOldStar = (int)sceneMatchPkRaceEnd.oldSeasonStar;
			this.seasonExp = (int)sceneMatchPkRaceEnd.newSeasonExp;
			this.seasonOldExp = (int)sceneMatchPkRaceEnd.oldSeasonExp;
		}

		// Token: 0x0600B8FE RID: 47358 RVA: 0x002A5F43 File Offset: 0x002A4343
		private void _OnSystemChanged(UIEvent a_event)
		{
			this._TryShowSeasonStart();
		}

		// Token: 0x0600B8FF RID: 47359 RVA: 0x002A5F4C File Offset: 0x002A434C
		private void _OnPlayerDataSeasonChanged(UIEvent a_event)
		{
			SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)a_event.Param1;
			if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_LEVEL || sceneObjectAttr == SceneObjectAttr.SOA_SEASON_STAR || sceneObjectAttr == SceneObjectAttr.SOA_SEASON_EXP)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PKRankChanged, null, null, null, null);
			}
		}

		// Token: 0x0600B900 RID: 47360 RVA: 0x002A5F94 File Offset: 0x002A4394
		private void _TryShowSeasonStart()
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Duel) && this.m_eSeasonPlayStatus > SeasonPlayStatus.SPS_INVALID)
			{
				if (this.m_eSeasonPlayStatus == SeasonPlayStatus.SPS_NEW)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PKSeasonStartFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<PKSeasonStartFrame>(null, false);
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKSeasonStartFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else if (this.m_eSeasonPlayStatus == SeasonPlayStatus.SPS_NEW_ATTR)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PKSeasonAttrChangeFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<PKSeasonAttrChangeFrame>(null, false);
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKSeasonAttrChangeFrame>(FrameLayer.Middle, null, string.Empty);
				}
				this.m_eSeasonPlayStatus = SeasonPlayStatus.SPS_INVALID;
				SceneSeasonPlayStatus sceneSeasonPlayStatus = new SceneSeasonPlayStatus();
				sceneSeasonPlayStatus.seasonId = (uint)this.seasonID;
				NetManager.Instance().SendCommand<SceneSeasonPlayStatus>(ServerType.GATE_SERVER, sceneSeasonPlayStatus);
			}
		}

		// Token: 0x0600B901 RID: 47361 RVA: 0x002A606C File Offset: 0x002A446C
		private void _InitSeasonRewards()
		{
			this.m_arrSeasonRewards.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<SeasonLevelTable>())
			{
				SeasonLevelTable seasonLevelTable = keyValuePair.Value as SeasonLevelTable;
				bool flag = false;
				for (int i = 0; i < this.m_arrSeasonRewards.Count; i++)
				{
					if (this.m_arrSeasonRewards[i].levelTable.MainLevel == seasonLevelTable.MainLevel)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					SeasonLevel seasonLevel = new SeasonLevel();
					seasonLevel.levelTable = seasonLevelTable;
					seasonLevel.attrTable = null;
					seasonLevel.strFormatAttr = string.Empty;
					this.m_arrSeasonRewards.Add(seasonLevel);
				}
			}
		}

		// Token: 0x0600B902 RID: 47362 RVA: 0x002A613B File Offset: 0x002A453B
		private void _ClearSeasonRewards()
		{
			this.m_arrSeasonRewards.Clear();
		}

		// Token: 0x0600B903 RID: 47363 RVA: 0x002A6148 File Offset: 0x002A4548
		private void _InitSeasonAttrs()
		{
			this.m_arrSeasonAttrs.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<SeasonLevelTable>())
			{
				SeasonLevelTable seasonLevelTable = keyValuePair.Value as SeasonLevelTable;
				bool flag = false;
				for (int i = 0; i < this.m_arrSeasonAttrs.Count; i++)
				{
					if (this.m_arrSeasonAttrs[i].levelTable.MainLevel == seasonLevelTable.MainLevel)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					SeasonLevel seasonLevel = new SeasonLevel();
					seasonLevel.levelTable = seasonLevelTable;
					seasonLevel.attrTable = Singleton<TableManager>.GetInstance().GetTableItem<SeasonAttrTable>(seasonLevelTable.AttrID, string.Empty, string.Empty);
					seasonLevel.strFormatAttr = string.Empty;
					for (int j = 0; j < seasonLevel.attrTable.Descs.Count; j++)
					{
						if (j > 0)
						{
							if (j % 4 == 0)
							{
								SeasonLevel seasonLevel2 = seasonLevel;
								seasonLevel2.strFormatAttr += '\n';
							}
							else
							{
								SeasonLevel seasonLevel3 = seasonLevel;
								seasonLevel3.strFormatAttr += ' ';
							}
						}
						SeasonLevel seasonLevel4 = seasonLevel;
						seasonLevel4.strFormatAttr += seasonLevel.attrTable.Descs[j];
					}
					this.m_arrSeasonAttrs.Add(seasonLevel);
				}
			}
			SeasonLevel seasonLevel5 = new SeasonLevel();
			seasonLevel5.levelTable = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(this.GetMaxRankID(), string.Empty, string.Empty);
			seasonLevel5.attrTable = Singleton<TableManager>.GetInstance().GetTableItem<SeasonAttrTable>(seasonLevel5.levelTable.AttrID + 1, string.Empty, string.Empty);
			seasonLevel5.strFormatAttr = string.Empty;
			for (int k = 0; k < seasonLevel5.attrTable.Descs.Count; k++)
			{
				if (k > 0)
				{
					if (k % 4 == 0)
					{
						SeasonLevel seasonLevel6 = seasonLevel5;
						seasonLevel6.strFormatAttr += '\n';
					}
					else
					{
						SeasonLevel seasonLevel7 = seasonLevel5;
						seasonLevel7.strFormatAttr += "  ";
					}
				}
				SeasonLevel seasonLevel8 = seasonLevel5;
				seasonLevel8.strFormatAttr += seasonLevel5.attrTable.Descs[k];
			}
			this.m_arrSeasonAttrs.Add(seasonLevel5);
		}

		// Token: 0x0600B904 RID: 47364 RVA: 0x002A63BE File Offset: 0x002A47BE
		private void _ClearSeasonAttrs()
		{
			this.m_arrSeasonAttrs.Clear();
		}

		// Token: 0x04006832 RID: 26674
		private SeasonPlayStatus m_eSeasonPlayStatus;

		// Token: 0x04006833 RID: 26675
		private List<SeasonLevel> m_arrSeasonRewards = new List<SeasonLevel>();

		// Token: 0x04006834 RID: 26676
		private List<SeasonLevel> m_arrSeasonAttrs = new List<SeasonLevel>();
	}
}
