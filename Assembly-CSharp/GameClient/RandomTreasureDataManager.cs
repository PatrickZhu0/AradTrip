using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012CF RID: 4815
	public class RandomTreasureDataManager : DataManager<RandomTreasureDataManager>
	{
		// Token: 0x17001B64 RID: 7012
		// (get) Token: 0x0600BA7A RID: 47738 RVA: 0x002B12AC File Offset: 0x002AF6AC
		public int Gold_Treasure_Item_Id
		{
			get
			{
				return this.gold_Treasure_Item_Id;
			}
		}

		// Token: 0x17001B65 RID: 7013
		// (get) Token: 0x0600BA7B RID: 47739 RVA: 0x002B12B4 File Offset: 0x002AF6B4
		public int Silver_Treasure_Item_Id
		{
			get
			{
				return this.silver_Treasure_Item_Id;
			}
		}

		// Token: 0x17001B66 RID: 7014
		// (get) Token: 0x0600BA7C RID: 47740 RVA: 0x002B12BC File Offset: 0x002AF6BC
		public ItemSimpleData GoldRaffleMustGetItem
		{
			get
			{
				return this.goldRaffleMustGetItem;
			}
		}

		// Token: 0x17001B67 RID: 7015
		// (get) Token: 0x0600BA7D RID: 47741 RVA: 0x002B12C4 File Offset: 0x002AF6C4
		public ItemSimpleData SilverRaffleMustGetItem
		{
			get
			{
				return this.silverRaffleMustGetItem;
			}
		}

		// Token: 0x17001B68 RID: 7016
		// (get) Token: 0x0600BA7E RID: 47742 RVA: 0x002B12CC File Offset: 0x002AF6CC
		// (set) Token: 0x0600BA7F RID: 47743 RVA: 0x002B12D4 File Offset: 0x002AF6D4
		public bool BSilverRaffleSkipAnim
		{
			get
			{
				return this.bSilverRaffleSkipAnim;
			}
			set
			{
				this.bSilverRaffleSkipAnim = value;
			}
		}

		// Token: 0x0600BA80 RID: 47744 RVA: 0x002B12DD File Offset: 0x002AF6DD
		public override void Initialize()
		{
			this._InitLocalMapData();
			this._BindEvent();
		}

		// Token: 0x0600BA81 RID: 47745 RVA: 0x002B12EB File Offset: 0x002AF6EB
		public override void Clear()
		{
			this.ClearRandomTreasureData();
			this._UnBindEvent();
		}

		// Token: 0x0600BA82 RID: 47746 RVA: 0x002B12F9 File Offset: 0x002AF6F9
		public override void Update(float a_fTime)
		{
			this.mUpdateTimer += a_fTime;
			if (this.mUpdateTimer > this.mUpdateInterval)
			{
				this._InvokePreUIEventInDelayList();
				this.mUpdateTimer = 0f;
			}
		}

		// Token: 0x0600BA83 RID: 47747 RVA: 0x002B132C File Offset: 0x002AF72C
		private void _InvokePreUIEventInDelayList()
		{
			if (this.mDelayRefreshUIEventList != null && this.mDelayRefreshUIEventList.Count > 0)
			{
				RandomTreasureUIEvent randomTreasureUIEvent = this.mDelayRefreshUIEventList[0];
				if (randomTreasureUIEvent != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(randomTreasureUIEvent);
				}
				this.mDelayRefreshUIEventList.RemoveAt(0);
			}
		}

		// Token: 0x0600BA84 RID: 47748 RVA: 0x002B1380 File Offset: 0x002AF780
		private void _BindEvent()
		{
			NetProcess.AddMsgHandler(608206U, new Action<MsgDATA>(this._OnReqOpenDigMapRes));
			NetProcess.AddMsgHandler(608210U, new Action<MsgDATA>(this._OnReqWatchDigSiteRes));
			NetProcess.AddMsgHandler(608212U, new Action<MsgDATA>(this._OnReqOpenDigSiteRes));
			NetProcess.AddMsgHandler(608214U, new Action<MsgDATA>(this._OnReqMapInfoRes));
			NetProcess.AddMsgHandler(608216U, new Action<MsgDATA>(this._OnReqDigRecordRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_DIG, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x0600BA85 RID: 47749 RVA: 0x002B1414 File Offset: 0x002AF814
		private void _UnBindEvent()
		{
			NetProcess.RemoveMsgHandler(608206U, new Action<MsgDATA>(this._OnReqOpenDigMapRes));
			NetProcess.RemoveMsgHandler(608210U, new Action<MsgDATA>(this._OnReqWatchDigSiteRes));
			NetProcess.RemoveMsgHandler(608212U, new Action<MsgDATA>(this._OnReqOpenDigSiteRes));
			NetProcess.RemoveMsgHandler(608214U, new Action<MsgDATA>(this._OnReqMapInfoRes));
			NetProcess.RemoveMsgHandler(608216U, new Action<MsgDATA>(this._OnReqDigRecordRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_DIG, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x0600BA86 RID: 47750 RVA: 0x002B14A8 File Offset: 0x002AF8A8
		private void _InitLocalMapData()
		{
			if (this.mTotalMapModelDic == null)
			{
				this.mTotalMapModelDic = new Dictionary<int, RandomTreasureMapModel>();
			}
			else
			{
				this.mTotalMapModelDic.Clear();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DigMapTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _InitLocalMapData not find digMapTable", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				DigMapTable digMapTable = keyValuePair.Value as DigMapTable;
				RandomTreasureMapModel randomTreasureMapModel = new RandomTreasureMapModel();
				randomTreasureMapModel.mapId = digMapTable.ID;
				randomTreasureMapModel.localMapData = digMapTable;
				if (this.mTotalMapModelDic.ContainsKey(digMapTable.ID))
				{
					this.mTotalMapModelDic[digMapTable.ID].localMapData = digMapTable;
				}
				else
				{
					this.mTotalMapModelDic.Add(digMapTable.ID, randomTreasureMapModel);
				}
			}
			string s = TR.Value("random_treasure_ui_event_delay_interval");
			if (float.TryParse(s, out this.mUpdateInterval))
			{
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(433, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(434, string.Empty, string.Empty);
			if (tableItem != null && tableItem2 != null)
			{
				string ownedItemName = DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(tableItem.Value);
				this.goldRaffleMustGetItem = new ItemSimpleData(tableItem.Value, tableItem2.Value);
				this.goldRaffleMustGetItem.Name = ownedItemName;
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(435, string.Empty, string.Empty);
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(436, string.Empty, string.Empty);
			if (tableItem3 != null && tableItem4 != null)
			{
				string ownedItemName2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(tableItem3.Value);
				this.silverRaffleMustGetItem = new ItemSimpleData(tableItem3.Value, tableItem4.Value);
				this.silverRaffleMustGetItem.Name = ownedItemName2;
			}
			SystemValueTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(431, string.Empty, string.Empty);
			if (tableItem5 != null)
			{
				this.gold_Treasure_Item_Id = tableItem5.Value;
			}
			SystemValueTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(432, string.Empty, string.Empty);
			if (tableItem6 != null)
			{
				this.silver_Treasure_Item_Id = tableItem6.Value;
			}
		}

		// Token: 0x0600BA87 RID: 47751 RVA: 0x002B1704 File Offset: 0x002AFB04
		private void ClearRandomTreasureData()
		{
			if (this.mTotalMapModelDic != null)
			{
				foreach (KeyValuePair<int, RandomTreasureMapModel> keyValuePair in this.mTotalMapModelDic)
				{
					RandomTreasureMapModel value = keyValuePair.Value;
					if (value != null)
					{
						value.Clear();
					}
				}
				this.mTotalMapModelDic.Clear();
			}
			if (this.mTotalMapRecordList != null)
			{
				for (int i = 0; i < this.mTotalMapRecordList.Count; i++)
				{
					RandomTreasureMapRecordModel randomTreasureMapRecordModel = this.mTotalMapRecordList[i];
					if (randomTreasureMapRecordModel != null)
					{
						randomTreasureMapRecordModel.Clear();
					}
				}
				this.mTotalMapRecordList.Clear();
			}
			if (this.mDelayRefreshUIEventList != null)
			{
				this.mDelayRefreshUIEventList.Clear();
			}
			this.goldRaffleMustGetItem = null;
			this.silverRaffleMustGetItem = null;
			this.mUpdateTimer = 0f;
			this.bSilverRaffleSkipAnim = false;
		}

		// Token: 0x0600BA88 RID: 47752 RVA: 0x002B17E4 File Offset: 0x002AFBE4
		private void _OnServerSwitchFunc(ServerSceneFuncSwitch funcSwitch)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureFuncSwitch, funcSwitch.sIsOpen, null, null, null);
		}

		// Token: 0x0600BA89 RID: 47753 RVA: 0x002B1804 File Offset: 0x002AFC04
		private void _OnSyncChangedDigInfo(MsgDATA data)
		{
			WorldDigInfoSync worldDigInfoSync = new WorldDigInfoSync();
			worldDigInfoSync.decode(data.bytes);
			int mapId = (int)worldDigInfoSync.mapId;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnSyncChangedDigInfo mTotalMapModelDic is null");
				return;
			}
			if (!this.mTotalMapModelDic.ContainsKey(mapId))
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncChangedDigInfo local map data is not equal to net data : {0}", new object[]
				{
					mapId
				});
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
			if (randomTreasureMapModel == null || randomTreasureMapModel.mapTotalDigSites == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncChangedDigInfo mTotalMapModelDic key {0} , obj is null", new object[]
				{
					mapId
				});
				return;
			}
			DigInfo info = worldDigInfoSync.info;
			if (info == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncChangedDigInfo ServerData is ERROR", new object[0]);
				return;
			}
			RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = null;
			for (int i = 0; i < randomTreasureMapModel.mapTotalDigSites.Count; i++)
			{
				randomTreasureMapDigSiteModel = randomTreasureMapModel.mapTotalDigSites[i];
				if (randomTreasureMapDigSiteModel != null)
				{
					if ((long)randomTreasureMapDigSiteModel.index == (long)((ulong)info.index))
					{
						this._DigSiteNetDataToLocalData(randomTreasureMapDigSiteModel, info, mapId);
						break;
					}
				}
			}
			if (randomTreasureMapDigSiteModel != null)
			{
				int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				RandomTreasureUIEvent randomTreasureUIEvent = new RandomTreasureUIEvent(serverTime);
				randomTreasureUIEvent.EventID = EUIEventID.OnTreasureDigSiteChanged;
				randomTreasureUIEvent.Param1 = randomTreasureMapDigSiteModel;
				if (this.mDelayRefreshUIEventList != null)
				{
					this.mDelayRefreshUIEventList.Add(randomTreasureUIEvent);
				}
			}
		}

		// Token: 0x0600BA8A RID: 47754 RVA: 0x002B196C File Offset: 0x002AFD6C
		private void _OnSyncResetDigInfos(MsgDATA data)
		{
			WorldDigRefreshSync worldDigRefreshSync = new WorldDigRefreshSync();
			worldDigRefreshSync.decode(data.bytes);
			int mapId = (int)worldDigRefreshSync.mapId;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnSyncResetDigInfos mTotalMapModelDic is null");
				return;
			}
			if (!this.mTotalMapModelDic.ContainsKey(mapId))
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncResetDigInfos local map data is not equal to net data : {0}", new object[]
				{
					mapId
				});
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
			if (randomTreasureMapModel == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncResetDigInfos mTotalMapModelDic key {0} , obj is null", new object[]
				{
					mapId
				});
				return;
			}
			if (randomTreasureMapModel.mapTotalDigSites == null)
			{
				randomTreasureMapModel.mapTotalDigSites = new List<RandomTreasureMapDigSiteModel>();
			}
			else
			{
				randomTreasureMapModel.mapTotalDigSites.Clear();
			}
			for (int i = 0; i < worldDigRefreshSync.infos.Length; i++)
			{
				DigInfo netDigBaseSite = worldDigRefreshSync.infos[i];
				RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = new RandomTreasureMapDigSiteModel();
				this._DigSiteNetDataToLocalData(randomTreasureMapDigSiteModel, netDigBaseSite, mapId);
				randomTreasureMapModel.mapTotalDigSites.Add(randomTreasureMapDigSiteModel);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureMapDigReset, randomTreasureMapModel, null, null, null);
		}

		// Token: 0x0600BA8B RID: 47755 RVA: 0x002B1A7C File Offset: 0x002AFE7C
		private void _OnReqOpenDigMapRes(MsgDATA data)
		{
			WorldDigMapOpenRes worldDigMapOpenRes = new WorldDigMapOpenRes();
			worldDigMapOpenRes.decode(data.bytes);
			if (worldDigMapOpenRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldDigMapOpenRes.result, string.Empty);
				return;
			}
			int mapId = (int)worldDigMapOpenRes.mapId;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnReqOpenDigMapRes mTotalMapModelDic is null");
				return;
			}
			if (!this.mTotalMapModelDic.ContainsKey(mapId))
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnReqOpenDigMapRes local map data is not equal to net data : {0}", new object[]
				{
					mapId
				});
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
			if (randomTreasureMapModel == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnReqOpenDigMapRes mTotalMapModelDic key {0} , obj is null", new object[]
				{
					mapId
				});
				return;
			}
			if (randomTreasureMapModel.mapTotalDigSites == null)
			{
				randomTreasureMapModel.mapTotalDigSites = new List<RandomTreasureMapDigSiteModel>();
			}
			else
			{
				randomTreasureMapModel.mapTotalDigSites.Clear();
			}
			for (int i = 0; i < worldDigMapOpenRes.infos.Length; i++)
			{
				DigInfo netDigBaseSite = worldDigMapOpenRes.infos[i];
				RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = new RandomTreasureMapDigSiteModel();
				this._DigSiteNetDataToLocalData(randomTreasureMapDigSiteModel, netDigBaseSite, mapId);
				randomTreasureMapModel.mapTotalDigSites.Add(randomTreasureMapDigSiteModel);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOpenTreasureDigMap, randomTreasureMapModel, null, null, null);
		}

		// Token: 0x0600BA8C RID: 47756 RVA: 0x002B1BA8 File Offset: 0x002AFFA8
		private void _OnReqWatchDigSiteRes(MsgDATA data)
		{
			WorldDigWatchRes worldDigWatchRes = new WorldDigWatchRes();
			worldDigWatchRes.decode(data.bytes);
			if (worldDigWatchRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldDigWatchRes.result, string.Empty);
				return;
			}
			int mapId = (int)worldDigWatchRes.mapId;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnReqWatchDigSiteRes mTotalMapModelDic is null");
				return;
			}
			if (!this.mTotalMapModelDic.ContainsKey(mapId))
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnReqWatchDigSiteRes local map data is not equal to net data : {0}", new object[]
				{
					mapId
				});
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
			if (randomTreasureMapModel == null || randomTreasureMapModel.mapTotalDigSites == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnReqWatchDigSiteRes mTotalMapModelDic key {0} , obj is null", new object[]
				{
					mapId
				});
				return;
			}
			DigDetailInfo info = worldDigWatchRes.info;
			if (info == null || info.simpleInfo == null || info.digItems == null || worldDigWatchRes.index != info.simpleInfo.index)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnReqWatchDigSiteRes ServerData is ERROR", new object[0]);
				return;
			}
			RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = null;
			for (int i = 0; i < randomTreasureMapModel.mapTotalDigSites.Count; i++)
			{
				randomTreasureMapDigSiteModel = randomTreasureMapModel.mapTotalDigSites[i];
				if (randomTreasureMapDigSiteModel != null)
				{
					if ((long)randomTreasureMapDigSiteModel.index == (long)((ulong)worldDigWatchRes.index))
					{
						this._DigSiteNetDataToLocalData(randomTreasureMapDigSiteModel, info, mapId);
						break;
					}
				}
			}
			if (randomTreasureMapDigSiteModel != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnWatchTreasureDigSite, randomTreasureMapDigSiteModel, null, null, null);
			}
		}

		// Token: 0x0600BA8D RID: 47757 RVA: 0x002B1D2C File Offset: 0x002B012C
		private void _OnReqOpenDigSiteRes(MsgDATA data)
		{
			WorldDigOpenRes worldDigOpenRes = new WorldDigOpenRes();
			worldDigOpenRes.decode(data.bytes);
			if (worldDigOpenRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldDigOpenRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureRaffleEnd, false, false, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOpenTreasureDigSite, (int)worldDigOpenRes.itemIndex, (int)worldDigOpenRes.itemId, (int)worldDigOpenRes.itemNum, null);
		}

		// Token: 0x0600BA8E RID: 47758 RVA: 0x002B1DB8 File Offset: 0x002B01B8
		private void _DigSiteNetDataToLocalData(RandomTreasureMapDigSiteModel localDigSite, DigInfo netDigBaseSite, int mapId)
		{
			if (localDigSite == null)
			{
				return;
			}
			if (netDigBaseSite == null)
			{
				return;
			}
			localDigSite.mapId = mapId;
			localDigSite.index = (int)netDigBaseSite.index;
			localDigSite.type = (DigType)netDigBaseSite.type;
			localDigSite.status = (DigStatus)netDigBaseSite.status;
			localDigSite.refreshTime = netDigBaseSite.refreshTime;
			localDigSite.changeStatusTime = netDigBaseSite.changeStatusTime;
			ItemSimpleData openItem = this._GetItemSimpleDataByItemId((int)netDigBaseSite.openItemId, (int)netDigBaseSite.openItemNum);
			localDigSite.openItem = openItem;
		}

		// Token: 0x0600BA8F RID: 47759 RVA: 0x002B1E30 File Offset: 0x002B0230
		private void _DigSiteNetDataToLocalData(RandomTreasureMapDigSiteModel localDigSite, DigDetailInfo netDigDetailSite, int mapId)
		{
			if (localDigSite == null)
			{
				return;
			}
			if (netDigDetailSite == null)
			{
				return;
			}
			if (netDigDetailSite.simpleInfo == null)
			{
				return;
			}
			localDigSite.mapId = mapId;
			localDigSite.type = (DigType)netDigDetailSite.simpleInfo.type;
			localDigSite.status = (DigStatus)netDigDetailSite.simpleInfo.status;
			localDigSite.refreshTime = netDigDetailSite.simpleInfo.refreshTime;
			localDigSite.changeStatusTime = netDigDetailSite.simpleInfo.changeStatusTime;
			localDigSite.openItem = this._GetItemSimpleDataByItemId((int)netDigDetailSite.simpleInfo.openItemId, (int)netDigDetailSite.simpleInfo.openItemNum);
			DigItemInfo[] digItems = netDigDetailSite.digItems;
			if (digItems == null)
			{
				return;
			}
			List<ItemSimpleData> list = new List<ItemSimpleData>();
			foreach (DigItemInfo digItemInfo in digItems)
			{
				if (digItemInfo != null)
				{
					ItemSimpleData item = this._GetItemSimpleDataByItemId((int)digItemInfo.itemId, (int)digItemInfo.itemNum);
					list.Add(item);
				}
			}
			localDigSite.itemSDatas = list;
		}

		// Token: 0x0600BA90 RID: 47760 RVA: 0x002B1F20 File Offset: 0x002B0320
		private ItemSimpleData _GetItemSimpleDataByItemId(int itemId, int itemCount = 1)
		{
			ItemSimpleData itemSimpleData = new ItemSimpleData(itemId, itemCount);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return itemSimpleData;
			}
			itemSimpleData.Name = tableItem.Name;
			return itemSimpleData;
		}

		// Token: 0x0600BA91 RID: 47761 RVA: 0x002B1F60 File Offset: 0x002B0360
		private void _OnSyncMapPlayerNum(MsgDATA data)
		{
			WorldDigPlayerSizeSync worldDigPlayerSizeSync = new WorldDigPlayerSizeSync();
			worldDigPlayerSizeSync.decode(data.bytes);
			int mapId = (int)worldDigPlayerSizeSync.mapId;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnSyncMapPlayerNum mTotalMapModelDic is null");
				return;
			}
			if (!this.mTotalMapModelDic.ContainsKey(mapId))
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncMapPlayerNum local map data is not equal to net data : {0}", new object[]
				{
					mapId
				});
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
			if (randomTreasureMapModel == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - _OnSyncMapPlayerNum mTotalMapModelDic key {0} , obj is null", new object[]
				{
					mapId
				});
				return;
			}
			randomTreasureMapModel.beInPlayerNum = (int)worldDigPlayerSizeSync.playerSize;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureMapPlayerNumSync, randomTreasureMapModel, null, null, null);
		}

		// Token: 0x0600BA92 RID: 47762 RVA: 0x002B2014 File Offset: 0x002B0414
		private void _OnReqMapInfoRes(MsgDATA data)
		{
			WorldDigMapInfoRes worldDigMapInfoRes = new WorldDigMapInfoRes();
			worldDigMapInfoRes.decode(data.bytes);
			if (worldDigMapInfoRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldDigMapInfoRes.result, string.Empty);
				return;
			}
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnReqMapInfoRes mTotalMapModelDic is null");
				return;
			}
			DigMapInfo[] digMapInfos = worldDigMapInfoRes.digMapInfos;
			if (digMapInfos == null || digMapInfos.Length == 0)
			{
				Logger.LogError("[RandomTreasureDataManager] - _OnReqMapInfoRes server digMapInfos is null");
				return;
			}
			foreach (DigMapInfo digMapInfo in digMapInfos)
			{
				if (digMapInfo != null)
				{
					int mapId = (int)digMapInfo.mapId;
					int goldDigSize = (int)digMapInfo.goldDigSize;
					int silverDigSize = (int)digMapInfo.silverDigSize;
					RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[mapId];
					if (randomTreasureMapModel != null)
					{
						randomTreasureMapModel.goldSiteNum = goldDigSize;
						randomTreasureMapModel.silverSiteNum = silverDigSize;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureAtlasInfoSync, null, null, null, null);
		}

		// Token: 0x0600BA93 RID: 47763 RVA: 0x002B20FC File Offset: 0x002B04FC
		private void _OnSyncDigRecordInfo(MsgDATA data)
		{
			WorldDigRecordInfoSync worldDigRecordInfoSync = new WorldDigRecordInfoSync();
			worldDigRecordInfoSync.decode(data.bytes);
			DigRecordInfo info = worldDigRecordInfoSync.info;
			if (this.mTotalMapRecordList == null)
			{
				return;
			}
			if (info == null)
			{
				return;
			}
			RandomTreasureMapRecordModel randomTreasureMapRecordModel = new RandomTreasureMapRecordModel();
			randomTreasureMapRecordModel.mapId = (int)info.mapId;
			if (this.mTotalMapModelDic != null && this.mTotalMapModelDic.ContainsKey(randomTreasureMapRecordModel.mapId))
			{
				RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[randomTreasureMapRecordModel.mapId];
				if (randomTreasureMapModel != null && randomTreasureMapModel.localMapData != null)
				{
					randomTreasureMapRecordModel.mapName = randomTreasureMapModel.localMapData.Name;
				}
			}
			randomTreasureMapRecordModel.digIndex = (int)info.digIndex;
			randomTreasureMapRecordModel.digType = (DigType)info.type;
			randomTreasureMapRecordModel.playerId = info.playerId;
			randomTreasureMapRecordModel.playerName = info.playerName;
			if (this._NeedFilterRecordInfoByItemQuality((int)info.itemId))
			{
				return;
			}
			randomTreasureMapRecordModel.itemSData = this._GetItemSimpleDataByItemId((int)info.itemId, (int)info.itemNum);
			this.mTotalMapRecordList.Add(randomTreasureMapRecordModel);
			int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			RandomTreasureUIEvent randomTreasureUIEvent = new RandomTreasureUIEvent(serverTime);
			randomTreasureUIEvent.EventID = EUIEventID.OnTreasureRecordInfoChanged;
			if (this.mDelayRefreshUIEventList != null)
			{
				this.mDelayRefreshUIEventList.Add(randomTreasureUIEvent);
			}
		}

		// Token: 0x0600BA94 RID: 47764 RVA: 0x002B223C File Offset: 0x002B063C
		private void _OnReqDigRecordRes(MsgDATA data)
		{
			WorldDigRecordsRes worldDigRecordsRes = new WorldDigRecordsRes();
			worldDigRecordsRes.decode(data.bytes);
			DigRecordInfo[] infos = worldDigRecordsRes.infos;
			if (this.mTotalMapRecordList == null)
			{
				return;
			}
			this.mTotalMapRecordList.Clear();
			if (infos == null)
			{
				return;
			}
			foreach (DigRecordInfo digRecordInfo in infos)
			{
				if (infos != null)
				{
					RandomTreasureMapRecordModel randomTreasureMapRecordModel = new RandomTreasureMapRecordModel();
					randomTreasureMapRecordModel.mapId = (int)digRecordInfo.mapId;
					if (this.mTotalMapModelDic != null && this.mTotalMapModelDic.ContainsKey(randomTreasureMapRecordModel.mapId))
					{
						RandomTreasureMapModel randomTreasureMapModel = this.mTotalMapModelDic[randomTreasureMapRecordModel.mapId];
						if (randomTreasureMapModel != null && randomTreasureMapModel.localMapData != null)
						{
							randomTreasureMapRecordModel.mapName = randomTreasureMapModel.localMapData.Name;
						}
					}
					randomTreasureMapRecordModel.digIndex = (int)digRecordInfo.digIndex;
					randomTreasureMapRecordModel.digType = (DigType)digRecordInfo.type;
					randomTreasureMapRecordModel.playerId = digRecordInfo.playerId;
					randomTreasureMapRecordModel.playerName = digRecordInfo.playerName;
					if (!this._NeedFilterRecordInfoByItemQuality((int)digRecordInfo.itemId))
					{
						randomTreasureMapRecordModel.itemSData = this._GetItemSimpleDataByItemId((int)digRecordInfo.itemId, (int)digRecordInfo.itemNum);
						this.mTotalMapRecordList.Add(randomTreasureMapRecordModel);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureRecordInfoSync, null, null, null, null);
		}

		// Token: 0x0600BA95 RID: 47765 RVA: 0x002B2398 File Offset: 0x002B0798
		private void _OnMallBuyRes(MsgDATA data)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(data.bytes);
			if (worldMallBuyRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMallBuyRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureItemBuyRes, null, null, null, null);
			}
		}

		// Token: 0x0600BA96 RID: 47766 RVA: 0x002B23EC File Offset: 0x002B07EC
		private bool _NeedFilterRecordInfoByItemQuality(int itemId)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemId, 100, 0);
			return itemData.Quality <= this.mFilterRecordByQuality;
		}

		// Token: 0x0600BA97 RID: 47767 RVA: 0x002B2417 File Offset: 0x002B0817
		public bool _NeedFilterRecordInfoByItemQuality(ItemData itemData)
		{
			return itemData == null || itemData.Quality <= this.mFilterRecordByQuality;
		}

		// Token: 0x0600BA98 RID: 47768 RVA: 0x002B2435 File Offset: 0x002B0835
		public Dictionary<int, RandomTreasureMapModel> GetTotalMapModelDic()
		{
			return this.mTotalMapModelDic;
		}

		// Token: 0x0600BA99 RID: 47769 RVA: 0x002B2440 File Offset: 0x002B0840
		public List<RandomTreasureMapModel> GetTotalMapModelList()
		{
			if (this.mTotalMapModelDic == null)
			{
				return null;
			}
			List<RandomTreasureMapModel> list = new List<RandomTreasureMapModel>();
			foreach (KeyValuePair<int, RandomTreasureMapModel> keyValuePair in this.mTotalMapModelDic)
			{
				RandomTreasureMapModel value = keyValuePair.Value;
				if (value != null)
				{
					list.Add(value);
				}
			}
			return list;
		}

		// Token: 0x0600BA9A RID: 47770 RVA: 0x002B249C File Offset: 0x002B089C
		public List<RandomTreasureMapModel> GetFilterMapModelList(RandomTreasureMapModel currMapModel)
		{
			if (this.mTotalMapModelDic == null)
			{
				return null;
			}
			List<RandomTreasureMapModel> list = new List<RandomTreasureMapModel>();
			foreach (KeyValuePair<int, RandomTreasureMapModel> keyValuePair in this.mTotalMapModelDic)
			{
				RandomTreasureMapModel value = keyValuePair.Value;
				if (value != null)
				{
					if (currMapModel == null || value.mapId != currMapModel.mapId)
					{
						list.Add(value);
					}
				}
			}
			return list;
		}

		// Token: 0x0600BA9B RID: 47771 RVA: 0x002B2514 File Offset: 0x002B0914
		public List<RandomTreasureMapModel> GetTreasureTypeMapModelList(DigType type, bool needFiler = false, RandomTreasureMapModel currMapModel = null)
		{
			if (this.mTotalMapModelDic == null)
			{
				return null;
			}
			List<RandomTreasureMapModel> list = new List<RandomTreasureMapModel>();
			foreach (KeyValuePair<int, RandomTreasureMapModel> keyValuePair in this.mTotalMapModelDic)
			{
				RandomTreasureMapModel value = keyValuePair.Value;
				if (value != null)
				{
					if (!needFiler || currMapModel == null || currMapModel.mapId != value.mapId)
					{
						if (type != DigType.DIG_GLOD)
						{
							if (type == DigType.DIG_SILVER)
							{
								if (value.silverSiteNum > 0)
								{
									list.Add(value);
								}
							}
						}
						else if (value.goldSiteNum > 0)
						{
							list.Add(value);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BA9C RID: 47772 RVA: 0x002B25D4 File Offset: 0x002B09D4
		public int GetFirstMapId()
		{
			int result = 0;
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - GetMapModelByMapId , mTotalMapModelDic is null");
				return result;
			}
			Dictionary<int, RandomTreasureMapModel>.KeyCollection.Enumerator enumerator = this.mTotalMapModelDic.Keys.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return result;
			}
			return enumerator.Current;
		}

		// Token: 0x0600BA9D RID: 47773 RVA: 0x002B2628 File Offset: 0x002B0A28
		public RandomTreasureMapModel GetMapModelByMapId(int mapId)
		{
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - GetMapModelByMapId , mTotalMapModelDic is null");
				return null;
			}
			RandomTreasureMapModel result = null;
			this.mTotalMapModelDic.TryGetValue(mapId, out result);
			return result;
		}

		// Token: 0x0600BA9E RID: 47774 RVA: 0x002B2660 File Offset: 0x002B0A60
		public RandomTreasureMapDigSiteModel GetMapSiteModelByMapIdAndSiteIndex(int mapId, int mapSiteIndex)
		{
			if (this.mTotalMapModelDic == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - GetMapSiteModelByMapIdAndSiteIndex , mTotalMapModelDic is null");
				return null;
			}
			RandomTreasureMapDigSiteModel result = null;
			RandomTreasureMapModel randomTreasureMapModel = null;
			this.mTotalMapModelDic.TryGetValue(mapId, out randomTreasureMapModel);
			if (randomTreasureMapModel != null)
			{
				List<RandomTreasureMapDigSiteModel> mapTotalDigSites = randomTreasureMapModel.mapTotalDigSites;
				if (mapTotalDigSites == null)
				{
					return result;
				}
				for (int i = 0; i < mapTotalDigSites.Count; i++)
				{
					if (mapTotalDigSites[i].index == mapSiteIndex)
					{
						return mapTotalDigSites[i];
					}
				}
			}
			return result;
		}

		// Token: 0x0600BA9F RID: 47775 RVA: 0x002B26DE File Offset: 0x002B0ADE
		public List<RandomTreasureMapRecordModel> GetMapRecordInfoList()
		{
			return this.mTotalMapRecordList;
		}

		// Token: 0x0600BAA0 RID: 47776 RVA: 0x002B26E8 File Offset: 0x002B0AE8
		public void AddNetEventListener()
		{
			NetProcess.AddMsgHandler(608201U, new Action<MsgDATA>(this._OnSyncChangedDigInfo));
			NetProcess.AddMsgHandler(608202U, new Action<MsgDATA>(this._OnSyncResetDigInfos));
			NetProcess.AddMsgHandler(608203U, new Action<MsgDATA>(this._OnSyncMapPlayerNum));
			NetProcess.AddMsgHandler(608204U, new Action<MsgDATA>(this._OnSyncDigRecordInfo));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this._OnMallBuyRes));
		}

		// Token: 0x0600BAA1 RID: 47777 RVA: 0x002B2764 File Offset: 0x002B0B64
		public void RemoveNetEventListener()
		{
			NetProcess.RemoveMsgHandler(608201U, new Action<MsgDATA>(this._OnSyncChangedDigInfo));
			NetProcess.RemoveMsgHandler(608202U, new Action<MsgDATA>(this._OnSyncResetDigInfos));
			NetProcess.RemoveMsgHandler(608203U, new Action<MsgDATA>(this._OnSyncMapPlayerNum));
			NetProcess.RemoveMsgHandler(608204U, new Action<MsgDATA>(this._OnSyncDigRecordInfo));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this._OnMallBuyRes));
		}

		// Token: 0x0600BAA2 RID: 47778 RVA: 0x002B27E0 File Offset: 0x002B0BE0
		public void ReqOpenFirstTreasureMap()
		{
			int firstMapId = this.GetFirstMapId();
			if (firstMapId < 1)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - ReqOpenFirstTreasureMap firstId < 1", new object[]
				{
					firstMapId
				});
				return;
			}
			WorldDigMapOpenReq worldDigMapOpenReq = new WorldDigMapOpenReq();
			worldDigMapOpenReq.mapId = (uint)firstMapId;
			NetManager.Instance().SendCommand<WorldDigMapOpenReq>(ServerType.GATE_SERVER, worldDigMapOpenReq);
		}

		// Token: 0x0600BAA3 RID: 47779 RVA: 0x002B2830 File Offset: 0x002B0C30
		public void ReqOpenTreasureMap(int mapId)
		{
			if (this.GetMapModelByMapId(mapId) == null)
			{
				Logger.LogErrorFormat("[RandomTreasureDataManager] - ReqOpenTreasureMap data is null, mapid is {0}", new object[]
				{
					mapId
				});
				return;
			}
			WorldDigMapOpenReq worldDigMapOpenReq = new WorldDigMapOpenReq();
			worldDigMapOpenReq.mapId = (uint)mapId;
			NetManager.Instance().SendCommand<WorldDigMapOpenReq>(ServerType.GATE_SERVER, worldDigMapOpenReq);
		}

		// Token: 0x0600BAA4 RID: 47780 RVA: 0x002B2880 File Offset: 0x002B0C80
		public void ReqOpenTreasureMap(RandomTreasureMapModel mapModel)
		{
			if (mapModel == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - ReqOpenTreasureMap data is null");
				return;
			}
			WorldDigMapOpenReq worldDigMapOpenReq = new WorldDigMapOpenReq();
			worldDigMapOpenReq.mapId = (uint)mapModel.mapId;
			NetManager.Instance().SendCommand<WorldDigMapOpenReq>(ServerType.GATE_SERVER, worldDigMapOpenReq);
		}

		// Token: 0x0600BAA5 RID: 47781 RVA: 0x002B28C0 File Offset: 0x002B0CC0
		public void ReqCloseTreasureMap(RandomTreasureMapModel mapModel)
		{
			if (mapModel == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - ReqCloseTreasureMap data is null");
				return;
			}
			WorldDigMapCloseReq worldDigMapCloseReq = new WorldDigMapCloseReq();
			worldDigMapCloseReq.mapId = (uint)mapModel.mapId;
			NetManager.Instance().SendCommand<WorldDigMapCloseReq>(ServerType.GATE_SERVER, worldDigMapCloseReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldDigMapCloseRes>(delegate(WorldDigMapCloseRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BAA6 RID: 47782 RVA: 0x002B292C File Offset: 0x002B0D2C
		public void ReqWatchTreasureSite(RandomTreasureMapDigSiteModel digSite)
		{
			if (digSite == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - ReqWatchTreasureSite data is null");
				return;
			}
			WorldDigWatchReq worldDigWatchReq = new WorldDigWatchReq();
			worldDigWatchReq.mapId = (uint)digSite.mapId;
			worldDigWatchReq.index = (uint)digSite.index;
			NetManager.Instance().SendCommand<WorldDigWatchReq>(ServerType.GATE_SERVER, worldDigWatchReq);
		}

		// Token: 0x0600BAA7 RID: 47783 RVA: 0x002B2978 File Offset: 0x002B0D78
		public void ReqOpenTreasureDigSite(RandomTreasureMapDigSiteModel digSite)
		{
			if (digSite == null)
			{
				Logger.LogError("[RandomTreasureDataManager] - ReqDigTreasureSite data is null");
				return;
			}
			WorldDigOpenReq worldDigOpenReq = new WorldDigOpenReq();
			worldDigOpenReq.mapId = (uint)digSite.mapId;
			worldDigOpenReq.index = (uint)digSite.index;
			NetManager.Instance().SendCommand<WorldDigOpenReq>(ServerType.GATE_SERVER, worldDigOpenReq);
		}

		// Token: 0x0600BAA8 RID: 47784 RVA: 0x002B29C4 File Offset: 0x002B0DC4
		public void ReqTotalAtlasInfo()
		{
			WorldDigMapInfoReq cmd = new WorldDigMapInfoReq();
			NetManager.Instance().SendCommand<WorldDigMapInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BAA9 RID: 47785 RVA: 0x002B29E4 File Offset: 0x002B0DE4
		public void ReqMapRecordInfo()
		{
			WorldDigRecordsReq cmd = new WorldDigRecordsReq();
			NetManager.Instance().SendCommand<WorldDigRecordsReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BAAA RID: 47786 RVA: 0x002B2A04 File Offset: 0x002B0E04
		public void ReqFastMallBuy(int itemId)
		{
			WorldGetMallItemByItemIdReq worldGetMallItemByItemIdReq = new WorldGetMallItemByItemIdReq();
			worldGetMallItemByItemIdReq.itemId = (uint)itemId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, worldGetMallItemByItemIdReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(delegate(WorldGetMallItemByItemIdRes msgRet)
			{
				MallItemInfo mallItem = msgRet.mallItem;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItem, string.Empty);
			}, false, 15f, null);
		}

		// Token: 0x0600BAAB RID: 47787 RVA: 0x002B2A5C File Offset: 0x002B0E5C
		public void SystemNotifyOnGetItem(ItemSimpleData rewardItem)
		{
			if (rewardItem != null)
			{
				string msgContent = string.Format("{0} * {1}", rewardItem.Name, rewardItem.Count);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, rewardItem.ItemID);
			}
		}

		// Token: 0x0600BAAC RID: 47788 RVA: 0x002B2A98 File Offset: 0x002B0E98
		public bool CheckGetItemDataNeedNotifyRecord(ItemData itemData)
		{
			return !this._NeedFilterRecordInfoByItemQuality(itemData);
		}

		// Token: 0x0600BAAD RID: 47789 RVA: 0x002B2AB4 File Offset: 0x002B0EB4
		public void SystemNotifyOnGetItem(ItemData rewardItem)
		{
			if (rewardItem != null)
			{
				string msgContent = string.Format("{0} * {1}", rewardItem.Name, rewardItem.Count);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, rewardItem.TableID);
			}
		}

		// Token: 0x0600BAAE RID: 47790 RVA: 0x002B2AF0 File Offset: 0x002B0EF0
		public bool IsServerSwitchFuncOn()
		{
			return !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_DIG);
		}

		// Token: 0x0600BAAF RID: 47791 RVA: 0x002B2B11 File Offset: 0x002B0F11
		public void OpenRandomTreasureFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RandomTreasureFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RandomTreasureFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RandomTreasureFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x040068CD RID: 26829
		private int mGoldenShovelCount;

		// Token: 0x040068CE RID: 26830
		private int mSilverShovelCount;

		// Token: 0x040068CF RID: 26831
		private ItemTable.eColor mFilterRecordByQuality = ItemTable.eColor.PURPLE;

		// Token: 0x040068D0 RID: 26832
		private Dictionary<int, RandomTreasureMapModel> mTotalMapModelDic = new Dictionary<int, RandomTreasureMapModel>();

		// Token: 0x040068D1 RID: 26833
		private List<RandomTreasureMapRecordModel> mTotalMapRecordList = new List<RandomTreasureMapRecordModel>();

		// Token: 0x040068D2 RID: 26834
		private List<RandomTreasureUIEvent> mDelayRefreshUIEventList = new List<RandomTreasureUIEvent>();

		// Token: 0x040068D3 RID: 26835
		private float mUpdateTimer;

		// Token: 0x040068D4 RID: 26836
		private float mUpdateInterval = 5f;

		// Token: 0x040068D5 RID: 26837
		private int gold_Treasure_Item_Id = 330000193;

		// Token: 0x040068D6 RID: 26838
		private int silver_Treasure_Item_Id = 330000192;

		// Token: 0x040068D7 RID: 26839
		private ItemSimpleData goldRaffleMustGetItem;

		// Token: 0x040068D8 RID: 26840
		private ItemSimpleData silverRaffleMustGetItem;

		// Token: 0x040068D9 RID: 26841
		private bool bSilverRaffleSkipAnim;
	}
}
