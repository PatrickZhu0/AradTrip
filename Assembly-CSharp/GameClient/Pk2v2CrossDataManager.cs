using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012BE RID: 4798
	public class Pk2v2CrossDataManager : DataManager<Pk2v2CrossDataManager>
	{
		// Token: 0x0600B978 RID: 47480 RVA: 0x002A9A1A File Offset: 0x002A7E1A
		public List<Pk2v2CrossDataManager.ScoreListItem> GetScoreList()
		{
			return this.m_arrScoreList;
		}

		// Token: 0x17001B56 RID: 6998
		// (get) Token: 0x0600B979 RID: 47481 RVA: 0x002A9A22 File Offset: 0x002A7E22
		public static int MAX_PK_COUNT
		{
			get
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_2V2_SCORE_WAR_PARTAKE_NUM, 0);
			}
		}

		// Token: 0x17001B57 RID: 6999
		// (get) Token: 0x0600B97B RID: 47483 RVA: 0x002A9A38 File Offset: 0x002A7E38
		// (set) Token: 0x0600B97A RID: 47482 RVA: 0x002A9A2F File Offset: 0x002A7E2F
		public Pk2v2CrossDataManager.My2v2PkInfo PkInfo
		{
			get
			{
				if (this.m_pkInfo == null)
				{
					this.m_pkInfo = new Pk2v2CrossDataManager.My2v2PkInfo();
				}
				return this.m_pkInfo;
			}
			set
			{
				this.m_pkInfo = value;
			}
		}

		// Token: 0x0600B97C RID: 47484 RVA: 0x002A9A56 File Offset: 0x002A7E56
		public Pk2v2CrossDataManager.ScoreListItem GetMyRankInfo()
		{
			return this.m_myRankInfo;
		}

		// Token: 0x0600B97D RID: 47485 RVA: 0x002A9A5E File Offset: 0x002A7E5E
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B97E RID: 47486 RVA: 0x002A9A64 File Offset: 0x002A7E64
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600B97F RID: 47487 RVA: 0x002A9AE4 File Offset: 0x002A7EE4
		public override void Clear()
		{
			this.m_arrScoreList = null;
			this.m_pkInfo = null;
			this.bMatching = false;
			this.bOpenNotifyFrame = false;
			this.NotifyCount = 0;
			this.scoreWarStatus = ScoreWar2V2Status.SWS_2V2_INVALID;
			this.scoreWarStateEndTime = 0U;
			this.m_myRankInfo = new Pk2v2CrossDataManager.ScoreListItem();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			this._UnBindNetMsg();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600B980 RID: 47488 RVA: 0x002A9B74 File Offset: 0x002A7F74
		public override void Update(float a_fTime)
		{
		}

		// Token: 0x0600B981 RID: 47489 RVA: 0x002A9B78 File Offset: 0x002A7F78
		public bool CheckPk2v2CrossScence()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Melee2v2Cross)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B982 RID: 47490 RVA: 0x002A9BCC File Offset: 0x002A7FCC
		public void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(602602U, new Action<MsgDATA>(this._OnRankListRes));
				NetProcess.AddMsgHandler(509601U, new Action<MsgDATA>(this.OnScene2V2SyncScoreWarInfo));
				NetProcess.AddMsgHandler(509604U, new Action<MsgDATA>(this.OnScene2V2coreWarRewardRes));
				NetProcess.AddMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
				NetProcess.AddMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600B983 RID: 47491 RVA: 0x002A9C5C File Offset: 0x002A805C
		public void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(602602U, new Action<MsgDATA>(this._OnRankListRes));
			NetProcess.RemoveMsgHandler(509601U, new Action<MsgDATA>(this.OnScene2V2SyncScoreWarInfo));
			NetProcess.RemoveMsgHandler(509604U, new Action<MsgDATA>(this.OnScene2V2coreWarRewardRes));
			NetProcess.RemoveMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
			NetProcess.RemoveMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
			this.m_bNetBind = false;
		}

		// Token: 0x0600B984 RID: 47492 RVA: 0x002A9CDE File Offset: 0x002A80DE
		public bool IsMathcing()
		{
			return this.bMatching;
		}

		// Token: 0x0600B985 RID: 47493 RVA: 0x002A9CE8 File Offset: 0x002A80E8
		private void _onStartBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			if (!this.CheckPk2v2CrossScence())
			{
				return;
			}
			WorldMatchStartRes worldMatchStartRes = new WorldMatchStartRes();
			worldMatchStartRes.decode(a_msgData.bytes);
			if (worldMatchStartRes == null)
			{
				return;
			}
			if (worldMatchStartRes.result != 0U)
			{
				if (worldMatchStartRes.result != 3302003U)
				{
					SystemNotifyManager.SystemNotify((int)worldMatchStartRes.result, string.Empty);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
				return;
			}
			this.bMatching = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossBeginMatchRes, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossBeginMatch, null, null, null, null);
		}

		// Token: 0x0600B986 RID: 47494 RVA: 0x002A9D94 File Offset: 0x002A8194
		private void _onCancelBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			if (!this.CheckPk2v2CrossScence())
			{
				return;
			}
			WorldMatchCancelRes worldMatchCancelRes = new WorldMatchCancelRes();
			worldMatchCancelRes.decode(a_msgData.bytes);
			if (worldMatchCancelRes == null)
			{
				return;
			}
			if (worldMatchCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMatchCancelRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
				return;
			}
			this.bMatching = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossCancelMatchRes, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossCancelMatch, null, null, null, null);
		}

		// Token: 0x0600B987 RID: 47495 RVA: 0x002A9E2C File Offset: 0x002A822C
		private void Swap<T>(ref T x, ref T y)
		{
			T t = x;
			x = y;
			y = t;
		}

		// Token: 0x0600B988 RID: 47496 RVA: 0x002A9E54 File Offset: 0x002A8254
		private void _OnRankListRes(MsgDATA msg)
		{
			WorldSortListRet stream = new WorldSortListRet();
			stream.decode(msg.bytes);
			int num = 0;
			BaseSortList baseSortList = SortListDecoder.Decode(msg.bytes, ref num, msg.bytes.Length, false);
			if (baseSortList == null)
			{
				Logger.LogError("arrRecods decode fail");
				return;
			}
			if (baseSortList.type != SortListType.SORTLIST_2V2_SCORE_WAR)
			{
				return;
			}
			if (this.m_arrScoreList == null)
			{
				this.m_arrScoreList = new List<Pk2v2CrossDataManager.ScoreListItem>();
				if (this.m_arrScoreList == null)
				{
					Logger.LogErrorFormat("new List<ScoreListItem>() error!!!", new object[0]);
					return;
				}
			}
			this.m_arrScoreList.Clear();
			for (int i = 0; i < baseSortList.entries.Count; i++)
			{
				ScoreWarSortListEntry scoreWarSortListEntry = baseSortList.entries[i] as ScoreWarSortListEntry;
				if (scoreWarSortListEntry == null)
				{
					Logger.LogErrorFormat("arrRecods.entries[{0}] error!!!", new object[]
					{
						i
					});
				}
				else
				{
					Pk2v2CrossDataManager.ScoreListItem scoreListItem = new Pk2v2CrossDataManager.ScoreListItem();
					if (scoreListItem == null)
					{
						Logger.LogErrorFormat("new ScoreListItem() error!!!", new object[0]);
					}
					else
					{
						scoreListItem.nPlayerID = scoreWarSortListEntry.id;
						scoreListItem.nPlayerScore = (ulong)scoreWarSortListEntry.score;
						scoreListItem.strPlayerName = scoreWarSortListEntry.name;
						scoreListItem.strServerName = scoreWarSortListEntry.serverName;
						scoreListItem.nRank = scoreWarSortListEntry.ranking;
						this.m_arrScoreList.Add(scoreListItem);
					}
				}
			}
			if (baseSortList.selfEntry == null)
			{
				Logger.LogErrorFormat("arrRecods.selfEntry is null!!!", new object[0]);
			}
			else
			{
				ScoreWarSortListEntry scoreWarSortListEntry2 = baseSortList.selfEntry as ScoreWarSortListEntry;
				if (scoreWarSortListEntry2 != null)
				{
					if (this.m_myRankInfo != null)
					{
						this.m_myRankInfo.nPlayerID = scoreWarSortListEntry2.id;
						this.m_myRankInfo.nPlayerScore = (ulong)scoreWarSortListEntry2.score;
						this.m_myRankInfo.strPlayerName = scoreWarSortListEntry2.name;
						this.m_myRankInfo.strServerName = scoreWarSortListEntry2.serverName;
						this.m_myRankInfo.nRank = scoreWarSortListEntry2.ranking;
					}
				}
				else
				{
					Logger.LogErrorFormat("arrRecods.selfEntry as ScoreWarSortListEntry error!!!", new object[0]);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePk2v2CrossRankScoreList, null, null, null, null);
		}

		// Token: 0x0600B989 RID: 47497 RVA: 0x002AA078 File Offset: 0x002A8478
		public void SwitchToPk2v2CrossScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(true);
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 5008,
				targetDoorID = 0
			}, false));
		}

		// Token: 0x0600B98A RID: 47498 RVA: 0x002AA13C File Offset: 0x002A853C
		private void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x17001B58 RID: 7000
		// (get) Token: 0x0600B98C RID: 47500 RVA: 0x002AA167 File Offset: 0x002A8567
		// (set) Token: 0x0600B98B RID: 47499 RVA: 0x002AA15E File Offset: 0x002A855E
		public int NotifyCount { get; set; }

		// Token: 0x17001B59 RID: 7001
		// (get) Token: 0x0600B98E RID: 47502 RVA: 0x002AA178 File Offset: 0x002A8578
		// (set) Token: 0x0600B98D RID: 47501 RVA: 0x002AA16F File Offset: 0x002A856F
		public bool IsOpenNotifyFrame
		{
			get
			{
				return this.bOpenNotifyFrame;
			}
			set
			{
				this.bOpenNotifyFrame = value;
			}
		}

		// Token: 0x0600B98F RID: 47503 RVA: 0x002AA180 File Offset: 0x002A8580
		public ScoreWar2V2Status Get2v2CrossWarStatus()
		{
			return this.scoreWarStatus;
		}

		// Token: 0x0600B990 RID: 47504 RVA: 0x002AA188 File Offset: 0x002A8588
		public uint Get2v2CrossWarStatusEndTime()
		{
			return this.scoreWarStateEndTime;
		}

		// Token: 0x0600B991 RID: 47505 RVA: 0x002AA190 File Offset: 0x002A8590
		public override void OnApplicationStart()
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kSavePath, out this.jsonText);
			if (this.jsonText == null)
			{
				FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, string.Empty);
				this.jsonText = string.Empty;
				return;
			}
		}

		// Token: 0x0600B992 RID: 47506 RVA: 0x002AA1CC File Offset: 0x002A85CC
		public bool IsIDOpened(ulong id)
		{
			if (string.IsNullOrEmpty(this.jsonText))
			{
				return false;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return false;
			}
			string text = id.ToString();
			return jsonData.ContainsKey(text) && jsonData[text].IsBoolean && (bool)jsonData[text];
		}

		// Token: 0x0600B993 RID: 47507 RVA: 0x002AA23C File Offset: 0x002A863C
		public void ClearIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = false;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600B994 RID: 47508 RVA: 0x002AA2CC File Offset: 0x002A86CC
		public void SetIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = true;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600B995 RID: 47509 RVA: 0x002AA35C File Offset: 0x002A875C
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			string text = uiEvent.Param1 as string;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text == "pvp_2v2_score")
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				pkInfo.nScore = (uint)DataManager<CountDataManager>.GetInstance().GetCount(text);
				DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo = pkInfo;
			}
			else if (text == "pvp_2v2_battle_count")
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo2 = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				pkInfo2.nCurPkCount = Pk2v2CrossDataManager.MAX_PK_COUNT - DataManager<CountDataManager>.GetInstance().GetCount(text);
				DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo = pkInfo2;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossPkAwardInfoUpdate, null, null, null, null);
			}
			else if (text == "pvp_2v2_win_count")
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo3 = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				pkInfo3.nWinCount = (byte)DataManager<CountDataManager>.GetInstance().GetCount(text);
				DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo = pkInfo3;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossPkAwardInfoUpdate, null, null, null, null);
			}
			else if (text == "pvp_2v2_reward_mask")
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo4 = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				List<uint> arrAwardIDs = pkInfo4.arrAwardIDs;
				arrAwardIDs.Clear();
				int count = DataManager<CountDataManager>.GetInstance().GetCount(text);
				BitArray bitArray = new BitArray(BitConverter.GetBytes(count));
				if (bitArray != null)
				{
					int count2 = Singleton<TableManager>.GetInstance().GetTable<ScoreWar2v2RewardTable>().Count;
					uint num = 0U;
					while ((ulong)num < (ulong)((long)bitArray.Length) && (ulong)num < (ulong)((long)count2))
					{
						int id = (int)(num + 1U);
						ScoreWar2v2RewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScoreWar2v2RewardTable>(id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							int rewardId = tableItem.RewardId;
							if (bitArray.Get(rewardId))
							{
								arrAwardIDs.Add((uint)rewardId);
							}
						}
						num += 1U;
					}
				}
				arrAwardIDs.Sort();
				DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo = pkInfo4;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossPkAwardInfoUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600B996 RID: 47510 RVA: 0x002AA564 File Offset: 0x002A8964
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int value = tableItem.Value;
				if (value > 0 && iPreLv < value && iCurLv >= value)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK2V2CrossButton, (byte)DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus(), null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
				}
			}
		}

		// Token: 0x0600B997 RID: 47511 RVA: 0x002AA5E4 File Offset: 0x002A89E4
		private void OnScene2V2SyncScoreWarInfo(MsgDATA msg)
		{
			Scene2V2SyncScoreWarInfo scene2V2SyncScoreWarInfo = new Scene2V2SyncScoreWarInfo();
			scene2V2SyncScoreWarInfo.decode(msg.bytes);
			this.scoreWarStatus = (ScoreWar2V2Status)scene2V2SyncScoreWarInfo.status;
			this.scoreWarStateEndTime = scene2V2SyncScoreWarInfo.statusEndTime;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
			bool flag = scene2V2SyncScoreWarInfo.status >= 1 && scene2V2SyncScoreWarInfo.status < 3;
			if (flag)
			{
				this.NotifyCount++;
			}
			else
			{
				this.NotifyCount = 0;
				this.bOpenNotifyFrame = false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && this.NotifyCount > 0 && !this.bOpenNotifyFrame && !this.IsIDOpened((ulong)ClientApplication.playerinfo.accid))
			{
				this.bOpenNotifyFrame = true;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk2v2CrossOpenNotifyFrame>(FrameLayer.Middle, null, string.Empty);
				this.SetIDOpened((ulong)ClientApplication.playerinfo.accid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK2V2CrossButton, scene2V2SyncScoreWarInfo.status, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK2V2CrossStatusUpdate, null, null, null, null);
			if (this.scoreWarStatus == ScoreWar2V2Status.SWS_2V2_BATTLE && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk2v2CrossWaitingRoomFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk2v2CrossMatchStartNotifyFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (this.scoreWarStatus >= ScoreWar2V2Status.SWS_2V2_WAIT_END)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossCancelMatchRes, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk2v2CrossCancelMatch, null, null, null, null);
			}
			if (this.scoreWarStatus == ScoreWar2V2Status.SWS_2V2_INVALID || this.scoreWarStatus == ScoreWar2V2Status.SWS_2V2_WAIT_END || this.scoreWarStatus == ScoreWar2V2Status.SWS_2V2_MAX)
			{
				this.bOpenNotifyFrame = false;
				this.NotifyCount = 0;
				this.ClearIDOpened((ulong)ClientApplication.playerinfo.accid);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<JoinPk2v2CrossFrame>(null, false);
			}
			if (this.scoreWarStatus >= ScoreWar2V2Status.SWS_2V2_WAIT_END)
			{
				this.bMatching = false;
				this.SendCancelOnePersonMatchGameReq();
			}
		}

		// Token: 0x0600B998 RID: 47512 RVA: 0x002AA814 File Offset: 0x002A8C14
		private void OnScene2V2coreWarRewardRes(MsgDATA msg)
		{
			Scene2V2coreWarRewardRes scene2V2coreWarRewardRes = new Scene2V2coreWarRewardRes();
			scene2V2coreWarRewardRes.decode(msg.bytes);
			if (scene2V2coreWarRewardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)scene2V2coreWarRewardRes.result, string.Empty);
			}
		}

		// Token: 0x0400684F RID: 26703
		private List<Pk2v2CrossDataManager.ScoreListItem> m_arrScoreList;

		// Token: 0x04006850 RID: 26704
		private bool m_bNetBind;

		// Token: 0x04006851 RID: 26705
		private Pk2v2CrossDataManager.My2v2PkInfo m_pkInfo = new Pk2v2CrossDataManager.My2v2PkInfo();

		// Token: 0x04006852 RID: 26706
		public Pk2v2CrossDataManager.ScoreListItem m_myRankInfo = new Pk2v2CrossDataManager.ScoreListItem();

		// Token: 0x04006853 RID: 26707
		private const string key_pvp_2v2_score = "pvp_2v2_score";

		// Token: 0x04006854 RID: 26708
		private const string key_pvp_2v2_battle_count = "pvp_2v2_battle_count";

		// Token: 0x04006855 RID: 26709
		private const string key_pvp_2v2_win_count = "pvp_2v2_win_count";

		// Token: 0x04006856 RID: 26710
		private const string key_pvp_2v2_last_battle_time = "pvp_2v2_last_battle_time";

		// Token: 0x04006857 RID: 26711
		private const string key_pvp_2v2_reward_mask = "pvp_2v2_reward_mask";

		// Token: 0x04006858 RID: 26712
		public bool bMatching;

		// Token: 0x04006859 RID: 26713
		private bool bOpenNotifyFrame;

		// Token: 0x0400685B RID: 26715
		private ScoreWar2V2Status scoreWarStatus;

		// Token: 0x0400685C RID: 26716
		private uint scoreWarStateEndTime;

		// Token: 0x0400685D RID: 26717
		private string m_kSavePath = "2v2CrossOpen.json";

		// Token: 0x0400685E RID: 26718
		private string jsonText;

		// Token: 0x020012BF RID: 4799
		public class ScoreListItem
		{
			// Token: 0x0400685F RID: 26719
			public ulong nPlayerID;

			// Token: 0x04006860 RID: 26720
			public string strPlayerName;

			// Token: 0x04006861 RID: 26721
			public ulong nPlayerScore;

			// Token: 0x04006862 RID: 26722
			public string strServerName;

			// Token: 0x04006863 RID: 26723
			public ushort nRank;
		}

		// Token: 0x020012C0 RID: 4800
		public class My2v2PkInfo
		{
			// Token: 0x04006864 RID: 26724
			public int nCurPkCount;

			// Token: 0x04006865 RID: 26725
			public uint nScore;

			// Token: 0x04006866 RID: 26726
			public byte nWinCount;

			// Token: 0x04006867 RID: 26727
			public List<uint> arrAwardIDs = new List<uint>();
		}
	}
}
