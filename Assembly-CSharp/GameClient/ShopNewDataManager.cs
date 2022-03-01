using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012DF RID: 4831
	public class ShopNewDataManager : DataManager<ShopNewDataManager>
	{
		// Token: 0x0600BB4E RID: 47950 RVA: 0x002B6589 File Offset: 0x002B4989
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600BB4F RID: 47951 RVA: 0x002B6591 File Offset: 0x002B4991
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(500926U, new Action<MsgDATA>(this.OnSyncShopNewShopItemTable));
		}

		// Token: 0x0600BB50 RID: 47952 RVA: 0x002B65A9 File Offset: 0x002B49A9
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
		}

		// Token: 0x0600BB51 RID: 47953 RVA: 0x002B65B7 File Offset: 0x002B49B7
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(500926U, new Action<MsgDATA>(this.OnSyncShopNewShopItemTable));
		}

		// Token: 0x0600BB52 RID: 47954 RVA: 0x002B65D0 File Offset: 0x002B49D0
		public void ClearData()
		{
			foreach (KeyValuePair<int, List<ShopNewShopItemTable>> keyValuePair in this._shopNewShopItemTableDictionary)
			{
				List<ShopNewShopItemTable> value = keyValuePair.Value;
				if (value != null)
				{
					value.Clear();
				}
			}
			this._shopNewShopItemTableDictionary.Clear();
			this._shopNewShopDataList.Clear();
			foreach (KeyValuePair<int, List<int>> keyValuePair2 in this._shopCostItemIdDictionary)
			{
				List<int> value2 = keyValuePair2.Value;
				if (value2 != null)
				{
					value2.Clear();
				}
			}
			this._shopCostItemIdDictionary.Clear();
			for (int i = 0; i < this._shopTabCostItemList.Count; i++)
			{
				if (this._shopTabCostItemList[i] != null && this._shopTabCostItemList[i].CostItems != null)
				{
					this._shopTabCostItemList[i].CostItems.Clear();
				}
			}
			this._shopTabCostItemList.Clear();
			foreach (KeyValuePair<ShopTable.eFilter, List<ShopNewFilterData>> keyValuePair3 in this._shopFilterDataDictionary)
			{
				List<ShopNewFilterData> value3 = keyValuePair3.Value;
				if (value3 != null)
				{
					value3.Clear();
				}
			}
			this._shopFilterDataDictionary.Clear();
			this._shopFirstFilterIndexList.Clear();
			this._shopSecondFilterIndexList.Clear();
			this._shopFilterTitleIndexList.Clear();
			this._shopHideFilterItemList.Clear();
		}

		// Token: 0x0600BB53 RID: 47955 RVA: 0x002B6754 File Offset: 0x002B4B54
		public void InitShopData(int shopId)
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("ShopNewTable is null and shopId is {0}", new object[]
				{
					shopId
				});
				return;
			}
			FlatBufferArray<int> children = tableItem.Children;
			if (children.Count <= 0 || (children.Count == 1 && children[0] == 0))
			{
				this.InitShopItemTableByShopId(shopId);
			}
			else
			{
				for (int i = 0; i < children.Count; i++)
				{
					int num = children[i];
					if (num != 0)
					{
						this.InitShopItemTableByShopId(num);
					}
				}
			}
			this.InitShopFilterDataList(tableItem);
		}

		// Token: 0x0600BB54 RID: 47956 RVA: 0x002B6808 File Offset: 0x002B4C08
		private void InitShopFilterDataList(ShopTable shopNewTable)
		{
			this._shopFirstFilterIndexList.Clear();
			this._shopSecondFilterIndexList.Clear();
			this._shopFilterTitleIndexList.Clear();
			this._shopHideFilterItemList.Clear();
			int num = (shopNewTable.Filter.Count <= shopNewTable.Filter2.Count) ? shopNewTable.Filter2.Count : shopNewTable.Filter.Count;
			for (int i = 0; i < num; i++)
			{
				if (i >= shopNewTable.Filter.Count)
				{
					this._shopFirstFilterIndexList.Add(0);
				}
				else
				{
					this._shopFirstFilterIndexList.Add((int)shopNewTable.Filter[i]);
				}
				if (i >= shopNewTable.Filter2.Count)
				{
					this._shopSecondFilterIndexList.Add(0);
				}
				else
				{
					this._shopSecondFilterIndexList.Add(shopNewTable.Filter2[i]);
				}
				if (i >= shopNewTable.IsShowFilterTitle.Count)
				{
					this._shopFilterTitleIndexList.Add(0);
				}
				else
				{
					this._shopFilterTitleIndexList.Add(shopNewTable.IsShowFilterTitle[i]);
				}
			}
			if (shopNewTable.HideFilterItem != null && shopNewTable.HideFilterItem.Count > 0)
			{
				for (int j = 0; j < shopNewTable.HideFilterItem.Count; j++)
				{
					if (shopNewTable.HideFilterItem[j] != 0)
					{
						this._shopHideFilterItemList.Add(shopNewTable.HideFilterItem[j]);
					}
				}
			}
		}

		// Token: 0x0600BB55 RID: 47957 RVA: 0x002B699C File Offset: 0x002B4D9C
		public void InitShopItemTableByShopId(int shopId)
		{
			if (this._shopNewShopDataList.Find((ShopNewShopData x) => x.ShopId == shopId) == null)
			{
				ShopNewShopData item = new ShopNewShopData
				{
					ShopId = shopId
				};
				this._shopNewShopDataList.Add(item);
			}
			List<ShopNewShopItemTable> list = null;
			if (!this._shopNewShopItemTableDictionary.TryGetValue(shopId, out list))
			{
				list = new List<ShopNewShopItemTable>();
				this._shopNewShopItemTableDictionary.Add(shopId, list);
			}
			list.Clear();
			List<int> list2 = null;
			if (!this._shopCostItemIdDictionary.TryGetValue(shopId, out list2))
			{
				list2 = new List<int>();
				this._shopCostItemIdDictionary.Add(shopId, list2);
			}
			list2.Clear();
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ShopItemTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ShopItemTable shopItemTable = keyValuePair.Value as ShopItemTable;
				if (shopItemTable != null)
				{
					if (shopItemTable.ShopID == shopId)
					{
						ShopNewShopItemTable item2 = new ShopNewShopItemTable
						{
							ShopId = shopId,
							ShopItemId = shopItemTable.ID,
							LimitBuyTimes = -1,
							ShopItemTable = shopItemTable
						};
						list.Add(item2);
						if (tableItem != null && tableItem.CurrencyShowType == 0 && !list2.Contains(shopItemTable.CostItemID))
						{
							list2.Add(shopItemTable.CostItemID);
						}
					}
				}
			}
			list.Sort((ShopNewShopItemTable x, ShopNewShopItemTable y) => x.ShopItemTable.SortID.CompareTo(y.ShopItemTable.SortID));
			ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				try
				{
					int num = int.Parse(tableItem2.ExtraShowMoneys);
					if (num > 0 && !list2.Contains(num))
					{
						list2.Add(num);
					}
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("excption is {0}", new object[]
					{
						ex.ToString()
					});
				}
			}
			list2.Sort((int x, int y) => x.CompareTo(y));
			if (tableItem != null && tableItem.CurrencyShowType == 1)
			{
				this.AddShopTabExtraCostItem(tableItem);
			}
		}

		// Token: 0x0600BB56 RID: 47958 RVA: 0x002B6C3C File Offset: 0x002B503C
		private void AddShopTabExtraCostItem(ShopTable shopTable)
		{
			int id = shopTable.ID;
			for (int i = 0; i < shopTable.SubType.Count; i++)
			{
				int shopTabIndex = (int)shopTable.SubType[i];
				if (i < shopTable.CurrencyExtraItem.Count)
				{
					string text = shopTable.CurrencyExtraItem[i];
					string[] array = text.Split(new char[]
					{
						'_'
					});
					int num = array.Length;
					if (num > 0)
					{
						for (int j = 0; j < num; j++)
						{
							string s = array[j];
							int num2 = int.Parse(s);
							if (num2 > 0)
							{
								this.AddOneShopTabCostItem(id, shopTabIndex, num2);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BB57 RID: 47959 RVA: 0x002B6D00 File Offset: 0x002B5100
		private void AddOneShopTabCostItem(int shopId, int shopTabIndex, int costItem)
		{
			bool flag = false;
			ShopNewShopTabCostItem shopNewShopTabCostItem = null;
			for (int i = 0; i < this._shopTabCostItemList.Count; i++)
			{
				shopNewShopTabCostItem = this._shopTabCostItemList[i];
				if (shopNewShopTabCostItem != null)
				{
					if (shopNewShopTabCostItem.ShopId == shopId && shopNewShopTabCostItem.ShopTabIndex == shopTabIndex)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				if (!shopNewShopTabCostItem.CostItems.Contains(costItem))
				{
					shopNewShopTabCostItem.CostItems.Add(costItem);
				}
			}
			else
			{
				shopNewShopTabCostItem = new ShopNewShopTabCostItem
				{
					ShopId = shopId,
					ShopTabIndex = shopTabIndex
				};
				shopNewShopTabCostItem.CostItems.Add(costItem);
				this._shopTabCostItemList.Add(shopNewShopTabCostItem);
			}
		}

		// Token: 0x0600BB58 RID: 47960 RVA: 0x002B6DBC File Offset: 0x002B51BC
		private void SortShopTabCostItem()
		{
			for (int i = 0; i < this._shopTabCostItemList.Count; i++)
			{
				if (this._shopTabCostItemList[i] != null && this._shopTabCostItemList[i].CostItems != null && this._shopTabCostItemList[i].CostItems.Count > 1)
				{
					this._shopTabCostItemList[i].CostItems.Sort((int x, int y) => x.CompareTo(y));
				}
			}
		}

		// Token: 0x0600BB59 RID: 47961 RVA: 0x002B6E5C File Offset: 0x002B525C
		public List<ShopNewMainTabData> GetShopNewMainTabDataList(int shopId)
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("ShopNewTable is null and shopId is {0}", new object[]
				{
					shopId
				});
				return null;
			}
			List<ShopNewMainTabData> list = new List<ShopNewMainTabData>();
			FlatBufferArray<int> children = tableItem.Children;
			if (children.Count <= 0 || (children.Count == 1 && children[0] == 0))
			{
				for (int i = 0; i < tableItem.SubType.Count; i++)
				{
					if (tableItem.SubType[i] != ShopTable.eSubType.ST_NONE)
					{
						ShopNewMainTabData item = new ShopNewMainTabData
						{
							MainTabType = ShopNewMainTabType.ItemType,
							Index = (int)tableItem.SubType[i],
							Name = TR.Value(string.Format(TR.Value("shop_tab_format"), (int)tableItem.SubType[i]))
						};
						list.Add(item);
					}
				}
			}
			else
			{
				for (int j = 0; j < children.Count; j++)
				{
					int num = children[j];
					ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(num, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ShopNewMainTabData shopNewMainTabData = new ShopNewMainTabData
						{
							MainTabType = ShopNewMainTabType.ShopType,
							Index = num
						};
						if (string.IsNullOrEmpty(tableItem2.ShopSimpleName))
						{
							shopNewMainTabData.Name = tableItem2.ShopName;
						}
						else
						{
							shopNewMainTabData.Name = tableItem2.ShopSimpleName;
						}
						list.Add(shopNewMainTabData);
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB5A RID: 47962 RVA: 0x002B7004 File Offset: 0x002B5404
		public List<ShopNewShopItemTable> GetOriginalShopNewShopItemList(int shopId)
		{
			List<ShopNewShopItemTable> result = null;
			this._shopNewShopItemTableDictionary.TryGetValue(shopId, out result);
			return result;
		}

		// Token: 0x0600BB5B RID: 47963 RVA: 0x002B7024 File Offset: 0x002B5424
		public List<ShopNewShopItemTable> GetShopNewNeedShowingShopItemList(int shopId, ShopNewMainTabData shopNewMainTabData = null, ShopNewFilterData firstFilterData = null, ShopNewFilterData secondFilterData = null)
		{
			List<ShopNewShopItemTable> list = null;
			if (shopNewMainTabData == null || shopNewMainTabData.MainTabType == ShopNewMainTabType.ItemType)
			{
				list = this.GetOriginalShopNewShopItemList(shopId);
			}
			else if (shopNewMainTabData.MainTabType == ShopNewMainTabType.ShopType)
			{
				list = this.GetOriginalShopNewShopItemList(shopNewMainTabData.Index);
			}
			if (list == null)
			{
				return null;
			}
			List<ShopNewShopItemTable> list2 = new List<ShopNewShopItemTable>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].ShopItemTable != null)
				{
					list2.Add(list[i]);
				}
			}
			list2.Sort((ShopNewShopItemTable x, ShopNewShopItemTable y) => x.ShopItemTable.SortID.CompareTo(y.ShopItemTable.SortID));
			if (shopNewMainTabData != null && shopNewMainTabData.MainTabType == ShopNewMainTabType.ItemType)
			{
				ShopTable.eSubType itemType = (ShopTable.eSubType)shopNewMainTabData.Index;
				if (itemType != ShopTable.eSubType.ST_NONE)
				{
					list2 = list2.FindAll((ShopNewShopItemTable x) => x.ShopItemTable != null && x.ShopItemTable.SubType == (ShopItemTable.eSubType)itemType);
				}
			}
			list2 = this.FilterShopItemTableListByFilterData(list2, firstFilterData, secondFilterData);
			return this.FilterShopItemTableListByShopLevel(list2);
		}

		// Token: 0x0600BB5C RID: 47964 RVA: 0x002B712C File Offset: 0x002B552C
		private List<ShopNewShopItemTable> FilterShopItemTableListByShopLevel(List<ShopNewShopItemTable> shopNewShopItemTableList)
		{
			if (shopNewShopItemTableList == null || shopNewShopItemTableList.Count <= 0)
			{
				return shopNewShopItemTableList;
			}
			int count = shopNewShopItemTableList.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				ShopNewShopItemTable shopNewShopItemTable = shopNewShopItemTableList[i];
				if (shopNewShopItemTable.ShopItemTable != null)
				{
					if (shopNewShopItemTable.ShopItemTable.ShowLevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						shopNewShopItemTableList.RemoveAt(i);
					}
				}
			}
			return shopNewShopItemTableList;
		}

		// Token: 0x0600BB5D RID: 47965 RVA: 0x002B71A4 File Offset: 0x002B55A4
		private List<ShopNewShopItemTable> FilterShopItemTableListByFilterData(List<ShopNewShopItemTable> shopNewShopItemTableList, ShopNewFilterData firstFilterData, ShopNewFilterData secondFilterData)
		{
			if (shopNewShopItemTableList == null || shopNewShopItemTableList.Count <= 0)
			{
				return shopNewShopItemTableList;
			}
			int count = shopNewShopItemTableList.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				ShopNewShopItemTable shopNewShopItemTable = shopNewShopItemTableList[i];
				if (shopNewShopItemTable.ShopItemTable != null)
				{
					int itemID = shopNewShopItemTable.ShopItemTable.ItemID;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
					if (tableItem == null)
					{
						shopNewShopItemTableList.RemoveAt(i);
					}
					else
					{
						bool flag = this.IsItemNeedShow(tableItem, firstFilterData);
						if (flag)
						{
							flag = this.IsItemNeedShow(tableItem, secondFilterData);
						}
						if (!flag)
						{
							shopNewShopItemTableList.RemoveAt(i);
						}
					}
				}
			}
			return shopNewShopItemTableList;
		}

		// Token: 0x0600BB5E RID: 47966 RVA: 0x002B7260 File Offset: 0x002B5660
		private bool IsItemNeedShow(ItemTable itemTable, ShopNewFilterData filterData)
		{
			if (filterData == null || filterData.FilterType == ShopTable.eFilter.SF_NONE)
			{
				return true;
			}
			bool flag = false;
			if (filterData.FilterType == ShopTable.eFilter.SF_ARMOR)
			{
				flag = this.IsItemNeedShowByItemType(itemTable, filterData);
			}
			else if (filterData.FilterType == ShopTable.eFilter.SF_OCCU)
			{
				if (itemTable.Occu.Count == 0 || (itemTable.Occu.Count == 1 && itemTable.Occu[0] == 0))
				{
					flag = true;
				}
				else
				{
					for (int i = 0; i < itemTable.Occu.Count; i++)
					{
						int num = itemTable.Occu[i];
						if (num == 0 || num == filterData.Index)
						{
							flag = true;
						}
						if (!flag)
						{
							JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
							if (tableItem != null && tableItem.prejob == filterData.Index)
							{
								flag = true;
							}
						}
					}
				}
				if (!flag && itemTable.Occu2.Count >= 1)
				{
					for (int j = 0; j < itemTable.Occu2.Count; j++)
					{
						int id = itemTable.Occu2[j];
						JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.prejob == filterData.Index)
						{
							flag = true;
						}
					}
				}
			}
			else if (filterData.FilterType == ShopTable.eFilter.SF_OCCU2)
			{
				if (itemTable.Occu2.Count == 0 || (itemTable.Occu2.Count == 1 && itemTable.Occu2[0] == 0))
				{
					flag = true;
				}
				else
				{
					for (int k = 0; k < itemTable.Occu2.Count; k++)
					{
						if (itemTable.Occu2[k] == 0 || itemTable.Occu2[k] == filterData.Index)
						{
							flag = true;
						}
					}
				}
			}
			else if (filterData.FilterType == ShopTable.eFilter.SF_PLAY_OCCU)
			{
				if (itemTable.Occu2.Count == 0 || (itemTable.Occu2.Count == 1 && itemTable.Occu2[0] == 0))
				{
					flag = true;
				}
				else
				{
					for (int l = 0; l < itemTable.Occu2.Count; l++)
					{
						if (itemTable.Occu2[l] == 0 || itemTable.Occu2[l] == DataManager<PlayerBaseData>.GetInstance().JobTableID)
						{
							flag = true;
						}
					}
				}
			}
			else if (filterData.FilterType == ShopTable.eFilter.SF_LEVEL || filterData.FilterType == ShopTable.eFilter.SF_LEVEL_2)
			{
				if (filterData.FilterTableItem == null || filterData.FilterTableItem.Parameter == null || filterData.FilterTableItem.Parameter.Count <= 1)
				{
					flag = true;
				}
				else if (itemTable.NeedLevel >= filterData.FilterTableItem.Parameter[0] && itemTable.NeedLevel <= filterData.FilterTableItem.Parameter[1])
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x0600BB5F RID: 47967 RVA: 0x002B758C File Offset: 0x002B598C
		private bool IsItemNeedShowByItemType(ItemTable itemTable, ShopNewFilterData filterData)
		{
			if (filterData.FilterTableItem == null || filterData.FilterTableItem.Parameter == null || filterData.FilterTableItem.Parameter.Count <= 0)
			{
				return true;
			}
			if (itemTable.ThirdType == (ItemTable.eThirdType)filterData.FilterTableItem.Parameter[0])
			{
				return true;
			}
			List<ShopNewFilterData> shopNewFilterDataList = this.GetShopNewFilterDataList(ShopTable.eFilter.SF_ARMOR);
			for (int i = 0; i < shopNewFilterDataList.Count; i++)
			{
				ShopNewFilterData shopNewFilterData = shopNewFilterDataList[i];
				if (shopNewFilterData.FilterTableItem != null && shopNewFilterData.FilterTableItem.Parameter != null && shopNewFilterData.FilterTableItem.Parameter.Count == 1 && itemTable.ThirdType == (ItemTable.eThirdType)shopNewFilterData.FilterTableItem.Parameter[0])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600BB60 RID: 47968 RVA: 0x002B7664 File Offset: 0x002B5A64
		public List<int> GetShopCostItems(int shopId)
		{
			List<int> result = null;
			this._shopCostItemIdDictionary.TryGetValue(shopId, out result);
			return result;
		}

		// Token: 0x0600BB61 RID: 47969 RVA: 0x002B7684 File Offset: 0x002B5A84
		public List<int> GetShopCostItemsByShopTab(int shopId, int shopTabIndex)
		{
			List<int> result = null;
			for (int i = 0; i < this._shopTabCostItemList.Count; i++)
			{
				ShopNewShopTabCostItem shopNewShopTabCostItem = this._shopTabCostItemList[i];
				if (shopNewShopTabCostItem != null)
				{
					if (shopNewShopTabCostItem.ShopId == shopId && shopNewShopTabCostItem.ShopTabIndex == shopTabIndex)
					{
						result = shopNewShopTabCostItem.CostItems;
					}
				}
			}
			return result;
		}

		// Token: 0x0600BB62 RID: 47970 RVA: 0x002B76E8 File Offset: 0x002B5AE8
		public void BuyGoods(int shopId, int goodId, int count, List<ItemInfo> info)
		{
			SceneShopBuy cmd = new SceneShopBuy
			{
				shopId = (byte)shopId,
				shopItemId = (uint)goodId,
				num = (ushort)count,
				costExtraItems = info.ToArray()
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneShopBuy>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopBuyRet>(delegate(SceneShopBuyRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					List<ShopNewShopItemTable> list = null;
					if (this._shopNewShopItemTableDictionary == null || this._shopNewShopItemTableDictionary.Count <= 0)
					{
						return;
					}
					if (!this._shopNewShopItemTableDictionary.TryGetValue(shopId, out list))
					{
						return;
					}
					if (list == null || list.Count <= 0)
					{
						return;
					}
					ShopNewShopItemTable shopNewShopItemTable = list.Find((ShopNewShopItemTable x) => (long)x.ShopItemId == (long)((ulong)msgRet.shopItemId));
					if (shopNewShopItemTable == null)
					{
						return;
					}
					shopNewShopItemTable.LimitBuyTimes = ((shopNewShopItemTable.LimitBuyTimes < 0) ? -1 : ((int)msgRet.newNum));
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopNewBuyGoodsSuccess, shopNewShopItemTable.ShopItemId, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BB63 RID: 47971 RVA: 0x002B7768 File Offset: 0x002B5B68
		public ShopNewFilterData GetDefaultFilterDataByFilterType(ShopTable.eFilter filterType)
		{
			ShopNewFilterData shopNewFilterData = new ShopNewFilterData();
			shopNewFilterData.FilterType = filterType;
			if (filterType == ShopTable.eFilter.SF_OCCU)
			{
				int baseJobID = Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID);
				shopNewFilterData.Index = baseJobID;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(baseJobID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					shopNewFilterData.Name = tableItem.Name;
				}
			}
			else if (filterType == ShopTable.eFilter.SF_OCCU2)
			{
				int betterJobId = Utility.GetBetterJobId(DataManager<PlayerBaseData>.GetInstance().JobTableID);
				shopNewFilterData.Index = betterJobId;
				JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(betterJobId, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					shopNewFilterData.Name = tableItem2.Name;
				}
			}
			else if (filterType == ShopTable.eFilter.SF_ARMOR)
			{
				List<ShopNewFilterData> shopNewFilterDataList = this.GetShopNewFilterDataList(ShopTable.eFilter.SF_ARMOR);
				if (shopNewFilterDataList != null && shopNewFilterDataList.Count > 0)
				{
					shopNewFilterData = shopNewFilterDataList[0];
					JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.SuitArmorType > 0)
					{
						for (int i = 0; i < shopNewFilterDataList.Count; i++)
						{
							ShopNewFilterData shopNewFilterData2 = shopNewFilterDataList[i];
							if (shopNewFilterData2 != null && shopNewFilterData2.Index == tableItem3.SuitArmorType)
							{
								shopNewFilterData = shopNewFilterData2;
							}
						}
					}
				}
			}
			else if (filterType == ShopTable.eFilter.SF_LEVEL || filterType == ShopTable.eFilter.SF_LEVEL_2)
			{
				List<ShopNewFilterData> shopNewFilterDataList2 = this.GetShopNewFilterDataList(filterType);
				if (shopNewFilterDataList2 != null && shopNewFilterDataList2.Count > 0)
				{
					ShopNewFilterData shopNewFilterData3 = shopNewFilterDataList2[0];
					bool flag = false;
					ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
					for (int j = 1; j < shopNewFilterDataList2.Count; j++)
					{
						ShopNewFilterData shopNewFilterData4 = shopNewFilterDataList2[j];
						if (shopNewFilterData4 != null && shopNewFilterData4.FilterTableItem != null && shopNewFilterData4.FilterTableItem.Parameter != null && shopNewFilterData4.FilterTableItem.Parameter.Length > 0)
						{
							if ((int)level >= shopNewFilterData4.FilterTableItem.Parameter[0] && (int)level <= shopNewFilterData4.FilterTableItem.Parameter[1])
							{
								flag = true;
								shopNewFilterData = shopNewFilterData4;
								break;
							}
							if ((int)level > shopNewFilterData4.FilterTableItem.Parameter[1])
							{
								shopNewFilterData3 = shopNewFilterData4;
							}
						}
					}
					if (!flag)
					{
						shopNewFilterData = shopNewFilterData3;
					}
				}
			}
			return shopNewFilterData;
		}

		// Token: 0x0600BB64 RID: 47972 RVA: 0x002B79D5 File Offset: 0x002B5DD5
		public int GetFirstFilterIndex(int index)
		{
			if (index < 0 || index >= this._shopFirstFilterIndexList.Count)
			{
				return 0;
			}
			return this._shopFirstFilterIndexList[index];
		}

		// Token: 0x0600BB65 RID: 47973 RVA: 0x002B79FD File Offset: 0x002B5DFD
		public int GetSecondFilterIndex(int index)
		{
			if (index < 0 || index >= this._shopSecondFilterIndexList.Count)
			{
				return 0;
			}
			return this._shopSecondFilterIndexList[index];
		}

		// Token: 0x0600BB66 RID: 47974 RVA: 0x002B7A25 File Offset: 0x002B5E25
		public int GetFilterTitleIndex(int index)
		{
			if (index < 0 || index >= this._shopFilterTitleIndexList.Count)
			{
				return 0;
			}
			return this._shopFilterTitleIndexList[index];
		}

		// Token: 0x0600BB67 RID: 47975 RVA: 0x002B7A50 File Offset: 0x002B5E50
		public List<ShopNewFilterData> GetShopNewFilterDataList(ShopTable.eFilter filterType)
		{
			if (filterType == ShopTable.eFilter.SF_NONE)
			{
				return null;
			}
			List<ShopNewFilterData> list = null;
			if (!this._shopFilterDataDictionary.TryGetValue(filterType, out list))
			{
				list = this.InitShopNewFilterDataListByFilterType(filterType);
				this._shopFilterDataDictionary.Add(filterType, list);
			}
			return list;
		}

		// Token: 0x0600BB68 RID: 47976 RVA: 0x002B7A90 File Offset: 0x002B5E90
		private List<ShopNewFilterData> InitShopNewFilterDataListByFilterType(ShopTable.eFilter filterType)
		{
			switch (filterType)
			{
			case ShopTable.eFilter.SF_OCCU:
				return this.InitBaseJobFilterDataList();
			case ShopTable.eFilter.SF_ARMOR:
				return this.InitFilterDataListByFilterType(ShopTable.eFilter.SF_ARMOR);
			case ShopTable.eFilter.SF_OCCU2:
				return this.InitBetterJobFilterDataList();
			case ShopTable.eFilter.SF_LEVEL:
				return this.InitFilterDataListByFilterType(ShopTable.eFilter.SF_LEVEL);
			case ShopTable.eFilter.SF_LEVEL_2:
				return this.InitFilterDataListByFilterType(ShopTable.eFilter.SF_LEVEL_2);
			}
			return null;
		}

		// Token: 0x0600BB69 RID: 47977 RVA: 0x002B7AEC File Offset: 0x002B5EEC
		private List<ShopNewFilterData> InitBaseJobFilterDataList()
		{
			List<ShopNewFilterData> list = new List<ShopNewFilterData>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JobTable jobTable = keyValuePair.Value as JobTable;
					if (jobTable != null && jobTable.JobType == 0 && jobTable.Open == 1)
					{
						ShopNewFilterData item = new ShopNewFilterData
						{
							FilterType = ShopTable.eFilter.SF_OCCU,
							Name = jobTable.Name,
							Index = jobTable.ID
						};
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB6A RID: 47978 RVA: 0x002B7B94 File Offset: 0x002B5F94
		private List<ShopNewFilterData> InitBetterJobFilterDataList()
		{
			List<ShopNewFilterData> list = new List<ShopNewFilterData>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JobTable jobTable = keyValuePair.Value as JobTable;
					if (jobTable != null && jobTable.JobType == 1 && jobTable.Open == 1)
					{
						ShopNewFilterData item = new ShopNewFilterData
						{
							FilterType = ShopTable.eFilter.SF_OCCU2,
							Name = jobTable.Name,
							Index = jobTable.ID
						};
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB6B RID: 47979 RVA: 0x002B7C3C File Offset: 0x002B603C
		private List<ShopNewFilterData> InitFilterDataListByFilterType(ShopTable.eFilter eFilter)
		{
			List<ShopNewFilterData> list = new List<ShopNewFilterData>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ShopNewFilterTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ShopNewFilterTable shopNewFilterTable = keyValuePair.Value as ShopNewFilterTable;
					if (shopNewFilterTable != null && shopNewFilterTable.FilterItemType == (int)eFilter)
					{
						bool flag = false;
						for (int i = 0; i < this._shopHideFilterItemList.Count; i++)
						{
							if (this._shopHideFilterItemList[i] == shopNewFilterTable.ID)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							ShopNewFilterData item = new ShopNewFilterData
							{
								FilterType = eFilter,
								Name = shopNewFilterTable.Name,
								Index = shopNewFilterTable.ID,
								FilterTableItem = shopNewFilterTable
							};
							list.Add(item);
						}
					}
				}
			}
			list.Sort((ShopNewFilterData x, ShopNewFilterData y) => x.FilterTableItem.Sort.CompareTo(y.FilterTableItem.Sort));
			return list;
		}

		// Token: 0x0600BB6C RID: 47980 RVA: 0x002B7D4C File Offset: 0x002B614C
		public void OpenShopNewFrame(int shopId, int shopChildrenId = 0, int shopItemType = 0, int npcId = -1)
		{
			ShopNewUtility.OnCloseShopNewFrame();
			ShopNewParamData shopNewParamData = new ShopNewParamData
			{
				ShopId = shopId,
				ShopChildId = shopChildrenId,
				ShopItemType = shopItemType,
				NpcId = npcId
			};
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("The shopNewTable is null and shop id is {0}", new object[]
				{
					shopId
				});
				return;
			}
			this.InitShopData(shopId);
			if (tableItem.Refresh == 0)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopNewFrame>(FrameLayer.Middle, shopNewParamData, string.Empty);
			}
			else
			{
				this.OpenRefreshShopFrame(shopId, shopNewParamData);
			}
		}

		// Token: 0x0600BB6D RID: 47981 RVA: 0x002B7DEA File Offset: 0x002B61EA
		private void OpenRefreshShopFrame(int shopId, ShopNewParamData shopNewParamData)
		{
			this.SendSceneShopQuery(shopId);
			this.WaitSceneShopQueryRet(shopId, shopNewParamData);
		}

		// Token: 0x0600BB6E RID: 47982 RVA: 0x002B7DFB File Offset: 0x002B61FB
		public void SendRequestChildrenShopData(int shopId, int childrenShopId)
		{
			this.SendSceneShopQuery(childrenShopId);
			this.WaitRequestChildrenShopData(shopId, childrenShopId);
		}

		// Token: 0x0600BB6F RID: 47983 RVA: 0x002B7E0C File Offset: 0x002B620C
		private void SendSceneShopQuery(int shopId)
		{
			SceneShopQuery sceneShopQuery = new SceneShopQuery();
			sceneShopQuery.shopId = (byte)shopId;
			sceneShopQuery.cache = 0;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneShopQuery>(ServerType.GATE_SERVER, sceneShopQuery);
		}

		// Token: 0x0600BB70 RID: 47984 RVA: 0x002B7E40 File Offset: 0x002B6240
		private void WaitRequestChildrenShopData(int shopId, int childrenShopId)
		{
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopQueryRet>(delegate(SceneShopQueryRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopNewRequestChildrenShopDataSucceed, shopId, childrenShopId, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600BB71 RID: 47985 RVA: 0x002B7E80 File Offset: 0x002B6280
		private void WaitSceneShopQueryRet(int shopId, ShopNewParamData shopNewParamData)
		{
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopQueryRet>(delegate(SceneShopQueryRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopNewFrame>(FrameLayer.Middle, shopNewParamData, string.Empty);
			}, true, 15f, null);
		}

		// Token: 0x0600BB72 RID: 47986 RVA: 0x002B7EB8 File Offset: 0x002B62B8
		public ShopNewShopData GetShopNewShopData(int shopId)
		{
			if (this._shopNewShopDataList == null || this._shopNewShopDataList.Count == 0)
			{
				return null;
			}
			return this._shopNewShopDataList.Find((ShopNewShopData x) => x.ShopId == shopId);
		}

		// Token: 0x0600BB73 RID: 47987 RVA: 0x002B7F08 File Offset: 0x002B6308
		private void OnSyncShopNewShopItemTable(MsgDATA msg)
		{
			if (CommonUtility.IsInGameBattleScene())
			{
				return;
			}
			int num = 0;
			CustomDecoder.ProtoShop protoShop;
			if (!CustomDecoder.DecodeShop(out protoShop, msg.bytes, ref num, msg.bytes.Length))
			{
				Logger.LogErrorFormat("Open ShopNewFrame OnSyncShopItem Decode is error", new object[0]);
				return;
			}
			if (protoShop == null)
			{
				Logger.LogErrorFormat("Open ShopNewFrame OnSyncShopItem Decode msgRet is null", new object[0]);
				return;
			}
			int shopId = (int)protoShop.shopID;
			ShopNewShopData shopNewShopData = this._shopNewShopDataList.Find((ShopNewShopData x) => x.ShopId == shopId);
			if (shopNewShopData == null)
			{
				shopNewShopData = new ShopNewShopData();
				this._shopNewShopDataList.Add(shopNewShopData);
			}
			shopNewShopData.ShopId = shopId;
			shopNewShopData.RefreshCost = (int)protoShop.refreshCost;
			shopNewShopData.ResetRefreshTime = protoShop.restRefreshTime;
			shopNewShopData.WeekResetRefreshTime = protoShop.WeekRestRefreshTime;
			shopNewShopData.MonthRefreshTime = protoShop.MonthRefreshTime;
			shopNewShopData.RefreshLeftTimes = (int)protoShop.refreshTimes;
			shopNewShopData.RefreshAllTimes = (int)protoShop.refreshAllTimes;
			List<ShopNewShopItemTable> list = null;
			if (!this._shopNewShopItemTableDictionary.TryGetValue(shopId, out list))
			{
				list = new List<ShopNewShopItemTable>();
				this._shopNewShopItemTableDictionary.Add(shopId, list);
			}
			list.Clear();
			for (int i = 0; i < protoShop.shopItemList.Count; i++)
			{
				CustomDecoder.ProtoShopItem protoShopItem = protoShop.shopItemList[i];
				int shopItemId = (int)protoShopItem.shopItemId;
				ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(shopItemId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("ShopItemTable is null and shopItemId is {0}", new object[]
					{
						shopItemId
					});
				}
				else
				{
					ShopNewShopItemTable shopNewShopItemTable = new ShopNewShopItemTable();
					shopNewShopItemTable.ShopItemTable = tableItem;
					shopNewShopItemTable.ShopId = shopId;
					shopNewShopItemTable.ShopItemId = shopItemId;
					shopNewShopItemTable.VipLimitLevel = (int)protoShopItem.vipLv;
					shopNewShopItemTable.VipDiscount = (int)protoShopItem.vipDiscount;
					shopNewShopItemTable.LimitBuyTimes = (int)protoShopItem.restNum;
					shopNewShopItemTable.GoodDiscount = (int)protoShopItem.discount;
					list.Add(shopNewShopItemTable);
				}
			}
		}

		// Token: 0x0600BB74 RID: 47988 RVA: 0x002B8118 File Offset: 0x002B6518
		public override void Update(float time)
		{
			this.timeInterval += time;
			if (this.timeInterval >= 1f)
			{
				this.timeInterval = 0f;
				if (this._shopNewShopDataList != null && this._shopNewShopDataList.Count > 0)
				{
					for (int i = 0; i < this._shopNewShopDataList.Count; i++)
					{
						ShopNewShopData shopNewShopData = this._shopNewShopDataList[i];
						if (shopNewShopData != null)
						{
							if (shopNewShopData.ResetRefreshTime <= 0U)
							{
								shopNewShopData.ResetRefreshTime = 0U;
							}
							else
							{
								shopNewShopData.ResetRefreshTime -= 1U;
							}
							if (shopNewShopData.WeekResetRefreshTime <= 0U)
							{
								shopNewShopData.WeekResetRefreshTime = 0U;
							}
							else
							{
								shopNewShopData.WeekResetRefreshTime -= 1U;
							}
							if (shopNewShopData.MonthRefreshTime <= 0U)
							{
								shopNewShopData.MonthRefreshTime = 0U;
							}
							else
							{
								shopNewShopData.MonthRefreshTime -= 1U;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BB75 RID: 47989 RVA: 0x002B8210 File Offset: 0x002B6610
		public void JumpToShopById(int shopId)
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.OpenLevel)
				{
					string msgContent = string.Format(TR.Value("exchange_mall_not_open"), tableItem.OpenLevel, tableItem.ShopName);
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					this.OpenShopNewFrame(shopId, 0, 0, -1);
				}
			}
			else
			{
				Logger.LogErrorFormat("ShopTable is null and shop id is {0}", new object[]
				{
					shopId
				});
			}
		}

		// Token: 0x0600BB76 RID: 47990 RVA: 0x002B82A4 File Offset: 0x002B66A4
		public bool IsShopNewFrameByShopId(int shopId)
		{
			if (this._shopNewShopIdList == null || this._shopNewShopIdList.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._shopNewShopIdList.Length; i++)
			{
				if (this._shopNewShopIdList[i] == shopId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BB77 RID: 47991 RVA: 0x002B82F8 File Offset: 0x002B66F8
		public bool IsShowOldChangeNew(ShopNewShopItemTable shopNewShopItemTable)
		{
			if (shopNewShopItemTable.ShopId != 7 && shopNewShopItemTable.ShopId != 9)
			{
				return false;
			}
			int subType = (int)shopNewShopItemTable.ShopItemTable.SubType;
			return (subType == 14 || subType == 3 || subType == 2) && !string.IsNullOrEmpty(shopNewShopItemTable.ShopItemTable.OldChangeNewItemID);
		}

		// Token: 0x0600BB78 RID: 47992 RVA: 0x002B835C File Offset: 0x002B675C
		public List<ulong> GetPackageOldChangeNewEquip(int id)
		{
			return DataManager<ShopDataManager>.GetInstance().GetPackageOldChangeNewEquip(id);
		}

		// Token: 0x0600BB79 RID: 47993 RVA: 0x002B8369 File Offset: 0x002B6769
		public bool IsPackageHaveExchangeEquipment(int itemId, EPackageType type, ref ItemData oldChangeNewItemData)
		{
			return DataManager<ShopDataManager>.GetInstance()._IsPackHaveExchangeEquipment(itemId, type, ref oldChangeNewItemData);
		}

		// Token: 0x0600BB7A RID: 47994 RVA: 0x002B8378 File Offset: 0x002B6778
		public void GetOldChangeNewItem(ShopItemTable shopItemTable, List<AwardItemData> oldChangeNewItemList)
		{
			DataManager<ShopDataManager>.GetInstance()._GetOldChangeNewItem(shopItemTable, oldChangeNewItemList);
		}

		// Token: 0x0600BB7B RID: 47995 RVA: 0x002B8388 File Offset: 0x002B6788
		public bool IsMoneyItemShowName(int moneyItemId)
		{
			if (this.moneyItemShowName == null || this.moneyItemShowName.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.moneyItemShowName.Length; i++)
			{
				if (moneyItemId == this.moneyItemShowName[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BB7C RID: 47996 RVA: 0x002B83DC File Offset: 0x002B67DC
		public AccountShopItemInfo[] TryFilterAccountShopItemInfos(AccountShopItemInfo[] accShopItemInfos, ShopNewFilterData firstFilterData = null, ShopNewFilterData secondFilterData = null)
		{
			if (accShopItemInfos == null)
			{
				return null;
			}
			List<AccountShopItemInfo> list = new List<AccountShopItemInfo>();
			for (int i = 0; i < accShopItemInfos.Length; i++)
			{
				if (accShopItemInfos[i] != null)
				{
					list.Add(accShopItemInfos[i]);
				}
			}
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			int count = list.Count;
			for (int j = count - 1; j >= 0; j--)
			{
				AccountShopItemInfo accountShopItemInfo = list[j];
				int itemDataId = (int)accountShopItemInfo.itemDataId;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemDataId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					list.RemoveAt(j);
				}
				else
				{
					bool flag = this.IsItemNeedShow(tableItem, firstFilterData);
					if (flag)
					{
						flag = this.IsItemNeedShow(tableItem, secondFilterData);
					}
					if (!flag)
					{
						list.RemoveAt(j);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x04006957 RID: 26967
		private int[] _shopNewShopIdList = new int[]
		{
			5,
			7,
			9,
			13,
			14,
			15,
			16,
			21,
			22,
			23,
			24,
			25
		};

		// Token: 0x04006958 RID: 26968
		private int[] moneyItemShowName = new int[]
		{
			600000064,
			600000065
		};

		// Token: 0x04006959 RID: 26969
		public readonly Color specialColor = new Color(0.95686275f, 0.8627451f, 0.5372549f, 1f);

		// Token: 0x0400695A RID: 26970
		private Dictionary<int, List<ShopNewShopItemTable>> _shopNewShopItemTableDictionary = new Dictionary<int, List<ShopNewShopItemTable>>();

		// Token: 0x0400695B RID: 26971
		private List<ShopNewShopData> _shopNewShopDataList = new List<ShopNewShopData>();

		// Token: 0x0400695C RID: 26972
		private Dictionary<int, List<int>> _shopCostItemIdDictionary = new Dictionary<int, List<int>>();

		// Token: 0x0400695D RID: 26973
		private List<ShopNewShopTabCostItem> _shopTabCostItemList = new List<ShopNewShopTabCostItem>();

		// Token: 0x0400695E RID: 26974
		private Dictionary<ShopTable.eFilter, List<ShopNewFilterData>> _shopFilterDataDictionary = new Dictionary<ShopTable.eFilter, List<ShopNewFilterData>>();

		// Token: 0x0400695F RID: 26975
		private List<int> _shopFirstFilterIndexList = new List<int>();

		// Token: 0x04006960 RID: 26976
		private List<int> _shopSecondFilterIndexList = new List<int>();

		// Token: 0x04006961 RID: 26977
		private List<int> _shopFilterTitleIndexList = new List<int>();

		// Token: 0x04006962 RID: 26978
		private List<int> _shopHideFilterItemList = new List<int>();

		// Token: 0x04006963 RID: 26979
		private float timeInterval;
	}
}
