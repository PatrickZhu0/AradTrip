using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011EE RID: 4590
	public class AuctionNewDataManager : DataManager<AuctionNewDataManager>
	{
		// Token: 0x0600B081 RID: 45185 RVA: 0x0026D682 File Offset: 0x0026BA82
		public override void Initialize()
		{
			this.ResetData();
			this.InitData();
			this.BindEvents();
		}

		// Token: 0x0600B082 RID: 45186 RVA: 0x0026D698 File Offset: 0x0026BA98
		private void InitData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionBoothTable>();
			if (table != null)
			{
				this.MaxAddShelfNum = table.Count;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(24, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.BaseShelfNum = tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(498, string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.Value > 0)
			{
				this.PageNumber = tableItem2.Value;
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(493, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.TreasureItemRushBuyTimeInterval = tableItem3.Value;
			}
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(510, string.Empty, string.Empty);
			if (tableItem4 != null && tableItem4.Value > 0)
			{
				this.TreasureItemRecommendPriceRate = tableItem4.Value;
			}
		}

		// Token: 0x0600B083 RID: 45187 RVA: 0x0026D78B File Offset: 0x0026BB8B
		public override void Clear()
		{
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x0600B084 RID: 45188 RVA: 0x0026D79C File Offset: 0x0026BB9C
		private void BindEvents()
		{
			NetProcess.AddMsgHandler(603921U, new Action<MsgDATA>(this.OnReceiveAuctionItemNumRes));
			NetProcess.AddMsgHandler(603902U, new Action<MsgDATA>(this.OnReceiveAuctionItemDetailListRes));
			NetProcess.AddMsgHandler(603911U, new Action<MsgDATA>(this.OnWorldAuctionNotifyRefreshRes));
			NetProcess.AddMsgHandler(603905U, new Action<MsgDATA>(this.OnReceiveWorldAuctionSelfListRes));
			NetProcess.AddMsgHandler(503904U, new Action<MsgDATA>(this.OnReceiveBuyShelfRes));
			NetProcess.AddMsgHandler(603925U, new Action<MsgDATA>(this.OnReceiveAuctionNewTreasureTransactionRes));
			NetProcess.AddMsgHandler(603917U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemRet));
			NetProcess.AddMsgHandler(603923U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemPriceRes));
			NetProcess.AddMsgHandler(603932U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemPriceListRes));
			NetProcess.AddMsgHandler(603936U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemTransListRes));
			NetProcess.AddMsgHandler(603928U, new Action<MsgDATA>(this.OnReceiveWorldAuctionSyncPubPageIds));
			NetProcess.AddMsgHandler(603930U, new Action<MsgDATA>(this.OnReceiveWorldActionNoticeRes));
			NetProcess.AddMsgHandler(603934U, new Action<MsgDATA>(this.OnReceiveAuctionNewMagicCardOnSaleRes));
		}

		// Token: 0x0600B085 RID: 45189 RVA: 0x0026D8C8 File Offset: 0x0026BCC8
		private void UnBindEvents()
		{
			NetProcess.RemoveMsgHandler(603921U, new Action<MsgDATA>(this.OnReceiveAuctionItemNumRes));
			NetProcess.RemoveMsgHandler(603902U, new Action<MsgDATA>(this.OnReceiveAuctionItemDetailListRes));
			NetProcess.RemoveMsgHandler(603911U, new Action<MsgDATA>(this.OnWorldAuctionNotifyRefreshRes));
			NetProcess.RemoveMsgHandler(603905U, new Action<MsgDATA>(this.OnReceiveWorldAuctionSelfListRes));
			NetProcess.RemoveMsgHandler(503904U, new Action<MsgDATA>(this.OnReceiveBuyShelfRes));
			NetProcess.RemoveMsgHandler(603925U, new Action<MsgDATA>(this.OnReceiveAuctionNewTreasureTransactionRes));
			NetProcess.RemoveMsgHandler(603917U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemRet));
			NetProcess.RemoveMsgHandler(603923U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemPriceRes));
			NetProcess.RemoveMsgHandler(603932U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemPriceListRes));
			NetProcess.RemoveMsgHandler(603936U, new Action<MsgDATA>(this.OnReceiveWorldAuctionQueryItemTransListRes));
			NetProcess.RemoveMsgHandler(603928U, new Action<MsgDATA>(this.OnReceiveWorldAuctionSyncPubPageIds));
			NetProcess.RemoveMsgHandler(603930U, new Action<MsgDATA>(this.OnReceiveWorldActionNoticeRes));
			NetProcess.RemoveMsgHandler(603934U, new Action<MsgDATA>(this.OnReceiveAuctionNewMagicCardOnSaleRes));
		}

		// Token: 0x0600B086 RID: 45190 RVA: 0x0026D9F4 File Offset: 0x0026BDF4
		private void ResetData()
		{
			foreach (KeyValuePair<int, List<AuctionNewFilterData>> keyValuePair in this._auctionNewFilterDataDictionary)
			{
				List<AuctionNewFilterData> value = keyValuePair.Value;
				if (value != null)
				{
					value.Clear();
				}
			}
			this._auctionNewFilterDataDictionary.Clear();
			foreach (KeyValuePair<int, List<AuctionItemBaseInfo>> keyValuePair2 in this._auctionNewItemNumResDictionary)
			{
				List<AuctionItemBaseInfo> value2 = keyValuePair2.Value;
				if (value2 != null)
				{
					value2.Clear();
				}
			}
			this._auctionNewItemNumResDictionary.Clear();
			this._auctionNewItemDetailResDictionary.Clear();
			this._onShelfDataModelList.Clear();
			this._treasureItemBuyRecordList.Clear();
			this._treasureItemSaleRecordList.Clear();
			this._lastTimeAuctionNewUserData = null;
			this._itemDataDetailDictionary.Clear();
			this.IsNotShowOnShelfTipOfNormalItem = false;
			this.IsNotShowOnShelfTipOfTreasureItem = false;
			this._worldAuctionQueryItemPriceRes = null;
			this._worldAuctionQueryItemPriceListRes = null;
			this._worldAuctionQueryItemTransListRes = null;
			this._worldAuctionSyncPubPageIds = null;
			this._worldAuctionQueryMagicOnSalesRes = null;
			this.ResetAuctionNewItemIdDictionary();
			this.PageNumber = 6;
			this.ResetPreviewOnShelfItemData();
			this._packageTypeList.Clear();
		}

		// Token: 0x0600B087 RID: 45191 RVA: 0x0026DB1C File Offset: 0x0026BF1C
		public List<AuctionNewFilterData> GetAuctionNewFilterDataList(AuctionNewFrameTable.eFilterItemType filterType)
		{
			if (filterType <= AuctionNewFrameTable.eFilterItemType.FIT_NONE || filterType >= AuctionNewFrameTable.eFilterItemType.FIT_MAX)
			{
				return null;
			}
			List<AuctionNewFilterData> list = null;
			if (!this._auctionNewFilterDataDictionary.TryGetValue((int)filterType, out list))
			{
				list = this.InitAuctionNewFilterDataListByFilterTypeIndex((int)filterType);
				if (this._auctionNewFilterDataDictionary.ContainsKey((int)filterType))
				{
					this._auctionNewFilterDataDictionary[(int)filterType] = list;
				}
				else
				{
					this._auctionNewFilterDataDictionary.Add((int)filterType, list);
				}
			}
			return list;
		}

		// Token: 0x0600B088 RID: 45192 RVA: 0x0026DB8C File Offset: 0x0026BF8C
		public AuctionNewFilterData GetDefaultAuctionNewFilterData(AuctionNewFrameTable.eFilterItemType filterType, int filterSortType)
		{
			List<AuctionNewFilterData> auctionNewFilterDataList = this.GetAuctionNewFilterDataList(filterType);
			if (auctionNewFilterDataList == null || auctionNewFilterDataList.Count <= 0)
			{
				return null;
			}
			if (filterSortType <= 1)
			{
				return auctionNewFilterDataList[0];
			}
			AuctionNewFilterData auctionNewFilterData = auctionNewFilterDataList[0];
			if (filterSortType == 2)
			{
				if (auctionNewFilterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_LEVEL)
				{
					return auctionNewFilterData;
				}
				ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
				for (int i = auctionNewFilterDataList.Count - 1; i >= 1; i--)
				{
					int id = auctionNewFilterDataList[i].Id;
					AuctionNewFilterTable auctionNewFilterTable = auctionNewFilterDataList[i].AuctionNewFilterTable;
					if (auctionNewFilterTable.Parameter != null && auctionNewFilterTable.Parameter.Count == 2)
					{
						int num = auctionNewFilterTable.Parameter[0];
						int num2 = auctionNewFilterTable.Parameter[1];
						if (((int)level >= num && (int)level <= num2) || ((int)level <= num && (int)level >= num2))
						{
							return auctionNewFilterDataList[i];
						}
					}
				}
			}
			else if (filterSortType == 3)
			{
				if (auctionNewFilterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_JOB)
				{
					return auctionNewFilterData;
				}
				int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
				int baseJobID = Utility.GetBaseJobID(jobTableID);
				for (int j = auctionNewFilterDataList.Count - 1; j >= 1; j--)
				{
					AuctionNewFilterData result = auctionNewFilterDataList[j];
					AuctionNewFilterTable auctionNewFilterTable2 = auctionNewFilterDataList[j].AuctionNewFilterTable;
					if (auctionNewFilterTable2.Parameter != null && auctionNewFilterTable2.Parameter.Count > 0)
					{
						for (int k = 0; k < auctionNewFilterTable2.Parameter.Count; k++)
						{
							int num3 = auctionNewFilterTable2.Parameter[k];
							if (num3 == baseJobID)
							{
								return result;
							}
						}
					}
				}
			}
			return auctionNewFilterData;
		}

		// Token: 0x0600B089 RID: 45193 RVA: 0x0026DD48 File Offset: 0x0026C148
		private List<AuctionNewFilterData> InitAuctionNewFilterDataListByFilterTypeIndex(int filterTypeIndex)
		{
			List<AuctionNewFilterData> list = new List<AuctionNewFilterData>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionNewFilterTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AuctionNewFilterTable auctionNewFilterTable = keyValuePair.Value as AuctionNewFilterTable;
				if (auctionNewFilterTable != null && auctionNewFilterTable.FilterItemType == filterTypeIndex)
				{
					AuctionNewFilterData item = new AuctionNewFilterData
					{
						FilterItemType = (AuctionNewFrameTable.eFilterItemType)filterTypeIndex,
						Id = auctionNewFilterTable.ID,
						Sort = auctionNewFilterTable.Sort,
						Name = auctionNewFilterTable.Name,
						AuctionNewFilterTable = auctionNewFilterTable
					};
					list.Add(item);
				}
			}
			list.Sort((AuctionNewFilterData x, AuctionNewFilterData y) => x.Sort.CompareTo(y.Sort));
			return list;
		}

		// Token: 0x0600B08A RID: 45194 RVA: 0x0026DE14 File Offset: 0x0026C214
		public void SendAuctionNewOnSaleItemListReq(AuctionNewMainTabType auctionNewMainTabType, AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, AuctionNewMenuTabDataModel secondLayerMenuTabDataModel, AuctionNewMenuTabDataModel thirdLayerMenuTabDataModel, AuctionNewFilterData firstFilterData = null, AuctionNewFilterData secondFilterData = null, AuctionNewFilterData thirdFilterData = null)
		{
			if (auctionNewMainTabType != AuctionNewMainTabType.AuctionBuyType && auctionNewMainTabType != AuctionNewMainTabType.AuctionNoticeType)
			{
				Logger.LogErrorFormat("AuctionNewMainTabType is Error ", new object[0]);
				return;
			}
			if (firstLayerMenuTabDataModel == null || firstLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("FirstLayerMenuTabDataModel is Error", new object[0]);
				return;
			}
			if (secondLayerMenuTabDataModel == null || secondLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("SecondLayerMenuTabDataModel is Error", new object[0]);
				return;
			}
			WorldAuctionItemNumReq worldAuctionItemNumReq = new WorldAuctionItemNumReq();
			worldAuctionItemNumReq.cond.itemMainType = (byte)firstLayerMenuTabDataModel.AuctionNewFrameTable.MainItemType;
			worldAuctionItemNumReq.cond.type = 0;
			AuctionGoodState auctionGoodState = AuctionNewUtility.ConvertToAuctionGoodState(auctionNewMainTabType);
			worldAuctionItemNumReq.cond.goodState = (byte)auctionGoodState;
			if (thirdLayerMenuTabDataModel == null || thirdLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				if (secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Count == 0 || (secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Count == 1 && secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID[0] == 0))
				{
					List<uint> itemSubTypes = this.GetItemSubTypes(secondLayerMenuTabDataModel.AuctionNewFrameTable);
					worldAuctionItemNumReq.cond.itemSubTypes = itemSubTypes.ToArray();
				}
				else
				{
					int length = secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Length;
					List<uint> list = new List<uint>();
					for (int i = 0; i < length; i++)
					{
						int id = secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID[i];
						AuctionNewFrameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionNewFrameTable>(id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							List<uint> itemSubTypes2 = this.GetItemSubTypes(tableItem);
							list.AddRange(itemSubTypes2);
						}
					}
					worldAuctionItemNumReq.cond.excludeItemSubTypes = list.ToArray();
				}
			}
			else
			{
				FlatBufferArray<int> thirdType = thirdLayerMenuTabDataModel.AuctionNewFrameTable.ThirdType;
				FlatBufferArray<int> subType = thirdLayerMenuTabDataModel.AuctionNewFrameTable.SubType;
				if (thirdType.Count == 1 && thirdType[0] == -1)
				{
					thirdType = secondLayerMenuTabDataModel.AuctionNewFrameTable.ThirdType;
				}
				if (subType.Count == 1 && subType[0] == -1)
				{
					subType = secondLayerMenuTabDataModel.AuctionNewFrameTable.SubType;
				}
				int length2 = subType.Length;
				worldAuctionItemNumReq.cond.itemSubTypes = new uint[length2];
				for (int j = 0; j < length2; j++)
				{
					worldAuctionItemNumReq.cond.itemSubTypes[j] = (uint)(subType[j] * 1000 + thirdType[j]);
				}
				if (thirdLayerMenuTabDataModel.AuctionNewFrameTable.SpecialParametersType == 1)
				{
					worldAuctionItemNumReq.cond.quality = (byte)thirdLayerMenuTabDataModel.AuctionNewFrameTable.SpecialParameters;
				}
				else if (thirdLayerMenuTabDataModel.AuctionNewFrameTable.SpecialParametersType == 2)
				{
					worldAuctionItemNumReq.cond.couponStrengthToLev = (uint)((byte)thirdLayerMenuTabDataModel.AuctionNewFrameTable.SpecialParameters);
				}
			}
			if (firstFilterData != null)
			{
				this.SetAuctionNewNumReqFilterParam(worldAuctionItemNumReq, firstFilterData);
			}
			if (secondFilterData != null)
			{
				this.SetAuctionNewNumReqFilterParam(worldAuctionItemNumReq, secondFilterData);
			}
			if (thirdFilterData != null)
			{
				this.SetAuctionNewNumReqFilterParam(worldAuctionItemNumReq, thirdFilterData);
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionItemNumReq>(ServerType.GATE_SERVER, worldAuctionItemNumReq);
			}
		}

		// Token: 0x0600B08B RID: 45195 RVA: 0x0026E134 File Offset: 0x0026C534
		private List<uint> GetItemSubTypes(AuctionNewFrameTable auctionNewFrameTable)
		{
			int length = auctionNewFrameTable.SubType.Length;
			int length2 = auctionNewFrameTable.ThirdType.Length;
			int num = (length < length2) ? length : length2;
			List<uint> list = new List<uint>();
			for (int i = 0; i < num; i++)
			{
				int num2 = auctionNewFrameTable.SubType[i];
				int num3 = auctionNewFrameTable.ThirdType[i];
				list.Add((uint)(num2 * 1000 + num3));
			}
			return list;
		}

		// Token: 0x0600B08C RID: 45196 RVA: 0x0026E1B4 File Offset: 0x0026C5B4
		private void SetAuctionNewNumReqFilterParam(WorldAuctionItemNumReq req, AuctionNewFilterData filterData)
		{
			if (req == null || req.cond == null)
			{
				return;
			}
			if (filterData.AuctionNewFilterTable.Parameter == null || (filterData.AuctionNewFilterTable.Parameter.Count == 1 && filterData.AuctionNewFilterTable.Parameter[0] == 0))
			{
				return;
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_LEVEL)
			{
				if (filterData.AuctionNewFilterTable.Parameter != null && filterData.AuctionNewFilterTable.Parameter.Count == 2)
				{
					int num = filterData.AuctionNewFilterTable.Parameter[0];
					int num2 = filterData.AuctionNewFilterTable.Parameter[1];
					if (num > num2)
					{
						req.cond.minLevel = (byte)num2;
						req.cond.maxLevel = (byte)num;
					}
					else
					{
						req.cond.minLevel = (byte)num;
						req.cond.maxLevel = (byte)num2;
					}
				}
			}
			else if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_QUALITY)
			{
				if (filterData.AuctionNewFilterTable.Parameter.Count > 1)
				{
					req.cond.quality = 0;
				}
				else
				{
					req.cond.quality = (byte)filterData.AuctionNewFilterTable.Parameter[0];
				}
			}
			else if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_SUCCEEDRAT)
			{
				if (filterData.AuctionNewFilterTable.Parameter.Count <= 1)
				{
					return;
				}
				int num3 = filterData.AuctionNewFilterTable.Parameter[0];
				int num4 = filterData.AuctionNewFilterTable.Parameter[1];
				if (num3 > num4)
				{
					req.cond.minLevel = (byte)num4;
					req.cond.maxLevel = (byte)num3;
				}
				else
				{
					req.cond.minLevel = (byte)num3;
					req.cond.maxLevel = (byte)num4;
				}
			}
			else if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_JOB)
			{
				int count = filterData.AuctionNewFilterTable.Parameter.Count;
				req.cond.occus = new byte[count];
				for (int i = 0; i < count; i++)
				{
					req.cond.occus[i] = (byte)filterData.AuctionNewFilterTable.Parameter[i];
				}
			}
		}

		// Token: 0x0600B08D RID: 45197 RVA: 0x0026E3F4 File Offset: 0x0026C7F4
		private void OnReceiveAuctionItemNumRes(MsgDATA msgData)
		{
			WorldAuctionItemNumRes worldAuctionItemNumRes = new WorldAuctionItemNumRes();
			worldAuctionItemNumRes.decode(msgData.bytes);
			int goodState = (int)worldAuctionItemNumRes.goodState;
			if (goodState <= 0 || goodState > 2)
			{
				Logger.LogErrorFormat("AuctionItemNumRes goodState is Error", new object[0]);
				return;
			}
			if (this._auctionNewItemNumResDictionary == null)
			{
				this._auctionNewItemNumResDictionary = new Dictionary<int, List<AuctionItemBaseInfo>>();
			}
			List<AuctionItemBaseInfo> list = new List<AuctionItemBaseInfo>();
			if (!this._auctionNewItemNumResDictionary.ContainsKey(goodState))
			{
				this._auctionNewItemNumResDictionary.Add(goodState, list);
			}
			else if (!this._auctionNewItemNumResDictionary.TryGetValue(goodState, out list))
			{
				list = new List<AuctionItemBaseInfo>();
				this._auctionNewItemNumResDictionary[goodState] = list;
			}
			list.Clear();
			int num = worldAuctionItemNumRes.items.Length;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					int itemTypeId = (int)worldAuctionItemNumRes.items[i].itemTypeId;
					if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemTypeId, string.Empty, string.Empty) != null)
					{
						list.Add(worldAuctionItemNumRes.items[i]);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewReceiveItemNumResSucceed, goodState, null, null, null);
		}

		// Token: 0x0600B08E RID: 45198 RVA: 0x0026E528 File Offset: 0x0026C928
		public List<AuctionItemBaseInfo> GetAuctionNewItemNumResList(int goodState)
		{
			if (this._auctionNewItemNumResDictionary == null || this._auctionNewItemNumResDictionary.Count <= 0)
			{
				return null;
			}
			List<AuctionItemBaseInfo> result = null;
			if (this._auctionNewItemNumResDictionary.TryGetValue(goodState, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B08F RID: 45199 RVA: 0x0026E56C File Offset: 0x0026C96C
		public void SendAuctionNewItemDetailListReq(int itemId, AuctionNewMainTabType mainTabType, int curPage = 1, int sortType = 1, int noticeTab = 0, int minStrengthenLevel = 0, int maxStrengthenLevel = 0)
		{
			WorldAuctionListReq worldAuctionListReq = new WorldAuctionListReq();
			worldAuctionListReq.cond.type = 0;
			worldAuctionListReq.cond.itemTypeID = (uint)itemId;
			AuctionGoodState auctionGoodState = AuctionNewUtility.ConvertToAuctionGoodState(mainTabType);
			worldAuctionListReq.cond.goodState = (byte)auctionGoodState;
			worldAuctionListReq.cond.page = (ushort)curPage;
			worldAuctionListReq.cond.itemNumPerPage = (byte)this.PageNumber;
			worldAuctionListReq.cond.sortType = (byte)sortType;
			worldAuctionListReq.cond.attent = (byte)noticeTab;
			worldAuctionListReq.cond.minStrength = (byte)minStrengthenLevel;
			worldAuctionListReq.cond.maxStrength = (byte)maxStrengthenLevel;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionListReq>(ServerType.GATE_SERVER, worldAuctionListReq);
			}
		}

		// Token: 0x0600B090 RID: 45200 RVA: 0x0026E620 File Offset: 0x0026CA20
		private void OnReceiveAuctionItemDetailListRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			WorldAuctionListQueryRet worldAuctionListQueryRet = new WorldAuctionListQueryRet();
			worldAuctionListQueryRet.decode(msgData.bytes);
			int goodState = (int)worldAuctionListQueryRet.goodState;
			if (goodState <= 0 || goodState > 2)
			{
				Logger.LogErrorFormat("AuctionItemListRes goodState is Error and goodState is {0}", new object[]
				{
					goodState
				});
				return;
			}
			if (this._auctionNewItemDetailResDictionary == null)
			{
				this._auctionNewItemDetailResDictionary = new Dictionary<int, AuctionNewItemDetailData>();
			}
			AuctionNewItemDetailData auctionNewItemDetailData = new AuctionNewItemDetailData();
			auctionNewItemDetailData.Type = (int)worldAuctionListQueryRet.type;
			auctionNewItemDetailData.CurPage = (int)worldAuctionListQueryRet.curPage;
			auctionNewItemDetailData.MaxPage = (int)worldAuctionListQueryRet.maxPage;
			auctionNewItemDetailData.NoticeType = (int)worldAuctionListQueryRet.attent;
			auctionNewItemDetailData.ItemDetailDataList = new List<AuctionBaseInfo>();
			if (worldAuctionListQueryRet.data != null && worldAuctionListQueryRet.data.Length > 0)
			{
				for (int i = 0; i < worldAuctionListQueryRet.data.Length; i++)
				{
					auctionNewItemDetailData.ItemDetailDataList.Add(worldAuctionListQueryRet.data[i]);
				}
			}
			if (this._auctionNewItemDetailResDictionary.ContainsKey(goodState))
			{
				this._auctionNewItemDetailResDictionary[goodState] = auctionNewItemDetailData;
			}
			else
			{
				this._auctionNewItemDetailResDictionary.Add(goodState, auctionNewItemDetailData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewReceiveItemDetailDataResSucceed, goodState, null, null, null);
		}

		// Token: 0x0600B091 RID: 45201 RVA: 0x0026E75C File Offset: 0x0026CB5C
		public AuctionNewItemDetailData GetAuctionNewItemDetailData(int goodState)
		{
			if (this._auctionNewItemDetailResDictionary == null || this._auctionNewItemDetailResDictionary.Count <= 0)
			{
				return null;
			}
			if (!this._auctionNewItemDetailResDictionary.ContainsKey(goodState))
			{
				return null;
			}
			AuctionNewItemDetailData result = null;
			if (this._auctionNewItemDetailResDictionary.TryGetValue(goodState, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B092 RID: 45202 RVA: 0x0026E7B4 File Offset: 0x0026CBB4
		public bool IsPackageItemCanInForSaleList(ulong guid, ActionNewSellTabType sellTabType)
		{
			if (!this.IsPackageItemCanTradeByGuid(guid))
			{
				return false;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item == null)
			{
				return false;
			}
			if (sellTabType == ActionNewSellTabType.AuctionNewSellEquipType)
			{
				if (AuctionNewUtility.IsEquipItems(item))
				{
					return true;
				}
			}
			else if (sellTabType == ActionNewSellTabType.AuctionNewSellMaterialType && !AuctionNewUtility.IsEquipItems(item))
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600B093 RID: 45203 RVA: 0x0026E814 File Offset: 0x0026CC14
		public bool IsPackageItemCanTradeByGuid(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item == null)
			{
				return false;
			}
			if (!DataManager<ItemDataManager>.GetInstance().TradeItemStateFliter(item))
			{
				return false;
			}
			this.UpdatePackageTypeList();
			return DataManager<ItemDataManager>.GetInstance().TradeItemTypeFliter(this._packageTypeList, item.PackageType) && !item.isInSidePack && !item.CheckEquipIsMosaicInscription() && !item.bLocked;
		}

		// Token: 0x0600B094 RID: 45204 RVA: 0x0026E894 File Offset: 0x0026CC94
		private void UpdatePackageTypeList()
		{
			if (this._packageTypeList == null)
			{
				this._packageTypeList = new List<EPackageType>();
			}
			if (this._packageTypeList.Count == 0)
			{
				this._packageTypeList.Add(EPackageType.Equip);
				this._packageTypeList.Add(EPackageType.Material);
				this._packageTypeList.Add(EPackageType.Consumable);
				this._packageTypeList.Add(EPackageType.Task);
				this._packageTypeList.Add(EPackageType.Fashion);
				this._packageTypeList.Add(EPackageType.Title);
			}
		}

		// Token: 0x0600B095 RID: 45205 RVA: 0x0026E910 File Offset: 0x0026CD10
		public void UpdatePackageItemUid()
		{
			this._packageSellItemUidList.Clear();
			this.UpdatePackageTypeList();
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, ItemData> keyValuePair in allPackageItems)
			{
				ulong key = keyValuePair.Key;
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(key);
				if (item != null)
				{
					if (DataManager<ItemDataManager>.GetInstance().TradeItemTypeFliter(this._packageTypeList, item.PackageType))
					{
						if (DataManager<ItemDataManager>.GetInstance().TradeItemStateFliter(item))
						{
							this._packageSellItemUidList.Add(key);
						}
					}
				}
			}
		}

		// Token: 0x0600B096 RID: 45206 RVA: 0x0026E9C4 File Offset: 0x0026CDC4
		public List<AuctionSellItemData> GetAuctionSellItemDataByType(ActionNewSellTabType sellTabType)
		{
			if (this._packageSellItemDataList == null)
			{
				this._packageSellItemDataList = new List<AuctionSellItemData>();
			}
			this._packageSellItemDataList.Clear();
			this.UpdatePackageItemUid();
			for (int i = 0; i < this._packageSellItemUidList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this._packageSellItemUidList[i]);
				if (item != null)
				{
					if (!item.isInSidePack)
					{
						if (!item.CheckEquipIsMosaicInscription())
						{
							if (!item.IsItemInUnUsedEquipPlan)
							{
								AuctionSellItemData auctionSellItemData = null;
								if (sellTabType == ActionNewSellTabType.AuctionNewSellEquipType)
								{
									if (AuctionNewUtility.IsEquipItems(item))
									{
										auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, item.IsTreasure);
									}
								}
								else if (!AuctionNewUtility.IsEquipItems(item))
								{
									auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, item.IsTreasure);
								}
								if (auctionSellItemData != null)
								{
									if (!item.bLocked)
									{
										this._packageSellItemDataList.Add(auctionSellItemData);
									}
								}
							}
						}
					}
				}
			}
			this._packageSellItemDataList.Sort(delegate(AuctionSellItemData x, AuctionSellItemData y)
			{
				int num = -x.IsTreasure.CompareTo(y.IsTreasure);
				if (num == 0)
				{
					num = -x.Quality.CompareTo(y.Quality);
				}
				return num;
			});
			return this._packageSellItemDataList;
		}

		// Token: 0x0600B097 RID: 45207 RVA: 0x0026EB18 File Offset: 0x0026CF18
		private void OnWorldAuctionNotifyRefreshRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			WorldAuctionNotifyRefresh worldAuctionNotifyRefresh = new WorldAuctionNotifyRefresh();
			worldAuctionNotifyRefresh.decode(msgData.bytes);
			if (worldAuctionNotifyRefresh.type != 0)
			{
				return;
			}
			if (worldAuctionNotifyRefresh.reason == 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewNotifyRefreshToRequestDetailItems, worldAuctionNotifyRefresh.auctGuid, null, null, null);
			}
			else if (worldAuctionNotifyRefresh.reason == 3)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewNotifyRefreshToRequestDetailItems, worldAuctionNotifyRefresh.auctGuid, null, null, null);
			}
			else if (worldAuctionNotifyRefresh.reason == 1 || worldAuctionNotifyRefresh.reason == 2 || worldAuctionNotifyRefresh.reason == 4)
			{
				this.SendSelfAuctionListRequest();
			}
		}

		// Token: 0x0600B098 RID: 45208 RVA: 0x0026EBCF File Offset: 0x0026CFCF
		public bool IsAuctionNewCanBuyShelfField()
		{
			return DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.MaxAddShelfNum;
		}

		// Token: 0x0600B099 RID: 45209 RVA: 0x0026EBEC File Offset: 0x0026CFEC
		public void SendBuyShelfRequest()
		{
			NetManager netManager = NetManager.Instance();
			SceneAuctionBuyBoothReq cmd = new SceneAuctionBuyBoothReq();
			netManager.SendCommand<SceneAuctionBuyBoothReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B09A RID: 45210 RVA: 0x0026EC10 File Offset: 0x0026D010
		private void OnReceiveBuyShelfRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneAuctionBuyBoothRes sceneAuctionBuyBoothRes = new SceneAuctionBuyBoothRes();
			sceneAuctionBuyBoothRes.decode(msgData.bytes);
			if (sceneAuctionBuyBoothRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneAuctionBuyBoothRes.result, string.Empty);
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum = (int)sceneAuctionBuyBoothRes.boothNum;
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_onSale_buy_shelf_succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			if (this._onShelfDataModelList != null && this._onShelfDataModelList.Count > 0)
			{
				AuctionNewOnShelfDataModel auctionNewOnShelfDataModel = this._onShelfDataModelList[this._onShelfDataModelList.Count - 1];
				if (auctionNewOnShelfDataModel != null && auctionNewOnShelfDataModel.onShelfState == AuctionNewOnShelfState.BuyField)
				{
					auctionNewOnShelfDataModel.onShelfState = AuctionNewOnShelfState.Empty;
					auctionNewOnShelfDataModel.boothTableData = null;
				}
			}
			if (DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.MaxAddShelfNum)
			{
				this.AddOneBuyShelfDataModel(DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + 1);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewBuyShelfResSucceed, null, null, null, null);
		}

		// Token: 0x0600B09B RID: 45211 RVA: 0x0026ED04 File Offset: 0x0026D104
		public void SendDownShelfItemRequest(ulong guid)
		{
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionCancel>(ServerType.GATE_SERVER, new WorldAuctionCancel
			{
				id = guid
			});
		}

		// Token: 0x0600B09C RID: 45212 RVA: 0x0026ED30 File Offset: 0x0026D130
		public void SendSelfAuctionListRequest()
		{
			WorldAuctionSelfListReq worldAuctionSelfListReq = new WorldAuctionSelfListReq();
			worldAuctionSelfListReq.type = 0;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionSelfListReq>(ServerType.GATE_SERVER, worldAuctionSelfListReq);
			}
		}

		// Token: 0x0600B09D RID: 45213 RVA: 0x0026ED68 File Offset: 0x0026D168
		private void OnReceiveWorldAuctionSelfListRes(MsgDATA msgData)
		{
			WorldAuctionSelfListRes worldAuctionSelfListRes = new WorldAuctionSelfListRes();
			worldAuctionSelfListRes.decode(msgData.bytes);
			if (worldAuctionSelfListRes.type != 0)
			{
				return;
			}
			this._onShelfDataModelList.Clear();
			if (worldAuctionSelfListRes.data != null && worldAuctionSelfListRes.data.Length > 0)
			{
				for (int i = 0; i < worldAuctionSelfListRes.data.Length; i++)
				{
					AuctionBaseInfo auctionBaseInfo = worldAuctionSelfListRes.data[i];
					if (auctionBaseInfo != null)
					{
						AuctionNewOnShelfDataModel auctionNewOnShelfDataModel = new AuctionNewOnShelfDataModel();
						auctionNewOnShelfDataModel.onShelfState = AuctionNewOnShelfState.OwnerItem;
						auctionNewOnShelfDataModel.auctionBaseInfo = auctionBaseInfo;
						this._onShelfDataModelList.Add(auctionNewOnShelfDataModel);
					}
				}
			}
			this.OnShelfItemNumber = this._onShelfDataModelList.Count;
			this.AddExtraOnShelfDataModelList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewReceiveSelfListResSucceed, null, null, null, null);
		}

		// Token: 0x0600B09E RID: 45214 RVA: 0x0026EE2C File Offset: 0x0026D22C
		private void AddExtraOnShelfDataModelList()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + this.BaseShelfNum;
			int count = this._onShelfDataModelList.Count;
			if (count < num)
			{
				int num2 = num - count;
				for (int i = 0; i < num2; i++)
				{
					AuctionNewOnShelfDataModel auctionNewOnShelfDataModel = new AuctionNewOnShelfDataModel();
					auctionNewOnShelfDataModel.onShelfState = AuctionNewOnShelfState.Empty;
					this._onShelfDataModelList.Add(auctionNewOnShelfDataModel);
				}
			}
			if (DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.MaxAddShelfNum)
			{
				this.AddOneBuyShelfDataModel(DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + 1);
			}
		}

		// Token: 0x0600B09F RID: 45215 RVA: 0x0026EEB8 File Offset: 0x0026D2B8
		private void AddOneBuyShelfDataModel(int boothTableId)
		{
			AuctionBoothTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionBoothTable>(boothTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			AuctionNewOnShelfDataModel auctionNewOnShelfDataModel = new AuctionNewOnShelfDataModel();
			auctionNewOnShelfDataModel.onShelfState = AuctionNewOnShelfState.BuyField;
			auctionNewOnShelfDataModel.boothTableData = tableItem;
			this._onShelfDataModelList.Add(auctionNewOnShelfDataModel);
		}

		// Token: 0x0600B0A0 RID: 45216 RVA: 0x0026EF04 File Offset: 0x0026D304
		public List<AuctionNewOnShelfDataModel> GetOnShelfDataModelList()
		{
			return this._onShelfDataModelList;
		}

		// Token: 0x0600B0A1 RID: 45217 RVA: 0x0026EF0C File Offset: 0x0026D30C
		public void SendAuctionNewTreasureTransactionReq()
		{
			this.ResetTreasureTransactionRecordList();
			NetManager netManager = NetManager.Instance();
			WorldAuctionGetTreasTransactionReq cmd = new WorldAuctionGetTreasTransactionReq();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionGetTreasTransactionReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B0A2 RID: 45218 RVA: 0x0026EF40 File Offset: 0x0026D340
		private void OnReceiveAuctionNewTreasureTransactionRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			WorldAuctionGetTreasTransactionRes worldAuctionGetTreasTransactionRes = new WorldAuctionGetTreasTransactionRes();
			worldAuctionGetTreasTransactionRes.decode(msgData.bytes);
			if (worldAuctionGetTreasTransactionRes.sales != null)
			{
				this._treasureItemSaleRecordList.AddRange(worldAuctionGetTreasTransactionRes.sales);
			}
			if (worldAuctionGetTreasTransactionRes.buys != null)
			{
				this._treasureItemBuyRecordList.AddRange(worldAuctionGetTreasTransactionRes.buys);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewGetTreasureTransactionRecordSucceed, null, null, null, null);
		}

		// Token: 0x0600B0A3 RID: 45219 RVA: 0x0026EFB1 File Offset: 0x0026D3B1
		public List<AuctionTransaction> GetTreasureItemSaleRecordList()
		{
			return this._treasureItemSaleRecordList;
		}

		// Token: 0x0600B0A4 RID: 45220 RVA: 0x0026EFB9 File Offset: 0x0026D3B9
		public List<AuctionTransaction> GetTreasureItemBuyRecordList()
		{
			return this._treasureItemBuyRecordList;
		}

		// Token: 0x0600B0A5 RID: 45221 RVA: 0x0026EFC1 File Offset: 0x0026D3C1
		public void ResetTreasureTransactionRecordList()
		{
			this._treasureItemSaleRecordList.Clear();
			this._treasureItemBuyRecordList.Clear();
		}

		// Token: 0x0600B0A6 RID: 45222 RVA: 0x0026EFDC File Offset: 0x0026D3DC
		public void OnClickOnPacking(ItemData itemData)
		{
			SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
			smithShopNewLinkData.itemData = itemData;
			smithShopNewLinkData.iDefaultFirstTabId = 7;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
		}

		// Token: 0x0600B0A7 RID: 45223 RVA: 0x0026F01C File Offset: 0x0026D41C
		public void SendOnShelfReq(ItemData itemData, int totalPrice, int itemNumber, byte isAgain = 0, ulong auctionGuid = 0UL)
		{
			WorldAuctionRequest worldAuctionRequest = new WorldAuctionRequest();
			worldAuctionRequest.id = itemData.GUID;
			worldAuctionRequest.typeId = (uint)itemData.TableID;
			worldAuctionRequest.type = 0;
			worldAuctionRequest.price = (uint)totalPrice;
			worldAuctionRequest.duration = 0;
			worldAuctionRequest.num = (uint)itemNumber;
			worldAuctionRequest.strength = (byte)itemData.StrengthenLevel;
			if (itemData.SubType == 54)
			{
				worldAuctionRequest.beadbuffId = (uint)itemData.BeadAdditiveAttributeBuffID;
			}
			else
			{
				worldAuctionRequest.beadbuffId = 0U;
			}
			worldAuctionRequest.enhanceType = (byte)itemData.GrowthAttrType;
			if (isAgain == 1)
			{
				worldAuctionRequest.isAgain = isAgain;
				worldAuctionRequest.auctionGuid = auctionGuid;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionRequest>(ServerType.GATE_SERVER, worldAuctionRequest);
			DataManager<AuctionNewDataManager>.GetInstance().SetPreviewOnShelfItemData(itemData.TableID, itemData.StrengthenLevel, totalPrice);
		}

		// Token: 0x0600B0A8 RID: 45224 RVA: 0x0026F0E0 File Offset: 0x0026D4E0
		public void SetLastTimeUserDataMainTabType(AuctionNewMainTabType mainTabType)
		{
			this.InitLastTimeAuctionNewUserData();
			this._lastTimeAuctionNewUserData.MainTabType = mainTabType;
		}

		// Token: 0x0600B0A9 RID: 45225 RVA: 0x0026F0F4 File Offset: 0x0026D4F4
		public void SetLastTimeUserDataFirstLayerTabId(int firstLayerId)
		{
			this.InitLastTimeAuctionNewUserData();
			this._lastTimeAuctionNewUserData.FirstLayerTabId = firstLayerId;
		}

		// Token: 0x0600B0AA RID: 45226 RVA: 0x0026F108 File Offset: 0x0026D508
		public void SetLastTimeUserDataSecondLayerTabId(int secondLayerTabId)
		{
			this.InitLastTimeAuctionNewUserData();
			this._lastTimeAuctionNewUserData.SecondLayerTabId = secondLayerTabId;
		}

		// Token: 0x0600B0AB RID: 45227 RVA: 0x0026F11C File Offset: 0x0026D51C
		private void InitLastTimeAuctionNewUserData()
		{
			if (this._lastTimeAuctionNewUserData == null)
			{
				this._lastTimeAuctionNewUserData = new AuctionNewUserData();
			}
		}

		// Token: 0x0600B0AC RID: 45228 RVA: 0x0026F134 File Offset: 0x0026D534
		public AuctionNewUserData GetLastTimeUserData()
		{
			return this._lastTimeAuctionNewUserData;
		}

		// Token: 0x0600B0AD RID: 45229 RVA: 0x0026F13C File Offset: 0x0026D53C
		public void ResetLastTimeUserData()
		{
			this._lastTimeAuctionNewUserData = null;
		}

		// Token: 0x0600B0AE RID: 45230 RVA: 0x0026F145 File Offset: 0x0026D545
		public void OnShowItemDetailTipFrame(ItemData itemData, ulong guid = 0UL)
		{
			if (guid == 0UL)
			{
				this.ShowAuctionNewSystemItemTip(itemData);
			}
			else
			{
				this.ShowItemDataDetailInfoTipFrame(guid);
			}
		}

		// Token: 0x0600B0AF RID: 45231 RVA: 0x0026F164 File Offset: 0x0026D564
		public void ShowItemDataDetailInfoTipFrame(ulong guid)
		{
			ItemData itemDataDetailInfoByGuid = this.GetItemDataDetailInfoByGuid(guid);
			if (itemDataDetailInfoByGuid == null)
			{
				this.SendWorldAuctionQueryItemReq(guid);
			}
			else
			{
				this.ShowAuctionNewSystemItemTip(itemDataDetailInfoByGuid);
			}
		}

		// Token: 0x0600B0B0 RID: 45232 RVA: 0x0026F194 File Offset: 0x0026D594
		private void SendWorldAuctionQueryItemReq(ulong guid)
		{
			WorldAuctionQueryItemReq worldAuctionQueryItemReq = new WorldAuctionQueryItemReq();
			worldAuctionQueryItemReq.id = guid;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionQueryItemReq>(ServerType.GATE_SERVER, worldAuctionQueryItemReq);
			}
		}

		// Token: 0x0600B0B1 RID: 45233 RVA: 0x0026F1CC File Offset: 0x0026D5CC
		private void OnReceiveWorldAuctionQueryItemRet(MsgDATA msgData)
		{
			int num = 0;
			ulong num2 = 0UL;
			BaseDLL.decode_uint64(msgData.bytes, ref num, ref num2);
			uint dataid = 0U;
			BaseDLL.decode_uint32(msgData.bytes, ref num, ref dataid);
			Item item = new Item();
			item.uid = num2;
			item.dataid = dataid;
			StreamObjectDecoder<Item>.DecodePropertys(ref item, msgData.bytes, ref num, msgData.bytes.Length);
			ItemData itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(item);
			if (itemData == null)
			{
				Logger.LogError("itemData is null in [OnAuctionItemDetailRet] in AuctionItemFrame");
				return;
			}
			this.AddItemDataDetailInfo(num2, itemData);
			this.ShowAuctionNewSystemItemTip(itemData);
		}

		// Token: 0x0600B0B2 RID: 45234 RVA: 0x0026F25C File Offset: 0x0026D65C
		private void ShowAuctionNewSystemItemTip(ItemData itemData)
		{
			if (itemData != null)
			{
				if (itemData.IsTreasure)
				{
					itemData.IsShowTreasureFlagInTipFrame = true;
				}
				else
				{
					itemData.IsShowTreasureFlagInTipFrame = false;
				}
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600B0B3 RID: 45235 RVA: 0x0026F294 File Offset: 0x0026D694
		public void AddItemDataDetailInfo(ulong guid, ItemData itemData)
		{
			if (guid == 0UL)
			{
				return;
			}
			if (this._itemDataDetailDictionary == null)
			{
				this._itemDataDetailDictionary = new Dictionary<ulong, ItemData>();
			}
			if (this._itemDataDetailDictionary.ContainsKey(guid))
			{
				this._itemDataDetailDictionary[guid] = itemData;
			}
			else
			{
				this._itemDataDetailDictionary.Add(guid, itemData);
			}
		}

		// Token: 0x0600B0B4 RID: 45236 RVA: 0x0026F2F0 File Offset: 0x0026D6F0
		public ItemData GetItemDataDetailInfoByGuid(ulong guid)
		{
			if (guid == 0UL)
			{
				return null;
			}
			if (this._itemDataDetailDictionary == null)
			{
				return null;
			}
			if (!this._itemDataDetailDictionary.ContainsKey(guid))
			{
				return null;
			}
			ItemData result = null;
			if (this._itemDataDetailDictionary.TryGetValue(guid, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B0B5 RID: 45237 RVA: 0x0026F340 File Offset: 0x0026D740
		public bool IsShowOnShelfTipOfTreasureItem(Action onCancel, Action onOk)
		{
			if (this.IsNotShowOnShelfTipOfTreasureItem)
			{
				return false;
			}
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(9961, string.Empty, string.Empty);
			if (tableItem == null || string.IsNullOrEmpty(tableItem.Descs))
			{
				Logger.LogErrorFormat("commonTipsDesItem is null or desc is null and commonTipsDescId is {0}", new object[]
				{
					9961
				});
				return false;
			}
			string descStr = AuctionNewUtility.ConvertDescLine(tableItem.Descs);
			string contentLabel = AuctionNewUtility.ConvertDescBlank(descStr);
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateOnShelfTipOfTreasureItem),
				LeftButtonText = TR.Value("common_data_cancel"),
				OnLeftButtonClickCallBack = onCancel,
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onOk
			};
			this.OpenAuctionNewMsgBoxOkCancelFrame(paramData);
			return true;
		}

		// Token: 0x0600B0B6 RID: 45238 RVA: 0x0026F423 File Offset: 0x0026D823
		private void OnUpdateOnShelfTipOfTreasureItem(bool value)
		{
			this.IsNotShowOnShelfTipOfTreasureItem = value;
		}

		// Token: 0x0600B0B7 RID: 45239 RVA: 0x0026F42C File Offset: 0x0026D82C
		public bool IsShowOnShelfTipOfNormalItem(Action onCancel, Action onOk)
		{
			if (this.IsNotShowOnShelfTipOfNormalItem)
			{
				return false;
			}
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(9962, string.Empty, string.Empty);
			if (tableItem == null || string.IsNullOrEmpty(tableItem.Descs))
			{
				Logger.LogErrorFormat("commonTipsDesItem is null or desc is null and commonTipsDescId is {0}", new object[]
				{
					9961
				});
				return false;
			}
			string descStr = AuctionNewUtility.ConvertDescLine(tableItem.Descs);
			string contentLabel = AuctionNewUtility.ConvertDescBlank(descStr);
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateOnShelfTipOfNormalItem),
				LeftButtonText = TR.Value("common_data_cancel"),
				OnLeftButtonClickCallBack = onCancel,
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onOk
			};
			this.OpenAuctionNewMsgBoxOkCancelFrame(paramData);
			return true;
		}

		// Token: 0x0600B0B8 RID: 45240 RVA: 0x0026F50F File Offset: 0x0026D90F
		private void OnUpdateOnShelfTipOfNormalItem(bool value)
		{
			this.IsNotShowOnShelfTipOfNormalItem = value;
		}

		// Token: 0x0600B0B9 RID: 45241 RVA: 0x0026F518 File Offset: 0x0026D918
		public bool OpenTreasureItemOnShelfAgain(Action onCancel, Action onOk)
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(10016, string.Empty, string.Empty);
			if (tableItem == null || string.IsNullOrEmpty(tableItem.Descs))
			{
				Logger.LogErrorFormat("commonTipsDesItem is null or desc is null and commonTipsDescId is {0}", new object[]
				{
					9961
				});
				return false;
			}
			string descStr = AuctionNewUtility.ConvertDescLine(tableItem.Descs);
			string contentLabel = AuctionNewUtility.ConvertDescBlank(descStr);
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				LeftButtonText = TR.Value("common_data_cancel"),
				OnLeftButtonClickCallBack = onCancel,
				RightButtonText = TR.Value("auction_new_on_shelf_again_ensure"),
				OnRightButtonClickCallBack = onOk
			};
			this.OpenAuctionNewMsgBoxOkCancelFrame(paramData);
			return true;
		}

		// Token: 0x0600B0BA RID: 45242 RVA: 0x0026F5D3 File Offset: 0x0026D9D3
		private void OpenAuctionNewMsgBoxOkCancelFrame(CommonMsgBoxOkCancelNewParamData paramData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMsgBoxOkCancelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewMsgBoxOkCancelFrame>(FrameLayer.High, paramData, string.Empty);
		}

		// Token: 0x0600B0BB RID: 45243 RVA: 0x0026F604 File Offset: 0x0026DA04
		public void SendWorldAuctionQueryOnShelfItemPriceReq(ItemData itemData)
		{
			if (itemData == null)
			{
				Logger.LogErrorFormat("SendWorldAuctionQueryOnShelfItemPriceReq and itemData is null", new object[0]);
				return;
			}
			WorldAuctionQueryItemPricesReq worldAuctionQueryItemPricesReq = new WorldAuctionQueryItemPricesReq();
			worldAuctionQueryItemPricesReq.type = 0;
			worldAuctionQueryItemPricesReq.itemTypeId = (uint)itemData.TableID;
			worldAuctionQueryItemPricesReq.strengthen = (uint)itemData.StrengthenLevel;
			worldAuctionQueryItemPricesReq.enhanceType = (byte)itemData.GrowthAttrType;
			if (itemData.SubType == 54)
			{
				worldAuctionQueryItemPricesReq.beadbuffid = (uint)itemData.BeadAdditiveAttributeBuffID;
			}
			this._worldAuctionQueryItemPriceRes = null;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionQueryItemPricesReq>(ServerType.GATE_SERVER, worldAuctionQueryItemPricesReq);
		}

		// Token: 0x0600B0BC RID: 45244 RVA: 0x0026F68C File Offset: 0x0026DA8C
		private void OnReceiveWorldAuctionQueryItemPriceRes(MsgDATA msgData)
		{
			WorldAuctionQueryItemPricesRes worldAuctionQueryItemPricesRes = new WorldAuctionQueryItemPricesRes();
			worldAuctionQueryItemPricesRes.decode(msgData.bytes);
			if (worldAuctionQueryItemPricesRes.type != 0)
			{
				Logger.LogError("OnReceiveWorldAuctionQueryItemPriceRes type is not Item");
				return;
			}
			this._worldAuctionQueryItemPriceRes = worldAuctionQueryItemPricesRes;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewWorldQueryItemPriceResSucceed, null, null, null, null);
		}

		// Token: 0x0600B0BD RID: 45245 RVA: 0x0026F6DB File Offset: 0x0026DADB
		public WorldAuctionQueryItemPricesRes GetWorldAuctionQueryItemPriceRes()
		{
			return this._worldAuctionQueryItemPriceRes;
		}

		// Token: 0x0600B0BE RID: 45246 RVA: 0x0026F6E4 File Offset: 0x0026DAE4
		public void SendWorldAuctionQueryItemPriceListReq(byte auctionState, ItemData itemData)
		{
			if (itemData == null)
			{
				Logger.LogError("SendWorldAuctionQueryItemPriceListReq and itemData is null");
				return;
			}
			WorldAuctionQueryItemPriceListReq worldAuctionQueryItemPriceListReq = new WorldAuctionQueryItemPriceListReq();
			worldAuctionQueryItemPriceListReq.type = 0;
			worldAuctionQueryItemPriceListReq.auctionState = auctionState;
			worldAuctionQueryItemPriceListReq.itemTypeId = (uint)itemData.TableID;
			worldAuctionQueryItemPriceListReq.strengthen = (uint)itemData.StrengthenLevel;
			worldAuctionQueryItemPriceListReq.enhanceType = (byte)itemData.GrowthAttrType;
			this._worldAuctionQueryItemPriceListRes = null;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionQueryItemPriceListReq>(ServerType.GATE_SERVER, worldAuctionQueryItemPriceListReq);
		}

		// Token: 0x0600B0BF RID: 45247 RVA: 0x0026F754 File Offset: 0x0026DB54
		private void OnReceiveWorldAuctionQueryItemPriceListRes(MsgDATA msgData)
		{
			WorldAuctionQueryItemPriceListRes worldAuctionQueryItemPriceListRes = new WorldAuctionQueryItemPriceListRes();
			worldAuctionQueryItemPriceListRes.decode(msgData.bytes);
			this._worldAuctionQueryItemPriceListRes = worldAuctionQueryItemPriceListRes;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewWorldQueryItemPriceListResSucceed, null, null, null, null);
		}

		// Token: 0x0600B0C0 RID: 45248 RVA: 0x0026F78D File Offset: 0x0026DB8D
		public WorldAuctionQueryItemPriceListRes GetWorldAuctionQueryItemPriceListRes()
		{
			return this._worldAuctionQueryItemPriceListRes;
		}

		// Token: 0x0600B0C1 RID: 45249 RVA: 0x0026F798 File Offset: 0x0026DB98
		public void SendWorldAuctionQueryItemTransListReq(ItemData itemData)
		{
			if (itemData == null)
			{
				Logger.LogError("SendWorldAuctionQueryItemTransListReq and itemData is null");
				return;
			}
			WorldAuctionQueryItemTransListReq worldAuctionQueryItemTransListReq = new WorldAuctionQueryItemTransListReq();
			worldAuctionQueryItemTransListReq.itemTypeId = (uint)itemData.TableID;
			worldAuctionQueryItemTransListReq.strengthen = (uint)itemData.StrengthenLevel;
			worldAuctionQueryItemTransListReq.enhanceType = (byte)itemData.GrowthAttrType;
			worldAuctionQueryItemTransListReq.beadBuffId = (uint)itemData.BeadAdditiveAttributeBuffID;
			this._worldAuctionQueryItemTransListRes = null;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionQueryItemTransListReq>(ServerType.GATE_SERVER, worldAuctionQueryItemTransListReq);
		}

		// Token: 0x0600B0C2 RID: 45250 RVA: 0x0026F804 File Offset: 0x0026DC04
		private void OnReceiveWorldAuctionQueryItemTransListRes(MsgDATA msgData)
		{
			WorldAuctionQueryItemTransListRes worldAuctionQueryItemTransListRes = new WorldAuctionQueryItemTransListRes();
			worldAuctionQueryItemTransListRes.decode(msgData.bytes);
			this._worldAuctionQueryItemTransListRes = worldAuctionQueryItemTransListRes;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewWorldQueryItemTransListResSucceed, null, null, null, null);
		}

		// Token: 0x0600B0C3 RID: 45251 RVA: 0x0026F83D File Offset: 0x0026DC3D
		public WorldAuctionQueryItemTransListRes GetWorldAuctionQueryItemTransListRes()
		{
			return this._worldAuctionQueryItemTransListRes;
		}

		// Token: 0x0600B0C4 RID: 45252 RVA: 0x0026F845 File Offset: 0x0026DC45
		public void ResetAuctionNewOnShelfData()
		{
			this._worldAuctionQueryItemTransListRes = null;
			this._worldAuctionQueryItemPriceListRes = null;
			this._worldAuctionQueryItemPriceRes = null;
		}

		// Token: 0x0600B0C5 RID: 45253 RVA: 0x0026F85C File Offset: 0x0026DC5C
		private void OnReceiveWorldAuctionSyncPubPageIds(MsgDATA msgData)
		{
			WorldAuctionSyncPubPageIds worldAuctionSyncPubPageIds = new WorldAuctionSyncPubPageIds();
			worldAuctionSyncPubPageIds.decode(msgData.bytes);
			this._worldAuctionSyncPubPageIds = worldAuctionSyncPubPageIds;
		}

		// Token: 0x0600B0C6 RID: 45254 RVA: 0x0026F884 File Offset: 0x0026DC84
		public bool IsNoticeLayerIdValid(int layerId)
		{
			if (this._worldAuctionSyncPubPageIds == null || this._worldAuctionSyncPubPageIds.pageIds == null || this._worldAuctionSyncPubPageIds.pageIds.Length <= 0)
			{
				return true;
			}
			for (int i = 0; i < this._worldAuctionSyncPubPageIds.pageIds.Length; i++)
			{
				if (this._worldAuctionSyncPubPageIds.pageIds[i] == (uint)layerId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B0C7 RID: 45255 RVA: 0x0026F8F8 File Offset: 0x0026DCF8
		public bool IsNotOnSaleItemNeedBeDeleted(int itemId)
		{
			if (this._worldAuctionSyncPubPageIds == null || this._worldAuctionSyncPubPageIds.shieldItemList == null || this._worldAuctionSyncPubPageIds.shieldItemList.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._worldAuctionSyncPubPageIds.shieldItemList.Length; i++)
			{
				int num = (int)this._worldAuctionSyncPubPageIds.shieldItemList[i];
				if (itemId == num)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B0C8 RID: 45256 RVA: 0x0026F96C File Offset: 0x0026DD6C
		public List<int> GetAuctionNewItemIdList(AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, AuctionNewMenuTabDataModel secondLayerMenuTabDataModel, AuctionNewMenuTabDataModel thirdLayerMenuTabDataModel)
		{
			if (firstLayerMenuTabDataModel == null || firstLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("FirstLayerMenuTabDataModel is Error", new object[0]);
				return null;
			}
			if (secondLayerMenuTabDataModel == null || secondLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("SecondLayerMenuTabDataModel is Error", new object[0]);
				return null;
			}
			int id;
			if (thirdLayerMenuTabDataModel == null || thirdLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				id = secondLayerMenuTabDataModel.AuctionNewFrameTable.ID;
			}
			else
			{
				id = thirdLayerMenuTabDataModel.AuctionNewFrameTable.ID;
			}
			List<int> list;
			if (this._auctionNewItemIdDictionary.TryGetValue(id, out list))
			{
				return list;
			}
			list = AuctionNewUtility.GetItemIdList(firstLayerMenuTabDataModel, secondLayerMenuTabDataModel, thirdLayerMenuTabDataModel);
			if (list == null)
			{
				list = new List<int>();
			}
			if (!this._auctionNewItemIdDictionary.ContainsKey(id))
			{
				this._auctionNewItemIdDictionary.Add(id, list);
			}
			else
			{
				this._auctionNewItemIdDictionary[id] = list;
			}
			return list;
		}

		// Token: 0x0600B0C9 RID: 45257 RVA: 0x0026FA4C File Offset: 0x0026DE4C
		public void ResetAuctionNewItemIdDictionary()
		{
			if (this._auctionNewItemIdDictionary == null || this._auctionNewItemIdDictionary.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in this._auctionNewItemIdDictionary)
			{
				List<int> value = keyValuePair.Value;
				if (value != null)
				{
					value.Clear();
				}
			}
			this._auctionNewItemIdDictionary.Clear();
		}

		// Token: 0x0600B0CA RID: 45258 RVA: 0x0026FABC File Offset: 0x0026DEBC
		public void OnSendWorldActionNoticeReq(ulong itemGuid)
		{
			WorldAuctionAttentReq worldAuctionAttentReq = new WorldAuctionAttentReq();
			worldAuctionAttentReq.autionGuid = itemGuid;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionAttentReq>(ServerType.GATE_SERVER, worldAuctionAttentReq);
			}
		}

		// Token: 0x0600B0CB RID: 45259 RVA: 0x0026FAF4 File Offset: 0x0026DEF4
		private void OnReceiveWorldActionNoticeRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("OnReceiveWorldActionNoticeRes MsgData is null", new object[0]);
				return;
			}
			WorldActionAttentRes worldActionAttentRes = new WorldActionAttentRes();
			worldActionAttentRes.decode(msgData.bytes);
			if (worldActionAttentRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldActionAttentRes.code, string.Empty);
				return;
			}
			if (worldActionAttentRes.aution == null)
			{
				Logger.LogErrorFormat("OnReceiveWorldActionNoticeRes auction is null", new object[0]);
				return;
			}
			if (this._auctionNewItemDetailResDictionary == null)
			{
				Logger.LogErrorFormat("ItemDetailDictionary is null", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, AuctionNewItemDetailData> keyValuePair in this._auctionNewItemDetailResDictionary)
			{
				AuctionNewItemDetailData value = keyValuePair.Value;
				if (value != null && value.ItemDetailDataList != null && value.ItemDetailDataList.Count > 0)
				{
					for (int i = 0; i < value.ItemDetailDataList.Count; i++)
					{
						AuctionBaseInfo auctionBaseInfo = value.ItemDetailDataList[i];
						if (auctionBaseInfo != null && auctionBaseInfo.guid == worldActionAttentRes.aution.guid)
						{
							auctionBaseInfo.attent = worldActionAttentRes.aution.attent;
							auctionBaseInfo.attentNum = worldActionAttentRes.aution.attentNum;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewReceiveNoticeReqSucceed, worldActionAttentRes.aution.guid, null, null, null);
						}
					}
				}
			}
		}

		// Token: 0x0600B0CC RID: 45260 RVA: 0x0026FC60 File Offset: 0x0026E060
		public void ResetPreviewOnShelfItemData()
		{
			if (this._previewOnShelfItemData != null)
			{
				this._previewOnShelfItemData.ResetItemData();
			}
		}

		// Token: 0x0600B0CD RID: 45261 RVA: 0x0026FC78 File Offset: 0x0026E078
		public void SetPreviewOnShelfItemData(int itemId, int strengthLevel, int onShelfPrice)
		{
			if (this._previewOnShelfItemData == null)
			{
				this._previewOnShelfItemData = new AuctionNewPreviewOnShelfItemData();
			}
			this._previewOnShelfItemData.ItemId = itemId;
			this._previewOnShelfItemData.StrengthLevel = strengthLevel;
			this._previewOnShelfItemData.OnShelfPrice = onShelfPrice;
		}

		// Token: 0x0600B0CE RID: 45262 RVA: 0x0026FCB4 File Offset: 0x0026E0B4
		public bool IsOnShelfSameItemLastTime(int itemId, int strengthLevel, ref int onShelfPrice)
		{
			if (this._previewOnShelfItemData == null)
			{
				return false;
			}
			if (this._previewOnShelfItemData.ItemId != itemId)
			{
				return false;
			}
			if (this._previewOnShelfItemData.StrengthLevel != strengthLevel)
			{
				return false;
			}
			onShelfPrice = this._previewOnShelfItemData.OnShelfPrice;
			return true;
		}

		// Token: 0x0600B0CF RID: 45263 RVA: 0x0026FD02 File Offset: 0x0026E102
		public void ResetAuctionNewMagicCardOnSaleRes()
		{
			this._worldAuctionQueryMagicOnSalesRes = null;
		}

		// Token: 0x0600B0D0 RID: 45264 RVA: 0x0026FD0B File Offset: 0x0026E10B
		public WorldAuctionQueryMagicOnsalesRes GetAuctionNewMagicCardOnSaleRes()
		{
			return this._worldAuctionQueryMagicOnSalesRes;
		}

		// Token: 0x0600B0D1 RID: 45265 RVA: 0x0026FD14 File Offset: 0x0026E114
		public void SendAuctionNewMagicCardOnSaleReq(uint itemId)
		{
			this.ResetAuctionNewMagicCardOnSaleRes();
			WorldAuctionQueryMagicOnsalesReq worldAuctionQueryMagicOnsalesReq = new WorldAuctionQueryMagicOnsalesReq();
			worldAuctionQueryMagicOnsalesReq.itemTypeId = itemId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<WorldAuctionQueryMagicOnsalesReq>(ServerType.GATE_SERVER, worldAuctionQueryMagicOnsalesReq);
			}
		}

		// Token: 0x0600B0D2 RID: 45266 RVA: 0x0026FD50 File Offset: 0x0026E150
		private void OnReceiveAuctionNewMagicCardOnSaleRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			WorldAuctionQueryMagicOnsalesRes worldAuctionQueryMagicOnsalesRes = new WorldAuctionQueryMagicOnsalesRes();
			worldAuctionQueryMagicOnsalesRes.decode(msgData.bytes);
			if (worldAuctionQueryMagicOnsalesRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldAuctionQueryMagicOnsalesRes.code, string.Empty);
				return;
			}
			this._worldAuctionQueryMagicOnSalesRes = worldAuctionQueryMagicOnsalesRes;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewWorldQueryMagicCardOnSaleResSucceed, null, null, null, null);
		}

		// Token: 0x040062B8 RID: 25272
		public int DefaultMagicCardZeroStrengthenLevelQuery = 100;

		// Token: 0x040062B9 RID: 25273
		public int MaxAddShelfNum = 5;

		// Token: 0x040062BA RID: 25274
		public int BaseShelfNum = 5;

		// Token: 0x040062BB RID: 25275
		public int OnShelfItemNumber;

		// Token: 0x040062BC RID: 25276
		public int TreasureItemRushBuyTimeInterval = 5;

		// Token: 0x040062BD RID: 25277
		public int TreasureItemRecommendPriceRate = 1;

		// Token: 0x040062BE RID: 25278
		public int PageNumber = 6;

		// Token: 0x040062BF RID: 25279
		private const uint SubTypeCoefficient = 1000U;

		// Token: 0x040062C0 RID: 25280
		private Dictionary<int, List<AuctionNewFilterData>> _auctionNewFilterDataDictionary = new Dictionary<int, List<AuctionNewFilterData>>();

		// Token: 0x040062C1 RID: 25281
		private Dictionary<int, List<AuctionItemBaseInfo>> _auctionNewItemNumResDictionary = new Dictionary<int, List<AuctionItemBaseInfo>>();

		// Token: 0x040062C2 RID: 25282
		private Dictionary<int, AuctionNewItemDetailData> _auctionNewItemDetailResDictionary = new Dictionary<int, AuctionNewItemDetailData>();

		// Token: 0x040062C3 RID: 25283
		private List<EPackageType> _packageTypeList = new List<EPackageType>();

		// Token: 0x040062C4 RID: 25284
		private List<ulong> _packageSellItemUidList = new List<ulong>();

		// Token: 0x040062C5 RID: 25285
		private List<AuctionSellItemData> _packageSellItemDataList = new List<AuctionSellItemData>();

		// Token: 0x040062C6 RID: 25286
		private List<AuctionNewOnShelfDataModel> _onShelfDataModelList = new List<AuctionNewOnShelfDataModel>();

		// Token: 0x040062C7 RID: 25287
		private List<AuctionTransaction> _treasureItemSaleRecordList = new List<AuctionTransaction>();

		// Token: 0x040062C8 RID: 25288
		private List<AuctionTransaction> _treasureItemBuyRecordList = new List<AuctionTransaction>();

		// Token: 0x040062C9 RID: 25289
		private AuctionNewUserData _lastTimeAuctionNewUserData;

		// Token: 0x040062CA RID: 25290
		private Dictionary<ulong, ItemData> _itemDataDetailDictionary = new Dictionary<ulong, ItemData>();

		// Token: 0x040062CB RID: 25291
		public bool IsNotShowOnShelfTipOfTreasureItem;

		// Token: 0x040062CC RID: 25292
		public bool IsNotShowOnShelfTipOfNormalItem;

		// Token: 0x040062CD RID: 25293
		public const int OnShelfTipIdOnTreasureItem = 9961;

		// Token: 0x040062CE RID: 25294
		public const int OnShelfTipIdOnNormalItem = 9962;

		// Token: 0x040062CF RID: 25295
		public const int ShelfAgainTreasureItem = 10016;

		// Token: 0x040062D0 RID: 25296
		public const int ItemForeverFreezeDays = 4000;

		// Token: 0x040062D1 RID: 25297
		private WorldAuctionQueryItemPricesRes _worldAuctionQueryItemPriceRes;

		// Token: 0x040062D2 RID: 25298
		private WorldAuctionQueryItemPriceListRes _worldAuctionQueryItemPriceListRes;

		// Token: 0x040062D3 RID: 25299
		private WorldAuctionQueryItemTransListRes _worldAuctionQueryItemTransListRes;

		// Token: 0x040062D4 RID: 25300
		private WorldAuctionSyncPubPageIds _worldAuctionSyncPubPageIds;

		// Token: 0x040062D5 RID: 25301
		private Dictionary<int, List<int>> _auctionNewItemIdDictionary = new Dictionary<int, List<int>>();

		// Token: 0x040062D6 RID: 25302
		private AuctionNewPreviewOnShelfItemData _previewOnShelfItemData = new AuctionNewPreviewOnShelfItemData();

		// Token: 0x040062D7 RID: 25303
		private WorldAuctionQueryMagicOnsalesRes _worldAuctionQueryMagicOnSalesRes;
	}
}
