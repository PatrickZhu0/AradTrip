using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A4E RID: 6734
	internal class ShopDataManager : DataManager<ShopDataManager>
	{
		// Token: 0x17001D52 RID: 7506
		// (get) Token: 0x06010875 RID: 67701 RVA: 0x004A893E File Offset: 0x004A6D3E
		// (set) Token: 0x06010876 RID: 67702 RVA: 0x004A8946 File Offset: 0x004A6D46
		public int MysticalMerchantID
		{
			get
			{
				return this.mysticalMerchantId;
			}
			set
			{
				this.mysticalMerchantId = value;
			}
		}

		// Token: 0x06010877 RID: 67703 RVA: 0x004A894F File Offset: 0x004A6D4F
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ShopDataManager;
		}

		// Token: 0x06010878 RID: 67704 RVA: 0x004A8954 File Offset: 0x004A6D54
		public override void Initialize()
		{
			NetProcess.AddMsgHandler(500926U, new Action<MsgDATA>(this._OnResetShopGoods));
			NetProcess.AddMsgHandler(500927U, new Action<MsgDATA>(this._OnSceneShopItemSync));
			NetProcess.AddMsgHandler(501020U, new Action<MsgDATA>(this._OnSceneSyncMysticalMerchant));
			NetProcess.AddMsgHandler(602824U, new Action<MsgDATA>(this._OnWorldMallQuerySingleItemRes));
			this._InitShopItemTableData();
			this._InitJuedouchangItemPropellingTableData();
			this.InitEquipInitialAttributeTableData();
			this.m_arrShopDatas.Clear();
		}

		// Token: 0x06010879 RID: 67705 RVA: 0x004A89D8 File Offset: 0x004A6DD8
		public override void Clear()
		{
			NetProcess.RemoveMsgHandler(500926U, new Action<MsgDATA>(this._OnResetShopGoods));
			NetProcess.RemoveMsgHandler(500927U, new Action<MsgDATA>(this._OnSceneShopItemSync));
			NetProcess.RemoveMsgHandler(501020U, new Action<MsgDATA>(this._OnSceneSyncMysticalMerchant));
			NetProcess.RemoveMsgHandler(602824U, new Action<MsgDATA>(this._OnWorldMallQuerySingleItemRes));
			this.m_arrShopDatas.Clear();
			this.DuelWeaponsList.Clear();
			this.DuelWeaponsDic.Clear();
			this.juedouchangItemPropelingList.Clear();
			this.oldChangeNewItem.Clear();
			this.mysticalMerchantId = -1;
			this.mEquipInitialAttrbuteDic.Clear();
		}

		// Token: 0x0601087A RID: 67706 RVA: 0x004A8A88 File Offset: 0x004A6E88
		public int RegisterMainFrame()
		{
			int num = ++this.m_iUniqueId;
			this.m_akMainFrameIds.Add(num, num);
			return num;
		}

		// Token: 0x0601087B RID: 67707 RVA: 0x004A8AB8 File Offset: 0x004A6EB8
		public bool _IsShowOldChangeNew(GoodsData goodsData)
		{
			if (goodsData.shopItem.ShopID != 7 && goodsData.shopItem.ShopID != 9)
			{
				return false;
			}
			if (goodsData.Type != ShopTable.eSubType.ST_EQUIP && goodsData.Type != ShopTable.eSubType.ST_ARMOR && goodsData.Type != ShopTable.eSubType.ST_WEAPON)
			{
				return false;
			}
			ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(goodsData.shopItem.ID, string.Empty, string.Empty);
			return tableItem != null && !string.IsNullOrEmpty(tableItem.OldChangeNewItemID);
		}

		// Token: 0x0601087C RID: 67708 RVA: 0x004A8B94 File Offset: 0x004A6F94
		public bool _IsCanOldChangeNew(ItemData data, EPackageType type)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null && item.TableID == data.TableID)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0601087D RID: 67709 RVA: 0x004A8C04 File Offset: 0x004A7004
		public bool _IsPackHaveExchangeEquipment(int id, EPackageType type, ref ItemData oldChangeNewItemData)
		{
			ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (string.IsNullOrEmpty(tableItem.OldChangeNewItemID))
				{
					return type == EPackageType.Equip;
				}
				this._GetOldChangeNewItem(tableItem, this.oldChangeNewItem);
				for (int i = 0; i < this.oldChangeNewItem.Count; i++)
				{
					oldChangeNewItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.oldChangeNewItem[i].ID);
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
					int num = 0;
					if (itemsByPackageType != null)
					{
						for (int j = 0; j < itemsByPackageType.Count; j++)
						{
							ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
							if (item != null && item.TableID == oldChangeNewItemData.TableID)
							{
								if (type != EPackageType.Equip)
								{
									return true;
								}
								num++;
							}
						}
					}
					if (num >= this.oldChangeNewItem[i].Num)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0601087E RID: 67710 RVA: 0x004A8D20 File Offset: 0x004A7120
		public void _GetOldChangeNewItem(ShopItemTable shopItemTable, List<AwardItemData> oldChangeNewItem)
		{
			oldChangeNewItem.Clear();
			if (!string.IsNullOrEmpty(shopItemTable.OldChangeNewItemID))
			{
				string[] array = shopItemTable.OldChangeNewItemID.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						string[] array2 = array[i].Split(new char[]
						{
							'_'
						});
						if (array2.Length == 2)
						{
							int id = int.Parse(array2[0]);
							int num = int.Parse(array2[1]);
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
							if (tableItem != null && num > 0)
							{
								oldChangeNewItem.Add(new AwardItemData
								{
									ID = id,
									Num = num
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x0601087F RID: 67711 RVA: 0x004A8DF8 File Offset: 0x004A71F8
		public List<ulong> GetPackageOldChangeNewEquip(int id)
		{
			List<ulong> list = new List<ulong>();
			ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._GetOldChangeNewItem(tableItem, this.oldChangeNewItem);
				for (int i = 0; i < this.oldChangeNewItem.Count; i++)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.oldChangeNewItem[i].ID);
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
					if (itemsByPackageType != null)
					{
						for (int j = 0; j < itemsByPackageType.Count; j++)
						{
							ulong num = itemsByPackageType[j];
							ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
							if (item != null)
							{
								if (item.TableID == commonItemTableDataByID.TableID)
								{
									list.Add(num);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06010880 RID: 67712 RVA: 0x004A8EE1 File Offset: 0x004A72E1
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010881 RID: 67713 RVA: 0x004A8EF9 File Offset: 0x004A72F9
		public void UnRegisterMainFrame(int iKey)
		{
			this.m_akMainFrameIds.Remove(iKey);
		}

		// Token: 0x06010882 RID: 67714 RVA: 0x004A8F08 File Offset: 0x004A7308
		private bool HasMainFrame(int iKey)
		{
			return this.m_akMainFrameIds.ContainsKey(iKey);
		}

		// Token: 0x06010883 RID: 67715 RVA: 0x004A8F18 File Offset: 0x004A7318
		private void _InitShopItemTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ShopItemTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ShopItemTable shopItemTable = keyValuePair.Value as ShopItemTable;
					if (shopItemTable != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(shopItemTable.ItemID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (shopItemTable.SubType == ShopItemTable.eSubType.ST_EQUIP)
							{
								if (tableItem.SubType == ItemTable.eSubType.WEAPON)
								{
									this.DuelWeaponsList.Add(shopItemTable);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06010884 RID: 67716 RVA: 0x004A8FC8 File Offset: 0x004A73C8
		private void _InitJuedouchangItemPropellingTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JuedouchangItemPropellingTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JuedouchangItemPropellingTable juedouchangItemPropellingTable = keyValuePair.Value as JuedouchangItemPropellingTable;
					if (juedouchangItemPropellingTable != null)
					{
						this.juedouchangItemPropelingList.Add(juedouchangItemPropellingTable);
					}
				}
			}
		}

		// Token: 0x06010885 RID: 67717 RVA: 0x004A902C File Offset: 0x004A742C
		private void InitEquipInitialAttributeTableData()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquipInitialAttribute>())
			{
				EquipInitialAttribute equipInitialAttribute = keyValuePair.Value as EquipInitialAttribute;
				if (!this.mEquipInitialAttrbuteDic.ContainsKey(equipInitialAttribute.ItemID))
				{
					this.mEquipInitialAttrbuteDic.Add(equipInitialAttribute.ItemID, equipInitialAttribute);
				}
			}
		}

		// Token: 0x06010886 RID: 67718 RVA: 0x004A9098 File Offset: 0x004A7498
		public void GetWeaponLeaseInitQualityAndInitStrenth(int itemID, ref int quality, ref int strenth)
		{
			if (this.mEquipInitialAttrbuteDic.ContainsKey(itemID))
			{
				EquipInitialAttribute equipInitialAttribute = this.mEquipInitialAttrbuteDic[itemID];
				quality = equipInitialAttribute.EquipQL;
				strenth = equipInitialAttribute.Strengthen;
			}
		}

		// Token: 0x06010887 RID: 67719 RVA: 0x004A90D4 File Offset: 0x004A74D4
		public bool WeaponLeaseIsRecommendOccu(int itemID)
		{
			bool result = false;
			if (this.mEquipInitialAttrbuteDic.ContainsKey(itemID))
			{
				EquipInitialAttribute equipInitialAttribute = this.mEquipInitialAttrbuteDic[itemID];
				for (int i = 0; i < equipInitialAttribute.FitOccu.Length; i++)
				{
					int num = 0;
					if (int.TryParse(equipInitialAttribute.FitOccu[i], out num))
					{
					}
					if (num == DataManager<PlayerBaseData>.GetInstance().JobTableID)
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06010888 RID: 67720 RVA: 0x004A9150 File Offset: 0x004A7550
		public void InitBaseWeaponData(int curJob)
		{
			this.DuelWeaponsDic.Clear();
			for (int i = 0; i < this.DuelWeaponsList.Count; i++)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.DuelWeaponsList[i].ItemID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Occu.Count >= 1 && tableItem.Occu[0] != 0)
					{
						for (int j = 0; j < tableItem.Occu.Count; j++)
						{
							if (tableItem.Occu[j] / 10 * 10 == curJob)
							{
								List<ShopItemTable> list = null;
								if (!this.DuelWeaponsDic.TryGetValue(tableItem.NeedLevel, out list))
								{
									this.DuelWeaponsDic.Add(tableItem.NeedLevel, new List<ShopItemTable>());
								}
								this.DuelWeaponsDic[tableItem.NeedLevel].Add(this.DuelWeaponsList[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x06010889 RID: 67721 RVA: 0x004A9264 File Offset: 0x004A7664
		public List<ShopItemTable> _ScreenCurrJobDuelWeapons(int curLevel)
		{
			List<ShopItemTable> result = null;
			for (int i = 0; i < this.juedouchangItemPropelingList.Count; i++)
			{
				if (curLevel >= this.juedouchangItemPropelingList[i].NeedMinLevel && curLevel <= this.juedouchangItemPropelingList[i].NeedMaxLevel && this.DuelWeaponsDic.TryGetValue(this.juedouchangItemPropelingList[i].ItemLevel, out result))
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x0601088A RID: 67722 RVA: 0x004A92E3 File Offset: 0x004A76E3
		public Dictionary<int, List<ShopItemTable>> GetDuelWeaponsDict()
		{
			return this.DuelWeaponsDic;
		}

		// Token: 0x0601088B RID: 67723 RVA: 0x004A92EC File Offset: 0x004A76EC
		public void OpenShop(int shopID, int shopLinkID = 0, int shopTabID = -1, ShopFrame.OnShopReturn onShopReturn = null, GameObject goRoot = null, ShopFrame.ShopFrameMode eMode = ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, int target = 0, int linkNpcId = -1)
		{
			if (DataManager<ShopNewDataManager>.GetInstance().IsShopNewFrameByShopId(shopID) && eMode != ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME)
			{
				DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(shopID, 0, shopTabID, -1);
				return;
			}
			ShopData shopData = this.m_arrShopDatas.Find((ShopData data) => data.ID == shopID);
			if (shopData == null)
			{
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				shopData = new ShopData();
				shopData.ID = new int?(tableItem.ID);
				shopData.Name = tableItem.ShopName;
				shopData.ShopNamePath = tableItem.ShopNamePath;
				shopData.GoodsTypes = new List<ShopTable.eSubType>(tableItem.SubType);
				shopData.NeedRefresh = new int?(tableItem.Refresh);
				shopData.RefreshCost = new int?(0);
				shopData.RefreshTime = 0U;
				shopData.RefreshLeftTimes = 0;
				shopData.RefreshTotalTimes = 0;
				shopData.WeekRefreshTime = 0U;
				shopData.MonthRefreshTime = 0U;
				this.m_arrShopDatas.Add(shopData);
			}
			shopData.iLinkNpcId = linkNpcId;
			if (shopData.NeedRefresh == 0)
			{
				if (shopData.Goods.Count <= 0)
				{
					Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ShopItemTable>();
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						ShopItemTable shopItemTable = keyValuePair.Value as ShopItemTable;
						if (shopItemTable.ShopID == shopData.ID)
						{
							GoodsData goodsData = new GoodsData();
							goodsData.ID = new int?(shopItemTable.ID);
							goodsData.ItemData = ItemDataManager.CreateItemDataFromTable(shopItemTable.ItemID, 100, 0);
							goodsData.Type = new ShopTable.eSubType?((ShopTable.eSubType)shopItemTable.SubType);
							goodsData.CostItemData = ItemDataManager.CreateItemDataFromTable(shopItemTable.CostItemID, 100, 0);
							goodsData.CostItemCount = new int?(shopItemTable.CostNum);
							goodsData.eGoodsLimitButyType = (GoodsLimitButyType)shopItemTable.ExLimite;
							goodsData.iLimitValue = shopItemTable.ExValue;
							GoodsData goodsData2 = goodsData;
							Dictionary<int, object>.Enumerator enumerator;
							KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
							goodsData2.shopItem = (keyValuePair2.Value as ShopItemTable);
							goodsData.LimitBuyCount = new int?(1);
							if (goodsData.shopItem != null)
							{
								goodsData.LimitBuyCount = new int?(goodsData.shopItem.GroupNum);
							}
							goodsData.LimitBuyTimes = -1;
							if (goodsData.shopItem != null)
							{
								goodsData.LimitBuyTimes = -1;
							}
							goodsData.ItemData.Count = goodsData.LimitBuyCount.GetValueOrDefault();
							if (goodsData.ItemData != null && goodsData.CostItemData != null)
							{
								shopData.Goods.Add(goodsData);
							}
							else
							{
								if (goodsData.ItemData == null)
								{
									Logger.LogErrorFormat("goodsData.ItemData is null id = {0}", new object[]
									{
										shopItemTable.ItemID
									});
								}
								if (goodsData.CostItemData == null)
								{
									Logger.LogErrorFormat("goodsData.CostItemData is null id = {0}", new object[]
									{
										shopItemTable.CostItemID
									});
								}
							}
						}
					}
				}
				if (eMode == ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME)
				{
					if (onShopReturn != null)
					{
						onShopReturn();
					}
					return;
				}
				ShopFrame.ShopFrameData shopFrameData = new ShopFrame.ShopFrameData();
				shopFrameData.m_kShopData = shopData;
				shopFrameData.m_iShopLinkID = shopLinkID;
				shopFrameData.m_iShopTabID = shopTabID;
				shopFrameData.onShopReturn = onShopReturn;
				shopFrameData.eShopFrameMode = ShopFrame.ShopFrameMode.SFM_MAIN_FRAME;
				if (goRoot == null)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopFrame>(FrameLayer.Middle, shopFrameData, string.Empty);
				}
				else if (target != 0 && this.HasMainFrame(target))
				{
					shopFrameData.eShopFrameMode = eMode;
					IClientFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopFrame>(goRoot, shopFrameData, "ShopFrame" + shopID);
					if (this.onOpenChildShopFrame != null)
					{
						this.onOpenChildShopFrame(shopID, clientFrame as ShopFrame, target);
					}
				}
			}
			else
			{
				SceneShopQuery sceneShopQuery = new SceneShopQuery();
				SceneShopQuery sceneShopQuery2 = sceneShopQuery;
				int? id = shopData.ID;
				sceneShopQuery2.shopId = (byte)id.Value;
				sceneShopQuery.cache = ((shopData.Goods.Count <= 0) ? 0 : 1);
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneShopQuery>(ServerType.GATE_SERVER, sceneShopQuery);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopQueryRet>(delegate(SceneShopQueryRet msgRet)
				{
					if (msgRet.code != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						for (int i = 0; i < this.mysteryShopIDs.Length; i++)
						{
							if (shopID == this.mysteryShopIDs[i])
							{
								MysteryShopData mysteryShopData = new MysteryShopData();
								mysteryShopData.mysteryShopData = shopData;
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<MysteryShopFrame>(FrameLayer.Middle, mysteryShopData, string.Empty);
								return;
							}
						}
						ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopID, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.ShopKind == ShopTable.eShopKind.SK_Lease)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<WeaponLeaseShopFrame>(FrameLayer.Middle, shopData, string.Empty);
							return;
						}
						if (eMode == ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME)
						{
							if (onShopReturn != null)
							{
								onShopReturn();
							}
							return;
						}
						ShopFrame.ShopFrameData shopFrameData2 = new ShopFrame.ShopFrameData();
						shopFrameData2.m_kShopData = shopData;
						shopFrameData2.m_iShopLinkID = shopLinkID;
						shopFrameData2.m_iShopTabID = shopTabID;
						shopFrameData2.onShopReturn = onShopReturn;
						shopFrameData2.eShopFrameMode = ShopFrame.ShopFrameMode.SFM_MAIN_FRAME;
						if (goRoot == null)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopFrame>(FrameLayer.Middle, shopFrameData2, string.Empty);
						}
						else if (target != 0 && this.HasMainFrame(target))
						{
							shopFrameData2.eShopFrameMode = eMode;
							IClientFrame clientFrame2 = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopFrame>(goRoot, shopFrameData2, "ShopFrame" + shopData.ID.Value);
							if (this.onOpenChildShopFrame != null)
							{
								this.onOpenChildShopFrame(shopData.ID.Value, clientFrame2 as ShopFrame, target);
							}
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0601088C RID: 67724 RVA: 0x004A9850 File Offset: 0x004A7C50
		public void OpenMysteryShopFrame()
		{
			MysticalMerchantTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MysticalMerchantTable>(this.MysticalMerchantID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.OpenShop(tableItem.ShopId, 0, -1, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
		}

		// Token: 0x0601088D RID: 67725 RVA: 0x004A9894 File Offset: 0x004A7C94
		public ShopData GetGoodsDataFromShop(int iShopID)
		{
			return this.m_arrShopDatas.Find((ShopData data) => data.ID == iShopID);
		}

		// Token: 0x0601088E RID: 67726 RVA: 0x004A98C7 File Offset: 0x004A7CC7
		protected void _OnSceneShopItemSync(MsgDATA msg)
		{
			Logger.LogError("_OnSceneShopItemSync !");
		}

		// Token: 0x0601088F RID: 67727 RVA: 0x004A98D4 File Offset: 0x004A7CD4
		protected void _OnResetShopGoods(MsgDATA msg)
		{
			int num = 0;
			CustomDecoder.ProtoShop msgRet;
			if (CustomDecoder.DecodeShop(out msgRet, msg.bytes, ref num, msg.bytes.Length) && msgRet != null)
			{
				ShopData shopData = this.m_arrShopDatas.Find(delegate(ShopData data)
				{
					int? id3 = data.ID;
					return ((id3 == null) ? null : new long?((long)id3.Value)) == (long)((ulong)msgRet.shopID);
				});
				if (shopData != null)
				{
					shopData.RefreshCost = new int?((int)msgRet.refreshCost);
					shopData.RefreshTime = msgRet.restRefreshTime;
					shopData.RefreshLeftTimes = (int)msgRet.refreshTimes;
					shopData.RefreshTotalTimes = (int)msgRet.refreshAllTimes;
					shopData.WeekRefreshTime = msgRet.WeekRestRefreshTime;
					shopData.MonthRefreshTime = msgRet.MonthRefreshTime;
					shopData.Goods.Clear();
					for (int i = 0; i < msgRet.shopItemList.Count; i++)
					{
						CustomDecoder.ProtoShopItem protoShopItem = msgRet.shopItemList[i];
						GoodsData goodsData = new GoodsData();
						goodsData.ID = new int?((int)protoShopItem.shopItemId);
						goodsData.VipLimitLevel = new int?((int)protoShopItem.vipLv);
						goodsData.VipDiscount = new int?((int)protoShopItem.vipDiscount);
						TableManager instance = Singleton<TableManager>.GetInstance();
						int? id = goodsData.ID;
						ShopItemTable tableItem = instance.GetTableItem<ShopItemTable>(id.Value, string.Empty, string.Empty);
						goodsData.shopItem = tableItem;
						goodsData.LimitBuyCount = new int?(1);
						if (goodsData.shopItem != null)
						{
							goodsData.LimitBuyCount = new int?(goodsData.shopItem.GroupNum);
						}
						if (tableItem == null)
						{
							string str = "shopItemId = {0} can not find in table shopItemTable!";
							object[] array = new object[1];
							int num2 = 0;
							int? id2 = goodsData.ID;
							array[num2] = id2.Value;
							Logger.LogErrorFormat(str, array);
						}
						else
						{
							goodsData.LimitBuyTimes = (int)protoShopItem.restNum;
							ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>((int)msgRet.shopID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.ShopKind == ShopTable.eShopKind.SK_Lease)
								{
									int subQuality = 0;
									int strengthLevel = 0;
									this.GetWeaponLeaseInitQualityAndInitStrenth(tableItem.ItemID, ref subQuality, ref strengthLevel);
									goodsData.ItemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, subQuality, strengthLevel);
									goodsData.LeaseEndTimeStamp = (int)protoShopItem.leaseEndTimeStamp;
								}
								else
								{
									goodsData.ItemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, 100, 0);
								}
							}
							if (goodsData.ItemData == null)
							{
								Logger.LogErrorFormat("ItemID = {0} can not find in itemTable!", new object[]
								{
									tableItem.ItemID
								});
							}
							else
							{
								goodsData.Type = new ShopTable.eSubType?((ShopTable.eSubType)tableItem.SubType);
								goodsData.CostItemData = ItemDataManager.CreateItemDataFromTable(tableItem.CostItemID, 100, 0);
								if (goodsData.CostItemData == null)
								{
									Logger.LogErrorFormat("CostItemID = {0} can not find in itemTable!", new object[]
									{
										tableItem.CostItemID
									});
								}
								else
								{
									goodsData.CostItemCount = new int?(tableItem.CostNum);
									goodsData.eGoodsLimitButyType = (GoodsLimitButyType)tableItem.ExLimite;
									goodsData.iLimitValue = tableItem.ExValue;
									goodsData.ItemData.Count = goodsData.LimitBuyCount.GetValueOrDefault();
									goodsData.TotalLimitBuyTimes = tableItem.NumLimite;
									goodsData.GoodsDisCount = new int?((int)protoShopItem.discount);
									if (goodsData.ItemData != null && goodsData.CostItemData != null)
									{
										shopData.Goods.Add(goodsData);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06010890 RID: 67728 RVA: 0x004A9C64 File Offset: 0x004A8064
		public void BuyGoods(int shopID, int goodsID, int count, List<ItemInfo> info)
		{
			SceneShopBuy sceneShopBuy = new SceneShopBuy();
			sceneShopBuy.shopId = (byte)shopID;
			sceneShopBuy.shopItemId = (uint)goodsID;
			sceneShopBuy.num = (ushort)count;
			sceneShopBuy.costExtraItems = info.ToArray();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneShopBuy>(ServerType.GATE_SERVER, sceneShopBuy);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopBuyRet>(delegate(SceneShopBuyRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventID = EUIEventID.ShopBuyGoodsSuccess;
					idleUIEvent.EventParams.buyGoodsResult = new BuyGoodsResult((int)msgRet.shopItemId, (int)msgRet.newNum);
					ShopData goodsDataFromShop = this.GetGoodsDataFromShop(shopID);
					if (goodsDataFromShop != null)
					{
						GoodsData goodsData = goodsDataFromShop.Goods.Find(delegate(GoodsData x)
						{
							int? id = x.ID;
							return ((id == null) ? null : new long?((long)id.Value)) == (long)((ulong)msgRet.shopItemId);
						});
						if (goodsData != null)
						{
							goodsData.LimitBuyTimes = ((goodsData.LimitBuyTimes < 0) ? -1 : ((int)msgRet.newNum));
							ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopID, string.Empty, string.Empty);
							if (tableItem != null && tableItem.ShopKind == ShopTable.eShopKind.SK_Lease)
							{
								goodsData.LeaseEndTimeStamp = (int)msgRet.leaseEndTimeStamp;
							}
							UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
						}
					}
				}
			}, true, 15f, null);
		}

		// Token: 0x06010891 RID: 67729 RVA: 0x004A9CE4 File Offset: 0x004A80E4
		public void RefreshShop(int shopID)
		{
			SceneShopRefresh sceneShopRefresh = new SceneShopRefresh();
			sceneShopRefresh.shopId = (byte)shopID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneShopRefresh>(ServerType.GATE_SERVER, sceneShopRefresh);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopRefreshRet>(delegate(SceneShopRefreshRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventID = EUIEventID.ShopRefreshSuccess;
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				}
			}, true, 15f, null);
		}

		// Token: 0x06010892 RID: 67730 RVA: 0x004A9D40 File Offset: 0x004A8140
		public void _OnSceneSyncMysticalMerchant(MsgDATA msg)
		{
			SceneSyncMysticalMerchant sceneSyncMysticalMerchant = new SceneSyncMysticalMerchant();
			sceneSyncMysticalMerchant.decode(msg.bytes);
			this.mysticalMerchantId = (int)sceneSyncMysticalMerchant.id;
			this.MysticalMerchantTiggerNumber();
			this.MysticalMerchantType();
		}

		// Token: 0x06010893 RID: 67731 RVA: 0x004A9D78 File Offset: 0x004A8178
		public void OnGoldBuy(int id)
		{
			WorldMallQuerySingleItemReq worldMallQuerySingleItemReq = new WorldMallQuerySingleItemReq();
			worldMallQuerySingleItemReq.mallItemId = (uint)id;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallQuerySingleItemReq>(ServerType.GATE_SERVER, worldMallQuerySingleItemReq);
		}

		// Token: 0x06010894 RID: 67732 RVA: 0x004A9DA4 File Offset: 0x004A81A4
		private void _OnWorldMallQuerySingleItemRes(MsgDATA msg)
		{
			WorldMallQuerySingleItemRes worldMallQuerySingleItemRes = new WorldMallQuerySingleItemRes();
			worldMallQuerySingleItemRes.decode(msg.bytes);
			if (worldMallQuerySingleItemRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMallQuerySingleItemRes.retCode, string.Empty);
			}
			else
			{
				MallItemInfo mallItemInfo = worldMallQuerySingleItemRes.mallItemInfo;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItemInfo, string.Empty);
			}
		}

		// Token: 0x06010895 RID: 67733 RVA: 0x004A9DFC File Offset: 0x004A81FC
		public bool FindMysteryShopID(int shopId)
		{
			bool result = false;
			for (int i = 0; i < DataManager<ShopDataManager>.GetInstance().mysteryShopIDs.Length; i++)
			{
				if (shopId == DataManager<ShopDataManager>.GetInstance().mysteryShopIDs[i])
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06010896 RID: 67734 RVA: 0x004A9E42 File Offset: 0x004A8242
		private void MysticalMerchantTiggerNumber()
		{
			this.mySteryMerchantTriggerNumber++;
			Singleton<GameStatisticManager>.GetInstance().DoStartMysticalMerchant(this.mySteryMerchantTriggerNumber);
		}

		// Token: 0x06010897 RID: 67735 RVA: 0x004A9E64 File Offset: 0x004A8264
		private void MysticalMerchantType()
		{
			MysticalMerchantTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MysticalMerchantTable>(this.MysticalMerchantID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(tableItem.ShopId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			Singleton<GameStatisticManager>.GetInstance().DoStartMysticalMerchantType(tableItem2.ShopName);
		}

		// Token: 0x0400A85A RID: 43098
		private List<ShopData> m_arrShopDatas = new List<ShopData>();

		// Token: 0x0400A85B RID: 43099
		private List<ShopItemTable> DuelWeaponsList = new List<ShopItemTable>();

		// Token: 0x0400A85C RID: 43100
		private Dictionary<int, List<ShopItemTable>> DuelWeaponsDic = new Dictionary<int, List<ShopItemTable>>();

		// Token: 0x0400A85D RID: 43101
		private List<JuedouchangItemPropellingTable> juedouchangItemPropelingList = new List<JuedouchangItemPropellingTable>();

		// Token: 0x0400A85E RID: 43102
		private Dictionary<int, EquipInitialAttribute> mEquipInitialAttrbuteDic = new Dictionary<int, EquipInitialAttribute>();

		// Token: 0x0400A85F RID: 43103
		private int mySteryMerchantTriggerNumber;

		// Token: 0x0400A860 RID: 43104
		public int[] mysteryShopIDs = new int[]
		{
			17,
			18,
			19
		};

		// Token: 0x0400A861 RID: 43105
		private int mysticalMerchantId = -1;

		// Token: 0x0400A862 RID: 43106
		public ShopDataManager.OnOpenChildShopFrame onOpenChildShopFrame;

		// Token: 0x0400A863 RID: 43107
		private int m_iUniqueId;

		// Token: 0x0400A864 RID: 43108
		private Dictionary<int, int> m_akMainFrameIds = new Dictionary<int, int>();

		// Token: 0x0400A865 RID: 43109
		private List<AwardItemData> oldChangeNewItem = new List<AwardItemData>();

		// Token: 0x02001A4F RID: 6735
		// (Invoke) Token: 0x0601089A RID: 67738
		public delegate void OnOpenChildShopFrame(int iShopID, ShopFrame frame, int iId);
	}
}
