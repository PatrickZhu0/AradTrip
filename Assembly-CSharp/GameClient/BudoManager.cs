using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004554 RID: 17748
	internal class BudoManager : DataManager<BudoManager>
	{
		// Token: 0x06018B90 RID: 101264 RVA: 0x007B9F4C File Offset: 0x007B834C
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.BudoManager;
		}

		// Token: 0x17002028 RID: 8232
		// (get) Token: 0x06018B91 RID: 101265 RVA: 0x007B9F50 File Offset: 0x007B8350
		public static int TicketID
		{
			get
			{
				if (BudoManager.ticketId == 0)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(132, string.Empty, string.Empty);
					if (tableItem != null)
					{
						BudoManager.ticketId = tableItem.Value;
					}
				}
				return BudoManager.ticketId;
			}
		}

		// Token: 0x17002029 RID: 8233
		// (get) Token: 0x06018B92 RID: 101266 RVA: 0x007B9F97 File Offset: 0x007B8397
		public static int ActiveID
		{
			get
			{
				return DataManager<ActiveManager>.GetInstance().BudoActive;
			}
		}

		// Token: 0x1700202A RID: 8234
		// (get) Token: 0x06018B93 RID: 101267 RVA: 0x007B9FA3 File Offset: 0x007B83A3
		public bool NeedHintAddParty
		{
			get
			{
				return this.IsOpen && this.IsLevelFit && this.TotalTimes <= 0 && this.CanParty;
			}
		}

		// Token: 0x1700202B RID: 8235
		// (get) Token: 0x06018B94 RID: 101268 RVA: 0x007B9FDC File Offset: 0x007B83DC
		public bool IsOpen
		{
			get
			{
				bool result = false;
				ActivityInfo activityInfo = null;
				if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
				{
					activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
				}
				if (activityInfo != null)
				{
					result = (activityInfo.state == 1);
				}
				return result;
			}
		}

		// Token: 0x1700202C RID: 8236
		// (get) Token: 0x06018B95 RID: 101269 RVA: 0x007BA02C File Offset: 0x007B842C
		public bool IsLevelFit
		{
			get
			{
				bool result = false;
				ActivityInfo activityInfo = null;
				if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
				{
					activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
				}
				if (activityInfo != null)
				{
					result = (activityInfo.level <= DataManager<PlayerBaseData>.GetInstance().Level);
				}
				return result;
			}
		}

		// Token: 0x1700202D RID: 8237
		// (get) Token: 0x06018B96 RID: 101270 RVA: 0x007BA088 File Offset: 0x007B8488
		public int NeedLv
		{
			get
			{
				ActivityInfo activityInfo = null;
				if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
				{
					activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
				}
				if (activityInfo != null)
				{
					return (int)activityInfo.level;
				}
				return 1;
			}
		}

		// Token: 0x1700202E RID: 8238
		// (get) Token: 0x06018B97 RID: 101271 RVA: 0x007BA0D3 File Offset: 0x007B84D3
		public bool CanParty
		{
			get
			{
				return this.eWudaoStatus == WudaoStatus.WUDAO_STATUS_INIT;
			}
		}

		// Token: 0x1700202F RID: 8239
		// (get) Token: 0x06018B98 RID: 101272 RVA: 0x007BA0DE File Offset: 0x007B84DE
		public bool CanMatch
		{
			get
			{
				return this.eWudaoStatus == WudaoStatus.WUDAO_STATUS_PLAYING;
			}
		}

		// Token: 0x17002030 RID: 8240
		// (get) Token: 0x06018B99 RID: 101273 RVA: 0x007BA0E9 File Offset: 0x007B84E9
		public bool CanOpenMatchFrame
		{
			get
			{
				return this.eWudaoStatus == WudaoStatus.WUDAO_STATUS_PLAYING || this.eWudaoStatus == WudaoStatus.WUDAO_STATUS_COMPLETE;
			}
		}

		// Token: 0x17002031 RID: 8241
		// (get) Token: 0x06018B9A RID: 101274 RVA: 0x007BA103 File Offset: 0x007B8503
		public bool CanAcqured
		{
			get
			{
				return this.eWudaoStatus == WudaoStatus.WUDAO_STATUS_COMPLETE;
			}
		}

		// Token: 0x17002032 RID: 8242
		// (get) Token: 0x06018B9B RID: 101275 RVA: 0x007BA10E File Offset: 0x007B850E
		public int MaxWinTimes
		{
			get
			{
				return this.iMaxWinTimes;
			}
		}

		// Token: 0x17002033 RID: 8243
		// (get) Token: 0x06018B9C RID: 101276 RVA: 0x007BA116 File Offset: 0x007B8516
		public int MaxLoseTimes
		{
			get
			{
				return this.iMaxLoseTimes;
			}
		}

		// Token: 0x17002034 RID: 8244
		// (get) Token: 0x06018B9D RID: 101277 RVA: 0x007BA120 File Offset: 0x007B8520
		public int WinTimes
		{
			get
			{
				CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo("wudao_win");
				if (countInfo != null)
				{
					return (int)countInfo.value;
				}
				return 0;
			}
		}

		// Token: 0x17002035 RID: 8245
		// (get) Token: 0x06018B9E RID: 101278 RVA: 0x007BA14C File Offset: 0x007B854C
		public int LoseTimes
		{
			get
			{
				CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo("wudao_lose");
				if (countInfo != null)
				{
					return (int)countInfo.value;
				}
				return 0;
			}
		}

		// Token: 0x17002036 RID: 8246
		// (get) Token: 0x06018B9F RID: 101279 RVA: 0x007BA178 File Offset: 0x007B8578
		public int TotalTimes
		{
			get
			{
				CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo("wudao_times");
				if (countInfo != null)
				{
					return (int)countInfo.value;
				}
				return 0;
			}
		}

		// Token: 0x17002037 RID: 8247
		// (get) Token: 0x06018BA0 RID: 101280 RVA: 0x007BA1A3 File Offset: 0x007B85A3
		// (set) Token: 0x06018BA1 RID: 101281 RVA: 0x007BA1AB File Offset: 0x007B85AB
		public bool NeedOpenBudoInfoFrame
		{
			get
			{
				return this.bNeedOpenBudoInfoFrame;
			}
			set
			{
				this.bNeedOpenBudoInfoFrame = value;
			}
		}

		// Token: 0x17002038 RID: 8248
		// (get) Token: 0x06018BA2 RID: 101282 RVA: 0x007BA1B4 File Offset: 0x007B85B4
		// (set) Token: 0x06018BA3 RID: 101283 RVA: 0x007BA1BC File Offset: 0x007B85BC
		public int BudoStatus
		{
			get
			{
				return this.iBudoStatus;
			}
			set
			{
				this.iBudoStatus = value;
				this.eWudaoStatus = (WudaoStatus)value;
				if (this.onBudoInfoChanged != null)
				{
					this.onBudoInfoChanged();
				}
			}
		}

		// Token: 0x17002039 RID: 8249
		// (get) Token: 0x06018BA4 RID: 101284 RVA: 0x007BA1E2 File Offset: 0x007B85E2
		public List<BudoAwardTable> BudoJars
		{
			get
			{
				return this.m_akBudoJars;
			}
		}

		// Token: 0x06018BA5 RID: 101285 RVA: 0x007BA1EC File Offset: 0x007B85EC
		public int GetPreJarIdByTimes()
		{
			int result = 0;
			if (this.m_akBudoJars.Count > 0)
			{
				result = this.m_akBudoJars[0].ID;
			}
			int winTimes = this.WinTimes;
			int num = (winTimes <= 0) ? winTimes : (winTimes - 1);
			for (int i = 0; i < this.m_akBudoJars.Count; i++)
			{
				if (num >= this.m_akBudoJars[i].Times && num <= this.m_akBudoJars[i].MaxTimes)
				{
					result = this.m_akBudoJars[i].ID;
					break;
				}
			}
			return result;
		}

		// Token: 0x06018BA6 RID: 101286 RVA: 0x007BA298 File Offset: 0x007B8698
		public ItemData GetPreJarDataByTimes()
		{
			int preJarIdByTimes = this.GetPreJarIdByTimes();
			return DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(preJarIdByTimes);
		}

		// Token: 0x06018BA7 RID: 101287 RVA: 0x007BA2B8 File Offset: 0x007B86B8
		public BudoAwardTable GetJarItemByTimes()
		{
			int jarIdByTimes = this.GetJarIdByTimes();
			return Singleton<TableManager>.GetInstance().GetTableItem<BudoAwardTable>(jarIdByTimes, string.Empty, string.Empty);
		}

		// Token: 0x06018BA8 RID: 101288 RVA: 0x007BA2E4 File Offset: 0x007B86E4
		public BudoAwardTable GetPreJarItemByTimes()
		{
			int preJarIdByTimes = this.GetPreJarIdByTimes();
			return Singleton<TableManager>.GetInstance().GetTableItem<BudoAwardTable>(preJarIdByTimes, string.Empty, string.Empty);
		}

		// Token: 0x06018BA9 RID: 101289 RVA: 0x007BA310 File Offset: 0x007B8710
		public int GetJarIdByTimes()
		{
			int result = 0;
			if (this.m_akBudoJars.Count > 0)
			{
				result = this.m_akBudoJars[0].ID;
			}
			int winTimes = this.WinTimes;
			for (int i = 0; i < this.m_akBudoJars.Count; i++)
			{
				if (winTimes >= this.m_akBudoJars[i].Times && winTimes <= this.m_akBudoJars[i].MaxTimes)
				{
					result = this.m_akBudoJars[i].ID;
					break;
				}
			}
			return result;
		}

		// Token: 0x06018BAA RID: 101290 RVA: 0x007BA3AC File Offset: 0x007B87AC
		public ItemData GetJarDataByTimes()
		{
			int jarIdByTimes = this.GetJarIdByTimes();
			return DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(jarIdByTimes);
		}

		// Token: 0x06018BAB RID: 101291 RVA: 0x007BA3CC File Offset: 0x007B87CC
		public override void Initialize()
		{
			this.RegisterNetHandler();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(131, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.iMaxLoseTimes = tableItem.Value;
			}
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(130, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.iMaxWinTimes = tableItem.Value;
			}
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(132, string.Empty, string.Empty);
			if (tableItem != null)
			{
				BudoManager.ticketId = tableItem.Value;
			}
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(133, string.Empty, string.Empty);
			if (tableItem != null)
			{
				BudoManager.activeId = tableItem.Value;
			}
			this.m_akBudoJars.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BudoAwardTable>();
			if (table != null)
			{
				Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
				while (enumerator.MoveNext())
				{
					List<BudoAwardTable> akBudoJars = this.m_akBudoJars;
					KeyValuePair<int, object> keyValuePair = enumerator.Current;
					akBudoJars.Add(keyValuePair.Value as BudoAwardTable);
				}
				this.m_akBudoJars.Sort((BudoAwardTable x, BudoAwardTable y) => x.Times - y.Times);
			}
		}

		// Token: 0x06018BAC RID: 101292 RVA: 0x007BA523 File Offset: 0x007B8923
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x06018BAD RID: 101293 RVA: 0x007BA546 File Offset: 0x007B8946
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(506709U, new Action<MsgDATA>(this.OnRecvSceneWudaoRewardRes));
			NetProcess.AddMsgHandler(506707U, new Action<MsgDATA>(this.OnRecvSceneWudaoJoinRes));
		}

		// Token: 0x06018BAE RID: 101294 RVA: 0x007BA574 File Offset: 0x007B8974
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(506709U, new Action<MsgDATA>(this.OnRecvSceneWudaoRewardRes));
			NetProcess.RemoveMsgHandler(506707U, new Action<MsgDATA>(this.OnRecvSceneWudaoJoinRes));
		}

		// Token: 0x06018BAF RID: 101295 RVA: 0x007BA5A4 File Offset: 0x007B89A4
		private void _OnCountValueChanged(UIEvent a_event)
		{
			CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(a_event.Param1 as string);
			if (countInfo != null)
			{
				this.OnCountChanged(countInfo);
			}
		}

		// Token: 0x06018BB0 RID: 101296 RVA: 0x007BA5D4 File Offset: 0x007B89D4
		private void OnCountChanged(CounterInfo info)
		{
			if (info.name == "wudao_times")
			{
				this.iTotalTimes = (int)info.value;
			}
			else if (info.name == "wudao_win")
			{
				this.iWinTimes = (int)info.value;
			}
			else
			{
				if (!(info.name == "wudao_lose"))
				{
					return;
				}
				this.iLosTimes = (int)info.value;
			}
			if (this.onBudoInfoChanged != null)
			{
				this.onBudoInfoChanged();
			}
		}

		// Token: 0x06018BB1 RID: 101297 RVA: 0x007BA66C File Offset: 0x007B8A6C
		public void SendAddParty()
		{
			SceneWudaoJoinReq cmd = new SceneWudaoJoinReq();
			NetManager.Instance().SendCommand<SceneWudaoJoinReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06018BB2 RID: 101298 RVA: 0x007BA68C File Offset: 0x007B8A8C
		public void SendMatchParty()
		{
			if (!this.CanMatch)
			{
				return;
			}
			WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
			worldMatchStartReq.type = 3;
			NetManager.Instance().SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMatchStartRes>(delegate(WorldMatchStartRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchStartSuccess, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x06018BB3 RID: 101299 RVA: 0x007BA6F0 File Offset: 0x007B8AF0
		private void OnRecvSceneWudaoJoinRes(MsgDATA msg)
		{
			int num = 0;
			SceneWudaoJoinRes sceneWudaoJoinRes = new SceneWudaoJoinRes();
			sceneWudaoJoinRes.decode(msg.bytes, ref num);
			if (sceneWudaoJoinRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneWudaoJoinRes.result, string.Empty);
			}
			else
			{
				this.GotoPvpBudo();
			}
		}

		// Token: 0x1700203A RID: 8250
		// (get) Token: 0x06018BB4 RID: 101300 RVA: 0x007BA739 File Offset: 0x007B8B39
		// (set) Token: 0x06018BB5 RID: 101301 RVA: 0x007BA741 File Offset: 0x007B8B41
		public bool ReturnFromPk
		{
			get
			{
				return this.bReturnFromPk;
			}
			set
			{
				this.bReturnFromPk = value;
			}
		}

		// Token: 0x1700203B RID: 8251
		// (get) Token: 0x06018BB6 RID: 101302 RVA: 0x007BA74A File Offset: 0x007B8B4A
		// (set) Token: 0x06018BB7 RID: 101303 RVA: 0x007BA752 File Offset: 0x007B8B52
		public PKResult pkResult
		{
			get
			{
				return this.m_ePKResult;
			}
			set
			{
				this.m_ePKResult = value;
			}
		}

		// Token: 0x06018BB8 RID: 101304 RVA: 0x007BA75C File Offset: 0x007B8B5C
		public void TryBeginActive()
		{
			if (this.CanAcqured)
			{
				BudoResultFrame.Open(new BudoResultFrameData
				{
					bOver = true,
					bNeedOpenBudoInfo = true
				});
			}
			else if (!this.IsOpen || this.CanParty)
			{
				BoduInfoFrame.Open(1);
			}
			else
			{
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					SystemNotifyManager.SystemNotify(1104, string.Empty);
					return;
				}
				this.GotoPvpBudo();
			}
		}

		// Token: 0x06018BB9 RID: 101305 RVA: 0x007BA7DC File Offset: 0x007B8BDC
		public void GotoPvpBudo()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (clientSystemTown.CurrentSceneID != tableItem.BudoSceneID && tableItem.BudoSceneID > 0)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
				{
					currSceneID = clientSystemTown.CurrentSceneID,
					currDoorID = 0,
					targetSceneID = tableItem.BudoSceneID,
					targetDoorID = 0
				}, false));
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			}
		}

		// Token: 0x06018BBA RID: 101306 RVA: 0x007BA88C File Offset: 0x007B8C8C
		public void SendSceneWudaoRewardReq()
		{
			SceneWudaoRewardReq cmd = new SceneWudaoRewardReq();
			NetManager.Instance().SendCommand<SceneWudaoRewardReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06018BBB RID: 101307 RVA: 0x007BA8AC File Offset: 0x007B8CAC
		public void OpenBudoPreviewFrame(int iTableID)
		{
			List<ItemData> previewItems = this.GetPreviewItems(iTableID);
			if (previewItems != null && previewItems.Count > 0)
			{
				BudoRewardsFrameData budoRewardsFrameData = new BudoRewardsFrameData();
				budoRewardsFrameData.datas.Clear();
				budoRewardsFrameData.datas.AddRange(previewItems);
				budoRewardsFrameData.bJustPreView = true;
				budoRewardsFrameData.title = TR.Value("budo_award_title0");
				budoRewardsFrameData.ReceiveItemDataModelList = this.GetReceiveItemDataModelList(iTableID);
				BudoRewardsFrame.Open(budoRewardsFrameData);
			}
		}

		// Token: 0x06018BBC RID: 101308 RVA: 0x007BA91C File Offset: 0x007B8D1C
		public List<ReceiveItemDataModel> GetReceiveItemDataModelList(int awardTableId)
		{
			BudoAwardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BudoAwardTable>(awardTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			return CommonUtility.GetReceiveItemDataModelBySplitString(tableItem.GetPreview);
		}

		// Token: 0x06018BBD RID: 101309 RVA: 0x007BA954 File Offset: 0x007B8D54
		public List<ItemData> GetPreviewItems(int iTableID)
		{
			BudoAwardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BudoAwardTable>(iTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			int winTimes = this.WinTimes;
			int num = winTimes - tableItem.Times;
			if (num < 0 || num >= tableItem.JarType.Count)
			{
				return null;
			}
			int a_nID = tableItem.JarType[num];
			List<ItemData> list = new List<ItemData>();
			JarData jarData = DataManager<JarDataManager>.GetInstance().GetJarData(a_nID);
			if (jarData != null)
			{
				for (int i = 0; i < jarData.arrBonusItems.Count; i++)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(jarData.arrBonusItems[i].ItemID, 100, 0);
					if (itemData != null)
					{
						itemData.Count = jarData.arrBonusItems[i].Count;
						list.Add(itemData);
					}
				}
			}
			return list;
		}

		// Token: 0x06018BBE RID: 101310 RVA: 0x007BAA40 File Offset: 0x007B8E40
		private void OnRecvSceneWudaoRewardRes(MsgDATA msg)
		{
			int num = 0;
			SceneWudaoRewardRes sceneWudaoRewardRes = new SceneWudaoRewardRes();
			sceneWudaoRewardRes.decode(msg.bytes, ref num);
			if (sceneWudaoRewardRes.result == 0U)
			{
				List<ItemData> list = new List<ItemData>();
				for (int i = 0; i < sceneWudaoRewardRes.getItems.Length; i++)
				{
					ItemReward itemReward = sceneWudaoRewardRes.getItems[i];
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, 100, 0);
					itemData.Count = (int)itemReward.num;
					list.Add(itemData);
				}
				BudoRewardsFrameData budoRewardsFrameData = new BudoRewardsFrameData();
				budoRewardsFrameData.datas.AddRange(list);
				budoRewardsFrameData.bJustPreView = false;
				budoRewardsFrameData.title = TR.Value("budo_award_title1");
				BudoRewardsFrame.Open(budoRewardsFrameData);
			}
			else
			{
				SystemNotifyManager.SystemNotify((int)sceneWudaoRewardRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BudoRewardReturn, null, null, null, null);
		}

		// Token: 0x06018BBF RID: 101311 RVA: 0x007BAB1C File Offset: 0x007B8F1C
		public bool SendReturnToTownRelation()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
			{
				MonoBehaviour instance = MonoSingleton<GameFrameWork>.instance;
				ClientSystemTown clientSystemTown2 = clientSystemTown;
				SceneParams sceneParams = new SceneParams();
				sceneParams.onSceneLoadFinish = delegate()
				{
					BoduInfoFrame.Open(1);
				};
				instance.StartCoroutine(clientSystemTown2._NetSyncChangeScene(sceneParams, true));
			}
			return true;
		}

		// Token: 0x04011D0F RID: 72975
		private static int ticketId;

		// Token: 0x04011D10 RID: 72976
		private static int activeId;

		// Token: 0x04011D11 RID: 72977
		private int iMaxWinTimes;

		// Token: 0x04011D12 RID: 72978
		private int iMaxLoseTimes;

		// Token: 0x04011D13 RID: 72979
		private int iWinTimes;

		// Token: 0x04011D14 RID: 72980
		private int iLosTimes;

		// Token: 0x04011D15 RID: 72981
		private int iTotalTimes;

		// Token: 0x04011D16 RID: 72982
		private WudaoStatus eWudaoStatus;

		// Token: 0x04011D17 RID: 72983
		private int iBudoStatus;

		// Token: 0x04011D18 RID: 72984
		private bool bNeedOpenBudoInfoFrame;

		// Token: 0x04011D19 RID: 72985
		private List<BudoAwardTable> m_akBudoJars = new List<BudoAwardTable>();

		// Token: 0x04011D1A RID: 72986
		public BudoManager.OnBudoInfoChanged onBudoInfoChanged;

		// Token: 0x04011D1B RID: 72987
		private bool bReturnFromPk;

		// Token: 0x04011D1C RID: 72988
		private PKResult m_ePKResult = PKResult.INVALID;

		// Token: 0x02004555 RID: 17749
		// (Invoke) Token: 0x06018BC5 RID: 101317
		public delegate void OnBudoInfoChanged();
	}
}
