using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012D9 RID: 4825
	public class AccountShopDataManager : DataManager<AccountShopDataManager>
	{
		// Token: 0x0600BB21 RID: 47905 RVA: 0x002B50F8 File Offset: 0x002B34F8
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BB22 RID: 47906 RVA: 0x002B50FC File Offset: 0x002B34FC
		public sealed override void Initialize()
		{
			this.Clear();
			this.AllAccountShopDataList.Clear();
			this.SpecialItemNumDic.Clear();
			this._BindNetMsg();
		}

		// Token: 0x0600BB23 RID: 47907 RVA: 0x002B5120 File Offset: 0x002B3520
		public sealed override void Clear()
		{
			this.AllAccountShopDataList.Clear();
			this.SpecialItemNumDic.Clear();
			this._UnBindNetMsg();
			this.m_bNetBind = false;
			this._ClearTempFilterDic();
		}

		// Token: 0x0600BB24 RID: 47908 RVA: 0x002B514C File Offset: 0x002B354C
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(608802U, new Action<MsgDATA>(this._OnWorldAccountShopItemQueryRes));
				NetProcess.AddMsgHandler(608804U, new Action<MsgDATA>(this._OnWorldAccountShopItemBuyRes));
				NetProcess.AddMsgHandler(602825U, new Action<MsgDATA>(this._OnWorldMallBuyGotInfoSync));
				NetProcess.AddMsgHandler(600606U, new Action<MsgDATA>(this._OnWorldAccountCounterNotify));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600BB25 RID: 47909 RVA: 0x002B51C4 File Offset: 0x002B35C4
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(608802U, new Action<MsgDATA>(this._OnWorldAccountShopItemQueryRes));
			NetProcess.RemoveMsgHandler(608804U, new Action<MsgDATA>(this._OnWorldAccountShopItemBuyRes));
			NetProcess.RemoveMsgHandler(602825U, new Action<MsgDATA>(this._OnWorldMallBuyGotInfoSync));
			NetProcess.RemoveMsgHandler(600606U, new Action<MsgDATA>(this._OnWorldAccountCounterNotify));
		}

		// Token: 0x0600BB26 RID: 47910 RVA: 0x002B522C File Offset: 0x002B362C
		private void _SetShopFilterDataListTemp(ShopTable shopNewTable)
		{
			if (shopNewTable == null)
			{
				return;
			}
			if (!this.CheckIsShopTableFormatRight(shopNewTable))
			{
				return;
			}
			this._ClearTempFilterDic();
			int num = (shopNewTable.Filter.Count <= shopNewTable.Filter2.Count) ? shopNewTable.Filter2.Count : shopNewTable.Filter.Count;
			List<int> list = null;
			List<int> list2 = null;
			for (int i = 0; i < num; i++)
			{
				if (this._tempShopTableFilterDic.TryGetValue(1, out list))
				{
					if (list == null)
					{
						list = new List<int>();
					}
					if (i >= shopNewTable.Filter.Count)
					{
						list.Add(0);
					}
					else
					{
						list.Add((int)shopNewTable.Filter[i]);
					}
				}
				else
				{
					if (list == null)
					{
						list = new List<int>();
					}
					if (i >= shopNewTable.Filter.Count)
					{
						list.Add(0);
					}
					else
					{
						list.Add((int)shopNewTable.Filter[i]);
					}
					this._tempShopTableFilterDic.Add(1, list);
				}
				if (this._tempShopTableFilterDic.TryGetValue(2, out list2))
				{
					if (list2 == null)
					{
						list2 = new List<int>();
					}
					if (i >= shopNewTable.Filter2.Count)
					{
						list2.Add(0);
					}
					else
					{
						list2.Add(shopNewTable.Filter2[i]);
					}
				}
				else
				{
					if (list2 == null)
					{
						list2 = new List<int>();
					}
					if (i >= shopNewTable.Filter2.Count)
					{
						list2.Add(0);
					}
					else
					{
						list2.Add(shopNewTable.Filter2[i]);
					}
					this._tempShopTableFilterDic.Add(2, list2);
				}
			}
		}

		// Token: 0x0600BB27 RID: 47911 RVA: 0x002B53D8 File Offset: 0x002B37D8
		private void _ClearTempFilterDic()
		{
			if (this._tempShopTableFilterDic == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in this._tempShopTableFilterDic)
			{
				List<int> value = keyValuePair.Value;
				if (value != null)
				{
					value.Clear();
				}
			}
			this._tempShopTableFilterDic.Clear();
		}

		// Token: 0x0600BB28 RID: 47912 RVA: 0x002B5438 File Offset: 0x002B3838
		public void SendWorldAccountShopItemQueryReq(AccountShopQueryIndex item)
		{
			WorldAccountShopItemQueryReq worldAccountShopItemQueryReq = new WorldAccountShopItemQueryReq();
			worldAccountShopItemQueryReq.queryIndex = item;
			NetManager.Instance().SendCommand<WorldAccountShopItemQueryReq>(ServerType.GATE_SERVER, worldAccountShopItemQueryReq);
		}

		// Token: 0x0600BB29 RID: 47913 RVA: 0x002B5460 File Offset: 0x002B3860
		public void SendWorldAccountShopItemBuyReq(AccountShopQueryIndex item, uint id, uint num)
		{
			WorldAccountShopItemBuyReq worldAccountShopItemBuyReq = new WorldAccountShopItemBuyReq();
			worldAccountShopItemBuyReq.queryIndex = item;
			worldAccountShopItemBuyReq.buyShopItemId = id;
			worldAccountShopItemBuyReq.buyShopItemNum = num;
			NetManager.Instance().SendCommand<WorldAccountShopItemBuyReq>(ServerType.GATE_SERVER, worldAccountShopItemBuyReq);
		}

		// Token: 0x0600BB2A RID: 47914 RVA: 0x002B5498 File Offset: 0x002B3898
		private void _OnWorldAccountShopItemQueryRes(MsgDATA msg)
		{
			WorldAccountShopItemQueryRes worldAccountShopItemQueryRes = new WorldAccountShopItemQueryRes();
			worldAccountShopItemQueryRes.decode(msg.bytes);
			if (worldAccountShopItemQueryRes.resCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldAccountShopItemQueryRes.resCode, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AccountShopReqFailed, null, null, null, null);
				return;
			}
			for (int i = 0; i < this.AllAccountShopDataList.Count; i++)
			{
				if (worldAccountShopItemQueryRes.queryIndex.shopId == this.AllAccountShopDataList[i].queryIndex.shopId && worldAccountShopItemQueryRes.queryIndex.tabType == this.AllAccountShopDataList[i].queryIndex.tabType && worldAccountShopItemQueryRes.queryIndex.jobType == this.AllAccountShopDataList[i].queryIndex.jobType)
				{
					this.AllAccountShopDataList.Remove(this.AllAccountShopDataList[i]);
				}
			}
			AccountShopData accountShopData = new AccountShopData();
			accountShopData.queryIndex.shopId = worldAccountShopItemQueryRes.queryIndex.shopId;
			accountShopData.queryIndex.tabType = worldAccountShopItemQueryRes.queryIndex.tabType;
			accountShopData.queryIndex.jobType = worldAccountShopItemQueryRes.queryIndex.jobType;
			accountShopData.shopItems = new AccountShopItemInfo[worldAccountShopItemQueryRes.shopItems.Length];
			for (int j = 0; j < worldAccountShopItemQueryRes.shopItems.Length; j++)
			{
				accountShopData.shopItems[j] = worldAccountShopItemQueryRes.shopItems[j];
			}
			accountShopData.nextGroupOnSaleTime = worldAccountShopItemQueryRes.nextGroupOnSaleTime;
			this.AllAccountShopDataList.Add(accountShopData);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AccountShopUpdate, worldAccountShopItemQueryRes.queryIndex, null, null, null);
		}

		// Token: 0x0600BB2B RID: 47915 RVA: 0x002B5640 File Offset: 0x002B3A40
		private void _OnWorldAccountShopItemBuyRes(MsgDATA msg)
		{
			WorldAccountShopItemBuyRes worldAccountShopItemBuyRes = new WorldAccountShopItemBuyRes();
			worldAccountShopItemBuyRes.decode(msg.bytes);
			if (worldAccountShopItemBuyRes.resCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldAccountShopItemBuyRes.resCode, string.Empty);
				return;
			}
			for (int i = 0; i < this.AllAccountShopDataList.Count; i++)
			{
				if (worldAccountShopItemBuyRes.queryIndex.shopId == this.AllAccountShopDataList[i].queryIndex.shopId && worldAccountShopItemBuyRes.queryIndex.tabType == this.AllAccountShopDataList[i].queryIndex.tabType && worldAccountShopItemBuyRes.queryIndex.jobType == this.AllAccountShopDataList[i].queryIndex.jobType)
				{
					for (int j = 0; j < this.AllAccountShopDataList[i].shopItems.Length; j++)
					{
						if (this.AllAccountShopDataList[i].shopItems[j].shopItemId == worldAccountShopItemBuyRes.buyShopItemId)
						{
							this.AllAccountShopDataList[i].shopItems[j].accountRestBuyNum = worldAccountShopItemBuyRes.accountRestBuyNum;
							this.AllAccountShopDataList[i].shopItems[j].roleRestBuyNum = worldAccountShopItemBuyRes.roleRestBuyNum;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AccountShopItemUpdata, worldAccountShopItemBuyRes.queryIndex, null, null, null);
						}
					}
				}
			}
		}

		// Token: 0x0600BB2C RID: 47916 RVA: 0x002B57A4 File Offset: 0x002B3BA4
		private void _OnWorldMallBuyGotInfoSync(MsgDATA msg)
		{
			WorldPlayerMallBuyGotInfoSync worldPlayerMallBuyGotInfoSync = new WorldPlayerMallBuyGotInfoSync();
			worldPlayerMallBuyGotInfoSync.decode(msg.bytes);
			this.SpecialItemNumDic[(int)worldPlayerMallBuyGotInfoSync.mallBuyGotInfo.itemDataId] = (int)worldPlayerMallBuyGotInfoSync.mallBuyGotInfo.buyGotNum;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SpeicialItemUpdate, (int)worldPlayerMallBuyGotInfoSync.mallBuyGotInfo.itemDataId, null, null, null);
		}

		// Token: 0x0600BB2D RID: 47917 RVA: 0x002B5808 File Offset: 0x002B3C08
		private void _OnWorldAccountCounterNotify(MsgDATA msg)
		{
			WorldAccountCounterNotify worldAccountCounterNotify = new WorldAccountCounterNotify();
			worldAccountCounterNotify.decode(msg.bytes);
			for (int i = 0; i < worldAccountCounterNotify.accCounterList.Length; i++)
			{
				this.myAccountCountDic[(int)worldAccountCounterNotify.accCounterList[i].type] = worldAccountCounterNotify.accCounterList[i].num;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AccountSpecialItemUpdate, null, null, null, null);
		}

		// Token: 0x0600BB2E RID: 47918 RVA: 0x002B5878 File Offset: 0x002B3C78
		public AccountShopItemInfo[] GetAccountShopData(AccountShopQueryIndex item)
		{
			for (int i = 0; i < this.AllAccountShopDataList.Count; i++)
			{
				if (item.shopId == this.AllAccountShopDataList[i].queryIndex.shopId && item.tabType == this.AllAccountShopDataList[i].queryIndex.tabType && item.jobType == this.AllAccountShopDataList[i].queryIndex.jobType)
				{
					return this.AllAccountShopDataList[i].shopItems;
				}
			}
			return null;
		}

		// Token: 0x0600BB2F RID: 47919 RVA: 0x002B5918 File Offset: 0x002B3D18
		public int GetShopNextTime(AccountShopQueryIndex item)
		{
			for (int i = 0; i < this.AllAccountShopDataList.Count; i++)
			{
				if (item.shopId == this.AllAccountShopDataList[i].queryIndex.shopId && item.tabType == this.AllAccountShopDataList[i].queryIndex.tabType && item.jobType == this.AllAccountShopDataList[i].queryIndex.jobType)
				{
					return (int)this.AllAccountShopDataList[i].nextGroupOnSaleTime;
				}
			}
			return 0;
		}

		// Token: 0x0600BB30 RID: 47920 RVA: 0x002B59B7 File Offset: 0x002B3DB7
		public int GetSpecialItemNum(int id)
		{
			if (this.SpecialItemNumDic.ContainsKey(id))
			{
				return this.SpecialItemNumDic[id];
			}
			return 0;
		}

		// Token: 0x0600BB31 RID: 47921 RVA: 0x002B59D8 File Offset: 0x002B3DD8
		public ulong GetAccountSpecialItemNum(AccountCounterType type)
		{
			if (this.myAccountCountDic.ContainsKey((int)type))
			{
				return this.myAccountCountDic[(int)type];
			}
			return 0UL;
		}

		// Token: 0x0600BB32 RID: 47922 RVA: 0x002B59FC File Offset: 0x002B3DFC
		public void OpenAccountShop(int shopId, int shopChildrenId = 0, int shopItemType = 0, int npcId = -1)
		{
			ShopNewParamData shopNewParam = new ShopNewParamData
			{
				ShopId = shopId,
				ShopChildId = shopChildrenId,
				ShopItemType = shopItemType,
				NpcId = npcId
			};
			this.OpenAccountShop(shopNewParam);
		}

		// Token: 0x0600BB33 RID: 47923 RVA: 0x002B5A38 File Offset: 0x002B3E38
		public void OpenAccountShop(ShopNewParamData shopNewParam)
		{
			if (shopNewParam == null)
			{
				return;
			}
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopNewParam.ShopId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - OpenAccountShop failed, shopNewTable is null and shop id is {0}", new object[]
				{
					shopNewParam.ShopId
				});
				return;
			}
			if (tableItem.BindType != ShopTable.eBindType.ACCOUNT_BIND)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - OpenAccountShop failed, shop {0}, bind type is not account shop !", new object[]
				{
					shopNewParam.ShopId
				});
				return;
			}
			this._SetShopFilterDataListTemp(tableItem);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AccountShopFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountShopFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountShopFrame>(FrameLayer.Middle, shopNewParam, string.Empty);
		}

		// Token: 0x0600BB34 RID: 47924 RVA: 0x002B5AEC File Offset: 0x002B3EEC
		public AccountShopPurchaseType GetAccShopItemBuyLimitType(AccountShopItemInfo itemInfo)
		{
			AccountShopPurchaseType result = AccountShopPurchaseType.NotLimit;
			if (itemInfo == null)
			{
				return result;
			}
			if (itemInfo.accountLimitBuyNum == 0U && itemInfo.roleLimitBuyNum == 0U)
			{
				result = AccountShopPurchaseType.NotLimit;
			}
			else if (itemInfo.accountLimitBuyNum > 0U && itemInfo.roleLimitBuyNum == 0U)
			{
				result = AccountShopPurchaseType.AccountBind;
			}
			else if (itemInfo.accountLimitBuyNum == 0U && itemInfo.roleLimitBuyNum > 0U)
			{
				result = AccountShopPurchaseType.RoleBind;
			}
			else if (itemInfo.accountLimitBuyNum > 0U && itemInfo.roleLimitBuyNum > 0U)
			{
				result = (AccountShopPurchaseType)3;
			}
			return result;
		}

		// Token: 0x0600BB35 RID: 47925 RVA: 0x002B5B78 File Offset: 0x002B3F78
		public int GetAccountShopItemCanBuyNum(AccountShopItemInfo _accShopItemInfo)
		{
			int result = 0;
			if (_accShopItemInfo == null)
			{
				return result;
			}
			if (_accShopItemInfo.accountLimitBuyNum > 0U && _accShopItemInfo.roleLimitBuyNum == 0U)
			{
				result = (int)_accShopItemInfo.accountRestBuyNum;
			}
			else if (_accShopItemInfo.accountLimitBuyNum == 0U && _accShopItemInfo.roleLimitBuyNum > 0U)
			{
				result = (int)_accShopItemInfo.roleRestBuyNum;
			}
			else if (_accShopItemInfo.accountLimitBuyNum > 0U && _accShopItemInfo.roleLimitBuyNum > 0U)
			{
				if (_accShopItemInfo.accountRestBuyNum > 0U && _accShopItemInfo.roleRestBuyNum > 0U)
				{
					int accountRestBuyNum = (int)_accShopItemInfo.accountRestBuyNum;
					int roleRestBuyNum = (int)_accShopItemInfo.roleRestBuyNum;
					result = ((accountRestBuyNum > roleRestBuyNum) ? roleRestBuyNum : accountRestBuyNum);
				}
			}
			else if (_accShopItemInfo.accountLimitBuyNum == 0U && _accShopItemInfo.roleLimitBuyNum == 0U)
			{
				return -1;
			}
			return result;
		}

		// Token: 0x0600BB36 RID: 47926 RVA: 0x002B5C40 File Offset: 0x002B4040
		public int GetAccountShopRefreshTime(AccountShopItemInfo[] oneTabShopItemInfos, AccountShopPurchaseType defaultBindType = AccountShopPurchaseType.AccountBind, bool bReverse = false)
		{
			if (oneTabShopItemInfos == null)
			{
				return 0;
			}
			List<int> list = new List<int>();
			foreach (AccountShopItemInfo accountShopItemInfo in oneTabShopItemInfos)
			{
				if (accountShopItemInfo != null)
				{
					if (accountShopItemInfo.accountRefreshType != 0 || accountShopItemInfo.roleRefreshType != 0)
					{
						if (accountShopItemInfo.roleRefreshType > 0)
						{
							int num = (int)accountShopItemInfo.roleBuyRecordNextRefreshTimestamp;
							if (defaultBindType == AccountShopPurchaseType.RoleBind && num > 0)
							{
								list.Add(num);
							}
						}
						else if (accountShopItemInfo.accountRefreshType > 0)
						{
							int num = (int)accountShopItemInfo.accountBuyRecordNextRefreshTimestamp;
							if (defaultBindType == AccountShopPurchaseType.AccountBind && num > 0)
							{
								list.Add(num);
							}
						}
					}
				}
			}
			if (bReverse)
			{
				list.Sort((int x, int y) => -x.CompareTo(y));
			}
			else
			{
				list.Sort((int x, int y) => x.CompareTo(y));
			}
			if (list != null && list.Count > 0)
			{
				int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				int num2 = list[0];
				if (num2 > serverTime)
				{
					return num2 - serverTime;
				}
			}
			return 0;
		}

		// Token: 0x0600BB37 RID: 47927 RVA: 0x002B5D78 File Offset: 0x002B4178
		public AccountShopQueryIndex GetAccountShopQueryIndex(ShopNewFrameViewData shopViewData)
		{
			AccountShopQueryIndex accountShopQueryIndex = new AccountShopQueryIndex();
			if (shopViewData == null)
			{
				return accountShopQueryIndex;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopViewData.shopId, string.Empty, string.Empty) == null)
			{
				return accountShopQueryIndex;
			}
			if (shopViewData.currentSelectedTabData != null)
			{
				ShopNewMainTabType mainTabType = shopViewData.currentSelectedTabData.MainTabType;
				if (mainTabType == ShopNewMainTabType.ShopType)
				{
					int index = shopViewData.currentSelectedTabData.Index;
					accountShopQueryIndex.shopId = (uint)index;
					ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(index, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return accountShopQueryIndex;
					}
					if (!this.CheckIsChildShopTable(tableItem))
					{
						return accountShopQueryIndex;
					}
					accountShopQueryIndex.tabType = (byte)tableItem.SubType[0];
				}
				else if (mainTabType == ShopNewMainTabType.ItemType)
				{
					accountShopQueryIndex.shopId = (uint)shopViewData.shopId;
					accountShopQueryIndex.tabType = (byte)shopViewData.currentSelectedTabData.Index;
				}
			}
			if (shopViewData.currFirstFilterData != null)
			{
				accountShopQueryIndex.jobType = (byte)shopViewData.currFirstFilterData.Index;
			}
			return accountShopQueryIndex;
		}

		// Token: 0x0600BB38 RID: 47928 RVA: 0x002B5E74 File Offset: 0x002B4274
		public void SendWorldAccountShopItemQueryReq(ShopNewFrameViewData shopViewData)
		{
			if (shopViewData == null)
			{
				return;
			}
			AccountShopQueryIndex accountShopQueryIndex = this.GetAccountShopQueryIndex(shopViewData);
			this.SendWorldAccountShopItemQueryReq(accountShopQueryIndex);
		}

		// Token: 0x0600BB39 RID: 47929 RVA: 0x002B5E98 File Offset: 0x002B4298
		public AccountShopItemInfo[] GetAccountShopData(ShopNewFrameViewData shopViewData)
		{
			if (shopViewData == null)
			{
				return null;
			}
			AccountShopQueryIndex accountShopQueryIndex = this.GetAccountShopQueryIndex(shopViewData);
			return this.GetAccountShopData(accountShopQueryIndex);
		}

		// Token: 0x0600BB3A RID: 47930 RVA: 0x002B5EBC File Offset: 0x002B42BC
		public bool CheckIsShopTableFormatRight(ShopTable shopTable)
		{
			bool result = true;
			if (shopTable == null)
			{
				result = false;
			}
			if (shopTable.ChildrenLength != shopTable.SubTypeLength && shopTable.ChildrenLength > 1)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsShopTableFormatRight : shop table error, children shop length > 1 but children length != subtype length, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			if (shopTable.ChildrenLength != shopTable.FilterLength && shopTable.ChildrenLength > 1)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsShopTableFormatRight : shop table error, children shop length > 1 but children length != filter length, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			if (shopTable.ChildrenLength != shopTable.Filter2Length && shopTable.ChildrenLength > 1)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsShopTableFormatRight : shop table error, children shop length > 1 but children length != filter2 length, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			int num = (shopTable.Filter.Count <= shopTable.Filter2.Count) ? shopTable.Filter2.Count : shopTable.Filter.Count;
			if (num != shopTable.SubTypeLength)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsShopTableFormatRight : shop table error, filter1 or filter2 length != subtype length, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			if (shopTable.SubTypeLength != shopTable.RefreshCycleLength && shopTable.Refresh == 2)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsShopTableFormatRight : shop table error, refresh cycle  length != subtype length and refresh == 2, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			return result;
		}

		// Token: 0x0600BB3B RID: 47931 RVA: 0x002B6060 File Offset: 0x002B4460
		public bool CheckIsChildShopTable(ShopTable shopTable)
		{
			bool result = true;
			if (shopTable == null)
			{
				result = false;
			}
			if (!this.CheckIsShopTableFormatRight(shopTable))
			{
				result = false;
			}
			if (shopTable.ChildrenLength != 1)
			{
				Logger.LogErrorFormat("[AccountShopDataManager] - CheckIsChildShopTable : shop table error, children length > 0, shopId is {0}", new object[]
				{
					shopTable.ID.ToString()
				});
				result = false;
			}
			return result;
		}

		// Token: 0x0600BB3C RID: 47932 RVA: 0x002B60BC File Offset: 0x002B44BC
		public bool CheckHasChildShop(int shopId)
		{
			bool result = false;
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.ChildrenLength > 1)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600BB3D RID: 47933 RVA: 0x002B60F8 File Offset: 0x002B44F8
		public List<int> GetShopBaseMoneyIds(int shopId, int shopTabIndex = 0)
		{
			List<int> list = new List<int>();
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int num = 0;
				if (!string.IsNullOrEmpty(tableItem.ExtraShowMoneys) && int.TryParse(tableItem.ExtraShowMoneys, out num) && num > 0 && !list.Contains(num))
				{
					list.Add(num);
				}
				if (tableItem.CurrencyShowType > 0 && tableItem.CurrencyExtraItem != null)
				{
					for (int i = 0; i < tableItem.CurrencyExtraItem.Count; i++)
					{
						string text = tableItem.CurrencyExtraItem[i];
						if (!string.IsNullOrEmpty(text))
						{
							string[] array = text.Split(new char[]
							{
								'_'
							});
							if (array != null)
							{
								for (int j = 0; j < array.Length; j++)
								{
									int num2 = 0;
									if (!string.IsNullOrEmpty(array[j]) && int.TryParse(array[j], out num2) && num2 > 0 && !list.Contains(num2))
									{
										list.Add(num2);
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB3E RID: 47934 RVA: 0x002B6234 File Offset: 0x002B4634
		public List<int> GetShopExtraMoneyIds(AccountShopItemInfo[] accShopItemInfos)
		{
			List<int> list = new List<int>();
			if (accShopItemInfos == null)
			{
				return list;
			}
			foreach (AccountShopItemInfo accountShopItemInfo in accShopItemInfos)
			{
				if (accountShopItemInfo != null)
				{
					if (accountShopItemInfo.costItems != null && accountShopItemInfo.costItems.Length > 0)
					{
						for (int j = 0; j < accountShopItemInfo.costItems.Length; j++)
						{
							ItemReward itemReward = accountShopItemInfo.costItems[j];
							if (itemReward != null)
							{
								if (list != null && !list.Contains((int)itemReward.id))
								{
									list.Add((int)itemReward.id);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB3F RID: 47935 RVA: 0x002B62EC File Offset: 0x002B46EC
		public int GetShopHelpId(int shopId)
		{
			int result = 0;
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.HelpID;
			}
			return result;
		}

		// Token: 0x0600BB40 RID: 47936 RVA: 0x002B6320 File Offset: 0x002B4720
		public string GetShopName(int shopId)
		{
			string result = "帐号商店";
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.ShopName;
			}
			return result;
		}

		// Token: 0x0600BB41 RID: 47937 RVA: 0x002B6358 File Offset: 0x002B4758
		public string GetShopRefreshTimeDesc(int shopId)
		{
			string result = string.Empty;
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.ShopItemRefreshDesc;
			}
			return result;
		}

		// Token: 0x0600BB42 RID: 47938 RVA: 0x002B6390 File Offset: 0x002B4790
		public ShopTable.eFilter GetFilterDataType(AccountShopFilterType filterType, int index)
		{
			if (this._tempShopTableFilterDic == null)
			{
				return ShopTable.eFilter.SF_NONE;
			}
			List<int> list = null;
			if (!this._tempShopTableFilterDic.TryGetValue((int)filterType, out list))
			{
				return ShopTable.eFilter.SF_NONE;
			}
			if (index < 0 || index >= list.Count)
			{
				return ShopTable.eFilter.SF_NONE;
			}
			return (ShopTable.eFilter)list[index];
		}

		// Token: 0x0600BB43 RID: 47939 RVA: 0x002B63E0 File Offset: 0x002B47E0
		public void RestoreFilterDataByIndex(ref ShopNewFilterData tempFilterData, ShopNewFilterData currSelectedFilterData, AccountShopFilterType filterType, int index)
		{
			if (tempFilterData == null)
			{
				return;
			}
			ShopTable.eFilter filterDataType = this.GetFilterDataType(filterType, index);
			if (filterDataType < ShopTable.eFilter.SF_NONE || filterDataType >= ShopTable.eFilter.SF_NUM)
			{
				tempFilterData = null;
			}
			else if (currSelectedFilterData != null)
			{
				tempFilterData = currSelectedFilterData;
			}
			else
			{
				tempFilterData = DataManager<ShopNewDataManager>.GetInstance().GetDefaultFilterDataByFilterType(filterDataType);
			}
		}

		// Token: 0x0600BB44 RID: 47940 RVA: 0x002B6432 File Offset: 0x002B4832
		public bool CheckIsAdventureTeamAccShop(ShopTable _shopTable)
		{
			return _shopTable != null && (_shopTable.BindType == ShopTable.eBindType.ACCOUNT_BIND && _shopTable.ShopKind == ShopTable.eShopKind.SK_BlessCrystal);
		}

		// Token: 0x0600BB45 RID: 47941 RVA: 0x002B6458 File Offset: 0x002B4858
		public bool CheckIsAdventureTeamAccShopOpen()
		{
			return DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened;
		}

		// Token: 0x04006934 RID: 26932
		public const int ADVENTURE_TEAM_SHOP_ID = 50;

		// Token: 0x04006935 RID: 26933
		public const int ADVENTURE_TEAM_BLESS_CRYSTAL_CHILD_SHOP_ID = 51;

		// Token: 0x04006936 RID: 26934
		public const int ADVENTURE_TEAM_BOUNTY_CHILD_SHOP_ID = 52;

		// Token: 0x04006937 RID: 26935
		private bool m_bNetBind;

		// Token: 0x04006938 RID: 26936
		private List<AccountShopData> AllAccountShopDataList = new List<AccountShopData>();

		// Token: 0x04006939 RID: 26937
		private Dictionary<int, int> SpecialItemNumDic = new Dictionary<int, int>();

		// Token: 0x0400693A RID: 26938
		private Dictionary<int, ulong> myAccountCountDic = new Dictionary<int, ulong>();

		// Token: 0x0400693B RID: 26939
		private Dictionary<int, List<int>> _tempShopTableFilterDic = new Dictionary<int, List<int>>();
	}
}
